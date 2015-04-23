using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Controls;
using MW5.Helpers;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mvp;
using MW5.Services;
using MW5.Services.Helpers;
using MW5.Shared;
using MW5.UI;
using MW5.UI.Controls;
using MW5.UI.Forms;
using MW5.UI.Helpers;
using MW5.Views;
using MW5.Views.Abstract;
using Syncfusion.Windows.Forms.Grid.Grouping;

namespace MW5
{
    internal static class CompositionRoot
    {
        public static void Compose(IApplicationContainer container)
        {
            container.RegisterSingleton<IMainView, MainView>()
                .RegisterSingleton<IAppContext, AppContext>()
                .RegisterView<ISetProjectionView, SetProjectionView>()
                .RegisterView<IConfigView, ConfigView>()
                .RegisterSingleton<IAppView, AppView>()
                .RegisterInstance<IApplicationContainer>(container)
                .RegisterService<LegendPresenter>()
                .RegisterService<LegendDockPanel>();
            
            Services.CompositionRoot.Compose(container);
            Plugins.CompositionRoot.Compose(container);
            Projections.CompositionRoot.Compose(container);
            UI.CompositionRoot.Compose(container);
            Data.CompositionRoot.Compose(container);
            Tools.CompositionRoot.Compose(container);

            CommandBarHelper.InitMenuColors();

            GridEngineFactory.Factory = new Syncfusion.GridHelperClasses.AllowResizingIndividualRows();
        }
    }
}
