namespace VetTakip
{
    partial class AnaPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnaPanel));
            this.SidePanel = new System.Windows.Forms.Panel();
            this.AltPanel2 = new System.Windows.Forms.Panel();
            this.AltPanel1 = new System.Windows.Forms.Panel();
            this.OrtaPanel = new System.Windows.Forms.Panel();
            this.TakvimeGit = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.UstPanel4 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.UstPanel3 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.UstPanel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.UstPanel1 = new System.Windows.Forms.Panel();
            this.BgnkRandevulLbl = new System.Windows.Forms.Label();
            this.TamamlananRandevuLbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.sahiplerPanel1 = new VetTakip.SahiplerPanel();
            this.AltPanel2.SuspendLayout();
            this.OrtaPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.UstPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.UstPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.UstPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.UstPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // SidePanel
            // 
            this.SidePanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SidePanel.BackgroundImage")));
            this.SidePanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.SidePanel.Location = new System.Drawing.Point(1262, 222);
            this.SidePanel.Margin = new System.Windows.Forms.Padding(0, 0, 36, 0);
            this.SidePanel.Name = "SidePanel";
            this.SidePanel.Padding = new System.Windows.Forms.Padding(10);
            this.SidePanel.Size = new System.Drawing.Size(299, 669);
            this.SidePanel.TabIndex = 7;
            // 
            // AltPanel2
            // 
            this.AltPanel2.AutoScroll = true;
            this.AltPanel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("AltPanel2.BackgroundImage")));
            this.AltPanel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.AltPanel2.Controls.Add(this.sahiplerPanel1);
            this.AltPanel2.Location = new System.Drawing.Point(661, 574);
            this.AltPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.AltPanel2.Name = "AltPanel2";
            this.AltPanel2.Padding = new System.Windows.Forms.Padding(10);
            this.AltPanel2.Size = new System.Drawing.Size(550, 310);
            this.AltPanel2.TabIndex = 6;
            // 
            // AltPanel1
            // 
            this.AltPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("AltPanel1.BackgroundImage")));
            this.AltPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.AltPanel1.Location = new System.Drawing.Point(36, 574);
            this.AltPanel1.Margin = new System.Windows.Forms.Padding(36, 0, 0, 0);
            this.AltPanel1.Name = "AltPanel1";
            this.AltPanel1.Padding = new System.Windows.Forms.Padding(10);
            this.AltPanel1.Size = new System.Drawing.Size(550, 310);
            this.AltPanel1.TabIndex = 6;
            // 
            // OrtaPanel
            // 
            this.OrtaPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("OrtaPanel.BackgroundImage")));
            this.OrtaPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.OrtaPanel.Controls.Add(this.TakvimeGit);
            this.OrtaPanel.Controls.Add(this.label11);
            this.OrtaPanel.Controls.Add(this.dataGridView1);
            this.OrtaPanel.Location = new System.Drawing.Point(36, 222);
            this.OrtaPanel.Margin = new System.Windows.Forms.Padding(36, 0, 0, 50);
            this.OrtaPanel.Name = "OrtaPanel";
            this.OrtaPanel.Padding = new System.Windows.Forms.Padding(0, 40, 0, 10);
            this.OrtaPanel.Size = new System.Drawing.Size(1175, 302);
            this.OrtaPanel.TabIndex = 5;
            // 
            // TakvimeGit
            // 
            this.TakvimeGit.BackColor = System.Drawing.Color.Transparent;
            this.TakvimeGit.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.TakvimeGit.FlatAppearance.BorderSize = 0;
            this.TakvimeGit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.TakvimeGit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.TakvimeGit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TakvimeGit.Font = new System.Drawing.Font("Inter", 14F);
            this.TakvimeGit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(118)))), ((int)(((byte)(110)))));
            this.TakvimeGit.Location = new System.Drawing.Point(982, 0);
            this.TakvimeGit.Margin = new System.Windows.Forms.Padding(0);
            this.TakvimeGit.Name = "TakvimeGit";
            this.TakvimeGit.Size = new System.Drawing.Size(188, 40);
            this.TakvimeGit.TabIndex = 2;
            this.TakvimeGit.Text = "Takvime Git >";
            this.TakvimeGit.UseVisualStyleBackColor = false;
            this.TakvimeGit.Click += new System.EventHandler(this.TakvimeGit_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Location = new System.Drawing.Point(19, 6);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(125, 30);
            this.label11.TabIndex = 1;
            this.label11.Text = "Randevular";
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 40);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1175, 252);
            this.dataGridView1.TabIndex = 0;
            // 
            // UstPanel4
            // 
            this.UstPanel4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("UstPanel4.BackgroundImage")));
            this.UstPanel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.UstPanel4.Controls.Add(this.label10);
            this.UstPanel4.Controls.Add(this.pictureBox4);
            this.UstPanel4.Controls.Add(this.label8);
            this.UstPanel4.Controls.Add(this.label9);
            this.UstPanel4.Location = new System.Drawing.Point(1230, 35);
            this.UstPanel4.Margin = new System.Windows.Forms.Padding(0, 0, 36, 50);
            this.UstPanel4.Name = "UstPanel4";
            this.UstPanel4.Padding = new System.Windows.Forms.Padding(10);
            this.UstPanel4.Size = new System.Drawing.Size(331, 137);
            this.UstPanel4.TabIndex = 4;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Inter", 20F);
            this.label10.Location = new System.Drawing.Point(76, 50);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 39);
            this.label10.TabIndex = 2;
            this.label10.Text = "101";
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox4.BackgroundImage")));
            this.pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(13, 20);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(57, 53);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 0;
            this.pictureBox4.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Inter", 15F);
            this.label8.ForeColor = System.Drawing.Color.DimGray;
            this.label8.Location = new System.Drawing.Point(76, 89);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 28);
            this.label8.TabIndex = 1;
            this.label8.Text = "Yeterli";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.ForeColor = System.Drawing.Color.DimGray;
            this.label9.Location = new System.Drawing.Point(76, 20);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(196, 30);
            this.label9.TabIndex = 1;
            this.label9.Text = "Kalan Mesaj Hakkı";
            // 
            // UstPanel3
            // 
            this.UstPanel3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("UstPanel3.BackgroundImage")));
            this.UstPanel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.UstPanel3.Controls.Add(this.label7);
            this.UstPanel3.Controls.Add(this.pictureBox3);
            this.UstPanel3.Controls.Add(this.label5);
            this.UstPanel3.Controls.Add(this.label6);
            this.UstPanel3.Location = new System.Drawing.Point(832, 35);
            this.UstPanel3.Margin = new System.Windows.Forms.Padding(0, 0, 75, 50);
            this.UstPanel3.Name = "UstPanel3";
            this.UstPanel3.Padding = new System.Windows.Forms.Padding(10);
            this.UstPanel3.Size = new System.Drawing.Size(331, 137);
            this.UstPanel3.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Inter", 20F);
            this.label7.Location = new System.Drawing.Point(76, 50);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 39);
            this.label7.TabIndex = 2;
            this.label7.Text = "2/8";
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox3.BackgroundImage")));
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(13, 20);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(57, 53);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 0;
            this.pictureBox3.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.Color.DimGray;
            this.label5.Location = new System.Drawing.Point(76, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 30);
            this.label5.TabIndex = 1;
            this.label5.Text = "Yatan Hasta";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Inter", 15F);
            this.label6.ForeColor = System.Drawing.Color.DimGray;
            this.label6.Location = new System.Drawing.Point(76, 89);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 28);
            this.label6.TabIndex = 1;
            this.label6.Text = "Kafes Dolu";
            // 
            // UstPanel2
            // 
            this.UstPanel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("UstPanel2.BackgroundImage")));
            this.UstPanel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.UstPanel2.Controls.Add(this.label4);
            this.UstPanel2.Controls.Add(this.pictureBox2);
            this.UstPanel2.Controls.Add(this.label3);
            this.UstPanel2.Controls.Add(this.label2);
            this.UstPanel2.Location = new System.Drawing.Point(434, 35);
            this.UstPanel2.Margin = new System.Windows.Forms.Padding(0, 0, 75, 50);
            this.UstPanel2.Name = "UstPanel2";
            this.UstPanel2.Padding = new System.Windows.Forms.Padding(10);
            this.UstPanel2.Size = new System.Drawing.Size(331, 137);
            this.UstPanel2.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Inter", 20F);
            this.label4.Location = new System.Drawing.Point(76, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 39);
            this.label4.TabIndex = 2;
            this.label4.Text = "6";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(13, 20);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(57, 53);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Inter", 15F);
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(76, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 28);
            this.label3.TabIndex = 1;
            this.label3.Text = "Boncuk * 12dk";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(76, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(208, 30);
            this.label2.TabIndex = 1;
            this.label2.Text = "Bekleme Salonunda";
            // 
            // UstPanel1
            // 
            this.UstPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("UstPanel1.BackgroundImage")));
            this.UstPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.UstPanel1.Controls.Add(this.BgnkRandevulLbl);
            this.UstPanel1.Controls.Add(this.TamamlananRandevuLbl);
            this.UstPanel1.Controls.Add(this.label1);
            this.UstPanel1.Controls.Add(this.pictureBox1);
            this.UstPanel1.Location = new System.Drawing.Point(36, 35);
            this.UstPanel1.Margin = new System.Windows.Forms.Padding(36, 0, 75, 50);
            this.UstPanel1.Name = "UstPanel1";
            this.UstPanel1.Padding = new System.Windows.Forms.Padding(10);
            this.UstPanel1.Size = new System.Drawing.Size(331, 137);
            this.UstPanel1.TabIndex = 4;
            // 
            // BgnkRandevulLbl
            // 
            this.BgnkRandevulLbl.AutoSize = true;
            this.BgnkRandevulLbl.BackColor = System.Drawing.Color.Transparent;
            this.BgnkRandevulLbl.Font = new System.Drawing.Font("Inter", 20F);
            this.BgnkRandevulLbl.Location = new System.Drawing.Point(76, 50);
            this.BgnkRandevulLbl.Name = "BgnkRandevulLbl";
            this.BgnkRandevulLbl.Size = new System.Drawing.Size(34, 39);
            this.BgnkRandevulLbl.TabIndex = 2;
            this.BgnkRandevulLbl.Text = "6";
            // 
            // TamamlananRandevuLbl
            // 
            this.TamamlananRandevuLbl.AutoSize = true;
            this.TamamlananRandevuLbl.BackColor = System.Drawing.Color.Transparent;
            this.TamamlananRandevuLbl.Font = new System.Drawing.Font("Inter", 15F);
            this.TamamlananRandevuLbl.ForeColor = System.Drawing.Color.DimGray;
            this.TamamlananRandevuLbl.Location = new System.Drawing.Point(76, 89);
            this.TamamlananRandevuLbl.Name = "TamamlananRandevuLbl";
            this.TamamlananRandevuLbl.Size = new System.Drawing.Size(152, 28);
            this.TamamlananRandevuLbl.TabIndex = 1;
            this.TamamlananRandevuLbl.Text = "1\'i Tamamlandı";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(76, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(218, 30);
            this.label1.TabIndex = 1;
            this.label1.Text = "Bugünkü Randevular";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(13, 20);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(57, 53);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // sahiplerPanel1
            // 
            this.sahiplerPanel1.AutoScroll = true;
            this.sahiplerPanel1.AutoSize = true;
            this.sahiplerPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.sahiplerPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.sahiplerPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sahiplerPanel1.Font = new System.Drawing.Font("Inter", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.sahiplerPanel1.Location = new System.Drawing.Point(10, 10);
            this.sahiplerPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.sahiplerPanel1.Name = "sahiplerPanel1";
            this.sahiplerPanel1.Padding = new System.Windows.Forms.Padding(15, 17, 15, 17);
            this.sahiplerPanel1.Size = new System.Drawing.Size(530, 290);
            this.sahiplerPanel1.TabIndex = 0;
            // 
            // AnaPanel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.Controls.Add(this.SidePanel);
            this.Controls.Add(this.AltPanel2);
            this.Controls.Add(this.AltPanel1);
            this.Controls.Add(this.OrtaPanel);
            this.Controls.Add(this.UstPanel4);
            this.Controls.Add(this.UstPanel3);
            this.Controls.Add(this.UstPanel2);
            this.Controls.Add(this.UstPanel1);
            this.Font = new System.Drawing.Font("Inter", 15.5F);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "AnaPanel";
            this.Size = new System.Drawing.Size(1622, 891);
            this.AltPanel2.ResumeLayout(false);
            this.AltPanel2.PerformLayout();
            this.OrtaPanel.ResumeLayout(false);
            this.OrtaPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.UstPanel4.ResumeLayout(false);
            this.UstPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.UstPanel3.ResumeLayout(false);
            this.UstPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.UstPanel2.ResumeLayout(false);
            this.UstPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.UstPanel1.ResumeLayout(false);
            this.UstPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel UstPanel1;
        private System.Windows.Forms.Panel UstPanel2;
        private System.Windows.Forms.Panel UstPanel3;
        private System.Windows.Forms.Panel OrtaPanel;
        private System.Windows.Forms.Panel AltPanel1;
        private System.Windows.Forms.Panel AltPanel2;
        private System.Windows.Forms.Panel UstPanel4;
        private System.Windows.Forms.Panel SidePanel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label BgnkRandevulLbl;
        private System.Windows.Forms.Label TamamlananRandevuLbl;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button TakvimeGit;
        private SahiplerPanel sahiplerPanel1;
    }
}
