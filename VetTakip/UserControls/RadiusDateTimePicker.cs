using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace VetTakip
{
  public class RadiusDateTimePicker : DateTimePicker
  {
    private int borderRadius = 12;
    private int borderSize = 1;
    private Color borderColor = Color.Gray;

    public RadiusDateTimePicker()
    {
      this.SetStyle(ControlStyles.UserPaint, true);
      this.MinimumSize = new Size(0, 32);
      this.Size = new Size(200, 32);
      this.Font = new Font("Segoe UI", 9.5F);
      this.Format = DateTimePickerFormat.Short;
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
      using (SolidBrush textBrush = new SolidBrush(this.ForeColor))
      using (StringFormat format = new StringFormat { LineAlignment = StringAlignment.Center })
      {
        // Arka planı ve kavisli kenarları çiz
        this.Region = new Region(pathSurface);
        e.Graphics.FillPath(brushSurface, pathSurface);

        if (borderSize >= 1)
        {
          e.Graphics.DrawPath(penBorder, pathBorder);
        }

        // Seçili tarihi çiz
        Rectangle textRect = new Rectangle(10, 0, this.Width - 35, this.Height);
        e.Graphics.DrawString(this.Text, this.Font, textBrush, textRect, format);

        // Sağ tarafa minimalist bir takvim ikonu çiz
        int iconSize = 14;
        Rectangle iconRect = new Rectangle(this.Width - iconSize - 10, (this.Height - iconSize) / 2, iconSize, iconSize);

        using (Pen iconPen = new Pen(this.ForeColor, 1.5f))
        {
          e.Graphics.DrawRectangle(iconPen, iconRect.X, iconRect.Y + 2, iconRect.Width, iconRect.Height - 2);
          e.Graphics.DrawLine(iconPen, iconRect.X, iconRect.Y + 6, iconRect.Right, iconRect.Y + 6);
          e.Graphics.DrawLine(iconPen, iconRect.X + 3, iconRect.Y, iconRect.X + 3, iconRect.Y + 4);
          e.Graphics.DrawLine(iconPen, iconRect.Right - 3, iconRect.Y, iconRect.Right - 3, iconRect.Y + 4);
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
}