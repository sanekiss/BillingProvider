using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using NLog;
using RestSharp;

namespace BillingProvider.Core.KKMDrivers
{
    public class AtolOnlineDriver : IKkmDriver
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();

        private readonly RestClient _client;
        readonly CancellationTokenSource _cancelTokenSource = new CancellationTokenSource();

        public AtolOnlineDriver(string inn, string groupId, string login, string password, string cashierName,
            string cashierVatin, string hostname, string companyEmail)
        {
            Inn = inn;
            GroupId = groupId;
            Login = login;
            Password = password;
            CashierName = cashierName;
            CashierVatin = cashierVatin;
            Hostname = hostname;
            CompanyEmail = companyEmail;

            _client = new RestClient("https://testonline.atol.ru/possystem/v4/");
        }

        public string Inn { get; }
        public string GroupId { get; }

        public string Address { get; } = string.Empty;
        public int Port { get; } = 0;
        public string Login { get; }
        public string Password { get; }
        public string Hostname { get; }
        public string CashierName { get; }
        public string CashierVatin { get; }
        
        public string CompanyEmail { get; }

        private string Token { get; set; }

        public async void RegisterCheck(string clientInfo, string name, string sum)
        {
            Log.Info($"Регистрация чека: {clientInfo}; {name}; {sum}");

            sum = sum.Replace(".", ",");
            var checkStrings = name.Split(';');
            var tmpStrings = new List<object>();
            foreach (var str in checkStrings)
            {
                var t = str.Split('+');
                tmpStrings.Add(
                    new
                    {
                        name = t[0],
                        price = decimal.Parse(t[1].Replace(".", ",")),
                        quantity = 1.0,
                        sum = decimal.Parse(t[1].Replace(".", ",")),
                        payment_object = "service",
                        payment_method = "full_payment",
                        vat = new
                        {
                            type = "vat0"
                        }
                    }
                );
            }

            RestRequest request;
            if (string.IsNullOrEmpty(Token))
            {
                request = new RestRequest("getToken", Method.POST)
                {
                    RequestFormat = DataFormat.Json
                };
                request.AddHeader("Content-Type", "application/json; charset=utf-8");
                request.AddBody(new {login = Login, pass = Password});
                var res3 = await _client.ExecuteTaskAsync<AuthResponse>(request, _cancelTokenSource.Token);
                Token = res3.Data.Token;
                Log.Info($"Получен токен: {Token}");
            }

            request = new RestRequest($"{GroupId}/sell", Method.POST)
            {
                RequestFormat = DataFormat.Json
            };
            request.AddHeader("Content-Type", "application/json; charset=utf-8");
            request.AddHeader("Token", Token);
            request.AddBody(
                new
                {
                    timestamp = DateTime.Now.ToString("dd.MM.yyyy hh:mm:ss"),
                    external_id = Guid.NewGuid().ToString("N"),
                    receipt = new
                    {
                        client = new
                        {
                            email = "none",
                            name = clientInfo,
                        },
                        company = new
                        {
                            email = CompanyEmail,
                            sno = "osn",
                            inn = Inn,
                            payment_address = Hostname
                        },
                        items = tmpStrings.ToArray(),
                        payments = new List<object>
                        {
                            new
                            {
                                type = 1,
                                sum = decimal.Parse(sum)
                            }
                        },
                        total = decimal.Parse(sum)
                    }
                }
            );
            var res = await _client.ExecuteTaskAsync<SellResponse>(request, _cancelTokenSource.Token);
            Log.Info($"UUID чека: {res.Data.Uuid}");
            // Log.Info(
            //     $"Ссылка для проверки состояния: https://testonline.atol.ru/possystem/v4/{GroupId}/report/{res.Data.Uuid}?token={Token}");

            var req = new RestRequest($"{GroupId}/report/{res.Data.Uuid}", Method.GET)
            {
                RequestFormat = DataFormat.Json
            };
            req.AddHeader("Token", Token);
            await Task.Delay(7500);
            var res0 = await _client.ExecuteTaskAsync<ReportResponse>(req, _cancelTokenSource.Token);
            var json = JObject.Parse(res0.Data.Payload);
            var url = json["ofd_receipt_url"];
            Log.Info($"Ссылка на ОФД ({res.Data.Uuid}): {url}");
        }

