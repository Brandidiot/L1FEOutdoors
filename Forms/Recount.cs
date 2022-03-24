using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using L1FEOutdoors.LOControls;

namespace L1FEOutdoors
{
    public partial class Recount : Form
    {
        public Recount()
        {
            InitializeComponent();
        }

        public static async Task GenerateDataTable(String sourceUrl, DataGridView dgv)
        {
            var dialog = new OpenFileDialog();
            //var SourceURL = @"C:\Users\" + Environment.UserName + @"\Documents\Recounted.csv";

            try
            {
                if (!File.Exists(sourceUrl))
                {
                    dialog.ShowDialog();
                    sourceUrl = dialog.FileName;
                }

                int ImportedRecord = 0, inValidItem = 0;

                //if (dialog.FileName == "") return;
                DataTable dtNew;

                if (File.Exists(sourceUrl) && sourceUrl.EndsWith(".csv"))
                {
                    dtNew = await GetDataTabletFromCsvFile(sourceUrl);

                    /*if (Convert.ToString(dtNew.Columns[0]).ToLower() != "part")
                    {
                        MessageBox.Show("Invalid Items File");
                        Save.Enabled = false;
                        return;
                    }*/

                    //txtSearch.Text = dialog.SafeFileName;
                    if (dtNew.Rows.ToString() != String.Empty)
                    {
                        dgv.DataSource = dtNew;
                    }

                    foreach (DataGridViewRow row in dgv.Rows)
                    {
                        foreach (DataGridViewColumn column in dgv.Columns)
                        {
                            if (Convert.ToString(row.Cells[column.Name].Value) == "" || row.Cells[column.Name].Value == null
                                /*|| Convert.ToString(row.Cells["Available"].Value) == "" ||
                                row.Cells["Available"].Value == null
                                || Convert.ToString(row.Cells["UOM"].Value) == "" || row.Cells["UOM"].Value == null
                                || Convert.ToString(row.Cells["Count"].Value) == "" || row.Cells["Count"].Value == null
                                || Convert.ToString(row.Cells["Location"].Value) == "" ||
                                row.Cells["Location"].Value == null*/)
                            {
                                //row.DefaultCellStyle.BackColor = Color.White;
                                inValidItem += 1;
                            }
                            else
                            {
                                ImportedRecord += 1;
                            }
                        }
                    }
                    
                    if (dgv.Rows.Count != 0) return;

                    //Save.Enabled = false;
                    LOMessageBox.Show("There is no data in this file", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    LOMessageBox.Show("Recounted.csv Doesn't Exist. Please Import File.", "Doesn't Exist",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                LOMessageBox.Show("Exception " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void Import_Click(object sender, EventArgs e)
        {

            var dialogResult = LOMessageBox.Show("Are You Sure You Want To Import New Data? \n This Will Remove All Current Data",
                    "Import Data", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult != DialogResult.Yes) return;
            
            var dialog = new OpenFileDialog();
            var sourceUrl = @"C:\Users\" + Environment.UserName + @"\Documents\Recount.csv";

            try
            {
                dialog.ShowDialog();
                sourceUrl = dialog.FileName;
                int importedRecord = 0, inValidItem = 0;

                if (dialog.FileName == "") return;
                DataTable dtNew;

                if (sourceUrl.EndsWith(".csv"))
                {
                    dtNew = await GetDataTabletFromCsvFile(sourceUrl);

                    if (Convert.ToString(dtNew.Columns[0]).ToLower() != "part")
                    {
                        LOMessageBox.Show("Invalid Items File","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        Save.Enabled = false;
                        return;
                    }

                    loTextBox1.Texts = dialog.SafeFileName;
                    if (dtNew.Rows.ToString() != String.Empty)
                    {
                        dgItems.DataSource = dtNew;
                    }

                    foreach (DataGridViewRow row in dgItems.Rows)
                    {
                        if (Convert.ToString(row.Cells["Part"].Value) == "" || row.Cells["Part"].Value == null
                                                                            || Convert.ToString(row.Cells["Available"].Value) == "" || row.Cells["Available"].Value == null
                                                                            || Convert.ToString(row.Cells["UOM"].Value) == "" || row.Cells["UOM"].Value == null
                                                                            || Convert.ToString(row.Cells["Count"].Value) == "" || row.Cells["Count"].Value == null
                                                                            || Convert.ToString(row.Cells["Location"].Value) == "" || row.Cells["Location"].Value == null)
                        {
                            row.DefaultCellStyle.BackColor = Color.White;
                            inValidItem += 1;
                        }
                        else
                        {
                            importedRecord += 1;
                        }
                    }

                    FormatDataGridView();
                    if (dgItems.Rows.Count != 0) return;

                    Save.Enabled = false;
                    LOMessageBox.Show("There is no data in this file", "No Data", MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                }
                else
                {
                    MessageBox.Show(@"Selected File is Invalid, Please Select valid csv file.", @"Invalid",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                LOMessageBox.Show("Exception " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            var searchValue = loTextBox1.Texts;
            
            //dgItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            try
            {
                if (loTextBox1.Texts == "" || loTextBox2.Texts == "" || loComboBox1.SelectedIndex == -1)
                {
                    LOMessageBox.Show("Please Make Sure All Fields Are Filled Out", "Missing Field",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                    return;
                }

                foreach (DataGridViewRow row in dgItems.Rows)
                {
                    if (!row.Cells[0].Value.ToString().Contains(searchValue)) continue;
                    
                    var qty = int.Parse(loTextBox2.Texts);
                    //row.Selected = true;
                    if (row.Cells[3].Value == DBNull.Value)
                    {
                        row.Cells[3].Value = "0";
                    }

                    var cell = int.Parse(row.Cells[3].Value.ToString());
                    row.Cells[3].Value = (cell + qty).ToString();

                    if (row.Cells[4].Value != DBNull.Value)
                    {
                        LOMessageBox.Show(@"Part Already Counted At Location " + row.Cells[4].Value, "Already Counted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        row.Cells[4].Value = loComboBox1.SelectedItem.ToString();
                    }

                    loTextBox1.Texts = "";
                    loTextBox2.Texts = "";
                    row.Selected = true;
                    dgItems.FirstDisplayedScrollingRowIndex = row.Index;
                    dgItems.Focus();
                    loTextBox1.Focus();

                    //MessageBox.Show(row.Cells[3].Value.ToString());
                    break;
                }
            }
            catch (Exception exc)
            {
                LOMessageBox.Show(exc.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        public static Task<DataTable> GetDataTabletFromCsvFile(string csvFilePath)
        {
            var csvData = new DataTable();
            try
            {
                if (csvFilePath.EndsWith(".csv"))
                {
                    using (Microsoft.VisualBasic.FileIO.TextFieldParser csvReader = new Microsoft.VisualBasic.FileIO.TextFieldParser(csvFilePath))
                    {
                        csvReader.SetDelimiters(new string[] { "," });
                        csvReader.HasFieldsEnclosedInQuotes = true;
                        //read column
                        var colFields = csvReader.ReadFields();
                        foreach (var column in colFields)
                        {
                            var datacolumn = new DataColumn(column);
                            datacolumn.AllowDBNull = true;
                            csvData.Columns.Add(datacolumn);
                        }
                        while (!csvReader.EndOfData)
                        {
                            var fieldData = csvReader.ReadFields();
                            for (var i = 0; i < fieldData.Length; i++)
                            {
                                if (fieldData[i] == "")
                                {
                                    fieldData[i] = null;
                                }
                            }
                            csvData.Rows.Add(fieldData);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LOMessageBox.Show("Exce " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return Task.FromResult(csvData);
        }

        private void Export_Click(object sender, EventArgs e)
        {
            //var csvPath = @"C:\Users\" + Environment.UserName + @"\Documents\Recounted.csv";
            string csvPath;

            if (dgItems.Rows.Count > 0)
            {
                var sfd = new SaveFileDialog();
                sfd.Filter = @"CSV (*.csv)|*.csv";
                var folderName = @"C:\Users\" + Environment.UserName + @"\Desktop\" + DateTime.Now.ToString("M/d/yyyy");

                if (File.Exists(folderName))
                {
                    csvPath = folderName + @"\Recount_" + DateTime.Now.ToString("hh") + DateTime.Now.ToString("tt") + ".csv";
                }
                else
                {
                    Directory.CreateDirectory(folderName);
                    csvPath = folderName + @"\Recount_" + DateTime.Now.ToString("hh") + DateTime.Now.ToString("tt") + ".csv";
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
                        LOMessageBox.Show("It wasn't possible to write the data to the disk." + ex.Message, "Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                }

                if (fileError) return;
                {
                    try
                    {
                        var columnCount = dgItems.Columns.Count;
                        var columnNames = "";
                        var outputCsv = new string[dgItems.Rows.Count + 1];
                        for (var i = 0; i < columnCount; i++)
                        {
                            if (i == columnCount - 1)
                            {
                                columnNames += dgItems.Columns[i].HeaderText;
                            }
                            else
                            {
                                columnNames += dgItems.Columns[i].HeaderText.ToString() + ",";
                            }
                        }
                        outputCsv[0] += columnNames;

                        for (var i = 1; i - 1 < dgItems.Rows.Count; i++)
                        {
                            for (var j = 0; j < columnCount; j++)
                            {
                                if (dgItems.Rows[i-1].Cells[0].Value.ToString().Contains(","))
                                {
                                    if (j == columnCount - 1)
                                    {
                                        outputCsv[i] += dgItems.Rows[i - 1].Cells[j].Value;
                                    }
                                    else if (j == 0)
                                    {
                                        if (dgItems.Rows[i - 1].Cells[0].Value.ToString().Contains("\""))
                                        {
                                            var index = dgItems.Rows[i - 1].Cells[0].Value.ToString().IndexOf("\"", StringComparison.Ordinal);
                                            outputCsv[i] += "\"" + dgItems.Rows[i - 1].Cells[j].Value.ToString().Insert(index,"\"") + "\"" + ",";
                                        }
                                        else
                                        {
                                            outputCsv[i] += "\"" + dgItems.Rows[i - 1].Cells[j].Value + "\"" + ",";
                                        }
                                    }
                                    else
                                    {
                                        outputCsv[i] += dgItems.Rows[i - 1].Cells[j].Value + ",";
                                    }
                                }
                                else
                                {
                                    if (j == columnCount - 1)
                                    {
                                        outputCsv[i] += dgItems.Rows[i - 1].Cells[j].Value;
                                    }
                                    else
                                    {
                                        outputCsv[i] += dgItems.Rows[i - 1].Cells[j].Value + ",";
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
                LOMessageBox.Show("No Record To Export!", "No Record", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        
        private void LoadTheme()
        {
            foreach (Control ctrls in this.Controls)
            {
                if (ctrls.GetType() == typeof(Button))
                {
                    var btn = (Button)ctrls;

                    btn.BackColor = ThemeColor.PrimaryColor;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                }
                else if (ctrls.GetType() == typeof(LOTextBox))
                {
                    var box = (LOTextBox)ctrls;
                    box.BorderColor = ThemeColor.PrimaryColor;
                    box.BorderFocusColor = ThemeColor.SecondaryColor;
                }
                else if (ctrls.GetType() == typeof(LOComboBox))
                {
                    var box = (LOComboBox) ctrls;
                    box.BorderColor = ThemeColor.PrimaryColor;
                    box.IconColor = ThemeColor.PrimaryColor;
                }
            }
        }

        private void FormatDataGridView()
        {
            dgItems.ColumnHeadersDefaultCellStyle.BackColor = ThemeColor.PrimaryColor;
            dgItems.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgItems.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgItems.EnableHeadersVisualStyles = false;
            dgItems.BorderStyle = BorderStyle.None;
            //dgItems.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            /*foreach (DataGridViewRow dgvr in dgItems.Rows)//dgv is datagridview
            {
                if (dgvr.Index % 2 == 0)
                {
                    dgvr.Cells["Part"].Style.BackColor = Color.LightGray;
                    dgvr.Cells["Available"].Style.BackColor = Color.LightGray;
                    dgvr.Cells["UOM"].Style.BackColor = Color.LightGray;
                    dgvr.Cells["Location"].Style.BackColor = Color.LightGray;
                    dgvr.Cells["Count"].Style.BackColor = Color.LightGray;
                }
                else
                {
                    dgvr.Cells["Part"].Style.BackColor = Color.White;
                    dgvr.Cells["Available"].Style.BackColor = Color.White;
                    dgvr.Cells["UOM"].Style.BackColor = Color.White;
                    dgvr.Cells["Location"].Style.BackColor = Color.White;
                    dgvr.Cells["Count"].Style.BackColor = Color.White;
                }
            }*/
            dgItems.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            dgItems.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgItems.DefaultCellStyle.SelectionBackColor = ThemeColor.SecondaryColor;

            dgItems.Columns["Available"]!.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgItems.Columns["UOM"]!.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgItems.Columns["Count"]!.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgItems.Columns["Location"]!.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            foreach (DataGridViewColumn c in dgItems.Columns)
            {
                c.DefaultCellStyle.Font = new Font("Verdana", 12F, GraphicsUnit.Pixel);
            }
        }

        private async void Recount_Load(object sender, EventArgs e)
        {
            
            
        }

        private void loTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            base.OnKeyPress(e);

            if (e.KeyChar != '\r') return;

            e.Handled = true;

            loTextBox2.Focus();
        }

        private void loTextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            base.OnKeyPress(e);

            if (e.KeyChar != '\r') return;

            e.Handled = true;

            Save_Click(sender,e);
        }

        private async void Recount_Shown(object sender, EventArgs e)
        {
            try
            {
                await GenerateDataTable(AppDomain.CurrentDomain.BaseDirectory + @"\Resources\Recount.csv", dgItems);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            LoadTheme();
            FormatDataGridView();
        }
    }
}