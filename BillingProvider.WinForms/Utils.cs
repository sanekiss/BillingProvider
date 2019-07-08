using System;
using System.Net;
using System.Net.Sockets;
using NLog;

namespace BillingProvider.WinForms
{
    public static class Utils
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();


        public static void ServerAvailable(string server)
        {
            try
            {
                WebRequest.Create(server).GetResponse();
                Log.Info($"Сервер {server} доступен!");
            }
            catch (Exception ex)
            {
                if (ex is SocketException)
                {
                    Log.Warn($"Сервер {server} не доступен! Причина:\n{ex.Message}");
                }
                else
                {
                    Log.Info($"Сервер {server} доступен!");
                }
            }
        }
    }
}