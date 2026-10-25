using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace e_pet_desk_deneme1
{
  public class RadiusComboBox : UserControl
  {
    private ComboBox innerComboBox;
    private int borderRadius = 12;
    private int borderSize = 1;
    private Color borderColor = Color.Gray;

    public RadiusComboBox()
    {
      innerComboBox = new ComboBox();
      innerComboBox.FlatStyle = FlatStyle.Flat;
      innerComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
      innerComboBox.BackColor = Color.White;
      innerComboBox.Font = new Font("Segoe UI", 9.5F);

      this.Controls.Add(innerComboBox);
      this.Size = new Size(200, 32);
      this.BackColor = Color.White;
      this.Padding = new Padding(8, 6, 8, 6);

      innerComboBox.SelectedIndexChanged += (s, e) => { OnSelectedIndexChanged(e); };
    }

    // Form kodlarının bozulmaması için gerekli ComboBox özelliklerinin dışa aktarımı
    [Category("Advanced")]
    public ComboBoxStyle DropDownStyle
    {
      get { return innerComboBox.DropDownStyle; }
      set { innerComboBox.DropDownStyle = value; }
    }

    public object DataSource { get { return innerComboBox.DataSource; } set { innerComboBox.DataSource = value; } }
    public string DisplayMember { get { return innerComboBox.DisplayMember; } set { innerComboBox.DisplayMember = value; } }
    public string ValueMember { get { return innerComboBox.ValueMember; } set { innerComboBox.ValueMember = value; } }
    public object SelectedValue { get { return innerComboBox.SelectedValue; } set { innerComboBox.SelectedValue = value; } }
    public int SelectedIndex { get { return innerComboBox.SelectedIndex; } set { innerComboBox.SelectedIndex = value; } }
    public object SelectedItem { get { return innerComboBox.SelectedItem; } set { innerComboBox.SelectedItem = value; } }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public ComboBox.ObjectCollection Items { get { return innerComboBox.Items; } }

    [Category("Advanced")]
    public int BorderRadius { get { return borderRadius; } set { borderRadius = value; this.Invalidate(); } }
    [Category("Advanced")]
    public int BorderSize { get { return borderSize; } set { borderSize = value; this.Invalidate(); } }
    [Category("Advanced")]
    public Color BorderColor { get { return borderColor; } set { borderColor = value; this.Invalidate(); } }

    public event EventHandler SelectedIndexChanged;
    protected virtual void OnSelectedIndexChanged(EventArgs e) { SelectedIndexChanged?.Invoke(this, e); }

    protected override void OnLayout(LayoutEventArgs e)
    {
      base.OnLayout(e);
      if (innerComboBox != null)
      {
        innerComboBox.Width = this.Width - 14;
        innerComboBox.Location = new Point(7, (this.Height - innerComboBox.Height) / 2);
      }
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
}