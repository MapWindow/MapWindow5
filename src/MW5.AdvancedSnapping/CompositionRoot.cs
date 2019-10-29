using MW5.Plugins.AdvancedSnapping.Context;
using MW5.Plugins.AdvancedSnapping.Listeners;
using MW5.Plugins.AdvancedSnapping.Services;
using MW5.Plugins.Mvp;

namespace MW5.Plugins.AdvancedSnapping
{
    internal static class CompositionRoot
    {
        public static void Compose(IApplicationContainer container)
        {
            container
                .RegisterSingleton<ISnapRestrictionService, SnapRestrictionService>()
                .RegisterSingleton<IAnchorService, AnchorService>()
                .RegisterSingleton<IDrawingService, DrawingService>()
                .RegisterSingleton<ContextMenuExtender>()
                .RegisterSingleton<MapListener>();
                
        }
    }
}
