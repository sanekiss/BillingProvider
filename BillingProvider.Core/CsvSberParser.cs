using System.Collections.Generic;
using BillingProvider.Core.Models;

namespace BillingProvider.Core
{
    public class CsvSberParser : IParser
    {
        public CsvSberParser(string path)
        {
            Data = new List<ClientInfo>();
            Path = path;
        }

        public string Path { get; }
        public List<ClientInfo> Data { get; }
        public List<string> Captions { get; }

        public void Load()
        {
            throw new System.NotImplementedException();
        }
    }
}