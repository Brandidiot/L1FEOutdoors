using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.Remoting.Messaging;
using System.Windows.Forms;

namespace L1FEOutdoors.LOControls
{
    [DefaultEvent("_TextChanged")]
    public partial class LOTextBox : UserControl
    {
        private Color _borderColor = ThemeColor.PrimaryColor;
        private Color _borderFocusColor = Color.HotPink;
        private int _borderSize = 2;
        private bool _underlinedStyle = false;
        private bool _isFocused = false;
        private int _borderRadius = 0;
        private Color _placeholderColor = Color.DarkGray;
        private string _placeholderText = "";
        private bool _isPlaceholder = false;
        private bool _isPasswordChar = false;

        public LOTextBox()
        {
            InitializeComponent();
        }

        //Events
        public event EventHandler _TextChanged;

        public Color BorderColor
        {
            get => _borderColor;
            set
            {
                _borderColor = value;
                this.Invalidate();
            }
        }

        public Color BorderFocusColor
        {
            get => _borderFocusColor;
            set
            {
                _borderFocusColor = value;
                this.Invalidate();
            }
        }

        public int BorderSize
        {
            get => _borderSize;
            set
            {
                _borderSize = value;
                this.Invalidate();
            }
        }

        public bool UnderlinedStyle
        {
            get => _underlinedStyle;
            set
            {
                _underlinedStyle = value;
                this.Invalidate();
            }
        }

        public int BorderRadius
        {
            get => _borderRadius;
            set
            {
                if (value >= 0)
                {
                    _borderRadius = value;
                    this.Invalidate();
                }
            }
        }

        public bool PasswordChar
        {
            get => _isPasswordChar;
            set
            {
                _isPasswordChar = value;
                textBox1.UseSystemPasswordChar = value;
            }
        }

        public override Color BackColor
        {
            get => base.BackColor;
            set
            {
                base.BackColor = value;
                textBox1.BackColor = value;
            }
        }

        public override Color ForeColor
        {
            get => base.ForeColor;
            set
            {
                base.ForeColor = value;
                textBox1.ForeColor = value;
            }
        }

        public override Font Font
        {
            get => base.Font;
            set
            {
                base.Font = value;
                textBox1.Font = value;
                if(this.DesignMode)
                    UpdateControlHeight();
            }
        }

        public string Texts
        {
            get => _isPlaceholder ? "" : textBox1.Text;
            set
            {
                textBox1.Text = value;
                SetPlaceholder();
            }
        }

        public Color PlaceHolderColor
        {
            get => _placeholderColor;
            set
            {
                _placeholderColor = value;
                if (_isPasswordChar)
                    textBox1.ForeColor = value;
            }
        }

        public string PlaceHolderText
        {
            get => _placeholderText;
            set
            {
                _placeholderText = value;
                textBox1.Text = "";
                SetPlaceholder();
            }
        }

        public bool MultiLine
        {
            get => textBox1.Multiline;
            set => textBox1.Multiline = value;
        }

        #region -> Overrides
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var graphics = e.Graphics;

