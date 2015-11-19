using System;
using MW5.Api.Enums;
using MW5.Shared;

namespace MW5.Plugins.Identifier.Enums
{
    internal class IdentifierModeConverter : IEnumConverter<IdentifierMode>
    {
        public string GetString(IdentifierMode value)
        {
            switch (value)
            {
                case IdentifierMode.CurrentLayer:
                    return "Current layer";
                case IdentifierMode.AllLayers:
                    return "All layers";
                case IdentifierMode.AllLayersStopOnFirst:
                    return "Top down stop on first";
            }
            throw new ApplicationException("Invalid IdentifierMode mode");
        }
    }
}
