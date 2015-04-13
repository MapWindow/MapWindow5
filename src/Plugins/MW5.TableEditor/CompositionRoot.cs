using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Mvp;
using MW5.Plugins.TableEditor.BO;
using MW5.Plugins.TableEditor.Editor;
using MW5.Plugins.TableEditor.Forms;
using MW5.Plugins.TableEditor.Helpers;
using MW5.Plugins.TableEditor.Legacy;
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
                .RegisterSingleton<RowManager>()
                .RegisterSingleton<AppContextWrapper>()
                .RegisterService<ICalculateFieldView, CalculateFieldView>()
                .RegisterService<ITableEditorView, TableEditorView>()
                .RegisterService<IDeleteFieldsView, DeleteFieldsView>()
                .RegisterService<IAddFieldView, AddFieldView>()
                .RegisterService<IRenameFieldView, RenameFieldView>();

            EnumHelper.RegisterConverter(new AttributeTypeConverter());
            EnumHelper.RegisterConverter(new CalculatorFunctionCoverter());
        }
    }
}
