using System;
using System.Collections.Generic;
using System.Diagnostics;
//using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Interfaces;
using MW5.Plugins.Concrete;
using MW5.Plugins.Interfaces;
using MW5.Plugins.ShapeEditor.Menu;

namespace MW5.Plugins.ShapeEditor
{
    public class MapListener
    {
        private readonly IAppContext _context;

        public MapListener(BasePlugin plugin, IAppContext context)
        {
            if (context == null) throw new ArgumentNullException("context");

            _context = context;

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
            Debug.Print("Map cursor changed");
            _context.Toolbars.FindItem(MenuKeys.GeometryCreate).Checked = _context.Map.MapCursor == Api.MapCursor.AddShape;
            _context.Toolbars.FindItem(MenuKeys.VertexEditor).Checked = _context.Map.MapCursor == Api.MapCursor.EditShape;
        }

        private void plugin_ExtentsChanged(IMuteMap sender, EventArgs e)
        {
            
        }
    }
}
