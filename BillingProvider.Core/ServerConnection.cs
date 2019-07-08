using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using NLog;
using RestSharp;

namespace BillingProvider.Core
{
    public class ServerConnection
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();
        private readonly RestClient _restClient;
        public int Port { get; }
        public string Address { get; }
        public string Login { get; }
        public string Password { get; }

        public readonly List<string> AvailableCommands = new List<string>();

        public ServerConnection(int port, string address, string login, string password)
        {
            Port = port;
            Address = address;
            Login = login;
            Password = password;
            _restClient = new RestClient($"http://{Address}:{Port}");
        }


        public void ExecuteCommand()
        {
            GetDataKkt();
        }

        public void GetDataKkt()
        {
            var request = new RestRequest("Execute/", Method.POST)
            {
                RequestFormat = DataFormat.Json
            };


            var bytes = Encoding.UTF8.GetBytes($"{Login}:{Password}");

            request.AddHeader("Authorization", $"Basic {Convert.ToBase64String(bytes)}");
            request.AddBody(new
            {
                Command = "GetDataKKT",
                NumDevice = 0,
                IdCommand = Guid.NewGuid().ToString("N")
            });
            _restClient.ExecuteAsync(request, restResponse =>
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