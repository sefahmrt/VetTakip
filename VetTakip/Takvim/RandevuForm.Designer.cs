namespace VetTakip
{
  partial class RandevuForm
  {
    /// <summary>
    /// Gerekli tasarımcı değişkeni.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Kullanılan tüm kaynakları temizleyin.
    /// </summary>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Tasarımcısı üretimi kod

    /// <summary>
    /// Tasarımcı desteği için gerekli metot - bu metodun
    /// içeriğini kod düzenleyici ile değiştirmeyin.
    /// </summary>
    private void InitializeComponent()
    {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RandevuForm));
            this.lblBaslik = new System.Windows.Forms.Label();
            this.lblHasta = new System.Windows.Forms.Label();
            this.cmbHasta = new VetTakip.RadiusComboBox();
            this.lblHekim = new System.Windows.Forms.Label();
            this.cmbHekim = new VetTakip.RadiusComboBox();
            this.lblTarih = new System.Windows.Forms.Label();
            this.dtpTarih = new VetTakip.RadiusDateTimePicker();
            this.lblBaslangic = new System.Windows.Forms.Label();
            this.dtpBaslangic = new VetTakip.RadiusDateTimePicker();
            this.lblSure = new System.Windows.Forms.Label();
            this.cmbSure = new VetTakip.RadiusComboBox();
            this.lblIslem = new System.Windows.Forms.Label();
            this.txtIslem = new RadiusTextBox();
            this.lblHata = new System.Windows.Forms.Label();
            this.btnIptal = new RadiusButton();
            this.btnKaydet = new RadiusButton();
            this.SuspendLayout();
            // 
            // lblBaslik
            // 
            this.lblBaslik.Font = new System.Drawing.Font("Segoe UI Semibold", 15F);
            this.lblBaslik.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(118)))), ((int)(((byte)(110)))));
            this.lblBaslik.Location = new System.Drawing.Point(22, 13);
            this.lblBaslik.Name = "lblBaslik";
            this.lblBaslik.Size = new System.Drawing.Size(399, 34);
            this.lblBaslik.TabIndex = 0;
            this.lblBaslik.Text = "Yeni Randevu";
            // 
            // lblHasta
            // 
            this.lblHasta.ForeColor = System.Drawing.Color.Black;
            this.lblHasta.Location = new System.Drawing.Point(19, 47);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Size = new System.Drawing.Size(390, 26);
            this.lblHasta.TabIndex = 1;
            this.lblHasta.Text = "Hasta (Sahip)";
            this.lblHasta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbHasta
            // 
            this.cmbHasta.BackColor = System.Drawing.Color.White;
            this.cmbHasta.BorderColor = System.Drawing.Color.Gray;
            this.cmbHasta.BorderRadius = 12;
            this.cmbHasta.BorderSize = 1;
            this.cmbHasta.DataSource = null;
            this.cmbHasta.DisplayMember = "";
            this.cmbHasta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHasta.Location = new System.Drawing.Point(23, 76);
            this.cmbHasta.Name = "cmbHasta";
            this.cmbHasta.Padding = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.cmbHasta.SelectedIndex = -1;
            this.cmbHasta.SelectedItem = null;
            this.cmbHasta.SelectedValue = null;
            this.cmbHasta.Size = new System.Drawing.Size(390, 32);
            this.cmbHasta.TabIndex = 2;
            this.cmbHasta.ValueMember = "";
            // 
            // lblHekim
            // 
            this.lblHekim.ForeColor = System.Drawing.Color.Black;
            this.lblHekim.Location = new System.Drawing.Point(19, 110);
            this.lblHekim.Name = "lblHekim";
            this.lblHekim.Size = new System.Drawing.Size(390, 26);
            this.lblHekim.TabIndex = 3;
            this.lblHekim.Text = "Hekim";
            this.lblHekim.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbHekim
            // 
            this.cmbHekim.BackColor = System.Drawing.Color.White;
            this.cmbHekim.BorderColor = System.Drawing.Color.Gray;
            this.cmbHekim.BorderRadius = 12;
            this.cmbHekim.BorderSize = 1;
            this.cmbHekim.DataSource = null;
            this.cmbHekim.DisplayMember = "";
            this.cmbHekim.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHekim.Location = new System.Drawing.Point(23, 139);
            this.cmbHekim.Name = "cmbHekim";
            this.cmbHekim.Padding = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.cmbHekim.SelectedIndex = -1;
            this.cmbHekim.SelectedItem = null;
            this.cmbHekim.SelectedValue = null;
            this.cmbHekim.Size = new System.Drawing.Size(390, 32);
            this.cmbHekim.TabIndex = 4;
            this.cmbHekim.ValueMember = "";
            // 
            // lblTarih
            // 
            this.lblTarih.ForeColor = System.Drawing.Color.Black;
            this.lblTarih.Location = new System.Drawing.Point(19, 173);
            this.lblTarih.Name = "lblTarih";
            this.lblTarih.Size = new System.Drawing.Size(390, 26);
            this.lblTarih.TabIndex = 5;
            this.lblTarih.Text = "Tarih";
            this.lblTarih.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpTarih
            // 
            this.dtpTarih.BorderColor = System.Drawing.Color.Gray;
            this.dtpTarih.BorderRadius = 12;
            this.dtpTarih.BorderSize = 1;
            this.dtpTarih.CustomFormat = "dd MMM yyyy, ddd";
            this.dtpTarih.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpTarih.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTarih.Location = new System.Drawing.Point(23, 202);
            this.dtpTarih.MinimumSize = new System.Drawing.Size(4, 32);
            this.dtpTarih.Name = "dtpTarih";
            this.dtpTarih.Size = new System.Drawing.Size(390, 32);
            this.dtpTarih.TabIndex = 6;
            // 
            // lblBaslangic
            // 
            this.lblBaslangic.ForeColor = System.Drawing.Color.Black;
            this.lblBaslangic.Location = new System.Drawing.Point(19, 234);
            this.lblBaslangic.Name = "lblBaslangic";
            this.lblBaslangic.Size = new System.Drawing.Size(390, 26);
            this.lblBaslangic.TabIndex = 7;
            this.lblBaslangic.Text = "Başlangıç saati";
            this.lblBaslangic.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpBaslangic
            // 
            this.dtpBaslangic.BorderColor = System.Drawing.Color.Gray;
            this.dtpBaslangic.BorderRadius = 12;
            this.dtpBaslangic.BorderSize = 1;
            this.dtpBaslangic.CustomFormat = "HH:mm";
            this.dtpBaslangic.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dtpBaslangic.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBaslangic.Location = new System.Drawing.Point(23, 263);
            this.dtpBaslangic.MinimumSize = new System.Drawing.Size(4, 32);
            this.dtpBaslangic.Name = "dtpBaslangic";
            this.dtpBaslangic.ShowUpDown = true;
            this.dtpBaslangic.Size = new System.Drawing.Size(390, 32);
            this.dtpBaslangic.TabIndex = 8;
            // 
            // lblSure
            // 
            this.lblSure.ForeColor = System.Drawing.Color.Black;
            this.lblSure.Location = new System.Drawing.Point(19, 295);
            this.lblSure.Name = "lblSure";
            this.lblSure.Size = new System.Drawing.Size(390, 26);
            this.lblSure.TabIndex = 9;
            this.lblSure.Text = "Süre";
            this.lblSure.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbSure
            // 
            this.cmbSure.BackColor = System.Drawing.Color.White;
            this.cmbSure.BorderColor = System.Drawing.Color.Gray;
            this.cmbSure.BorderRadius = 12;
            this.cmbSure.BorderSize = 1;
            this.cmbSure.DataSource = null;
            this.cmbSure.DisplayMember = "";
            this.cmbSure.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSure.Items.AddRange(new object[] {
            "15 dk",
            "30 dk",
            "45 dk",
            "60 dk",
            "90 dk",
            "120 dk"});
            this.cmbSure.Location = new System.Drawing.Point(23, 324);
            this.cmbSure.Name = "cmbSure";
            this.cmbSure.Padding = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.cmbSure.SelectedIndex = -1;
            this.cmbSure.SelectedItem = null;
            this.cmbSure.SelectedValue = null;
            this.cmbSure.Size = new System.Drawing.Size(390, 32);
            this.cmbSure.TabIndex = 10;
            this.cmbSure.ValueMember = "";
            // 
            // lblIslem
            // 
            this.lblIslem.ForeColor = System.Drawing.Color.Black;
            this.lblIslem.Location = new System.Drawing.Point(19, 358);
            this.lblIslem.Name = "lblIslem";
            this.lblIslem.Size = new System.Drawing.Size(390, 26);
            this.lblIslem.TabIndex = 11;
            this.lblIslem.Text = "İşlem / Not";
            this.lblIslem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtIslem
            // 
            this.txtIslem.BackColor = System.Drawing.Color.White;
            this.txtIslem.BorderColor = System.Drawing.Color.Gray;
            this.txtIslem.BorderRadius = 12;
            this.txtIslem.BorderSize = 1;
            this.txtIslem.Location = new System.Drawing.Point(23, 387);
            this.txtIslem.MaxLength = 32767;
            this.txtIslem.Multiline = false;
            this.txtIslem.Name = "txtIslem";
            this.txtIslem.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtIslem.PasswordChar = '\0';
            this.txtIslem.PlaceholderText = "";
            this.txtIslem.Size = new System.Drawing.Size(390, 32);
            this.txtIslem.TabIndex = 12;
            this.txtIslem.UseSystemPasswordChar = false;
            // 
            // lblHata
            // 
            this.lblHata.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.lblHata.Location = new System.Drawing.Point(22, 422);
            this.lblHata.Name = "lblHata";
            this.lblHata.Size = new System.Drawing.Size(395, 29);
            this.lblHata.TabIndex = 13;
            // 
            // btnIptal
            // 
            this.btnIptal.BackColor = System.Drawing.Color.Transparent;
            this.btnIptal.BorderColor = System.Drawing.Color.LightGray;
            this.btnIptal.BorderRadius = 5;
            this.btnIptal.BorderSize = 1;
            this.btnIptal.ButtonColor = System.Drawing.Color.White;
            this.btnIptal.ButtonIcon = ((System.Drawing.Image)(resources.GetObject("btnIptal.ButtonIcon")));
            this.btnIptal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIptal.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.btnIptal.DisabledTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.btnIptal.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnIptal.HoverIcon = ((System.Drawing.Image)(resources.GetObject("btnIptal.HoverIcon")));
            this.btnIptal.IconLocation = IconPosition.Left;
            this.btnIptal.IsActive = false;
            this.btnIptal.Location = new System.Drawing.Point(151, 446);
            this.btnIptal.MouseDownBackColor = System.Drawing.Color.Red;
            this.btnIptal.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(118)))), ((int)(((byte)(110)))));
            this.btnIptal.Name = "btnIptal";
            this.btnIptal.Size = new System.Drawing.Size(120, 40);
            this.btnIptal.TabIndex = 16;
            this.btnIptal.Text = "İptal";
            this.btnIptal.TextAlign = CustomTextAlign.Center;
            this.btnIptal.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(118)))), ((int)(((byte)(110)))));
            this.btnIptal.Click += new System.EventHandler(this.btnIptal_Click);
            this.btnIptal.MouseEnter += new System.EventHandler(this.radiusButton2_MouseEnter);
            this.btnIptal.MouseLeave += new System.EventHandler(this.radiusButton2_MouseLeave);
            // 
            // btnKaydet
            // 
            this.btnKaydet.BackColor = System.Drawing.Color.Transparent;
            this.btnKaydet.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(79)))), ((int)(((byte)(74)))));
            this.btnKaydet.BorderRadius = 5;
            this.btnKaydet.BorderSize = 0;
            this.btnKaydet.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(118)))), ((int)(((byte)(110)))));
            this.btnKaydet.ButtonIcon = ((System.Drawing.Image)(resources.GetObject("btnKaydet.ButtonIcon")));
            this.btnKaydet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKaydet.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.btnKaydet.DisabledTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.btnKaydet.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnKaydet.HoverIcon = null;
            this.btnKaydet.IconLocation = IconPosition.Left;
            this.btnKaydet.IsActive = false;
            this.btnKaydet.Location = new System.Drawing.Point(277, 446);
            this.btnKaydet.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.btnKaydet.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(118)))), ((int)(((byte)(110)))));
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(140, 40);
            this.btnKaydet.TabIndex = 16;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.TextAlign = CustomTextAlign.Center;
            this.btnKaydet.TextColor = System.Drawing.Color.White;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            this.btnKaydet.MouseEnter += new System.EventHandler(this.radiusButton1_MouseEnter);
            this.btnKaydet.MouseLeave += new System.EventHandler(this.radiusButton1_MouseLeave);
            // 
            // RandevuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(440, 504);
            this.Controls.Add(this.btnIptal);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.lblHata);
            this.Controls.Add(this.txtIslem);
            this.Controls.Add(this.lblIslem);
            this.Controls.Add(this.cmbSure);
            this.Controls.Add(this.lblSure);
            this.Controls.Add(this.dtpBaslangic);
            this.Controls.Add(this.lblBaslangic);
            this.Controls.Add(this.dtpTarih);
            this.Controls.Add(this.lblTarih);
            this.Controls.Add(this.cmbHekim);
            this.Controls.Add(this.lblHekim);
            this.Controls.Add(this.cmbHasta);
            this.Controls.Add(this.lblHasta);
            this.Controls.Add(this.lblBaslik);
            this.Font = new System.Drawing.Font("Inter", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RandevuForm";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Randevu Oluştur";
            this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Label lblBaslik;
    private System.Windows.Forms.Label lblHasta;
    private VetTakip.RadiusComboBox cmbHasta;
    private System.Windows.Forms.Label lblHekim;
    private VetTakip.RadiusComboBox cmbHekim;
    private System.Windows.Forms.Label lblTarih;
    private VetTakip.RadiusDateTimePicker dtpTarih;
    private System.Windows.Forms.Label lblBaslangic;
    private VetTakip.RadiusDateTimePicker dtpBaslangic;
    private System.Windows.Forms.Label lblSure;
    private VetTakip.RadiusComboBox cmbSure;
    private System.Windows.Forms.Label lblIslem;
    private RadiusTextBox txtIslem;
    private System.Windows.Forms.Label lblHata;
    private RadiusButton btnKaydet;
    private RadiusButton btnIptal;
  }
}