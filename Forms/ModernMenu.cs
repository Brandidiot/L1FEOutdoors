using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using FontAwesome.Sharp;
using L1FEOutdoors.Forms;
using L1FEOutdoors.LOControls;

namespace L1FEOutdoors
{
    public partial class ModernMenu : Form
    {
        private IconButton _currentButton;
        private Random _randomColor;
        private int _tempIndex;
        private Form _activeForm;
        private readonly string _update = "-Daily Inventory Availability And Product Pricing Update.";
        private Size _formSize;

        public ModernMenu()
        {
            InitializeComponent();
            _randomColor = new Random();
            btnCloseChildForm.Visible = false;
            this.Text = string.Empty;
            //this.ControlBox = false;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            this.WindowState = FormWindowState.Maximized;
        }

        public string VersionLabel
{
    get
    {
        if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
        {
            var ver = System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion;
            return $"{ver.Major}.{ver.Minor}.{ver.Build}.{ver.Revision}";
        }
        else
        {
            var ver = Assembly.GetExecutingAssembly().GetName().Version;
            return $"{ver.Major}.{ver.Minor}.{ver.Build}.{ver.Revision}";
        }
    }
}

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private static extern void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private static extern void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        //Random Color
        private Color SelectThemeColor()
        {
            var index = _randomColor.Next(ThemeColor.ColorList.Count);

            while (_tempIndex == index)
            {
               index = _randomColor.Next(ThemeColor.ColorList.Count);
            }

            _tempIndex = index;
            var color = ThemeColor.ColorList[index];
            return ColorTranslator.FromHtml(color);
        }

        //Active Button
        private void ActivateButton(object btnSender)
        {
            if (btnSender == null) return;
            if (_currentButton == (IconButton) btnSender) return;
            
            if (Properties.Settings.Default.RandomColor)
            {
                var color = SelectThemeColor();

                DeactivateButton();
                _currentButton = (IconButton) btnSender;
                _currentButton.BackColor = color;
                _currentButton.ForeColor = Color.White;
                _currentButton.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte) (0)));
                panelTitleBar.BackColor = color;
                //iconButton1.BackColor = color;
                //panelLogo.BackColor = ThemeColor.ChangeColorBrightness(color, -0.2f);

                ThemeColor.PrimaryColor = color;
                ThemeColor.SecondaryColor = ThemeColor.ChangeColorBrightness(color, -0.3f);

