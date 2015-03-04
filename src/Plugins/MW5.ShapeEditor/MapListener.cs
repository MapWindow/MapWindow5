using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Interfaces;
using MW5.Plugins.Concrete;

namespace MW5.Plugins.ShapeEditor
{
    public class MapListener
    {
        private readonly BasePlugin _plugin;

        public MapListener(BasePlugin plugin)
        {
            _plugin = plugin;

            plugin.ExtentsChanged += plugin_ExtentsChanged;
        }

        private void plugin_ExtentsChanged(IMuteMap sender, EventArgs e)
        {
            Debug.Print("Shape editor: map extents changed");
        }

        //void plugin_ExtentsChanged(object sender, EventArgs e)
        //{
        //    Debug.Print("Shape editor: map extents changed");
        //}
    }
}
