namespace L1FEOutdoors.Forms
{
    partial class Settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.panel = new System.Windows.Forms.Panel();
            this.btnHColor = new FontAwesome.Sharp.IconButton();
            this.btnSColor = new FontAwesome.Sharp.IconButton();
            this.btnSRColor = new FontAwesome.Sharp.IconButton();
            this.btnRColor = new FontAwesome.Sharp.IconButton();
            this.btnCSColor = new FontAwesome.Sharp.IconButton();
            this.btnPPColor = new FontAwesome.Sharp.IconButton();
            this.chkRandom = new System.Windows.Forms.CheckBox();
            this.PPColor = new System.Windows.Forms.ColorDialog();
            this.CSColor = new System.Windows.Forms.ColorDialog();
            this.RColor = new System.Windows.Forms.ColorDialog();
            this.SRColor = new System.Windows.Forms.ColorDialog();
            this.SColor = new System.Windows.Forms.ColorDialog();
            this.HColor = new System.Windows.Forms.ColorDialog();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.Controls.Add(this.btnHColor);
            this.panel.Controls.Add(this.btnSColor);
            this.panel.Controls.Add(this.btnSRColor);
            this.panel.Controls.Add(this.btnRColor);
            this.panel.Controls.Add(this.btnCSColor);
            this.panel.Controls.Add(this.btnPPColor);
            this.panel.Controls.Add(this.chkRandom);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(800, 450);
            this.panel.TabIndex = 0;
            // 
            // btnHColor
            // 
            this.btnHColor.Enabled = false;
            this.btnHColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHColor.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHColor.ForeColor = System.Drawing.Color.White;
            this.btnHColor.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnHColor.IconColor = System.Drawing.Color.Black;
            this.btnHColor.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnHColor.Location = new System.Drawing.Point(12, 220);
            this.btnHColor.Name = "btnHColor";
            this.btnHColor.Size = new System.Drawing.Size(189, 30);
            this.btnHColor.TabIndex = 6;
            this.btnHColor.Text = "Help Color";
            this.btnHColor.UseVisualStyleBackColor = true;
            this.btnHColor.Click += new System.EventHandler(this.btnHColor_Click);
            // 
            // btnSColor
            // 
            this.btnSColor.Enabled = false;
            this.btnSColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSColor.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSColor.ForeColor = System.Drawing.Color.White;
            this.btnSColor.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnSColor.IconColor = System.Drawing.Color.Black;
            this.btnSColor.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSColor.Location = new System.Drawing.Point(12, 184);
            this.btnSColor.Name = "btnSColor";
            this.btnSColor.Size = new System.Drawing.Size(189, 30);
            this.btnSColor.TabIndex = 5;
            this.btnSColor.Text = "Settings Color";
            this.btnSColor.UseVisualStyleBackColor = true;
            this.btnSColor.Click += new System.EventHandler(this.btnSColor_Click);
            // 
            // btnSRColor
            // 
            this.btnSRColor.Enabled = false;
            this.btnSRColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSRColor.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSRColor.ForeColor = System.Drawing.Color.White;
            this.btnSRColor.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnSRColor.IconColor = System.Drawing.Color.Black;
            this.btnSRColor.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSRColor.Location = new System.Drawing.Point(12, 148);
            this.btnSRColor.Name = "btnSRColor";
            this.btnSRColor.Size = new System.Drawing.Size(189, 30);
            this.btnSRColor.TabIndex = 4;
            this.btnSRColor.Text = "Square Recount Color";
            this.btnSRColor.UseVisualStyleBackColor = true;
            this.btnSRColor.Click += new System.EventHandler(this.btnSRColor_Click);
            // 
            // btnRColor
            // 
            this.btnRColor.Enabled = false;
            this.btnRColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRColor.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRColor.ForeColor = System.Drawing.Color.White;
            this.btnRColor.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnRColor.IconColor = System.Drawing.Color.Black;
            this.btnRColor.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnRColor.Location = new System.Drawing.Point(12, 112);
            this.btnRColor.Name = "btnRColor";
            this.btnRColor.Size = new System.Drawing.Size(189, 30);
            this.btnRColor.TabIndex = 3;
            this.btnRColor.Text = "Recount Color";
            this.btnRColor.UseVisualStyleBackColor = true;
            this.btnRColor.Click += new System.EventHandler(this.btnRColor_Click);
            // 
            // btnCSColor
            // 
            this.btnCSColor.Enabled = false;
            this.btnCSColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCSColor.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCSColor.ForeColor = System.Drawing.Color.White;
            this.btnCSColor.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnCSColor.IconColor = System.Drawing.Color.Black;
            this.btnCSColor.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCSColor.Location = new System.Drawing.Point(12, 76);
            this.btnCSColor.Name = "btnCSColor";
            this.btnCSColor.Size = new System.Drawing.Size(189, 30);
            this.btnCSColor.TabIndex = 2;
            this.btnCSColor.Text = "Check Square Color";
            this.btnCSColor.UseVisualStyleBackColor = true;
            this.btnCSColor.Click += new System.EventHandler(this.btnCSColor_Click);
            // 
            // btnPPColor
            // 
            this.btnPPColor.Enabled = false;
            this.btnPPColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPPColor.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPPColor.ForeColor = System.Drawing.Color.White;
            this.btnPPColor.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnPPColor.IconColor = System.Drawing.Color.Black;
            this.btnPPColor.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnPPColor.Location = new System.Drawing.Point(12, 40);
            this.btnPPColor.Name = "btnPPColor";
            this.btnPPColor.Size = new System.Drawing.Size(189, 30);
            this.btnPPColor.TabIndex = 1;
            this.btnPPColor.Text = "Product Pricing Color";
            this.btnPPColor.UseVisualStyleBackColor = true;
            this.btnPPColor.Click += new System.EventHandler(this.btnPPColor_Click);
            // 
            // chkRandom
            // 
            this.chkRandom.AutoSize = true;
            this.chkRandom.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkRandom.Location = new System.Drawing.Point(12, 12);
            this.chkRandom.Name = "chkRandom";
            this.chkRandom.Size = new System.Drawing.Size(142, 22);
            this.chkRandom.TabIndex = 0;
            this.chkRandom.Text = "Random Colors";
            this.chkRandom.UseVisualStyleBackColor = true;
            this.chkRandom.CheckedChanged += new System.EventHandler(this.chkRandom_CheckedChanged);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Settings";
            this.Text = "Settings";
            this.Shown += new System.EventHandler(this.Settings_Shown);
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.CheckBox chkRandom;
        private FontAwesome.Sharp.IconButton btnPPColor;
        private System.Windows.Forms.ColorDialog PPColor;
        private FontAwesome.Sharp.IconButton btnSColor;
        private FontAwesome.Sharp.IconButton btnSRColor;
        private FontAwesome.Sharp.IconButton btnRColor;
        private FontAwesome.Sharp.IconButton btnCSColor;
        private FontAwesome.Sharp.IconButton btnHColor;
        private System.Windows.Forms.ColorDialog CSColor;
        private System.Windows.Forms.ColorDialog RColor;
        private System.Windows.Forms.ColorDialog SRColor;
        private System.Windows.Forms.ColorDialog SColor;
        private System.Windows.Forms.ColorDialog HColor;
    }
}