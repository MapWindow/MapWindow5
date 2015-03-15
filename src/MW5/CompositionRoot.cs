using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Abstract;
using MW5.DI.Castle;
//using MW5.DI.LightInject;
//using MW5.DI.Ninject;
//using MW5.DI.Unity;
using MW5.Helpers;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mvp;
using MW5.Presenters;
using MW5.Services;
using MW5.UI;
using MW5.Views;

namespace MW5
{
    public static class CompositionRoot
    {
        public static void Compose(IApplicationContainer container)
        {
            container.RegisterSingleton<IMainView, MainView>()
                .RegisterView<ISetProjectionView, SetProjectionView>()
                .RegisterSingleton<IAppContext, AppContext>()
                .RegisterInstance<IApplicationContainer>(container);
            
            Services.CompositionRoot.Compose(container);
            Plugins.CompositionRoot.Compose(container);
        }
    }
}
