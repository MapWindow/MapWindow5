using MW5.Plugins.Concrete;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mef;
using MW5.Plugins.TemplatePlugin.Menu;

namespace MW5.Plugins.TemplatePlugin
{
    [PluginExport("Template plugin", "Author", "BAE94101-5DBE-43E5-9D55-BC2532A2168C")]
    public class TemplatePlugin: BasePlugin
    {
        private bool _initialized = false;
        private MenuGenerator _menuGenerator;
        private MenuListener _menuListener;
        private MapListener _mapListener;

        public override string Description
        {
            get { return "Plugin description"; }
        }

        public override void Initialize(IAppContext context)
        {
            if (!_initialized)
            {
                CompositionRoot.Compose(context.Container, this);
                _initialized = true;
            }

            _menuGenerator = context.Container.Resolve<MenuGenerator>();
            _menuListener = context.Container.Resolve<MenuListener>();
            _mapListener = context.Container.Resolve<MapListener>();
        }

        public override void Terminate()
        {
            // menus & toolbars will be cleared automatically
        }
    }
}
