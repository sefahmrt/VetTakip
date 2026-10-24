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
        }

        private void girisBtn_Click(object sender, EventArgs e)
        {
            string sorgu = "SELECT COUNT(*) FROM kullanici WHERE kullanici_adi = @kullanici AND sifre = @sifre";
            try
            {
                using (SQLiteConnection baglanti = Veritabani.Ac())
                using (SQLiteCommand komut = new SQLiteCommand(sorgu, baglanti))
                {
                    komut.Parameters.AddWithValue("@kullanici", kAdiTxt.Text.Trim());
                    komut.Parameters.AddWithValue("@sifre", sifreTxt.Text.Trim());

                    if (Convert.ToInt32(komut.ExecuteScalar()) > 0)
                    {
                        // Giriş formu kapanır, ana formu Program.cs açar.
                        // (Eskiden ana form açılıp bu form gizleniyordu; ana form kapatılınca program arka planda açık kalıyordu.)
                        DialogResult = DialogResult.OK;
                        return;
                    }
                }
                MessageBox.Show("Kullanıcı adı veya şifre hatalı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(Veritabani.HataMetni(ex), "Giriş yapılamadı", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

    }
}
