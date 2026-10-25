using System;
using System.Drawing;
using System.Windows.Forms;


namespace e_pet_desk_deneme1
{
    public partial class AnaForm : Form
    {
        private RadiusButton aktifButon = null;

        public AnaForm()
        {
            InitializeComponent();
            MenuButonunaTiklandi(AnaSayfaBtn, new AnaPanel()); // açılışta Ana Sayfa seçili gelsin
            Version surum = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            this.Text = "E_Pet_Desk Alpha - v" + surum.ToString();
            lblSurum.Text = "Alpha - v" + surum.ToString();
            MenuButonunaTiklandi(AnaSayfaBtn, AnaPanelOlustur());
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
