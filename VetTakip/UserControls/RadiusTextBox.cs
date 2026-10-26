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
    private int borderSize = 1; // Çerçeve kalınlığı
    private Color borderColor = Color.Gray; // Çerçeve rengi
    private string placeholderText = "";

    public RadiusTextBox()
    {
        innerTextBox = new TextBox();
        innerTextBox.BorderStyle = BorderStyle.None;
        innerTextBox.Dock = DockStyle.Fill;

        this.Size = new Size(200, 32);
        this.BackColor = Color.White; // UserControl'ün kendi BackColor'ı kullanılıyor
        this.Padding = new Padding(10, 7, 10, 7);

        innerTextBox.TextChanged += (s, e) => this.OnTextChanged(e);

        // İç TextBox'taki olayları dışarıya aktar (form kodlarında KeyDown vb. çalışsın)
        innerTextBox.KeyDown += (s, e) => this.OnKeyDown(e);
        innerTextBox.KeyPress += (s, e) => this.OnKeyPress(e);
        innerTextBox.KeyUp += (s, e) => this.OnKeyUp(e);
        innerTextBox.GotFocus += (s, e) => this.OnGotFocus(e);
        innerTextBox.LostFocus += (s, e) => this.OnLostFocus(e);
        innerTextBox.Click += (s, e) => this.OnClick(e);
        innerTextBox.DoubleClick += (s, e) => this.OnDoubleClick(e);

        // Multiline vb. değişimlerinde handle yeniden oluşursa placeholder'ı tekrar uygula
        innerTextBox.HandleCreated += (s, e) => ApplyPlaceholder();

        this.Controls.Add(innerTextBox);
    }

    private void ApplyPlaceholder()
    {
        if (innerTextBox != null && innerTextBox.IsHandleCreated && !string.IsNullOrEmpty(placeholderText))
        {
            SendMessage(innerTextBox.Handle, EM_SETCUEBANNER, 0, placeholderText);
        }
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

    // ===== Normal TextBox'tan eklenen özellikler =====

    [Category("Behavior"), DefaultValue(0)]
    public int MaxLength
    {
        get { return innerTextBox.MaxLength; }
        set { innerTextBox.MaxLength = value; }
    }

    [Category("Behavior"), DefaultValue(false)]
    public bool ReadOnly
    {
        get { return innerTextBox.ReadOnly; }
        set { innerTextBox.ReadOnly = value; }
    }

    [Category("Appearance"), DefaultValue(HorizontalAlignment.Left)]
    public HorizontalAlignment TextAlign
    {
        get { return innerTextBox.TextAlign; }
        set { innerTextBox.TextAlign = value; }
    }

    [Category("Behavior"), DefaultValue(true)]
    public bool WordWrap
    {
        get { return innerTextBox.WordWrap; }
        set { innerTextBox.WordWrap = value; }
    }

    [Category("Appearance"), DefaultValue(ScrollBars.None)]
    public ScrollBars ScrollBars
    {
        get { return innerTextBox.ScrollBars; }
        set { innerTextBox.ScrollBars = value; }
    }

    [Category("Behavior"), DefaultValue(false)]
    public bool AcceptsReturn
    {
        get { return innerTextBox.AcceptsReturn; }
        set { innerTextBox.AcceptsReturn = value; }
    }

    [Category("Behavior"), DefaultValue(false)]
    public bool AcceptsTab
    {
        get { return innerTextBox.AcceptsTab; }
        set { innerTextBox.AcceptsTab = value; }
    }

    [Category("Behavior"), DefaultValue(CharacterCasing.Normal)]
    public CharacterCasing CharacterCasing
    {
        get { return innerTextBox.CharacterCasing; }
        set { innerTextBox.CharacterCasing = value; }
    }

    [Category("Behavior"), DefaultValue(true)]
    public bool HideSelection
    {
        get { return innerTextBox.HideSelection; }
        set { innerTextBox.HideSelection = value; }
    }

    [Category("Behavior"), DefaultValue(true)]
    public bool ShortcutsEnabled
    {
        get { return innerTextBox.ShortcutsEnabled; }
        set { innerTextBox.ShortcutsEnabled = value; }
    }

    [Category("Behavior"), DefaultValue(AutoCompleteMode.None)]
    public AutoCompleteMode AutoCompleteMode
    {
        get { return innerTextBox.AutoCompleteMode; }
        set { innerTextBox.AutoCompleteMode = value; }
    }

    [Category("Behavior"), DefaultValue(AutoCompleteSource.None)]
    public AutoCompleteSource AutoCompleteSource
    {
        get { return innerTextBox.AutoCompleteSource; }
        set { innerTextBox.AutoCompleteSource = value; }
    }

    [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public AutoCompleteStringCollection AutoCompleteCustomSource
    {
        get { return innerTextBox.AutoCompleteCustomSource; }
        set { innerTextBox.AutoCompleteCustomSource = value; }
    }

    [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public string[] Lines
    {
        get { return innerTextBox.Lines; }
        set { innerTextBox.Lines = value; }
    }

    [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public string SelectedText
    {
        get { return innerTextBox.SelectedText; }
        set { innerTextBox.SelectedText = value; }
    }

    [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int SelectionStart
    {
        get { return innerTextBox.SelectionStart; }
        set { innerTextBox.SelectionStart = value; }
    }

    [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int SelectionLength
    {
        get { return innerTextBox.SelectionLength; }
        set { innerTextBox.SelectionLength = value; }
    }

    [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool Modified
    {
        get { return innerTextBox.Modified; }
        set { innerTextBox.Modified = value; }
    }

    [Browsable(false)]
    public bool CanUndo
    {
        get { return innerTextBox.CanUndo; }
    }

    [Browsable(false)]
    public int TextLength
    {
        get { return innerTextBox.TextLength; }
    }

    // Sağ tık menüsü iç TextBox'a da uygulanır
    [DefaultValue(null)]
    public override ContextMenuStrip ContextMenuStrip
    {
        get { return base.ContextMenuStrip; }
        set
        {
            base.ContextMenuStrip = value;
            if (innerTextBox != null)
            {
                innerTextBox.ContextMenuStrip = value;
            }
        }
    }

    // ===== Metotlar =====

    public void AppendText(string text) { innerTextBox.AppendText(text); }
    public void Clear() { innerTextBox.Clear(); }
    public void ClearUndo() { innerTextBox.ClearUndo(); }
    public void Copy() { innerTextBox.Copy(); }
    public void Cut() { innerTextBox.Cut(); }
    public void Paste() { innerTextBox.Paste(); }
    public void Undo() { innerTextBox.Undo(); }
    public void SelectAll() { innerTextBox.SelectAll(); }
    public void DeselectAll() { innerTextBox.DeselectAll(); }
    public void Select(int start, int length) { innerTextBox.Select(start, length); }
    public void ScrollToCaret() { innerTextBox.ScrollToCaret(); }
    public int GetCharIndexFromPosition(Point pt) { return innerTextBox.GetCharIndexFromPosition(pt); }
    public int GetLineFromCharIndex(int index) { return innerTextBox.GetLineFromCharIndex(index); }
    public int GetFirstCharIndexFromLine(int lineNumber) { return innerTextBox.GetFirstCharIndexFromLine(lineNumber); }
    public int GetFirstCharIndexOfCurrentLine() { return innerTextBox.GetFirstCharIndexOfCurrentLine(); }
    public Point GetPositionFromCharIndex(int index) { return innerTextBox.GetPositionFromCharIndex(index); }

    // ===== Olaylar (iç TextBox'a yönlendirilir) =====

    public event EventHandler ReadOnlyChanged
    {
        add { innerTextBox.ReadOnlyChanged += value; }
        remove { innerTextBox.ReadOnlyChanged -= value; }
    }

    public event EventHandler ModifiedChanged
    {
        add { innerTextBox.ModifiedChanged += value; }
        remove { innerTextBox.ModifiedChanged -= value; }
    }

    public event EventHandler MultilineChanged
    {
        add { innerTextBox.MultilineChanged += value; }
        remove { innerTextBox.MultilineChanged -= value; }
    }

    public event EventHandler TextAlignChanged
    {
        add { innerTextBox.TextAlignChanged += value; }
        remove { innerTextBox.TextAlignChanged -= value; }
    }

    public event EventHandler AcceptsTabChanged
    {
        add { innerTextBox.AcceptsTabChanged += value; }
        remove { innerTextBox.AcceptsTabChanged -= value; }
    }

    public event EventHandler HideSelectionChanged
    {
        add { innerTextBox.HideSelectionChanged += value; }
        remove { innerTextBox.HideSelectionChanged -= value; }
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