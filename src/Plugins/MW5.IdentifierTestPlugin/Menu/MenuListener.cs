
using System;
using MW5.Api;
using MW5.Api.Enums;
using MW5.Plugins.Concrete;
using MW5.Plugins.Events;
using MW5.Plugins.IdentifierTestPlugin.Properties;
using MW5.Plugins.Interfaces;
using MW5.UI.Menu;

namespace MW5.Plugins.IdentifierTestPlugin.Menu
{
    public class MenuListener: MenuServiceBase
    {
        private readonly IdentifierTestPlugin _plugin;
        
        public MenuListener(IAppContext context, IdentifierTestPlugin plugin):
            base(context, plugin.Identity)
        {
            if (plugin == null) throw new ArgumentNullException("plugin");
            _plugin = plugin;
            
            plugin.ItemClicked += plugin_ItemClicked;
            plugin.ViewUpdating += ViewUpdating;
        }

        private void ViewUpdating(object sender, EventArgs e)
        {
            var item = _context.Toolbars.FindItem(MenuKeys.IdentifyTool, _plugin.Identity);
            if (item != null)
            {
                item.Checked = _context.Map.MapCursor == MapCursor.Identify;
            }
        }

        void plugin_ItemClicked(object sender, MenuItemEventArgs e)
        {
            switch (e.ItemKey)
            {
                case MenuKeys.IdentifyTool:
                    _context.Map.MapCursor = MapCursor.Identify;
                    break;
            }
        }
    }
}
