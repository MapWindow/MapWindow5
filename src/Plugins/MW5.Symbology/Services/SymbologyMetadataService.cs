using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Concrete;
using MW5.Plugins.Interfaces;
using MW5.Services.Config;

namespace MW5.Plugins.Symbology.Services
{
    public class SymbologyMetadataService: LayerMetadataServiceBase<SymbologyMetadata>
    {
        public SymbologyMetadataService(IAppContext context, SymbologyPlugin plugin) : base(context, plugin)
        {
        }
    }
}
