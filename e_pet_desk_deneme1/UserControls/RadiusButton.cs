using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.ComponentModel;

public enum IconPosition { Left, Right }
public enum CustomTextAlign { Left, Center, Right }

public partial class RadiusButton : UserControl
{
    private int borderRadius = 12;
    private int borderSize = 0;
    private Color borderColor = Color.PaleVioletRed;
    private Color buttonColor = Color.MediumSlateBlue;
    private Color textColor = Color.White;

    // İKON DEĞİŞKENLERİ
    private Image buttonIcon = null; // Gri ikon (Varsayılan)
    private Image hoverIcon = null;  // Beyaz ikon (Fare üstündeyken veya aktifken)
    private string buttonText = "Radius Button";

    private IconPosition iconLocation = IconPosition.Left;
    private CustomTextAlign textAlign = CustomTextAlign.Center;

    private Color mouseOverBackColor = Color.MediumSlateBlue;
    private Color mouseDownBackColor = Color.MediumSlateBlue;

    private bool isHovering = false;
    private bool isPressed = false;
    private bool isActive = false; // Menüde seçili buton mu?

    public RadiusButton()
    {
        this.Size = new Size(160, 40);
        this.BackColor = Color.Transparent;
        this.DoubleBuffered = true;
        this.Cursor = Cursors.Hand;
    }

    // YENİ: Özellikler penceresinde görünecek Hover (Beyaz) İkonu
    [Category("Advanced")]
    public Image HoverIcon
    {
        get { return hoverIcon; }
        set { hoverIcon = value; this.Invalidate(); }
    }

    // YENİ: Koddan kontrol edeceğimiz aktiflik durumu (Properties'de görünmesine gerek yok)
    [Category("Advanced"), Browsable(false)]
    public bool IsActive
    {
        get { return isActive; }
        set { isActive = value; this.Invalidate(); }
    }

    [Category("Advanced")]
    public Color MouseOverBackColor
    {
        get { return mouseOverBackColor; }
        set { mouseOverBackColor = value; this.Invalidate(); }
    }

    [Category("Advanced")]
    public Color MouseDownBackColor
    {
        get { return mouseDownBackColor; }
        set { mouseDownBackColor = value; this.Invalidate(); }
    }

    [Category("Advanced"), Browsable(true)]
    public IconPosition IconLocation
    {
        get { return iconLocation; }
        set { iconLocation = value; this.Invalidate(); }
    }

    [Category("Advanced"), Browsable(true)]
    public CustomTextAlign TextAlign
    {
        get { return textAlign; }
        set { textAlign = value; this.Invalidate(); }
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

    [Category("Advanced"), Browsable(true)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public override string Text
    {
        get { return buttonText; }
        set { buttonText = value; this.Invalidate(); }
    }

    protected override void OnMouseEnter(EventArgs e)
    {
        base.OnMouseEnter(e);
        isHovering = true;
        this.Invalidate();
    }

    protected override void OnMouseLeave(EventArgs e)
    {
        base.OnMouseLeave(e);
        isHovering = false;
        isPressed = false;
        this.Invalidate();
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
        base.OnMouseDown(e);
        isPressed = true;
        this.Invalidate();
    }

    protected override void OnMouseUp(MouseEventArgs e)
    {
        base.OnMouseUp(e);
        isPressed = false;
        this.Invalidate();
    }

    protected override void OnClick(EventArgs e)
    {
        base.OnClick(e);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

        Rectangle rectSurface = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
        Rectangle rectBorder = Rectangle.Inflate(rectSurface, -borderSize, -borderSize);

        Color currentBackColor = buttonColor;
        if (isPressed) currentBackColor = mouseDownBackColor;
        else if (isHovering) currentBackColor = mouseOverBackColor;

        using (GraphicsPath pathSurface = GetFigurePath(rectSurface, borderRadius))
        using (GraphicsPath pathBorder = GetFigurePath(rectBorder, borderRadius - borderSize > 0 ? borderRadius - borderSize : 0))
        using (Pen penBorder = new Pen(borderColor, borderSize))
        using (SolidBrush brushSurface = new SolidBrush(currentBackColor))
        using (SolidBrush brushText = new SolidBrush(textColor))
        using (StringFormat stringFormat = new StringFormat() { LineAlignment = StringAlignment.Center })
        {
            e.Graphics.FillPath(brushSurface, pathSurface);

            if (borderSize >= 1)
            {
                e.Graphics.DrawPath(penBorder, pathBorder);
            }

            int iconSize = 20;
            int spacing = 8;
            int padding = 12;

            // HANGİ İKONUN ÇİZİLECEĞİNE KARAR VERİYORUZ
            Image currentIcon = buttonIcon;

            // Eğer fare üzerindeyse VEYA tıklandıysa VEYA aktif butonsa HoverIcon (Beyaz) kullan
            if ((isHovering || isPressed || isActive) && hoverIcon != null)
            {
                currentIcon = hoverIcon;
            }

            if (currentIcon != null)
            {
                SizeF textSize = e.Graphics.MeasureString(buttonText, this.Font);
                int totalWidth = iconSize + spacing + (int)textSize.Width;

                int iconX = 0;
                int textX = 0;
                int yPos = (this.Height - iconSize) / 2;

                if (textAlign == CustomTextAlign.Center)
                {
                    int startX = (this.Width - totalWidth) / 2;
                    iconX = (iconLocation == IconPosition.Left) ? startX : startX + (int)textSize.Width + spacing;
                    textX = (iconLocation == IconPosition.Left) ? startX + iconSize + spacing : startX;
                }
                else if (textAlign == CustomTextAlign.Left)
                {
                    iconX = (iconLocation == IconPosition.Left) ? padding : padding + (int)textSize.Width + spacing;
                    textX = (iconLocation == IconPosition.Left) ? padding + iconSize + spacing : padding;
                }
                else
                {
                    iconX = (iconLocation == IconPosition.Right) ? this.Width - padding - iconSize : this.Width - padding - totalWidth;
                    textX = (iconLocation == IconPosition.Right) ? this.Width - padding - totalWidth : this.Width - padding - (int)textSize.Width;
                }

                e.Graphics.DrawImage(currentIcon, new Rectangle(iconX, yPos, iconSize, iconSize));

                Rectangle textRect = new Rectangle(textX, 0, (int)textSize.Width + 5, this.Height);
                stringFormat.Alignment = StringAlignment.Near;
                e.Graphics.DrawString(buttonText, this.Font, brushText, textRect, stringFormat);
            }
            else
            {
                if (textAlign == CustomTextAlign.Left) stringFormat.Alignment = StringAlignment.Near;
                else if (textAlign == CustomTextAlign.Right) stringFormat.Alignment = StringAlignment.Far;
                else stringFormat.Alignment = StringAlignment.Center;

                Rectangle textRect = new Rectangle(padding, 0, this.Width - (padding * 2), this.Height);
                e.Graphics.DrawString(buttonText, this.Font, brushText, textRect, stringFormat);
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