using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public enum IconPosition { Left, Right }
public enum CustomTextAlign { Left, Center, Right }

public partial class RadiusButton : UserControl, IButtonControl
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
    private int iconSize = 20;

    private IconPosition iconLocation = IconPosition.Left;
    private CustomTextAlign textAlign = CustomTextAlign.Center;

    private Color mouseOverBackColor = Color.MediumSlateBlue;
    private Color mouseDownBackColor = Color.MediumSlateBlue;

    // Normal Button'daki Enabled=false görünümü için
    private Color disabledBackColor = Color.FromArgb(220, 220, 220);
    private Color disabledTextColor = Color.FromArgb(150, 150, 150);

    private bool isHovering = false;
    private bool isPressed = false;
    private bool isActive = false; // Menüde seçili buton mu?

    // Normal Button'dan gelen özellikler
    private DialogResult dialogResult = DialogResult.None;
    private bool autoEllipsis = false;
    private bool useMnemonic = true;
    private bool isDefault = false;
    private bool isKeyDown = false;

    public RadiusButton()
    {
        this.Size = new Size(160, 40);
        this.BackColor = Color.Transparent;
        this.DoubleBuffered = true;
        this.Cursor = Cursors.Hand;
        this.ResizeRedraw = true;

        // Klavyeyle odaklanabilme (Tab / Space) - normal Button gibi
        this.SetStyle(ControlStyles.Selectable, true);
        this.TabStop = true;
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
        set { buttonText = value; this.Invalidate(); this.OnTextChanged(EventArgs.Empty); }
    }

    // ===== Normal Button'dan eklenen özellikler =====

    // Button.ForeColor = yazı rengi (TextColor ile aynı değeri kullanır)
    [Category("Appearance")]
    public override Color ForeColor
    {
        get { return textColor; }
        set { textColor = value; base.ForeColor = value; this.Invalidate(); }
    }

    // Button.Image (koddan kullanım için; tasarımcıda ButtonIcon kullanılır)
    [Browsable(false), EditorBrowsable(EditorBrowsableState.Advanced)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Image Image
    {
        get { return buttonIcon; }
        set { buttonIcon = value; this.Invalidate(); }
    }

    [Category("Advanced"), DefaultValue(20)]
    public int IconSize
    {
        get { return iconSize; }
        set { iconSize = value > 0 ? value : 1; this.Invalidate(); }
    }

    [Category("Advanced")]
    public Color DisabledBackColor
    {
        get { return disabledBackColor; }
        set { disabledBackColor = value; this.Invalidate(); }
    }

    [Category("Advanced")]
    public Color DisabledTextColor
    {
        get { return disabledTextColor; }
        set { disabledTextColor = value; this.Invalidate(); }
    }

    // Button.DialogResult (IButtonControl)
    [Category("Behavior"), DefaultValue(DialogResult.None)]
    public DialogResult DialogResult
    {
        get { return dialogResult; }
        set { dialogResult = value; }
    }

    // Button.AutoEllipsis
    [Category("Behavior"), DefaultValue(false)]
    public bool AutoEllipsis
    {
        get { return autoEllipsis; }
        set { autoEllipsis = value; this.Invalidate(); }
    }

    // Button.UseMnemonic ("&Kaydet" gibi kısayol harfi)
    [Category("Appearance"), DefaultValue(true)]
    public bool UseMnemonic
    {
        get { return useMnemonic; }
        set { useMnemonic = value; this.Invalidate(); }
    }

    // IButtonControl: Form.AcceptButton / CancelButton olarak atanabilir
    public void NotifyDefault(bool value)
    {
        if (isDefault != value)
        {
            isDefault = value;
            this.Invalidate();
        }
    }

    // Button.PerformClick()
    public void PerformClick()
    {
        if (this.Enabled && this.Visible)
        {
            this.OnClick(EventArgs.Empty);
        }
    }

    protected override bool ProcessMnemonic(char charCode)
    {
        if (useMnemonic && this.Enabled && this.Visible && IsMnemonic(charCode, buttonText))
        {
            this.PerformClick();
            return true;
        }
        return base.ProcessMnemonic(charCode);
    }

    protected override void OnEnabledChanged(EventArgs e)
    {
        base.OnEnabledChanged(e);
        isHovering = false;
        isPressed = false;
        this.Invalidate();
    }

    protected override void OnGotFocus(EventArgs e)
    {
        base.OnGotFocus(e);
        this.Invalidate();
    }

    protected override void OnLostFocus(EventArgs e)
    {
        base.OnLostFocus(e);
        isPressed = false;
        isKeyDown = false;
        this.Invalidate();
    }

    protected override void OnKeyDown(KeyEventArgs e)
    {
        base.OnKeyDown(e);
        if (e.KeyCode == Keys.Space && !e.Alt && !e.Control)
        {
            isKeyDown = true;
            isPressed = true;
            this.Invalidate();
            e.Handled = true;
        }
    }

    protected override void OnKeyUp(KeyEventArgs e)
    {
        base.OnKeyUp(e);
        if (e.KeyCode == Keys.Space && isKeyDown)
        {
            isKeyDown = false;
            isPressed = false;
            this.Invalidate();
            this.PerformClick();
            e.Handled = true;
        }
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
        if (e.Button == MouseButtons.Left)
        {
            isPressed = true;
            if (this.CanSelect)
            {
                this.Focus();
            }
            this.Invalidate();
        }
    }

    protected override void OnMouseUp(MouseEventArgs e)
    {
        base.OnMouseUp(e);
        isPressed = false;
        this.Invalidate();
    }

    protected override void OnClick(EventArgs e)
    {
        // Normal Button gibi: DialogResult atanmışsa formu kapatır
        if (dialogResult != DialogResult.None)
        {
            Form form = this.FindForm();
            if (form != null)
            {
                form.DialogResult = dialogResult;
            }
        }
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
        Color currentTextColor = textColor;
        if (!this.Enabled)
        {
            currentBackColor = disabledBackColor;
            currentTextColor = disabledTextColor;
        }
        else if (isPressed) currentBackColor = mouseDownBackColor;
        else if (isHovering) currentBackColor = mouseOverBackColor;

        using (GraphicsPath pathSurface = GetFigurePath(rectSurface, borderRadius))
        using (GraphicsPath pathBorder = GetFigurePath(rectBorder, borderRadius - borderSize > 0 ? borderRadius - borderSize : 0))
        using (Pen penBorder = new Pen(borderColor, borderSize))
        using (SolidBrush brushSurface = new SolidBrush(currentBackColor))
        using (SolidBrush brushText = new SolidBrush(currentTextColor))
        using (StringFormat stringFormat = new StringFormat() { LineAlignment = StringAlignment.Center })
        {
            if (useMnemonic)
            {
                stringFormat.HotkeyPrefix = this.ShowKeyboardCues
                    ? System.Drawing.Text.HotkeyPrefix.Show
                    : System.Drawing.Text.HotkeyPrefix.Hide;
            }
            else
            {
                stringFormat.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.None;
            }

            if (autoEllipsis)
            {
                stringFormat.Trimming = StringTrimming.EllipsisCharacter;
                stringFormat.FormatFlags |= StringFormatFlags.NoWrap;
            }

            e.Graphics.FillPath(brushSurface, pathSurface);

            if (borderSize >= 1)
            {
                e.Graphics.DrawPath(penBorder, pathBorder);
            }

            int spacing = 8;
            int padding = 12;

            // HANGİ İKONUN ÇİZİLECEĞİNE KARAR VERİYORUZ
            Image currentIcon = buttonIcon;

            // Eğer fare üzerindeyse VEYA tıklandıysa VEYA aktif butonsa HoverIcon (Beyaz) kullan
            if (this.Enabled && (isHovering || isPressed || isActive) && hoverIcon != null)
            {
                currentIcon = hoverIcon;
            }

            if (currentIcon != null)
            {
                SizeF textSize = e.Graphics.MeasureString(buttonText, this.Font, 10000, stringFormat);

                if (autoEllipsis)
                {
                    float maxText = this.Width - (padding * 2) - iconSize - spacing;
                    if (maxText > 0 && textSize.Width > maxText)
                    {
                        textSize = new SizeF(maxText, textSize.Height);
                    }
                }

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

            // Klavye odağı göstergesi (normal Button'daki noktalı çerçeve gibi)
            if (this.Focused && this.ShowFocusCues)
            {
                Rectangle rectFocus = Rectangle.Inflate(rectSurface, -3, -3);
                int focusRadius = borderRadius - 3 > 1 ? borderRadius - 3 : 1;
                using (GraphicsPath pathFocus = GetFigurePath(rectFocus, focusRadius))
                using (Pen penFocus = new Pen(Color.FromArgb(160, currentTextColor)) { DashStyle = DashStyle.Dot })
                {
                    e.Graphics.DrawPath(penFocus, pathFocus);
                }
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