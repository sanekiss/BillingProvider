namespace BillingProvider.Core.KKMDrivers
{
    public interface IKkmDriver
    {
        int Port { get; }
        string Address { get; }
        string Login { get; }
        string Password { get; }
        string CashierName { get; }
        string CashierVatin { get; }

        string CompanyEmail { get; }

        void RegisterCheck(string clientInfo, string name, string sum, string filePath);
        void RegisterTestCheck();

        void TestConnection();
    }
}