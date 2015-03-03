using System;
using System.Linq;
using System.Windows.Forms;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mef;

namespace MW5.Plugins.ShapeEditor
{
    [PluginExport("MW5.Plugins.ShapeEditor")]
    public class ShapeEditor: IPlugin
    {
        private IAppContext _context;
        
        public string Author
        {
            get { return "Sergei Leschinski"; }
        }

        public string Description
        {
            get { return "Provides tools for editing shapefiles and other vector formats."; }
        }

        public string Name
        {
            get { return "Shape Editor"; }
        }

        public void Initialize(IAppContext context)
        {
            _context = context;
            MenuHelper.InitMenu(context);
            //context.Map.ExtentsChanged += Map_ExtentsChanged;
        }

        public void Terminate()
        {
            //_context.Map.ExtentsChanged -= Map_ExtentsChanged;
        }

        private void Map_ExtentsChanged(object sender, EventArgs e)
        {
            ///MessageBox.Show("Shape editor extents changed: " + _context.Map.Extents);
        }
    }
}