        public async void RegisterTestCheck()
        {
            RestRequest request;
            if (string.IsNullOrEmpty(Token))
            {
                request = new RestRequest("getToken", Method.POST)
                {
                    RequestFormat = DataFormat.Json
                };
                request.AddHeader("Content-Type", "application/json; charset=utf-8");
                request.AddBody(new {login = Login, pass = Password});
                var res3 = await _client.ExecuteTaskAsync<AuthResponse>(request, _cancelTokenSource.Token);
                Token = res3.Data.Token;
                Log.Info($"Получен токен: {Token}");
            }

            request = new RestRequest($"{GroupId}/sell", Method.POST)
            {
                RequestFormat = DataFormat.Json
            };
            request.AddHeader("Content-Type", "application/json; charset=utf-8");
            request.AddHeader("Token", Token);
            request.AddBody(new
            {
                timestamp = DateTime.Now.ToString("dd.MM.yyyy hh:mm:ss"),
                external_id = Guid.NewGuid().ToString("N"),
                receipt = new
                {
                    client = new
                    {
                        email = "none",
                        name = "Иванов И. И.",
                    },
                    company = new
                    {
                        email = "test@test.ru",
                        sno = "osn",
                        inn = Inn,
                        payment_address = Hostname
                    },
                    items = new List<object>
                    {
                        new
                        {
                            name = "Тестовая услуга",
                            price = 1.00,
                            quantity = 1.0,
                            sum = 1.00,
                            payment_object = "service",
                            payment_method = "full_payment",
                            vat = new
                            {
                                type = "vat0"
                            }
                        }
                    },
                    payments = new List<object>
                    {
                        new
                        {
                            type = 1,
                            sum = 1.00
                        }
                    },
                    total = 1.00
                }
            });
            var res = await _client.ExecuteTaskAsync<SellResponse>(request, _cancelTokenSource.Token);
            Log.Info($"UUID чека: {res.Data.Uuid}");
            // Log.Info(
            //     $"Ссылка для проверки состояния: https://testonline.atol.ru/possystem/v4/{GroupId}/report/{res.Data.Uuid}?token={Token}");

            var req = new RestRequest($"{GroupId}/report/{res.Data.Uuid}", Method.GET)
            {
                RequestFormat = DataFormat.Json
            };
            req.AddHeader("Token", Token);
            await Task.Delay(7500);
            var res0 = await _client.ExecuteTaskAsync<ReportResponse>(req, _cancelTokenSource.Token);
            var json = JObject.Parse(res0.Data.Payload);
            var url = json["ofd_receipt_url"];
            Log.Info($"Ссылка на ОФД: {url}");
        }

        public async void TestConnection()
        {
            var request = new RestRequest("getToken", Method.POST)
            {
                RequestFormat = DataFormat.Json
            };
            request.AddHeader("Content-Type", "application/json; charset=utf-8");
            request.AddBody(new {login = Login, pass = Password});
            var res = await _client.ExecuteTaskAsync<AuthResponse>(request, _cancelTokenSource.Token);
            Token = res.Data.Token;
            Log.Info($"Получен токен: {Token}");
            Log.Info($"Дата окончания: {res.Data.Timestamp}");
        }

        private class ReportResponse
        {
            public string Payload { get; set; }
        }

        private class AuthResponse
        {
            public string Token { get; set; }
            public string Timestamp { get; set; }
            public object Error { get; set; }
        }

        private class SellResponse
        {
            public string Uuid { get; set; }
            public string Status { get; set; }
            public string Error { get; set; }
            public string Timestamp { get; set; }
        }
    }
}