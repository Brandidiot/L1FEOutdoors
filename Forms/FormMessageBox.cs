using System.Drawing;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace L1FEOutdoors
{
    public partial class FormMessageBox : Form
    {
        private Color _primaryColor = Color.CornflowerBlue;
        private int _borderSize = 2;

        public Color PrimaryColor
        {
            get => _primaryColor;

            set
            {
                _primaryColor = value;
                this.BackColor = _primaryColor;
                this.panelTitleBar.BackColor = PrimaryColor;
            }
        }

        public FormMessageBox(string text)
        {
            InitializeComponent();
            InitializeItems();
            this.PrimaryColor = _primaryColor;
            this.lblMessage.Text = text;
            this.lblCaption.Text = "";
            SetFormSize();
            SetButtons(MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
        }

        public FormMessageBox(string text, string caption)
        {
            InitializeComponent();
            InitializeItems();
            this.PrimaryColor = _primaryColor;
            this.lblMessage.Text = text;
            this.lblCaption.Text = caption;
            SetFormSize();
            SetButtons(MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
        }

        public FormMessageBox(string text, string caption, MessageBoxButtons buttons)
        {
            InitializeComponent();
            InitializeItems();
            this.PrimaryColor = _primaryColor;
            this.lblMessage.Text = text;
            this.lblCaption.Text = caption;
            SetFormSize();
            SetButtons(buttons, MessageBoxDefaultButton.Button1);
        }

        public FormMessageBox(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            InitializeComponent();
            InitializeItems();
            this.PrimaryColor = _primaryColor;
            this.lblMessage.Text = text;
            this.lblCaption.Text = caption;
            SetFormSize();
            SetButtons(buttons, MessageBoxDefaultButton.Button1);
            SetIcon(icon);
        }

        public FormMessageBox(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton)
        {
            InitializeComponent();
            InitializeItems();
            this.PrimaryColor = _primaryColor;
            this.lblMessage.Text = text;
            this.lblCaption.Text = caption;
            SetFormSize();
            SetButtons(buttons, defaultButton);
            SetIcon(icon);
        }

        private void InitializeItems()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(_borderSize);
            this.lblMessage.MaximumSize = new Size(550, 0);
            this.btnClose.DialogResult = DialogResult.Cancel;
            this.button1.DialogResult = DialogResult.OK;
            this.button1.Visible = false;
            this.button2.Visible = false;
            this.button3.Visible = false;
        }

        private void SetFormSize()
        {
            var width = this.lblMessage.Width + this.pbIcon.Width + this.panelMessageBar.Padding.Left;
            var height = this.panelTitleBar.Height + this.lblMessage.Height + this.panelButtons.Height + this.panelMessageBar.Padding.Top;
            this.Size = new Size(width, height);
        }

        private void SetButtons(MessageBoxButtons buttons, MessageBoxDefaultButton defaultButton)
        {
            var xCenter = (this.panelButtons.Width - button1.Width) / 2;
            var yCenter = (this.panelButtons.Height - button1.Height) / 2;

            switch (buttons)
            {
                case MessageBoxButtons.OK:
                    //OK Button
                    button1.Visible = true;
                    button1.Location = new Point(xCenter, yCenter);
                    button1.Text = @"Ok";
                    button1.DialogResult = DialogResult.OK;

                    SetDefaultButton(defaultButton);
                    break;
                case MessageBoxButtons.OKCancel:
                    //OK Button
                    button1.Visible = true;
                    button1.Location = new Point(xCenter - (button1.Width / 2) - 5, yCenter);
                    button1.Text = @"Ok";
                    button1.DialogResult = DialogResult.OK;

                    //Cancel Button
                    button2.Visible = true;
                    button2.Location = new Point(xCenter + (button2.Width / 2) + 5, yCenter);
                    button2.Text = @"Cancel";
                    button2.DialogResult = DialogResult.Cancel;
                    button2.BackColor = Color.DimGray;

                    //Set Default Button
                    SetDefaultButton(defaultButton != MessageBoxDefaultButton.Button3 ? defaultButton : MessageBoxDefaultButton.Button1);
                    break;
                case MessageBoxButtons.RetryCancel:
                    //Retry Button
                    button1.Visible = true;
                    button1.Location = new Point(xCenter - (button1.Width / 2) - 5, yCenter);
                    button1.Text = @"Retry";
                    button1.DialogResult = DialogResult.Retry;

                    //Cancel Button
                    button2.Visible = true;
                    button2.Location = new Point(xCenter + (button2.Width / 2) + 5, yCenter);
                    button2.Text = @"Cancel";
                    button2.DialogResult = DialogResult.Cancel;
                    button2.BackColor = Color.DimGray;

                    //Set Default Button
                    SetDefaultButton(defaultButton != MessageBoxDefaultButton.Button3 ? defaultButton : MessageBoxDefaultButton.Button1);
                    break;

                case MessageBoxButtons.YesNo:
                    //Yes Button
                    button1.Visible = true;
                    button1.Location = new Point(xCenter - (button1.Width / 2) - 5,yCenter);
                    button1.Text = @"Yes";
                    button1.DialogResult = DialogResult.Yes;

                    //No Button
                    button2.Visible = true;
                    button2.Location = new Point(xCenter + (button2.Width / 2) + 5, yCenter);
                    button2.Text = @"No";
                    button2.DialogResult = DialogResult.No;
                    button2.BackColor = Color.IndianRed;

                    //Set Default Button
                    SetDefaultButton(defaultButton != MessageBoxDefaultButton.Button3 ? defaultButton : MessageBoxDefaultButton.Button1);
                    break;

                case MessageBoxButtons.YesNoCancel:
                    //Yes Button
                    button1.Visible = true;
                    button1.Location = new Point(xCenter - (button1.Width / 2) - 5, yCenter);
                    button1.Text = @"Yes";
                    button1.DialogResult = DialogResult.Yes;

                    //No Button
                    button2.Visible = true;
                    button2.Location = new Point(xCenter, yCenter);
                    button2.Text = @"No";
                    button2.DialogResult = DialogResult.No;
                    button2.BackColor = Color.IndianRed;

                    //Cancel Button
                    button3.Visible = true;
                    button3.Location = new Point(xCenter + (button3.Width / 2) + 5, yCenter);
                    button3.Text = @"Cancel";
                    button3.DialogResult = DialogResult.Cancel;
                    button3.BackColor = Color.DimGray;

                    //Set Default Button
                    SetDefaultButton(defaultButton);
                    break;

                case MessageBoxButtons.AbortRetryIgnore:
                    //Abort Button
                    button1.Visible = true;
                    button1.Location = new Point(xCenter - button1.Width - 5, yCenter);
                    button1.Text = "Abort";
                    button1.DialogResult = DialogResult.Abort;//Set DialogResult
                    button1.BackColor = Color.Goldenrod;
                    //Retry Button
                    button2.Visible = true;
                    button2.Location = new Point(xCenter, yCenter);
                    button2.Text = "Retry";
                    button2.DialogResult = DialogResult.Retry;//Set DialogResult                    
                    //Ignore Button
                    button3.Visible = true;
                    button3.Location = new Point(xCenter + button2.Width + 5, yCenter);
                    button3.Text = "Ignore";
                    button3.DialogResult = DialogResult.Ignore;//Set DialogResult
                    button3.BackColor = Color.IndianRed;
                    //Set Default Button
                    SetDefaultButton(defaultButton);
                    break;
            }
        }
        private void SetDefaultButton(MessageBoxDefaultButton defaultButton)
        {
            switch (defaultButton)
            {
                case MessageBoxDefaultButton.Button1://Focus button 1
                    button1.Select();
                    button1.ForeColor = Color.White;
                    button1.Font = new Font(button1.Font, FontStyle.Underline);
                    break;
                case MessageBoxDefaultButton.Button2://Focus button 2
                    button2.Select();
                    button2.ForeColor = Color.White;
                    button2.Font = new Font(button2.Font, FontStyle.Underline);
                    break;
                case MessageBoxDefaultButton.Button3://Focus button 3
                    button3.Select();
                    button3.ForeColor = Color.White;
                    button3.Font = new Font(button3.Font, FontStyle.Underline);
                    break;
            }
        }
        private void SetIcon(MessageBoxIcon icon)
        {
            switch (icon)
            {
                case MessageBoxIcon.Error:
                    this.pbIcon.Image = Properties.Resources.error;
                    PrimaryColor = Color.FromArgb(224, 79, 95);
                    this.btnClose.FlatAppearance.MouseOverBackColor = Color.Crimson;
                    break;
                case MessageBoxIcon.Information:
                    this.pbIcon.Image = Properties.Resources.information;
                    PrimaryColor = Color.FromArgb(38, 191, 166);
                    break;
                case MessageBoxIcon.Question:
                    this.pbIcon.Image = Properties.Resources.question;
                    PrimaryColor = Color.FromArgb(10, 119, 232);
                    break;
                case MessageBoxIcon.Exclamation:
                    this.pbIcon.Image = Properties.Resources.exclamation;
                    PrimaryColor = Color.FromArgb(255, 140, 0);
                    break;
                case MessageBoxIcon.None:
                    this.pbIcon.Image = Properties.Resources.chat;
                    PrimaryColor = Color.CornflowerBlue;
                    break;
            }
        }

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
        #region -> Drag Form
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private static extern void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private static extern void ReleaseCapture();
        private void panelTitleBar_MouseDown_1(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        #endregion
    }
}
