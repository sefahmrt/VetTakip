using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public class RoundedPanel : Panel
{
    private int borderRadius = 20; // Köşe yuvarlaklığı (radius değeri)
    private Color borderColor = Color.Silver;
    private int borderSize = 1;

    public int BorderRadius
    {
        get => borderRadius;
        set { borderRadius = value; Invalidate(); }
    }

    public Color BorderColor
    {
        get => borderColor;
        set { borderColor = value; Invalidate(); }
    }

    public int BorderSize
    {
        get => borderSize;
        set { borderSize = value; Invalidate(); }
    }

    // Köşeleri yuvarlatan ve çizen metod
    private GraphicsPath GetFigurePath(Rectangle rect, float radius)
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

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

        Rectangle rectSurface = this.ClientRectangle;
        Rectangle rectBorder = Rectangle.Inflate(rectSurface, -borderSize, -borderSize);

        int smoothSize = 2;
        if (borderSize > 0)
        {
            smoothSize = borderSize;
        }

        if (borderRadius > 2)
        {
            using (GraphicsPath pathSurface = GetFigurePath(rectSurface, borderRadius))
            using (GraphicsPath pathBorder = GetFigurePath(rectBorder, borderRadius - 1))
            using (Pen penSurface = new Pen(this.Parent.BackColor, smoothSize))
            using (Pen penBorder = new Pen(borderColor, borderSize))
            {
                this.Region = new Region(pathSurface);
                e.Graphics.DrawPath(penSurface, pathSurface);

                if (borderSize > 0)
                {
                    e.Graphics.DrawPath(penBorder, pathBorder);
                }
            }
        }
        else
        {
            this.Region = new Region(rectSurface);
            if (borderSize > 0)
            {
                using (Pen penBorder = new Pen(borderColor, borderSize))
                {
                    e.Graphics.DrawRectangle(penBorder, 0, 0, this.Width - 1, this.Height - 1);
                }
            }
        }
    }
}