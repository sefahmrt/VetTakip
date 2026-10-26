using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace VetTakip
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

            // Normal ComboBox olaylarını dışarıya aktar
            innerComboBox.SelectedValueChanged += (s, e) => { SelectedValueChanged?.Invoke(this, e); };
            innerComboBox.SelectionChangeCommitted += (s, e) => { SelectionChangeCommitted?.Invoke(this, e); };
            innerComboBox.DropDown += (s, e) => { DropDown?.Invoke(this, e); };
            innerComboBox.DropDownClosed += (s, e) => { DropDownClosed?.Invoke(this, e); };
            innerComboBox.TextUpdate += (s, e) => { TextUpdate?.Invoke(this, e); };
            innerComboBox.DropDownStyleChanged += (s, e) => { DropDownStyleChanged?.Invoke(this, e); };
            innerComboBox.TextChanged += (s, e) => { this.OnTextChanged(e); };
            innerComboBox.KeyDown += (s, e) => { this.OnKeyDown(e); };
            innerComboBox.KeyPress += (s, e) => { this.OnKeyPress(e); };
            innerComboBox.KeyUp += (s, e) => { this.OnKeyUp(e); };
            innerComboBox.GotFocus += (s, e) => { this.OnGotFocus(e); };
            innerComboBox.LostFocus += (s, e) => { this.OnLostFocus(e); };
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

        // ===== Normal ComboBox'tan eklenen özellikler =====

        public override string Text
        {
            get { return innerComboBox != null ? innerComboBox.Text : base.Text; }
            set
            {
                if (innerComboBox != null) innerComboBox.Text = value;
                else base.Text = value;
            }
        }

        // Arka plan rengi iç ComboBox'a da uygulanır (Transparent hariç)
        public override Color BackColor
        {
            get { return base.BackColor; }
            set
            {
                base.BackColor = value;
                if (innerComboBox != null && value.A == 255)
                {
                    innerComboBox.BackColor = value;
                }
                this.Invalidate();
            }
        }

        // Yazı tipi iç ComboBox'a da uygulanır
        public override Font Font
        {
            get { return base.Font; }
            set
            {
                base.Font = value;
                if (innerComboBox != null && value != null)
                {
                    innerComboBox.Font = value;
                    this.PerformLayout();
                }
            }
        }

        [Category("Appearance"), DefaultValue(FlatStyle.Flat)]
        public FlatStyle FlatStyle
        {
            get { return innerComboBox.FlatStyle; }
            set { innerComboBox.FlatStyle = value; }
        }

        [Category("Behavior"), DefaultValue(false)]
        public bool Sorted
        {
            get { return innerComboBox.Sorted; }
            set { innerComboBox.Sorted = value; }
        }

        [Category("Behavior"), DefaultValue(0)]
        public int MaxLength
        {
            get { return innerComboBox.MaxLength; }
            set { innerComboBox.MaxLength = value; }
        }

        [Category("Behavior"), DefaultValue(8)]
        public int MaxDropDownItems
        {
            get { return innerComboBox.MaxDropDownItems; }
            set { innerComboBox.MaxDropDownItems = value; }
        }

        [Category("Behavior"), DefaultValue(true)]
        public bool IntegralHeight
        {
            get { return innerComboBox.IntegralHeight; }
            set { innerComboBox.IntegralHeight = value; }
        }

        [Category("Behavior"), DefaultValue(false)]
        public bool FormattingEnabled
        {
            get { return innerComboBox.FormattingEnabled; }
            set { innerComboBox.FormattingEnabled = value; }
        }

        [Category("Behavior"), DefaultValue("")]
        public string FormatString
        {
            get { return innerComboBox.FormatString; }
            set { innerComboBox.FormatString = value; }
        }

        [Category("Behavior"), DefaultValue(DrawMode.Normal)]
        public DrawMode DrawMode
        {
            get { return innerComboBox.DrawMode; }
            set { innerComboBox.DrawMode = value; }
        }

        [Category("Behavior"), DefaultValue(AutoCompleteMode.None)]
        public AutoCompleteMode AutoCompleteMode
        {
            get { return innerComboBox.AutoCompleteMode; }
            set { innerComboBox.AutoCompleteMode = value; }
        }

        [Category("Behavior"), DefaultValue(AutoCompleteSource.None)]
        public AutoCompleteSource AutoCompleteSource
        {
            get { return innerComboBox.AutoCompleteSource; }
            set { innerComboBox.AutoCompleteSource = value; }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AutoCompleteStringCollection AutoCompleteCustomSource
        {
            get { return innerComboBox.AutoCompleteCustomSource; }
            set { innerComboBox.AutoCompleteCustomSource = value; }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int DropDownWidth
        {
            get { return innerComboBox.DropDownWidth; }
            set { innerComboBox.DropDownWidth = value; }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int DropDownHeight
        {
            get { return innerComboBox.DropDownHeight; }
            set { innerComboBox.DropDownHeight = value; }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int ItemHeight
        {
            get { return innerComboBox.ItemHeight; }
            set { innerComboBox.ItemHeight = value; }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool DroppedDown
        {
            get { return innerComboBox.DroppedDown; }
            set { innerComboBox.DroppedDown = value; }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string SelectedText
        {
            get { return innerComboBox.SelectedText; }
            set { innerComboBox.SelectedText = value; }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int SelectionStart
        {
            get { return innerComboBox.SelectionStart; }
            set { innerComboBox.SelectionStart = value; }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int SelectionLength
        {
            get { return innerComboBox.SelectionLength; }
            set { innerComboBox.SelectionLength = value; }
        }

        // ===== Metotlar =====

        public int FindString(string s) { return innerComboBox.FindString(s); }
        public int FindString(string s, int startIndex) { return innerComboBox.FindString(s, startIndex); }
        public int FindStringExact(string s) { return innerComboBox.FindStringExact(s); }
        public int FindStringExact(string s, int startIndex) { return innerComboBox.FindStringExact(s, startIndex); }
        public string GetItemText(object item) { return innerComboBox.GetItemText(item); }
        public void BeginUpdate() { innerComboBox.BeginUpdate(); }
        public void EndUpdate() { innerComboBox.EndUpdate(); }
        public void SelectAll() { innerComboBox.SelectAll(); }
        public void Select(int start, int length) { innerComboBox.Select(start, length); }

        // ===== Olaylar =====

        public event EventHandler SelectedIndexChanged;
        protected virtual void OnSelectedIndexChanged(EventArgs e) { SelectedIndexChanged?.Invoke(this, e); }

        public event EventHandler SelectedValueChanged;
        public event EventHandler SelectionChangeCommitted;
        public event EventHandler DropDown;
        public event EventHandler DropDownClosed;
        public event EventHandler TextUpdate;
        public event EventHandler DropDownStyleChanged;

        public event DrawItemEventHandler DrawItem
        {
            add { innerComboBox.DrawItem += value; }
            remove { innerComboBox.DrawItem -= value; }
        }

        public event MeasureItemEventHandler MeasureItem
        {
            add { innerComboBox.MeasureItem += value; }
            remove { innerComboBox.MeasureItem -= value; }
        }

        public event ListControlConvertEventHandler Format
        {
            add { innerComboBox.Format += value; }
            remove { innerComboBox.Format -= value; }
        }

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