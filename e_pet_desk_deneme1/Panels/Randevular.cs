using System;
using System.Windows.Forms;

namespace e_pet_desk_deneme1
{
    public partial class Randevular : UserControl
    {
        public Randevular()
        {
            InitializeComponent();

            // UserControl yüklendiğinde ve tarih değiştiğinde çalışacak olayları bağlıyoruz
            this.Load += Randevular_Load;
            randevuTakvimi1.TarihDegisti += RandevuTakvimi1_TarihDegisti;
        }

        private void Randevular_Load(object sender, EventArgs e)
        {
            // 1. Tablolar yoksa oluştur ve örnek kayıt ekle (ilk açılış için)
            RandevuVeri.TablolariHazirla();
            RandevuVeri.OrnekKayitlariEkle();

            // 2. Veritabanından hekimleri ve o günün randevularını çekip takvime ekle
            HekimleriYukle();
            GunuYukle();

            // 3. Takvimi şu anki saatin olduğu bölüme kaydır
            randevuTakvimi1.SaateKaydir(DateTime.Now.Hour - 1);
        }

        private void RandevuTakvimi1_TarihDegisti(object sender, EventArgs e)
        {
            // Kullanıcı takvimde gün değiştirdiğinde yeni günün randevularını yükler
            GunuYukle();
        }

        private void HekimleriYukle()
        {
            randevuTakvimi1.HekimleriTemizle();
            try
            {
                // Veritabanındaki aktif hekimleri çek ve takvimin sütunlarına ekle
                foreach (var hekim in RandevuVeri.HekimleriGetir())
                {
                    randevuTakvimi1.HekimEkle(hekim);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hekimler yüklenemedi: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GunuYukle()
        {
            randevuTakvimi1.RandevulariTemizle();
            try
            {
                // Takvimdeki o anki tarihe ait randevuları veritabanından çekip takvime ekle
                randevuTakvimi1.RandevuEkle(RandevuVeri.GunuGetir(randevuTakvimi1.Tarih));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Randevular yüklenemedi: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}