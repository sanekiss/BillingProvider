using System;
using System.Windows.Forms;

namespace BillingProvider.WinForms
{
    public partial class MainWindow : Form
    {
        private readonly AppSettings _appSettings = new AppSettings();


        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            gridSettings.SelectedObject = _appSettings;
            
        }
        
    }
}