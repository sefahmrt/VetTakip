using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace e_pet_desk_deneme1
{
  /// <summary>
  /// Yeni randevu oluşturma penceresi. Kontroller RandevuForm.Designer.cs içinde (arayüzden düzenlenir).
  /// Kaydet'e basınca RandevuVeri.RandevuEkle ile veritabanına yazar.
  /// Hekim, tarih ve başlangıç saati dışarıdan (boş saate tıklanınca) önceden doldurulabilir.
  /// </summary>
  public partial class RandevuForm : Form
  {
    private readonly DateTime ilkTarih;
    private readonly TakvimHekim ilkHekim;
    private readonly DateTime? ilkBaslangic;

    /// <summary>Kaydedilen randevunun başlangıç günü (ekranı o güne götürmek için).</summary>
    public DateTime KaydedilenGun { get; private set; }

    /// <summary>Tasarım ekranı (Visual Studio designer) için boş kurucu.</summary>
    public RandevuForm() : this(DateTime.Today) { }

    public RandevuForm(DateTime tarih, TakvimHekim hekim = null, DateTime? baslangic = null)
    {
      InitializeComponent();
      ilkTarih = tarih;
      ilkHekim = hekim;
      ilkBaslangic = baslangic;
    }

    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);
      // Tasarım ekranında veritabanına bağlanma
      if (DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;

      cmbHasta.DisplayMember = "Value";
      cmbHasta.ValueMember = "Key";
      cmbHekim.DisplayMember = "Ad";
      if (cmbSure.SelectedIndex < 0) cmbSure.SelectedIndex = 1;   // 30 dk

      dtpTarih.Value = ilkTarih.Date;
      DateTime bas = ilkBaslangic ?? ilkTarih.Date.AddHours(9);
      dtpBaslangic.Value = DateTime.Today.Add(bas.TimeOfDay);

      try
      {
        foreach (var h in RandevuVeri.HastalariGetir()) cmbHasta.Items.Add(h);
        foreach (var h in RandevuVeri.HekimleriGetir()) cmbHekim.Items.Add(h);
      }
      catch (Exception ex) { lblHata.Text = Veritabani.HataMetni(ex); }

      if (ilkHekim != null)
        for (int i = 0; i < cmbHekim.Items.Count; i++)
          if (((TakvimHekim)cmbHekim.Items[i]).Id == ilkHekim.Id) { cmbHekim.SelectedIndex = i; break; }
      if (cmbHekim.SelectedIndex < 0 && cmbHekim.Items.Count > 0) cmbHekim.SelectedIndex = 0;
    }

    private void btnKaydet_Click(object sender, EventArgs e)
    {
      lblHata.Text = "";
      if (!(cmbHasta.SelectedItem is KeyValuePair<int, string>))
      {
        lblHata.Text = "Lütfen listeden bir hasta seçin.";
        return;
      }
      var hasta = (KeyValuePair<int, string>)cmbHasta.SelectedItem;
      var hekim = cmbHekim.SelectedItem as TakvimHekim;
      if (hekim == null) { lblHata.Text = "Lütfen bir hekim seçin."; return; }

      int sure = int.Parse(cmbSure.SelectedItem.ToString().Split(' ')[0], CultureInfo.InvariantCulture);
      DateTime baslangic = dtpTarih.Value.Date.Add(dtpBaslangic.Value.TimeOfDay);
      DateTime bitis = baslangic.AddMinutes(sure);

      try
      {
        RandevuVeri.RandevuEkle(hasta.Key, hekim.Id, baslangic, bitis, txtIslem.Text);
        KaydedilenGun = baslangic.Date;
        DialogResult = DialogResult.OK;
        Close();
      }
      catch (Exception ex)
      {
        // Çakışma ve veritabanı hataları formun içinde gösterilir
        lblHata.Text = ex is InvalidOperationException || ex is ArgumentException ? ex.Message : Veritabani.HataMetni(ex);
      }
    }

        private void radiusButton1_MouseEnter(object sender, EventArgs e)
        {
            RadiusButton btn = sender as RadiusButton; // Button yerine RadiusButton'a dönüştürüyoruz
            if (btn != null)
            {
                btn.TextColor = Color.WhiteSmoke;
                btn.MouseOverBackColor = Color.FromArgb(25, 145, 136);
            }
        }

        private void radiusButton1_MouseLeave(object sender, EventArgs e)
        {
            RadiusButton btn = sender as RadiusButton; // Button yerine RadiusButton'a dönüştürüyoruz
            if (btn != null)
            {
                btn.TextColor = Color.White;
            }
        }

        private void radiusButton2_MouseEnter(object sender, EventArgs e)
        {
            RadiusButton btn = sender as RadiusButton; // Button yerine RadiusButton'a dönüştürüyoruz
            if (btn != null)
            {
                btn.MouseOverBackColor = Color.FromArgb(255, 192, 192);
                btn.TextColor = Color.DimGray;
            }
        }

        private void radiusButton2_MouseLeave(object sender, EventArgs e)
        {
            RadiusButton btn = sender as RadiusButton; // Button yerine RadiusButton'a dönüştürüyoruz
            if (btn != null)
            {
                btn.TextColor = Color.FromArgb(15, 118, 110);
            }
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

    }
}