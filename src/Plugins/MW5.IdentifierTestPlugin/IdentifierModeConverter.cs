using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Helpers;
using MW5.Shared;
using MW5.UI.Helpers;

namespace MW5.Plugins.IdentifierTestPlugin
{
    internal class IdentifierModeConverter: IEnumConverter<IdentifierPluginMode>
    {
        public string GetString(IdentifierPluginMode value)
        {
            switch (value)
            {
                case IdentifierPluginMode.CurrentLayer:
                    return "Current layer";
                case IdentifierPluginMode.AllLayers:
                    return "All layers";
                case IdentifierPluginMode.TopDownStopOnFirst:
                    return "Top down stop on first";
                case IdentifierPluginMode.LayerSelection:
                    return "Layer selection";
            }
            throw new ApplicationException("Invalid IdentifierPluginMode mode");
        }
    }
}
