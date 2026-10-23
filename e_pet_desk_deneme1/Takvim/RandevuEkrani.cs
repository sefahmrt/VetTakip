using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace e_pet_desk_deneme1
{
    /// <summary>
    /// Randevular ekranı (gün görünümü, her hekim bir sütun). Ayrı pencere açmaz;
    /// Panels\Randevular bunu kendi içine koyar, AnaForm da Randevular'ı panelContainer'da gösterir.
    /// Bilgi ve hata mesajları ayrı pencerede değil, ekranın üstündeki şeritte görünür.
    /// </summary>
    public class RandevuEkrani : UserControl
    {
        private static readonly CultureInfo Tr = new CultureInfo("tr-TR");
        private static readonly Color BilgiZemin = Color.FromArgb(230, 242, 240), BilgiYazi = Color.FromArgb(19, 78, 74);
        private static readonly Color HataZemin = Color.FromArgb(253, 236, 236), HataYazi = Color.FromArgb(153, 27, 27);

        private readonly RandevuTakvimi takvim = new RandevuTakvimi();
        private readonly Label tarihYazisi = new Label();
        private readonly Label mesaj = new Label();
        private bool yuklendi;

        /// <summary>Boş saate tıklandı: kendi randevu ekleme ekranınızı burada açın. Bağlanmazsa şeritte bilgi çıkar.</summary>
        public event EventHandler<BosSaatEventArgs> BosSaatTiklandi;
        /// <summary>Randevuya çift tıklandı: düzenleme ekranınızı burada açın. Bağlanmazsa şeritte bilgi çıkar.</summary>
        public event EventHandler<RandevuEventArgs> RandevuCiftTiklandi;

        public RandevuEkrani()
        {
            BackColor = Color.FromArgb(242, 242, 242);
            Font = new Font("Segoe UI", 9.75f);
            Size = new Size(1626, 800);

            // Üst çubuk: Önceki / Sonraki / Bugün ve tarih
            var ust = new Panel { Dock = DockStyle.Top, Height = 56, Padding = new Padding(16, 12, 16, 6) };
            var dugmeler = new FlowLayoutPanel { Dock = DockStyle.Left, AutoSize = true, WrapContents = false };
            Button onceki = Dugme("‹", 40), sonraki = Dugme("›", 40), bugun = Dugme("Bugün", 80);
            bugun.Margin = new Padding(10, 0, 0, 0);
            dugmeler.Controls.AddRange(new Control[] { onceki, sonraki, bugun });
            tarihYazisi.Dock = DockStyle.Fill;
            tarihYazisi.TextAlign = ContentAlignment.MiddleCenter;
            tarihYazisi.Font = new Font("Segoe UI Semibold", 14f);
            tarihYazisi.ForeColor = Color.FromArgb(19, 78, 74);
            ust.Controls.Add(tarihYazisi);
            ust.Controls.Add(dugmeler);

            // Mesaj şeridi (gizli başlar; tıklayınca kapanır)
            mesaj.Dock = DockStyle.Top;
            mesaj.AutoSize = false;
            mesaj.Visible = false;
            mesaj.Padding = new Padding(16, 8, 16, 8);
            mesaj.TextAlign = ContentAlignment.MiddleLeft;
            mesaj.Cursor = Cursors.Hand;
            mesaj.Click += delegate { mesaj.Visible = false; };

            var alan = new Panel { Dock = DockStyle.Fill, Padding = new Padding(16, 6, 16, 16) };
            takvim.Dock = DockStyle.Fill;
            alan.Controls.Add(takvim);

            // Sıra önemli: en son eklenen en üste yerleşir
            Controls.Add(alan);
            Controls.Add(mesaj);
            Controls.Add(ust);

            onceki.Click += delegate { takvim.OncekiGun(); };
            sonraki.Click += delegate { takvim.SonrakiGun(); };
            bugun.Click += delegate { takvim.Bugun(); };
            takvim.TarihDegisti += delegate { GunuYukle(); };
            takvim.BosSaatTiklandi += Takvim_BosSaatTiklandi;
            takvim.RandevuCiftTiklandi += Takvim_RandevuCiftTiklandi;
            tarihYazisi.Text = takvim.Tarih.ToString("d MMMM yyyy, dddd", Tr);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            // Tasarım ekranında (Visual Studio designer) veritabanına bağlanma
            if (DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;
            Yukle();
        }

        /// <summary>Gösterilen günü değiştirir.</summary>
        public void GuneGit(DateTime gun) { takvim.Tarih = gun; }

        /// <summary>Hekimleri ve günü veritabanından yeniden okur (ör. randevu ekledikten sonra).</summary>
        public void Yenile() { HekimleriYukle(); GunuYukle(); }

        private void Yukle()
        {
            if (yuklendi) return;
            yuklendi = true;
            if (HekimleriYukle()) GunuYukle();

            // Mesai içindeyse şu anki saate kaydır, mesai dışındaysa günün başını göster
            int saat = DateTime.Now.Hour - 1;
            if (saat < takvim.BaslangicSaati || saat >= takvim.BitisSaati - 1) saat = takvim.BaslangicSaati;
            takvim.SaateKaydir(saat);
        }

        private bool HekimleriYukle()
        {
            takvim.HekimleriTemizle();
            try
            {
                foreach (TakvimHekim h in RandevuVeri.HekimleriGetir()) takvim.HekimEkle(h);
                return true;
            }
            catch (Exception ex) { MesajGoster(Veritabani.HataMetni(ex), true); return false; }
        }

        private void GunuYukle()
        {
            tarihYazisi.Text = takvim.Tarih.ToString("d MMMM yyyy, dddd", Tr);   // "26 Ekim 2026, Pazartesi"
            if (!yuklendi) return;
            takvim.RandevulariTemizle();
            try { takvim.RandevuEkle(RandevuVeri.GunuGetir(takvim.Tarih)); }
            catch (Exception ex) { MesajGoster(Veritabani.HataMetni(ex), true); }
        }

        private void Takvim_BosSaatTiklandi(object sender, BosSaatEventArgs e)
        {
            if (BosSaatTiklandi != null) { BosSaatTiklandi(this, e); return; }
            MesajGoster("Yeni randevu: " + e.Hekim.Ad + ", " + e.Baslangic.ToString("d MMMM, HH:mm", Tr) + " - " + e.Bitis.ToString("HH:mm") +
                        ". (Randevu ekleme ekranınızı BosSaatTiklandi olayına bağlayın.)", false);
        }

        private void Takvim_RandevuCiftTiklandi(object sender, RandevuEventArgs e)
        {
            if (RandevuCiftTiklandi != null) { RandevuCiftTiklandi(this, e); return; }
            var r = e.Randevu;
            MesajGoster(r.Baslangic.ToString("HH:mm") + " - " + r.Bitis.ToString("HH:mm") + " · " + r.Baslik +
                        (string.IsNullOrEmpty(r.Aciklama) ? "" : " · " + r.Aciklama) + " · Durum: " + r.Etiket, false);
        }

        /// <summary>Üstteki şeritte mesaj gösterir (hata ise kırmızı). Tıklanınca kapanır.</summary>
        public void MesajGoster(string metin, bool hata)
        {
            mesaj.Text = metin;
            mesaj.BackColor = hata ? HataZemin : BilgiZemin;
            mesaj.ForeColor = hata ? HataYazi : BilgiYazi;
            int genislik = Math.Max(200, ClientSize.Width - mesaj.Padding.Horizontal);
            Size olcu = TextRenderer.MeasureText(metin, mesaj.Font, new Size(genislik, 0), TextFormatFlags.WordBreak);
            mesaj.Height = olcu.Height + mesaj.Padding.Vertical + 4;
            mesaj.Visible = true;
        }

        private static Button Dugme(string yazi, int genislik)
        {
            var b = new Button
            {
                Text = yazi, Width = genislik, Height = 34, FlatStyle = FlatStyle.Flat, BackColor = Color.White,
                ForeColor = Color.FromArgb(31, 41, 55), Cursor = Cursors.Hand, Margin = new Padding(0, 0, 4, 0)
            };
            b.FlatAppearance.BorderColor = Color.FromArgb(209, 213, 219);
            b.FlatAppearance.MouseOverBackColor = Color.FromArgb(243, 244, 246);
            if (yazi.Length == 1) b.Font = new Font("Segoe UI", 13f);
            return b;
        }
    }
}
