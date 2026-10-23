using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            lblSurum.Text = "Alpha - v" +surum.ToString();
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
            AnaPanel uc = new AnaPanel();
            MenuButonunaTiklandi(AnaSayfaBtn, uc); // Hangi buton olduğunu ve hangi UserControl'ün açılacağını söylüyoruz
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

        private void radiusButton1_Load(object sender, EventArgs e)
        {

        }

        private void HayvanlarBtn_Click(object sender, EventArgs e)
        {

        }

        private void MuayeneBtn_Click(object sender, EventArgs e)
        {

        }

        private void MesajlarBtn_Click(object sender, EventArgs e)
        {

        }

        private void TakvimBtn_Click(object sender, EventArgs e)
        {

        }

        private void AyarlarBtn_Click(object sender, EventArgs e)
        {

        }

        private void HatirlatmaBtn_Click(object sender, EventArgs e)
        {

        }

        private void YatakliHBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
