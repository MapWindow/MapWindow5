using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Interfaces;
using MW5.Plugins.Interfaces;

namespace MW5.Plugins.TemplatePlugin
{
    public class MapListener
    {
        private readonly IAppContext _context;
        private readonly TemplatePlugin _plugin;

        public MapListener(IAppContext context, TemplatePlugin plugin)
        {
            if (context == null) throw new ArgumentNullException("context");
            if (plugin == null) throw new ArgumentNullException("plugin");
            
            _context = context;
            _plugin = plugin;

            _plugin.ExtentsChanged+=_plugin_ExtentsChanged;
        }

        private void _plugin_ExtentsChanged(IMuteMap map, EventArgs e)
        {
            Debug.Print("Extents changed: " + map.Extents);
        }
    }
}
