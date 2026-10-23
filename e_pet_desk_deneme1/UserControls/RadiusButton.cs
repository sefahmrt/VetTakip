using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.ComponentModel;

public partial class RadiusButton : UserControl
{
    private int borderRadius = 12;
    private int borderSize = 0;
    private Color borderColor = Color.PaleVioletRed;
    private Color buttonColor = Color.MediumSlateBlue;
    private Color textColor = Color.White;
    private Image buttonIcon = null;
    private string buttonText = "Radius Button";

    // İkon ile yazı arasındaki boşluk ve konum
    private ContentAlignment textAlign = ContentAlignment.MiddleCenter;

    public RadiusButton()
    {
        this.Size = new Size(160, 40);
        this.BackColor = Color.Transparent;
        this.DoubleBuffered = true;
        this.Cursor = Cursors.Hand;
    }

    [Category("Advanced")]
    public int BorderRadius
    {
        get { return borderRadius; }
        set { borderRadius = value; this.Invalidate(); }
    }

    [Category("Advanced")]
    public int BorderSize
    {
        get { return borderSize; }
        set { borderSize = value; this.Invalidate(); }
    }

    [Category("Advanced")]
    public Color BorderColor
    {
        get { return borderColor; }
        set { borderColor = value; this.Invalidate(); }
    }

    [Category("Advanced")]
    public Color ButtonColor
    {
        get { return buttonColor; }
        set { buttonColor = value; this.Invalidate(); }
    }

    [Category("Advanced")]
    public Color TextColor
    {
        get { return textColor; }
        set { textColor = value; this.Invalidate(); }
    }

    [Category("Advanced")]
    public Image ButtonIcon
    {
        get { return buttonIcon; }
        set { buttonIcon = value; this.Invalidate(); }
    }

    [Category("Advanced")]
    [Browsable(true)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public override string Text
    {
        get { return buttonText; }
        set { buttonText = value; this.Invalidate(); }
    }

    // Butona tıklandığında dışarıya Click olayı fırlatması için (İçindeki kontrolleri ezmemek adına)
    protected override void OnClick(EventArgs e)
    {
        base.OnClick(e);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

        Rectangle rectSurface = this.ClientRectangle;
        Rectangle rectBorder = Rectangle.Inflate(rectSurface, -borderSize, -borderSize);

        using (GraphicsPath pathSurface = GetFigurePath(rectSurface, borderRadius))
        using (GraphicsPath pathBorder = GetFigurePath(rectBorder, borderRadius - borderSize > 0 ? borderRadius - borderSize : 0))
        using (Pen penBorder = new Pen(borderColor, borderSize))
        using (SolidBrush brushSurface = new SolidBrush(buttonColor))
        using (SolidBrush brushText = new SolidBrush(textColor))
        using (StringFormat stringFormat = new StringFormat())
        {
            // Butonun oval arkaplanını boya
            this.Region = new Region(pathSurface);
            e.Graphics.FillPath(brushSurface, pathSurface);

            // Çerçeve varsa çiz
            if (borderSize >= 1)
            {
                e.Graphics.DrawPath(penBorder, pathBorder);
            }

            // İkon ve Yazı Yerleşimi
            int iconSize = 20; // İkonun boyutu
            int spacing = 8;   // İkon ile yazı arasındaki mesafe

            // Eğer ikon eklendiyse ikonla birlikte çiz
            if (buttonIcon != null)
            {
                // Metin boyutunu hesapla
                SizeF textSize = e.Graphics.MeasureString(buttonText, this.Font);
                int totalWidth = iconSize + spacing + (int)textSize.Width;
                int startX = (this.Width - totalWidth) / 2;
                int startY = (this.Height - iconSize) / 2;

                // İkonu çiz
                e.Graphics.DrawImage(buttonIcon, new Rectangle(startX, startY, iconSize, iconSize));

                // Yazıyı ikonun hemen yanına çiz
                stringFormat.Alignment = StringAlignment.Near;
                stringFormat.LineAlignment = StringAlignment.Center;
                Rectangle textRect = new Rectangle(startX + iconSize + spacing, 0, this.Width - (startX + iconSize + spacing), this.Height);
                e.Graphics.DrawString(buttonText, this.Font, brushText, textRect, stringFormat);
            }
            else
            {
                // İkon yoksa sadece ortalı yazı çiz
                stringFormat.Alignment = StringAlignment.Center;
                stringFormat.LineAlignment = StringAlignment.Center;
                e.Graphics.DrawString(buttonText, this.Font, brushText, rectSurface, stringFormat);
            }
        }
    }

    private GraphicsPath GetFigurePath(Rectangle rect, int radius)
    {
        GraphicsPath path = new GraphicsPath();
        float curveSize = radius * 2F;

        path.StartFigure();
        path.AddArc(rect.X, rect.Y, curveSize, curveSize, 180, 90);
        path.AddArc(rect.Right - curveSize, rect.Y, curveSize, curveSize, 270, 90);
        path.AddArc(rect.Right - curveSize, rect.Bottom - curveSize, curveSize, curveSize, 0, 90);
        path.AddArc(rect.X, rect.Bottom - curveSize, curveSize, curveSize, 90, 90);
        path.CloseFigure();

        return path;
    }
}