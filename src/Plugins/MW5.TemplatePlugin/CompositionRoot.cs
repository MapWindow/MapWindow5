using MW5.Plugins.Concrete;
using MW5.Plugins.Mvp;
using MW5.Plugins.TemplatePlugin.Menu;

namespace MW5.Plugins.TemplatePlugin
{
    public static class CompositionRoot
    {
        public static void Compose(IApplicationContainer container, BasePlugin plugin)
        {
            container.RegisterInstance(plugin.GetType(), plugin);    // registering for injection
            container.RegisterService<MenuGenerator, MenuGenerator>();
        }
    }
}
