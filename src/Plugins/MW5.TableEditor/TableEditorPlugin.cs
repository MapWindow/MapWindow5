using System;
using MW5.Plugins.Concrete;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mef;
using MW5.Plugins.Mvp;
using MW5.Plugins.TableEditor.Menu;
using MW5.Plugins.TableEditor.Services;

namespace MW5.Plugins.TableEditor
{
    [MapWindowPlugin(loadOnStartUp: true)]
    public class TableEditorPlugin: BasePlugin
    {
        private IAppContext _context;
        private MenuListener _menuListener;
        private MapListener _mapListener;
        private MenuGenerator _menuGenerator;
        private ProjectListener _projectListener;
        private DockPanelService _dockPanelService;

        protected override void RegisterServices(IApplicationContainer container)
        {
            CompositionRoot.Compose(container);
        }

        public override void Initialize(IAppContext context)
        {
            if (context == null) throw new ArgumentNullException("context");
            _context = context;

            _menuGenerator = _context.Container.GetInstance<MenuGenerator>();
            _menuListener = _context.Container.GetSingleton<MenuListener>();
            _mapListener = _context.Container.GetSingleton<MapListener>();
            _projectListener = _context.Container.GetSingleton<ProjectListener>();
            _dockPanelService = _context.Container.GetInstance<DockPanelService>();
        }
    }
}
