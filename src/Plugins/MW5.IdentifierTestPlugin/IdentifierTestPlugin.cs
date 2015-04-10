using System.Diagnostics;
using MW5.Api.Helpers;
using MW5.Plugins.Concrete;
using MW5.Plugins.IdentifierTestPlugin.Listeners;
using MW5.Plugins.IdentifierTestPlugin.Menu;
using MW5.Plugins.IdentifierTestPlugin.Properties;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mef;
using MW5.Plugins.Mvp;
using MW5.Plugins.Services;
using MW5.Shared;
using MW5.UI.Helpers;

namespace MW5.Plugins.IdentifierTestPlugin
{
    [PluginExport()]
    public class IdentifierTestPlugin: BasePlugin
    {
        private IAppContext _context;
        private DockPanelService _dockPanelService;
        private MenuListener _menuListener;
        private MenuGenerator _menuGenerator;
        private MapListener _mapListener;
        private IdentifierControl _identifierControl;

        public override void RegisterServices(IApplicationContainer container)
        {
            CompositionRoot.Compose(container);

            EnumHelper.RegisterConverter(new IdentifierModeConverter());
        }

        public override void Initialize(IAppContext context)
        {
            _context = context;

            // will better to preserve state if plugin is unloaded, therefore singleton
            _identifierControl = context.Container.GetSingleton<IdentifierControl>();

            _menuGenerator = context.Container.GetInstance<MenuGenerator>();
            _menuListener = context.Container.GetInstance<MenuListener>();
            _mapListener = context.Container.GetInstance<MapListener>();
            _dockPanelService = context.Container.GetInstance<DockPanelService>();
        }
        
        public override void Terminate()
        {

        }
    }
}
