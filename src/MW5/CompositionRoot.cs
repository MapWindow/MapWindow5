using MW5.Controls;
using MW5.Menu;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mvp;
using MW5.UI.Forms;
using MW5.UI.Helpers;
using MW5.Views;
using MW5.Views.Abstract;
using Syncfusion.GridHelperClasses;
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
                .RegisterView<ILegendGroupView, LegendGroupView>()
                .RegisterView<IMeasuringView, MeasuringView>()
                .RegisterView<IAboutView, AboutView>()
                .RegisterView<IWelcomeView, WelcomeView>()
                .RegisterView<IConfigView, ConfigView>()
                .RegisterView<ICreatePyramidsView, CreatePyramidsView>()
                .RegisterView<ISpatialIndexView, SpatialIndexView>()
                .RegisterSingleton<IAppView, AppView>()
                .RegisterInstance<IApplicationContainer>(container)
                .RegisterService<LegendPresenter>()
                .RegisterService<LegendDockPanel>()
                .RegisterService<ContextMenuView>()
                .RegisterService<ContextMenuPresenter>();
            
            Services.CompositionRoot.Compose(container);
            Plugins.CompositionRoot.Compose(container);
            Projections.CompositionRoot.Compose(container);
            UI.CompositionRoot.Compose(container);
            Data.CompositionRoot.Compose(container);
            Tools.CompositionRoot.Compose(container);
            Gdal.CompositionRoot.Compose(container);
            Attributes.CompositionRoot.Compose(container);

            CommandBarHelper.InitMenuColors();

            GridEngineFactory.Factory = new AllowResizingIndividualRows();
        }
    }
}
