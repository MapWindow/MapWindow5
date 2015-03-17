using System.Diagnostics;
using MW5.Plugins.Concrete;
using MW5.Plugins.IdentifierTestPlugin.Listeners;
using MW5.Plugins.IdentifierTestPlugin.Menu;
using MW5.Plugins.IdentifierTestPlugin.Properties;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mef;

namespace MW5.Plugins.IdentifierTestPlugin
{
    [PluginExport("Identifier test plugin", "Author", "1AECEA80-DCC3-4A34-89FB-7A2304B489FA")]
    public class IdentifierTestPlugin: BasePlugin
    {
        private string DOCK_PANEL_KEY = "IdentifierPluginDockPanel";
        private IAppContext _context;
        private MenuGenerator _menuGenerator;
        private MenuListener _menuListener;
        private MapListener _mapListener;
        private IdentifierControl _identifierControl;

        public override string Description
        {
            get { return "Plugin description"; }
        }

        public override void Initialize(IAppContext context)
        {
            _context = context;
        
            CompositionRoot.Compose(context.Container);
            _menuGenerator = context.Container.GetInstance<MenuGenerator>();
            _menuListener = context.Container.GetInstance<MenuListener>();
            _mapListener = context.Container.GetInstance<MapListener>();

            CreateDockWindow(context);
        }


        private void CreateDockWindow(IAppContext context)
        {
            _identifierControl = new IdentifierControl();

            var panels = context.DockPanels;

            panels.Lock();
            var panel = panels.Add(_identifierControl, DOCK_PANEL_KEY, Identity);
            panel.Caption = "Identifier";
            panel.SetIcon(Resources.ico_identify);

            var preview = panels.Preview;
            if (preview != null)
            {
                panel.DockTo(preview, DockPanelState.Tabbed, 150);
            }

            panels.Unlock();
        }

        public override void Terminate()
        {
            // menus & toolbars will be cleared automatically
        }
    }
}
