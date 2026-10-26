using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;

public partial class RadiusTextBox : UserControl
{
  // Placeholder için gerekli Windows API tanımlamaları
  private const int EM_SETCUEBANNER = 0x1501;

  [DllImport("user32.dll", CharSet = CharSet.Auto)]
  private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);

  private TextBox innerTextBox;
  private int borderRadius = 12;
  private int borderSize = 1; // Çerçeve kalınlığı[cite: 7]
  private Color borderColor = Color.Gray; // Çerçeve rengi[cite: 7]
  private string placeholderText = "";

  public RadiusTextBox()
  {
    innerTextBox = new TextBox();
    innerTextBox.BorderStyle = BorderStyle.None;
    innerTextBox.Dock = DockStyle.Fill;

    this.Size = new Size(200, 32);
    this.BackColor = Color.White; // UserControl'ün kendi BackColor'ı kullanılıyor[cite: 7]
    this.Padding = new Padding(10, 7, 10, 7);

    innerTextBox.TextChanged += (s, e) => this.OnTextChanged(e);

    this.Controls.Add(innerTextBox);
  }

  [Category("Advanced")]
  public string PlaceholderText
  {
    get { return placeholderText; }
    set
    {
      placeholderText = value;
      if (innerTextBox.IsHandleCreated)
      {
        // wParam: 0 = sadece boşken göster, 1 = odaktayken de boşsa göster
        SendMessage(innerTextBox.Handle, EM_SETCUEBANNER, 0, placeholderText);
      }
    }
  }

  // Kontrol oluşturulduğunda Placeholder metnini uygula
  protected override void OnHandleCreated(EventArgs e)
  {
    base.OnHandleCreated(e);
    if (!string.IsNullOrEmpty(placeholderText))
    {
      SendMessage(innerTextBox.Handle, EM_SETCUEBANNER, 0, placeholderText);
    }
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
  public int BorderRadius
  {
    get { return borderRadius; }
    set { borderRadius = value; this.Invalidate(); }
  }

  [Category("Advanced")]
  public override Color BackColor
  {
    get { return base.BackColor; }
    set
    {
      base.BackColor = value;
      innerTextBox.BackColor = value;
      this.Invalidate();
    }
  }
  [Category("Advanced")]
  public bool Multiline
  {
    get { return innerTextBox.Multiline; }
    set { innerTextBox.Multiline = value; }
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
      this.Region = new Region(pathSurface);
      e.Graphics.FillPath(brushSurface, pathSurface);

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