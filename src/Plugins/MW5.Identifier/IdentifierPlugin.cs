using MW5.Plugins.Concrete;
using MW5.Plugins.Identifier.Listeners;
using MW5.Plugins.Identifier.Menu;
using MW5.Plugins.Identifier.Views;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mef;
using MW5.Plugins.Mvp;

namespace MW5.Plugins.Identifier
{
    [MapWindowPlugin()]
    public class IdentifierPlugin: BasePlugin
    {
        private IAppContext _context;
        private DockPanelService _dockPanelService;
        private MenuListener _menuListener;
        private MenuGenerator _menuGenerator;
        private MapListener _mapListener;

        public override void RegisterServices(IApplicationContainer container)
        {
            CompositionRoot.Compose(container);
        }

        public override void Initialize(IAppContext context)
        {
            _context = context;

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
