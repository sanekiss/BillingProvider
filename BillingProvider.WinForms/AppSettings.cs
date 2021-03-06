using System;
using System.ComponentModel;
using System.Configuration;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using BillingProvider.WinForms.Extensions;
using NLog;

namespace BillingProvider.WinForms
{
    //TODO: validation

    public class AppSettings
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();

        #region AtolOnline

        [Category("АТОЛ Онлайн")]
        [Description("ИНН организации; сравнивается со значением в фискальном накопителе")]
        [DisplayName("ИНН")]
        public string AtolOnlineINN { get; set; } = "";

        [Category("АТОЛ Онлайн")]
        [Description("Код группы ККТ, относящейся к интернет-магазину, зарегистрированному в “АТОЛ Онлайн”")]
        [DisplayName("Идентификатор группы ККТ")]
        public string AtolOnlineGroupID { get; set; } = "";

        [Category("АТОЛ Онлайн")]
        [Description("При расчётах в интернете это адрес сайта; сравнивается со значением в фискальном накопителе")]
        [DisplayName("Адрес места расчетов")]
        public string AtolOnlineHostname { get; set; } = "";

        [Category("АТОЛ Онлайн")]
        [Description(
            "Логин пользователя для отправки данных. Его можно получить из файла настроек для CMS в личном кабинете пользователя “АТОЛ Онлайн”")]
        [DisplayName("Логин")]
        [RefreshProperties(RefreshProperties.All)]
        public string AtolOnlineLogin { get; set; } = "";

        [Category("АТОЛ Онлайн")]
        [Description(
            "Пароль пользователя для отправки данных. Его можно получить из файла настроек для CMS в личном кабинете пользователя “АТОЛ Онлайн”")]
        [DisplayName("Пароль")]
        [RefreshProperties(RefreshProperties.All)]
        public string AtolOnlinePassword { get; set; } = "";

        #endregion

        #region KKMServer

        [Category("KKM Server")]
        [Description("IP-адрес сервера с кассой")]
        [DisplayName("Адрес")]
        public string ServerAddress { get; set; } = "127.0.0.1";

        [Category("KKM Server")]
        [Description("Порт, на котором запущен сервер")]
        [DisplayName("Порт")]
        public int ServerPort { get; set; } = 5893;

        [Category("KKM Server")]
        [Description("Номер устройства на сервере, 0 - первое активное")]
        [DisplayName("Номер устройства")]
        public int ServerDeviceId { get; set; }


        [Category("KKM Server")]
        [Description("Имя учетной записи kktserver")]
        [DisplayName("Логин")]
        public string ServerLogin { get; set; } = "Admin";

        [Category("KKM Server")]
        [Description("Пароль от учетной записи kktserver")]
        [DisplayName("Пароль")]
        public string ServerPassword { get; set; } = "";

        #endregion

        #region Cashier

        [Category("Кассир")]
        [Description("Фамилия и инициалы текущего кассира")]
        [DisplayName("Имя")]
        [RefreshProperties(RefreshProperties.All)]
        public string CashierName { get; set; }

        [Category("Кассир")]
        [Description("ИНН текущего кассира")]
        [DisplayName("ИНН")]
        [RefreshProperties(RefreshProperties.All)]
        public string CashierVatin { get; set; }

        #endregion

        #region Common

        [Category("Общие")]
        [Description("Адрес электронной почты компании")]
        [DisplayName("Email")]
        [RefreshProperties(RefreshProperties.All)]
        public string CompanyMail { get; set; }

        public enum KkmDrivers
        {
            [Description("АТОЛ Онлайн")]
            atol,
            [Description("KkmServer")]
            kkmserver
        }
        
        [Category("Общие")]
        [Description("Драйвер ККМ")]
        [DisplayName("Драйвер ККМ")]
        [RefreshProperties(RefreshProperties.All)]
        [TypeConverter(typeof(EnumTypeConverter))]
        public KkmDrivers KkmDriver { get; set; }
        
        #endregion


        #region Watcher

        [Category("Отслеживание папки")]
        [Description("Путь до папки")]
        [DisplayName("Папка")]
        [Editor(typeof(FolderNameEditor), typeof(UITypeEditor))]
        [RefreshProperties(RefreshProperties.All)]
        public string FolderPath { get; set; }

        
        [Category("Отслеживание папки")]
        [Description("Сканирование подпапок на наличие изменений")]
        [DisplayName("Включая подпапки")]
        [TypeConverter(typeof(BooleanToYesNoTypeConverter))]
        [RefreshProperties(RefreshProperties.All)]
        public bool IncludeSubfolders { get; set; }
        
        #endregion

