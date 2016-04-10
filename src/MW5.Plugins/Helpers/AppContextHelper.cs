using MW5.Plugins.Interfaces;
using MW5.Plugins.Model;

namespace MW5.Plugins.Helpers
{
    public static class AppContextHelper
    {
        /// <summary>
        /// Clears selection from all layers.
        /// </summary>
        internal static void ClearAllSelection(this IAppContext context)
        {
            foreach (var layer in context.Layers)
            {
                var fs = layer.FeatureSet;
                if (fs != null)
                {
                    fs.ClearSelection();
                }
            }
        }

        /// <summary>
        /// Activates the panel. Use DockPanelKeys members to specify correct key.
        /// </summary>
        internal static void ActivatePanel(this IAppContext context, string dockPanelKey)
        {
            var panel = context.DockPanels.Find(dockPanelKey);
            if (panel != null)
            {
                panel.Visible = true;
                panel.Activate();
            }
        }

        public static bool SetCustomTileProvider(this IAppContext context, TmsProvider provider)
        {
            var providers = context.Map.Tiles.Providers;
            providers.Clear(false);
            return providers.AddCustom(provider.Id, provider.Name, provider.Url, provider.Projection, provider.MinZoom, provider.MaxZoom);
        }
    }
}
