using Newtonsoft.Json;

namespace BillingProvider.Core.Models
{
    public static class Serialize
    {
        public static string ToJson(this GetDataKktRequest self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }
}