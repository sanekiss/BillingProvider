using Newtonsoft.Json;

namespace BillingProvider.Core.Models.Response
{
    public class DataKktResponse
    {
        public static Response FromJson(string json) =>
            JsonConvert.DeserializeObject<Response>(json, BillingProvider.Core.Models.Converter.Settings);
    }
}