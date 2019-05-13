using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Enums;
using MW5.Api.Interfaces;

namespace MW5.Plugins.Events
{
    public class TileProviderArgs: CancelEventArgs, ICancellableEvent
    {
        public TileProviderArgs(int providerId)
        {
            ProviderId = providerId;
        }

        public int ProviderId { get; set; }

        public bool IsBingProvider
        {
            get
            {
                var bingProviders = new[] { TileProvider.BingHybrid, TileProvider.BingMaps, TileProvider.BingSatellite };
                var list = bingProviders.Select(p => (int)p);
                return list.Contains(ProviderId);
            }
        }
    }
}
