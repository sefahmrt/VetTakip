using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.ComponentModel;

public partial class RadiusTextBox : UserControl
{
    private TextBox innerTextBox;
    private int borderRadius = 12;
    private int borderSize = 1; // Çerçeve kalınlığı
    private Color borderColor = Color.Gray; // Çerçeve rengi

    public RadiusTextBox()
    {
        innerTextBox = new TextBox();
        innerTextBox.BorderStyle = BorderStyle.None;
        innerTextBox.Dock = DockStyle.Fill;

        this.Size = new Size(200, 32);
        this.BackColor = Color.White;
        this.Padding = new Padding(10, 7, 10, 7);

        innerTextBox.TextChanged += (s, e) => this.OnTextChanged(e);

        this.Controls.Add(innerTextBox);
    }

    // Dışarıdan BorderSize ayarlayabilmek için:
    [Category("Advanced")]
    public int BorderSize
    {
        get { return borderSize; }
        set { borderSize = value; this.Invalidate(); }
    }

    // Dışarıdan BorderColor ayarlayabilmek için:
    [Category("Advanced")]
    public Color BorderColor
    {
        get { return borderColor; }
        set { borderColor = value; this.Invalidate(); }
    }

    [Category("Advanced")]
    public int BorderRadius
    {
        get { return borderRadius; }
        set { borderRadius = value; this.Invalidate(); }
    }

    public override string Text
    {
        get { return innerTextBox.Text; }
        set { innerTextBox.Text = value; }
    }

    public char PasswordChar
    {
        get { return innerTextBox.PasswordChar; }
        set { innerTextBox.PasswordChar = value; }
    }

    public bool UseSystemPasswordChar
    {
        get { return innerTextBox.UseSystemPasswordChar; }
        set { innerTextBox.UseSystemPasswordChar = value; }
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
        using (SolidBrush brushSurface = new SolidBrush(this.BackColor))
        {
            // Kutunun arkaplanını ve oval formunu ayarla
            this.Region = new Region(pathSurface);
            e.Graphics.FillPath(brushSurface, pathSurface);

            // Çerçeve kalınlığı 0'dan büyükse kenar çizgisini çiz
            if (borderSize >= 1)
            {
                e.Graphics.DrawPath(penBorder, pathBorder);
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