                btnCloseChildForm.Visible = true;
                btnCloseChildForm.BackColor = color;
                //btnMin.BackColor = ThemeColor.PrimaryColor;
                //btnClose.BackColor = ThemeColor.PrimaryColor;
            }
            else
            {
                switch (((IconButton)btnSender).Name)
                {
                    case "btnPricing":
                    {
                        var color = Properties.Settings.Default.PPColor;

                        DeactivateButton();
                        _currentButton = (IconButton)btnSender;
                        _currentButton.BackColor = color;
                        _currentButton.ForeColor = Color.White;
                        _currentButton.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                        panelTitleBar.BackColor = color;
                        //iconButton1.BackColor = color;
                        //panelLogo.BackColor = ThemeColor.ChangeColorBrightness(color, -0.2f);

                        ThemeColor.PrimaryColor = color;
                        ThemeColor.SecondaryColor = ThemeColor.ChangeColorBrightness(color, -0.3f);

                        btnCloseChildForm.Visible = true;
                        btnCloseChildForm.BackColor = color;
                        break;
                    }
                    case "btnCheckSquare":
                    {
                        var color = Properties.Settings.Default.CSColor;

                        DeactivateButton();
                        _currentButton = (IconButton)btnSender;
                        _currentButton.BackColor = color;
                        _currentButton.ForeColor = Color.White;
                        _currentButton.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                        panelTitleBar.BackColor = color;
                        //iconButton1.BackColor = color;
                        //panelLogo.BackColor = ThemeColor.ChangeColorBrightness(color, -0.2f);

                        ThemeColor.PrimaryColor = color;
                        ThemeColor.SecondaryColor = ThemeColor.ChangeColorBrightness(color, -0.3f);

                        btnCloseChildForm.Visible = true;
                        btnCloseChildForm.BackColor = color;
                            break;
                    }
                    case "btnRecount":
                    {
                        var color = Properties.Settings.Default.RColor;

                        DeactivateButton();
                        _currentButton = (IconButton)btnSender;
                        _currentButton.BackColor = color;
                        _currentButton.ForeColor = Color.White;
                        _currentButton.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                        panelTitleBar.BackColor = color;
                        //iconButton1.BackColor = color;
                        //panelLogo.BackColor = ThemeColor.ChangeColorBrightness(color, -0.2f);

                        ThemeColor.PrimaryColor = color;
                        ThemeColor.SecondaryColor = ThemeColor.ChangeColorBrightness(color, -0.3f);

                        btnCloseChildForm.Visible = true;
                        btnCloseChildForm.BackColor = color;
                            break;
                    }
                    case "btnSquareRecount":
                    {
                        var color = Properties.Settings.Default.SRColor;

                        DeactivateButton();
                        _currentButton = (IconButton)btnSender;
                        _currentButton.BackColor = color;
                        _currentButton.ForeColor = Color.White;
                        _currentButton.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                        panelTitleBar.BackColor = color;
                        //iconButton1.BackColor = color;
                        //panelLogo.BackColor = ThemeColor.ChangeColorBrightness(color, -0.2f);

                        ThemeColor.PrimaryColor = color;
                        ThemeColor.SecondaryColor = ThemeColor.ChangeColorBrightness(color, -0.3f);

                        btnCloseChildForm.Visible = true;
                        btnCloseChildForm.BackColor = color;
                            break;
                    }
                    case "btnSettings":
                    {
                        var color = Properties.Settings.Default.SColor;

                        DeactivateButton();
                        _currentButton = (IconButton)btnSender;
                        _currentButton.BackColor = color;
                        _currentButton.ForeColor = Color.White;
                        _currentButton.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                        panelTitleBar.BackColor = color;
                        //iconButton1.BackColor = color;
                        //panelLogo.BackColor = ThemeColor.ChangeColorBrightness(color, -0.2f);

                        ThemeColor.PrimaryColor = color;
                        ThemeColor.SecondaryColor = ThemeColor.ChangeColorBrightness(color, -0.3f);

                        btnCloseChildForm.Visible = true;
                        btnCloseChildForm.BackColor = color;
                            break;
                    }
                    case "btnHelp":
                    {
                        var color = Properties.Settings.Default.HColor;

                        DeactivateButton();
                        _currentButton = (IconButton)btnSender;
                        _currentButton.BackColor = color;
                        _currentButton.ForeColor = Color.White;
                        _currentButton.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                        panelTitleBar.BackColor = color;
                        //iconButton1.BackColor = color;
                        //panelLogo.BackColor = ThemeColor.ChangeColorBrightness(color, -0.2f);

                        ThemeColor.PrimaryColor = color;
                        ThemeColor.SecondaryColor = ThemeColor.ChangeColorBrightness(color, -0.3f);

                        btnCloseChildForm.Visible = true;
                        btnCloseChildForm.BackColor = color;
                            break;
                    }
                }
            }
        }
        private void DeactivateButton()
        {
            foreach (Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn.GetType() != typeof(IconButton)) continue;

                previousBtn.BackColor = Color.FromArgb(51, 51, 76);
                previousBtn.ForeColor = Color.Gainsboro;
                previousBtn.Font = new Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            }
        }
        private void OpenChildForm(Form childForm, Object btnSender)
        {
            _activeForm?.Close();

            ActivateButton(btnSender);
            _activeForm = childForm;

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            panelDesktop.Controls.Add(childForm);
            panelDesktop.Tag = childForm;

            childForm.BringToFront();
            childForm.Show();

            lblTitle.Text = childForm.Text;
        }

        private void btnSquareRecount_Click(object sender, EventArgs e)
        {
            if (CheckForRecount()) return;
            OpenChildForm(new SquareCount(),sender);
            this.Size = new Size(1000, 500);
        }

        private void btnRecount_Click(object sender, EventArgs e)
        {
            if (CheckForRecount()) return;
            OpenChildForm(new Recount(), sender);
            this.Size = new Size(1150, 500);
        }

        private void btnCheckSquare_Click(object sender, EventArgs e)
        {
            if (CheckForRecount()) return;
            OpenChildForm(new CheckSquare(), sender);
            this.Size = new Size(900, 500);
        }

        private void btnCloseChildForm_Click(object sender, EventArgs e)
        {
            if (_activeForm == null) return;

            CheckForRecount();
        }

        private bool CheckForRecount()
        {
            if (_activeForm == null) return false;

            if (_activeForm.Text == @"Square Recount" || _activeForm.Text == @"Recount")
            {
                var dialogResult = LOMessageBox.Show("Do you need to save the data? \n If so please click Export!",
                    "Save Data?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                if (dialogResult == DialogResult.Yes) return true;

                _activeForm.Close();
                Reset();
            }
            else
            {
                _activeForm.Close();
                Reset();
                return false;
            }

            return false;
        }

        private void Reset()
        {
            DeactivateButton();
            lblTitle.Text = "HOME";
            panelTitleBar.BackColor = Color.FromArgb(36, 53, 73);
            _currentButton = null;
            btnCloseChildForm.Visible = false;
            this.Size = new Size(800, 500);
            //btnMin.BackColor = Color.FromArgb(36, 53, 73);
            //btnClose.BackColor = Color.FromArgb(36, 53, 73);
        }

        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle,0x112,0xf012,0);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            var dialogResult = LOMessageBox.Show(@"Are you sure you want to close the application?",
                "Close?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

            if (dialogResult != DialogResult.Yes) return;
            Application.Exit();
        }
        
        private void btnHelp_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Help(), sender);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ProductPrice(), sender);
        }

        private void ModernMenu_Shown(object sender, EventArgs e)
        {
            //LOMessageBox.Show(VersionLabel);
            lblVersion.Text = VersionLabel;
            if (Properties.Settings.Default.Version == VersionLabel) return;
            //lblGreetings.Text = "Welcome New User";
            //Change the value since the program has run once now
            Properties.Settings.Default.Version = VersionLabel;
            Properties.Settings.Default.Save();
            LOUpdateBox.Show(_update, "Updated To " + VersionLabel, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #region Windows Stuff
        //Overridden methods
        protected override void WndProc(ref Message m)
        {
            const int WM_NCCALCSIZE = 0x0083;//Standar Title Bar - Snap Window
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_MINIMIZE = 0xF020; //Minimize form (Before)
            const int SC_RESTORE = 0xF120; //Restore form (Before)
            const int WM_NCHITTEST = 0x0084;//Win32, Mouse Input Notification: Determine what part of the window corresponds to a point, allows to resize the form.
            const int resizeAreaSize = 10;
            #region Form Resize
            // Resize/WM_NCHITTEST values
            const int HTCLIENT = 1; //Represents the client area of the window
            const int HTLEFT = 10;  //Left border of a window, allows resize horizontally to the left
            const int HTRIGHT = 11; //Right border of a window, allows resize horizontally to the right
            const int HTTOP = 12;   //Upper-horizontal border of a window, allows resize vertically up
            const int HTTOPLEFT = 13;//Upper-left corner of a window border, allows resize diagonally to the left
            const int HTTOPRIGHT = 14;//Upper-right corner of a window border, allows resize diagonally to the right
            const int HTBOTTOM = 15; //Lower-horizontal border of a window, allows resize vertically down
            const int HTBOTTOMLEFT = 16;//Lower-left corner of a window border, allows resize diagonally to the left
            const int HTBOTTOMRIGHT = 17;//Lower-right corner of a window border, allows resize diagonally to the right
            ///<Doc> More Information: https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-nchittest </Doc>
            if (m.Msg == WM_NCHITTEST)
            { //If the windows m is WM_NCHITTEST
                base.WndProc(ref m);
                if (this.WindowState == FormWindowState.Normal)//Resize the form if it is in normal state
                {
                    if ((int)m.Result == HTCLIENT)//If the result of the m (mouse pointer) is in the client area of the window
                    {
                        Point screenPoint = new Point(m.LParam.ToInt32()); //Gets screen point coordinates(X and Y coordinate of the pointer)                           
                        Point clientPoint = this.PointToClient(screenPoint); //Computes the location of the screen point into client coordinates                          
                        if (clientPoint.Y <= resizeAreaSize)//If the pointer is at the top of the form (within the resize area- X coordinate)
                        {
                            if (clientPoint.X <= resizeAreaSize) //If the pointer is at the coordinate X=0 or less than the resizing area(X=10) in 
                                m.Result = (IntPtr)HTTOPLEFT; //Resize diagonally to the left
                            else if (clientPoint.X < (this.Size.Width - resizeAreaSize))//If the pointer is at the coordinate X=11 or less than the width of the form(X=Form.Width-resizeArea)
                                m.Result = (IntPtr)HTTOP; //Resize vertically up
                            else //Resize diagonally to the right
                                m.Result = (IntPtr)HTTOPRIGHT;
                        }
                        else if (clientPoint.Y <= (this.Size.Height - resizeAreaSize)) //If the pointer is inside the form at the Y coordinate(discounting the resize area size)
                        {
                            if (clientPoint.X <= resizeAreaSize)//Resize horizontally to the left
                                m.Result = (IntPtr)HTLEFT;
                            else if (clientPoint.X > (this.Width - resizeAreaSize))//Resize horizontally to the right
                                m.Result = (IntPtr)HTRIGHT;
                        }
                        else
                        {
                            if (clientPoint.X <= resizeAreaSize)//Resize diagonally to the left
                                m.Result = (IntPtr)HTBOTTOMLEFT;
                            else if (clientPoint.X < (this.Size.Width - resizeAreaSize)) //Resize vertically down
                                m.Result = (IntPtr)HTBOTTOM;
                            else //Resize diagonally to the right
                                m.Result = (IntPtr)HTBOTTOMRIGHT;
                        }
                    }
                }
                return;
            }
            #endregion
            //Remove border and keep snap window
            if (m.Msg == WM_NCCALCSIZE && m.WParam.ToInt32() == 1)
            {
                return;
            }
            //Keep form size when it is minimized and restored. Since the form is resized because it takes into account the size of the title bar and borders.
            if (m.Msg == WM_SYSCOMMAND)
            {
                /// <see cref="https://docs.microsoft.com/en-us/windows/win32/menurc/wm-syscommand"/>
                /// Quote:
                /// In WM_SYSCOMMAND messages, the four low - order bits of the wParam parameter 
                /// are used internally by the system.To obtain the correct result when testing 
                /// the value of wParam, an application must combine the value 0xFFF0 with the 
                /// wParam value by using the bitwise AND operator.
                int wParam = (m.WParam.ToInt32() & 0xFFF0);
                if (wParam == SC_MINIMIZE)  //Before
                    _formSize = this.ClientSize;
                if (wParam == SC_RESTORE)// Restored form(Before)
                    this.Size = _formSize;
            }
            base.WndProc(ref m);
        }

        private void ModernMenu_Resize(object sender, EventArgs e)
        {
            AdjustForm();
        }

        private void AdjustForm()
        {
            switch (this.WindowState)
            {
                case FormWindowState.Maximized: //Maximized form (After)
                    this.Padding = new Padding(8, 8, 8, 8);
                    break;
                case FormWindowState.Normal: //Restored form (After)
                    if (this.Padding.Top != 2)
                        this.Padding = new Padding(2);
                    break;
            }
        }
        #endregion

        private void btnMax_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                _formSize = this.ClientSize;
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                this.Size = _formSize;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void CollapseMenu()
        {
            if (this.panelMenu.Width > 200)
            {
                panelMenu.Width = 50;
                btnMenu.Dock = DockStyle.Fill;
                label1.Visible = false;
                //label1.Dock = DockStyle.Fill;
                foreach (IconButton btn in panelMenu.Controls.OfType<IconButton>())
                {
                    btn.Text = "";
                    btn.ImageAlign = ContentAlignment.MiddleCenter;
                    btn.Padding = new Padding(0);
                }
            }
            else
            {
                panelMenu.Width = 220;
                btnMenu.Dock = DockStyle.None;
                label1.Visible = true;
                //label1.Dock = DockStyle.Fill;
                foreach (IconButton btn in panelMenu.Controls.OfType<IconButton>())
                {
                    btn.Text = btn.Tag.ToString();
                    btn.ImageAlign = ContentAlignment.MiddleLeft;
                    btn.Padding = new Padding(0,0,0,0);
                }
            }
        }

        #region Button Stuff
        private void btnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btn_MouseEnter(object sender, EventArgs e)
        {
            var btn = sender as IconButton;
            btn.IconColor = Color.Gainsboro;
        }

        private void btn_MouseLeave(object sender, EventArgs e)
        {
            var btn = sender as IconButton;
            btn.IconColor = Color.White;
        }

        private void btn_MouseDown(object sender, MouseEventArgs e)
        {
            var btn = sender as IconButton;
            btn.IconColor = Color.DarkGray;
        }
        #endregion

        private void btnMenu_Click(object sender, EventArgs e)
        {
            CollapseMenu();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.Settings(), sender);
        }


    }
}