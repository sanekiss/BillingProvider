using System.Collections.Generic;

namespace BillingProvider.Core.Models
{
    public class HtmlParser : IParser
    {
        public List<ClientInfo> data { get; }

        public HtmlParser()
        {
            data = new List<ClientInfo>();
        }


        public void Load(string file)
        {
//            var doc = new HtmlDocument();
//
//            doc.Load(openFileDialog.FileName, Encoding.UTF8);
//            var dt = new DataTable();
//
//            var captions = doc.DocumentNode.Descendants("th").ToList();
//            foreach (var cell in captions)
//            {
//                dt.Columns.Add(cell.InnerText.Trim(), typeof(string));
//            }
//
//            gridSource.DataSource = dt;
//
//            foreach (var row in doc.DocumentNode.SelectNodes("//tr").Skip(1))
//            {
//                var data = row.Descendants("td").Select(x => x.InnerText.Trim()).Cast<object>().ToArray();
//                dt.LoadDataRow(data, LoadOption.Upsert);
//
//                gridSource.Update();
        }
    }
}