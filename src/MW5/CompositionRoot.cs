using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Helpers;
using MW5.Mvp.DI;
using MW5.Plugins.Interfaces;
using MW5.Presenters;
using MW5.Services;
using MW5.Services.Abstract;
using MW5.Views;

namespace MW5
{
    public static class CompositionRoot
    {
        public static void Compose(IApplicationContainer container)
        {
            container.RegisterView<IMainView, MainView>()
                .RegisterServiceSingleton<IAppContext, AppContext>()
                .RegisterServiceSingleton<ILayerService, LayerService>();
            
            Core.CompositionRoot.Compose(container);
        }
    }
}
