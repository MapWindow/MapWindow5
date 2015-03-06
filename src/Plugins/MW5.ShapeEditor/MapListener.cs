using System;
using System.Collections.Generic;
using System.Diagnostics;
//using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Interfaces;
using MW5.Plugins.Concrete;
using MW5.Plugins.Interfaces;

namespace MW5.Plugins.ShapeEditor
{
    public class MapListener
    {
        private readonly BasePlugin _plugin;

        public MapListener(BasePlugin plugin)
        {
            if (plugin == null) throw new ArgumentNullException("plugin");

            _plugin = plugin;

            plugin.ExtentsChanged += plugin_ExtentsChanged;
            plugin.MapCursorChanged += plugin_MapCursorChanged;
            plugin.ChooseLayer += plugin_ChooseLayer;
        }

        void plugin_ChooseLayer(IMuteMap map, Api.Events.ChooseLayerEventArgs e)
        {
            Debug.Print("Choose layer");
            var layer = map.Layers.SelectedLayer;
            if (layer != null)
            {
                e.LayerHandle = layer.Handle;
            }
        }

        private void plugin_MapCursorChanged(IMuteMap sender, EventArgs e)
        {
            // TODO: update state of menu items
            Debug.Print("Map cursor changed");
        }

        private void plugin_ExtentsChanged(IMuteMap sender, EventArgs e)
        {
            
        }
    }
}
