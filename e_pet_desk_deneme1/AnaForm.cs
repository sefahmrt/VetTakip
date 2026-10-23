using System;
using System.Drawing;
using System.Windows.Forms;

namespace e_pet_desk_deneme1
{
    public partial class AnaForm : Form
    {
        private RadiusButton aktifButon = null;
        private readonly Color aktifRenk = Color.FromArgb(15, 118, 110);
        private readonly Color pasifYaziRengi = Color.DimGray;

        public AnaForm()
        {
            InitializeComponent();
            EkraniDuzenle();

            Version surum = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            this.Text = "VetTakip Klinik Sistemi - Alpha v" + surum.ToString();
            lblSurum.Text = "Alpha - v" + surum.ToString();

            // Başlangıçta Ana Sayfa butonunu aktif et ve AnaPanel'i yükle
            MenuButonunaTiklandi(AnaSayfaBtn, new AnaPanel());
        }

        /// <summary>
        /// Farklı ekran çözünürlüklerinde panellerin tam oturmasını sağlar.
        /// </summary>
        private void EkraniDuzenle()
        {
            LogoPanel.Dock = DockStyle.Top;
            MenuSidePanel.Dock = DockStyle.Left;
            panelContainer.Dock = DockStyle.Fill;
            panelContainer.BringToFront(); // Fill olan panelin diğerlerinin altına kaçmasını önler
        }

        private void MenuButonunaTiklandi(RadiusButton yeniButton, UserControl getirilecekUserControl)
        {
            // Eğer zaten aktif olan butona tekrar tıklandıysa işlem yapma (gereksiz yeniden yüklemeyi önler)
            if (aktifButon == yeniButton && panelContainer.Controls.Count > 0)
            {
                getirilecekUserControl?.Dispose();
                return;
            }

            // 1. Önceki aktif butonun görünümünü sıfırla
            if (aktifButon != null)
            {
                aktifButon.ButtonColor = Color.Transparent;
                aktifButon.TextColor = pasifYaziRengi;
                aktifButon.IsActive = false;
            }

            // 2. Yeni tıklanan butonu aktif olarak işaretle
            if (yeniButton != null)
            {
                aktifButon = yeniButton;
                aktifButon.ButtonColor = aktifRenk;
                aktifButon.TextColor = Color.WhiteSmoke;
                aktifButon.IsActive = true;
            }

            // 3. Paneldeki eski UserControl'leri bellekten tamamen temizle (Memory Leak Önlemi)
            while (panelContainer.Controls.Count > 0)
            {
                Control eskiKontrol = panelContainer.Controls[0];
                panelContainer.Controls.RemoveAt(0);
                eskiKontrol.Dispose();
            }

            // 4. Yeni UserControl'ü panele ekle
            if (getirilecekUserControl != null)
            {
                getirilecekUserControl.Dock = DockStyle.Fill;
                panelContainer.Controls.Add(getirilecekUserControl);
                getirilecekUserControl.BringToFront();
            }
        }

        private void MenuBtns_MouseEnter(object sender, EventArgs e)
        {
            if (sender is RadiusButton btn)
            {
                btn.TextColor = Color.WhiteSmoke;
            }
        }

        private void MenuBtns_MouseLeave(object sender, EventArgs e)
        {
            if (sender is RadiusButton btn && btn != aktifButon)
            {
                btn.TextColor = pasifYaziRengi;
            }
        }

        // --- MENÜ BUTON TIKLAMA OLAYLARI ---

        private void AnaSayfaBtn_Click(object sender, EventArgs e)
        {
            MenuButonunaTiklandi(AnaSayfaBtn, new AnaPanel());
        }

        private void RandevularBtn_Click(object sender, EventArgs e)
        {
            MenuButonunaTiklandi(RandevularBtn, new Randevular());
        }

        private void SahiplerBtn_Click(object sender, EventArgs e)
        {
            MenuButonunaTiklandi(SahiplerBtn, new SahiplerPanel());
        }

        private void HayvanlarBtn_Click(object sender, EventArgs e)
        {
            // İlgili UserControl oluşturulduğunda yorum satırını kaldırabilirsin:
            // MenuButonunaTiklandi(HayvanlarBtn, new HayvanlarPanel());
            YapimAsamasindaMesaji("Hayvanlar");
        }

        private void MuayeneBtn_Click(object sender, EventArgs e)
        {
            // MenuButonunaTiklandi(MuayeneBtn, new MuayenePanel());
            YapimAsamasindaMesaji("Muayene Geçmişi");
        }

        private void YatakliHBtn_Click(object sender, EventArgs e)
        {
            // MenuButonunaTiklandi(YataklıHBtn, new YatakliHastalarPanel());
            YapimAsamasindaMesaji("Yataklı Hastalar");
        }

        private void MesajlarBtn_Click(object sender, EventArgs e)
        {
            // MenuButonunaTiklandi(MesajlarBtn, new MesajlarPanel());
            YapimAsamasindaMesaji("Mesajlar");
        }

        private void HatirlatmaBtn_Click(object sender, EventArgs e)
        {
            // MenuButonunaTiklandi(HatirlatmaBtn, new HatirlatmaPanel());
            YapimAsamasindaMesaji("Hatırlatma");
        }

        private void TakvimBtn_Click(object sender, EventArgs e)
        {
            // MenuButonunaTiklandi(TakvimBtn, new TakvimPanel());
            YapimAsamasindaMesaji("Takvim");
        }

        private void AyarlarBtn_Click(object sender, EventArgs e)
        {
            // MenuButonunaTiklandi(AyarlarBtn, new AyarlarPanel());
            YapimAsamasindaMesaji("Ayarlar");
        }

        private void YapimAsamasindaMesaji(string modulAdi)
        {
            MessageBox.Show($"{modulAdi} modülü henüz yapım aşamasındadır.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void radiusButton1_Load(object sender, EventArgs e)
        {
        }
    }
}