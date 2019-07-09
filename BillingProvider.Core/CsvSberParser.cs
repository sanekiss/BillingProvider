using System.Collections.Generic;
using System.Text;
using BillingProvider.Core.Models;
using Microsoft.VisualBasic.FileIO;

namespace BillingProvider.Core
{
    public class CsvSberParser : IParser
    {
        public CsvSberParser(string path)
        {
            Data = new List<ClientInfo>();
            Path = path;
            Captions = new List<string>()
            {
                "ФИО", "Адрес", "Сумма", "Позиции"
            };
        }

        public string Path { get; }
        public List<ClientInfo> Data { get; }
        public List<string> Captions { get; }

        public void Load()
        {
            using (var parser = new TextFieldParser(Path, Encoding.Default))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(";");
                while (!parser.EndOfData)
                {
                    var row = parser.ReadFields();
                    if (row.Length < 10)
                    {
                        continue;
                    }

                    var tmp = new ClientInfo();
                    tmp.Address = row[7];
                    tmp.Name = row[6];

                    var i = 10;
                    while (true)
                    {
                        tmp.Positions.Add(new Position {Name = row[i + 1], Sum = row[i + 2].Replace(",", ".")});

                        if (row[i + 3] == "[!]")
                        {
                            break;
                        }

                        i += 3;
                    }

                    tmp.Sum = row[i + 5];

                    Data.Add(tmp);
                }
            }
        }
    }
}