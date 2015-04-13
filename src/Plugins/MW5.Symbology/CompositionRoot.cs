using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Mvp;
using MW5.Plugins.Symbology.Services;
using MW5.Shared;

namespace MW5.Plugins.Symbology
{
    internal static class CompositionRoot
    {
        public static void Compose(IApplicationContainer container)
        {
            EnumHelper.RegisterConverter(new SymbologyTypeCoverter());
        }
    }
}
