using System.Diagnostics;
using MW5.Plugins.Concrete;
using MW5.Plugins.IdentifierTestPlugin.Listeners;
using MW5.Plugins.IdentifierTestPlugin.Menu;
using MW5.Plugins.IdentifierTestPlugin.Properties;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mef;
using MW5.UI.Helpers;

namespace MW5.Plugins.IdentifierTestPlugin
{
    [PluginExport("Identifier test plugin", "Author", "1AECEA80-DCC3-4A34-89FB-7A2304B489FA")]
    public class IdentifierTestPlugin: BasePlugin
    {
        private IAppContext _context;
        private DockPanelService _dockPanelService;
        private MenuGenerator _menuGenerator;
        private MapListener _mapListener;
        private IdentifierControl _identifierControl;

        static IdentifierTestPlugin()
        {
            EnumHelper.RegisterConverter(new IdentifierModeConverter());
        }

        public override string Description
        {
            get { return "Identifier test plugin"; }
        }

        public override void Initialize(IAppContext context)
        {
            _context = context;

            CompositionRoot.Compose(context.Container);

            // will better to preserve state if plugin is unloaded, therefore singleton
            _identifierControl = context.Container.GetSingleton<IdentifierControl>();   
            
            _menuGenerator = context.Container.GetInstance<MenuGenerator>();
            _mapListener = context.Container.GetInstance<MapListener>();
            _dockPanelService = context.Container.GetInstance<DockPanelService>();
        }
        
        public override void Terminate()
        {

        }
    }
}
