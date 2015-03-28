using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Mvp;
using MW5.Plugins.TableEditor.BO;
using MW5.Plugins.TableEditor.Editor;
using MW5.Plugins.TableEditor.Forms;
using MW5.Plugins.TableEditor.Legacy;
using MW5.Plugins.TableEditor.Views;
using MW5.Plugins.TableEditor.Views.Abstract;

namespace MW5.Plugins.TableEditor
{
    public static class CompositionRoot
    {
        public static void Compose(IApplicationContainer container)
        {
            container.RegisterSingleton<TableEditorPresenter, TableEditorPresenter>()
                .RegisterSingleton<RowManager, RowManager>()
                .RegisterSingleton<AppContextWrapper, AppContextWrapper>()
                .RegisterService<ICalculateFieldView, CalculateFieldView>()
                .RegisterService<ITableEditorView, TableEditorView>()
                .RegisterService<IDeleteFieldsView, DeleteFieldsView>()
                .RegisterService<IAddFieldView, AddFieldView>()
                .RegisterService<IRenameFieldView, RenameFieldView>();
        }
    }
}
