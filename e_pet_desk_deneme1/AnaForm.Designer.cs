namespace e_pet_desk_deneme1
{
    partial class AnaForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnaForm));
            this.LogoPanel = new RoundedPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.MenuSidePanel = new RoundedPanel();
            this.AnaSayfaBtn = new RadiusButton();
            this.RandevularBtn = new RadiusButton();
            this.HatirlatmaBtn = new RadiusButton();
            this.TakvimBtn = new RadiusButton();
            this.SahiplerBtn = new RadiusButton();
            this.MesajlarBtn = new RadiusButton();
            this.AyarlarBtn = new RadiusButton();
            this.HayvanlarBtn = new RadiusButton();
            this.YataklıHBtn = new RadiusButton();
            this.MuayeneBtn = new RadiusButton();
            this.panelContainer = new RoundedPanel();
            this.FooterPanel = new RoundedPanel();
            this.lblSurum = new System.Windows.Forms.Label();
            this.LogoPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.MenuSidePanel.SuspendLayout();
            this.FooterPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // LogoPanel
            // 
            this.LogoPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.LogoPanel.BorderColor = System.Drawing.Color.Gainsboro;
            this.LogoPanel.BorderRadius = 10;
            this.LogoPanel.BorderSize = 1;
            this.LogoPanel.Controls.Add(this.pictureBox1);
            this.LogoPanel.Controls.Add(this.label1);
            this.LogoPanel.Controls.Add(this.label2);
            this.LogoPanel.Location = new System.Drawing.Point(0, 0);
            this.LogoPanel.Name = "LogoPanel";
            this.LogoPanel.Size = new System.Drawing.Size(1264, 90);
            this.LogoPanel.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(10, 10);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(70, 70);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Inter", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(118)))), ((int)(((byte)(110)))));
            this.label1.Location = new System.Drawing.Point(80, 19);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "VetTakip";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(118)))), ((int)(((byte)(110)))));
            this.label2.Location = new System.Drawing.Point(92, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(192, 22);
            this.label2.TabIndex = 2;
            this.label2.Text = "Veteriner Klinik Takip Sistemi";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MenuSidePanel
            // 
            this.MenuSidePanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.MenuSidePanel.BorderColor = System.Drawing.Color.Gainsboro;
            this.MenuSidePanel.BorderRadius = 10;
            this.MenuSidePanel.BorderSize = 1;
            this.MenuSidePanel.Controls.Add(this.AnaSayfaBtn);
            this.MenuSidePanel.Controls.Add(this.RandevularBtn);
            this.MenuSidePanel.Controls.Add(this.HatirlatmaBtn);
            this.MenuSidePanel.Controls.Add(this.TakvimBtn);
            this.MenuSidePanel.Controls.Add(this.SahiplerBtn);
            this.MenuSidePanel.Controls.Add(this.MesajlarBtn);
            this.MenuSidePanel.Controls.Add(this.AyarlarBtn);
            this.MenuSidePanel.Controls.Add(this.HayvanlarBtn);
            this.MenuSidePanel.Controls.Add(this.YataklıHBtn);
            this.MenuSidePanel.Controls.Add(this.MuayeneBtn);
            this.MenuSidePanel.Location = new System.Drawing.Point(0, 96);
            this.MenuSidePanel.Name = "MenuSidePanel";
            this.MenuSidePanel.Size = new System.Drawing.Size(192, 586);
            this.MenuSidePanel.TabIndex = 0;
            // 
            // AnaSayfaBtn
            // 
            this.AnaSayfaBtn.BackColor = System.Drawing.Color.Transparent;
            this.AnaSayfaBtn.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.AnaSayfaBtn.BorderRadius = 8;
            this.AnaSayfaBtn.BorderSize = 0;
            this.AnaSayfaBtn.ButtonColor = System.Drawing.Color.Transparent;
            this.AnaSayfaBtn.ButtonIcon = ((System.Drawing.Image)(resources.GetObject("AnaSayfaBtn.ButtonIcon")));
            this.AnaSayfaBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AnaSayfaBtn.Font = new System.Drawing.Font("Inter SemiBold", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.AnaSayfaBtn.HoverIcon = ((System.Drawing.Image)(resources.GetObject("AnaSayfaBtn.HoverIcon")));
            this.AnaSayfaBtn.IconLocation = IconPosition.Left;
            this.AnaSayfaBtn.IsActive = false;
            this.AnaSayfaBtn.Location = new System.Drawing.Point(5, 5);
            this.AnaSayfaBtn.Margin = new System.Windows.Forms.Padding(5);
            this.AnaSayfaBtn.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(118)))), ((int)(((byte)(110)))));
            this.AnaSayfaBtn.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(118)))), ((int)(((byte)(110)))));
            this.AnaSayfaBtn.Name = "AnaSayfaBtn";
            this.AnaSayfaBtn.Size = new System.Drawing.Size(182, 40);
            this.AnaSayfaBtn.TabIndex = 8;
            this.AnaSayfaBtn.Text = "Ana Sayfa";
            this.AnaSayfaBtn.TextAlign = CustomTextAlign.Left;
            this.AnaSayfaBtn.TextColor = System.Drawing.Color.DimGray;
            this.AnaSayfaBtn.Click += new System.EventHandler(this.AnaSayfaBtn_Click);
            this.AnaSayfaBtn.MouseEnter += new System.EventHandler(this.MenuBtns_MouseEnter);
            this.AnaSayfaBtn.MouseLeave += new System.EventHandler(this.MenuBtns_MouseLeave);
            // 
            // RandevularBtn
            // 
            this.RandevularBtn.BackColor = System.Drawing.Color.Transparent;
            this.RandevularBtn.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.RandevularBtn.BorderRadius = 8;
            this.RandevularBtn.BorderSize = 0;
            this.RandevularBtn.ButtonColor = System.Drawing.Color.Transparent;
            this.RandevularBtn.ButtonIcon = ((System.Drawing.Image)(resources.GetObject("RandevularBtn.ButtonIcon")));
            this.RandevularBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RandevularBtn.Font = new System.Drawing.Font("Inter SemiBold", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.RandevularBtn.HoverIcon = ((System.Drawing.Image)(resources.GetObject("RandevularBtn.HoverIcon")));
            this.RandevularBtn.IconLocation = IconPosition.Left;
            this.RandevularBtn.IsActive = false;
            this.RandevularBtn.Location = new System.Drawing.Point(5, 53);
            this.RandevularBtn.Margin = new System.Windows.Forms.Padding(5);
            this.RandevularBtn.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(118)))), ((int)(((byte)(110)))));
            this.RandevularBtn.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(118)))), ((int)(((byte)(110)))));
            this.RandevularBtn.Name = "RandevularBtn";
            this.RandevularBtn.Size = new System.Drawing.Size(182, 40);
            this.RandevularBtn.TabIndex = 8;
            this.RandevularBtn.Text = "Randevular";
            this.RandevularBtn.TextAlign = CustomTextAlign.Left;
            this.RandevularBtn.TextColor = System.Drawing.Color.DimGray;
            this.RandevularBtn.Click += new System.EventHandler(this.RandevularBtn_Click);
            this.RandevularBtn.MouseEnter += new System.EventHandler(this.MenuBtns_MouseEnter);
            this.RandevularBtn.MouseLeave += new System.EventHandler(this.MenuBtns_MouseLeave);
            // 
            // HatirlatmaBtn
            // 
            this.HatirlatmaBtn.BackColor = System.Drawing.Color.Transparent;
            this.HatirlatmaBtn.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.HatirlatmaBtn.BorderRadius = 8;
            this.HatirlatmaBtn.BorderSize = 0;
            this.HatirlatmaBtn.ButtonColor = System.Drawing.Color.Transparent;
            this.HatirlatmaBtn.ButtonIcon = ((System.Drawing.Image)(resources.GetObject("HatirlatmaBtn.ButtonIcon")));
            this.HatirlatmaBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.HatirlatmaBtn.Font = new System.Drawing.Font("Inter SemiBold", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.HatirlatmaBtn.HoverIcon = ((System.Drawing.Image)(resources.GetObject("HatirlatmaBtn.HoverIcon")));
            this.HatirlatmaBtn.IconLocation = IconPosition.Left;
            this.HatirlatmaBtn.IsActive = false;
            this.HatirlatmaBtn.Location = new System.Drawing.Point(5, 341);
            this.HatirlatmaBtn.Margin = new System.Windows.Forms.Padding(5);
            this.HatirlatmaBtn.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(118)))), ((int)(((byte)(110)))));
            this.HatirlatmaBtn.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(118)))), ((int)(((byte)(110)))));
            this.HatirlatmaBtn.Name = "HatirlatmaBtn";
            this.HatirlatmaBtn.Size = new System.Drawing.Size(182, 40);
            this.HatirlatmaBtn.TabIndex = 8;
            this.HatirlatmaBtn.Text = "Hatırlatma";
            this.HatirlatmaBtn.TextAlign = CustomTextAlign.Left;
            this.HatirlatmaBtn.TextColor = System.Drawing.Color.DimGray;
            this.HatirlatmaBtn.Click += new System.EventHandler(this.HatirlatmaBtn_Click);
            this.HatirlatmaBtn.MouseEnter += new System.EventHandler(this.MenuBtns_MouseEnter);
            this.HatirlatmaBtn.MouseLeave += new System.EventHandler(this.MenuBtns_MouseLeave);
            // 
            // TakvimBtn
            // 
            this.TakvimBtn.BackColor = System.Drawing.Color.Transparent;
            this.TakvimBtn.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.TakvimBtn.BorderRadius = 8;
            this.TakvimBtn.BorderSize = 0;
            this.TakvimBtn.ButtonColor = System.Drawing.Color.Transparent;
            this.TakvimBtn.ButtonIcon = ((System.Drawing.Image)(resources.GetObject("TakvimBtn.ButtonIcon")));
            this.TakvimBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TakvimBtn.Font = new System.Drawing.Font("Inter SemiBold", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TakvimBtn.HoverIcon = ((System.Drawing.Image)(resources.GetObject("TakvimBtn.HoverIcon")));
            this.TakvimBtn.IconLocation = IconPosition.Left;
            this.TakvimBtn.IsActive = false;
            this.TakvimBtn.Location = new System.Drawing.Point(5, 389);
            this.TakvimBtn.Margin = new System.Windows.Forms.Padding(5);
            this.TakvimBtn.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(118)))), ((int)(((byte)(110)))));
            this.TakvimBtn.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(118)))), ((int)(((byte)(110)))));
            this.TakvimBtn.Name = "TakvimBtn";
            this.TakvimBtn.Size = new System.Drawing.Size(182, 40);
            this.TakvimBtn.TabIndex = 8;
            this.TakvimBtn.Text = "Takvim";
            this.TakvimBtn.TextAlign = CustomTextAlign.Left;
            this.TakvimBtn.TextColor = System.Drawing.Color.DimGray;
            this.TakvimBtn.Click += new System.EventHandler(this.TakvimBtn_Click);
            this.TakvimBtn.MouseEnter += new System.EventHandler(this.MenuBtns_MouseEnter);
            this.TakvimBtn.MouseLeave += new System.EventHandler(this.MenuBtns_MouseLeave);
            // 
            // SahiplerBtn
            // 
            this.SahiplerBtn.BackColor = System.Drawing.Color.Transparent;
            this.SahiplerBtn.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.SahiplerBtn.BorderRadius = 8;
            this.SahiplerBtn.BorderSize = 0;
            this.SahiplerBtn.ButtonColor = System.Drawing.Color.Transparent;
            this.SahiplerBtn.ButtonIcon = ((System.Drawing.Image)(resources.GetObject("SahiplerBtn.ButtonIcon")));
            this.SahiplerBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SahiplerBtn.Font = new System.Drawing.Font("Inter SemiBold", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.SahiplerBtn.HoverIcon = ((System.Drawing.Image)(resources.GetObject("SahiplerBtn.HoverIcon")));
            this.SahiplerBtn.IconLocation = IconPosition.Left;
            this.SahiplerBtn.IsActive = false;
            this.SahiplerBtn.Location = new System.Drawing.Point(5, 101);
            this.SahiplerBtn.Margin = new System.Windows.Forms.Padding(5);
            this.SahiplerBtn.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(118)))), ((int)(((byte)(110)))));
            this.SahiplerBtn.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(118)))), ((int)(((byte)(110)))));
            this.SahiplerBtn.Name = "SahiplerBtn";
            this.SahiplerBtn.Size = new System.Drawing.Size(182, 40);
            this.SahiplerBtn.TabIndex = 8;
            this.SahiplerBtn.Text = "Hasta Sahipleri";
            this.SahiplerBtn.TextAlign = CustomTextAlign.Left;
            this.SahiplerBtn.TextColor = System.Drawing.Color.DimGray;
            this.SahiplerBtn.Click += new System.EventHandler(this.SahiplerBtn_Click);
            this.SahiplerBtn.MouseEnter += new System.EventHandler(this.MenuBtns_MouseEnter);
            this.SahiplerBtn.MouseLeave += new System.EventHandler(this.MenuBtns_MouseLeave);
            // 
            // MesajlarBtn
            // 
            this.MesajlarBtn.BackColor = System.Drawing.Color.Transparent;
            this.MesajlarBtn.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.MesajlarBtn.BorderRadius = 8;
            this.MesajlarBtn.BorderSize = 0;
            this.MesajlarBtn.ButtonColor = System.Drawing.Color.Transparent;
            this.MesajlarBtn.ButtonIcon = ((System.Drawing.Image)(resources.GetObject("MesajlarBtn.ButtonIcon")));
            this.MesajlarBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MesajlarBtn.Font = new System.Drawing.Font("Inter SemiBold", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.MesajlarBtn.HoverIcon = ((System.Drawing.Image)(resources.GetObject("MesajlarBtn.HoverIcon")));
            this.MesajlarBtn.IconLocation = IconPosition.Left;
            this.MesajlarBtn.IsActive = false;
            this.MesajlarBtn.Location = new System.Drawing.Point(5, 293);
            this.MesajlarBtn.Margin = new System.Windows.Forms.Padding(5);
            this.MesajlarBtn.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(118)))), ((int)(((byte)(110)))));
            this.MesajlarBtn.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(118)))), ((int)(((byte)(110)))));
            this.MesajlarBtn.Name = "MesajlarBtn";
            this.MesajlarBtn.Size = new System.Drawing.Size(182, 40);
            this.MesajlarBtn.TabIndex = 8;
            this.MesajlarBtn.Text = "Mesajlar";
            this.MesajlarBtn.TextAlign = CustomTextAlign.Left;
            this.MesajlarBtn.TextColor = System.Drawing.Color.DimGray;
            this.MesajlarBtn.Click += new System.EventHandler(this.MesajlarBtn_Click);
            this.MesajlarBtn.MouseEnter += new System.EventHandler(this.MenuBtns_MouseEnter);
            this.MesajlarBtn.MouseLeave += new System.EventHandler(this.MenuBtns_MouseLeave);
            // 
            // AyarlarBtn
            // 
            this.AyarlarBtn.BackColor = System.Drawing.Color.Transparent;
            this.AyarlarBtn.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.AyarlarBtn.BorderRadius = 8;
            this.AyarlarBtn.BorderSize = 0;
            this.AyarlarBtn.ButtonColor = System.Drawing.Color.Transparent;
            this.AyarlarBtn.ButtonIcon = ((System.Drawing.Image)(resources.GetObject("AyarlarBtn.ButtonIcon")));
            this.AyarlarBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AyarlarBtn.Font = new System.Drawing.Font("Inter SemiBold", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.AyarlarBtn.HoverIcon = ((System.Drawing.Image)(resources.GetObject("AyarlarBtn.HoverIcon")));
            this.AyarlarBtn.IconLocation = IconPosition.Left;
            this.AyarlarBtn.IsActive = false;
            this.AyarlarBtn.Location = new System.Drawing.Point(5, 437);
            this.AyarlarBtn.Margin = new System.Windows.Forms.Padding(5);
            this.AyarlarBtn.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(118)))), ((int)(((byte)(110)))));
            this.AyarlarBtn.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(118)))), ((int)(((byte)(110)))));
            this.AyarlarBtn.Name = "AyarlarBtn";
            this.AyarlarBtn.Size = new System.Drawing.Size(182, 40);
            this.AyarlarBtn.TabIndex = 8;
            this.AyarlarBtn.Text = "Ayarlar";
            this.AyarlarBtn.TextAlign = CustomTextAlign.Left;
            this.AyarlarBtn.TextColor = System.Drawing.Color.DimGray;
            this.AyarlarBtn.Click += new System.EventHandler(this.AyarlarBtn_Click);
            this.AyarlarBtn.MouseEnter += new System.EventHandler(this.MenuBtns_MouseEnter);
            this.AyarlarBtn.MouseLeave += new System.EventHandler(this.MenuBtns_MouseLeave);
            // 
            // HayvanlarBtn
            // 
            this.HayvanlarBtn.BackColor = System.Drawing.Color.Transparent;
            this.HayvanlarBtn.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.HayvanlarBtn.BorderRadius = 8;
            this.HayvanlarBtn.BorderSize = 0;
            this.HayvanlarBtn.ButtonColor = System.Drawing.Color.Transparent;
            this.HayvanlarBtn.ButtonIcon = ((System.Drawing.Image)(resources.GetObject("HayvanlarBtn.ButtonIcon")));
            this.HayvanlarBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.HayvanlarBtn.Font = new System.Drawing.Font("Inter SemiBold", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.HayvanlarBtn.HoverIcon = ((System.Drawing.Image)(resources.GetObject("HayvanlarBtn.HoverIcon")));
            this.HayvanlarBtn.IconLocation = IconPosition.Left;
            this.HayvanlarBtn.IsActive = false;
            this.HayvanlarBtn.Location = new System.Drawing.Point(5, 149);
            this.HayvanlarBtn.Margin = new System.Windows.Forms.Padding(5);
            this.HayvanlarBtn.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(118)))), ((int)(((byte)(110)))));
            this.HayvanlarBtn.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(118)))), ((int)(((byte)(110)))));
            this.HayvanlarBtn.Name = "HayvanlarBtn";
            this.HayvanlarBtn.Size = new System.Drawing.Size(182, 40);
            this.HayvanlarBtn.TabIndex = 8;
            this.HayvanlarBtn.Text = "Hayvanlar";
            this.HayvanlarBtn.TextAlign = CustomTextAlign.Left;
            this.HayvanlarBtn.TextColor = System.Drawing.Color.DimGray;
            this.HayvanlarBtn.Click += new System.EventHandler(this.HayvanlarBtn_Click);
            this.HayvanlarBtn.MouseEnter += new System.EventHandler(this.MenuBtns_MouseEnter);
            this.HayvanlarBtn.MouseLeave += new System.EventHandler(this.MenuBtns_MouseLeave);
            // 
            // YataklıHBtn
            // 
            this.YataklıHBtn.BackColor = System.Drawing.Color.Transparent;
            this.YataklıHBtn.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.YataklıHBtn.BorderRadius = 8;
            this.YataklıHBtn.BorderSize = 0;
            this.YataklıHBtn.ButtonColor = System.Drawing.Color.Transparent;
            this.YataklıHBtn.ButtonIcon = ((System.Drawing.Image)(resources.GetObject("YataklıHBtn.ButtonIcon")));
            this.YataklıHBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.YataklıHBtn.Font = new System.Drawing.Font("Inter SemiBold", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.YataklıHBtn.HoverIcon = ((System.Drawing.Image)(resources.GetObject("YataklıHBtn.HoverIcon")));
            this.YataklıHBtn.IconLocation = IconPosition.Left;
            this.YataklıHBtn.IsActive = false;
            this.YataklıHBtn.Location = new System.Drawing.Point(5, 245);
            this.YataklıHBtn.Margin = new System.Windows.Forms.Padding(5);
            this.YataklıHBtn.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(118)))), ((int)(((byte)(110)))));
            this.YataklıHBtn.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(118)))), ((int)(((byte)(110)))));
            this.YataklıHBtn.Name = "YataklıHBtn";
            this.YataklıHBtn.Size = new System.Drawing.Size(182, 40);
            this.YataklıHBtn.TabIndex = 8;
            this.YataklıHBtn.Text = "Yataklı Hastalar";
            this.YataklıHBtn.TextAlign = CustomTextAlign.Left;
            this.YataklıHBtn.TextColor = System.Drawing.Color.DimGray;
            this.YataklıHBtn.Click += new System.EventHandler(this.YatakliHBtn_Click);
            this.YataklıHBtn.MouseEnter += new System.EventHandler(this.MenuBtns_MouseEnter);
            this.YataklıHBtn.MouseLeave += new System.EventHandler(this.MenuBtns_MouseLeave);
            // 
            // MuayeneBtn
            // 
            this.MuayeneBtn.BackColor = System.Drawing.Color.Transparent;
            this.MuayeneBtn.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.MuayeneBtn.BorderRadius = 8;
            this.MuayeneBtn.BorderSize = 0;
            this.MuayeneBtn.ButtonColor = System.Drawing.Color.Transparent;
            this.MuayeneBtn.ButtonIcon = ((System.Drawing.Image)(resources.GetObject("MuayeneBtn.ButtonIcon")));
            this.MuayeneBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MuayeneBtn.Font = new System.Drawing.Font("Inter SemiBold", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.MuayeneBtn.HoverIcon = ((System.Drawing.Image)(resources.GetObject("MuayeneBtn.HoverIcon")));
            this.MuayeneBtn.IconLocation = IconPosition.Left;
            this.MuayeneBtn.IsActive = false;
            this.MuayeneBtn.Location = new System.Drawing.Point(5, 197);
            this.MuayeneBtn.Margin = new System.Windows.Forms.Padding(5);
            this.MuayeneBtn.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(118)))), ((int)(((byte)(110)))));
            this.MuayeneBtn.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(118)))), ((int)(((byte)(110)))));
            this.MuayeneBtn.Name = "MuayeneBtn";
            this.MuayeneBtn.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.MuayeneBtn.Size = new System.Drawing.Size(182, 40);
            this.MuayeneBtn.TabIndex = 8;
            this.MuayeneBtn.Text = "Muayene Geçmişi";
            this.MuayeneBtn.TextAlign = CustomTextAlign.Left;
            this.MuayeneBtn.TextColor = System.Drawing.Color.DimGray;
            this.MuayeneBtn.Click += new System.EventHandler(this.MuayeneBtn_Click);
            this.MuayeneBtn.MouseEnter += new System.EventHandler(this.MenuBtns_MouseEnter);
            this.MuayeneBtn.MouseLeave += new System.EventHandler(this.MenuBtns_MouseLeave);
            // 
            // panelContainer
            // 
            this.panelContainer.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelContainer.BorderColor = System.Drawing.Color.Gainsboro;
            this.panelContainer.BorderRadius = 10;
            this.panelContainer.BorderSize = 1;
            this.panelContainer.Location = new System.Drawing.Point(198, 96);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(1066, 565);
            this.panelContainer.TabIndex = 6;
            // 
            // FooterPanel
            // 
            this.FooterPanel.BorderColor = System.Drawing.Color.Silver;
            this.FooterPanel.BorderRadius = 5;
            this.FooterPanel.BorderSize = 1;
            this.FooterPanel.Controls.Add(this.lblSurum);
            this.FooterPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 5F);
            this.FooterPanel.Location = new System.Drawing.Point(198, 667);
            this.FooterPanel.Name = "FooterPanel";
            this.FooterPanel.Size = new System.Drawing.Size(1066, 15);
            this.FooterPanel.TabIndex = 5;
            // 
            // lblSurum
            // 
            this.lblSurum.BackColor = System.Drawing.Color.Transparent;
            this.lblSurum.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblSurum.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.lblSurum.ForeColor = System.Drawing.Color.Gray;
            this.lblSurum.Location = new System.Drawing.Point(0, -10);
            this.lblSurum.Margin = new System.Windows.Forms.Padding(0);
            this.lblSurum.Name = "lblSurum";
            this.lblSurum.Size = new System.Drawing.Size(1066, 25);
            this.lblSurum.TabIndex = 0;
            this.lblSurum.Text = "label1";
            this.lblSurum.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // AnaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.LogoPanel);
            this.Controls.Add(this.MenuSidePanel);
            this.Controls.Add(this.panelContainer);
            this.Controls.Add(this.FooterPanel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AnaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "E_Pet_Desk";
            this.LogoPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.MenuSidePanel.ResumeLayout(false);
            this.FooterPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblSurum;
        private RoundedPanel FooterPanel;
        private RoundedPanel panelContainer;
        private RoundedPanel MenuSidePanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private RoundedPanel LogoPanel;
        private RadiusButton AyarlarBtn;
        private RadiusButton RandevularBtn;
        private RadiusButton SahiplerBtn;
        private RadiusButton HayvanlarBtn;
        private RadiusButton MuayeneBtn;
        private RadiusButton YataklıHBtn;
        private RadiusButton MesajlarBtn;
        private RadiusButton HatirlatmaBtn;
        private RadiusButton TakvimBtn;
        private RadiusButton AnaSayfaBtn;
    }
}