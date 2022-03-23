using System;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using L1FEOutdoors.Forms;
using L1FEOutdoors.Properties;

namespace L1FEOutdoors
{
    public partial class ModernMenu : Form
    {
        private Button _currentButton;
        private Random _randomColor;
        private int _tempIndex;
        private Form _activeForm;

        public ModernMenu()
        {
            InitializeComponent();
            _randomColor = new Random();
            btnCloseChildForm.Visible = false;
            this.Text = string.Empty;
            this.ControlBox = false;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;

            //LOMessageBox.Show(VersionLabel);
            lblVersion.Text = VersionLabel;
            if (Settings.Default.FirstRun != true) return;
            //lblGreetings.Text = "Welcome New User";
            //Change the value since the program has run once now
            Settings.Default.FirstRun = false;
            Settings.Default.Save();
            LOMessageBox.Show("Updated All Files And Settings", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public string VersionLabel
{
    get
    {
        if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
        {
            Version ver = System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion;
            return string.Format("{0}.{1}.{2}.{3}", ver.Major, ver.Minor, ver.Build, ver.Revision);
        }
        else
        {
            var ver = Assembly.GetExecutingAssembly().GetName().Version;
            return string.Format("{0}.{1}.{2}.{3}", ver.Major, ver.Minor, ver.Build, ver.Revision);
        }
    }
}

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

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
            if (_currentButton == (Button) btnSender) return;

            var color = SelectThemeColor();

            DeactivateButton();
            _currentButton = (Button) btnSender;
            _currentButton.BackColor = color;
            _currentButton.ForeColor = Color.White;
            _currentButton.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            panelTitleBar.BackColor = color;
            //panelLogo.BackColor = ThemeColor.ChangeColorBrightness(color, -0.2f);

            ThemeColor.PrimaryColor = color;
            ThemeColor.SecondaryColor = ThemeColor.ChangeColorBrightness(color, -0.3f);

            btnCloseChildForm.Visible = true;
            btnCloseChildForm.BackColor = ThemeColor.PrimaryColor;
            btnMinimize.BackColor = ThemeColor.PrimaryColor;
            btnClose.BackColor = ThemeColor.PrimaryColor;
        }
        private void DeactivateButton()
        {
            foreach (Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn.GetType() != typeof(Button)) continue;

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
            btnMinimize.BackColor = Color.FromArgb(36, 53, 73);
            btnClose.BackColor = Color.FromArgb(36, 53, 73);
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

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Help(), sender);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ProductPrice(), sender);
        }
    }
}