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
                .RegisterView<IFieldCalculatorView, FieldCalculatorView>()
                .RegisterView<IUpdateMeasurementsView, UpdateMeasurementsView>()
                .RegisterView<ICalculateFieldView, CalculateFieldView>()
                .RegisterView<IDeleteFieldsView, DeleteFieldsView>()
                
                .RegisterView<IJoinsView, JoinsView>()
                .RegisterView<IFieldPropertiesView, FieldPropertiesView>()
                .RegisterView<IFieldStatsView, FieldStatsView>()
                .RegisterView<IFindReplaceView, FindReplaceView>();

            EnumHelper.RegisterConverter(new FunctionGroupConverter());
            EnumHelper.RegisterConverter(new MatchTypeConverter());
            EnumHelper.RegisterConverter(new SearchDirectionConverter());
            EnumHelper.RegisterConverter(new AttributeTypeConverter());
            EnumHelper.RegisterConverter(new CalculatorFunctionConverter());
        }
    }
}
