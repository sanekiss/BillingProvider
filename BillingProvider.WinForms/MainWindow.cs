using System;
using System.Windows.Forms;
using NLog;

namespace BillingProvider.WinForms
{
    public partial class MainWindow : Form
    {
        private readonly AppSettings _appSettings = new AppSettings();
        private static Logger Log; //

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            Log = LogManager.GetCurrentClassLogger();
            gridSettings.SelectedObject = _appSettings;
            Log.Trace("Trace message");
            Log.Debug("Debug message");
            Log.Info("Info message");
            Log.Warn("Warning message");
            Log.Error("Error message");
            Log.Fatal("FATAL ERROR MESSAGE");
        }
    }
}