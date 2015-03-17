using System;
using System.Diagnostics;
using MW5.Plugins.Interfaces;

namespace MW5.Plugins.IdentifierTestPlugin.Listeners
{
    public class MapListener
    {
        private readonly IAppContext _context;
        private readonly IdentifierTestPlugin _plugin;

        public MapListener(IAppContext context, IdentifierTestPlugin plugin)
        {
            if (context == null) throw new ArgumentNullException("context");
            if (plugin == null) throw new ArgumentNullException("plugin");
            
            _context = context;
            _plugin = plugin;

            _plugin.LayerSelected += _plugin_LayerSelected;
        }

        void _plugin_LayerSelected(Api.Legend.Abstract.IMuteLegend legend, Api.Legend.Events.LayerEventArgs e)
        {
            Debug.Print("Layer selected: " + e.LayerHandle);
        }
    }
}
