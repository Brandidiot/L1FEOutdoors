using System;
using System.Data;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace L1FEOutdoors
{
    public class GenerateDT
    {
        public static async Task GenerateDataTable(String SourceURL, DataGridView dgv)
        {
            var dialog = new OpenFileDialog();
            //var SourceURL = @"C:\Users\" + Environment.UserName + @"\Documents\Recounted.csv";

            try
            {
                if (!File.Exists(SourceURL))
                {
                    dialog.ShowDialog();
                    SourceURL = dialog.FileName;
                }

                int ImportedRecord = 0, inValidItem = 0;

                //if (dialog.FileName == "") return;
                DataTable dtNew;

                if (File.Exists(SourceURL) && SourceURL.EndsWith(".csv"))
                {
                    dtNew = await GetDataTabletFromCsvFile(SourceURL);

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
                    LOMessageBox.Show("There is no data in this file", "No Data", MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
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
    }
}
