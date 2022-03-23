using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace L1FEOutdoors
{
    public partial class CheckSquare : Form
    {
        public CheckSquare()
        {
            InitializeComponent();
        }

        private void LoadTheme()
        {
            foreach (Control btns in this.Controls)
            {
                if (btns.GetType() != typeof(Button)) continue;

                var btn = (Button) btns;

                btn.BackColor = ThemeColor.PrimaryColor;
                btn.ForeColor = Color.White;
                btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
            }
        }

        private void RemoveRows()
        {
            var rows = new List<DataGridViewRow>();

            //Compare Square and Fishbowl Quantities
            for (var index = 0; index < dgSquare.Rows.Count; index++)
            {
                var row = dgSquare.Rows[index];
                if (row.Cells["SquareQty"].Value.ToString() == row.Cells["FishbowlQty"].Value.ToString())
                {
                    //MessageBox.Show(row.Index.ToString());
                    //row.Selected = true;
                    //else
                    //dgSquare.Rows.Remove(row);
                    rows.Add(row);
                }
            }

            foreach (var r in rows)
            {
                dgSquare.Rows.Remove(r);
            }
        }

        private void PopulateSquareInfo()
        {
            //Populate DataTable With Square Data
            Recount.GenerateDataTable(AppDomain.CurrentDomain.BaseDirectory + @"\Resources\Square.csv", dgSquare);

            //Hide Useless Columns
            dgSquare.Columns.Remove("Reference Handle");
            dgSquare.Columns["Token"].Visible = false;
            dgSquare.Columns["Description"].Visible = false;
            dgSquare.Columns["Price"].Visible = false;
            //dgSquare.Columns["Option Name 1"].Visible = false;
            dgSquare.Columns["Option Value 1"].Visible = false;
            dgSquare.Columns["Enabled L1FE Outdoors"].Visible = false;

            //Hide More Useless Columns
            foreach (DataGridViewColumn column in dgSquare.Columns)
            {
                if (column.Index > 10)
                {
                    dgSquare.Columns[column.Index].Visible = false;
                }
            }

            foreach (DataGridViewRow row in dgSquare.Rows)
            {
                if (row.Cells[10].Value == DBNull.Value)
                {
                    row.Cells[10].Value = "0";
                }
            }
        }

        private void PopulateInvQty()
        {
            //Get Data From InvQtys
            DataTable dtNew;
            dtNew = Recount.GetDataTabletFromCsvFile(AppDomain.CurrentDomain.BaseDirectory + @"\Resources\InvQtys.csv");

            foreach (DataGridViewRow rows in dgSquare.Rows)
            {
                String SKU = rows.Cells["SKU"].Value.ToString();
                /*var contains = dtNew.AsEnumerable().Any(row => SKU == row.Field<String>("PartNumber"));

                if (contains)
                    MessageBox.Show("Found SKU " + SKU + " in Row " + dtNew. );*/
                if (dtNew.Select("PartNumber = '" + SKU + "'").Length > 0)
                {
                    DataRow[] dr = dtNew.Select("PartNumber = '" + SKU + "'");

                    var part = dr[0]["PartNumber"].ToString();
                    var qty = dr[0]["Qty"].ToString();

                    //rows.Cells["FishbowlQty"].Value = "0";
                    rows.Cells[7].Value = qty;
                    //MessageBox.Show(rows.Cells[0].Value.ToString());
                }
                else
                {
                    rows.Cells[7].Value = "0";
                }
            }
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
            FormProvider.ModernMenu.Show();
        }

        private void CheckSquare_Load(object sender, EventArgs e)
        {
            LoadTheme();
            FormatDataGridView();
        }
        private void FormatDataGridView()
        {
            dgSquare.ColumnHeadersDefaultCellStyle.BackColor = ThemeColor.PrimaryColor;
            dgSquare.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgSquare.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgSquare.EnableHeadersVisualStyles = false;
            dgSquare.BorderStyle = BorderStyle.None;
            dgSquare.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            dgSquare.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgSquare.DefaultCellStyle.SelectionBackColor = ThemeColor.SecondaryColor;
        }

        private void CheckSquare_Shown(object sender, EventArgs e)
        {
            PopulateSquareInfo();
            PopulateInvQty();

            RemoveRows();
        }

        private void dgSquare_Sorted(object sender, EventArgs e)
        {

        }
    }
}
