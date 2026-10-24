using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace e_pet_desk_deneme1
{
    public partial class AnaPanel : UserControl
    {
        public AnaPanel()
        {
            InitializeComponent();
            RandevulariListele();
            BugunkuRandevuSayisiniGoster();
            

            // Mevcut tasarım ayarların
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.BackgroundColor = Color.FromArgb(243, 244, 246);
            dataGridView1.GridColor = Color.FromArgb(229, 231, 235);
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.DefaultCellStyle.BackColor = Color.WhiteSmoke;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            dataGridView1.DefaultCellStyle.ForeColor = Color.FromArgb(31, 41, 55);
            dataGridView1.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#d1ffd3");
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(243, 244, 246);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(107, 114, 128);
            dataGridView1.ColumnHeadersHeight = 40;
            dataGridView1.DefaultCellStyle.Font = new Font("Inter", 12F);
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Inter", 15F);
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.ColumnHeadersDefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#DCDCDC"); // Normal arka plan rengiyle aynı yapabilirsiniz
            dataGridView1.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.DimGray; // Normal yazı rengiyle aynı yapabilirsiniz
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#DCDCDC"); // Normal arka plan rengiyle aynı yapabilirsiniz
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.DimGray; // Normal yazı rengiyle aynı yapabilirsiniz
            dataGridView1.ScrollBars = ScrollBars.Both;

            // İkonları ve rozetleri çizecek olayı (Event) bağla
            dataGridView1.CellFormatting += DataGridView1_CellFormatting;
        }

        private void RandevulariListele()
        {
            string baglantiYolu = @"Data Source=vettakip.db;Version=3;";

            // İkonların neye göre seçileceğini bilmek için has.tur AS 'Tür' eklendi
            string sorgu = @"
                SELECT 
                    STRFTIME('%H:%M', r.baslangic) AS 'Saat',
                    t.ad AS 'Tür', -- Tür tablosundan tür adı alınıyor
                    has.ad AS 'Hayvan',
                    mus.ad || ' ' || mus.soyad AS 'Sahip',
                    r.islem AS 'İşlem',
                    hek.ad AS 'Hekim',
                    r.durum AS 'Durum'
                FROM randevu r
                    INNER JOIN hekim hek ON r.hekim_id = hek.id
                    INNER JOIN hasta has ON r.hasta_id = has.id
                    INNER JOIN musteri mus ON has.musteri_id = mus.id
                    INNER JOIN tur t ON has.tur_id = t.id -- Tür tablosu sorguya eklendi
                WHERE DATE(r.baslangic) = DATE('now', 'localtime')
                ORDER BY r.baslangic ASC;
            ";

            using (SQLiteConnection baglanti = new SQLiteConnection(baglantiYolu))
            {
                using (SQLiteDataAdapter adaptor = new SQLiteDataAdapter(sorgu, baglanti))
                {
                    try
                    {
                        DataTable tablo = new DataTable();
                        adaptor.Fill(tablo);
                        dataGridView1.DataSource = tablo;

                        dataGridView1.Columns["Saat"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dataGridView1.Columns["Saat"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        // Sadece "Saat" sütununun genişliğini içeriğe göre otomatik ayarlar
                        dataGridView1.Columns["Saat"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                        // İkon sütunu yoksa oluştur ve 'Hayvan' sütununun yanına ekle
                        if (dataGridView1.Columns["Ikon"] == null)
                        {
                            DataGridViewImageColumn ikonSutunu = new DataGridViewImageColumn();
                            ikonSutunu.Name = "Ikon";
                            ikonSutunu.HeaderText = "";
                            ikonSutunu.ImageLayout = DataGridViewImageCellLayout.Zoom;
                            ikonSutunu.Width = 20;

                            int hayvanIndex = dataGridView1.Columns["Hayvan"].Index;
                            dataGridView1.Columns.Insert(hayvanIndex, ikonSutunu);
                        }

                        // Tür bilgisini içeren metin sütununu ekranda gizle, sadece arka planda veri olarak kalsın
                        if (dataGridView1.Columns["Tür"] != null)
                        {
                            dataGridView1.Columns["Tür"].Visible = false;
                        }

                        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                        // İkon sütununun boyutunu sabitlemek için (çok genişlemesini önler)
                        dataGridView1.Columns["Ikon"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    }
                    catch (Exception hata)
                    {
                        MessageBox.Show("Randevular listelenirken bir hata oluştu:\n" + hata.Message,
                                        "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // 1. İkon Atama İşlemi
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Ikon")
            {
                string hayvanTuru = dataGridView1.Rows[e.RowIndex].Cells["Tür"].Value?.ToString();

                // Projeye eklediğin resimlerin isimlerini kedi_ikon, kopek_ikon şeklinde değiştirebilirsin
                if (hayvanTuru == "Kedi")
                    e.Value = Properties.Resources.kedi;
                else if (hayvanTuru == "Köpek")
                    e.Value = Properties.Resources.kopek;
                else if (hayvanTuru == "Tavşan")
                    e.Value = Properties.Resources.tavsan;
                else if (hayvanTuru == "Kuş")
                    e.Value = Properties.Resources.kus;
            }

            // 2. Tamamlandı Rozeti Renklendirmesi
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Durum")
            {
                string durum = e.Value?.ToString();

                if (durum == "Tamamlandı")
                {
                    e.CellStyle.BackColor = Color.FromArgb(209, 250, 229); // Açık yeşil arka plan
                    e.CellStyle.ForeColor = Color.FromArgb(6, 95, 70);     // Koyu yeşil metin
                    e.CellStyle.SelectionBackColor = Color.FromArgb(167, 243, 208); // Seçiliyken biraz daha koyu
                    e.CellStyle.SelectionForeColor = Color.FromArgb(6, 95, 70);
                }
                // Dilersen İptal veya Bekliyor için de eklemeler yapabilirsin
            }
        }

        private void BugunkuRandevuSayisiniGoster()
        {
            string baglantiYolu = @"Data Source=vettakip.db;Version=3;";
            string sorgu = "SELECT COUNT(*) FROM randevu WHERE DATE(baslangic) = DATE('now', 'localtime');";

            using (SQLiteConnection baglanti = new SQLiteConnection(baglantiYolu))
            {
                using (SQLiteCommand komut = new SQLiteCommand(sorgu, baglanti))
                {
                    try
                    {
                        baglanti.Open();
                        // ExecuteScalar sorgudan dönen tek bir değeri (sayıyı) alır
                        int toplamRandevu = Convert.ToInt32(komut.ExecuteScalar());

                        // Label'ın textine yazdırıyoruz
                        BgnkRandevulLbl.Text = toplamRandevu.ToString();
                    }
                    catch (Exception hata)
                    {
                        MessageBox.Show("Hata: " + hata.Message);
                    }
                }
            }
        }

        public event EventHandler TakvimeGitIstendi;

        private void TakvimeGit_Click(object sender, EventArgs e)
        {
          if (TakvimeGitIstendi != null) TakvimeGitIstendi(this, EventArgs.Empty);
        }
  }
}