            if (_borderRadius > 1) //Rounded
            {
                //Fields
                var rectBorderSmooth = this.ClientRectangle;
                var rectBorder = Rectangle.Inflate(rectBorderSmooth, -_borderSize, -_borderSize);
                var smoothSize = _borderSize > 0 ? _borderSize : 1;

                using (var pathBorderSmooth = GetFigurePath(rectBorderSmooth, _borderRadius))
                using(var pathBorder = GetFigurePath(rectBorder,_borderRadius - _borderSize)) 
                using (var penBorderSmooth = new Pen(this.Parent.BackColor,smoothSize))
                using (var penBorder = new Pen(_borderColor, _borderSize))
                {
                    //Draw
                    this.Region = new Region(pathBorderSmooth);
                    if (_borderRadius > 15) SetTextBoxRoundedRegion();
                    graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    
                    penBorder.Alignment = PenAlignment.Center;
                    if (_isFocused) penBorder.Color = _borderFocusColor;

                    if (_underlinedStyle)
                    {
                        graphics.DrawPath(penBorderSmooth,pathBorderSmooth);
                        graphics.SmoothingMode = SmoothingMode.None;
                        graphics.DrawLine(penBorder, 0, this.Height - 1, this.Width, this.Height - 1);
                    }
                    else
                    {
                        graphics.DrawPath(penBorderSmooth, pathBorderSmooth);
                        graphics.DrawPath(penBorder, pathBorder);
                    }
                }
            }
            else //Squared
            {
                using (var penBorder = new Pen(_borderColor, _borderSize))
                {
                    this.Region = new Region(this.ClientRectangle);

                    penBorder.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;

                    if (_underlinedStyle)
                    {
                        graphics.DrawLine(penBorder, 0, this.Height - 1, this.Width, this.Height - 1);
                    }
                    else
                    {
                        graphics.DrawRectangle(penBorder, 0, 0, this.Width - 0.5f, this.Height - 0.5f);
                    }
                }
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if(this.DesignMode)
                UpdateControlHeight();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            UpdateControlHeight();
        }
        #endregion

        #region -> Private Methods
        private void SetPlaceholder()
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text) || _placeholderText == "") return;
            _isPlaceholder = true;
            textBox1.Text = _placeholderText;
            textBox1.ForeColor = _placeholderColor;
            if (_isPasswordChar)
                textBox1.UseSystemPasswordChar = false;
        }
        private void RemovePlaceholder()
        {
            if (!_isPlaceholder || _placeholderText == "") return;
            _isPlaceholder = false;
            textBox1.Text = "";
            textBox1.ForeColor = this.ForeColor;
            if (_isPasswordChar)
                textBox1.UseSystemPasswordChar = true;
        }
        private GraphicsPath GetFigurePath(Rectangle rect, int radius)
        {
            var path = new GraphicsPath();
            var curveSize = radius * 2F;
            path.StartFigure();
            path.AddArc(rect.X, rect.Y, curveSize, curveSize, 180, 90);
            path.AddArc(rect.Right - curveSize, rect.Y, curveSize, curveSize, 270, 90);
            path.AddArc(rect.Right - curveSize, rect.Bottom - curveSize, curveSize, curveSize, 0, 90);
            path.AddArc(rect.X, rect.Bottom - curveSize, curveSize, curveSize, 90, 90);
            path.CloseFigure();
            return path;
        }
        private void SetTextBoxRoundedRegion()
        {
            GraphicsPath pathTxt;
            if (MultiLine)
            {
                pathTxt = GetFigurePath(textBox1.ClientRectangle, _borderRadius - _borderSize);
                textBox1.Region = new Region(pathTxt);
            }
            else
            {
                pathTxt = GetFigurePath(textBox1.ClientRectangle, _borderSize * 2);
                textBox1.Region = new Region(pathTxt);
            }
            pathTxt.Dispose();
        }
        private void UpdateControlHeight()
        {
            if (textBox1.Multiline != false) return;

            var txtHeight = TextRenderer.MeasureText("Text",this.Font).Height + 1;
            textBox1.Multiline = true;
            textBox1.MinimumSize = new Size(0, txtHeight);
            textBox1.Multiline = false;

            this.Height = textBox1.Height + this.Padding.Top + this.Padding.Bottom;
        }
        #endregion

        #region -> textBox1 Events
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            _TextChanged?.Invoke(sender, e);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.OnKeyPress(e);
        }

        private void textBox1_MouseEnter(object sender, EventArgs e)
        {
            this.OnMouseEnter(e);
        }

        private void textBox1_MouseLeave(object sender, EventArgs e)
        {
            this.OnMouseLeave(e);
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            _isFocused = true;
            this.Invalidate();
            RemovePlaceholder();
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            _isFocused = false;
            this.Invalidate();
            SetPlaceholder();
        }
        #endregion


    }
}
