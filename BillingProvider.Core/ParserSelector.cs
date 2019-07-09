using System.IO;
using System.Linq;

namespace BillingProvider.Core
{
    public static class ParserSelector
    {
        public static IParser Select(string path)
        {
            var firstLine = File.ReadLines(path).First();
            if (firstLine.Contains("html"))
            {
                return new HtmlKbbParser(path);
            }

            return new CsvSberParser(path);
        }
    }
}