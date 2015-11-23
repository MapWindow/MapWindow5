using System;
using MW5.Plugins.Enums;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Repository.Properties;
using MW5.Plugins.Repository.Views;
using MW5.UI.Docking;

namespace MW5.Plugins.Repository.Services
{
    public class DockPanelService
    {
        public DockPanelService(IAppContext context, RepositoryPlugin plugin, RepositoryPresenter presenter)
        {
            if (context == null) throw new ArgumentNullException("context");
            if (plugin == null) throw new ArgumentNullException("plugin");
            if (presenter == null) throw new ArgumentNullException("presenter");

            var panels = context.DockPanels;

            panels.Lock();

            try
            {
                var panel = panels.Add(presenter.GetInternalObject(), DockPanelKeys.Repository, plugin.Identity);
                panel.Caption = "Repository";
                panel.SetIcon(Resources.ico_folder24);
                panel.DockTo(panels.Toolbox, DockPanelState.Tabbed, 300);
                panel.TabPosition = 0;
            }
            finally
            {
                panels.Unlock();
            }
        }
    }
}
