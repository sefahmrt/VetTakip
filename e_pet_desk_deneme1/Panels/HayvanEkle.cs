using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace e_pet_desk_deneme1
{
    public partial class HayvanEkle : Form
    {
        private const string BaglantiYolu = @"Data Source=vettakip.db;Version=3;";
        private int musteriId;

        public HayvanEkle(int musteriId)
        {
            InitializeComponent();
            this.musteriId = musteriId;
        }

        private void HayvanEkle_Load(object sender, EventArgs e)
        {
            cmbCinsiyet.Items.AddRange(new string[] { "Erkek", "Dişi" });
            cmbCinsiyet.SelectedIndex = 0;
            TurleriYukle();
        }

        private void TurleriYukle()
        {
            using (SQLiteConnection baglanti = new SQLiteConnection(BaglantiYolu))
            {
                baglanti.Open();
                using (SQLiteDataAdapter da = new SQLiteDataAdapter("SELECT id, ad FROM tur", baglanti))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cmbTur.DataSource = dt;
                    cmbTur.DisplayMember = "ad";
                    cmbTur.ValueMember = "id";
                }
            }
        }

        private void cmbTur_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTur.SelectedValue != null && (cmbTur.SelectedValue is long || cmbTur.SelectedValue is int))
            {
                int turId = Convert.ToInt32(cmbTur.SelectedValue);
                using (SQLiteConnection baglanti = new SQLiteConnection(BaglantiYolu))
                {
                    baglanti.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand("SELECT id, ad FROM irk WHERE tur_id = @tur_id", baglanti))
                    {
                        cmd.Parameters.AddWithValue("@tur_id", turId);
                        using (SQLiteDataAdapter da = new SQLiteDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);

                            // "Bilinmiyor" seçeneği için boş bir satır ekle
                            DataRow row = dt.NewRow();
                            row["id"] = DBNull.Value;
                            row["ad"] = "Bilinmiyor / Melez";
                            dt.Rows.InsertAt(row, 0);

                            cmbIrk.DataSource = dt;
                            cmbIrk.DisplayMember = "ad";
                            cmbIrk.ValueMember = "id";
                        }
                    }
                }
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAd.Text) || cmbTur.SelectedValue == null)
            {
                MessageBox.Show("Hayvan Adı ve Türü seçilmesi zorunludur.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SQLiteConnection baglanti = new SQLiteConnection(BaglantiYolu))
                {
                    baglanti.Open();
                    string sorgu = @"INSERT INTO hasta (musteri_id, ad, tur_id, irk_id, cinsiyet, dogum_tarihi, renk, mikrocip_no, kisir, agresif) 
                                     VALUES (@musteri, @ad, @tur, @irk, @cinsiyet, @dogum, @renk, @cip, @kisir, @agresif)";

                    using (SQLiteCommand komut = new SQLiteCommand(sorgu, baglanti))
                    {
                        komut.Parameters.AddWithValue("@musteri", musteriId);
                        komut.Parameters.AddWithValue("@ad", txtAd.Text.Trim());
                        komut.Parameters.AddWithValue("@tur", Convert.ToInt32(cmbTur.SelectedValue));
                        komut.Parameters.AddWithValue("@irk", cmbIrk.SelectedValue == DBNull.Value ? (object)DBNull.Value : Convert.ToInt32(cmbIrk.SelectedValue));
                        komut.Parameters.AddWithValue("@cinsiyet", cmbCinsiyet.SelectedItem.ToString());
                        komut.Parameters.AddWithValue("@dogum", dtpDogumTarihi.Value.ToString("yyyy-MM-dd"));
                        komut.Parameters.AddWithValue("@renk", txtRenk.Text.Trim());
                        komut.Parameters.AddWithValue("@cip", string.IsNullOrWhiteSpace(txtMikrocip.Text) ? (object)DBNull.Value : txtMikrocip.Text.Trim());
                        komut.Parameters.AddWithValue("@kisir", chkKisir.Checked ? 1 : 0);
                        komut.Parameters.AddWithValue("@agresif", chkAgresif.Checked ? 1 : 0);

                        komut.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Hayvan başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}