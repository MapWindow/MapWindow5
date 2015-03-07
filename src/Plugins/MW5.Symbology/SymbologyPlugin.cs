using System;
using MW5.Plugins.Concrete;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mef;
using MW5.Plugins.Symbology.Menu;

namespace MW5.Plugins.Symbology
{
    [PluginExport("Symbology Editor", "Sergei Leschinski", "34E6819B-4772-4B02-9407-12471048D201")]
    public class SymbologyPlugin : BasePlugin
    {
        private IAppContext _context;

        public override string Description
        {
            get { return "GUI to change symbology for vector and raster layers."; }
        }

        public override void Initialize(IAppContext context)
        {
            _context = context;
        }

        public override void Terminate()
        {
            
        }
    }
}
