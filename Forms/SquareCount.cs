using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using L1FEOutdoors.LOControls;

namespace L1FEOutdoors
{
    public partial class SquareCount : Form
    {
        public SquareCount()
        {
            InitializeComponent();

            UseWaitCursor = true;
        }

        private async void PopulateSquareInfo()
        {
            //Populate DataTable With Square Data
            try
            {
                await GenerateDT.GenerateDataTable(AppDomain.CurrentDomain.BaseDirectory + @"\Resources\Square.csv", dgSquareCount);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private async void PopulateInvQty()
        {
            try
            {
                //Get Data From InvQtys
                var dtNew = await GenerateDT.GetDataTabletFromCsvFile(AppDomain.CurrentDomain.BaseDirectory + @"\Resources\InvQtys.csv");

                foreach (DataGridViewRow rows in dgSquareCount.Rows)
                {
                    var sku = rows.Cells["SKU"].Value.ToString();
                    /*var contains = dtNew.AsEnumerable().Any(row => SKU == row.Field<String>("PartNumber"));

                    if (contains)
                        MessageBox.Show("Found SKU " + SKU + " in Row " + dtNew. );*/
                    if (dtNew.Select("PartNumber = '" + sku + "'").Length > 0)
                    {
                        var dr = dtNew.Select("PartNumber = '" + sku + "'");

                        var qty = dr[0]["Qty"].ToString();

                        //rows.Cells["FishbowlQty"].Value = "0";
                        rows.Cells["Qty"].Value = qty;
                        //MessageBox.Show(rows.Cells[0].Value.ToString());
                    }
                    else
                    {
                        rows.Cells["Qty"].Value = "0";
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            //var csvPath = @"C:\Users\" + Environment.UserName + @"\Documents\SquareCounted_" + DateTime.Now.ToString("M/d/yyyy") + ".csv";
            string csvPath;

            if (dgSquareCount.Rows.Count > 0)
            {
                var sfd = new SaveFileDialog();
                sfd.Filter = @"CSV (*.csv)|*.csv";

                var folderName = @"C:\Users\" + Environment.UserName + @"\Desktop\" + DateTime.Now.ToString("M/d/yyyy");

                if (File.Exists(folderName))
                {
                    csvPath = folderName + @"\SquareCounted_"+ DateTime.Now.ToString("hh") + DateTime.Now.ToString("tt") + ".csv";
                }
                else
                {
                    Directory.CreateDirectory(folderName);
                    csvPath = folderName + @"\SquareCounted_" + DateTime.Now.ToString("hh") + DateTime.Now.ToString("tt") + ".csv";
                }
                sfd.FileName = csvPath;

                var fileError = false;

                //if (sfd.ShowDialog() != DialogResult.OK) return;

                if (File.Exists(sfd.FileName))
                {
                    try
                    {
                        File.Delete(sfd.FileName);
                    }
                    catch (IOException ex)
                    {
                        fileError = true;
                        LOMessageBox.Show("It wasn't possible to write the data to the disk." + ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }

                if (fileError) return;
                {
                    try
                    {
                        var columnCount = dgSquareCount.Columns.Count;
                        var columnNames = "";
                        var outputCsv = new string[dgSquareCount.Rows.Count + 1];
                        for (var i = 0; i < columnCount; i++)
                        {
                            if (i == columnCount - 1)
                            {
                                columnNames += dgSquareCount.Columns[i].HeaderText;
                            }
                            else
                            {
                                columnNames += dgSquareCount.Columns[i].HeaderText + ",";
                            }
                        }
                        outputCsv[0] += columnNames;

                        for (var i = 1; i - 1 < dgSquareCount.Rows.Count; i++)
                        {
                            for (var j = 0; j < columnCount; j++)
                            {
                                if (dgSquareCount.Rows[i - 1].Cells["Product"].Value.ToString().Contains(","))
                                {
                                    if (j == columnCount - 1)
                                    {
                                        outputCsv[i] += dgSquareCount.Rows[i - 1].Cells[j].Value;
                                    }
                                    else if (j == 0)
                                    {
                                        if (dgSquareCount.Rows[i - 1].Cells["Product"].Value.ToString().Contains("\""))
                                        {
                                            var index = dgSquareCount.Rows[i - 1].Cells["Product"].Value.ToString().IndexOf("\"", StringComparison.Ordinal);
                                            outputCsv[i] += "\"" + dgSquareCount.Rows[i - 1].Cells[j].Value.ToString().Insert(index, "\"") + "\"" + ",";
                                        }
                                        else
                                        {
                                            outputCsv[i] += "\"" + dgSquareCount.Rows[i - 1].Cells[j].Value + "\"" + ",";
                                        }
                                    }
                                    else
                                    {
                                        outputCsv[i] += dgSquareCount.Rows[i - 1].Cells[j].Value + ",";
                                    }
                                }
                                else
                                {
                                    if (j == columnCount - 1)
                                    {
                                        outputCsv[i] += dgSquareCount.Rows[i - 1].Cells[j].Value;
                                    }
                                    else
                                    {
                                        outputCsv[i] += dgSquareCount.Rows[i - 1].Cells[j].Value + ",";
                                    }
                                }
                            }
                        }

                        File.WriteAllLines(sfd.FileName, outputCsv, Encoding.UTF8);
                        LOMessageBox.Show("Data Exported Successfully To " + csvPath, "Exported", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        LOMessageBox.Show("Error:" + ex.Message,"Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                LOMessageBox.Show("No Record To Export!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void LoadTheme()
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl.GetType() == typeof(Button))
                {

                    var btn = (Button)ctrl;

                    btn.BackColor = ThemeColor.PrimaryColor;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                }
                else if (ctrl.GetType() == typeof(LOTextBox))
                {
                    var box = (LOTextBox)ctrl;
                    box.BorderColor = ThemeColor.PrimaryColor;
                    box.BorderFocusColor = ThemeColor.SecondaryColor;
                }
            }
        }
        private void FormatDataGridView()
        {
            dgSquareCount.ColumnHeadersDefaultCellStyle.BackColor = ThemeColor.PrimaryColor;
            dgSquareCount.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgSquareCount.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgSquareCount.EnableHeadersVisualStyles = false;
            dgSquareCount.BorderStyle = BorderStyle.None;
            dgSquareCount.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            dgSquareCount.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgSquareCount.DefaultCellStyle.SelectionBackColor = ThemeColor.SecondaryColor;
        }

        private async void SquareCount_Shown(object sender, EventArgs e)
        {
            LoadTheme();
            FormatDataGridView();
            if (Program.IsConnectedToInternet())
            {
                var backgroundWorker = new Forms.BackgroundWorker();
                BeginInvoke(new Action(() => backgroundWorker.Show()));
                dgSquareCount.Columns.Remove("VariationName");
                //dgSquareCount.Columns.Remove("Category");
                var program = new Program();
                var progressReport = new Progress<int>(backgroundWorker.ReportProcessingProgress);
                var test = await program.RetrieveItemsAsync(progressReport, backgroundWorker);
                
                dgSquareCount.DataSource = test;
            }
            else
            {
                LOMessageBox.Show("Cannot Connect To Square. Using Stored Data");
                PopulateSquareInfo();
                PopulateInvQty();
                UpdateColumns();
            }
            UseWaitCursor = false;
            Program.FormProvider.ModernMenu.UpdateButtons();
        }

        private void UpdateColumns()
        {
            //Remove Useless Columns
            dgSquareCount.Columns.Remove("Token");
            dgSquareCount.Columns.Remove("Description");
            dgSquareCount.Columns.Remove("Price");
            dgSquareCount.Columns.Remove("Enabled L1FE Outdoors");
            for (var i = dgSquareCount.Columns.Count - 1; i >= 6; i--)
            {
                dgSquareCount.Columns.RemoveAt(i);
            }
        }

        private void txtSKU_KeyPress(object sender, KeyPressEventArgs e)
        {
            base.OnKeyPress(e);

            if (e.KeyChar != '\r') return;

            //Stop ding sound when enter is pressed
            e.Handled = true;

            var searchValue = txtSKU.Texts;

            //dgSquareCount.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            try
            {
                var found = false;

                foreach (DataGridViewRow row in dgSquareCount.Rows)
                {
                    if (!row.Cells["SKU"].Value.ToString().Equals(searchValue)) continue;
                    found = true;
                    const int qty = 1;
                    
                    //row.Selected = true;
                    if (row.Cells["Count"].Value == DBNull.Value)
                    {
                        row.Cells["Count"].Value = "0";
                    }

                    var cell = int.Parse(row.Cells["Count"].Value.ToString());
                    row.Cells["Count"].Value = (cell + qty).ToString();

                    //row.Cells[4].Value = cmbLoc.SelectedItem.ToString();


                    txtSKU.Texts = "";
                    //txtQty.Text = "";
                    row.Selected = true;
                    dgSquareCount.FirstDisplayedScrollingRowIndex = row.Index;
                    dgSquareCount.Focus();
                    txtSKU.Focus();

                    //MessageBox.Show(row.Cells[3].Value.ToString());
                    break;
                }

                if (found) return;
                //If SKU not found play Error sound and clear SKU
                var player = new System.Media.SoundPlayer(@"c:\Windows\Media\Windows Critical Stop.wav");
                player.Play();
                txtSKU.Texts = "";
                txtSKU.Focus();
            }
            catch (Exception exc)
            {
                LOMessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}