using System;
using MW5.Shared;

namespace MW5.Plugins.Identifier.Enums
{
    internal class IdentifierModeConverter : IEnumConverter<IdentifierPluginMode>
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
            }
            throw new ApplicationException("Invalid IdentifierPluginMode mode");
        }
    }
}
