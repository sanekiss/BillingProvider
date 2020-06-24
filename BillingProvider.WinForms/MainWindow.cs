﻿using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BillingProvider.Core;
using BillingProvider.Core.KKMDrivers;
using BillingProvider.Core.Parsers;
using BillingProvider.WinForms.Extensions;
using NLog;
using NLog.Fluent;

namespace BillingProvider.WinForms
{
    public partial class MainWindow : Form
    {
        private AppSettings _appSettings;
        private static Logger _log;

        // private ServerConnection _conn;
        private IKkmDriver _conn;

        private readonly StringBuilder _sbLog;
        private bool _logDirty;
        private FileSystemWatcher _watcher;
        private bool _isWatching;


        public MainWindow()
        {
            InitializeComponent();
            _sbLog = new StringBuilder();
            _logDirty = false;
            _isWatching = false;
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            // TestCheckToolStripMenuItem.Enabled = false;
            // KktStateToolStripMenuItem.Enabled = false;
            // DeviceListToolStripMenuItem.Enabled = false;

            _log = LogManager.GetCurrentClassLogger();
            _appSettings = new AppSettings();
            gridSettings.SelectedObject = _appSettings;
            if (_appSettings.KkmDriver == AppSettings.KkmDrivers.atol)
            {
                _conn = new AtolOnlineDriver(_appSettings.AtolOnlineINN, _appSettings.AtolOnlineGroupID,
                    _appSettings.AtolOnlineLogin, _appSettings.AtolOnlinePassword, _appSettings.CashierName,
                    _appSettings.CashierVatin, _appSettings.AtolOnlineHostname, _appSettings.CompanyMail);
            }
            else if (_appSettings.KkmDriver == AppSettings.KkmDrivers.kkmserver)
            {
                _conn = new KkmServerDriver(_appSettings.CashierName, _appSettings.CashierVatin,
                    _appSettings.ServerPassword, _appSettings.ServerLogin, _appSettings.ServerAddress,
                    _appSettings.ServerPort, _appSettings.CompanyMail);
            }

            _log.Debug("MainWindow loaded");
            CreateToolStripMenuItem_Click(sender, e);
            _log.Info("Приложение запущено!");
        }


        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _log.Debug($"{nameof(OpenToolStripMenuItem)} clicked");

            var result = openFileDialog.ShowDialog();
            if (result != DialogResult.OK)
            {
                return;
            }

            _log.Info($"Выбран файл: {openFileDialog.FileName}");
            Text = $@"{openFileDialog.FileName} - Billing Provider";

            var parser = ParserSelector.Select(openFileDialog.FileName);
            try
            {
                parser.Load();
            }
            catch
            {
                Log.Error($"Не удалось открыть файл: {openFileDialog.FileName}");
            }


            var dt = new DataTable();
            gridSource.DataSource = dt;

            _log.Debug($"Добавление колонок в {nameof(gridSource)}");
            foreach (var caption in parser.Captions)
            {
                dt.Columns.Add(caption, typeof(string));
            }

            gridSource.Update();

            _log.Debug($"Добавление данных в {nameof(gridSource)}");
            foreach (var node in parser.Data)
            {
                dt.LoadDataRow(node.AsArray(), LoadOption.Upsert);
                gridSource.Update();
            }
        }

        private bool _changed;
        private bool _processing;

        private void gridSettings_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            _changed = true;
            if (_appSettings.KkmDriver == AppSettings.KkmDrivers.atol)
            {
                _conn = new AtolOnlineDriver(_appSettings.AtolOnlineINN, _appSettings.AtolOnlineGroupID,
                    _appSettings.AtolOnlineLogin, _appSettings.AtolOnlinePassword, _appSettings.CashierName,
                    _appSettings.CashierVatin, _appSettings.AtolOnlineHostname, _appSettings.CompanyMail);
            }
            else if (_appSettings.KkmDriver == AppSettings.KkmDrivers.kkmserver)
            {
                _conn = new KkmServerDriver(_appSettings.CashierName, _appSettings.CashierVatin,
                    _appSettings.ServerPassword, _appSettings.ServerLogin, _appSettings.ServerAddress,
                    _appSettings.ServerPort, _appSettings.CompanyMail);
            }
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            _log.Debug($"Form closing");

