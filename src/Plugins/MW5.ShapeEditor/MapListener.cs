using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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

        public MapListener(IAppContext context, ShapeEditor plugin)
        {
            if (context == null) throw new ArgumentNullException("context");

            _context = context;

            plugin.ChooseLayer += plugin_ChooseLayer;
        }

        private  void plugin_ChooseLayer(IMuteMap map, Api.Events.ChooseLayerEventArgs e)
        {
            var layer = map.Layers.SelectedLayer;
            if (layer != null)
            {
                e.LayerHandle = layer.Handle;
            }
        }
    }
}
