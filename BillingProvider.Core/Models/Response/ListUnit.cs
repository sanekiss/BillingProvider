using System;
using Newtonsoft.Json;

namespace BillingProvider.Core.Models.Response
{
    public class ListUnit
    {
        [JsonProperty("NumDevice", Required = Required.Always)]
        public long NumDevice { get; set; }

        [JsonProperty("IdDevice", Required = Required.Always)]
        public Guid IdDevice { get; set; }

        [JsonProperty("OnOf", Required = Required.Always)]
        public bool OnOf { get; set; }

        [JsonProperty("Active", Required = Required.Always)]
        public bool Active { get; set; }

        [JsonProperty("TypeDevice", Required = Required.Always)]
        public string TypeDevice { get; set; }

        [JsonProperty("IdTypeDevice", Required = Required.Always)]
        public string IdTypeDevice { get; set; }

        [JsonProperty("IP", Required = Required.Always)]
        public string Ip { get; set; }

        [JsonProperty("NameDevice", Required = Required.Always)]
        public string NameDevice { get; set; }

        [JsonProperty("KktNumber", Required = Required.Always)]
        public string KktNumber { get; set; }

        [JsonProperty("INN", Required = Required.Always)]
        public string Inn { get; set; }

        [JsonProperty("TaxVariant", Required = Required.Always)]
        public string TaxVariant { get; set; }

        [JsonProperty("AddDate", Required = Required.Always)]
        public DateTimeOffset AddDate { get; set; }

        [JsonProperty("OFD_Error", Required = Required.Always)]
        public string OfdError { get; set; }

        [JsonProperty("OFD_NumErrorDoc", Required = Required.Always)]
        public long OfdNumErrorDoc { get; set; }

        [JsonProperty("OFD_DateErrorDoc", Required = Required.Always)]
        public DateTimeOffset OfdDateErrorDoc { get; set; }

        [JsonProperty("FN_DateEnd", Required = Required.Always)]
        public DateTimeOffset FnDateEnd { get; set; }

        [JsonProperty("FN_MemOverflowl", Required = Required.Always)]
        public bool FnMemOverflowl { get; set; }

        [JsonProperty("FN_IsFiscal", Required = Required.Always)]
        public bool FnIsFiscal { get; set; }

        [JsonProperty("PaperOver", Required = Required.Always)]
        public bool PaperOver { get; set; }
    }
}