            if (!_changed && !_processing)
            {
                return;
            }

            if (_processing)
            {
                _log.Debug($"Form closing: processing = true");
                MessageBox.Show(@"Идет обработка позиций!");
                e.Cancel = true;
                return;
            }


            if (!_changed)
            {
                return;
            }

            _log.Debug($"Form closing: changed = true");

            var result = MessageBox.Show(@"Вы изменили настройки, сохранить изменения?",
                @"Сохранить?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

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

        private void PingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _log.Debug($"{nameof(PingToolStripMenuItem)} clicked");
            // Utils.ServerAvailable(_appSettings.ServerAddress, _appSettings.ServerPort);
            _conn.TestConnection();
        }

        private void TestCheckToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _log.Debug($"{nameof(TestCheckToolStripMenuItem)} clicked");
            _conn.RegisterTestCheck();
        }

        private void KktStateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _log.Debug($"{nameof(KktStateToolStripMenuItem)} clicked");
            // _conn.GetDataKkt();
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _log.Debug($"{nameof(SaveToolStripMenuItem)} clicked");
            _appSettings.UpdateSettings();
            _changed = false;
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Белый Н. С.\nbeliy_ns@kuzro.ru", @"О программе");
        }

        private void DeviceListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _log.Debug($"{nameof(DeviceListToolStripMenuItem)} clicked");
            // _conn.List();
        }

        private async void FiscalAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _log.Debug($"{nameof(FiscalAllToolStripMenuItem)} clicked");
            _processing = true;


            for (var i = 0; i < gridSource.RowCount - 1; i++)
            {
                var currentRow = gridSource.Rows[i];
                _log.Debug(
                    $"Current row: {nameof(gridSource)}.Rows[{i}]: {currentRow.Cells[3].Value}, {currentRow.Cells[2].Value}");

                Utils.ChangeBackground(currentRow, Color.PaleGoldenrod);

                try
                {
                    _conn.RegisterCheck(currentRow.Cells[0].Value.ToString(), currentRow.Cells[3].Value.ToString(),
                        currentRow.Cells[2].Value.ToString());

                    await Task.Delay(1500);

                    Utils.ChangeBackground(currentRow, Color.YellowGreen);
                }
                catch
                {
                    Utils.ChangeBackground(currentRow, Color.Salmon);
                }
            }

            _processing = false;
            _log.Info("Фискализация позиций завершена");
        }

        private void CreateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Text = @"Billing Provider";

            var dt = new DataTable();
            gridSource.DataSource = dt;

            _log.Debug($"Добавление колонок в {nameof(gridSource)}");
            var parser = new HtmlKbbParser("");

            foreach (var caption in parser.Captions)
            {
                dt.Columns.Add(caption, typeof(string));
            }

            gridSource.Update();
        }

        private void rtxtLog_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            Process.Start(e.LinkText);
            Log.Debug($"{e.LinkText} clicked");
        }

        private void WatchFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_isWatching)
            {
                _isWatching = false;
                _watcher.EnableRaisingEvents = false;
                _watcher.Dispose();
                WatchFolderToolStripMenuItem.Text = @"Отслеживать папку";
            }
            else
            {
                _isWatching = true;
                WatchFolderToolStripMenuItem.Text = @"Прекратить отслеживание";

                _watcher = new FileSystemWatcher
                {
                    Filter = "*.*",
                    Path = _appSettings.FolderPath,
                    IncludeSubdirectories = _appSettings.IncludeSubfolders,
                    NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.FileName,
                                   EnableRaisingEvents = true
                };


                _watcher.Changed += OnChanged;
                _watcher.Created += OnChanged;
            }
        }

        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            if (_logDirty)
            {
                return;
            }

            _sbLog.Remove(0, _sbLog.Length);
            _sbLog.Append(e.FullPath);
            _sbLog.Append(" ");
            _sbLog.Append(e.ChangeType.ToString());
            _sbLog.Append("    ");
            _sbLog.Append(DateTime.Now.ToString(CultureInfo.InvariantCulture));
            _logDirty = true;
        }

        private void tmrEditNotify_Tick(object sender, EventArgs e)
        {
            if (!_logDirty)
            {
                return;
            }

            _log.Info(_sbLog.ToString());
            _logDirty = false;
        }
    }
}