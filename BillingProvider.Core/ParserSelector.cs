using System.IO;
using System.Linq;
using NLog;

namespace BillingProvider.Core
{
    public static class ParserSelector
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();

        public static IParser Select(string path)
        {
            var firstLine = File.ReadLines(path).First();
            if (firstLine.Contains("html"))
            {
                Log.Debug("Select HtmlKbbParser");
                return new HtmlKbbParser(path);
            }

            Log.Debug("Select CsvSberParser");
            return new CsvSberParser(path);
        }
    }
}