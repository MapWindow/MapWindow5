using System;
using System.Diagnostics;
using MW5.Api.Legend.Abstract;
using MW5.Api.Legend.Events;
using MW5.Plugins.Interfaces;

namespace MW5.Plugins.IdentifierTestPlugin.Listeners
{
    public class MapListener
    {
        private readonly IAppContext _context;
        private readonly IdentifierTestPlugin _plugin;
        private readonly IdentifierControl _identifierControl;

        public MapListener(IAppContext context, IdentifierTestPlugin plugin, IdentifierControl identifierControl)
        {
            if (context == null) throw new ArgumentNullException("context");
            if (plugin == null) throw new ArgumentNullException("plugin");
            if (identifierControl == null) throw new ArgumentNullException("identifierControl");

            _context = context;
            _plugin = plugin;
            _identifierControl = identifierControl;

            _plugin.ShapeIdentified += _plugin_ShapeIdentified;
        }

        private void _plugin_ShapeIdentified(Api.Interfaces.IMuteMap map, Api.Events.ShapeIdentifiedEventArgs e)
        {
            _identifierControl.OnShapeIdentified(map, e);
        }
    }
}
