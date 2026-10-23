using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.ComponentModel;

public class TopShadow : Panel // UserControl yerine Panel'den miras alıyoruz ki daha hafif olsun
{
    private int shadowAlpha = 35; // Gölgenin koyuluk derecesi (0-255 arası)

    public TopShadow()
    {
        this.Size = new Size(200, 6); // Gölgenin dikey kalınlığı (6 piksel idealdir)
        this.Dock = DockStyle.Top;
        this.BackColor = Color.Transparent; // Arka planın formun rengini alması için
    }

    [Category("Advanced")]
    public int ShadowAlpha
    {
        get { return shadowAlpha; }
        set
        {
            shadowAlpha = value > 255 ? 255 : (value < 0 ? 0 : value);
            this.Invalidate();
        }
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        // Yukarıdan aşağıya doğru kararan -> şeffaflaşan bir fırça oluşturuyoruz
        using (LinearGradientBrush brush = new LinearGradientBrush(
            this.ClientRectangle,
            Color.FromArgb(shadowAlpha, Color.Black), // Üst kısım (hafif siyah)
            Color.Transparent,                        // Alt kısım (görünmez)
            LinearGradientMode.Vertical))
        {
            e.Graphics.FillRectangle(brush, this.ClientRectangle);
        }
    }
}