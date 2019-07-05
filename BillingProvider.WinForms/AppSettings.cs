using System;
using System.ComponentModel;
using System.Configuration;
using NLog;

namespace BillingProvider.WinForms
{
    //TODO: validation

    public class AppSettings
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();

        #region Server

        [Category("Сервер")]
        [Description("IP-адрес сервера с кассой")]
        [DisplayName("Адрес")]
        public string ServerAddress { get; set; } = "127.0.0.1";

        [Category("Сервер")]
        [Description("Порт, на котором запущен сервер")]
        [DisplayName("Порт")]
        public int ServerPort { get; set; } = 5893;


        [Category("Сервер")]
        [Description("Имя учетной записи kktserver")]
        [DisplayName("Логин")]
        public string ServerLogin { get; set; } = "Admin";

        [Category("Сервер")]
        [Description("Пароль от учетной записи kktserver")]
        [DisplayName("Пароль")]
        public string ServerPassword { get; set; } = "";

        #endregion

        #region Cashier

        [Category("Кассир")]
        [Description("Фамилия и инициалы текущего кассира")]
        [DisplayName("Имя")]
        public string CashierName { get; set; } = "Иванов И. И.";

        [Category("Кассир")]
        [Description("ИНН текущего кассира")]
        [DisplayName("ИНН")]
        public string CashierVatin { get; set; } = "500100732259";

        #endregion

        #region Company

        [Category("Компания")]
        [Description("Адрес электронной почты компании")]
        [DisplayName("Email")]
        public string CompanyMail { get; set; } = "admin@kuzro.ru";

        #endregion

        public AppSettings()
        {
            Log.Debug("Begin app settings loading");
            try
            {
                ServerAddress = ConfigurationManager.AppSettings[$"{nameof(ServerAddress)}"];
                Log.Trace($"{nameof(ServerAddress)}='{ServerAddress}'");

                ServerPort = int.Parse(ConfigurationManager.AppSettings[$"{nameof(ServerPort)}"]);
                Log.Trace($"{nameof(ServerPort)}='{ServerPort}'");

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


                Check();
            }
            catch (Exception e)
            {
                Log.Fatal(e, "Error settings loading");
            }
            finally
            {
                Log.Debug("End app settings loading");
            }
        }

        private void Check()
        {
            Log.Debug("Begin checking app settings");

            //TODO

            Log.Debug("End checking app settings");
        }

        //TODO
        public bool SetValue(object property, object value)
        {
            return true;
        }
    }
}