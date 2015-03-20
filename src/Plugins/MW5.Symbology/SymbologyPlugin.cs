using System;
using MW5.Plugins.Concrete;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mef;
using MW5.Plugins.Symbology.Menu;

namespace MW5.Plugins.Symbology
{
    [PluginExport()]
    public class SymbologyPlugin : BasePlugin
    {
        private IAppContext _context;
        private LegendListener legendListener;

        public override void Initialize(IAppContext context)
        {
            _context = context;

            legendListener = context.Container.GetInstance<LegendListener>();
        }

        public override void Terminate()
        {
            
        }
    }
}
