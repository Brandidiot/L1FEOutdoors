using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace L1FEOutdoors.Forms
{
    public partial class Payment : Form
    {
        public Payment()
        {
            InitializeComponent();
            dateTimePicker1.Value = DateTime.Now.AddDays(-1);
            dateTimePicker2.Value = DateTime.Now;
        }

        private void fileSystemWatcher1_Changed(object sender, System.IO.FileSystemEventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
        }

        private async void Payment_Shown(object sender, EventArgs e)
        {
            FormatDataGridView();

            var beginDate =
                dateTimePicker1.Value.ToString("yyyy-MM-dd'T'HH:mm:ss.fffzzz", DateTimeFormatInfo.InvariantInfo);
            var endDate =
                dateTimePicker2.Value.ToString("yyyy-MM-dd'T'HH:mm:ss.fffzzz", DateTimeFormatInfo.InvariantInfo);

            if (Program.IsConnectedToInternet())
            {
                var backgroundWorker = new Forms.BackgroundWorker();
                BeginInvoke(new Action(() => backgroundWorker.Show()));
                //paymentGridView.Columns.Remove("VariationName");
                //dgSquareCount.Columns.Remove("Category");
                var program = new Program();
                var progressReport = new Progress<int>(backgroundWorker.ReportProcessingProgress);
                var test = await program.RetrievePaymentsAsync(beginDate, endDate, progressReport, backgroundWorker);

                paymentGridView.DataSource = test;
            }
            else
            {
                LOMessageBox.Show("Cannot Connect To Square.");
            }
            UseWaitCursor = false;
            Program.FormProvider.ModernMenu.UpdateButtons();
        }

        private void FormatDataGridView()
        {
            paymentGridView.ColumnHeadersDefaultCellStyle.BackColor = ThemeColor.PrimaryColor;
            paymentGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            paymentGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            paymentGridView.EnableHeadersVisualStyles = false;
            paymentGridView.BorderStyle = BorderStyle.None;
            paymentGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            paymentGridView.CellBorderStyle = DataGridViewCellBorderStyle.None;
            paymentGridView.DefaultCellStyle.SelectionBackColor = ThemeColor.SecondaryColor;
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            Program.FormProvider.ModernMenu.UpdateButtons();

            var beginDate =
                dateTimePicker1.Value.ToString("yyyy-MM-dd'T'HH:mm:ss.fffzzz", DateTimeFormatInfo.InvariantInfo);
            var endDate =
                dateTimePicker2.Value.ToString("yyyy-MM-dd'T'HH:mm:ss.fffzzz", DateTimeFormatInfo.InvariantInfo);

            if (Program.IsConnectedToInternet())
            {
                var backgroundWorker = new Forms.BackgroundWorker();
                BeginInvoke(new Action(() => backgroundWorker.Show()));
                //paymentGridView.Columns.Remove("VariationName");
                //dgSquareCount.Columns.Remove("Category");
                var program = new Program();
                var progressReport = new Progress<int>(backgroundWorker.ReportProcessingProgress);
                var test = await program.RetrievePaymentsAsync(beginDate, endDate, progressReport, backgroundWorker);

                paymentGridView.DataSource = test;
            }
            else
            {
                LOMessageBox.Show("Cannot Connect To Square.");
            }
            UseWaitCursor = false;
            Program.FormProvider.ModernMenu.UpdateButtons();
        }
    }
}
