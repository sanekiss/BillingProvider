using System;
using System.Net;
using System.Text;
using NLog;
using RestSharp;

namespace BillingProvider.Core
{
    public class ServerConnection
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();
        public int Port { get; }
        public string Address { get; }
        public string Login { get; }
        public string Password { get; }

        public ServerConnection(int port, string address, string login, string password)
        {
            Port = port;
            Address = address;
            Login = login;
            Password = password;
        }


        public void ExecuteCommand()
        {
            var client = new RestClient($"http://{Address}:{Port}");
            var request = new RestRequest("Execute/", Method.POST)
            {
                RequestFormat = DataFormat.Json
            };


            var bytes = Encoding.UTF8.GetBytes($"{Login}:{Password}");
            var btoa = Convert.ToBase64String(bytes);

            request.AddHeader("Authorization", $"Basic {btoa}");
            request.AddBody(new Models.GetDataKktRequest
            {
                Command = "GetDataKKT",
                NumDevice = 0,
                IdCommand = Guid.NewGuid().ToString("N")
            });
            client.ExecuteAsync(request, restResponse =>
            {
                if (restResponse.StatusCode != HttpStatusCode.OK)
                {
                    Log.Error($"{restResponse.StatusCode}: {restResponse.StatusDescription}");
                }
                else
                {
                    Log.Info(restResponse.Content);
                }
            });
        }
    }
}