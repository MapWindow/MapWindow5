using System;
using MW5.Plugins.Concrete;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mef;
using MW5.Plugins.TemplatePlugin.Menu;

namespace MW5.Plugins.TemplatePlugin
{
    [PluginExport("Template plugin", "Author", "BAE94101-5DBE-43E5-9D55-BC2532A2168C")]
    public class TemplatePlugin: BasePlugin
    {
        private IAppContext _context;
        private MenuGenerator _menuGenerator;
        private MenuListener _menuListener;
        private MapListener _mapListener;

        public override string Description
        {
            get { return "Plugin description"; }
        }

        public override void Initialize(IAppContext context)
        {
            _context = context;
        
            CompositionRoot.Compose(context.Container);
            _menuGenerator = context.Container.GetInstance<MenuGenerator>();
            _menuListener = context.Container.GetInstance<MenuListener>();
            _mapListener = context.Container.GetInstance<MapListener>();
        }

        public override void Terminate()
        {
            // menus & toolbars will be cleared automatically
        }
    }
}
