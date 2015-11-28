using MW5.Plugins.Concrete;
using MW5.Plugins.ImageRegistration.Menu;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mef;
using MW5.Plugins.Mvp;
using MW5.Tools.Helpers;

namespace MW5.Plugins.ImageRegistration
{
    [MapWindowPlugin()]
    public class ImageRegistrationPlugin: BasePlugin
    {
        private MenuGenerator _menuGenerator;
        private MenuListener _menuListener;

        public override void Initialize(IAppContext context)
        {
            _menuGenerator = context.Container.GetInstance<MenuGenerator>();
            _menuListener = context.Container.GetInstance<MenuListener>();

            context.Toolbox.AddTools(GetType().Assembly.GetTools());
        }

        protected override void RegisterServices(IApplicationContainer container)
        {
            CompositionRoot.Compose(container);
        }
    }
}
