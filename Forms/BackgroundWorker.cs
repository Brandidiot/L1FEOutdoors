using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace L1FEOutdoors.Forms;

public partial class BackgroundWorker : Form
{
    public BackgroundWorker()
    {
        InitializeComponent();
    }
    
    private void BackgroundWorker_Load(object sender, System.EventArgs e)
    {

    }

    public void ReportProcessingProgress(int percentage)
    {
        Debug.Print(percentage.ToString());
        progressBar1.Value = percentage;
    }
}