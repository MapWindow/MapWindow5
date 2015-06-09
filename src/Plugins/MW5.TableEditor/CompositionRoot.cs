using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Mvp;
using MW5.Plugins.TableEditor.Editor;
using MW5.Plugins.TableEditor.Helpers;
using MW5.Plugins.TableEditor.Views;
using MW5.Plugins.TableEditor.Views.Abstract;
using MW5.Shared;

namespace MW5.Plugins.TableEditor
{
    internal static class CompositionRoot
    {
        public static void Compose(IApplicationContainer container)
        {
            container.RegisterSingleton<TableEditorPresenter>()
                .RegisterService<ITableEditorView, TableEditorView>()
                .RegisterView<IUpdateMeasurementsView, UpdateMeasurementsView>()
                .RegisterView<ICalculateFieldView, CalculateFieldView>()
                .RegisterView<IDeleteFieldsView, DeleteFieldsView>()
                .RegisterView<IAddFieldView, AddFieldView>()
                .RegisterView<IRenameFieldView, RenameFieldView>()
                .RegisterView<IJoinTableView, JoinTableView>()
                .RegisterView<IJoinsView, JoinsView>();

            EnumHelper.RegisterConverter(new AttributeTypeConverter());
            EnumHelper.RegisterConverter(new CalculatorFunctionConverter());
        }
    }
}
