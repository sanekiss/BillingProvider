using System;
using Newtonsoft.Json;

namespace BillingProvider.Core.Models.Response
{
    public class Info
    {
        [JsonProperty("UrlServerOfd", Required = Required.Always)]
        public string UrlServerOfd { get; set; }

        [JsonProperty("PortServerOfd", Required = Required.Always)]
        [JsonConverter(typeof(ParseStringConverter))]
        public long PortServerOfd { get; set; }

        [JsonProperty("NameOFD", Required = Required.Always)]
        public string NameOfd { get; set; }

        [JsonProperty("UrlOfd", Required = Required.Always)]
        public string UrlOfd { get; set; }

        [JsonProperty("InnOfd", Required = Required.Always)]
        public string InnOfd { get; set; }

        [JsonProperty("NameOrganization", Required = Required.Always)]
        public string NameOrganization { get; set; }

        [JsonProperty("TaxVariant", Required = Required.Always)]
        public string TaxVariant { get; set; }

        [JsonProperty("AddressSettle", Required = Required.Always)]
        public string AddressSettle { get; set; }

        [JsonProperty("EncryptionMode", Required = Required.Always)]
        public bool EncryptionMode { get; set; }

        [JsonProperty("OfflineMode", Required = Required.Always)]
        public bool OfflineMode { get; set; }

        [JsonProperty("AutomaticMode", Required = Required.Always)]
        public bool AutomaticMode { get; set; }

        [JsonProperty("InternetMode", Required = Required.Always)]
        public bool InternetMode { get; set; }

        [JsonProperty("BSOMode", Required = Required.Always)]
        public bool BsoMode { get; set; }

        [JsonProperty("ServiceMode", Required = Required.Always)]
        public bool ServiceMode { get; set; }

        [JsonProperty("InnOrganization", Required = Required.Always)]
        public string InnOrganization { get; set; }

        [JsonProperty("KktNumber", Required = Required.Always)]
        public string KktNumber { get; set; }

        [JsonProperty("FnNumber", Required = Required.Always)]
        public string FnNumber { get; set; }

        [JsonProperty("RegNumber", Required = Required.Always)]
        public string RegNumber { get; set; }

        [JsonProperty("Command", Required = Required.Always)]
        public string Command { get; set; }

        [JsonProperty("FN_IsFiscal", Required = Required.Always)]
        public bool FnIsFiscal { get; set; }

        [JsonProperty("OFD_Error", Required = Required.Always)]
        public string OfdError { get; set; }

        [JsonProperty("OFD_NumErrorDoc", Required = Required.Always)]
        public long OfdNumErrorDoc { get; set; }

        [JsonProperty("OFD_DateErrorDoc", Required = Required.Always)]
        public DateTimeOffset OfdDateErrorDoc { get; set; }

        [JsonProperty("FN_DateEnd", Required = Required.Always)]
        public DateTimeOffset FnDateEnd { get; set; }

        [JsonProperty("SessionState", Required = Required.Always)]
        public long SessionState { get; set; }
    }
}