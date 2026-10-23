using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite; // SQLite kullanıyorsak

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
            // 1. Paneli temizle ki üst üste binme olmasın
            flowPanelSahipler.Controls.Clear();

            // SQLite bağlantı cümlesi (Veritabanı dosyan projenin ana klasöründe olmalı)
            string connectionString = "Data Source=demo.db;Version=3;";

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT ad, soyad, tel_no, adres FROM musteri";

                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            // 2. Veritabanındaki her bir müşteri kaydı için döngü dönüyor
                            while (reader.Read())
                            {
                                // Hafızada yeni bir müşteri kartı oluşturuyoruz
                                MusteriKartiUserControl kart = new MusteriKartiUserControl();

                                // Veritabanındaki verileri karta aktarıyoruz
                                kart.AdSoyad = reader["ad"].ToString() + " " + reader["soyad"].ToString();
                                kart.Telefon = reader["tel_no"].ToString();
                                kart.Adres = reader["adres"].ToString();

                                // 3. Oluşturduğumuz kartı ekrandaki FlowLayoutPanel içine ekliyoruz
                                flowPanelSahipler.Controls.Add(kart);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Bir hata oluştu: " + ex.Message);
                }
            }
        }

    }
}
