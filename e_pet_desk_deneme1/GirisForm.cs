using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace e_pet_desk_deneme1
{
    public partial class GirisForm : Form
    {
        public GirisForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 1. Veritabanı bağlantı cümlesini tanımlıyoruz
            string baglantiCumlesi = "Data Source=veritabani.db;Version=3;";

            // 2. SQL Sorgumuz: Kullanıcı adı ve şifre eşleşen kaç kayıt var?
            string sorgu = "SELECT COUNT(*) FROM kullanici WHERE kullanici_adi = @kullanici AND sifre = @sifre";

            // 3. Bağlantıyı oluşturup açıyoruz
            using (SQLiteConnection baglanti = new SQLiteConnection(baglantiCumlesi))
            {
                baglanti.Open();

                // SQL komutunu ve bağlantıyı bağlıyoruz
                using (SQLiteCommand komut = new SQLiteCommand(sorgu, baglanti))
                {
                    // Parametreler ile SQL Injection güvenlik açıklarını engelliyoruz
                    komut.Parameters.AddWithValue("@kullanici", kAdiTxt.Text.Trim());
                    komut.Parameters.AddWithValue("@sifre", sifreTxt.Text.Trim());

                    // Sorguyu çalıştırıp dönen eşleşme sayısını alıyoruz
                    int esleseSayisi = Convert.ToInt32(komut.ExecuteScalar());

                    if (esleseSayisi > 0)
                    {
                        // Ana formu açıp giriş formunu kapatma/gizleme
                        AnaForm anaF = new AnaForm();
                        anaF.Show();
                        this.Hide();

                        MessageBox.Show("Giriş başarılı!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Kullanıcı adı veya şifre hatalı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            sifreTxt.PasswordChar = (sifreTxt.PasswordChar == '*') ? '\0' : '*';
        }

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox2.BorderStyle = BorderStyle.Fixed3D;
        }

        private void pictureBox2_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox2.BorderStyle = BorderStyle.None;
        }
    }
}
