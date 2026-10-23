namespace e_pet_desk_deneme1
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
            this.flowPanelSahipler = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // flowPanelSahipler
            // 
            this.flowPanelSahipler.AutoScroll = true;
            this.flowPanelSahipler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowPanelSahipler.Location = new System.Drawing.Point(0, 0);
            this.flowPanelSahipler.Name = "flowPanelSahipler";
            this.flowPanelSahipler.Size = new System.Drawing.Size(1046, 563);
            this.flowPanelSahipler.TabIndex = 0;
            // 
            // SahiplerPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowPanelSahipler);
            this.Name = "SahiplerPanel";
            this.Size = new System.Drawing.Size(1046, 563);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.FlowLayoutPanel flowPanelSahipler;
    }
}
