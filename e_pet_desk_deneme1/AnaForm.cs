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

        private void Buton_MouseEnter(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null) btn.BackColor = Color.LightGreen;
        }

        private void Buton_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null) btn.BackColor = Color.Transparent;
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
            UserControlGetir(uc);
        }

        private void RandevularBtn_Click(object sender, EventArgs e)
        {
            Randevular uc = new Randevular();
            UserControlGetir(uc);
        }

        private void SahiplerBtn_Click(object sender, EventArgs e)
        {
            SahiplerPanel uc = new SahiplerPanel();
            UserControlGetir(uc);
        }
    }
}
