namespace L1FEOutdoors
{
    partial class Recount
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Recount));
            this.Save = new System.Windows.Forms.Button();
            this.dgItems = new System.Windows.Forms.DataGridView();
            this.Part = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Available = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UOM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Location = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Import = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Export = new System.Windows.Forms.Button();
            this.loTextBox2 = new L1FEOutdoors.LOControls.LOTextBox();
            this.loTextBox1 = new L1FEOutdoors.LOControls.LOTextBox();
            this.loComboBox1 = new L1FEOutdoors.LOControls.LOComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgItems)).BeginInit();
            this.SuspendLayout();
            // 
            // Save
            // 
            this.Save.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Save.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Save.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Save.Location = new System.Drawing.Point(447, 437);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(135, 48);
            this.Save.TabIndex = 0;
            this.Save.TabStop = false;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = false;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // dgItems
            // 
            this.dgItems.AllowUserToAddRows = false;
            this.dgItems.AllowUserToDeleteRows = false;
            this.dgItems.AllowUserToResizeRows = false;
            this.dgItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgItems.BackgroundColor = System.Drawing.Color.White;
            this.dgItems.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Part,
            this.Available,
            this.UOM,
            this.Count,
            this.Location});
            this.dgItems.Location = new System.Drawing.Point(12, 46);
            this.dgItems.Name = "dgItems";
            this.dgItems.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dgItems.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgItems.Size = new System.Drawing.Size(987, 385);
            this.dgItems.TabIndex = 2;
            this.dgItems.TabStop = false;
            // 
            // Part
            // 
            this.Part.DataPropertyName = "Part";
            this.Part.FillWeight = 304.5686F;
            this.Part.HeaderText = "Part";
            this.Part.Name = "Part";
            this.Part.ReadOnly = true;
            // 
            // Available
            // 
            this.Available.DataPropertyName = "Available";
            this.Available.FillWeight = 48.85788F;
            this.Available.HeaderText = "Available";
            this.Available.Name = "Available";
            this.Available.ReadOnly = true;
            // 
            // UOM
            // 
            this.UOM.DataPropertyName = "UOM";
            this.UOM.FillWeight = 48.85788F;
            this.UOM.HeaderText = "UOM";
            this.UOM.Name = "UOM";
            // 
            // Count
            // 
            this.Count.DataPropertyName = "Count";
            this.Count.FillWeight = 48.85788F;
            this.Count.HeaderText = "Count";
            this.Count.Name = "Count";
            // 
            // Location
            // 
            this.Location.DataPropertyName = "Location";
            this.Location.FillWeight = 48.85788F;
            this.Location.HeaderText = "Location";
            this.Location.Name = "Location";
            // 
            // Import
            // 
            this.Import.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Import.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.Import.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Import.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Import.Location = new System.Drawing.Point(12, 437);
            this.Import.Name = "Import";
            this.Import.Size = new System.Drawing.Size(135, 48);
            this.Import.TabIndex = 3;
            this.Import.TabStop = false;
            this.Import.Text = "Import";
            this.Import.UseVisualStyleBackColor = false;
            this.Import.Click += new System.EventHandler(this.Import_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // Export
            // 
            this.Export.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Export.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.Export.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Export.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Export.Location = new System.Drawing.Point(864, 437);
            this.Export.Name = "Export";
            this.Export.Size = new System.Drawing.Size(135, 48);
            this.Export.TabIndex = 7;
            this.Export.TabStop = false;
            this.Export.Text = "Export";
            this.Export.UseVisualStyleBackColor = false;
            this.Export.Click += new System.EventHandler(this.Export_Click);
            // 
            // loTextBox2
            // 
            this.loTextBox2.BackColor = System.Drawing.SystemColors.Window;
            this.loTextBox2.BorderColor = System.Drawing.Color.Empty;
            this.loTextBox2.BorderFocusColor = System.Drawing.Color.HotPink;
            this.loTextBox2.BorderRadius = 0;
            this.loTextBox2.BorderSize = 2;
            this.loTextBox2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loTextBox2.ForeColor = System.Drawing.Color.DarkGray;
            this.loTextBox2.Location = new System.Drawing.Point(271, 9);
            this.loTextBox2.Margin = new System.Windows.Forms.Padding(4);
            this.loTextBox2.MultiLine = false;
            this.loTextBox2.Name = "loTextBox2";
            this.loTextBox2.Padding = new System.Windows.Forms.Padding(7);
            this.loTextBox2.PasswordChar = false;
            this.loTextBox2.PlaceHolderColor = System.Drawing.Color.DarkGray;
            this.loTextBox2.PlaceHolderText = "QTY";
            this.loTextBox2.Size = new System.Drawing.Size(48, 31);
            this.loTextBox2.TabIndex = 12;
            this.loTextBox2.Texts = "";
            this.loTextBox2.UnderlinedStyle = false;
            this.loTextBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.loTextBox2_KeyPress);
            // 
            // loTextBox1
            // 
            this.loTextBox1.BackColor = System.Drawing.SystemColors.Window;
            this.loTextBox1.BorderColor = System.Drawing.Color.Empty;
            this.loTextBox1.BorderFocusColor = System.Drawing.Color.HotPink;
            this.loTextBox1.BorderRadius = 0;
            this.loTextBox1.BorderSize = 2;
            this.loTextBox1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loTextBox1.ForeColor = System.Drawing.Color.DarkGray;
            this.loTextBox1.Location = new System.Drawing.Point(13, 9);
            this.loTextBox1.Margin = new System.Windows.Forms.Padding(4);
            this.loTextBox1.MultiLine = false;
            this.loTextBox1.Name = "loTextBox1";
            this.loTextBox1.Padding = new System.Windows.Forms.Padding(7);
            this.loTextBox1.PasswordChar = false;
            this.loTextBox1.PlaceHolderColor = System.Drawing.Color.DarkGray;
            this.loTextBox1.PlaceHolderText = "SKU";
            this.loTextBox1.Size = new System.Drawing.Size(250, 31);
            this.loTextBox1.TabIndex = 11;
            this.loTextBox1.Texts = "";
            this.loTextBox1.UnderlinedStyle = false;
            this.loTextBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.loTextBox1_KeyPress);
            // 
            // loComboBox1
            // 
            this.loComboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.loComboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.loComboBox1.BackColor = System.Drawing.SystemColors.Window;
            this.loComboBox1.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.loComboBox1.BorderRadius = 0;
            this.loComboBox1.BorderSize = 2;
            this.loComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.loComboBox1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loComboBox1.ForeColor = System.Drawing.Color.DarkGray;
            this.loComboBox1.IconColor = System.Drawing.Color.MediumSlateBlue;
            this.loComboBox1.Items.AddRange(new object[] {
            "Warehouse",
            "Store Front",
            "HTG_1_A",
            "HTG_1_B",
            "HTG_1_C",
            "HTG_1_D",
            "HTG_1_E",
            "HTG_1_F",
            "HTG_2_A",
            "HTG_2_B",
            "HTG_2_C",
            "HTG_2_D",
            "HTG_2_E",
            "HTG_2_F",
            "HTG_3_A",
            "HTG_3_B",
            "HTG_3_C",
            "HTG_3_D",
            "HTG_3_E",
            "HTG_3_F",
            "HTG_4_A",
            "HTG_4_B",
            "HTG_4_C",
            "HTG_4_D",
            "HTG_4_E",
            "HTG_4_F",
            "HTG_5_A",
            "HTG_5_B",
            "HTG_5_C",
            "HTG_5_D",
            "HTG_5_E",
            "HTG_5_F",
            "HTG_6_A",
            "HTG_6_B",
            "HTG_6_C",
            "HTG_6_D",
            "HTG_6_E",
            "HTG_6_F",
            "HTG_7_A",
            "HTG_7_B",
            "HTG_7_C",
            "HTG_7_D",
            "HTG_7_E",
            "HTG_7_F",
            "HTG_8_A",
            "HTG_8_B",
            "HTG_8_C",
            "HTG_8_D",
            "HTG_8_E",
            "HTG_8_F"});
            this.loComboBox1.ListBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(228)))), ((int)(((byte)(245)))));
            this.loComboBox1.ListTextColor = System.Drawing.Color.DimGray;
            this.loComboBox1.Location = new System.Drawing.Point(326, 9);
            this.loComboBox1.MinimumSize = new System.Drawing.Size(200, 30);
            this.loComboBox1.Name = "loComboBox1";
            this.loComboBox1.Padding = new System.Windows.Forms.Padding(2);
            this.loComboBox1.Size = new System.Drawing.Size(200, 31);
            this.loComboBox1.TabIndex = 13;
            this.loComboBox1.Texts = "LOCATION";
            // 
            // Recount
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1007, 497);
            this.ControlBox = false;
            this.Controls.Add(this.loComboBox1);
            this.Controls.Add(this.loTextBox2);
            this.Controls.Add(this.loTextBox1);
            this.Controls.Add(this.Export);
            this.Controls.Add(this.Import);
            this.Controls.Add(this.dgItems);
            this.Controls.Add(this.Save);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Recount";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Recount";
            this.Load += new System.EventHandler(this.Recount_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgItems)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.DataGridView dgItems;
        private System.Windows.Forms.Button Import;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button Export;
        private System.Windows.Forms.DataGridViewTextBoxColumn Part;
        private System.Windows.Forms.DataGridViewTextBoxColumn Available;
        private System.Windows.Forms.DataGridViewTextBoxColumn UOM;
        private System.Windows.Forms.DataGridViewTextBoxColumn Count;
        private System.Windows.Forms.DataGridViewTextBoxColumn Location;
        private LOControls.LOTextBox loTextBox1;
        private LOControls.LOTextBox loTextBox2;
        private LOControls.LOComboBox loComboBox1;
    }
}

