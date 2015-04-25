using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Mvp;
using MW5.Plugins.Symbology.Services;
using MW5.Plugins.Symbology.Views;
using MW5.Plugins.Symbology.Views.Abstract;
using MW5.Shared;

namespace MW5.Plugins.Symbology
{
    internal static class CompositionRoot
    {
        public static void Compose(IApplicationContainer container)
        {
            container.RegisterView<IRasterStyleView, RasterStyleView>().
                      RegisterView<IRasterMinMaxView, RasterMinMaxView>();

            EnumHelper.RegisterConverter(new SymbologyTypeCoverter());
            EnumHelper.RegisterConverter(new RasterRenderingConverter());
            EnumHelper.RegisterConverter(new RasterClassificationConverter());
        }
    }
}
