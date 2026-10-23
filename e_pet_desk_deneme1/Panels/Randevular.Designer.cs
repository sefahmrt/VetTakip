namespace e_pet_desk_deneme1
{
    partial class Randevular
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
            this.randevuTakvimi1 = new e_pet_desk_deneme1.RandevuTakvimi();
            this.SuspendLayout();
            // 
            // randevuTakvimi1
            // 
            this.randevuTakvimi1.BackColor = System.Drawing.Color.White;
            this.randevuTakvimi1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.randevuTakvimi1.Location = new System.Drawing.Point(0, 3);
            this.randevuTakvimi1.Name = "randevuTakvimi1";
            this.randevuTakvimi1.Size = new System.Drawing.Size(1069, 586);
            this.randevuTakvimi1.TabIndex = 0;
            this.randevuTakvimi1.Text = "randevuTakvimi1";
            // 
            // Randevular
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.randevuTakvimi1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Randevular";
            this.Size = new System.Drawing.Size(1072, 592);
            this.ResumeLayout(false);

        }

        #endregion

        private RandevuTakvimi randevuTakvimi1;
    }
}
