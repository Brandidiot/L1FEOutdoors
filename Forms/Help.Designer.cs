namespace L1FEOutdoors
{
    partial class Help
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Help));
            this.panelInfo = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panelBody = new System.Windows.Forms.Panel();
            this.labelRequirements = new System.Windows.Forms.Label();
            this.labelCSV = new System.Windows.Forms.Label();
            this.labelBody = new System.Windows.Forms.Label();
            this.labelDirections = new System.Windows.Forms.Label();
            this.panelInfo.SuspendLayout();
            this.panelBody.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelInfo
            // 
            this.panelInfo.Controls.Add(this.button3);
            this.panelInfo.Controls.Add(this.button2);
            this.panelInfo.Controls.Add(this.button1);
            this.panelInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelInfo.Location = new System.Drawing.Point(0, 0);
            this.panelInfo.Name = "panelInfo";
            this.panelInfo.Size = new System.Drawing.Size(616, 72);
            this.panelInfo.TabIndex = 0;
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(474, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(130, 46);
            this.button3.TabIndex = 2;
            this.button3.Text = "Check Square";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(243, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(130, 46);
            this.button2.TabIndex = 1;
            this.button2.Text = "Recount";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 46);
            this.button1.TabIndex = 0;
            this.button1.Text = "Square Recount";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panelBody
            // 
            this.panelBody.Controls.Add(this.labelBody);
            this.panelBody.Controls.Add(this.labelDirections);
            this.panelBody.Controls.Add(this.labelCSV);
            this.panelBody.Controls.Add(this.labelRequirements);
            this.panelBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBody.Location = new System.Drawing.Point(0, 72);
            this.panelBody.Name = "panelBody";
            this.panelBody.Padding = new System.Windows.Forms.Padding(10);
            this.panelBody.Size = new System.Drawing.Size(616, 328);
            this.panelBody.TabIndex = 1;
            // 
            // labelRequirements
            // 
            this.labelRequirements.AutoSize = true;
            this.labelRequirements.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRequirements.Location = new System.Drawing.Point(9, 10);
            this.labelRequirements.Margin = new System.Windows.Forms.Padding(3);
            this.labelRequirements.Name = "labelRequirements";
            this.labelRequirements.Padding = new System.Windows.Forms.Padding(5, 5, 10, 15);
            this.labelRequirements.Size = new System.Drawing.Size(177, 38);
            this.labelRequirements.TabIndex = 0;
            this.labelRequirements.Text = "Required CSV Files";
            this.labelRequirements.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelCSV
            // 
            this.labelCSV.AutoSize = true;
            this.labelCSV.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCSV.Location = new System.Drawing.Point(15, 38);
            this.labelCSV.Name = "labelCSV";
            this.labelCSV.Size = new System.Drawing.Size(87, 32);
            this.labelCSV.TabIndex = 1;
            this.labelCSV.Text = "Square.csv\r\nInvQtys.csv";
            // 
            // labelBody
            // 
            this.labelBody.AutoSize = true;
            this.labelBody.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBody.Location = new System.Drawing.Point(15, 114);
            this.labelBody.Name = "labelBody";
            this.labelBody.Size = new System.Drawing.Size(561, 64);
            this.labelBody.TabIndex = 2;
            this.labelBody.Text = resources.GetString("labelBody.Text");
            // 
            // labelDirections
            // 
            this.labelDirections.AutoSize = true;
            this.labelDirections.BackColor = System.Drawing.SystemColors.Control;
            this.labelDirections.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDirections.Location = new System.Drawing.Point(9, 87);
            this.labelDirections.Margin = new System.Windows.Forms.Padding(3);
            this.labelDirections.Name = "labelDirections";
            this.labelDirections.Padding = new System.Windows.Forms.Padding(5, 5, 10, 15);
            this.labelDirections.Size = new System.Drawing.Size(105, 38);
            this.labelDirections.TabIndex = 3;
            this.labelDirections.Text = "Directions";
            this.labelDirections.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Help
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 400);
            this.Controls.Add(this.panelBody);
            this.Controls.Add(this.panelInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Help";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Help";
            this.Load += new System.EventHandler(this.Help_Load);
            this.panelInfo.ResumeLayout(false);
            this.panelBody.ResumeLayout(false);
            this.panelBody.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelInfo;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panelBody;
        private System.Windows.Forms.Label labelRequirements;
        private System.Windows.Forms.Label labelCSV;
        private System.Windows.Forms.Label labelBody;
        private System.Windows.Forms.Label labelDirections;
    }
}