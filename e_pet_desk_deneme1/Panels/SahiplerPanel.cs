using System;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace e_pet_desk_deneme1
{
    public partial class SahiplerPanel : UserControl
    {
        private const string BaglantiYolu = @"Data Source=vettakip.db;Version=3;";

        private static readonly CultureInfo Tr = new CultureInfo("tr-TR");
        private static readonly Color Yesil = Color.FromArgb(22, 163, 74);
        private static readonly Color AvatarYesil = Color.FromArgb(46, 204, 113);
        private static readonly Color AvatarGri = Color.FromArgb(156, 163, 175);
        private static readonly Color Koyu = Color.FromArgb(17, 24, 39);
        private static readonly Color Kirmizi = Color.FromArgb(220, 38, 38);

        private DataTable sahiplerTablosu;

        private int? seciliMusteriId;
        private bool seciliAktif = true;
        private bool seciliSmsIzni;
        private bool listeGuncelleniyor;
        private int aktifSekme;

        // Ana form bu olaylara abone olarak ilgili ekranları açabilir (parametre: müşteri id veya hasta id).
        public event Action<int> MusteriDuzenleIstendi;
        public event Action<int> SmsGonderIstendi;
        public event Action<int> HayvanEkleIstendi;   // müşteri id
        public event Action<int> HayvanKartiAcIstendi; // hasta id

        public SahiplerPanel()
        {
            InitializeComponent();

            ZiyaretGridiniBicimle();
            SekmeSec(0);
            DetayGoster(false);

            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
                SahipleriListele();

            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.GridColor = Color.FromArgb(229, 231, 235);
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;

            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView1.ColumnHeadersHeight = 38;

            dataGridView1.DefaultCellStyle.BackColor = Color.White;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(249, 250, 251);
            dataGridView1.DefaultCellStyle.ForeColor = Color.FromArgb(31, 41, 55);
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(209, 250, 229);
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.FromArgb(6, 95, 70);
            dataGridView1.DefaultCellStyle.Font = new Font("Inter", 13F);

            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(243, 244, 246);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(75, 85, 99);
            dataGridView1.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(243, 244, 246);
            dataGridView1.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.FromArgb(75, 85, 99);
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Inter", 15F, FontStyle.Bold);

            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.ScrollBars = ScrollBars.Both;

            // Pasif müşteriler listede gri görünsün ve numara biçimlendirilsin
            dataGridView1.CellFormatting += dataGridView1_CellFormatting;

            // Sütun ayarları her veri bağlamasından sonra yeniden uygulanır
            dataGridView1.DataBindingComplete += dataGridView1_DataBindingComplete;

            // Arama kutusu olayı (Designer'da ayrıca bağlama, olay iki kez çalışır)
            txtAra.TextChanged += txtAra_TextChanged;
        }

        // ------------------------------------------------------------------
        //  SOL TARAF: sahip listesi
        // ------------------------------------------------------------------

        private void SahipleriListele(int? seciliKalacakId = null)
        {
            string sorgu = @"
                SELECT
                    m.id AS [Id],
                    m.aktif AS [Aktif],
                    m.ad || ' ' || m.soyad AS [Ad Soyad],
                    m.tel AS [Telefon],
                    IFNULL(m.il, '') || ' / ' || IFNULL(m.ilce, '') AS [İl/İlçe],
                    COUNT(h.id) AS [Evcil Hayvan Sayısı],
                    CASE m.sms_izni WHEN 1 THEN 'Var' ELSE 'Yok' END AS [SMS İzni]
                FROM
                    musteri m
                LEFT JOIN
                    hasta h ON m.id = h.musteri_id
                GROUP BY
                    m.id, m.aktif, m.ad, m.soyad, m.tel, m.eposta, m.ilce, m.il, m.sms_izni;
            ";

            using (SQLiteConnection baglanti = new SQLiteConnection(BaglantiYolu))
            {
                using (SQLiteDataAdapter adaptor = new SQLiteDataAdapter(sorgu, baglanti))
                {
                    try
                    {
                        var tablo = new DataTable();
                        tablo.Locale = Tr;
                        adaptor.Fill(tablo);

                        listeGuncelleniyor = true;
                        try
                        {
                            sahiplerTablosu = tablo;
                            dataGridView1.DataSource = sahiplerTablosu;
                            FiltreUygula();
                            SatirSec(seciliKalacakId);
                        }
                        finally
                        {
                            listeGuncelleniyor = false;
                        }

                        SeciliSahibiGoster(true);
                    }
                    catch (Exception hata)
                    {
                        MessageBox.Show("Veriler listelenirken bir hata oluştu:\n" + hata.Message,
                                        "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
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
            SeciliSahibiGoster(false);
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (dataGridView1.Columns["Id"] == null) return;

            dataGridView1.Columns["Id"].Visible = false;
            dataGridView1.Columns["Aktif"].Visible = false;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Sıralama okunu kaldır
            foreach (DataGridViewColumn kolon in dataGridView1.Columns)
                kolon.SortMode = DataGridViewColumnSortMode.NotSortable;

            // Başlık tek satırda kalsın
            dataGridView1.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            dataGridView1.Columns["Evcil Hayvan Sayısı"].HeaderText = "Hayvan Sayısı";
            dataGridView1.Columns["SMS İzni"].HeaderText = "Sms İzni";

            // Sütun genişlik oranları
            /*
            dataGridView1.Columns["Ad Soyad"].FillWeight = 135;
            dataGridView1.Columns["Telefon"].FillWeight = 150;
            dataGridView1.Columns["İl/İlçe"].FillWeight = 160;
            dataGridView1.Columns["Evcil Hayvan Sayısı"].FillWeight = 130;
            dataGridView1.Columns["SMS İzni"].FillWeight = 80;
            */

            // Başlık ve hücrelerin sol boşluğu aynı olsun
            dataGridView1.ColumnHeadersDefaultCellStyle.Padding = new Padding(8, 0, 10, 0);
            dataGridView1.DefaultCellStyle.Padding = new Padding(8, 0, 10, 0);
            dataGridView1.Columns["Ad Soyad"].DefaultCellStyle.Padding = new Padding(10, 0, 0, 0);
            dataGridView1.Columns["Ad Soyad"].HeaderCell.Style.Padding = new Padding(25, 0, 0, 0);
            dataGridView1.Columns["Telefon"].HeaderCell.Style.Padding = new Padding(35, 0, 0, 0);
            dataGridView1.Columns["İl/İlçe"].HeaderCell.Style.Padding = new Padding(65, 0, 0, 0);
            dataGridView1.Columns["İl/İlçe"].DefaultCellStyle.Padding = new Padding(25, 0, 0, 0);

            //dataGridView1.Columns["Evcil Hayvan Sayısı"].HeaderCell.Style.Padding = new Padding(25, 0, 0, 0);
            dataGridView1.Columns["Sms İzni"].DefaultCellStyle.Padding = new Padding(45, 0, 15, 0);
            dataGridView1.Columns["Sms İzni"].HeaderCell.Style.Padding = new Padding(25, 0, 15, 0);
            dataGridView1.Columns["Evcil Hayvan Sayısı"].DefaultCellStyle.Padding = new Padding(65, 0, 0, 0);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataRowView drv = dataGridView1.Rows[e.RowIndex].DataBoundItem as DataRowView;

            // Pasif satırlar gri yapılsın
            if (drv != null && Convert.ToInt32(drv["Aktif"]) == 0)
            {
                e.CellStyle.ForeColor = Color.FromArgb(156, 163, 175);
            }

            // Telefon hücresi formatlansın
            if (this.dataGridView1.Columns[e.ColumnIndex].Name == "Telefon" && e.Value != null)
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
                seciliMusteriId = null;
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

        private void SahipDetayiniYukle(int id)
        {
            try
            {
                using (SQLiteConnection baglanti = new SQLiteConnection(BaglantiYolu))
                {
                    baglanti.Open();

                    using (SQLiteCommand komut = new SQLiteCommand("SELECT * FROM musteri WHERE id = @id", baglanti))
                    {
                        komut.Parameters.AddWithValue("@id", id);
                        using (SQLiteDataReader oku = komut.ExecuteReader())
                        {
                            if (!oku.Read())
                            {
                                seciliMusteriId = null;
                                DetayGoster(false);
                                return;
                            }
                            SahipBilgileriniDoldur(id, oku);
                        }
                    }

                    string hayvanSorgu = @"
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

                    var hayvanlar = new DataTable();
                    using (var adaptor = new SQLiteDataAdapter(hayvanSorgu, baglanti))
                    {
                        adaptor.SelectCommand.Parameters.AddWithValue("@id", id);
                        adaptor.Fill(hayvanlar);
                    }
                    HayvanKartlariniOlustur(hayvanlar);
                    lblTabHayvanlar.Text = "Hayvanlar (" + hayvanlar.Rows.Count + ")";

                    string ziyaretSorgu = @"
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
                    var ziyaretler = new DataTable();
                    using (var adaptor = new SQLiteDataAdapter(ziyaretSorgu, baglanti))
                    {
                        adaptor.SelectCommand.Parameters.AddWithValue("@id", id);
                        adaptor.Fill(ziyaretler);
                    }
                    dgvZiyaretler.DataSource = ziyaretler;
                    dgvZiyaretler.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgvZiyaretler.ClearSelection();
                }

                seciliMusteriId = id;
                SekmeSec(aktifSekme);
                DetayGoster(true);
            }
            catch (Exception hata)
            {
                MessageBox.Show("Sahip bilgileri yüklenirken bir hata oluştu:\n" + hata.Message,
                                "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SahipBilgileriniDoldur(int id, SQLiteDataReader m)
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
            if (acilKisi.Length > 0 && acilTel.Length > 0 && acilTel != "-")
                lblAcilKisiDeger.Text = acilKisi + " * " + acilTel;
            else
                lblAcilKisiDeger.Text = Bos(acilKisi + acilTel);

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
            kart.BackColor = Color.FromArgb(229, 231, 235);
            kart.BorderColor = Color.Silver;
            kart.BorderRadius = 10;
            kart.BorderSize = 0;
            kart.Margin = new Padding(0, 0, 0, 10);
            kart.Size = new Size(genislik, 96);

            var simge = new Label();
            simge.BackColor = Color.White;
            simge.ForeColor = Yesil;
            simge.Font = new Font("Inter", 18F, FontStyle.Bold);
            simge.TextAlign = ContentAlignment.MiddleCenter;
            simge.Text = ad.Length > 0 ? ad.Substring(0, 1).ToUpper(Tr) : "?";
            simge.Bounds = new Rectangle(12, 16, 64, 64);
            kart.Controls.Add(simge);

            int metinGenislik = genislik - 88 - 100;

            var lblAd = new Label();
            lblAd.AutoEllipsis = true;
            lblAd.BackColor = Color.Transparent;
            lblAd.ForeColor = Koyu;
            lblAd.Font = new Font("Inter", 12F, FontStyle.Bold);
            lblAd.Text = ad + (durum.Length > 0 && durum != "Aktif" ? "  (" + durum + ")" : "");
            lblAd.Bounds = new Rectangle(88, 12, metinGenislik, 26);
            kart.Controls.Add(lblAd);

            var lblDetay = new Label();
            lblDetay.AutoEllipsis = true;
            lblDetay.BackColor = Color.Transparent;
            lblDetay.ForeColor = Koyu;
            lblDetay.Font = new Font("Inter", 10F);
            lblDetay.Text = HayvanOzeti(h);
            lblDetay.Bounds = new Rectangle(88, 40, genislik - 88 - 12, 22);
            kart.Controls.Add(lblDetay);

            string cip = Metin(h["mikrocip_no"]);
            string son = Metin(h["son_ziyaret"]);
            var lblAlt = new Label();
            lblAlt.AutoEllipsis = true;
            lblAlt.BackColor = Color.Transparent;
            lblAlt.ForeColor = Koyu;
            lblAlt.Font = new Font("Inter", 10F);
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
            btnKart.Font = new Font("Inter", 9F);
            btnKart.Text = "Kartı aç";
            btnKart.Tag = hastaId;
            btnKart.UseVisualStyleBackColor = false;
            btnKart.Bounds = new Rectangle(genislik - 92, 10, 80, 28);
            btnKart.Click += btnKartiAc_Click;
            kart.Controls.Add(btnKart);

            btnKart.BringToFront();
            return kart;
        }

        private static string HayvanOzeti(DataRow h)
        {
            var parcalar = new System.Collections.Generic.List<string>();
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
                sekmeler[i].Font = new Font("Inter", 11F, secili ? FontStyle.Bold : FontStyle.Regular);
                icerik[i].Visible = secili;
            }

            pnlSekmeCizgi.Left = sekmeler[index].Left;
            pnlSekmeCizgi.Width = sekmeler[index].Width;
        }

        private void ZiyaretGridiniBicimle()
        {
            dgvZiyaretler.BorderStyle = BorderStyle.None;
            dgvZiyaretler.BackgroundColor = Color.White;
            dgvZiyaretler.GridColor = Color.FromArgb(229, 231, 235);
            dgvZiyaretler.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvZiyaretler.RowHeadersVisible = false;
            dgvZiyaretler.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvZiyaretler.MultiSelect = false;

            dgvZiyaretler.EnableHeadersVisualStyles = false;
            dgvZiyaretler.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvZiyaretler.ColumnHeadersHeight = 34;

            dgvZiyaretler.DefaultCellStyle.BackColor = Color.White;
            dgvZiyaretler.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(249, 250, 251);
            dgvZiyaretler.DefaultCellStyle.ForeColor = Color.FromArgb(31, 41, 55);
            dgvZiyaretler.DefaultCellStyle.SelectionBackColor = Color.FromArgb(209, 250, 229);
            dgvZiyaretler.DefaultCellStyle.SelectionForeColor = Color.FromArgb(6, 95, 70);
            dgvZiyaretler.DefaultCellStyle.Font = new Font("Inter", 9.5F);

            dgvZiyaretler.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(243, 244, 246);
            dgvZiyaretler.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(75, 85, 99);
            dgvZiyaretler.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(243, 244, 246);
            dgvZiyaretler.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.FromArgb(75, 85, 99);
            dgvZiyaretler.ColumnHeadersDefaultCellStyle.Font = new Font("Inter", 9.5F, FontStyle.Bold);

            dgvZiyaretler.ReadOnly = true;
            dgvZiyaretler.AllowUserToAddRows = false;
            dgvZiyaretler.AllowUserToDeleteRows = false;
            dgvZiyaretler.AllowUserToResizeColumns = false;
            dgvZiyaretler.AllowUserToResizeRows = false;
            dgvZiyaretler.ScrollBars = ScrollBars.Vertical;
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

            HayvanEkle ekleForm = new HayvanEkle(seciliMusteriId.Value);
            if (ekleForm.ShowDialog() == DialogResult.OK)
            {
                SahipDetayiniYukle(seciliMusteriId.Value);
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

        // 4-3-2-2 Formatında Telefon Biçimlendirme
        private static string TelefonMetni(string tel)
        {
            if (string.IsNullOrWhiteSpace(tel) || tel == "-")
                return "—";

            string rakamlar = new string(tel.Where(char.IsDigit).ToArray());

            if (rakamlar.Length == 10)
                rakamlar = "0" + rakamlar;

            if (rakamlar.Length == 11)
            {
                return $"{rakamlar.Substring(0, 4)} {rakamlar.Substring(4, 3)} {rakamlar.Substring(7, 2)} {rakamlar.Substring(9, 2)}";
            }

            return tel;
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

        private void YeniSahipBtn_Click(object sender, EventArgs e)
        {
            YeniSahip yeniSahipForm = new YeniSahip();
            if (yeniSahipForm.ShowDialog() == DialogResult.OK)
            {
                SahipleriListele();
            }
        }
    }
}