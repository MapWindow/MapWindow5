using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Concrete;
using MW5.Plugins.Helpers;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mvp;
using MW5.Plugins.Services;
using MW5.Shared;

namespace MW5.Plugins
{
    internal static class CompositionRoot
    {
        public static void Compose(IApplicationContainer container)
        {
            container.RegisterSingleton<IBroadcasterService, PluginBroadcaster>()
                .RegisterSingleton<IPluginManager, PluginManager>()
                .RegisterSingleton<MainPlugin>();

            EnumHelper.RegisterConverter(new GdalDriverMetadataConverter());
            EnumHelper.RegisterConverter(new ZoomBoxStyleConverter());
            EnumHelper.RegisterConverter(new ZoombarVerbosityConverter());
            EnumHelper.RegisterConverter(new MouseWheelDirectionConverter());
            EnumHelper.RegisterConverter(new ZoomBehaviorConverter());
            EnumHelper.RegisterConverter(new ScalebarUnitsConverter());
            EnumHelper.RegisterConverter(new ResizeBehaviorConverter());
            EnumHelper.RegisterConverter(new AutoToggleConverter());
            EnumHelper.RegisterConverter(new ProjectionAbsenceConverter());
            EnumHelper.RegisterConverter(new ProjectionMistmatchConverter());
            EnumHelper.RegisterConverter(new SymbologyStorageConverter());
            EnumHelper.RegisterConverter(new ColorInterpretationConverter());
            EnumHelper.RegisterConverter(new UnitsOfMeasureConverter());
        }
    }
}
