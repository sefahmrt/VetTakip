using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace VetTakip
{
    // Not: DateTimePicker'dan türediği için Value, Format, CustomFormat, MinDate, MaxDate,
    // ShowCheckBox, Checked, ShowUpDown, DropDownAlign, Calendar* renkleri, ValueChanged vb.
    // tüm özellik ve olaylar zaten mevcuttur. Bu sınıfta eksik olan şey çizimdi:
    // ShowCheckBox, ShowUpDown, Enabled=false ve RightToLeft artık özel çizimde de yansıtılıyor.
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

        protected override void OnValueChanged(EventArgs eventargs)
        {
            base.OnValueChanged(eventargs);
            this.Invalidate();
        }

        protected override void OnFormatChanged(EventArgs e)
        {
            base.OnFormatChanged(e);
            this.Invalidate();
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);
            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rectSurface = this.ClientRectangle;
            Rectangle rectBorder = Rectangle.Inflate(rectSurface, -borderSize, -borderSize);

            bool rtl = this.RightToLeft == RightToLeft.Yes;
            bool showCheck = this.ShowCheckBox;
            Color backCol = this.Enabled ? this.BackColor : SystemColors.Control;
            Color foreCol = this.Enabled ? this.ForeColor : SystemColors.GrayText;
            // Onay kutusu işaretli değilse normal DateTimePicker gibi metin soluk görünür
            Color textCol = (showCheck && !this.Checked) ? SystemColors.GrayText : foreCol;

            using (GraphicsPath pathSurface = GetFigurePath(rectSurface, borderRadius))
            using (GraphicsPath pathBorder = GetFigurePath(rectBorder, borderRadius - borderSize > 0 ? borderRadius - borderSize : 0))
            using (Pen penBorder = new Pen(borderColor, borderSize))
            using (SolidBrush brushSurface = new SolidBrush(backCol))
            using (SolidBrush textBrush = new SolidBrush(textCol))
            using (StringFormat format = new StringFormat { LineAlignment = StringAlignment.Center })
            {
                // Arka planı ve kavisli kenarları çiz
                this.Region = new Region(pathSurface);
                e.Graphics.FillPath(brushSurface, pathSurface);

                if (borderSize >= 1)
                {
                    e.Graphics.DrawPath(penBorder, pathBorder);
                }

                format.Trimming = StringTrimming.EllipsisCharacter;
                format.FormatFlags = StringFormatFlags.NoWrap;
                if (rtl)
                {
                    format.FormatFlags |= StringFormatFlags.DirectionRightToLeft;
                }

                int checkW = showCheck ? 21 : 0;

                // ShowCheckBox: sol (RTL'de sağ) tarafa onay kutusu çiz
                if (showCheck)
                {
                    int boxX = rtl ? this.Width - 8 - 13 : 8;
                    Rectangle box = new Rectangle(boxX, (this.Height - 13) / 2, 13, 13);
                    using (Pen boxPen = new Pen(foreCol, 1f))
                    {
                        e.Graphics.DrawRectangle(boxPen, box);
                        if (this.Checked)
                        {
                            using (Pen tickPen = new Pen(foreCol, 1.6f))
                            {
                                e.Graphics.DrawLines(tickPen, new Point[]
                                {
                  new Point(box.X + 3, box.Y + 7),
                  new Point(box.X + 5, box.Y + 9),
                  new Point(box.X + 10, box.Y + 3)
                                });
                            }
                        }
                    }
                }

                // Seçili tarihi çiz
                int textX;
                int textW;
                if (rtl)
                {
                    textX = 25;
                    textW = this.Width - 25 - 10 - checkW;
                }
                else
                {
                    textX = 10 + checkW;
                    textW = this.Width - 35 - checkW;
                }
                if (textW < 1) textW = 1;

                Rectangle textRect = new Rectangle(textX, 0, textW, this.Height);
                e.Graphics.DrawString(this.Text, this.Font, textBrush, textRect, format);

                // Sağ (RTL'de sol) tarafa ikon çiz
                int iconSize = 14;
                int iconX = rtl ? 10 : this.Width - iconSize - 10;
                Rectangle iconRect = new Rectangle(iconX, (this.Height - iconSize) / 2, iconSize, iconSize);

                if (this.ShowUpDown)
                {
                    // ShowUpDown: takvim yerine yukarı/aşağı oklar
                    int cx = iconRect.X + (iconRect.Width / 2);
                    int cy = iconRect.Y + (iconRect.Height / 2);
                    using (SolidBrush arrowBrush = new SolidBrush(foreCol))
                    {
                        e.Graphics.FillPolygon(arrowBrush, new Point[]
                        {
              new Point(cx - 4, cy - 2),
              new Point(cx + 4, cy - 2),
              new Point(cx, cy - 6)
                        });
                        e.Graphics.FillPolygon(arrowBrush, new Point[]
                        {
              new Point(cx - 4, cy + 2),
              new Point(cx + 4, cy + 2),
              new Point(cx, cy + 6)
                        });
                    }
                }
                else
                {
                    // Minimalist takvim ikonu
                    using (Pen iconPen = new Pen(foreCol, 1.5f))
                    {
                        e.Graphics.DrawRectangle(iconPen, iconRect.X, iconRect.Y + 2, iconRect.Width, iconRect.Height - 2);
                        e.Graphics.DrawLine(iconPen, iconRect.X, iconRect.Y + 6, iconRect.Right, iconRect.Y + 6);
                        e.Graphics.DrawLine(iconPen, iconRect.X + 3, iconRect.Y, iconRect.X + 3, iconRect.Y + 4);
                        e.Graphics.DrawLine(iconPen, iconRect.Right - 3, iconRect.Y, iconRect.Right - 3, iconRect.Y + 4);
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
}