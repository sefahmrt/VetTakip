using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace VetTakip
{
  public partial class YeniSahip : Form
  {

    public YeniSahip()
    {
      InitializeComponent();
    }

    private void btnKaydet_Click(object sender, EventArgs e)
    {
      if (string.IsNullOrWhiteSpace(txtAd.Text) || string.IsNullOrWhiteSpace(txtSoyad.Text) || string.IsNullOrWhiteSpace(txtTel.Text))
      {
        MessageBox.Show("Ad, Soyad ve Telefon alanları zorunludur.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return;
      }

      try
      {
        using (SQLiteConnection baglanti = Veritabani.Ac())
        {
          string sorgu = @"INSERT INTO musteri (ad, soyad, tel, tc, eposta, il, ilce, adres, acil_kisi, acil_tel, sms_izni) 
                                     VALUES (@ad, @soyad, @tel, @tc, @eposta, @il, @ilce, @adres, @acil_kisi, @acil_tel, @sms_izni)";

          using (SQLiteCommand komut = new SQLiteCommand(sorgu, baglanti))
          {
            komut.Parameters.AddWithValue("@ad", txtAd.Text.Trim());
            komut.Parameters.AddWithValue("@soyad", txtSoyad.Text.Trim());
            komut.Parameters.AddWithValue("@tel", txtTel.Text.Trim());
            komut.Parameters.AddWithValue("@tc", string.IsNullOrWhiteSpace(txtTc.Text) ? (object)DBNull.Value : txtTc.Text.Trim());
            komut.Parameters.AddWithValue("@eposta", txtEposta.Text.Trim());
            komut.Parameters.AddWithValue("@il", txtIl.Text.Trim());
            komut.Parameters.AddWithValue("@ilce", txtIlce.Text.Trim());
            komut.Parameters.AddWithValue("@adres", txtAdres.Text.Trim());
            komut.Parameters.AddWithValue("@acil_kisi", txtAcilKisi.Text.Trim());
            komut.Parameters.AddWithValue("@acil_tel", txtAcilTel.Text.Trim());
            komut.Parameters.AddWithValue("@sms_izni", chkSmsIzni.Checked ? 1 : 0);

            komut.ExecuteNonQuery();
          }
        }
        MessageBox.Show("Yeni sahip başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
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