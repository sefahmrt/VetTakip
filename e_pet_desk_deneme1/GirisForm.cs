using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace e_pet_desk_deneme1
{
    public partial class GirisForm : Form
    {
        public GirisForm()
        {
            InitializeComponent();
            Version surum = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            surumLbl.Text = "Alpha - v" + surum.ToString();
            galeri3.Visible = true;
            galeri2.Visible = false;
            galeri1.Visible = false;
            timer1.Start();
        }

        private void girisBtn_Click(object sender, EventArgs e)
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
            // Eğer şu an şifre gizliyse ('*' karakteri varsa)
            if (sifreTxt.PasswordChar == '*')
            {
                sifreTxt.PasswordChar = '\0'; // Şifreyi göster

                // Buraya açık göz ikonunu koymalısın (Örn: Properties.Resources.goz_acik)
                pictureBox2.Image = Properties.Resources.goz_acik;
            }
            else
            {
                sifreTxt.PasswordChar = '*'; // Şifreyi tekrar gizle

                // Buraya kapalı göz ikonunu koymalısın (Örn: Properties.Resources.goz_kapali)
                pictureBox2.Image = Properties.Resources.goz_kapali;
            }
        }

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox2.BorderStyle = BorderStyle.Fixed3D;
        }

        private void pictureBox2_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox2.BorderStyle = BorderStyle.None;
        }

        int sayac=0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            sayac++;
            label8.Text = sayac.ToString();
            if (sayac<=50)
            {
                galeri3.Visible = true;
                galeri2.Visible = false;
                galeri1.Visible = false;
            }
            else if (sayac <= 100)
            {
                galeri3.Visible = false;
                galeri2.Visible = true;
                galeri1.Visible = false;
            }
            else if (sayac <= 150)
            {
                galeri3.Visible = false;
                galeri2.Visible = false;
                galeri1.Visible = true;
                if (sayac==150) sayac = 0;
            }
        }
    }
}
