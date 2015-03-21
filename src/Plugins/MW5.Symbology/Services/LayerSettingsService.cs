using System.Collections.Generic;
using MW5.Plugins.Symbology.Helpers;

namespace MW5.Plugins.Symbology.Services
{
    internal static class LayerSettingsService
    {
        private static Dictionary<int, SymbologySettings> _settings = new Dictionary<int, SymbologySettings>();

        internal static SymbologySettings get_LayerSettings(int layerHandle)
        {

            // TODO: restore
            //SymbologySettings settings = null;
            //MWLite.Symbology.Layer layer = Legend.GetLayer(layerHandle);
            //if (layer != null)
            //{
            //    settings = (SymbologySettings)layer.GetCustomObject("SymbologyPluginSettings");
            //}
            if (_settings.ContainsKey(layerHandle))
            {
                return _settings[layerHandle];
            }
            else
            {
                var settings = new SymbologySettings();
                _settings[layerHandle] = settings;
                return settings;
            }
        }

        /// <summary>
        /// Saves symbology settings for the layer
        /// </summary>
        internal static void SaveLayerSettings(int layerHandle, SymbologySettings settings)
        {
            // TODO: restore
            //MWLite.Symbology.Layer layer = Legend.GetLayer(layerHandle);
            //if (layer != null)
            //{
            //    layer.SetCustomObject(settings, "SymbologyPluginSettings");
            //}
        }

        internal static void SaveLayerOptions(int layerHandle)
        {
            // TODO: restore
            //if (mapWin.ApplicationInfo.SymbologyLoadingBehavior == MapWindow.Interfaces.SymbologyBehavior.DefaultOptions)
            //{
            //    AxMapWinGIS.AxMap map = Globals.Map;
            //    if (map != null)
            //    {
            //        map.SaveLayerOptions(LayerHandle, "", true, "");
            //    }
            //}
        }
    }
}
