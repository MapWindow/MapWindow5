using System;
using MW5.Plugins.Concrete;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mef;
using MW5.Plugins.Symbology.Helpers;
using MW5.Plugins.Symbology.Menu;

namespace MW5.Plugins.Symbology
{
    [PluginExport()]
    public class SymbologyPlugin : BasePlugin
    {
        private IAppContext _context;
        private LegendListener _legendListener;
        private MenuService _menuService;

        public override void Initialize(IAppContext context)
        {
            _context = context;

            // well, it's not DI way; but let it be as it is for the moment
            Globals.Init(context);  

            _legendListener = context.Container.GetInstance<LegendListener>();
            _menuService = context.Container.GetInstance<MenuService>();
        }

        public override void Terminate()
        {
            
        }
    }
}
