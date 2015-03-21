using System;
using MW5.Plugins.Concrete;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mef;
using MW5.Plugins.Services;
using MW5.Plugins.Symbology.Controls.ImageCombo;
using MW5.Plugins.Symbology.Helpers;
using MW5.Plugins.Symbology.Menu;
using MW5.Plugins.Symbology.Services;
using MW5.UI.Helpers;

namespace MW5.Plugins.Symbology
{
    [PluginExport()]
    public class SymbologyPlugin : BasePlugin
    {
        private static IAppContext _context;
        private LegendListener _legendListener;
        private MenuService _menuService;

        static SymbologyPlugin()
        {
            EnumHelper.RegisterConverter(new SymbologyTypeCoverter());

            ColorSchemeProvider.Load();
        }

        internal static IMessageService Msg
        {
            get { return _context.Container.GetSingleton<IMessageService>(); }
        }

        public override void Initialize(IAppContext context)
        {
            _context = context;

            _legendListener = context.Container.GetInstance<LegendListener>();
            _menuService = context.Container.GetInstance<MenuService>();
        }

        public override void Terminate()
        {
            
        }
    }
}
