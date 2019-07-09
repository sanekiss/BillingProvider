using System.Collections.Generic;
using System.Linq;
using System.Text;
using BillingProvider.Core.Models;
using HtmlAgilityPack;

namespace BillingProvider.Core
{
    public class HtmlKbbParser : IParser
    {
        public List<ClientInfo> Data { get; }
        public List<string> Captions { get; }
        public string Path { get; }

        public HtmlKbbParser(string path)
        {
            Path = path;
            Data = new List<ClientInfo>();
            Captions = new List<string>()
            {
                "ФИО", "Адрес", "Сумма", "Позиции"
            };
        }


        public void Load()
        {
            var doc = new HtmlDocument();
            doc.Load(Path, Encoding.UTF8);

            foreach (var row in doc.DocumentNode.SelectNodes("//tr").Skip(1))
            {
                var data = row.Descendants("td").Select(x => x.InnerText.Trim()).ToList();
                var info = new ClientInfo
                {
                    Address = $"{data[0]}, {data[1]}, {data[2]}",
                    Name = data[3],
                    Sum = data[7]
                };

                info.Positions.Add(new Position()
                {
                    Name = data[8],
                    Sum = data[7]
                });

                Data.Add(info);
            }
        }
    }
}