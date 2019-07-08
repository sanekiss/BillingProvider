using System.Collections.Generic;

namespace BillingProvider.Core.Models
{
    public class ClientInfo
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Sum { get; set; }
        public List<Position> Positions { get; set; }
    }

    public class Position
    {
        public string Name { get; set; }
        public string Sum { get; set; }
    }
}