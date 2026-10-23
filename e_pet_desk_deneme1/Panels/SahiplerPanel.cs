using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace e_pet_desk_deneme1
{
    public partial class SahiplerPanel : UserControl
    {
        public SahiplerPanel()
        {
            InitializeComponent();
            MusterileriListele();
        }

        private void MusterileriListele()
        {
            flowPanelSahipler.Controls.Clear();

            // Sütun adları vettakip.db'deki musteri tablosuna göre (tel, il, ilce, adres, aktif)
            string sorgu =
                "SELECT ad, soyad, tel, adres, il, ilce FROM musteri " +
                "WHERE aktif = 1 ORDER BY ad, soyad";

            try
            {
                using (SQLiteConnection baglanti = Veritabani.Ac())
                using (SQLiteCommand komut = new SQLiteCommand(sorgu, baglanti))
                using (SQLiteDataReader oku = komut.ExecuteReader())
                {
                    while (oku.Read())
                    {
                        MusteriKartiUserControl kart = new MusteriKartiUserControl();
                        kart.AdSoyad = oku["ad"] + " " + oku["soyad"];
                        kart.Telefon = TelefonBicimle(oku["tel"].ToString());
                        kart.Adres = AdresMetni(oku["adres"].ToString(), oku["il"].ToString(), oku["ilce"].ToString());
                        flowPanelSahipler.Controls.Add(kart);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Veritabani.HataMetni(ex), "Sahipler listelenemedi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // "05321234567" -> "0532 123 45 67"
        private static string TelefonBicimle(string tel)
        {
            if (tel.Length != 11) return tel;
            return tel.Substring(0, 4) + " " + tel.Substring(4, 3) + " " + tel.Substring(7, 2) + " " + tel.Substring(9, 2);
        }

        // Açık adres yoksa "İlçe / İl" gösterilir
        private static string AdresMetni(string adres, string il, string ilce)
        {
            string yer = (ilce + " / " + il).Trim(' ', '/');
            if (adres.Length == 0) return yer;
            return yer.Length == 0 ? adres : adres + ", " + yer;
        }
    }
}
