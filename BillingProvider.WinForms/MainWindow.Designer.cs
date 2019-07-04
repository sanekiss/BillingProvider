namespace BillingProvider.WinForms
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources =
                new System.ComponentModel.ComponentResourceManager(typeof(BillingProvider.WinForms.MainWindow));
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.создатьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитькакToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.печатьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.предварительныйпросмотрToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.правкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отменадействияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отменадействияToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.вырезатьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.копироватьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вставкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.выделитьвсеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сервисToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.параметрыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.содержаниеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.индексToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.поискToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.опрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainSplitontainer = new System.Windows.Forms.SplitContainer();
            this.gridSettings = new System.Windows.Forms.PropertyGrid();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.gridSource = new System.Windows.Forms.DataGridView();
            this.rtxtLog = new System.Windows.Forms.RichTextBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.mainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.MainSplitontainer)).BeginInit();
            this.MainSplitontainer.Panel1.SuspendLayout();
            this.MainSplitontainer.Panel2.SuspendLayout();
            this.MainSplitontainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.gridSource)).BeginInit();
            this.SuspendLayout();
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[]
            {
                this.файлToolStripMenuItem, this.правкаToolStripMenuItem, this.сервисToolStripMenuItem,
                this.справкаToolStripMenuItem
            });
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(784, 24);
            this.mainMenu.TabIndex = 0;
            this.mainMenu.Text = "menuStrip1";
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[]
            {
                this.создатьToolStripMenuItem, this.OpenToolStripMenuItem, this.toolStripSeparator,
                this.сохранитьToolStripMenuItem, this.сохранитькакToolStripMenuItem, this.toolStripSeparator1,
                this.печатьToolStripMenuItem, this.предварительныйпросмотрToolStripMenuItem, this.toolStripSeparator2,
                this.выходToolStripMenuItem
            });
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "&Файл";
            this.создатьToolStripMenuItem.Image =
                ((System.Drawing.Image) (resources.GetObject("создатьToolStripMenuItem.Image")));
            this.создатьToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.создатьToolStripMenuItem.Name = "создатьToolStripMenuItem";
            this.создатьToolStripMenuItem.ShortcutKeys =
                ((System.Windows.Forms.Keys) ((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.создатьToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.создатьToolStripMenuItem.Text = "&Создать";
            this.OpenToolStripMenuItem.Image =
                ((System.Drawing.Image) (resources.GetObject("OpenToolStripMenuItem.Image")));
            this.OpenToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem";
            this.OpenToolStripMenuItem.ShortcutKeys =
                ((System.Windows.Forms.Keys) ((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.OpenToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.OpenToolStripMenuItem.Text = "&Открыть";
            this.OpenToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(230, 6);
            this.сохранитьToolStripMenuItem.Image =
                ((System.Drawing.Image) (resources.GetObject("сохранитьToolStripMenuItem.Image")));
            this.сохранитьToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.ShortcutKeys =
                ((System.Windows.Forms.Keys) ((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.сохранитьToolStripMenuItem.Text = "&Сохранить";
            this.сохранитькакToolStripMenuItem.Name = "сохранитькакToolStripMenuItem";
            this.сохранитькакToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.сохранитькакToolStripMenuItem.Text = "Сохранить &как";
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(230, 6);
            this.печатьToolStripMenuItem.Image =
                ((System.Drawing.Image) (resources.GetObject("печатьToolStripMenuItem.Image")));
            this.печатьToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.печатьToolStripMenuItem.Name = "печатьToolStripMenuItem";
            this.печатьToolStripMenuItem.ShortcutKeys =
                ((System.Windows.Forms.Keys) ((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.печатьToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.печатьToolStripMenuItem.Text = "&Печать";
            this.предварительныйпросмотрToolStripMenuItem.Image =
                ((System.Drawing.Image) (resources.GetObject("предварительныйпросмотрToolStripMenuItem.Image")));
            this.предварительныйпросмотрToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.предварительныйпросмотрToolStripMenuItem.Name = "предварительныйпросмотрToolStripMenuItem";
            this.предварительныйпросмотрToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.предварительныйпросмотрToolStripMenuItem.Text = "Предварительный про&смотр";
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(230, 6);
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.выходToolStripMenuItem.Text = "Вы&ход";
            this.правкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[]
            {
                this.отменадействияToolStripMenuItem, this.отменадействияToolStripMenuItem1, this.toolStripSeparator3,
                this.вырезатьToolStripMenuItem, this.копироватьToolStripMenuItem, this.вставкаToolStripMenuItem,
                this.toolStripSeparator4, this.выделитьвсеToolStripMenuItem
            });
            this.правкаToolStripMenuItem.Name = "правкаToolStripMenuItem";
            this.правкаToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.правкаToolStripMenuItem.Text = "&Правка";
            this.отменадействияToolStripMenuItem.Name = "отменадействияToolStripMenuItem";
            this.отменадействияToolStripMenuItem.ShortcutKeys =
                ((System.Windows.Forms.Keys) ((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.отменадействияToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.отменадействияToolStripMenuItem.Text = "&Отмена действия";
            this.отменадействияToolStripMenuItem1.Name = "отменадействияToolStripMenuItem1";
            this.отменадействияToolStripMenuItem1.ShortcutKeys =
                ((System.Windows.Forms.Keys) ((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.отменадействияToolStripMenuItem1.Size = new System.Drawing.Size(209, 22);
            this.отменадействияToolStripMenuItem1.Text = "&Отмена действия";
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(206, 6);
            this.вырезатьToolStripMenuItem.Image =
                ((System.Drawing.Image) (resources.GetObject("вырезатьToolStripMenuItem.Image")));
            this.вырезатьToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.вырезатьToolStripMenuItem.Name = "вырезатьToolStripMenuItem";
            this.вырезатьToolStripMenuItem.ShortcutKeys =
                ((System.Windows.Forms.Keys) ((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.вырезатьToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.вырезатьToolStripMenuItem.Text = "Вырезат&ь";
            this.копироватьToolStripMenuItem.Image =
                ((System.Drawing.Image) (resources.GetObject("копироватьToolStripMenuItem.Image")));
            this.копироватьToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.копироватьToolStripMenuItem.Name = "копироватьToolStripMenuItem";
            this.копироватьToolStripMenuItem.ShortcutKeys =
                ((System.Windows.Forms.Keys) ((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.копироватьToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.копироватьToolStripMenuItem.Text = "&Копировать";
            this.вставкаToolStripMenuItem.Image =
                ((System.Drawing.Image) (resources.GetObject("вставкаToolStripMenuItem.Image")));
            this.вставкаToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.вставкаToolStripMenuItem.Name = "вставкаToolStripMenuItem";
            this.вставкаToolStripMenuItem.ShortcutKeys =
                ((System.Windows.Forms.Keys) ((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.вставкаToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.вставкаToolStripMenuItem.Text = "Вст&авка";
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(206, 6);
            this.выделитьвсеToolStripMenuItem.Name = "выделитьвсеToolStripMenuItem";
            this.выделитьвсеToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.выделитьвсеToolStripMenuItem.Text = "Выделить &все";
            this.сервисToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[]
                {this.настройкиToolStripMenuItem, this.параметрыToolStripMenuItem});
            this.сервисToolStripMenuItem.Name = "сервисToolStripMenuItem";
            this.сервисToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.сервисToolStripMenuItem.Text = "&Сервис";
            this.настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            this.настройкиToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.настройкиToolStripMenuItem.Text = "&Настройки";
            this.параметрыToolStripMenuItem.Name = "параметрыToolStripMenuItem";
            this.параметрыToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.параметрыToolStripMenuItem.Text = "&Параметры";
            this.справкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[]
            {
                this.содержаниеToolStripMenuItem, this.индексToolStripMenuItem, this.поискToolStripMenuItem,
                this.toolStripSeparator5, this.опрограммеToolStripMenuItem
            });
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.справкаToolStripMenuItem.Text = "Спра&вка";
            this.содержаниеToolStripMenuItem.Name = "содержаниеToolStripMenuItem";
            this.содержаниеToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.содержаниеToolStripMenuItem.Text = "&Содержание";
            this.индексToolStripMenuItem.Name = "индексToolStripMenuItem";
            this.индексToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.индексToolStripMenuItem.Text = "&Индекс";
            this.поискToolStripMenuItem.Name = "поискToolStripMenuItem";
            this.поискToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.поискToolStripMenuItem.Text = "&Поиск";
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(155, 6);
            this.опрограммеToolStripMenuItem.Name = "опрограммеToolStripMenuItem";
            this.опрограммеToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.опрограммеToolStripMenuItem.Text = "&О программе...";
            this.MainSplitontainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainSplitontainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.MainSplitontainer.Location = new System.Drawing.Point(0, 24);
            this.MainSplitontainer.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MainSplitontainer.Name = "MainSplitontainer";
            this.MainSplitontainer.Panel1.Controls.Add(this.gridSettings);
            this.MainSplitontainer.Panel1MinSize = 250;
            this.MainSplitontainer.Panel2.Controls.Add(this.splitContainer2);
            this.MainSplitontainer.Panel2MinSize = 400;
            this.MainSplitontainer.Size = new System.Drawing.Size(784, 537);
            this.MainSplitontainer.SplitterDistance = 261;
            this.MainSplitontainer.TabIndex = 1;
            this.gridSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridSettings.LineColor = System.Drawing.SystemColors.ControlDark;
            this.gridSettings.Location = new System.Drawing.Point(0, 0);
            this.gridSettings.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.gridSettings.Name = "gridSettings";
            this.gridSettings.Size = new System.Drawing.Size(261, 537);
            this.gridSettings.TabIndex = 0;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.splitContainer2.Panel1.Controls.Add(this.gridSource);
            this.splitContainer2.Panel2.Controls.Add(this.rtxtLog);
            this.splitContainer2.Size = new System.Drawing.Size(519, 537);
            this.splitContainer2.SplitterDistance = 223;
            this.splitContainer2.SplitterWidth = 3;
            this.splitContainer2.TabIndex = 0;
            this.gridSource.AllowUserToAddRows = false;
            this.gridSource.AllowUserToDeleteRows = false;
            this.gridSource.ColumnHeadersHeightSizeMode =
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridSource.Location = new System.Drawing.Point(0, 0);
            this.gridSource.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.gridSource.Name = "gridSource";
            this.gridSource.ReadOnly = true;
            this.gridSource.Size = new System.Drawing.Size(519, 223);
            this.gridSource.TabIndex = 0;
            this.rtxtLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxtLog.Location = new System.Drawing.Point(0, 0);
            this.rtxtLog.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.rtxtLog.Name = "rtxtLog";
            this.rtxtLog.Size = new System.Drawing.Size(519, 311);
            this.rtxtLog.TabIndex = 0;
            this.rtxtLog.Text = "";
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.MainSplitontainer);
            this.Controls.Add(this.mainMenu);
            this.MainMenuStrip = this.mainMenu;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "MainWindow";
            this.Text = "Billing Provider";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.MainSplitontainer.Panel1.ResumeLayout(false);
            this.MainSplitontainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize) (this.MainSplitontainer)).EndInit();
            this.MainSplitontainer.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize) (this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize) (this.gridSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.SplitContainer MainSplitontainer;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.PropertyGrid gridSettings;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem создатьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитькакToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem печатьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem предварительныйпросмотрToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem правкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отменадействияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отменадействияToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem вырезатьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem копироватьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вставкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem выделитьвсеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сервисToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem настройкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem параметрыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem содержаниеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem индексToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem поискToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem опрограммеToolStripMenuItem;
        private System.Windows.Forms.RichTextBox rtxtLog;
        private System.Windows.Forms.DataGridView gridSource;
    }
}