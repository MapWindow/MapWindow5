using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.UI.Helpers;

namespace MW5.Plugins.Symbology.Services
{
    internal class SymbologyTypeCoverter : IEnumConverter<SymbologyType>
    {
        public string GetString(SymbologyType value)
        {
            switch (value)
            {
                case SymbologyType.Default:
                    return "Default options stored in the .mwsymb or .mwsr files";
                case SymbologyType.Random:
                    return "Options set randomly by MapWinGIS ActiveX control";
                case SymbologyType.Custom:
                default:
                    return "Custom symbology";
            }
        }
    }
}
