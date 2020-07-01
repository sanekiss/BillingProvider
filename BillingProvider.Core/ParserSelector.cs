using System;
using System.IO;
using System.Linq;
using BillingProvider.Core.Parsers;
using NLog;

namespace BillingProvider.Core
{
    public static class ParserSelector
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();

        public static IParser Select(string path)
        {
            if (path.EndsWith("xlsx") || path.EndsWith("xls"))
            {
                Log.Debug("Select xlsx parser");
                return new XlsxParser(path);
            }

            var firstLine = File.ReadLines(path).First();
            if (firstLine == "1CClientBankExchange")
            {
                Log.Debug("Select OneCParser");
                return new OneCParser(path);
            }

            if (firstLine.Contains("html"))
            {
                Log.Debug("Select HtmlKbbParser");
                return new HtmlKbbParser(path);
            }

            if (firstLine.Contains("#"))
            {
                Log.Debug("Select CsvKbbPareer");
                return new CsvKbbParser(path);
            }

            if (firstLine.Split(';').Length == 5)
            {
                Log.Debug("Select txtmail parser");
                return new TxtMailParser(path);
            }

            if (firstLine.Split('|').Length == 7)
            {
                Log.Debug("Select espsber parser");
                return new EspSberParser(path);
            }

            if (firstLine.Length < 10)
            {
                Log.Debug("Select CsvSberParser");
                return new CsvSberParser(path);
            }
            
            throw new ArgumentException();
        }
    }
}