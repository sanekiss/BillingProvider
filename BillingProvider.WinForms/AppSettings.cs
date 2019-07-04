using System.ComponentModel;

namespace BillingProvider.WinForms
{
    //TODO: validation
    public class AppSettings
    {
        #region Server

        [Category("Сервер")]
        [Description("IP-адрес сервера с кассой")]
        [DisplayName("Адрес")]
        public string ServerAddress { get; set; } = "127.0.0.1";

        [Category("Сервер")]
        [Description("Порт, на котором запущен сервер")]
        [DisplayName("Порт")]
        public int ServerPort { get; set; } = 5893;

        #endregion

        #region Cashier

        [Category("Кассир")]
        [Description("Фамилия и инициалы текущего кассира")]
        [DisplayName("Имя")]
        public string CashierName { get; set; } = "Иванов И. И.";

        [Category("Кассир")]
        [Description("ИНН текущего кассира")]
        [DisplayName("ИНН")]
        public string CashierInn { get; set; } = "500100732259"; //TODO: correct name ИНН

        #endregion

        #region Company

        [Category("Компания")]
        [Description("Адрес электронной почты компании")]
        [DisplayName("Email")]
        public string CompanyMail { get; set; } = "admin@kuzro.ru";

        #endregion

        public AppSettings()
        {
            
        }
    }
}