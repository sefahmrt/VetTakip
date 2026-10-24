using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace e_pet_desk_deneme1
{
    /// <summary>Takvimde sütunu olan hekim.</summary>
    public class TakvimHekim
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public Color Renk { get; set; }

        public TakvimHekim() { }
        public TakvimHekim(int id, string ad, Color renk) { Id = id; Ad = ad; Renk = renk; }
    }

    /// <summary>Takvimde kutu olarak çizilen randevu.</summary>
    public class TakvimRandevu
    {
        public int Id { get; set; }
        public int HekimId { get; set; }
        public DateTime Baslangic { get; set; }
        public DateTime Bitis { get; set; }
        public string Baslik { get; set; }      // ör. "Pamuk (Ayşe Yılmaz)"
        public string Aciklama { get; set; }    // ör. "Kuduz aşısı"
        public Color? Renk { get; set; }        // boş bırakılırsa hekimin rengi kullanılır
        public bool Soluk { get; set; }         // iptal edilen randevular soluk çizilir
        public object Etiket { get; set; }      // kendi verinizi saklamak için (ör. veritabanı kaydı)
    }

    public class BosSaatEventArgs : EventArgs
    {
        public TakvimHekim Hekim { get; private set; }
        public DateTime Baslangic { get; private set; }
        public DateTime Bitis { get; private set; }
        public BosSaatEventArgs(TakvimHekim hekim, DateTime baslangic, DateTime bitis) { Hekim = hekim; Baslangic = baslangic; Bitis = bitis; }
    }

    public class RandevuEventArgs : EventArgs
    {
        public TakvimRandevu Randevu { get; private set; }
        public RandevuEventArgs(TakvimRandevu randevu) { Randevu = randevu; }
    }

    /// <summary>
    /// Günlük randevu takvimi: her hekim bir sütun, her satır bir zaman aralığı (varsayılan 30 dk).
    /// Boş saate tıklanınca BosSaatTiklandi, randevuya tıklanınca RandevuTiklandi olayı çalışır.
    /// Aynı hekimin çakışan randevuları yan yana çizilir.
    /// </summary>
    public class RandevuTakvimi : Control
    {
        private const int SaatSutunu = 64;      // soldaki saat yazılarının genişliği
        private const int BaslikYuksekligi = 36;

        private readonly List<TakvimHekim> hekimler = new List<TakvimHekim>();
        private readonly List<TakvimRandevu> randevular = new List<TakvimRandevu>();
        private readonly List<Kutu> kutular = new List<Kutu>();   // randevuların sütun ve şerit yerleşimi
        private readonly VScrollBar kaydirma = new VScrollBar();
        private readonly ToolTip ipucu = new ToolTip();
        private readonly Timer dakikaSaati = new Timer();       // "şu an" çizgisini dakikada bir günceller

        private DateTime tarih = DateTime.Today;
        private int baslangicSaati = 9, bitisSaati = 18, dakikaAraligi = 30, satirYuksekligi = 44;
        private bool yerlesimEskidi = true;
        private TakvimRandevu secili, uzerindeki;
        private Rectangle fareHucresi = Rectangle.Empty;         // farenin üstünde durduğu boş hücre

        private class Kutu { public TakvimRandevu R; public int Sutun, Serit, SeritSayisi; }

        public RandevuTakvimi()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.Selectable, true);
            BackColor = Color.White;
            Font = new Font("Segoe UI", 9f);
            Size = new Size(800, 500);

            kaydirma.Dock = DockStyle.Right;
            kaydirma.Visible = false;
            kaydirma.ValueChanged += delegate { fareHucresi = Rectangle.Empty; Invalidate(); };
            Controls.Add(kaydirma);

            dakikaSaati.Interval = 60000;
            dakikaSaati.Tick += delegate { if (tarih == DateTime.Today) Invalidate(); };
            dakikaSaati.Start();
        }

        // ------------------------------------------------------------------ ayarlar

        [Category("Randevu Takvimi"), Description("Takvimin başladığı saat (0-23)."), DefaultValue(9)]
        public int BaslangicSaati
        {
            get { return baslangicSaati; }
            set { baslangicSaati = Math.Max(0, Math.Min(value, bitisSaati - 1)); YerlesimiYenile(); }
        }

        [Category("Randevu Takvimi"), Description("Takvimin bittiği saat (1-24)."), DefaultValue(18)]
        public int BitisSaati
        {
            get { return bitisSaati; }
            set { bitisSaati = Math.Min(24, Math.Max(value, baslangicSaati + 1)); YerlesimiYenile(); }
        }

        [Category("Randevu Takvimi"), Description("Bir satırın kaç dakika olduğu (5, 10, 15, 20, 30 ya da 60)."), DefaultValue(30)]
        public int DakikaAraligi
        {
            get { return dakikaAraligi; }
            set { dakikaAraligi = (value > 0 && 60 % value == 0) ? value : 30; YerlesimiYenile(); }
        }

        [Category("Randevu Takvimi"), Description("Bir satırın yüksekliği (piksel)."), DefaultValue(44)]
        public int SatirYuksekligi
        {
            get { return satirYuksekligi; }
            set { satirYuksekligi = Math.Max(16, value); YerlesimiYenile(); }
        }

        /// <summary>Gösterilen gün. Değişince TarihDegisti olayı çalışır; o günün randevularını orada yükleyin.</summary>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTime Tarih
        {
            get { return tarih; }
            set
            {
                if (value.Date == tarih) return;
                tarih = value.Date;
                secili = null;
                YerlesimiYenile();
                if (TarihDegisti != null) TarihDegisti(this, EventArgs.Empty);
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IList<TakvimHekim> Hekimler { get { return hekimler.AsReadOnly(); } }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IList<TakvimRandevu> Randevular { get { return randevular.AsReadOnly(); } }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TakvimRandevu SeciliRandevu { get { return secili; } }

        // ------------------------------------------------------------------ olaylar

        /// <summary>Boş bir saate tıklandı (yeni randevu formunu burada açın).</summary>
        public event EventHandler<BosSaatEventArgs> BosSaatTiklandi;
        /// <summary>Bir randevuya tıklandı (seçildi).</summary>
        public event EventHandler<RandevuEventArgs> RandevuTiklandi;
        /// <summary>Bir randevuya çift tıklandı (düzenleme formunu burada açın).</summary>
        public event EventHandler<RandevuEventArgs> RandevuCiftTiklandi;
        /// <summary>Gösterilen gün değişti.</summary>
        public event EventHandler TarihDegisti;

        // ------------------------------------------------------------------ veri

        public TakvimHekim HekimEkle(int id, string ad, Color renk)
        {
            var h = new TakvimHekim(id, ad, renk);
            HekimEkle(h);
            return h;
        }
        public void HekimEkle(TakvimHekim hekim) { hekimler.Add(hekim); YerlesimiYenile(); }
        public void HekimleriTemizle() { hekimler.Clear(); YerlesimiYenile(); }

        public void RandevuEkle(TakvimRandevu randevu) { randevular.Add(randevu); YerlesimiYenile(); }
        public void RandevuEkle(IEnumerable<TakvimRandevu> liste) { randevular.AddRange(liste); YerlesimiYenile(); }
        public void RandevuKaldir(TakvimRandevu randevu)
        {
            randevular.Remove(randevu);
            if (secili == randevu) secili = null;
            YerlesimiYenile();
        }
        public void RandevulariTemizle() { randevular.Clear(); secili = null; uzerindeki = null; YerlesimiYenile(); }

        /// <summary>Randevunun saatini, metnini ya da rengini değiştirdikten sonra çağırın.</summary>
        public void Yenile() { YerlesimiYenile(); }

        public void OncekiGun() { Tarih = tarih.AddDays(-1); }
        public void SonrakiGun() { Tarih = tarih.AddDays(1); }
        public void Bugun()
        {
            Tarih = DateTime.Today;
            SaateKaydir(DateTime.Now.Hour - 1);
        }

        /// <summary>Takvimi verilen saat en üstte görünecek şekilde kaydırır.</summary>
        public void SaateKaydir(int saat)
        {
            KaydirmayiAyarla();
            int y = (int)((Math.Max(saat, baslangicSaati) - baslangicSaati) * 60.0 / dakikaAraligi * satirYuksekligi);
            if (kaydirma.Visible) kaydirma.Value = Math.Max(0, Math.Min(y, kaydirma.Maximum - kaydirma.LargeChange + 1));
        }

        // ------------------------------------------------------------------ yerleşim

        private DateTime GunBasi { get { return tarih.AddHours(baslangicSaati); } }
        private DateTime GunSonu { get { return tarih.AddHours(bitisSaati); } }
        private int SatirSayisi { get { return (bitisSaati - baslangicSaati) * 60 / dakikaAraligi; } }
        private int IcerikYuksekligi { get { return SatirSayisi * satirYuksekligi; } }
        private int KaydirmaDegeri { get { return kaydirma.Visible ? kaydirma.Value : 0; } }
        private int IzgaraSol { get { return SaatSutunu; } }
        private int IzgaraGenisligi { get { return Math.Max(1, ClientSize.Width - SaatSutunu - (kaydirma.Visible ? kaydirma.Width : 0)); } }
        private float SutunGenisligi { get { return hekimler.Count == 0 ? 0 : (float)IzgaraGenisligi / hekimler.Count; } }

        private float ZamanY(DateTime t)
        {
            double dakika = (t - GunBasi).TotalMinutes;
            return (float)(BaslikYuksekligi + dakika / dakikaAraligi * satirYuksekligi - KaydirmaDegeri);
        }

        private void YerlesimiYenile()
        {
            yerlesimEskidi = true;
            KaydirmayiAyarla();
            Invalidate();
        }

        private void KaydirmayiAyarla()
        {
            int gorunen = Math.Max(1, ClientSize.Height - BaslikYuksekligi);
            bool gerekli = IcerikYuksekligi > gorunen;
            if (kaydirma.Visible != gerekli) kaydirma.Visible = gerekli;
            if (!gerekli) return;
            kaydirma.Minimum = 0;
            kaydirma.Maximum = IcerikYuksekligi - 1;
            kaydirma.LargeChange = gorunen;
            kaydirma.SmallChange = satirYuksekligi;
            if (kaydirma.Value > kaydirma.Maximum - kaydirma.LargeChange + 1)
                kaydirma.Value = Math.Max(0, kaydirma.Maximum - kaydirma.LargeChange + 1);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            KaydirmayiAyarla();
        }

        // Her hekim için o günün randevularını sırala; çakışanları ayrı şeritlere koy.
        private void KutulariHesapla()
        {
            kutular.Clear();
            for (int s = 0; s < hekimler.Count; s++)
            {
                int hekimId = hekimler[s].Id;
                var liste = randevular
                    .Where(r => r.HekimId == hekimId && r.Bitis > GunBasi && r.Baslangic < GunSonu && r.Bitis > r.Baslangic)
                    .OrderBy(r => r.Baslangic).ThenByDescending(r => r.Bitis).ToList();
                int i = 0;
                while (i < liste.Count)
                {
                    // Birbirine değen randevular bir "küme" oluşturur
                    var kume = new List<TakvimRandevu> { liste[i] };
                    DateTime kumeSonu = liste[i].Bitis;
                    int j = i + 1;
                    while (j < liste.Count && liste[j].Baslangic < kumeSonu)
                    {
                        kume.Add(liste[j]);
                        if (liste[j].Bitis > kumeSonu) kumeSonu = liste[j].Bitis;
                        j++;
                    }
                    var seritSonlari = new List<DateTime>();
                    var seritler = new List<int>();
                    foreach (var r in kume)
                    {
                        int serit = seritSonlari.FindIndex(son => son <= r.Baslangic);
                        if (serit < 0) { seritSonlari.Add(r.Bitis); serit = seritSonlari.Count - 1; }
                        else seritSonlari[serit] = r.Bitis;
                        seritler.Add(serit);
                    }
                    for (int k = 0; k < kume.Count; k++)
                        kutular.Add(new Kutu { R = kume[k], Sutun = s, Serit = seritler[k], SeritSayisi = seritSonlari.Count });
                    i = j;
                }
            }
            yerlesimEskidi = false;
        }

        private RectangleF KutuAlani(Kutu k)
        {
            float sw = SutunGenisligi;
            float genislik = (sw - 6) / k.SeritSayisi;
            float x = IzgaraSol + k.Sutun * sw + 3 + k.Serit * genislik;
            DateTime bas = k.R.Baslangic < GunBasi ? GunBasi : k.R.Baslangic;
            DateTime son = k.R.Bitis > GunSonu ? GunSonu : k.R.Bitis;
            float y1 = ZamanY(bas) + 1, y2 = ZamanY(son) - 1;
            return new RectangleF(x, y1, Math.Max(4, genislik - 2), Math.Max(6, y2 - y1));
        }

        private TakvimRandevu RandevuBul(Point p)
        {
            if (p.Y < BaslikYuksekligi) return null;
            if (yerlesimEskidi) KutulariHesapla();
            for (int i = kutular.Count - 1; i >= 0; i--)
                if (KutuAlani(kutular[i]).Contains(p)) return kutular[i].R;
            return null;
        }

        private bool HucreBul(Point p, out int sutun, out DateTime baslangic, out Rectangle alan)
        {
            sutun = -1; baslangic = DateTime.MinValue; alan = Rectangle.Empty;
            if (hekimler.Count == 0 || p.Y < BaslikYuksekligi || p.X < IzgaraSol || p.X >= IzgaraSol + IzgaraGenisligi) return false;
            int satir = (p.Y - BaslikYuksekligi + KaydirmaDegeri) / satirYuksekligi;
            if (satir < 0 || satir >= SatirSayisi) return false;
            float sw = SutunGenisligi;
            sutun = Math.Min(hekimler.Count - 1, (int)((p.X - IzgaraSol) / sw));
            baslangic = GunBasi.AddMinutes(satir * dakikaAraligi);
            int y = BaslikYuksekligi + satir * satirYuksekligi - KaydirmaDegeri;
            alan = new Rectangle((int)(IzgaraSol + sutun * sw) + 1, y + 1, (int)sw - 1, satirYuksekligi - 1);
            return true;
        }

        // ------------------------------------------------------------------ fare

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            var r = RandevuBul(e.Location);
            Rectangle hucre = Rectangle.Empty;
            if (r == null) { int s; DateTime b; HucreBul(e.Location, out s, out b, out hucre); }
            if (r != uzerindeki)
            {
                uzerindeki = r;
                ipucu.SetToolTip(this, r == null ? null : IpucuMetni(r));
            }
            Cursor = r != null || hucre != Rectangle.Empty ? Cursors.Hand : Cursors.Default;
            if (hucre != fareHucresi) { fareHucresi = hucre; Invalidate(); }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            uzerindeki = null;
            fareHucresi = Rectangle.Empty;
            Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            Focus();   // fare tekerleği çalışsın
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            if (e.Button != MouseButtons.Left) return;
            var r = RandevuBul(e.Location);
            if (r != null)
            {
                secili = r;
                Invalidate();
                if (RandevuTiklandi != null) RandevuTiklandi(this, new RandevuEventArgs(r));
                return;
            }
            int sutun; DateTime bas; Rectangle alan;
            if (HucreBul(e.Location, out sutun, out bas, out alan))
            {
                secili = null;
                Invalidate();
                if (BosSaatTiklandi != null) BosSaatTiklandi(this, new BosSaatEventArgs(hekimler[sutun], bas, bas.AddMinutes(dakikaAraligi)));
            }
        }

        protected override void OnMouseDoubleClick(MouseEventArgs e)
        {
            base.OnMouseDoubleClick(e);
            var r = RandevuBul(e.Location);
            if (r != null && RandevuCiftTiklandi != null) RandevuCiftTiklandi(this, new RandevuEventArgs(r));
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);
            if (!kaydirma.Visible) return;
            int yeni = kaydirma.Value - e.Delta / 120 * satirYuksekligi;
            kaydirma.Value = Math.Max(0, Math.Min(yeni, kaydirma.Maximum - kaydirma.LargeChange + 1));
        }

        private static string IpucuMetni(TakvimRandevu r)
        {
            string s = r.Baslangic.ToString("HH:mm") + " - " + r.Bitis.ToString("HH:mm");
            if (!string.IsNullOrEmpty(r.Baslik)) s += "\n" + r.Baslik;
            if (!string.IsNullOrEmpty(r.Aciklama)) s += "\n" + r.Aciklama;
            return s;
        }

        // ------------------------------------------------------------------ çizim

        private static readonly Color CizgiSaat = Color.FromArgb(209, 213, 219);
        private static readonly Color CizgiAra = Color.FromArgb(238, 240, 242);
        private static readonly Color YaziSoluk = Color.FromArgb(107, 114, 128);
        private static readonly Color VurguRengi = Color.FromArgb(15, 118, 110);

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(BackColor);
            if (yerlesimEskidi) KutulariHesapla();

            if (hekimler.Count == 0)
            {
                TextRenderer.DrawText(g, "Takvimde gösterilecek hekim yok.\nVeritabanındaki hekim tablosuna kayıt ekleyin.", Font, ClientRectangle, YaziSoluk,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
                return;
            }

            float sw = SutunGenisligi;
            int sag = IzgaraSol + IzgaraGenisligi;
            var izgara = new Rectangle(0, BaslikYuksekligi, sag, ClientSize.Height - BaslikYuksekligi);

            // 1) Satırlar, saat yazıları ve sütun çizgileri (başlığın altında kalan alan)
            g.SetClip(izgara);
            using (var saatKalemi = new Pen(CizgiSaat))
            using (var araKalemi = new Pen(CizgiAra))
            using (var kucukYazi = new Font(Font.FontFamily, Font.Size - 0.5f))
            {
                for (int i = 0; i <= SatirSayisi; i++)
                {
                    int y = BaslikYuksekligi + i * satirYuksekligi - KaydirmaDegeri;
                    if (y < BaslikYuksekligi - satirYuksekligi || y > ClientSize.Height) continue;
                    DateTime t = GunBasi.AddMinutes(i * dakikaAraligi);
                    bool tamSaat = t.Minute == 0;
                    g.DrawLine(tamSaat ? saatKalemi : araKalemi, tamSaat ? 0 : SaatSutunu - 8, y, sag, y);
                    if (i < SatirSayisi)
                        TextRenderer.DrawText(g, t.ToString("H:mm"), tamSaat ? Font : kucukYazi,
                            new Rectangle(0, y + 3, SaatSutunu - 10, satirYuksekligi), tamSaat ? ForeColor : YaziSoluk,
                            TextFormatFlags.Right | TextFormatFlags.Top | TextFormatFlags.NoPadding);
                }
                g.DrawLine(saatKalemi, SaatSutunu, BaslikYuksekligi, SaatSutunu, ClientSize.Height);
                for (int s = 1; s < hekimler.Count; s++)
                {
                    int x = (int)(IzgaraSol + s * sw);
                    g.DrawLine(saatKalemi, x, BaslikYuksekligi, x, ClientSize.Height);
                }
            }

            // Farenin üstündeki boş hücre
            if (fareHucresi != Rectangle.Empty)
                using (var b = new SolidBrush(Color.FromArgb(22, VurguRengi)))
                    g.FillRectangle(b, fareHucresi);

            // 2) Randevu kutuları
            g.SmoothingMode = SmoothingMode.AntiAlias;
            foreach (var k in kutular)
            {
                RectangleF alan = KutuAlani(k);
                if (alan.Bottom < BaslikYuksekligi || alan.Top > ClientSize.Height) continue;
                RandevuCiz(g, k.R, alan);
            }

            // 3) Şu anki saat (sadece bugün)
            DateTime simdi = DateTime.Now;
            if (tarih == DateTime.Today && simdi >= GunBasi && simdi <= GunSonu)
            {
                float y = ZamanY(simdi);
                using (var kalem = new Pen(Color.FromArgb(220, 38, 38), 2f))
                using (var firca = new SolidBrush(Color.FromArgb(220, 38, 38)))
                {
                    g.DrawLine(kalem, SaatSutunu, y, sag, y);
                    g.FillEllipse(firca, SaatSutunu - 5, y - 5, 10, 10);
                }
            }
            g.ResetClip();
            g.SmoothingMode = SmoothingMode.None;

            // 4) Hekim başlıkları (en üstte sabit durur)
            using (var kalinYazi = new Font(Font, FontStyle.Bold))
            {
                for (int s = 0; s < hekimler.Count; s++)
                {
                    var h = hekimler[s];
                    var r = new Rectangle((int)(IzgaraSol + s * sw), 0, (int)(IzgaraSol + (s + 1) * sw) - (int)(IzgaraSol + s * sw), BaslikYuksekligi);
                    if (s > 0) { r.X += 1; r.Width -= 1; }
                    using (var b = new SolidBrush(h.Renk.IsEmpty ? VurguRengi : h.Renk)) g.FillRectangle(b, r);
                    TextRenderer.DrawText(g, h.Ad ?? "", kalinYazi, Rectangle.Inflate(r, -6, 0), YaziRengi(h.Renk.IsEmpty ? VurguRengi : h.Renk),
                        TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis | TextFormatFlags.SingleLine);
                }
                using (var kalem = new Pen(CizgiSaat)) g.DrawLine(kalem, 0, BaslikYuksekligi - 1, sag, BaslikYuksekligi - 1);
            }
        }

        private void RandevuCiz(Graphics g, TakvimRandevu r, RectangleF alan)
        {
            TakvimHekim h = hekimler.FirstOrDefault(x => x.Id == r.HekimId);
            Color renk = r.Renk ?? (h != null && !h.Renk.IsEmpty ? h.Renk : VurguRengi);
            if (r.Soluk) renk = Color.FromArgb(renk.A, (renk.R + 2 * 255) / 3, (renk.G + 2 * 255) / 3, (renk.B + 2 * 255) / 3);
            else if (r == uzerindeki) renk = ControlPaint.Light(renk, 0.15f);
            Color yazi = YaziRengi(renk);

            using (var yol = Yuvarlak(alan, 4))
            {
                using (var b = new SolidBrush(renk)) g.FillPath(b, yol);
                if (r == secili)
                    using (var kalem = new Pen(Color.FromArgb(31, 41, 55), 2f)) g.DrawPath(kalem, yol);
            }

            // Metin: saat, başlık (kalın), açıklama; sığmayan satır gösterilmez
            Rectangle metin = Rectangle.Round(RectangleF.Inflate(alan, -5, -3));
            if (metin.Width < 12 || metin.Height < 8) return;
            const TextFormatFlags bicim = TextFormatFlags.Left | TextFormatFlags.Top | TextFormatFlags.EndEllipsis |
                                          TextFormatFlags.SingleLine | TextFormatFlags.NoPadding;
            int y = metin.Top;
            using (var kucuk = new Font(Font.FontFamily, Font.Size - 1f))
            using (var kalin = new Font(Font, r.Soluk ? FontStyle.Bold | FontStyle.Strikeout : FontStyle.Bold))
            {
                // Kısa randevu (ör. 15 dk): saat ve başlık tek satırda
                int kucukYukseklik = TextRenderer.MeasureText(g, "Ag", kucuk, Size.Empty, TextFormatFlags.NoPadding).Height;
                if (metin.Height < kucukYukseklik * 2 + 2)
                {
                    using (var kucukKalin = new Font(kucuk, r.Soluk ? FontStyle.Bold | FontStyle.Strikeout : FontStyle.Bold))
                        TextRenderer.DrawText(g, r.Baslangic.ToString("HH:mm") + "  " + (r.Baslik ?? ""), kucukKalin,
                            new Rectangle(metin.Left, metin.Top - 1, metin.Width, Math.Max(metin.Height + 2, kucukYukseklik)), yazi, bicim);
                    return;
                }
                var satirlar = new List<KeyValuePair<string, Font>>
                {
                    new KeyValuePair<string, Font>(r.Baslangic.ToString("HH:mm") + " - " + r.Bitis.ToString("HH:mm"), kucuk)
                };
                if (!string.IsNullOrEmpty(r.Baslik)) satirlar.Add(new KeyValuePair<string, Font>(r.Baslik, kalin));
                if (!string.IsNullOrEmpty(r.Aciklama)) satirlar.Add(new KeyValuePair<string, Font>(r.Aciklama, Font));
                foreach (var s in satirlar)
                {
                    int yukseklik = TextRenderer.MeasureText(g, "Ag", s.Value, Size.Empty, TextFormatFlags.NoPadding).Height;
                    if (y + yukseklik > metin.Bottom + 2) break;
                    TextRenderer.DrawText(g, s.Key, s.Value, new Rectangle(metin.Left, y, metin.Width, yukseklik), yazi, bicim);
                    y += yukseklik;
                }
            }
        }

        // Açık renk zeminde koyu, koyu zeminde beyaz yazı
        private static Color YaziRengi(Color zemin)
        {
            double parlaklik = 0.299 * zemin.R + 0.587 * zemin.G + 0.114 * zemin.B;
            return parlaklik > 165 ? Color.FromArgb(31, 41, 55) : Color.White;
        }

        private static GraphicsPath Yuvarlak(RectangleF r, float yaricap)
        {
            var yol = new GraphicsPath();
            float d = Math.Min(yaricap * 2, Math.Min(r.Width, r.Height));
            if (d < 1) { yol.AddRectangle(r); return yol; }
            yol.AddArc(r.X, r.Y, d, d, 180, 90);
            yol.AddArc(r.Right - d, r.Y, d, d, 270, 90);
            yol.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
            yol.AddArc(r.X, r.Bottom - d, d, d, 90, 90);
            yol.CloseFigure();
            return yol;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                dakikaSaati.Dispose();
                ipucu.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}