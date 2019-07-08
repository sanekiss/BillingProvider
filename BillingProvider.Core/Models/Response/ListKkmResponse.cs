using System.Collections.Generic;
using Newtonsoft.Json;

namespace BillingProvider.Core.Models.Response
{
    public partial class ListKkmResponse
    {
        public static ListKkmResponse FromJson(string json) =>
            JsonConvert.DeserializeObject<ListKkmResponse>(json, BillingProvider.Core.Models.Converter.Settings);
    }

    public partial class ListKkmResponse
    {
        [JsonProperty("ListUnit", Required = Required.Always)]
        public List<ListUnit> ListUnit { get; set; }

        [JsonProperty("Command", Required = Required.Always)]
        public string Command { get; set; }

        [JsonProperty("Error", Required = Required.Always)]
        public string Error { get; set; }

        [JsonProperty("Status", Required = Required.Always)]
        public long Status { get; set; }
    }
}