        public AppSettings()
        {
            Log.Debug("Begin app settings loading");
            try
            {
                AtolOnlineINN = ConfigurationManager.AppSettings[$"{nameof(AtolOnlineINN)}"];
                Log.Trace($"{nameof(AtolOnlineINN)}='{AtolOnlineINN}'");

                AtolOnlineGroupID = ConfigurationManager.AppSettings[$"{nameof(AtolOnlineGroupID)}"];
                Log.Trace($"{nameof(AtolOnlineGroupID)}='{AtolOnlineGroupID}'");

                AtolOnlineHostname = ConfigurationManager.AppSettings[$"{nameof(AtolOnlineHostname)}"];
                Log.Trace($"{nameof(AtolOnlineHostname)}='{AtolOnlineHostname}'");

                AtolOnlineLogin = ConfigurationManager.AppSettings[$"{nameof(AtolOnlineLogin)}"];
                Log.Trace($"{nameof(AtolOnlineLogin)}='{AtolOnlineLogin}'");

                AtolOnlinePassword = ConfigurationManager.AppSettings[$"{nameof(AtolOnlinePassword)}"];
                Log.Trace($"{nameof(AtolOnlinePassword)}='{AtolOnlinePassword}'");

                ServerAddress = ConfigurationManager.AppSettings[$"{nameof(ServerAddress)}"];
                Log.Trace($"{nameof(ServerAddress)}='{ServerAddress}'");

                ServerPort = int.Parse(ConfigurationManager.AppSettings[$"{nameof(ServerPort)}"]);
                Log.Trace($"{nameof(ServerPort)}='{ServerPort}'");

                ServerDeviceId = int.Parse(ConfigurationManager.AppSettings[$"{nameof(ServerDeviceId)}"]);
                Log.Trace($"{nameof(ServerDeviceId)}='{ServerDeviceId}'");

                ServerLogin = ConfigurationManager.AppSettings[$"{nameof(ServerLogin)}"];
                Log.Trace($"{nameof(ServerLogin)}='{ServerLogin}'");

                ServerPassword = ConfigurationManager.AppSettings[$"{nameof(ServerPassword)}"];
                Log.Trace($"{nameof(ServerPassword)}='{ServerPassword}'");

                CashierName = ConfigurationManager.AppSettings[$"{nameof(CashierName)}"];
                Log.Trace($"{nameof(CashierName)}='{CashierName}'");

                CashierVatin = ConfigurationManager.AppSettings[$"{nameof(CashierVatin)}"];
                Log.Trace($"{nameof(CashierVatin)}='{CashierVatin}'");

                CompanyMail = ConfigurationManager.AppSettings[$"{nameof(CompanyMail)}"];
                Log.Trace($"{nameof(CompanyMail)}='{CompanyMail}'");           
                
                FolderPath = ConfigurationManager.AppSettings[$"{nameof(FolderPath)}"];
                Log.Trace($"{nameof(FolderPath)}='{FolderPath}'");

                IncludeSubfolders = Convert.ToBoolean(ConfigurationManager.AppSettings[$"{nameof(IncludeSubfolders)}"]);
                Log.Trace($"{nameof(IncludeSubfolders)}='{IncludeSubfolders}'");

                Check();
            }
            catch (Exception e)
            {
                Log.Fatal(e, "Error settings loading");
            }
            finally
            {
                Log.Debug("End app settings loading");
                Log.Info("Настройки успешно загружены!");
            }
        }

        private void Check()
        {
            Log.Debug("Begin checking app settings");

            //TODO

            Log.Debug("End checking app settings");
        }

        public void UpdateSettings()
        {
            Log.Debug("Begin saving app settings");

            var configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            configuration.AppSettings.Settings[nameof(AtolOnlineINN)].Value = AtolOnlineINN;
            Log.Trace($"{nameof(AtolOnlineINN)}='{AtolOnlineINN}'");
            
            configuration.AppSettings.Settings[nameof(AtolOnlineGroupID)].Value = AtolOnlineGroupID;
            Log.Trace($"{nameof(AtolOnlineGroupID)}='{AtolOnlineGroupID}'");
            
            configuration.AppSettings.Settings[nameof(AtolOnlineHostname)].Value = AtolOnlineHostname;
            Log.Trace($"{nameof(AtolOnlineHostname)}='{AtolOnlineHostname}'");
            
            configuration.AppSettings.Settings[nameof(AtolOnlineLogin)].Value = AtolOnlineLogin;
            Log.Trace($"{nameof(AtolOnlineLogin)}='{AtolOnlineLogin}'");
            
            configuration.AppSettings.Settings[nameof(AtolOnlinePassword)].Value = AtolOnlinePassword;
            Log.Trace($"{nameof(AtolOnlinePassword)}='{AtolOnlinePassword}'");

            configuration.AppSettings.Settings[nameof(ServerAddress)].Value = ServerAddress;
            Log.Trace($"{nameof(ServerAddress)}='{ServerAddress}'");

            configuration.AppSettings.Settings[nameof(ServerPort)].Value = ServerPort.ToString();
            Log.Trace($"{nameof(ServerPort)}='{ServerPort}'");

            configuration.AppSettings.Settings[nameof(ServerLogin)].Value = ServerLogin;
            Log.Trace($"{nameof(ServerLogin)}='{ServerLogin}'");

            configuration.AppSettings.Settings[nameof(ServerPassword)].Value = ServerPassword;
            Log.Trace($"{nameof(ServerPassword)}='{ServerPassword}'");

            configuration.AppSettings.Settings[nameof(CashierName)].Value = CashierName;
            Log.Trace($"{nameof(CashierName)}='{CashierName}'");

            configuration.AppSettings.Settings[nameof(CashierVatin)].Value = CashierVatin;
            Log.Trace($"{nameof(CashierVatin)}='{CashierVatin}'");

            configuration.AppSettings.Settings[nameof(CompanyMail)].Value = CompanyMail;
            Log.Trace($"{nameof(CompanyMail)}='{CompanyMail}'");

            configuration.AppSettings.Settings[nameof(ServerDeviceId)].Value = ServerDeviceId.ToString();
            Log.Trace($"{nameof(ServerDeviceId)}='{ServerDeviceId}'");

            configuration.AppSettings.Settings[nameof(FolderPath)].Value = FolderPath;
            Log.Trace($"{nameof(FolderPath)}='{FolderPath}'");
            
            configuration.AppSettings.Settings[nameof(IncludeSubfolders)].Value = IncludeSubfolders.ToString();
            Log.Trace($"{nameof(IncludeSubfolders)}='{IncludeSubfolders}'");
            

            configuration.Save(ConfigurationSaveMode.Full, true);
            ConfigurationManager.RefreshSection("appSettings");
            Log.Debug("End saving app settings");
            Log.Info("Настройки сохранены!");
        }
    }
}