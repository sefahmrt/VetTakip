using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace e_pet_desk_deneme1
{
    public partial class AnaForm : Form
    {

        public AnaForm()
        {
            InitializeComponent();
            AnaPanel uc = new AnaPanel();
            UserControlGetir(uc);
            Version surum = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            this.Text = "E_Pet_Desk Alpha - v" + surum.ToString();
            lblSurum.Text = "Alpha - v" +surum.ToString();
        }

        private void UserControlGetir(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill; // Sayfanın paneli tam doldurmasını sağlar
            panelContainer.Controls.Clear();    // Paneldeki önceki sayfayı tamamen temizler
            panelContainer.Controls.Add(userControl); // Yeni sayfayı panele ekler
            userControl.BringToFront();       // Öne getirir
        }

        private void AnaPanelBtn_Click(object sender, EventArgs e)
        {
            AnaPanel uc = new AnaPanel();
            MenuButonunaTiklandi(AnaPanelBtn, uc); // Hangi buton olduğunu ve hangi UserControl'ün açılacağını söylüyoruz
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

        private Button aktifButon = null;

        private void MenuButonunaTiklandi(Button yeniButton, UserControl getirilecekUserControl)
        {
            // 1. Eğer daha önce seçilmiş bir buton varsa, rengini normal haline (örneğin beyaza) döndür
            if (aktifButon != null)
            {
                aktifButon.BackColor = Color.Transparent; // Varsayılan/Normal buton rengin
                aktifButon.ForeColor = Color.Gray;
            }

            // 2. Yeni tıklanan butonu "aktif buton" olarak işaretle ve rengini değiştir (örneğin açık gri/mavi)
            aktifButon = yeniButton;
            aktifButon.BackColor = Color.FromArgb(15, 118, 110); // Seçili (Aktif) buton rengin
            aktifButon.ForeColor = Color.WhiteSmoke;

            // 3. UserControl'ü panelin içinde açma işlemi (Daha önce yazdığımız metod)
            getirilecekUserControl.Dock = DockStyle.Fill;
            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(getirilecekUserControl);
            getirilecekUserControl.BringToFront();
        }


        private void MenuBtns_MouseEnter(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            if (btn != null) btn.ForeColor = Color.WhiteSmoke;
        }

        private void MenuBtns_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                // Sadece aktif (seçili) OLMAYAN butonlar transparan olsun
                if (btn != aktifButon)
                {
                    btn.ForeColor = Color.Gray;
                }
            }
        }

        private void radiusButton1_Load(object sender, EventArgs e)
        {

        }
    }
}
