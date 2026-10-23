using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace e_pet_desk_deneme1   // Kendi projenizin namespace'i ile değiştirin
{
    /// <summary>
    /// Randevular ekranı: üstte Önceki / Sonraki / Bugün ve tarih, altında RandevuTakvimi.
    /// Açmak için: new TakvimFormu().Show();
    /// </summary>
    public class TakvimFormu : Form
    {
        private static readonly CultureInfo Tr = new CultureInfo("tr-TR");
        private readonly RandevuTakvimi takvim = new RandevuTakvimi();
        private readonly Label tarihYazisi = new Label();

        public TakvimFormu()
        {
            Text = "Randevular";
            Size = new Size(1180, 760);
            MinimumSize = new Size(700, 450);
            StartPosition = FormStartPosition.CenterScreen;
            BackColor = Color.FromArgb(247, 248, 248);
            Font = new Font("Segoe UI", 9.75f);

            // Üst çubuk: düğmeler solda, tarih ortada
            var ust = new Panel { Dock = DockStyle.Top, Height = 60, Padding = new Padding(20, 14, 20, 8) };
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

            // Takvim, kenarlarda boşluk bırakan bir panelin içinde
            var alan = new Panel { Dock = DockStyle.Fill, Padding = new Padding(20, 4, 20, 20) };
            takvim.Dock = DockStyle.Fill;
            alan.Controls.Add(takvim);
            Controls.Add(alan);
            Controls.Add(ust);

            onceki.Click += delegate { takvim.OncekiGun(); };
            sonraki.Click += delegate { takvim.SonrakiGun(); };
            bugun.Click += delegate { takvim.Bugun(); };

            takvim.TarihDegisti += delegate { GunuYukle(); };
            takvim.BosSaatTiklandi += Takvim_BosSaatTiklandi;
            takvim.RandevuCiftTiklandi += Takvim_RandevuCiftTiklandi;

            Load += delegate
            {
                VeritabaniniHazirla();
                HekimleriYukle();
                GunuYukle();
                takvim.SaateKaydir(DateTime.Now.Hour - 1);
            };
        }

        /// <summary>
        /// true iken veritabanında hiç hekim/randevu yoksa örnek kayıtlar eklenir (deneme için).
        /// Gerçek kayıtlarla çalışmaya başlayınca false yapın.
        /// </summary>
        public static bool OrnekKayitEklensin = true;

        // Tablolar yoksa kurulur; boşsa (ve OrnekKayitEklensin açıksa) örnek kayıtlar eklenir
        private void VeritabaniniHazirla()
        {
            try
            {
                RandevuVeri.TablolariHazirla();
                if (!OrnekKayitEklensin) return;
                string sonuc = RandevuVeri.OrnekKayitlariEkle();
                if (sonuc.Length > 0)
                    MessageBox.Show(this, "Veritabanında takvim için kayıt yoktu, deneme kayıtları eklendi.\n\n" + sonuc,
                                    "Örnek kayıtlar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) { Hata("Takvim tabloları hazırlanamadı", ex); }
        }

        /// <summary>Gösterilen günü değiştirir (ör. ana ekrandan belli bir güne gitmek için).</summary>
        public void GuneGit(DateTime gun) { takvim.Tarih = gun; }

        private void HekimleriYukle()
        {
            takvim.HekimleriTemizle();
            try
            {
                foreach (var h in RandevuVeri.HekimleriGetir()) takvim.HekimEkle(h);
            }
            catch (Exception ex) { Hata("Hekimler yüklenemedi", ex); }
        }

        private void GunuYukle()
        {
            tarihYazisi.Text = takvim.Tarih.ToString("d MMMM yyyy, dddd", Tr);   // "26 Ekim 2026, Pazartesi"
            takvim.RandevulariTemizle();
            try
            {
                takvim.RandevuEkle(RandevuVeri.GunuGetir(takvim.Tarih));
            }
            catch (Exception ex) { Hata("Randevular yüklenemedi", ex); }
        }

        private void Takvim_BosSaatTiklandi(object sender, BosSaatEventArgs e)
        {
            // Burada hasta seçtiren kendi randevu formunuzu açın. Örnek:
            //   using (var f = new RandevuEkleFormu(e.Hekim.Id, e.Baslangic, e.Bitis))
            //       if (f.ShowDialog(this) == DialogResult.OK) GunuYukle();
            // Formun Kaydet düğmesinde: RandevuVeri.RandevuEkle(hastaId, hekimId, baslangic, bitis, islem);
            MessageBox.Show(this, e.Hekim.Ad + "\n" + e.Baslangic.ToString("d MMMM yyyy, HH:mm", Tr) + " - " + e.Bitis.ToString("HH:mm") +
                            "\n\nBuraya yeni randevu formu açılacak.", "Yeni randevu", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Takvim_RandevuCiftTiklandi(object sender, RandevuEventArgs e)
        {
            var r = e.Randevu;
            MessageBox.Show(this, r.Baslik + "\n" + r.Aciklama + "\n" + r.Baslangic.ToString("HH:mm") + " - " + r.Bitis.ToString("HH:mm") +
                            "\nDurum: " + r.Etiket, "Randevu", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Hata(string baslik, Exception ex)
        {
            MessageBox.Show(this, ex.Message, baslik, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
