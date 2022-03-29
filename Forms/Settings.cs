using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;

namespace L1FEOutdoors.Forms
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void Settings_Shown(object sender, EventArgs e)
        {
            chkRandom.CheckState = Properties.Settings.Default.RandomColor ? CheckState.Checked : CheckState.Unchecked;
            btnPPColor.BackColor = Properties.Settings.Default.PPColor;
            btnCSColor.BackColor = Properties.Settings.Default.CSColor;
            btnHColor.BackColor = Properties.Settings.Default.HColor;
            btnRColor.BackColor = Properties.Settings.Default.RColor;
            btnSColor.BackColor = Properties.Settings.Default.SColor;
            btnSRColor.BackColor = Properties.Settings.Default.SRColor;

            ButtonsEnabled();
        }

        private void chkRandom_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.RandomColor = chkRandom.Checked;
            Properties.Settings.Default.Save();
            ButtonsEnabled();
        }

        private void ButtonsEnabled()
        {
            if (chkRandom.Checked)
            {
                foreach (var btn in panel.Controls.OfType<IconButton>())
                {
                    btn.Enabled = false;
                }
            }
            else
            {
                foreach (var btn in panel.Controls.OfType<IconButton>())
                {
                    btn.Enabled = true;
                }
            }
        }

        private void btnPPColor_Click(object sender, EventArgs e)
        {
            PPColor.ShowDialog();
            btnPPColor.BackColor = PPColor.Color;
            Properties.Settings.Default.PPColor = PPColor.Color;
            Properties.Settings.Default.Save();
        }

        private void btnCSColor_Click(object sender, EventArgs e)
        {
            CSColor.ShowDialog();
            btnCSColor.BackColor = CSColor.Color;
            Properties.Settings.Default.CSColor = CSColor.Color;
            Properties.Settings.Default.Save();
        }

        private void btnRColor_Click(object sender, EventArgs e)
        {
            RColor.ShowDialog();
            btnRColor.BackColor = RColor.Color;
            Properties.Settings.Default.RColor = RColor.Color;
            Properties.Settings.Default.Save();
        }

        private void btnSRColor_Click(object sender, EventArgs e)
        {
            SRColor.ShowDialog();
            btnSRColor.BackColor = SRColor.Color;
            Properties.Settings.Default.SRColor = SRColor.Color;
            Properties.Settings.Default.Save();
        }

        private void btnSColor_Click(object sender, EventArgs e)
        {
            SColor.ShowDialog();
            btnSColor.BackColor = SColor.Color;
            Properties.Settings.Default.SColor = SColor.Color;
            Properties.Settings.Default.Save();
        }

        private void btnHColor_Click(object sender, EventArgs e)
        {
            HColor.ShowDialog();
            btnHColor.BackColor = HColor.Color;
            Properties.Settings.Default.HColor = HColor.Color;
            Properties.Settings.Default.Save();
        }
    }
}
