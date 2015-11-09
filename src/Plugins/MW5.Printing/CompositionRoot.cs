// -------------------------------------------------------------------------------------------
// <copyright file="CompositionRoot.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using MW5.Plugins.Mvp;
using MW5.Plugins.Printing.Services;
using MW5.Plugins.Printing.Views;
using MW5.Plugins.Printing.Views.Abstract;
using MW5.Plugins.Printing.Views.Panels;

namespace MW5.Plugins.Printing
{
    internal static class CompositionRoot
    {
        public static void Compose(IApplicationContainer container)
        {
            container.RegisterView<ILayoutView, LayoutView>()
                .RegisterView<IPageSetupView, PageSetupView>()
                .RegisterView<ITemplateView, TemplateView>()
                .RegisterView<ITableView, TableView>()
                .RegisterView<IChooseDpiView, ChooseDpiView>()
                .RegisterView<ICreateTableView, CreateTableView>()
                .RegisterService<PdfExportService>()
                .RegisterService<ElementsDockPanel>()
                .RegisterService<ElementsPresenter>();
        }
    }
}