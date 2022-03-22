using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using L1FEOutdoors.LOControls;

namespace L1FEOutdoors.Forms
{
    public partial class ProductPrice : Form
    {
        public ProductPrice()
        {
            InitializeComponent();
            GenerateDT.GenerateDataTable(AppDomain.CurrentDomain.BaseDirectory + @"\Resources\InvAvail.csv", dgProduct);
        }

        private void PopulatePrice()
        {
            //Get Data From InvQtys
            DataTable dtNew;
            dtNew = GenerateDT.GetDataTabletFromCsvFile(AppDomain.CurrentDomain.BaseDirectory + @"\Resources\ProductPricing.csv");

            foreach (DataGridViewRow rows in dgProduct.Rows)
            {
                var SKU = rows.Cells["Product"].Value.ToString();
                
                /*var contains = dtNew.AsEnumerable().Any(row => SKU == row.Field<String>("PartNumber"));

                if (contains)
                    MessageBox.Show("Found SKU " + SKU + " in Row " + dtNew. );*/
                if (dtNew.Select("Product = '" + SKU + "'").Length > 0)
                {
                    DataRow[] dr = dtNew.Select("Product = '" + SKU + "'");

                    var part = dr[0]["Product"].ToString();
                    var price = dr[0]["Price"].ToString();

                    //rows.Cells["FishbowlQty"].Value = "0";
                    rows.Cells["Price"].Value = price;
                    //MessageBox.Show(rows.Cells[0].Value.ToString());
                }
                else
                {
                    rows.Cells["Price"].Value = "0";
                }
            }
        }

        private void ProductPrice_Shown(object sender, EventArgs e)
        {
            LoadTheme();
            FormatDataGridView();
            //dgProduct.Columns.Remove("On Hand");
            dgProduct.Columns.Remove("Allocated");
            dgProduct.Columns.Remove("Not Available");
            dgProduct.Columns.Remove("Drop Ship");
            dgProduct.Columns.Remove("On Order");
            dgProduct.Columns.Remove("Short");
            dgProduct.Columns.Remove("Committed");
            PopulatePrice();
        }

        private void txtSearch__TextChanged(object sender, EventArgs e)
        {
            dgProduct.CurrentCell = null;

            //dgProduct.Rows[0].Visible = false;
            foreach (DataGridViewRow dr in dgProduct.Rows)
            {
                if (txtSearch.Texts == "")
                    dr.Visible = true;

                if (ContainsCaseInsensitive(dr.Cells["Product"].Value.ToString(), txtSearch.Texts) ||
                    ContainsCaseInsensitive(dr.Cells["Description"].Value.ToString(), txtSearch.Texts))
                {
                    dr.Visible = true;
                }
                else
                {
                    dr.Visible = false;
                }
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
            dgProduct.ColumnHeadersDefaultCellStyle.BackColor = ThemeColor.PrimaryColor;
            dgProduct.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgProduct.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgProduct.EnableHeadersVisualStyles = false;
            dgProduct.BorderStyle = BorderStyle.None;
            dgProduct.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            dgProduct.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgProduct.DefaultCellStyle.SelectionBackColor = ThemeColor.SecondaryColor;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            //var csvPath = @"C:\Users\" + Environment.UserName + @"\Documents\SquareCounted_" + DateTime.Now.ToString("M/d/yyyy") + ".csv";
            string csvPath;

            if (dgProduct.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "CSV (*.csv)|*.csv";

                var folderName = @"C:\Users\" + Environment.UserName + @"\Desktop\" + DateTime.Now.ToString("M/d/yyyy");

                if (File.Exists(folderName))
                {
                    csvPath = folderName + @"\ProductPricing_" + DateTime.Now.ToString("hh") + DateTime.Now.ToString("tt") + ".csv";
                }
                else
                {
                    Directory.CreateDirectory(folderName);
                    csvPath = folderName + @"\ProductPricing_" + DateTime.Now.ToString("hh") + DateTime.Now.ToString("tt") + ".csv";
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
                        var columnCount = dgProduct.Columns.Count;
                        var columnNames = "";
                        var outputCsv = new string[dgProduct.Rows.Count + 1];
                        for (var i = 0; i < columnCount; i++)
                        {
                            if (i == columnCount - 1)
                            {
                                columnNames += dgProduct.Columns[i].HeaderText;
                            }
                            else
                            {
                                columnNames += dgProduct.Columns[i].HeaderText.ToString() + ",";
                            }
                        }
                        outputCsv[0] += columnNames;

                        for (var i = 1; i - 1 < dgProduct.Rows.Count; i++)
                        {
                            for (var j = 0; j < columnCount; j++)
                            {
                                if (dgProduct.Rows[i - 1].Cells[1].Value.ToString().Contains(","))
                                {
                                    if (j == columnCount - 1)
                                    {
                                        outputCsv[i] += dgProduct.Rows[i - 1].Cells[j].Value;
                                    }
                                    else if (j == 1) //change number based on column number starting at 0
                                    {
                                        if (dgProduct.Rows[i - 1].Cells[1].Value.ToString().Contains("\"")) //change number based on column number starting at 0
                                        {
                                            var index = dgProduct.Rows[i - 1].Cells[1].Value.ToString().IndexOf("\"", StringComparison.Ordinal);
                                            outputCsv[i] += "\"" + dgProduct.Rows[i - 1].Cells[j].Value.ToString().Insert(index, "\"") + "\"" + ",";
                                        }
                                        else
                                        {
                                            outputCsv[i] += "\"" + dgProduct.Rows[i - 1].Cells[j].Value + "\"" + ",";
                                        }
                                    }
                                    else
                                    {
                                        outputCsv[i] += dgProduct.Rows[i - 1].Cells[j].Value + ",";
                                    }
                                }
                                else
                                {
                                    if (j == columnCount - 1)
                                    {
                                        outputCsv[i] += dgProduct.Rows[i - 1].Cells[j].Value;
                                    }
                                    else
                                    {
                                        outputCsv[i] += dgProduct.Rows[i - 1].Cells[j].Value + ",";
                                    }
                                }
                            }
                        }

                        File.WriteAllLines(sfd.FileName, outputCsv, Encoding.UTF8);
                        LOMessageBox.Show("Data Exported Successfully To " + csvPath, "Exported", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        LOMessageBox.Show("Error:" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                LOMessageBox.Show("No Record To Export!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private static bool ContainsCaseInsensitive(string source, string substring)
        {
            return source?.IndexOf(substring, StringComparison.OrdinalIgnoreCase) > -1;
        }
    }
}
