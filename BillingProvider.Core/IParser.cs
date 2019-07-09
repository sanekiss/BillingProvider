using System.Collections.Generic;
using BillingProvider.Core.Models;

namespace BillingProvider.Core
{
    public interface IParser
    {
        List<ClientInfo> Data { get; }
        List<string> Captions { get; }

        void Load();
    }
}