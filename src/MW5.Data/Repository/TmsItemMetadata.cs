using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Model;

namespace MW5.Data.Repository
{
    public class TmsItemMetadata : IItemMetadata
    {
        public TmsItemMetadata(TmsProvider provider)
        {
            Provider = provider;
        }

        public TmsProvider Provider { get; set; }
    }
}
