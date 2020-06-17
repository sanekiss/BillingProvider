using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using BillingProvider.Core.Models;
using ExcelDataReader;
using NLog;

namespace BillingProvider.Core.Parsers
{
    public class EspSberParser : IParser
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();
        public List<ClientInfo> Data { get; }
        public List<string> Captions { get; }
        public string Path { get; }

        public EspSberParser(string path)
        {
            Data = new List<ClientInfo>();
            Path = path;
            Captions = new List<string>
            {
                "ФИО", "Адрес", "Сумма", "Позиции"
            };
        }

        public void Load()
        {
            Log.Debug("Begin espsber parsing");
            using (var stream = File.Open(Path, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateCsvReader(stream, new ExcelReaderConfiguration
                {
                    FallbackEncoding = Encoding.GetEncoding(1251),
                    AutodetectSeparators = new[] {'|'}
                }))
                {
                    var result = reader.AsDataSet().Tables[0].Rows;
                    for (var i = 0; i < result.Count - 1; i++)
                    {
                        var x = result[i];
                        Log.Debug($"{x[1]}; {x[2]}; Обращение с ТКО; {x[4]}");
                        var tmp = new ClientInfo
                        {
                            Address = x[1].ToString(),
                            Name = x[1].ToString(),
                        };
                        tmp.Positions.Add(new Position
                        {
                            Name = $"Услуга {x[2]}",
                            Sum = x[3].ToString().Insert(x[3].ToString().Length-2, ".")
                        });

                        tmp.Sum = x[3].ToString().Insert(x[3].ToString().Length - 2, ".");
                        
                        Data.Add(tmp);
                    }
                }
            }

            Log.Debug("End espsber parsing");
            Log.Info($"Файл {Path} успешно загружен");
        }
    }
}