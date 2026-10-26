using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Windows.Forms;


namespace VetTakip
{
    public partial class AnaForm : Form
    {
        private RadiusButton aktifButon = null;

        public AnaForm()
        {
            InitializeComponent();
            AdSoyadLbl.Text = GirisForm.AdSoyad;
            YetkiLbl.Text = GirisForm.Yetki;
            Version surum = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            this.Text = "E_Pet_Desk Alpha - v" + surum.ToString();
            lblSurum.Text = "Alpha - v" + surum.ToString();
            MenuButonunaTiklandi(AnaSayfaBtn, AnaPanelOlustur()); // açılışta Ana Sayfa seçili gelsin
            ProfilLogosuOlustur();
        }

        private void UserControlGetir(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill; // Sayfanın paneli tam doldurmasını sağlar
            // Önceki sayfayı kapat (Dispose). Sadece Controls.Clear() yapılırsa her tıklamada eski sayfa bellekte kalır.
            while (panelContainer.Controls.Count > 0)
                panelContainer.Controls[0].Dispose();
            panelContainer.Controls.Add(userControl); // Yeni sayfayı panele ekler
            userControl.BringToFront();       // Öne getirir
        }

        private void AnaSayfaBtn_Click(object sender, EventArgs e)
        {
            MenuButonunaTiklandi(AnaSayfaBtn, AnaPanelOlustur());
        }

        private void RandevularBtn_Click(object sender, EventArgs e)
        {
            Randevular uc = new Randevular();
            MenuButonunaTiklandi(RandevularBtn, uc);
        }

        private void SahiplerBtn_Click(object sender, EventArgs e)
        {
            SahiplerPanel uc = new SahiplerPanel();
            MenuButonunaTiklandi(SahiplerBtn, uc);
        }


        private void MenuButonunaTiklandi(RadiusButton yeniButton, UserControl getirilecekUserControl)
        {
            // 1. Eğer daha önce seçilmiş bir buton varsa, rengini normal haline döndür
            if (aktifButon != null)
            {
                aktifButon.ButtonColor = Color.Transparent; // RadiusButton'un arkaplan özelliği
                aktifButon.TextColor = Color.DimGray;          // RadiusButton'un yazı rengi özelliği
                aktifButon.IsActive = false;
            }

            // 2. Yeni tıklanan butonu "aktif buton" olarak işaretle ve rengini değiştir
            aktifButon = yeniButton;
            aktifButon.ButtonColor = Color.FromArgb(15, 118, 110);
            aktifButon.TextColor = Color.WhiteSmoke;
            aktifButon.IsActive = true;

            // 3. UserControl'ü panelin içinde açma işlemi
            UserControlGetir(getirilecekUserControl);
        }


        private void MenuBtns_MouseEnter(object sender, EventArgs e)
        {
            RadiusButton btn = sender as RadiusButton; // Button yerine RadiusButton'a dönüştürüyoruz

            if (btn != null)
            {
                btn.TextColor = Color.WhiteSmoke;
            }
        }

        private void MenuBtns_MouseLeave(object sender, EventArgs e)
        {
            RadiusButton btn = sender as RadiusButton; // Button yerine RadiusButton'a dönüştürüyoruz
            if (btn != null)
            {
                // Sadece aktif (seçili) OLMAYAN butonlar eski rengine dönsün
                if (btn != aktifButon)
                {
                    btn.TextColor = Color.DimGray;
                }
            }
        }

        private void ProfilLogosuOlustur()
        {
            // "Ahmet Can Yılmaz" -> "AY", "Ahmet" -> "A"
            string[] kelimeler = GirisForm.AdSoyad.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string harfler = "";
            foreach (string kelime in kelimeler)
                harfler += kelime.Substring(0, 1);
            if (harfler.Length > 3)
                harfler = harfler.Substring(0, 2) + harfler.Substring(harfler.Length - 1);

            // Türkçe kültürle büyüt (i -> İ)
            harfler = harfler.ToUpper(new CultureInfo("tr-TR"));

            int boyut = Math.Max(ProfilLogoPicture.Width, ProfilLogoPicture.Height);
            Bitmap bmp = new Bitmap(boyut, boyut);

            using (Graphics g = Graphics.FromImage(bmp))
            using (SolidBrush daireFirca = new SolidBrush(Color.FromArgb(15, 118, 110)))
            using (Font font = new Font("Segoe UI", boyut * 0.38f, FontStyle.Bold, GraphicsUnit.Pixel))
            using (StringFormat sf = new StringFormat())
            {
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;

                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;

                g.FillEllipse(daireFirca, 0, 0, boyut - 1, boyut - 1);
                g.DrawString(harfler, font, Brushes.White, new RectangleF(0, 0, boyut, boyut), sf);
            }

            ProfilLogoPicture.SizeMode = PictureBoxSizeMode.Zoom;
            if (ProfilLogoPicture.Image != null)
                ProfilLogoPicture.Image.Dispose();
            ProfilLogoPicture.Image = bmp;
        }

        private void HayvanlarBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Yapım Aşamasında");
        }

        private void MuayeneBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Yapım Aşamasında");
        }

        private void MesajlarBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Yapım Aşamasında");
        }

        private void TakvimBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Yapım Aşamasında");
        }

        private void AyarlarBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Yapım Aşamasında");
        }

        private void HatirlatmaBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Yapım Aşamasında");
        }

        private void YatakliHBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Yapım Aşamasında");
        }

        private void HayvanlarBtn_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Yapım Aşamasında");
        }

        private AnaPanel AnaPanelOlustur()
        {
            var panel = new AnaPanel();
            // Panel değişirken eski panel Dispose edildiği için, değişimi olay bittikten sonraya bırakıyoruz
            panel.TakvimeGitIstendi += delegate
            {
                BeginInvoke(new Action(() => MenuButonunaTiklandi(RandevularBtn, new Randevular())));
            };
            return panel;
        }
    }
}
