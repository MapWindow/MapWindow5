using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using MW5.Plugins.Concrete;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mef;
using MW5.Plugins.ShapeEditor.Menu;

namespace MW5.Plugins.ShapeEditor
{
    [PluginExport("Shape Editor", "Sergei Leschinski", "274DCFA4-61FA-49E4-906D-E0D2E46E247B")]
    public class ShapeEditor: BasePlugin
    {
        private bool _initialized = false;
        private IAppContext _context;
        private MapListener _mapListener;
        private MenuGenerator _menuGenerator;
        private MenuListener _menuListener;
        private ProjectListener _projectListener;
        private MenuUpdater _menuUpdater;

        public override string Description
        {
            get { return "Provides tools for editing shapefiles and other vector formats."; }
        }

        public override void Initialize(IAppContext context)
        {
            if (!_initialized)
            {
                CompositionRoot.Compose(context.Container, this);
                _initialized = true;
            }

            _context = context;
            var container = context.Container;
            _mapListener = container.GetSingleton<MapListener>();
            _menuGenerator = container.GetSingleton<MenuGenerator>();
            _menuListener = container.GetSingleton<MenuListener>();
            _projectListener = container.GetSingleton<ProjectListener>();
            _menuUpdater = container.GetSingleton<MenuUpdater>();
        }

        public override void Terminate()
        {

        }
    }
}
