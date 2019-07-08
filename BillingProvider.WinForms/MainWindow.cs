using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BillingProvider.Core;
using NLog;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;

namespace BillingProvider.WinForms
{
    public partial class MainWindow : Form
    {
        private AppSettings _appSettings;
        private static Logger _log;

        private ServerConnection _conn;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            _log = LogManager.GetCurrentClassLogger();
            _appSettings = new AppSettings();
            gridSettings.SelectedObject = _appSettings;
            _conn = new ServerConnection(_appSettings.ServerPort, _appSettings.ServerAddress,
                _appSettings.ServerLogin, _appSettings.ServerPassword, _appSettings.CashierName,
                _appSettings.CashierVatin);

            _log.Info("Приложение запущено!");
        }


        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = openFileDialog.ShowDialog();
            if (result != DialogResult.OK)
            {
                return;
            }

            Text = $"{openFileDialog.FileName} - Billing Provider";
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

        private bool _changed;
        private bool _processing = false;

        private void gridSettings_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            _changed = true;
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_changed && !_processing)
            {
                return;
            }

            if (_processing)
            {
            }


            if (_changed)
            {
                var result = MessageBox.Show("Вы изменили настройки, сохранить изменения?",
                    "Сохранить?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                switch (result)
                {
                    case DialogResult.Yes:
                        _appSettings.UpdateSettings();
                        break;
                    case DialogResult.Cancel:
                        e.Cancel = true;
                        break;
                }
            }
        }

        private void PingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utils.ServerAvailable(_appSettings.ServerAddress, _appSettings.ServerPort);
        }

        private void TestCheckToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _conn.RegisterTestCheck();
        }

        private void KktStateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _conn.GetDataKkt();
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _appSettings.UpdateSettings();
            _changed = false;
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Белый Н. С.\nbeliy_ns@kuzro.ru", "О программе");
        }

        private void DeviceListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _conn.List();
        }

        private async void FiscalAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _processing = true;
            for (var i = 0; i < gridSource.RowCount; i++)
            {
                var currentRow = gridSource.Rows[i];

                for (var j = 0; j < gridSource.Rows[i].Cells.Count; j++)
                {
                    currentRow.Cells[j].Style.BackColor = Color.PaleGoldenrod;
                }

                try
                {
                    _conn.RegisterCheck(
                        $"{currentRow.Cells[0].Value}, {currentRow.Cells[1].Value}, {currentRow.Cells[2].Value}",
                        currentRow.Cells[3].Value.ToString(), currentRow.Cells[7].Value.ToString(), "0000101010111");
                    await Task.Delay(10000);
                    for (var j = 0; j < gridSource.Rows[i].Cells.Count; j++)
                    {
                        currentRow.Cells[j].Style.BackColor = Color.YellowGreen;
                    }
                }
                catch
                {
                    for (var j = 0; j < gridSource.Rows[i].Cells.Count; j++)
                    {
                        currentRow.Cells[j].Style.BackColor = Color.Salmon;
                    }
                }
            }

            _processing = false;
        }
    }
}