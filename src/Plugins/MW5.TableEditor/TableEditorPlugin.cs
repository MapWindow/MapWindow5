using System;
using MW5.Plugins.Concrete;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mef;
using MW5.Plugins.Mvp;
using MW5.Plugins.TableEditor.Menu;

namespace MW5.Plugins.TableEditor
{
    [MapWindowPlugin()]
    public class TableEditorPlugin: BasePlugin
    {
        private IAppContext _context;
        private MenuListener _menuListener;
        private MapListener _mapListener;
        private MenuGenerator _menuGenerator;

        public override void RegisterServices(IApplicationContainer container)
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
        }

        public override void Terminate()
        {
            
        }
    }
}
