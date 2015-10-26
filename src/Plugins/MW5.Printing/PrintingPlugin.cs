// -------------------------------------------------------------------------------------------
// <copyright file="PrintingPlugin.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using MW5.Plugins.Concrete;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mef;
using MW5.Plugins.Mvp;
using MW5.Plugins.Printing.Menu;

namespace MW5.Plugins.Printing
{
    [MapWindowPlugin]
    public class PrintingPlugin : BasePlugin
    {
        private MenuGenerator _menuGenerator;
        private MenuListener _menuListener;

        public override void Initialize(IAppContext context)
        {
            _menuGenerator = context.Container.GetInstance<MenuGenerator>();
            _menuListener = context.Container.GetInstance<MenuListener>();
        }

        protected override void RegisterServices(IApplicationContainer container)
        {
            CompositionRoot.Compose(container);
        }
    }
}