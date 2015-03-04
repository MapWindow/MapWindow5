using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using MW5.Plugins.Concrete;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mef;

namespace MW5.Plugins.ShapeEditor
{
    [PluginExport("MW5.Plugins.ShapeEditor")]
    public class ShapeEditor: BasePlugin
    {
        private IAppContext _context;
        private MapListener _mapListener;

        public ShapeEditor()
        {
            _mapListener = new MapListener(this);
        }

        public override string Author
        {
            get { return "Sergei Leschinski"; }
        }

        public override string Description
        {
            get { return "Provides tools for editing shapefiles and other vector formats."; }
        }

        public override string Name
        {
            get { return "Shape Editor"; }
        }

        public override void Initialize(IAppContext context)
        {
            _context = context;
            MenuHelper.InitMenu(context);
        }
        public override void Terminate()
        {
            //_context.Map.ExtentsChanged -= Map_ExtentsChanged;
        }
    }
}
