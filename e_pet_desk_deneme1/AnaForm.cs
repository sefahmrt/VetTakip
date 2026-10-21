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
        public AnaForm()
        {
            InitializeComponent();
            AnaPanel uc = new AnaPanel();
            UserControlGetir(uc);
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
    }
}
