using System.ComponentModel;

namespace L1FEOutdoors.Forms;

partial class BackgroundWorker
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;

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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BackgroundWorker));
        this.progressBar1 = new System.Windows.Forms.ProgressBar();
        this.label1 = new System.Windows.Forms.Label();
        this.SuspendLayout();
        // 
        // progressBar1
        // 
        this.progressBar1.Location = new System.Drawing.Point(10, 50);
        this.progressBar1.Name = "progressBar1";
        this.progressBar1.Size = new System.Drawing.Size(516, 33);
        this.progressBar1.TabIndex = 0;
        this.progressBar1.UseWaitCursor = true;
        // 
        // label1
        // 
        this.label1.Font = new System.Drawing.Font("Verdana", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.label1.Location = new System.Drawing.Point(10, 9);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(516, 38);
        this.label1.TabIndex = 1;
        this.label1.Text = "label1";
        this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        this.label1.UseWaitCursor = true;
        // 
        // BackgroundWorker
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
        this.ClientSize = new System.Drawing.Size(538, 100);
        this.ControlBox = false;
        this.Controls.Add(this.label1);
        this.Controls.Add(this.progressBar1);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "BackgroundWorker";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "Progress";
        this.TopMost = true;
        this.UseWaitCursor = true;
        this.Load += new System.EventHandler(this.BackgroundWorker_Load);
        this.ResumeLayout(false);
    }

    public System.Windows.Forms.Label label1;

    private System.Windows.Forms.ProgressBar progressBar1;

    #endregion
}