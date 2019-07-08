using System.Collections.Generic;

namespace BillingProvider.Core.Models
{
    public interface IParser
    {
        List<ClientInfo> data { get; }

        void Load(string file);
    }
}