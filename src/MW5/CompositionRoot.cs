using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Helpers;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mvp;
using MW5.Services;
using MW5.UI;
using MW5.Views;
using MW5.Views.Abstract;

namespace MW5
{
    public static class CompositionRoot
    {
        public static void Compose(IApplicationContainer container)
        {
            container.RegisterSingleton<IMainView, MainView>()
                .RegisterSingleton<IAppContext, AppContext>()
                .RegisterView<ISetProjectionView, SetProjectionView>()
                .RegisterView<IConfigView, ConfigView>()
                .RegisterSingleton<IAppView, AppView>()
                .RegisterInstance<IApplicationContainer>(container);
            
            Services.CompositionRoot.Compose(container);
            Plugins.CompositionRoot.Compose(container);
            Projections.CompositionRoot.Compose(container);
        }
    }
}
