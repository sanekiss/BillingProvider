using System.Net.Sockets;
using NLog;

namespace BillingProvider.WinForms
{
    public static class Utils
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();


        public static void ServerAvailable(string server, int port)
        {
            var tcpClient = new TcpClient();
            try
            {
                tcpClient.Connect(server, port);
                Log.Info($"Сервер {server}:{port} доступен!");
            }
            catch 
            {
                Log.Warn($"Сервер {server}:{port} не доступен!");
            }
        }
    }
}