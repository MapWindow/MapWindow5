using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using MW5.Plugins.Concrete;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mef;
using MW5.Plugins.ShapeEditor.Menu;
using MW5.Services.Services.Abstract;

namespace MW5.Plugins.ShapeEditor
{
    [PluginExport("Shape Editor", "Sergei Leschinski", "274DCFA4-61FA-49E4-906D-E0D2E46E247B")]
    public class ShapeEditor: BasePlugin
    {
        private IAppContext _context;
        private MapListener _mapListener;
        private ShapeEditorMenu _menu;

        public ShapeEditor()
        {
            _mapListener = new MapListener(this);
        }

        public override string Description
        {
            get { return "Provides tools for editing shapefiles and other vector formats."; }
        }

        public override void Initialize(IAppContext context)
        {
            _context = context;

            bool injection = false;
            if (injection)
            {
                context.Container.RegisterInstance(typeof (ShapeEditor), this);     // perhaps do it silently before calling initialize
                _menu = context.Container.GetSingleton<ShapeEditorMenu>();
            }
            else
            {
                // I guess it's notorious service locator pattern; but strangely I like this one better;
                // Of course if ShapeEditorMenu will be a dependency of some other service, the injeciton
                // would work better, but will it be the case
                _menu = new ShapeEditorMenu(context, this, context.Container.Resolve<ILayerService>());       
            }
        }

        public override void Terminate()
        {
            //_context.Map.ExtentsChanged -= Map_ExtentsChanged;
        }
    }
}
