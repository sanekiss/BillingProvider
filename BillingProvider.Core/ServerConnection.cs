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

        public string CashierName { get; }
        public string CashierVatin { get; }

        public readonly List<string> AvailableCommands = new List<string>();

        public ServerConnection(int port, string address, string login, string password, string cashierName,
            string cashierVatin)
        {
            Port = port;
            Address = address;
            Login = login;
            Password = password;
            CashierName = cashierName;
            CashierVatin = cashierVatin;
            _restClient = new RestClient($"http://{Address}:{Port}");
        }


        private void ExecuteCommand(object obj)
        {
            var request = new RestRequest("Execute/", Method.POST)
            {
                RequestFormat = DataFormat.Json
            };


            var bytes = Encoding.UTF8.GetBytes($"{Login}:{Password}");

            request.AddHeader("Authorization", $"Basic {Convert.ToBase64String(bytes)}");
            request.AddBody(obj);
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

        public void GetDataKkt()
        {
            ExecuteCommand(new
            {
                Command = "GetDataKKT",
                NumDevice = 0,
                IdCommand = Guid.NewGuid().ToString("N")
            });
        }

        public void RegisterTestCheck()
        {
            ExecuteCommand(new
            {
                Command = "RegisterCheck",
                NumDevice = 0,
                IdCommand = Guid.NewGuid().ToString("N"),
                IsFiscalCheck = true,
                TypeCheck = 0,
                NotPrint = false,
                NumberCopies = 0,
                CashierName,
                CashierVATIN = CashierVatin,
                ClientInfo = CashierName,
                CheckStrings = new[]
                {
                    new
                    {
                        Register = new
                        {
                            Name = "Тестовая услуга",
                            Quantity = 1,
                            Price = 1,
                            Tax = 20,
                            Amount = 1.00,
                            EAN13 = "1254789547853",
                            SignMethodCalculation = 4,
                            SignCalculationObject = 4
                        }
                    }
                },

                ElectronicPayment = 1
            });
        }

        public void RegisterCheck(string clientInfo, string name, int sum, string ean13)
        {
            ExecuteCommand(new
            {
                Command = "RegisterCheck",
                NumDevice = 0,
                IdCommand = Guid.NewGuid().ToString("N"),
                IsFiscalCheck = true,
                TypeCheck = 0,
                NotPrint = false,
                NumberCopies = 0,
                CashierName,
                CashierVATIN = CashierVatin,
                ClientInfo = clientInfo,
                CheckStrings = new[]
                {
                    new
                    {
                        Register = new
                        {
                            Name = name,
                            Quantity = 1,
                            Price = sum,
                            Tax = 20,
                            Amount = sum,
                            EAN13 = ean13,
                            SignMethodCalculation = 4,
                            SignCalculationObject = 4
                        }
                    }
                },

                ElectronicPayment = sum
            });
        }


        public void List()
        {
            ExecuteCommand(new
            {
                Command = "List",
                NumDevice = 0
            });
        }
    }
}