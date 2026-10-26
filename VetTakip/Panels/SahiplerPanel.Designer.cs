namespace VetTakip
{
  partial class SahiplerPanel
  {
    /// <summary> 
    ///Gerekli tasarımcı değişkeni.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary> 
    ///Kullanılan tüm kaynakları temizleyin.
    /// </summary>
    ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Bileşen Tasarımcısı üretimi kod

    /// <summary> 
    /// Tasarımcı desteği için gerekli metot - bu metodun 
    ///içeriğini kod düzenleyici ile değiştirmeyin.
    /// </summary>
    private void InitializeComponent()
    {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SahiplerPanel));
            this.YeniSahipBtn = new RadiusButton();
            this.roundedPanel2 = new RoundedPanel();
            this.pnlDetay = new System.Windows.Forms.Panel();
            this.pnlAvatar = new RoundedPanel();
            this.lblAvatar = new System.Windows.Forms.Label();
            this.lblAdSoyad = new System.Windows.Forms.Label();
            this.lblMusteriNo = new System.Windows.Forms.Label();
            this.btnDuzenle = new System.Windows.Forms.Button();
            this.btnSmsGonder = new System.Windows.Forms.Button();
            this.btnPasifeAl = new System.Windows.Forms.Button();
            this.pnlBilgi = new RoundedPanel();
            this.tableBilgi = new System.Windows.Forms.TableLayoutPanel();
            this.lblTelefonBaslik = new System.Windows.Forms.Label();
            this.lblTelefonNokta = new System.Windows.Forms.Label();
            this.lblTelefonDeger = new System.Windows.Forms.Label();
            this.lblTcBaslik = new System.Windows.Forms.Label();
            this.lblTcNokta = new System.Windows.Forms.Label();
            this.lblTcDeger = new System.Windows.Forms.Label();
            this.lblAcilKisiBaslik = new System.Windows.Forms.Label();
            this.lblAcilKisiNokta = new System.Windows.Forms.Label();
            this.lblAcilKisiDeger = new System.Windows.Forms.Label();
            this.lblKvkkBaslik = new System.Windows.Forms.Label();
            this.lblKvkkNokta = new System.Windows.Forms.Label();
            this.lblKvkkDeger = new System.Windows.Forms.Label();
            this.lblEpostaBaslik = new System.Windows.Forms.Label();
            this.lblEpostaNokta = new System.Windows.Forms.Label();
            this.lblEpostaDeger = new System.Windows.Forms.Label();
            this.lblAdresBaslik = new System.Windows.Forms.Label();
            this.lblAdresNokta = new System.Windows.Forms.Label();
            this.lblAdresDeger = new System.Windows.Forms.Label();
            this.lblSmsIzniBaslik = new System.Windows.Forms.Label();
            this.lblSmsIzniNokta = new System.Windows.Forms.Label();
            this.lblSmsIzniDeger = new System.Windows.Forms.Label();
            this.lblNotBaslik = new System.Windows.Forms.Label();
            this.lblNotNokta = new System.Windows.Forms.Label();
            this.lblNotDeger = new System.Windows.Forms.Label();
            this.lblTabHayvanlar = new System.Windows.Forms.Label();
            this.lblTabZiyaretler = new System.Windows.Forms.Label();
            this.lblTabMesaj = new System.Windows.Forms.Label();
            this.pnlSekmeCizgi = new System.Windows.Forms.Panel();
            this.flpHayvanlar = new System.Windows.Forms.FlowLayoutPanel();
            this.btnHayvanEkle = new System.Windows.Forms.Button();
            this.dgvZiyaretler = new System.Windows.Forms.DataGridView();
            this.lblMesajYok = new System.Windows.Forms.Label();
            this.lblSecimYok = new System.Windows.Forms.Label();
            this.roundedPanel1 = new RoundedPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtAra = new RadiusTextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.roundedPanel2.SuspendLayout();
            this.pnlDetay.SuspendLayout();
            this.pnlAvatar.SuspendLayout();
            this.pnlBilgi.SuspendLayout();
            this.tableBilgi.SuspendLayout();
            this.flpHayvanlar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvZiyaretler)).BeginInit();
            this.roundedPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // YeniSahipBtn
            // 
            this.YeniSahipBtn.BackColor = System.Drawing.Color.Transparent;
            this.YeniSahipBtn.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.YeniSahipBtn.BorderRadius = 10;
            this.YeniSahipBtn.BorderSize = 1;
            this.YeniSahipBtn.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(110)))), ((int)(((byte)(110)))));
            this.YeniSahipBtn.ButtonIcon = ((System.Drawing.Image)(resources.GetObject("YeniSahipBtn.ButtonIcon")));
            this.YeniSahipBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.YeniSahipBtn.Font = new System.Drawing.Font("Inter", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.YeniSahipBtn.HoverIcon = null;
            this.YeniSahipBtn.IconLocation = IconPosition.Left;
            this.YeniSahipBtn.IsActive = false;
            this.YeniSahipBtn.Location = new System.Drawing.Point(1384, 10);
            this.YeniSahipBtn.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.YeniSahipBtn.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.YeniSahipBtn.Name = "YeniSahipBtn";
            this.YeniSahipBtn.Size = new System.Drawing.Size(200, 50);
            this.YeniSahipBtn.TabIndex = 2;
            this.YeniSahipBtn.Text = "Yeni Sahip Ekle";
            this.YeniSahipBtn.TextAlign = CustomTextAlign.Center;
            this.YeniSahipBtn.TextColor = System.Drawing.Color.White;
            this.YeniSahipBtn.Click += new System.EventHandler(this.YeniSahipBtn_Click);
            // 
            // roundedPanel2
            // 
            this.roundedPanel2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.roundedPanel2.BackColor = System.Drawing.Color.White;
            this.roundedPanel2.BorderColor = System.Drawing.Color.Silver;
            this.roundedPanel2.BorderRadius = 10;
            this.roundedPanel2.BorderSize = 0;
            this.roundedPanel2.Controls.Add(this.pnlDetay);
            this.roundedPanel2.Controls.Add(this.lblSecimYok);
            this.roundedPanel2.Location = new System.Drawing.Point(1037, 67);
            this.roundedPanel2.Margin = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.roundedPanel2.Name = "roundedPanel2";
            this.roundedPanel2.Padding = new System.Windows.Forms.Padding(4);
            this.roundedPanel2.Size = new System.Drawing.Size(559, 776);
            this.roundedPanel2.TabIndex = 1;
            // 
            // pnlDetay
            // 
            this.pnlDetay.BackColor = System.Drawing.Color.White;
            this.pnlDetay.Controls.Add(this.pnlAvatar);
            this.pnlDetay.Controls.Add(this.lblAdSoyad);
            this.pnlDetay.Controls.Add(this.lblMusteriNo);
            this.pnlDetay.Controls.Add(this.btnDuzenle);
            this.pnlDetay.Controls.Add(this.btnSmsGonder);
            this.pnlDetay.Controls.Add(this.btnPasifeAl);
            this.pnlDetay.Controls.Add(this.pnlBilgi);
            this.pnlDetay.Controls.Add(this.lblTabHayvanlar);
            this.pnlDetay.Controls.Add(this.lblTabZiyaretler);
            this.pnlDetay.Controls.Add(this.lblTabMesaj);
            this.pnlDetay.Controls.Add(this.pnlSekmeCizgi);
            this.pnlDetay.Controls.Add(this.flpHayvanlar);
            this.pnlDetay.Controls.Add(this.dgvZiyaretler);
            this.pnlDetay.Controls.Add(this.lblMesajYok);
            this.pnlDetay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDetay.Location = new System.Drawing.Point(4, 4);
            this.pnlDetay.Margin = new System.Windows.Forms.Padding(0);
            this.pnlDetay.Name = "pnlDetay";
            this.pnlDetay.Size = new System.Drawing.Size(551, 768);
            this.pnlDetay.TabIndex = 0;
            // 
            // pnlAvatar
            // 
            this.pnlAvatar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.pnlAvatar.BorderColor = System.Drawing.Color.Silver;
            this.pnlAvatar.BorderRadius = 28;
            this.pnlAvatar.BorderSize = 0;
            this.pnlAvatar.Controls.Add(this.lblAvatar);
            this.pnlAvatar.Location = new System.Drawing.Point(19, 11);
            this.pnlAvatar.Margin = new System.Windows.Forms.Padding(0);
            this.pnlAvatar.Name = "pnlAvatar";
            this.pnlAvatar.Size = new System.Drawing.Size(56, 56);
            this.pnlAvatar.TabIndex = 0;
            // 
            // lblAvatar
            // 
            this.lblAvatar.BackColor = System.Drawing.Color.Transparent;
            this.lblAvatar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAvatar.Font = new System.Drawing.Font("Inter", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblAvatar.ForeColor = System.Drawing.Color.White;
            this.lblAvatar.Location = new System.Drawing.Point(0, 0);
            this.lblAvatar.Margin = new System.Windows.Forms.Padding(0);
            this.lblAvatar.Name = "lblAvatar";
            this.lblAvatar.Size = new System.Drawing.Size(56, 56);
            this.lblAvatar.TabIndex = 0;
            this.lblAvatar.Text = "YEK";
            this.lblAvatar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAdSoyad
            // 
            this.lblAdSoyad.AutoEllipsis = true;
            this.lblAdSoyad.Font = new System.Drawing.Font("Inter", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblAdSoyad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.lblAdSoyad.Location = new System.Drawing.Point(89, 9);
            this.lblAdSoyad.Name = "lblAdSoyad";
            this.lblAdSoyad.Size = new System.Drawing.Size(460, 32);
            this.lblAdSoyad.TabIndex = 1;
            this.lblAdSoyad.Text = "Ad Soyad";
            this.lblAdSoyad.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMusteriNo
            // 
            this.lblMusteriNo.AutoEllipsis = true;
            this.lblMusteriNo.Font = new System.Drawing.Font("Inter", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblMusteriNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.lblMusteriNo.Location = new System.Drawing.Point(89, 41);
            this.lblMusteriNo.Name = "lblMusteriNo";
            this.lblMusteriNo.Size = new System.Drawing.Size(460, 26);
            this.lblMusteriNo.TabIndex = 2;
            this.lblMusteriNo.Text = "müşteri no 0000 · Kayıt 00.00.0000";
            this.lblMusteriNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnDuzenle
            // 
            this.btnDuzenle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            this.btnDuzenle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDuzenle.FlatAppearance.BorderSize = 0;
            this.btnDuzenle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDuzenle.Font = new System.Drawing.Font("Inter", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnDuzenle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.btnDuzenle.Location = new System.Drawing.Point(19, 83);
            this.btnDuzenle.Name = "btnDuzenle";
            this.btnDuzenle.Size = new System.Drawing.Size(166, 36);
            this.btnDuzenle.TabIndex = 3;
            this.btnDuzenle.Text = "Düzenle";
            this.btnDuzenle.UseVisualStyleBackColor = false;
            this.btnDuzenle.Click += new System.EventHandler(this.btnDuzenle_Click);
            // 
            // btnSmsGonder
            // 
            this.btnSmsGonder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            this.btnSmsGonder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSmsGonder.FlatAppearance.BorderSize = 0;
            this.btnSmsGonder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSmsGonder.Font = new System.Drawing.Font("Inter", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSmsGonder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.btnSmsGonder.Location = new System.Drawing.Point(193, 83);
            this.btnSmsGonder.Name = "btnSmsGonder";
            this.btnSmsGonder.Size = new System.Drawing.Size(166, 36);
            this.btnSmsGonder.TabIndex = 4;
            this.btnSmsGonder.Text = "SMS gönder";
            this.btnSmsGonder.UseVisualStyleBackColor = false;
            this.btnSmsGonder.Click += new System.EventHandler(this.btnSmsGonder_Click);
            // 
            // btnPasifeAl
            // 
            this.btnPasifeAl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            this.btnPasifeAl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPasifeAl.FlatAppearance.BorderSize = 0;
            this.btnPasifeAl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPasifeAl.Font = new System.Drawing.Font("Inter", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnPasifeAl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.btnPasifeAl.Location = new System.Drawing.Point(367, 83);
            this.btnPasifeAl.Name = "btnPasifeAl";
            this.btnPasifeAl.Size = new System.Drawing.Size(166, 36);
            this.btnPasifeAl.TabIndex = 5;
            this.btnPasifeAl.Text = "Pasife al";
            this.btnPasifeAl.UseVisualStyleBackColor = false;
            this.btnPasifeAl.Click += new System.EventHandler(this.btnPasifeAl_Click);
            // 
            // pnlBilgi
            // 
            this.pnlBilgi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            this.pnlBilgi.BorderColor = System.Drawing.Color.Silver;
            this.pnlBilgi.BorderRadius = 6;
            this.pnlBilgi.BorderSize = 0;
            this.pnlBilgi.Controls.Add(this.tableBilgi);
            this.pnlBilgi.Location = new System.Drawing.Point(19, 138);
            this.pnlBilgi.Margin = new System.Windows.Forms.Padding(0);
            this.pnlBilgi.Name = "pnlBilgi";
            this.pnlBilgi.Padding = new System.Windows.Forms.Padding(16);
            this.pnlBilgi.Size = new System.Drawing.Size(514, 296);
            this.pnlBilgi.TabIndex = 6;
            // 
            // tableBilgi
            // 
            this.tableBilgi.BackColor = System.Drawing.Color.Transparent;
            this.tableBilgi.ColumnCount = 3;
            this.tableBilgi.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tableBilgi.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableBilgi.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableBilgi.Controls.Add(this.lblTelefonBaslik, 0, 0);
            this.tableBilgi.Controls.Add(this.lblTelefonNokta, 1, 0);
            this.tableBilgi.Controls.Add(this.lblTelefonDeger, 2, 0);
            this.tableBilgi.Controls.Add(this.lblTcBaslik, 0, 1);
            this.tableBilgi.Controls.Add(this.lblTcNokta, 1, 1);
            this.tableBilgi.Controls.Add(this.lblTcDeger, 2, 1);
            this.tableBilgi.Controls.Add(this.lblAcilKisiBaslik, 0, 2);
            this.tableBilgi.Controls.Add(this.lblAcilKisiNokta, 1, 2);
            this.tableBilgi.Controls.Add(this.lblAcilKisiDeger, 2, 2);
            this.tableBilgi.Controls.Add(this.lblKvkkBaslik, 0, 3);
            this.tableBilgi.Controls.Add(this.lblKvkkNokta, 1, 3);
            this.tableBilgi.Controls.Add(this.lblKvkkDeger, 2, 3);
            this.tableBilgi.Controls.Add(this.lblEpostaBaslik, 0, 4);
            this.tableBilgi.Controls.Add(this.lblEpostaNokta, 1, 4);
            this.tableBilgi.Controls.Add(this.lblEpostaDeger, 2, 4);
            this.tableBilgi.Controls.Add(this.lblAdresBaslik, 0, 5);
            this.tableBilgi.Controls.Add(this.lblAdresNokta, 1, 5);
            this.tableBilgi.Controls.Add(this.lblAdresDeger, 2, 5);
            this.tableBilgi.Controls.Add(this.lblSmsIzniBaslik, 0, 6);
            this.tableBilgi.Controls.Add(this.lblSmsIzniNokta, 1, 6);
            this.tableBilgi.Controls.Add(this.lblSmsIzniDeger, 2, 6);
            this.tableBilgi.Controls.Add(this.lblNotBaslik, 0, 7);
            this.tableBilgi.Controls.Add(this.lblNotNokta, 1, 7);
            this.tableBilgi.Controls.Add(this.lblNotDeger, 2, 7);
            this.tableBilgi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableBilgi.Font = new System.Drawing.Font("Inter", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tableBilgi.Location = new System.Drawing.Point(16, 16);
            this.tableBilgi.Margin = new System.Windows.Forms.Padding(0);
            this.tableBilgi.Name = "tableBilgi";
            this.tableBilgi.RowCount = 8;
            this.tableBilgi.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11136F));
            this.tableBilgi.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11136F));
            this.tableBilgi.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11136F));
            this.tableBilgi.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11136F));
            this.tableBilgi.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11136F));
            this.tableBilgi.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.2205F));
            this.tableBilgi.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11136F));
            this.tableBilgi.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11136F));
            this.tableBilgi.Size = new System.Drawing.Size(482, 264);
            this.tableBilgi.TabIndex = 0;
            // 
            // lblTelefonBaslik
            // 
            this.lblTelefonBaslik.AutoEllipsis = true;
            this.lblTelefonBaslik.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTelefonBaslik.Font = new System.Drawing.Font("Inter", 12F);
            this.lblTelefonBaslik.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(85)))), ((int)(((byte)(99)))));
            this.lblTelefonBaslik.Location = new System.Drawing.Point(0, 0);
            this.lblTelefonBaslik.Margin = new System.Windows.Forms.Padding(0);
            this.lblTelefonBaslik.Name = "lblTelefonBaslik";
            this.lblTelefonBaslik.Size = new System.Drawing.Size(140, 29);
            this.lblTelefonBaslik.TabIndex = 0;
            this.lblTelefonBaslik.Text = "Telefon";
            this.lblTelefonBaslik.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTelefonNokta
            // 
            this.lblTelefonNokta.AutoEllipsis = true;
            this.lblTelefonNokta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTelefonNokta.Font = new System.Drawing.Font("Inter", 12F);
            this.lblTelefonNokta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(85)))), ((int)(((byte)(99)))));
            this.lblTelefonNokta.Location = new System.Drawing.Point(140, 0);
            this.lblTelefonNokta.Margin = new System.Windows.Forms.Padding(0);
            this.lblTelefonNokta.Name = "lblTelefonNokta";
            this.lblTelefonNokta.Size = new System.Drawing.Size(20, 29);
            this.lblTelefonNokta.TabIndex = 1;
            this.lblTelefonNokta.Text = ":";
            this.lblTelefonNokta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTelefonDeger
            // 
            this.lblTelefonDeger.AutoEllipsis = true;
            this.lblTelefonDeger.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTelefonDeger.Font = new System.Drawing.Font("Inter", 12F);
            this.lblTelefonDeger.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.lblTelefonDeger.Location = new System.Drawing.Point(160, 0);
            this.lblTelefonDeger.Margin = new System.Windows.Forms.Padding(0);
            this.lblTelefonDeger.Name = "lblTelefonDeger";
            this.lblTelefonDeger.Size = new System.Drawing.Size(322, 29);
            this.lblTelefonDeger.TabIndex = 2;
            this.lblTelefonDeger.Text = "-";
            this.lblTelefonDeger.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTcBaslik
            // 
            this.lblTcBaslik.AutoEllipsis = true;
            this.lblTcBaslik.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTcBaslik.Font = new System.Drawing.Font("Inter", 12F);
            this.lblTcBaslik.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(85)))), ((int)(((byte)(99)))));
            this.lblTcBaslik.Location = new System.Drawing.Point(0, 29);
            this.lblTcBaslik.Margin = new System.Windows.Forms.Padding(0);
            this.lblTcBaslik.Name = "lblTcBaslik";
            this.lblTcBaslik.Size = new System.Drawing.Size(140, 29);
            this.lblTcBaslik.TabIndex = 3;
            this.lblTcBaslik.Text = "Tc kimlik no";
            this.lblTcBaslik.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTcNokta
            // 
            this.lblTcNokta.AutoEllipsis = true;
            this.lblTcNokta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTcNokta.Font = new System.Drawing.Font("Inter", 12F);
            this.lblTcNokta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(85)))), ((int)(((byte)(99)))));
            this.lblTcNokta.Location = new System.Drawing.Point(140, 29);
            this.lblTcNokta.Margin = new System.Windows.Forms.Padding(0);
            this.lblTcNokta.Name = "lblTcNokta";
            this.lblTcNokta.Size = new System.Drawing.Size(20, 29);
            this.lblTcNokta.TabIndex = 4;
            this.lblTcNokta.Text = ":";
            this.lblTcNokta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTcDeger
            // 
            this.lblTcDeger.AutoEllipsis = true;
            this.lblTcDeger.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTcDeger.Font = new System.Drawing.Font("Inter", 12F);
            this.lblTcDeger.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.lblTcDeger.Location = new System.Drawing.Point(160, 29);
            this.lblTcDeger.Margin = new System.Windows.Forms.Padding(0);
            this.lblTcDeger.Name = "lblTcDeger";
            this.lblTcDeger.Size = new System.Drawing.Size(322, 29);
            this.lblTcDeger.TabIndex = 5;
            this.lblTcDeger.Text = "-";
            this.lblTcDeger.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAcilKisiBaslik
            // 
            this.lblAcilKisiBaslik.AutoEllipsis = true;
            this.lblAcilKisiBaslik.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAcilKisiBaslik.Font = new System.Drawing.Font("Inter", 12F);
            this.lblAcilKisiBaslik.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(85)))), ((int)(((byte)(99)))));
            this.lblAcilKisiBaslik.Location = new System.Drawing.Point(0, 58);
            this.lblAcilKisiBaslik.Margin = new System.Windows.Forms.Padding(0);
            this.lblAcilKisiBaslik.Name = "lblAcilKisiBaslik";
            this.lblAcilKisiBaslik.Size = new System.Drawing.Size(140, 29);
            this.lblAcilKisiBaslik.TabIndex = 6;
            this.lblAcilKisiBaslik.Text = "Acil durum kişisi";
            this.lblAcilKisiBaslik.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAcilKisiNokta
            // 
            this.lblAcilKisiNokta.AutoEllipsis = true;
            this.lblAcilKisiNokta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAcilKisiNokta.Font = new System.Drawing.Font("Inter", 12F);
            this.lblAcilKisiNokta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(85)))), ((int)(((byte)(99)))));
            this.lblAcilKisiNokta.Location = new System.Drawing.Point(140, 58);
            this.lblAcilKisiNokta.Margin = new System.Windows.Forms.Padding(0);
            this.lblAcilKisiNokta.Name = "lblAcilKisiNokta";
            this.lblAcilKisiNokta.Size = new System.Drawing.Size(20, 29);
            this.lblAcilKisiNokta.TabIndex = 7;
            this.lblAcilKisiNokta.Text = ":";
            this.lblAcilKisiNokta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAcilKisiDeger
            // 
            this.lblAcilKisiDeger.AutoEllipsis = true;
            this.lblAcilKisiDeger.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAcilKisiDeger.Font = new System.Drawing.Font("Inter", 12F);
            this.lblAcilKisiDeger.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.lblAcilKisiDeger.Location = new System.Drawing.Point(160, 58);
            this.lblAcilKisiDeger.Margin = new System.Windows.Forms.Padding(0);
            this.lblAcilKisiDeger.Name = "lblAcilKisiDeger";
            this.lblAcilKisiDeger.Size = new System.Drawing.Size(322, 29);
            this.lblAcilKisiDeger.TabIndex = 8;
            this.lblAcilKisiDeger.Text = "-";
            this.lblAcilKisiDeger.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblKvkkBaslik
            // 
            this.lblKvkkBaslik.AutoEllipsis = true;
            this.lblKvkkBaslik.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblKvkkBaslik.Font = new System.Drawing.Font("Inter", 12F);
            this.lblKvkkBaslik.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(85)))), ((int)(((byte)(99)))));
            this.lblKvkkBaslik.Location = new System.Drawing.Point(0, 87);
            this.lblKvkkBaslik.Margin = new System.Windows.Forms.Padding(0);
            this.lblKvkkBaslik.Name = "lblKvkkBaslik";
            this.lblKvkkBaslik.Size = new System.Drawing.Size(140, 29);
            this.lblKvkkBaslik.TabIndex = 9;
            this.lblKvkkBaslik.Text = "KVKK onayı";
            this.lblKvkkBaslik.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblKvkkNokta
            // 
            this.lblKvkkNokta.AutoEllipsis = true;
            this.lblKvkkNokta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblKvkkNokta.Font = new System.Drawing.Font("Inter", 12F);
            this.lblKvkkNokta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(85)))), ((int)(((byte)(99)))));
            this.lblKvkkNokta.Location = new System.Drawing.Point(140, 87);
            this.lblKvkkNokta.Margin = new System.Windows.Forms.Padding(0);
            this.lblKvkkNokta.Name = "lblKvkkNokta";
            this.lblKvkkNokta.Size = new System.Drawing.Size(20, 29);
            this.lblKvkkNokta.TabIndex = 10;
            this.lblKvkkNokta.Text = ":";
            this.lblKvkkNokta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblKvkkDeger
            // 
            this.lblKvkkDeger.AutoEllipsis = true;
            this.lblKvkkDeger.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblKvkkDeger.Font = new System.Drawing.Font("Inter", 12F);
            this.lblKvkkDeger.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.lblKvkkDeger.Location = new System.Drawing.Point(160, 87);
            this.lblKvkkDeger.Margin = new System.Windows.Forms.Padding(0);
            this.lblKvkkDeger.Name = "lblKvkkDeger";
            this.lblKvkkDeger.Size = new System.Drawing.Size(322, 29);
            this.lblKvkkDeger.TabIndex = 11;
            this.lblKvkkDeger.Text = "-";
            this.lblKvkkDeger.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblEpostaBaslik
            // 
            this.lblEpostaBaslik.AutoEllipsis = true;
            this.lblEpostaBaslik.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEpostaBaslik.Font = new System.Drawing.Font("Inter", 12F);
            this.lblEpostaBaslik.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(85)))), ((int)(((byte)(99)))));
            this.lblEpostaBaslik.Location = new System.Drawing.Point(0, 116);
            this.lblEpostaBaslik.Margin = new System.Windows.Forms.Padding(0);
            this.lblEpostaBaslik.Name = "lblEpostaBaslik";
            this.lblEpostaBaslik.Size = new System.Drawing.Size(140, 29);
            this.lblEpostaBaslik.TabIndex = 12;
            this.lblEpostaBaslik.Text = "E posta";
            this.lblEpostaBaslik.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblEpostaNokta
            // 
            this.lblEpostaNokta.AutoEllipsis = true;
            this.lblEpostaNokta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEpostaNokta.Font = new System.Drawing.Font("Inter", 12F);
            this.lblEpostaNokta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(85)))), ((int)(((byte)(99)))));
            this.lblEpostaNokta.Location = new System.Drawing.Point(140, 116);
            this.lblEpostaNokta.Margin = new System.Windows.Forms.Padding(0);
            this.lblEpostaNokta.Name = "lblEpostaNokta";
            this.lblEpostaNokta.Size = new System.Drawing.Size(20, 29);
            this.lblEpostaNokta.TabIndex = 13;
            this.lblEpostaNokta.Text = ":";
            this.lblEpostaNokta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblEpostaDeger
            // 
            this.lblEpostaDeger.AutoEllipsis = true;
            this.lblEpostaDeger.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEpostaDeger.Font = new System.Drawing.Font("Inter", 12F);
            this.lblEpostaDeger.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.lblEpostaDeger.Location = new System.Drawing.Point(160, 116);
            this.lblEpostaDeger.Margin = new System.Windows.Forms.Padding(0);
            this.lblEpostaDeger.Name = "lblEpostaDeger";
            this.lblEpostaDeger.Size = new System.Drawing.Size(322, 29);
            this.lblEpostaDeger.TabIndex = 14;
            this.lblEpostaDeger.Text = "-";
            this.lblEpostaDeger.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAdresBaslik
            // 
            this.lblAdresBaslik.AutoEllipsis = true;
            this.lblAdresBaslik.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAdresBaslik.Font = new System.Drawing.Font("Inter", 12F);
            this.lblAdresBaslik.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(85)))), ((int)(((byte)(99)))));
            this.lblAdresBaslik.Location = new System.Drawing.Point(0, 145);
            this.lblAdresBaslik.Margin = new System.Windows.Forms.Padding(0);
            this.lblAdresBaslik.Name = "lblAdresBaslik";
            this.lblAdresBaslik.Size = new System.Drawing.Size(140, 58);
            this.lblAdresBaslik.TabIndex = 15;
            this.lblAdresBaslik.Text = "Adres";
            this.lblAdresBaslik.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAdresNokta
            // 
            this.lblAdresNokta.AutoEllipsis = true;
            this.lblAdresNokta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAdresNokta.Font = new System.Drawing.Font("Inter", 12F);
            this.lblAdresNokta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(85)))), ((int)(((byte)(99)))));
            this.lblAdresNokta.Location = new System.Drawing.Point(140, 145);
            this.lblAdresNokta.Margin = new System.Windows.Forms.Padding(0);
            this.lblAdresNokta.Name = "lblAdresNokta";
            this.lblAdresNokta.Size = new System.Drawing.Size(20, 58);
            this.lblAdresNokta.TabIndex = 16;
            this.lblAdresNokta.Text = ":";
            this.lblAdresNokta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAdresDeger
            // 
            this.lblAdresDeger.AutoEllipsis = true;
            this.lblAdresDeger.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAdresDeger.Font = new System.Drawing.Font("Inter", 12F);
            this.lblAdresDeger.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.lblAdresDeger.Location = new System.Drawing.Point(160, 145);
            this.lblAdresDeger.Margin = new System.Windows.Forms.Padding(0);
            this.lblAdresDeger.Name = "lblAdresDeger";
            this.lblAdresDeger.Size = new System.Drawing.Size(322, 58);
            this.lblAdresDeger.TabIndex = 17;
            this.lblAdresDeger.Text = "-";
            this.lblAdresDeger.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSmsIzniBaslik
            // 
            this.lblSmsIzniBaslik.AutoEllipsis = true;
            this.lblSmsIzniBaslik.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSmsIzniBaslik.Font = new System.Drawing.Font("Inter", 12F);
            this.lblSmsIzniBaslik.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(85)))), ((int)(((byte)(99)))));
            this.lblSmsIzniBaslik.Location = new System.Drawing.Point(0, 203);
            this.lblSmsIzniBaslik.Margin = new System.Windows.Forms.Padding(0);
            this.lblSmsIzniBaslik.Name = "lblSmsIzniBaslik";
            this.lblSmsIzniBaslik.Size = new System.Drawing.Size(140, 29);
            this.lblSmsIzniBaslik.TabIndex = 18;
            this.lblSmsIzniBaslik.Text = "SMS izni";
            this.lblSmsIzniBaslik.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSmsIzniNokta
            // 
            this.lblSmsIzniNokta.AutoEllipsis = true;
            this.lblSmsIzniNokta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSmsIzniNokta.Font = new System.Drawing.Font("Inter", 12F);
            this.lblSmsIzniNokta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(85)))), ((int)(((byte)(99)))));
            this.lblSmsIzniNokta.Location = new System.Drawing.Point(140, 203);
            this.lblSmsIzniNokta.Margin = new System.Windows.Forms.Padding(0);
            this.lblSmsIzniNokta.Name = "lblSmsIzniNokta";
            this.lblSmsIzniNokta.Size = new System.Drawing.Size(20, 29);
            this.lblSmsIzniNokta.TabIndex = 19;
            this.lblSmsIzniNokta.Text = ":";
            this.lblSmsIzniNokta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSmsIzniDeger
            // 
            this.lblSmsIzniDeger.AutoEllipsis = true;
            this.lblSmsIzniDeger.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSmsIzniDeger.Font = new System.Drawing.Font("Inter", 12F);
            this.lblSmsIzniDeger.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.lblSmsIzniDeger.Location = new System.Drawing.Point(160, 203);
            this.lblSmsIzniDeger.Margin = new System.Windows.Forms.Padding(0);
            this.lblSmsIzniDeger.Name = "lblSmsIzniDeger";
            this.lblSmsIzniDeger.Size = new System.Drawing.Size(322, 29);
            this.lblSmsIzniDeger.TabIndex = 20;
            this.lblSmsIzniDeger.Text = "-";
            this.lblSmsIzniDeger.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNotBaslik
            // 
            this.lblNotBaslik.AutoEllipsis = true;
            this.lblNotBaslik.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNotBaslik.Font = new System.Drawing.Font("Inter", 12F);
            this.lblNotBaslik.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(85)))), ((int)(((byte)(99)))));
            this.lblNotBaslik.Location = new System.Drawing.Point(0, 232);
            this.lblNotBaslik.Margin = new System.Windows.Forms.Padding(0);
            this.lblNotBaslik.Name = "lblNotBaslik";
            this.lblNotBaslik.Size = new System.Drawing.Size(140, 32);
            this.lblNotBaslik.TabIndex = 21;
            this.lblNotBaslik.Text = "Not";
            this.lblNotBaslik.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNotNokta
            // 
            this.lblNotNokta.AutoEllipsis = true;
            this.lblNotNokta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNotNokta.Font = new System.Drawing.Font("Inter", 12F);
            this.lblNotNokta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(85)))), ((int)(((byte)(99)))));
            this.lblNotNokta.Location = new System.Drawing.Point(140, 232);
            this.lblNotNokta.Margin = new System.Windows.Forms.Padding(0);
            this.lblNotNokta.Name = "lblNotNokta";
            this.lblNotNokta.Size = new System.Drawing.Size(20, 32);
            this.lblNotNokta.TabIndex = 22;
            this.lblNotNokta.Text = ":";
            this.lblNotNokta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNotDeger
            // 
            this.lblNotDeger.AutoEllipsis = true;
            this.lblNotDeger.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNotDeger.Font = new System.Drawing.Font("Inter", 12F);
            this.lblNotDeger.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.lblNotDeger.Location = new System.Drawing.Point(160, 232);
            this.lblNotDeger.Margin = new System.Windows.Forms.Padding(0);
            this.lblNotDeger.Name = "lblNotDeger";
            this.lblNotDeger.Size = new System.Drawing.Size(322, 32);
            this.lblNotDeger.TabIndex = 23;
            this.lblNotDeger.Text = "-";
            this.lblNotDeger.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTabHayvanlar
            // 
            this.lblTabHayvanlar.AutoSize = true;
            this.lblTabHayvanlar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblTabHayvanlar.Font = new System.Drawing.Font("Inter", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblTabHayvanlar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.lblTabHayvanlar.Location = new System.Drawing.Point(19, 440);
            this.lblTabHayvanlar.Name = "lblTabHayvanlar";
            this.lblTabHayvanlar.Size = new System.Drawing.Size(111, 22);
            this.lblTabHayvanlar.TabIndex = 8;
            this.lblTabHayvanlar.Tag = "0";
            this.lblTabHayvanlar.Text = "Hayvanlar (0)";
            this.lblTabHayvanlar.Click += new System.EventHandler(this.lblTab_Click);
            // 
            // lblTabZiyaretler
            // 
            this.lblTabZiyaretler.AutoSize = true;
            this.lblTabZiyaretler.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblTabZiyaretler.Font = new System.Drawing.Font("Inter", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblTabZiyaretler.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.lblTabZiyaretler.Location = new System.Drawing.Point(171, 440);
            this.lblTabZiyaretler.Name = "lblTabZiyaretler";
            this.lblTabZiyaretler.Size = new System.Drawing.Size(78, 22);
            this.lblTabZiyaretler.TabIndex = 9;
            this.lblTabZiyaretler.Tag = "1";
            this.lblTabZiyaretler.Text = "Ziyaretler";
            this.lblTabZiyaretler.Click += new System.EventHandler(this.lblTab_Click);
            // 
            // lblTabMesaj
            // 
            this.lblTabMesaj.AutoSize = true;
            this.lblTabMesaj.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblTabMesaj.Font = new System.Drawing.Font("Inter", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblTabMesaj.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.lblTabMesaj.Location = new System.Drawing.Point(281, 440);
            this.lblTabMesaj.Name = "lblTabMesaj";
            this.lblTabMesaj.Size = new System.Drawing.Size(115, 22);
            this.lblTabMesaj.TabIndex = 10;
            this.lblTabMesaj.Tag = "2";
            this.lblTabMesaj.Text = "Mesaj Geçmişi";
            this.lblTabMesaj.Click += new System.EventHandler(this.lblTab_Click);
            // 
            // pnlSekmeCizgi
            // 
            this.pnlSekmeCizgi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.pnlSekmeCizgi.Location = new System.Drawing.Point(19, 466);
            this.pnlSekmeCizgi.Margin = new System.Windows.Forms.Padding(0);
            this.pnlSekmeCizgi.Name = "pnlSekmeCizgi";
            this.pnlSekmeCizgi.Size = new System.Drawing.Size(110, 3);
            this.pnlSekmeCizgi.TabIndex = 11;
            // 
            // flpHayvanlar
            // 
            this.flpHayvanlar.AutoScroll = true;
            this.flpHayvanlar.BackColor = System.Drawing.Color.White;
            this.flpHayvanlar.Controls.Add(this.btnHayvanEkle);
            this.flpHayvanlar.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpHayvanlar.Location = new System.Drawing.Point(19, 478);
            this.flpHayvanlar.Margin = new System.Windows.Forms.Padding(0);
            this.flpHayvanlar.Name = "flpHayvanlar";
            this.flpHayvanlar.Size = new System.Drawing.Size(514, 279);
            this.flpHayvanlar.TabIndex = 12;
            this.flpHayvanlar.WrapContents = false;
            // 
            // btnHayvanEkle
            // 
            this.btnHayvanEkle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(231)))), ((int)(((byte)(235)))));
            this.btnHayvanEkle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHayvanEkle.FlatAppearance.BorderSize = 0;
            this.btnHayvanEkle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHayvanEkle.Font = new System.Drawing.Font("Inter", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnHayvanEkle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.btnHayvanEkle.Location = new System.Drawing.Point(0, 0);
            this.btnHayvanEkle.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.btnHayvanEkle.Name = "btnHayvanEkle";
            this.btnHayvanEkle.Size = new System.Drawing.Size(541, 84);
            this.btnHayvanEkle.TabIndex = 0;
            this.btnHayvanEkle.Text = "+  Hayvan ekle";
            this.btnHayvanEkle.UseVisualStyleBackColor = false;
            this.btnHayvanEkle.Click += new System.EventHandler(this.btnHayvanEkle_Click);
            // 
            // dgvZiyaretler
            // 
            this.dgvZiyaretler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvZiyaretler.Location = new System.Drawing.Point(19, 473);
            this.dgvZiyaretler.Margin = new System.Windows.Forms.Padding(0);
            this.dgvZiyaretler.Name = "dgvZiyaretler";
            this.dgvZiyaretler.Size = new System.Drawing.Size(514, 279);
            this.dgvZiyaretler.TabIndex = 13;
            this.dgvZiyaretler.Visible = false;
            // 
            // lblMesajYok
            // 
            this.lblMesajYok.Font = new System.Drawing.Font("Inter", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblMesajYok.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblMesajYok.Location = new System.Drawing.Point(19, 473);
            this.lblMesajYok.Name = "lblMesajYok";
            this.lblMesajYok.Size = new System.Drawing.Size(514, 279);
            this.lblMesajYok.TabIndex = 14;
            this.lblMesajYok.Text = "Bu müşteri için kayıtlı mesaj geçmişi yok.";
            this.lblMesajYok.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMesajYok.Visible = false;
            // 
            // lblSecimYok
            // 
            this.lblSecimYok.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSecimYok.Font = new System.Drawing.Font("Inter", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSecimYok.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblSecimYok.Location = new System.Drawing.Point(4, 4);
            this.lblSecimYok.Name = "lblSecimYok";
            this.lblSecimYok.Size = new System.Drawing.Size(551, 768);
            this.lblSecimYok.TabIndex = 1;
            this.lblSecimYok.Text = "Detayları görmek için listeden bir sahip seçin.";
            this.lblSecimYok.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSecimYok.Visible = false;
            // 
            // roundedPanel1
            // 
            this.roundedPanel1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.roundedPanel1.BackColor = System.Drawing.Color.White;
            this.roundedPanel1.BorderColor = System.Drawing.Color.Silver;
            this.roundedPanel1.BorderRadius = 10;
            this.roundedPanel1.BorderSize = 0;
            this.roundedPanel1.Controls.Add(this.pictureBox1);
            this.roundedPanel1.Controls.Add(this.txtAra);
            this.roundedPanel1.Controls.Add(this.dataGridView1);
            this.roundedPanel1.Location = new System.Drawing.Point(30, 30);
            this.roundedPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.roundedPanel1.Name = "roundedPanel1";
            this.roundedPanel1.Padding = new System.Windows.Forms.Padding(10, 57, 10, 10);
            this.roundedPanel1.Size = new System.Drawing.Size(947, 813);
            this.roundedPanel1.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(20, 22);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(30, 15, 5, 15);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(20, 20);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // txtAra
            // 
            this.txtAra.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtAra.BorderColor = System.Drawing.Color.DimGray;
            this.txtAra.BorderRadius = 10;
            this.txtAra.BorderSize = 1;
            this.txtAra.Font = new System.Drawing.Font("Inter", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtAra.Location = new System.Drawing.Point(10, 12);
            this.txtAra.Margin = new System.Windows.Forms.Padding(10);
            this.txtAra.Multiline = false;
            this.txtAra.Name = "txtAra";
            this.txtAra.Padding = new System.Windows.Forms.Padding(40, 9, 10, 0);
            this.txtAra.PasswordChar = '\0';
            this.txtAra.PlaceholderText = "Arama Yap";
            this.txtAra.Size = new System.Drawing.Size(327, 38);
            this.txtAra.TabIndex = 3;
            this.txtAra.UseSystemPasswordChar = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(10, 57);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(927, 746);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // SahiplerPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.Controls.Add(this.YeniSahipBtn);
            this.Controls.Add(this.roundedPanel2);
            this.Controls.Add(this.roundedPanel1);
            this.Font = new System.Drawing.Font("Inter", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "SahiplerPanel";
            this.Padding = new System.Windows.Forms.Padding(30);
            this.Size = new System.Drawing.Size(1626, 873);
            this.roundedPanel2.ResumeLayout(false);
            this.pnlDetay.ResumeLayout(false);
            this.pnlDetay.PerformLayout();
            this.pnlAvatar.ResumeLayout(false);
            this.pnlBilgi.ResumeLayout(false);
            this.tableBilgi.ResumeLayout(false);
            this.flpHayvanlar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvZiyaretler)).EndInit();
            this.roundedPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

    }

    #endregion
    private System.Windows.Forms.DataGridView dataGridView1;
    private RoundedPanel roundedPanel1;
    private RoundedPanel roundedPanel2;
    private System.Windows.Forms.PictureBox pictureBox1;
    private RadiusTextBox txtAra;
    private System.Windows.Forms.Panel pnlDetay;
    private System.Windows.Forms.Label lblSecimYok;
    private RoundedPanel pnlAvatar;
    private System.Windows.Forms.Label lblAvatar;
    private System.Windows.Forms.Label lblAdSoyad;
    private System.Windows.Forms.Label lblMusteriNo;
    private System.Windows.Forms.Button btnDuzenle;
    private System.Windows.Forms.Button btnSmsGonder;
    private System.Windows.Forms.Button btnPasifeAl;
    private RoundedPanel pnlBilgi;
    private System.Windows.Forms.TableLayoutPanel tableBilgi;
    private System.Windows.Forms.Label lblTelefonBaslik;
    private System.Windows.Forms.Label lblTelefonNokta;
    private System.Windows.Forms.Label lblTelefonDeger;
    private System.Windows.Forms.Label lblTcBaslik;
    private System.Windows.Forms.Label lblTcNokta;
    private System.Windows.Forms.Label lblTcDeger;
    private System.Windows.Forms.Label lblAcilKisiBaslik;
    private System.Windows.Forms.Label lblAcilKisiNokta;
    private System.Windows.Forms.Label lblAcilKisiDeger;
    private System.Windows.Forms.Label lblKvkkBaslik;
    private System.Windows.Forms.Label lblKvkkNokta;
    private System.Windows.Forms.Label lblKvkkDeger;
    private System.Windows.Forms.Label lblEpostaBaslik;
    private System.Windows.Forms.Label lblEpostaNokta;
    private System.Windows.Forms.Label lblEpostaDeger;
    private System.Windows.Forms.Label lblAdresBaslik;
    private System.Windows.Forms.Label lblAdresNokta;
    private System.Windows.Forms.Label lblAdresDeger;
    private System.Windows.Forms.Label lblSmsIzniBaslik;
    private System.Windows.Forms.Label lblSmsIzniNokta;
    private System.Windows.Forms.Label lblSmsIzniDeger;
    private System.Windows.Forms.Label lblNotBaslik;
    private System.Windows.Forms.Label lblNotNokta;
    private System.Windows.Forms.Label lblNotDeger;
    private System.Windows.Forms.Label lblTabHayvanlar;
    private System.Windows.Forms.Label lblTabZiyaretler;
    private System.Windows.Forms.Label lblTabMesaj;
    private System.Windows.Forms.Panel pnlSekmeCizgi;
    private System.Windows.Forms.FlowLayoutPanel flpHayvanlar;
    private System.Windows.Forms.Button btnHayvanEkle;
    private System.Windows.Forms.DataGridView dgvZiyaretler;
    private System.Windows.Forms.Label lblMesajYok;
        private RadiusButton YeniSahipBtn;
    }
}