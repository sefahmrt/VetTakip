using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VetTakip
{
    public partial class SahiplerPanel : UserControl
    {
        // Pooling=True: bağlantı her seferinde sıfırdan açılmaz, havuzdan alınır.
        private const string BaglantiYolu = @"Data Source=vettakip.db;Version=3;Pooling=True;";

        private const string ListeSorgusu = @"
            SELECT
                m.id AS [Id],
                m.aktif AS [Aktif],
                m.ad || ' ' || m.soyad AS [Ad Soyad],
                m.tel AS [Telefon],
                IFNULL(m.il, '') || ' / ' || IFNULL(m.ilce, '') AS [İl/İlçe],
                (SELECT COUNT(*) FROM hasta h WHERE h.musteri_id = m.id) AS [Evcil Hayvan Sayısı],
                CASE m.sms_izni WHEN 1 THEN 'Var' ELSE 'Yok' END AS [SMS İzni]
            FROM musteri m;";

        private const string HayvanSorgusu = @"
            SELECT h.id, h.ad, t.ad AS tur, i.ad AS irk, h.cinsiyet, h.dogum_tarihi,
                   h.mikrocip_no, h.durum,
                   (SELECT mu.kilo FROM muayene mu
                     WHERE mu.hasta_id = h.id AND mu.kilo IS NOT NULL
                     ORDER BY mu.tarih DESC LIMIT 1) AS kilo,
                   (SELECT MAX(x) FROM (
                        SELECT date(mu.tarih) AS x FROM muayene mu WHERE mu.hasta_id = h.id
                        UNION ALL
                        SELECT date(r.baslangic) FROM randevu r
                         WHERE r.hasta_id = h.id AND r.durum IN ('Geldi', 'Tamamlandı'))) AS son_ziyaret
            FROM hasta h
            JOIN tur t ON t.id = h.tur_id
            LEFT JOIN irk i ON i.id = h.irk_id
            WHERE h.musteri_id = @id
            ORDER BY h.ad";

        private const string ZiyaretSorgusu = @"
            SELECT strftime('%d.%m.%Y %H:%M', r.baslangic) AS [Tarih],
                   h.ad AS [Hayvan],
                   IFNULL(r.islem, '') AS [İşlem],
                   k.ad AS [Hekim],
                   r.durum AS [Durum]
            FROM randevu r
            JOIN hasta h ON h.id = r.hasta_id
            JOIN hekim k ON k.id = r.hekim_id
            WHERE h.musteri_id = @id
            ORDER BY r.baslangic DESC";

        private static readonly CultureInfo Tr = new CultureInfo("tr-TR");
        private static readonly Color Yesil = Color.FromArgb(22, 163, 74);
        private static readonly Color AvatarYesil = Color.FromArgb(46, 204, 113);
        private static readonly Color AvatarGri = Color.FromArgb(156, 163, 175);
        private static readonly Color Koyu = Color.FromArgb(17, 24, 39);
        private static readonly Color Kirmizi = Color.FromArgb(220, 38, 38);
        private static readonly Color PasifGri = Color.FromArgb(156, 163, 175);

        // Font nesneleri bir kez oluşturulur (her kart / her sekme tıklamasında yeniden oluşturulmaz).
        private static readonly Font FontGrid = new Font("Inter", 13F);
        private static readonly Font FontGridBaslik = new Font("Inter", 15F, FontStyle.Bold);
        private static readonly Font FontZiyaret = new Font("Inter", 9.5F);
        private static readonly Font FontZiyaretBaslik = new Font("Inter", 9.5F, FontStyle.Bold);
        private static readonly Font FontSekme = new Font("Inter", 11F, FontStyle.Regular);
        private static readonly Font FontSekmeSecili = new Font("Inter", 11F, FontStyle.Bold);
        private static readonly Font FontKartSimge = new Font("Inter", 18F, FontStyle.Bold);
        private static readonly Font FontKartAd = new Font("Inter", 12F, FontStyle.Bold);
        private static readonly Font FontKartDetay = new Font("Inter", 10F);
        private static readonly Font FontKartButon = new Font("Inter", 9F);

        // Telefon biçimlendirme sonuçları önbelleğe alınır (CellFormatting çok sık çağrılır).
        private static readonly Dictionary<string, string> TelefonOnbellek = new Dictionary<string, string>();

        private static readonly object IndeksKilidi = new object();
        private static bool indeksKontrolEdildi;

        // Arka planda hazırlanan detay verisi
        private sealed class DetayVerisi
        {
            public DataTable Musteri;
            public DataTable Hayvanlar;
        }

        private DataTable sahiplerTablosu;

        private int? seciliMusteriId;
        private int? ziyaretlerYuklenenId;
        private bool seciliAktif = true;
        private bool seciliSmsIzni;
        private bool listeGuncelleniyor;
        private int aktifSekme;

        // Eski (geç dönen) arka plan sonuçlarını yok saymak için istek sayaçları
        private int listeIstekNo;
        private int detayIstekNo;

        // Ok tuşlarıyla hızlı gezerken her satır için veritabanına gitmemek için kısa bir bekleme.
        private readonly Timer secimZamanlayici = new Timer { Interval = 50 };

        // Ana form bu olaylara abone olarak ilgili ekranları açabilir (parametre: müşteri id veya hasta id).
        public event Action<int> MusteriDuzenleIstendi;
        public event Action<int> SmsGonderIstendi;
        public event Action<int> HayvanEkleIstendi;   // müşteri id
        public event Action<int> HayvanKartiAcIstendi; // hasta id

        public SahiplerPanel()
        {
            InitializeComponent();

            // Panel ve alt kontrollerin çizimi tamponlanır, açılışta titreme azalır.
            DoubleBuffered = true;

            bool tasarimModu = LicenseManager.UsageMode == LicenseUsageMode.Designtime;

            AnaGridiBicimle();
            ZiyaretGridiniBicimle();

            dataGridView1.CellFormatting += dataGridView1_CellFormatting;
            txtAra.TextChanged += txtAra_TextChanged; // Designer'da ayrıca bağlama, olay iki kez çalışır

            secimZamanlayici.Tick += delegate
            {
                secimZamanlayici.Stop();
                SeciliSahibiGoster(false);
            };
            Disposed += delegate { secimZamanlayici.Dispose(); };

            SekmeSec(0);

            // Veri gelene kadar ne "detay" ne de "seçim yok" yazısı görünsün (yanlış mesaj çakması olmasın).
            pnlDetay.Visible = false;
            lblSecimYok.Visible = false;

            // Veri yükleme arka planda başlar; panel hemen açılır, liste hazır olunca dolar.
            if (!tasarimModu)
                SahipleriListele();
        }

        // ------------------------------------------------------------------
        //  Isıtma: GirisForm açılırken arka planda çağrılırsa ilk sorgu gecikmesi kalmaz
        //  Örnek (GirisForm constructor'ı):  Task.Run(() => SahiplerPanel.Isit());
        // ------------------------------------------------------------------

        public static void Isit()
        {
            try
            {
                IndeksleriHazirla();
                using (SQLiteConnection baglanti = new SQLiteConnection(BaglantiYolu))
                {
                    baglanti.Open();
                    using (SQLiteCommand komut = new SQLiteCommand("SELECT 1", baglanti))
                        komut.ExecuteScalar();
                }
            }
            catch
            {
                // Isıtma başarısız olursa sorun değil; ilk gerçek sorgu hatayı zaten gösterir.
            }
        }

        // ------------------------------------------------------------------
        //  Grid ayarları
        // ------------------------------------------------------------------

        private static void CiftTamponla(DataGridView grid)
        {
            // DataGridView'da DoubleBuffered korumalı olduğu için reflection ile açılır; kaydırma/çizim akıcılaşır.
            typeof(DataGridView).GetProperty("DoubleBuffered",
                BindingFlags.Instance | BindingFlags.NonPublic).SetValue(grid, true, null);
        }

        private void AnaGridiBicimle()
        {
            DataGridView g = dataGridView1;
            CiftTamponla(g);

            g.BorderStyle = BorderStyle.None;
            g.BackgroundColor = Color.White;
            g.GridColor = Color.FromArgb(229, 231, 235);
            g.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            g.RowHeadersVisible = false;
            g.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            g.MultiSelect = false;

            g.EnableHeadersVisualStyles = false;
            g.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            g.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            g.ColumnHeadersHeight = 38;

            g.DefaultCellStyle.BackColor = Color.White;
            g.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(249, 250, 251);
            g.DefaultCellStyle.ForeColor = Color.FromArgb(31, 41, 55);
            g.DefaultCellStyle.SelectionBackColor = Color.FromArgb(209, 250, 229);
            g.DefaultCellStyle.SelectionForeColor = Color.FromArgb(6, 95, 70);
            g.DefaultCellStyle.Font = FontGrid;
            g.DefaultCellStyle.Padding = new Padding(8, 0, 10, 0);

            g.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(243, 244, 246);
            g.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(75, 85, 99);
            g.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(243, 244, 246);
            g.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.FromArgb(75, 85, 99);
            g.ColumnHeadersDefaultCellStyle.Font = FontGridBaslik;
            g.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            g.ColumnHeadersDefaultCellStyle.Padding = new Padding(8, 0, 10, 0);

            g.ReadOnly = true;
            g.AllowUserToAddRows = false;
            g.AllowUserToDeleteRows = false;
            g.AllowUserToResizeColumns = false;
            g.AllowUserToResizeRows = false;

            // SABİT satır yüksekliği: AutoSizeRowsMode.AllCells her hücreyi ölçtüğü için çok yavaştı.
            g.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            g.RowTemplate.Height = 44;
            g.ScrollBars = ScrollBars.Both;
        }

        private void KolonlariAyarla()
        {
            DataGridView g = dataGridView1;
            if (g.Columns["Id"] == null) return;

            g.Columns["Id"].Visible = false;
            g.Columns["Aktif"].Visible = false;

            foreach (DataGridViewColumn kolon in g.Columns)
                kolon.SortMode = DataGridViewColumnSortMode.NotSortable;

            g.Columns["Evcil Hayvan Sayısı"].HeaderText = "Hayvan Sayısı";
            g.Columns["SMS İzni"].HeaderText = "Sms İzni";

            // AllCells yerine Fill + FillWeight: ölçüm gerektirmez, tek geçişte yerleşir.
            g.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            AyarlaKolon("Ad Soyad", 150, 140);
            AyarlaKolon("Telefon", 125, 120);
            AyarlaKolon("İl/İlçe", 140, 130);
            AyarlaKolon("Evcil Hayvan Sayısı", 125, 110);
            AyarlaKolon("SMS İzni", 80, 90);
        }

        private void AyarlaKolon(string ad, float agirlik, int minGenislik)
        {
            DataGridViewColumn k = dataGridView1.Columns[ad];
            k.FillWeight = agirlik;
            k.MinimumWidth = minGenislik;
        }

        // ------------------------------------------------------------------
        //  Veritabanı (ARKA PLAN İŞ PARÇACIĞINDA çalışır: kontrollere dokunma!)
        // ------------------------------------------------------------------

        private static void IndeksleriHazirla()
        {
            lock (IndeksKilidi)
            {
                if (indeksKontrolEdildi) return;
                indeksKontrolEdildi = true;

                try
                {
                    using (SQLiteConnection baglanti = new SQLiteConnection(BaglantiYolu))
                    {
                        baglanti.Open();
                        string sql = @"
                            CREATE INDEX IF NOT EXISTS idx_hasta_musteri  ON hasta(musteri_id);
                            CREATE INDEX IF NOT EXISTS idx_muayene_hasta  ON muayene(hasta_id, tarih);
                            CREATE INDEX IF NOT EXISTS idx_randevu_hasta  ON randevu(hasta_id, baslangic);";
                        using (SQLiteCommand komut = new SQLiteCommand(sql, baglanti))
                            komut.ExecuteNonQuery();
                    }
                }
                catch
                {
                    // İndeks oluşturulamazsa (ör. tablo adı farklı / salt okunur) uygulama yine çalışsın.
                }
            }
        }

        private static DataTable ListeyiGetir()
        {
            IndeksleriHazirla();

            var tablo = new DataTable { Locale = Tr };
            using (SQLiteConnection baglanti = new SQLiteConnection(BaglantiYolu))
            using (SQLiteDataAdapter adaptor = new SQLiteDataAdapter(ListeSorgusu, baglanti))
            {
                adaptor.Fill(tablo);
            }
            return tablo;
        }

        private static DetayVerisi DetayVerisiGetir(int id)
        {
            var veri = new DetayVerisi { Musteri = new DataTable(), Hayvanlar = new DataTable() };

            using (SQLiteConnection baglanti = new SQLiteConnection(BaglantiYolu))
            {
                baglanti.Open();

                using (var adaptor = new SQLiteDataAdapter("SELECT * FROM musteri WHERE id = @id", baglanti))
                {
                    adaptor.SelectCommand.Parameters.AddWithValue("@id", id);
                    adaptor.Fill(veri.Musteri);
                }

                using (var adaptor = new SQLiteDataAdapter(HayvanSorgusu, baglanti))
                {
                    adaptor.SelectCommand.Parameters.AddWithValue("@id", id);
                    adaptor.Fill(veri.Hayvanlar);
                }
            }
            return veri;
        }

        private static DataTable ZiyaretTablosuGetir(int id)
        {
            var tablo = new DataTable();
            using (SQLiteConnection baglanti = new SQLiteConnection(BaglantiYolu))
            using (var adaptor = new SQLiteDataAdapter(ZiyaretSorgusu, baglanti))
            {
                adaptor.SelectCommand.Parameters.AddWithValue("@id", id);
                adaptor.Fill(tablo);
            }
            return tablo;
        }

        // ------------------------------------------------------------------
        //  SOL TARAF: sahip listesi
        // ------------------------------------------------------------------

        private async void SahipleriListele(int? seciliKalacakId = null)
        {
            int istek = ++listeIstekNo;
            DataTable yeni;

            try
            {
                // Sorgu arka planda çalışır; arayüz bu sırada donmaz, panel hemen görünür.
                yeni = await Task.Run(() => ListeyiGetir());
            }
            catch (Exception hata)
            {
                if (!IsDisposed && istek == listeIstekNo)
                    MessageBox.Show("Veriler listelenirken bir hata oluştu:\n" + hata.Message,
                                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Panel kapandıysa veya daha yeni bir istek başladıysa bu sonuç geçersiz
            if (IsDisposed || istek != listeIstekNo) return;

            listeGuncelleniyor = true;
            secimZamanlayici.Stop();
            dataGridView1.SuspendLayout();
            try
            {
                sahiplerTablosu = yeni;
                dataGridView1.DataSource = sahiplerTablosu;
                KolonlariAyarla();
                FiltreUygula();
                SatirSec(seciliKalacakId);
            }
            finally
            {
                dataGridView1.ResumeLayout();
                listeGuncelleniyor = false;
            }

            SeciliSahibiGoster(true);
        }

        private void SatirSec(int? id)
        {
            if (id == null) return;
            foreach (DataGridViewRow satir in dataGridView1.Rows)
            {
                if (SatirId(satir) == id)
                {
                    satir.Selected = true;
                    dataGridView1.CurrentCell = satir.Cells["Ad Soyad"];
                    return;
                }
            }
        }

        private static int? SatirId(DataGridViewRow satir)
        {
            DataRowView drv = satir.DataBoundItem as DataRowView;
            if (drv == null) return null;
            return Convert.ToInt32(drv["Id"]);
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (listeGuncelleniyor) return;

            // Hızlı gezinmede sadece son satır yüklensin diye kısa bekleme.
            secimZamanlayici.Stop();
            secimZamanlayici.Start();
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataRowView drv = dataGridView1.Rows[e.RowIndex].DataBoundItem as DataRowView;

            // Pasif satırlar gri yapılsın
            if (drv != null && Convert.ToInt32(drv["Aktif"]) == 0)
                e.CellStyle.ForeColor = PasifGri;

            // Telefon hücresi formatlansın
            if (e.Value != null && dataGridView1.Columns[e.ColumnIndex].Name == "Telefon")
            {
                e.Value = TelefonMetni(e.Value.ToString());
                e.FormattingApplied = true;
            }
        }

        private void txtAra_TextChanged(object sender, EventArgs e)
        {
            FiltreUygula();
        }

        private void FiltreUygula()
        {
            if (sahiplerTablosu == null) return;

            string aranan = FiltreIcinTemizle(txtAra.Text.Trim());

            if (aranan.Length == 0)
            {
                sahiplerTablosu.DefaultView.RowFilter = "";
                return;
            }

            sahiplerTablosu.DefaultView.RowFilter = string.Format(
                "[Ad Soyad] LIKE '%{0}%' OR Convert(Telefon, 'System.String') LIKE '%{0}%'",
                aranan);
        }

        private string FiltreIcinTemizle(string metin)
        {
            var sb = new StringBuilder();
            foreach (char c in metin)
            {
                switch (c)
                {
                    case '\'': sb.Append("''"); break;
                    case '[':
                    case ']':
                    case '%':
                    case '*': sb.Append('[').Append(c).Append(']'); break;
                    default: sb.Append(c); break;
                }
            }
            return sb.ToString();
        }

        // ------------------------------------------------------------------
        //  SAĞ TARAF: seçilen sahibin detayı (roundedPanel2)
        // ------------------------------------------------------------------

        private void SeciliSahibiGoster(bool zorla)
        {
            int? id = null;
            if (dataGridView1.SelectedRows.Count > 0)
                id = SatirId(dataGridView1.SelectedRows[0]);

            if (id == null)
            {
                detayIstekNo++; // bekleyen detay sonuçları geçersiz olsun
                seciliMusteriId = null;
                ziyaretlerYuklenenId = null;
                DetayGoster(false);
                return;
            }

            if (!zorla && id == seciliMusteriId) return;

            SahipDetayiniYukle(id.Value);
        }

        private void DetayGoster(bool goster)
        {
            pnlDetay.Visible = goster;
            lblSecimYok.Visible = !goster;
        }

        private async void SahipDetayiniYukle(int id)
        {
            int istek = ++detayIstekNo;
            DetayVerisi veri;

            try
            {
                veri = await Task.Run(() => DetayVerisiGetir(id));
            }
            catch (Exception hata)
            {
                if (!IsDisposed && istek == detayIstekNo)
                    MessageBox.Show("Sahip bilgileri yüklenirken bir hata oluştu:\n" + hata.Message,
                                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kullanıcı bu arada başka satıra geçtiyse bu sonuç atılır
            if (IsDisposed || istek != detayIstekNo) return;

            if (veri.Musteri.Rows.Count == 0)
            {
                seciliMusteriId = null;
                ziyaretlerYuklenenId = null;
                DetayGoster(false);
                return;
            }

            pnlDetay.SuspendLayout();
            try
            {
                SahipBilgileriniDoldur(id, veri.Musteri.Rows[0]);
                HayvanKartlariniOlustur(veri.Hayvanlar);
                lblTabHayvanlar.Text = "Hayvanlar (" + veri.Hayvanlar.Rows.Count + ")";

                seciliMusteriId = id;

                // Ziyaretler sekmesi yalnızca açıldığında yüklenir (tembel yükleme).
                ziyaretlerYuklenenId = null;

                SekmeSec(aktifSekme);
                DetayGoster(true);
            }
            catch (Exception hata)
            {
                MessageBox.Show("Sahip bilgileri gösterilirken bir hata oluştu:\n" + hata.Message,
                                "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                pnlDetay.ResumeLayout(true);
            }
        }

        private async void ZiyaretleriYukle(int id)
        {
            ziyaretlerYuklenenId = id; // aynı sahip için tekrar tekrar tetiklenmesin
            DataTable ziyaretler;

            try
            {
                ziyaretler = await Task.Run(() => ZiyaretTablosuGetir(id));
            }
            catch (Exception hata)
            {
                ziyaretlerYuklenenId = null;
                if (!IsDisposed)
                    MessageBox.Show("Ziyaretler yüklenirken bir hata oluştu:\n" + hata.Message,
                                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (IsDisposed || seciliMusteriId != id) return;

            dgvZiyaretler.DataSource = ziyaretler;
            dgvZiyaretler.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvZiyaretler.ClearSelection();
        }

        private void SahipBilgileriniDoldur(int id, DataRow m)
        {
            string ad = Metin(m["ad"]);
            string soyad = Metin(m["soyad"]);
            bool aktif = Convert.ToInt32(m["aktif"]) == 1;
            bool smsIzni = Convert.ToInt32(m["sms_izni"]) == 1;
            string ilce = Metin(m["ilce"]);
            string il = Metin(m["il"]);
            string adres = Metin(m["adres"]);
            string kayit = TarihMetni(Metin(m["kayit_tarihi"]));

            seciliAktif = aktif;
            seciliSmsIzni = smsIzni;

            lblAvatar.Text = BasHarfler(ad, soyad);
            pnlAvatar.BackColor = aktif ? AvatarYesil : AvatarGri;
            pnlAvatar.Invalidate();
            lblAdSoyad.Text = (ad + " " + soyad).Trim() + (aktif ? "" : "  (Pasif)");
            lblMusteriNo.Text = "müşteri no " + id.ToString("D4") + " · Kayıt " + kayit;

            btnPasifeAl.Text = aktif ? "Pasife al" : "Aktife al";
            btnSmsGonder.Enabled = smsIzni;

            // FORMATLANMIŞ VERİLER
            lblTelefonDeger.Text = TelefonMetni(Metin(m["tel"]));
            lblTcDeger.Text = Bos(Metin(m["tc"]));

            string acilKisi = Metin(m["acil_kisi"]);
            string acilTel = TelefonMetni(Metin(m["acil_tel"]));
            if (acilKisi.Length > 0 && acilTel.Length > 0 && acilTel != "—")
                lblAcilKisiDeger.Text = acilKisi + " * " + acilTel;
            else
                lblAcilKisiDeger.Text = Bos(acilKisi + (acilTel == "—" ? "" : acilTel));

            lblKvkkDeger.Text = kayit;
            lblEpostaDeger.Text = Bos(Metin(m["eposta"]));

            string bolge = (ilce.Length > 0 && il.Length > 0) ? ilce + " / " + il : ilce + il;
            lblAdresDeger.Text = adres.Length > 0
                ? (bolge.Length > 0 ? adres + ", " + bolge : adres)
                : Bos(bolge);

            lblSmsIzniDeger.Text = smsIzni ? "Var" : "Yok";
            lblSmsIzniDeger.ForeColor = smsIzni ? Yesil : Kirmizi;

            lblNotDeger.Text = "Yok";
        }

        // ------------------------------------------------------------------
        //  Hayvan kartları
        // ------------------------------------------------------------------

        private void HayvanKartlariniOlustur(DataTable hayvanlar)
        {
            flpHayvanlar.SuspendLayout();

            for (int i = flpHayvanlar.Controls.Count - 1; i >= 0; i--)
            {
                Control c = flpHayvanlar.Controls[i];
                if (c == btnHayvanEkle) continue;
                flpHayvanlar.Controls.Remove(c);
                c.Dispose();
            }

            int genislik = flpHayvanlar.Width - SystemInformation.VerticalScrollBarWidth - flpHayvanlar.Padding.Horizontal;

            foreach (DataRow satir in hayvanlar.Rows)
                flpHayvanlar.Controls.Add(KartOlustur(satir, genislik));

            btnHayvanEkle.Width = genislik;
            flpHayvanlar.Controls.SetChildIndex(btnHayvanEkle, flpHayvanlar.Controls.Count - 1);

            flpHayvanlar.ResumeLayout(true);
            flpHayvanlar.AutoScrollPosition = new Point(0, 0);
        }

        private Control KartOlustur(DataRow h, int genislik)
        {
            int hastaId = Convert.ToInt32(h["id"]);
            string ad = Metin(h["ad"]);
            string durum = Metin(h["durum"]);

            var kart = new RoundedPanel();
            kart.SuspendLayout();
            kart.BackColor = Color.FromArgb(229, 231, 235);
            kart.BorderColor = Color.Silver;
            kart.BorderRadius = 10;
            kart.BorderSize = 0;
            kart.Margin = new Padding(0, 0, 0, 10);
            kart.Size = new Size(genislik, 96);

            var simge = new Label();
            simge.BackColor = Color.White;
            simge.ForeColor = Yesil;
            simge.Font = FontKartSimge;
            simge.TextAlign = ContentAlignment.MiddleCenter;
            simge.Text = ad.Length > 0 ? ad.Substring(0, 1).ToUpper(Tr) : "?";
            simge.Bounds = new Rectangle(12, 16, 64, 64);
            kart.Controls.Add(simge);

            int metinGenislik = genislik - 88 - 100;

            var lblAd = new Label();
            lblAd.AutoEllipsis = true;
            lblAd.BackColor = Color.Transparent;
            lblAd.ForeColor = Koyu;
            lblAd.Font = FontKartAd;
            lblAd.Text = ad + (durum.Length > 0 && durum != "Aktif" ? "  (" + durum + ")" : "");
            lblAd.Bounds = new Rectangle(88, 12, metinGenislik, 26);
            kart.Controls.Add(lblAd);

            var lblDetay = new Label();
            lblDetay.AutoEllipsis = true;
            lblDetay.BackColor = Color.Transparent;
            lblDetay.ForeColor = Koyu;
            lblDetay.Font = FontKartDetay;
            lblDetay.Text = HayvanOzeti(h);
            lblDetay.Bounds = new Rectangle(88, 40, genislik - 88 - 12, 22);
            kart.Controls.Add(lblDetay);

            string cip = Metin(h["mikrocip_no"]);
            string son = Metin(h["son_ziyaret"]);
            var lblAlt = new Label();
            lblAlt.AutoEllipsis = true;
            lblAlt.BackColor = Color.Transparent;
            lblAlt.ForeColor = Koyu;
            lblAlt.Font = FontKartDetay;
            lblAlt.Text = (cip.Length > 0 ? "çip " + Gruplu(cip, 3) : "çip yok") + " - "
                          + (son.Length > 0 ? "Son ziyareti " + TarihMetni(son) : "Henüz ziyaret yok");
            lblAlt.Bounds = new Rectangle(88, 64, genislik - 88 - 12, 22);
            kart.Controls.Add(lblAlt);

            var btnKart = new Button();
            btnKart.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnKart.BackColor = Color.White;
            btnKart.Cursor = Cursors.Hand;
            btnKart.FlatStyle = FlatStyle.Flat;
            btnKart.FlatAppearance.BorderSize = 0;
            btnKart.ForeColor = Koyu;
            btnKart.Font = FontKartButon;
            btnKart.Text = "Kartı aç";
            btnKart.Tag = hastaId;
            btnKart.UseVisualStyleBackColor = false;
            btnKart.Bounds = new Rectangle(genislik - 92, 10, 80, 28);
            btnKart.Click += btnKartiAc_Click;
            kart.Controls.Add(btnKart);

            btnKart.BringToFront();
            kart.ResumeLayout(false);
            return kart;
        }

        private static string HayvanOzeti(DataRow h)
        {
            var parcalar = new List<string>();
            string tur = Metin(h["tur"]);
            string irk = Metin(h["irk"]);
            string cinsiyet = Metin(h["cinsiyet"]);
            string yas = YasMetni(Metin(h["dogum_tarihi"]));

            if (tur.Length > 0) parcalar.Add(tur);
            if (irk.Length > 0) parcalar.Add(irk);
            if (cinsiyet.Length > 0) parcalar.Add(cinsiyet);
            if (yas != null) parcalar.Add(yas);

            if (h["kilo"] != DBNull.Value)
                parcalar.Add(Convert.ToDouble(h["kilo"], CultureInfo.InvariantCulture)
                                    .ToString("0.##", Tr) + " kg");

            return string.Join(" - ", parcalar.ToArray());
        }

        private static string YasMetni(string dogum)
        {
            DateTime d;
            if (!DateTime.TryParseExact(dogum, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out d))
                return null;

            DateTime bugun = DateTime.Today;
            if (d > bugun) return null;

            int yil = bugun.Year - d.Year;
            if (d.AddYears(yil) > bugun) yil--;
            if (yil >= 1) return yil + " Yaş";

            int ay = ((bugun.Year - d.Year) * 12) + bugun.Month - d.Month;
            if (bugun.Day < d.Day) ay--;
            if (ay >= 1) return ay + " Aylık";

            return (bugun - d).Days + " Günlük";
        }

        // ------------------------------------------------------------------
        //  Sekmeler (Hayvanlar / Ziyaretler / Mesaj Geçmişi)
        // ------------------------------------------------------------------

        private void lblTab_Click(object sender, EventArgs e)
        {
            SekmeSec(int.Parse((string)((Control)sender).Tag));
        }

        private void SekmeSec(int index)
        {
            aktifSekme = index;

            Label[] sekmeler = { lblTabHayvanlar, lblTabZiyaretler, lblTabMesaj };
            Control[] icerik = { flpHayvanlar, dgvZiyaretler, lblMesajYok };

            for (int i = 0; i < sekmeler.Length; i++)
            {
                bool secili = i == index;
                sekmeler[i].ForeColor = secili ? Yesil : Koyu;
                sekmeler[i].Font = secili ? FontSekmeSecili : FontSekme;
                icerik[i].Visible = secili;
            }

            pnlSekmeCizgi.Left = sekmeler[index].Left;
            pnlSekmeCizgi.Width = sekmeler[index].Width;

            // Ziyaretler sekmesi ilk kez açılıyorsa (veya sahip değiştiyse) şimdi yükle
            if (index == 1 && seciliMusteriId != null && ziyaretlerYuklenenId != seciliMusteriId)
                ZiyaretleriYukle(seciliMusteriId.Value);
        }

        private void ZiyaretGridiniBicimle()
        {
            DataGridView g = dgvZiyaretler;
            CiftTamponla(g);

            g.BorderStyle = BorderStyle.None;
            g.BackgroundColor = Color.White;
            g.GridColor = Color.FromArgb(229, 231, 235);
            g.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            g.RowHeadersVisible = false;
            g.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            g.MultiSelect = false;

            g.EnableHeadersVisualStyles = false;
            g.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            g.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            g.ColumnHeadersHeight = 34;

            g.DefaultCellStyle.BackColor = Color.White;
            g.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(249, 250, 251);
            g.DefaultCellStyle.ForeColor = Color.FromArgb(31, 41, 55);
            g.DefaultCellStyle.SelectionBackColor = Color.FromArgb(209, 250, 229);
            g.DefaultCellStyle.SelectionForeColor = Color.FromArgb(6, 95, 70);
            g.DefaultCellStyle.Font = FontZiyaret;

            g.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(243, 244, 246);
            g.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(75, 85, 99);
            g.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(243, 244, 246);
            g.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.FromArgb(75, 85, 99);
            g.ColumnHeadersDefaultCellStyle.Font = FontZiyaretBaslik;

            g.ReadOnly = true;
            g.AllowUserToAddRows = false;
            g.AllowUserToDeleteRows = false;
            g.AllowUserToResizeColumns = false;
            g.AllowUserToResizeRows = false;
            g.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            g.RowTemplate.Height = 28;
            g.ScrollBars = ScrollBars.Vertical;
        }

        // ------------------------------------------------------------------
        //  Butonlar
        // ------------------------------------------------------------------

        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            if (seciliMusteriId == null) return;
            Tetikle(MusteriDuzenleIstendi, seciliMusteriId.Value, "Sahip düzenleme");
        }

        private void btnSmsGonder_Click(object sender, EventArgs e)
        {
            if (seciliMusteriId == null) return;
            if (!seciliSmsIzni) return;
            Tetikle(SmsGonderIstendi, seciliMusteriId.Value, "SMS gönderme");
        }

        private void btnHayvanEkle_Click(object sender, EventArgs e)
        {
            if (seciliMusteriId == null) return;

            int id = seciliMusteriId.Value;
            using (HayvanEkle ekleForm = new HayvanEkle(id))
            {
                if (ekleForm.ShowDialog() == DialogResult.OK)
                {
                    // Hayvan sayısı listede de değişeceği için liste yenilenir, seçim korunur.
                    SahipleriListele(id);
                }
            }
        }

        private void btnKartiAc_Click(object sender, EventArgs e)
        {
            int hastaId = (int)((Control)sender).Tag;
            Tetikle(HayvanKartiAcIstendi, hastaId, "Hayvan kartı");
        }

        private void btnPasifeAl_Click(object sender, EventArgs e)
        {
            if (seciliMusteriId == null) return;

            int id = seciliMusteriId.Value;
            bool pasifeAl = seciliAktif;
            string ad = lblAdSoyad.Text;

            string soru = pasifeAl
                ? ad + " pasife alınsın mı?\nKayıt silinmez, listede gri görünür."
                : ad + " tekrar aktif edilsin mi?";

            if (MessageBox.Show(soru, "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                using (SQLiteConnection baglanti = new SQLiteConnection(BaglantiYolu))
                {
                    baglanti.Open();
                    using (SQLiteCommand komut = new SQLiteCommand("UPDATE musteri SET aktif = @aktif WHERE id = @id", baglanti))
                    {
                        komut.Parameters.AddWithValue("@aktif", pasifeAl ? 0 : 1);
                        komut.Parameters.AddWithValue("@id", id);
                        komut.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show("Durum güncellenirken bir hata oluştu:\n" + hata.Message,
                                "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SahipleriListele(id);
        }

        private void Tetikle(Action<int> olay, int id, string ekranAdi)
        {
            if (olay != null)
                olay(id);
            else
                MessageBox.Show(ekranAdi + " ekranı henüz bağlanmadı.", "Bilgi",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void YeniSahipBtn_Click(object sender, EventArgs e)
        {
            using (YeniSahip yeniSahipForm = new YeniSahip())
            {
                if (yeniSahipForm.ShowDialog() == DialogResult.OK)
                    SahipleriListele();
            }
        }

        // ------------------------------------------------------------------
        //  Yardımcılar
        // ------------------------------------------------------------------

        private static string Metin(object o)
        {
            if (o == null || o == DBNull.Value) return "";
            return Convert.ToString(o, CultureInfo.InvariantCulture).Trim();
        }

        private static string Bos(string metin)
        {
            return string.IsNullOrWhiteSpace(metin) ? "—" : metin;
        }

        private static string TarihMetni(string iso)
        {
            if (string.IsNullOrEmpty(iso)) return "—";
            DateTime d;
            if (DateTime.TryParse(iso, CultureInfo.InvariantCulture, DateTimeStyles.None, out d))
                return d.ToString("dd.MM.yyyy", CultureInfo.InvariantCulture);
            return iso;
        }

        // 4-3-2-2 Formatında Telefon Biçimlendirme (sonuçlar önbelleğe alınır)
        private static string TelefonMetni(string tel)
        {
            if (string.IsNullOrWhiteSpace(tel) || tel == "-")
                return "—";

            string sonuc;
            if (TelefonOnbellek.TryGetValue(tel, out sonuc))
                return sonuc;

            string rakamlar = new string(tel.Where(char.IsDigit).ToArray());

            if (rakamlar.Length == 10)
                rakamlar = "0" + rakamlar;

            if (rakamlar.Length == 11)
                sonuc = rakamlar.Substring(0, 4) + " " + rakamlar.Substring(4, 3) + " "
                        + rakamlar.Substring(7, 2) + " " + rakamlar.Substring(9, 2);
            else
                sonuc = tel;

            TelefonOnbellek[tel] = sonuc;
            return sonuc;
        }

        private static string Gruplu(string metin, int grup)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < metin.Length; i++)
            {
                if (i > 0 && i % grup == 0) sb.Append(' ');
                sb.Append(metin[i]);
            }
            return sb.ToString();
        }

        private static string BasHarfler(string ad, string soyad)
        {
            var sb = new StringBuilder();
            foreach (string parca in (ad + " " + soyad).Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries))
                sb.Append(char.ToUpper(parca[0], Tr));
            string sonuc = sb.ToString();
            return sonuc.Length > 3 ? sonuc.Substring(0, 3) : sonuc;
        }
    }
}