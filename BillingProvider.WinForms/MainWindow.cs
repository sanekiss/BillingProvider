using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NLog;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;

namespace BillingProvider.WinForms
{
    public partial class MainWindow : Form
    {
        private readonly AppSettings _appSettings = new AppSettings();
        private static Logger _log;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            _log = LogManager.GetCurrentClassLogger();
            gridSettings.SelectedObject = _appSettings;
            _log.Trace("Trace message");
            _log.Debug("Debug message");
            _log.Info("Info message");
            _log.Warn("Warning message");
            _log.Error("Error message");
            _log.Fatal("FATAL ERROR MESSAGE");
        }


        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog.ShowDialog();
            if (result != DialogResult.OK) // Test result.
            {
                return;
            }

            var doc = new HtmlDocument();

            doc.Load(openFileDialog.FileName, Encoding.UTF8);

            var dt = new DataTable();

            var captions = doc.DocumentNode.Descendants("th").ToList();
            foreach (var cell in captions)
            {
                dt.Columns.Add(cell.InnerText.Trim(), typeof(string));
            }

            gridSource.DataSource = dt;

            foreach (var row in doc.DocumentNode.SelectNodes("//tr").Skip(1))
            {
                var data = row.Descendants("td").Select(x => x.InnerText.Trim()).Cast<object>().ToArray();
                dt.LoadDataRow(data, LoadOption.Upsert);

                gridSource.Update();
            }
        }
    }
}