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
            Log.Debug("Begin command execution");
            var request = new RestRequest("Execute/", Method.POST)
            {
                RequestFormat = DataFormat.Json
            };


            var bytes = Encoding.UTF8.GetBytes($"{Login}:{Password}");

            request.AddHeader("Authorization", $"Basic {Convert.ToBase64String(bytes)}");
            request.AddBody(obj);
            Log.Debug($"Request: obj0={request.Parameters?[0]}");
            Log.Debug($"Request: obj1={request.Parameters?[1]}");

            _restClient.ExecuteAsync(request, restResponse =>
            {
                if (restResponse.StatusCode != HttpStatusCode.OK)
                {
                    Log.Error($"{restResponse.StatusCode}: {restResponse.StatusDescription}");
                    throw new Exception();
                }

                Log.Info(restResponse.Content);
            });
        }

        public void GetDataKkt()
        {
            Log.Info($"Получение текущего состояниея КТТ");
            ExecuteCommand(new
            {
                Command = "GetDataKKT",
                NumDevice = 0,
                IdCommand = Guid.NewGuid().ToString("N")
            });
        }

        public void RegisterTestCheck()
        {
            Log.Info($"Регистрация тестового чека");
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
                            SignMethodCalculation = 4,
                            SignCalculationObject = 4
                        }
                    }
                },

                ElectronicPayment = 1
            });
        }

        public void RegisterCheck(string clientInfo, string name, string sum)
        {
            Log.Info($"Регистрация чека: {clientInfo}; {name}; {sum}");

            sum = sum.Replace(",", ".");
            var checkStrings = name.Split(';');
            var tmpStrings = new List<object>();
            foreach (var str in checkStrings)
            {
                var t = str.Split('#');
                tmpStrings.Add(new
                {
                    Register = new
                    {
                        Name = t[0],
                        Quantity = 1,
                        Price = t[1].Replace(",", "."),
                        Tax = 20,
                        Amount = t[1].Replace(",", "."),
                        SignMethodCalculation = 4,
                        SignCalculationObject = 4
                    }
                });
            }

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
                CheckStrings = tmpStrings.ToArray(),
                ElectronicPayment = sum
            });
        }


        public void List()
        {
            Log.Info("Получение списка устройств");
            ExecuteCommand(new
            {
                Command = "List",
                NumDevice = 0
            });
        }
    }
}