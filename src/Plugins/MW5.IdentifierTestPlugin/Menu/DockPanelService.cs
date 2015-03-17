using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.IdentifierTestPlugin.Properties;
using MW5.Plugins.Interfaces;

namespace MW5.Plugins.IdentifierTestPlugin.Menu
{
    public class DockPanelService
    {
        private string DOCK_PANEL_KEY = "IdentifierPluginDockPanel";

        public DockPanelService(IAppContext context, IdentifierControl identifierControl, IdentifierTestPlugin plugin)
        {
            if (context == null) throw new ArgumentNullException("context");
            if (identifierControl == null) throw new ArgumentNullException("identifierControl");
            if (plugin == null) throw new ArgumentNullException("plugin");

            var panels = context.DockPanels;

            panels.Lock();
            var panel = panels.Add(identifierControl, DOCK_PANEL_KEY, plugin.Identity);
            panel.Caption = "Identifier";
            panel.SetIcon(Resources.ico_identify);

            var preview = panels.Preview;
            if (preview != null)
            {
                panel.DockTo(preview, DockPanelState.Tabbed, 150);
            }

            panels.Unlock();
        }
    }
}
