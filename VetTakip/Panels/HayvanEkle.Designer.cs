using System.Windows.Controls;

namespace VetTakip
{
  partial class HayvanEkle
  {
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HayvanEkle));
            this.chkKisir = new System.Windows.Forms.CheckBox();
            this.chkAgresif = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtAd = new RadiusTextBox();
            this.cmbTur = new VetTakip.RadiusComboBox();
            this.cmbIrk = new VetTakip.RadiusComboBox();
            this.cmbCinsiyet = new VetTakip.RadiusComboBox();
            this.dtpDogumTarihi = new VetTakip.RadiusDateTimePicker();
            this.txtRenk = new RadiusTextBox();
            this.txtMikrocip = new RadiusTextBox();
            this.btnIptal = new RadiusButton();
            this.btnKaydet = new RadiusButton();
            this.SuspendLayout();
            // 
            // chkKisir
            // 
            this.chkKisir.AutoSize = true;
            this.chkKisir.Location = new System.Drawing.Point(140, 310);
            this.chkKisir.Margin = new System.Windows.Forms.Padding(0);
            this.chkKisir.Name = "chkKisir";
            this.chkKisir.Size = new System.Drawing.Size(56, 25);
            this.chkKisir.TabIndex = 14;
            this.chkKisir.Text = "Kısır";
            // 
            // chkAgresif
            // 
            this.chkAgresif.AutoSize = true;
            this.chkAgresif.Location = new System.Drawing.Point(240, 310);
            this.chkAgresif.Margin = new System.Windows.Forms.Padding(0);
            this.chkAgresif.Name = "chkAgresif";
            this.chkAgresif.Size = new System.Drawing.Size(76, 25);
            this.chkAgresif.TabIndex = 15;
            this.chkAgresif.Text = "Agresif";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 33);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ad*";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 73);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tür*";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 113);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 21);
            this.label3.TabIndex = 4;
            this.label3.Text = "Irk";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 153);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 21);
            this.label4.TabIndex = 6;
            this.label4.Text = "Cinsiyet*";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(34, 193);
            this.label5.Margin = new System.Windows.Forms.Padding(0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 21);
            this.label5.TabIndex = 8;
            this.label5.Text = "Doğum Tarihi";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(34, 233);
            this.label6.Margin = new System.Windows.Forms.Padding(0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 21);
            this.label6.TabIndex = 10;
            this.label6.Text = "Renk";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(34, 273);
            this.label7.Margin = new System.Windows.Forms.Padding(0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 21);
            this.label7.TabIndex = 12;
            this.label7.Text = "Mikroçip No";
            // 
            // txtAd
            // 
            this.txtAd.BackColor = System.Drawing.Color.White;
            this.txtAd.BorderColor = System.Drawing.Color.DimGray;
            this.txtAd.BorderRadius = 8;
            this.txtAd.BorderSize = 1;
            this.txtAd.Location = new System.Drawing.Point(140, 25);
            this.txtAd.Margin = new System.Windows.Forms.Padding(0);
            this.txtAd.Multiline = false;
            this.txtAd.Name = "txtAd";
            this.txtAd.Padding = new System.Windows.Forms.Padding(10, 8, 10, 10);
            this.txtAd.PasswordChar = '\0';
            this.txtAd.PlaceholderText = "Hayvan Adı";
            this.txtAd.Size = new System.Drawing.Size(200, 32);
            this.txtAd.TabIndex = 1;
            this.txtAd.UseSystemPasswordChar = false;
            // 
            // cmbTur
            // 
            this.cmbTur.BackColor = System.Drawing.Color.White;
            this.cmbTur.BorderColor = System.Drawing.Color.DimGray;
            this.cmbTur.BorderRadius = 8;
            this.cmbTur.BorderSize = 1;
            this.cmbTur.DataSource = null;
            this.cmbTur.DisplayMember = "";
            this.cmbTur.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTur.Location = new System.Drawing.Point(140, 65);
            this.cmbTur.Margin = new System.Windows.Forms.Padding(0);
            this.cmbTur.Name = "cmbTur";
            this.cmbTur.Padding = new System.Windows.Forms.Padding(10, 8, 10, 10);
            this.cmbTur.SelectedIndex = -1;
            this.cmbTur.SelectedItem = null;
            this.cmbTur.SelectedValue = null;
            this.cmbTur.Size = new System.Drawing.Size(200, 32);
            this.cmbTur.TabIndex = 3;
            this.cmbTur.ValueMember = "";
            this.cmbTur.SelectedIndexChanged += new System.EventHandler(this.cmbTur_SelectedIndexChanged);
            // 
            // cmbIrk
            // 
            this.cmbIrk.BackColor = System.Drawing.Color.White;
            this.cmbIrk.BorderColor = System.Drawing.Color.DimGray;
            this.cmbIrk.BorderRadius = 8;
            this.cmbIrk.BorderSize = 1;
            this.cmbIrk.DataSource = null;
            this.cmbIrk.DisplayMember = "";
            this.cmbIrk.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIrk.Location = new System.Drawing.Point(140, 105);
            this.cmbIrk.Margin = new System.Windows.Forms.Padding(0);
            this.cmbIrk.Name = "cmbIrk";
            this.cmbIrk.Padding = new System.Windows.Forms.Padding(10, 8, 10, 10);
            this.cmbIrk.SelectedIndex = -1;
            this.cmbIrk.SelectedItem = null;
            this.cmbIrk.SelectedValue = null;
            this.cmbIrk.Size = new System.Drawing.Size(200, 32);
            this.cmbIrk.TabIndex = 5;
            this.cmbIrk.ValueMember = "";
            // 
            // cmbCinsiyet
            // 
            this.cmbCinsiyet.BackColor = System.Drawing.Color.White;
            this.cmbCinsiyet.BorderColor = System.Drawing.Color.DimGray;
            this.cmbCinsiyet.BorderRadius = 8;
            this.cmbCinsiyet.BorderSize = 1;
            this.cmbCinsiyet.DataSource = null;
            this.cmbCinsiyet.DisplayMember = "";
            this.cmbCinsiyet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCinsiyet.Location = new System.Drawing.Point(140, 145);
            this.cmbCinsiyet.Margin = new System.Windows.Forms.Padding(0);
            this.cmbCinsiyet.Name = "cmbCinsiyet";
            this.cmbCinsiyet.Padding = new System.Windows.Forms.Padding(10, 8, 10, 10);
            this.cmbCinsiyet.SelectedIndex = -1;
            this.cmbCinsiyet.SelectedItem = null;
            this.cmbCinsiyet.SelectedValue = null;
            this.cmbCinsiyet.Size = new System.Drawing.Size(200, 32);
            this.cmbCinsiyet.TabIndex = 7;
            this.cmbCinsiyet.ValueMember = "";
            // 
            // dtpDogumTarihi
            // 
            this.dtpDogumTarihi.BorderColor = System.Drawing.Color.DimGray;
            this.dtpDogumTarihi.BorderRadius = 8;
            this.dtpDogumTarihi.BorderSize = 1;
            this.dtpDogumTarihi.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dtpDogumTarihi.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDogumTarihi.Location = new System.Drawing.Point(140, 185);
            this.dtpDogumTarihi.Margin = new System.Windows.Forms.Padding(0);
            this.dtpDogumTarihi.MinimumSize = new System.Drawing.Size(0, 32);
            this.dtpDogumTarihi.Name = "dtpDogumTarihi";
            this.dtpDogumTarihi.Size = new System.Drawing.Size(200, 32);
            this.dtpDogumTarihi.TabIndex = 9;
            // 
            // txtRenk
            // 
            this.txtRenk.BackColor = System.Drawing.Color.White;
            this.txtRenk.BorderColor = System.Drawing.Color.DimGray;
            this.txtRenk.BorderRadius = 8;
            this.txtRenk.BorderSize = 1;
            this.txtRenk.Location = new System.Drawing.Point(140, 225);
            this.txtRenk.Margin = new System.Windows.Forms.Padding(0);
            this.txtRenk.Multiline = false;
            this.txtRenk.Name = "txtRenk";
            this.txtRenk.Padding = new System.Windows.Forms.Padding(10, 8, 10, 10);
            this.txtRenk.PasswordChar = '\0';
            this.txtRenk.PlaceholderText = "Örn: Sarman";
            this.txtRenk.Size = new System.Drawing.Size(200, 32);
            this.txtRenk.TabIndex = 11;
            this.txtRenk.UseSystemPasswordChar = false;
            // 
            // txtMikrocip
            // 
            this.txtMikrocip.BackColor = System.Drawing.Color.White;
            this.txtMikrocip.BorderColor = System.Drawing.Color.DimGray;
            this.txtMikrocip.BorderRadius = 8;
            this.txtMikrocip.BorderSize = 1;
            this.txtMikrocip.Location = new System.Drawing.Point(140, 265);
            this.txtMikrocip.Margin = new System.Windows.Forms.Padding(0);
            this.txtMikrocip.Multiline = false;
            this.txtMikrocip.Name = "txtMikrocip";
            this.txtMikrocip.Padding = new System.Windows.Forms.Padding(10, 8, 10, 10);
            this.txtMikrocip.PasswordChar = '\0';
            this.txtMikrocip.PlaceholderText = "15 Haneli Çip No";
            this.txtMikrocip.Size = new System.Drawing.Size(200, 32);
            this.txtMikrocip.TabIndex = 13;
            this.txtMikrocip.UseSystemPasswordChar = false;
            // 
            // btnIptal
            // 
            this.btnIptal.BackColor = System.Drawing.Color.Transparent;
            this.btnIptal.BorderColor = System.Drawing.Color.DarkGray;
            this.btnIptal.BorderRadius = 10;
            this.btnIptal.BorderSize = 1;
            this.btnIptal.ButtonColor = System.Drawing.Color.White;
            this.btnIptal.ButtonIcon = ((System.Drawing.Image)(resources.GetObject("btnIptal.ButtonIcon")));
            this.btnIptal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIptal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnIptal.HoverIcon = null;
            this.btnIptal.IconLocation = IconPosition.Left;
            this.btnIptal.IsActive = false;
            this.btnIptal.Location = new System.Drawing.Point(56, 358);
            this.btnIptal.Margin = new System.Windows.Forms.Padding(0);
            this.btnIptal.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.btnIptal.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.btnIptal.Name = "btnIptal";
            this.btnIptal.Size = new System.Drawing.Size(100, 40);
            this.btnIptal.TabIndex = 16;
            this.btnIptal.Text = "İptal";
            this.btnIptal.TextAlign = CustomTextAlign.Center;
            this.btnIptal.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(118)))), ((int)(((byte)(110)))));
            this.btnIptal.Click += new System.EventHandler(this.btnIptal_Click);
            // 
            // btnKaydet
            // 
            this.btnKaydet.BackColor = System.Drawing.Color.Transparent;
            this.btnKaydet.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(79)))), ((int)(((byte)(74)))));
            this.btnKaydet.BorderRadius = 10;
            this.btnKaydet.BorderSize = 1;
            this.btnKaydet.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(110)))), ((int)(((byte)(110)))));
            this.btnKaydet.ButtonIcon = ((System.Drawing.Image)(resources.GetObject("btnKaydet.ButtonIcon")));
            this.btnKaydet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKaydet.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKaydet.HoverIcon = null;
            this.btnKaydet.IconLocation = IconPosition.Left;
            this.btnKaydet.IsActive = false;
            this.btnKaydet.Location = new System.Drawing.Point(166, 358);
            this.btnKaydet.Margin = new System.Windows.Forms.Padding(0);
            this.btnKaydet.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.btnKaydet.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(150, 40);
            this.btnKaydet.TabIndex = 17;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.TextAlign = CustomTextAlign.Center;
            this.btnKaydet.TextColor = System.Drawing.Color.White;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // HayvanEkle
            // 
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(370, 420);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtAd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbTur);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbIrk);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbCinsiyet);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtpDogumTarihi);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtRenk);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtMikrocip);
            this.Controls.Add(this.chkKisir);
            this.Controls.Add(this.chkAgresif);
            this.Controls.Add(this.btnIptal);
            this.Controls.Add(this.btnKaydet);
            this.Font = new System.Drawing.Font("Inter", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HayvanEkle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Hayvan Ekle";
            this.Load += new System.EventHandler(this.HayvanEkle_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    private RadiusTextBox txtAd;
    private RadiusComboBox cmbTur;
    private RadiusComboBox cmbIrk;
    private RadiusComboBox cmbCinsiyet;
    private RadiusDateTimePicker dtpDogumTarihi;
    private RadiusTextBox txtRenk;
    private RadiusTextBox txtMikrocip;
    private System.Windows.Forms.CheckBox chkKisir;
    private System.Windows.Forms.CheckBox chkAgresif;
    private RadiusButton btnKaydet;
    private RadiusButton btnIptal;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label label7;
  }
}