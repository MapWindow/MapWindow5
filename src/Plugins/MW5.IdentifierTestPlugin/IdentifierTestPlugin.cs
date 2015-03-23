using System.Diagnostics;
using MW5.Plugins.Concrete;
using MW5.Plugins.IdentifierTestPlugin.Listeners;
using MW5.Plugins.IdentifierTestPlugin.Menu;
using MW5.Plugins.IdentifierTestPlugin.Properties;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mef;
using MW5.Plugins.Services;
using MW5.UI.Helpers;

namespace MW5.Plugins.IdentifierTestPlugin
{
    [PluginExport()]
    public class IdentifierTestPlugin: BasePlugin
    {
        private IAppContext _context;
        private DockPanelService _dockPanelService;
        private MenuService _menuService;
        private MapListener _mapListener;
        private IdentifierControl _identifierControl;

        static IdentifierTestPlugin()
        {
            EnumHelper.RegisterConverter(new IdentifierModeConverter());
        }

        public override void Initialize(IAppContext context)
        {
            _context = context;

            CompositionRoot.Compose(context.Container);

            // will better to preserve state if plugin is unloaded, therefore singleton
            _identifierControl = context.Container.GetSingleton<IdentifierControl>();   
            
            _menuService = context.Container.GetInstance<MenuService>();
            _mapListener = context.Container.GetInstance<MapListener>();
            _dockPanelService = context.Container.GetInstance<DockPanelService>();
        }
        
        public override void Terminate()
        {

        }
    }
}
