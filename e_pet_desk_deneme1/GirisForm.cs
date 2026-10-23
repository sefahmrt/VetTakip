using System;
using System.IO;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;

namespace e_pet_desk_deneme1
{
    public partial class GirisForm : Form
    {
        private int sayac = 0;

        public GirisForm()
        {
            InitializeComponent();

            Version surum = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            surumLbl.Text = "Alpha - v" + surum.ToString();

            // Enter tuşuna basıldığında doğrudan Giriş butonunu tetikle
            this.AcceptButton = girisBtn;

            // Debug için kullanılan sayaç etiketini gizle
            label8.Visible = false;

            // Galeri başlangıç durumu ve Timer ayarı
            galeri3.Visible = true;
            galeri2.Visible = false;
            galeri1.Visible = false;
            timer1.Interval = 100; // 100ms * 50 = her 5 saniyede bir görsel değişir
            timer1.Start();
        }

        private void girisBtn_Click(object sender, EventArgs e)
        {
            string kullaniciAdi = kAdiTxt.Text.Trim();
            string sifre = sifreTxt.Text.Trim();

            // 1. Boş alan kontrolü
            if (string.IsNullOrEmpty(kullaniciAdi) || string.IsNullOrEmpty(sifre))
            {
                MessageBox.Show("Lütfen kullanıcı adı ve şifre alanlarını doldurunuz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string dbYolu = Path.Combine(Application.StartupPath, "veritabani.db");
            if (!File.Exists(dbYolu))
            {
                MessageBox.Show($"Veritabanı dosyası bulunamadı!\nAranan yol: {dbYolu}", "Kritik Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string baglantiCumlesi = $"Data Source={dbYolu};Foreign Keys=True";
            string sorgu = "SELECT COUNT(*) FROM kullanici WHERE kullanici_adi = @kullanici AND sifre = @sifre";

            try
            {
                using (SqliteConnection baglanti = new SqliteConnection(baglantiCumlesi))
                {
                    baglanti.Open();

                    using (SqliteCommand komut = new SqliteCommand(sorgu, baglanti))
                    {
                        komut.Parameters.AddWithValue("@kullanici", kullaniciAdi);
                        komut.Parameters.AddWithValue("@sifre", sifre);

                        int eslesmeSayisi = Convert.ToInt32(komut.ExecuteScalar());

                        if (eslesmeSayisi > 0)
                        {
                            timer1.Stop(); // Arka planda timer çalışmaya devam etmesin

                            AnaForm anaF = new AnaForm();
                            // AnaForm kapatıldığında Giriş Formunu da kapat (Uygulama tamamen sonlansın)
                            anaF.FormClosed += (s, args) => this.Close();

                            this.Hide();
                            anaF.Show();
                        }
                        else
                        {
                            MessageBox.Show("Kullanıcı adı veya şifre hatalı!", "Giriş Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            sifreTxt.Focus();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanı bağlantısı sırasında bir hata oluştu:\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (sifreTxt.PasswordChar == '*')
            {
                sifreTxt.PasswordChar = '\0'; // Şifreyi göster
                pictureBox2.Image = Properties.Resources.goz_acik;
            }
            else
            {
                sifreTxt.PasswordChar = '*'; // Şifreyi gizle
                pictureBox2.Image = Properties.Resources.goz_kapali;
            }
        }

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            // Modern arayüzde Fixed3D yerine hafif konum kaydırma efekti daha şık durur
            pictureBox2.Top += 1;
        }

        private void pictureBox2_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox2.Top -= 1;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            sayac++;
            if (sayac <= 50)
            {
                if (!galeri3.Visible)
                {
                    galeri3.Visible = true;
                    galeri2.Visible = false;
                    galeri1.Visible = false;
                }
            }
            else if (sayac <= 100)
            {
                if (!galeri2.Visible)
                {
                    galeri3.Visible = false;
                    galeri2.Visible = true;
                    galeri1.Visible = false;
                }
            }
            else if (sayac <= 150)
            {
                if (!galeri1.Visible)
                {
                    galeri3.Visible = false;
                    galeri2.Visible = false;
                    galeri1.Visible = true;
                }
                if (sayac == 150) sayac = 0;
            }
        }
    }
}