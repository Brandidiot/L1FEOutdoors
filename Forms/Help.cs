using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace L1FEOutdoors
{
    public partial class Help : Form
    {
        public Help()
        {
            InitializeComponent();
        }

        private void LoadTheme()
        {
            foreach (Control btns in this.panelInfo.Controls)
            {
                if (btns.GetType() != typeof(Button)) continue;

                var btn = (Button)btns;

                btn.BackColor = ThemeColor.PrimaryColor;
                btn.ForeColor = Color.White;
                btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
            }
        }

        private void Help_Load(object sender, EventArgs e)
        {
            LoadTheme();
        }

        //Square Count
        private void button1_Click(object sender, EventArgs e)
        {
            labelCSV.Text = @"Square.csv" + Environment.NewLine + @"InvQtys.csv";

            labelBody.Text = @"-Download Square item library and save as Square.csv in C:/Documents." + Environment.NewLine +
                             @"-Export Fishbowl Inventory Quantities and save as InvQtys.csv in C:/Documents." + Environment.NewLine +
                             @"-Open InvQtys.csv in Excel and consolidate all data to combine location quantities." + Environment.NewLine +
                             @"-Save InvQtys.csv and now you should be good to use Square Recount.";
        }

        //Recount
        private void button2_Click(object sender, EventArgs e)
        {
            labelCSV.Text = @"Recounted.csv";

            labelBody.Text = @"-Save Fishbowl Available Cycle Count List report as Recount.csv in C:/Documents." + Environment.NewLine +
                             @"-Open Recount.csv in Excel" + Environment.NewLine +
                             @"-Delete rows 1-4 and column B and D." + Environment.NewLine +
                             @"-Make headers in row A as Part, Available, UOM, Count, and Location" + Environment.NewLine +
                             @"-Select column B and delete all blank cell rows." + Environment.NewLine +
                             @"-Save Recount.csv and now you should be good to use Recount.";
        }

        //Check Square
        private void button3_Click(object sender, EventArgs e)
        {
            labelCSV.Text = @"Square.csv" + Environment.NewLine +
                            @"InvQtys.csv";

            labelBody.Text = @"-Download Square item library and save as Square.csv in C:/Documents." + Environment.NewLine +
                             @"-Export Fishbowl Inventory Quantities and save as InvQtys.csv in C:/Documents." + Environment.NewLine +
                             @"-Open InvQtys.csv in Excel and consolidate all data to combine location quantities." + Environment.NewLine +
                             @"-Save InvQtys.csv and now you should be good to use Check Square.";
        }

        public void UpdateRequired(string text)
        {
            labelCSV.Text = text;
        }

        public void UpdateBody(string text)
        {
            labelBody.Text = text;
        }

        public void UpdateTitle(string text)
        {
            txtTitle.Text = text;
        }
    }
}
