using System;
using MW5.Plugins.Enums;
using MW5.Plugins.Identifier.Properties;
using MW5.Plugins.Identifier.Views;
using MW5.Plugins.Interfaces;

namespace MW5.Plugins.Identifier.Menu
{
    public class DockPanelService
    {
        private const string DockPanelKey = "IdentifierPluginDockPanel";

        public DockPanelService(IAppContext context, IdentifierPresenter presenter, IdentifierPlugin plugin)
        {
            if (context == null) throw new ArgumentNullException("context");
            if (presenter == null) throw new ArgumentNullException("presenter");
            if (plugin == null) throw new ArgumentNullException("plugin");

            var panels = context.DockPanels;

            panels.Lock();
            var panel = panels.Add(presenter.GetInternalObject(), DockPanelKey, plugin.Identity);
            panel.Caption = "Identifier";
            panel.SetIcon(Resources.ico_identify);

            var preview = panels.Preview;
            if (preview != null && preview.Visible)
            {
                panel.DockTo(preview, DockPanelState.Tabbed, 150);
            }

            panels.Unlock();
        }
    }
}
