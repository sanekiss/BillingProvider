namespace BillingProvider.Core.Models
{
    public class KkmServerResponse
    {
        public string Command { get; set; }
        public string Error { get; set; }
        public string Warning { get; set; }
        public string IdCommand { get; set; }

        public int Status { get; set; }
    }
}