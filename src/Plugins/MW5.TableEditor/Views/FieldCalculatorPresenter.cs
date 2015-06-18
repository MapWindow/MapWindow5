// -------------------------------------------------------------------------------------------
// <copyright file="FieldCalculatorPresenter.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System.Diagnostics;
using MW5.Api.Concrete;
using MW5.Plugins.Mvp;
using MW5.Plugins.Services;
using MW5.Plugins.TableEditor.Views.Abstract;
using MW5.Shared;

namespace MW5.Plugins.TableEditor.Views
{
    public class FieldCalculatorPresenter : BasePresenter<IFieldCalculatorView, FieldCalculatorModel>
    {
        public FieldCalculatorPresenter(IFieldCalculatorView view)
            : base(view) {}

        public override bool ViewOkClicked()
        {
            if (!Validate())
            {
                return false;
            }

            return CalculateField();
        }

        private bool CalculateField()
        {
            var eval = new ExpressionEvaluator();
            eval.ParseForTable(View.Expression, Model.Table);

            var count = 0;
            var rowCount = Model.Table.NumRows;

            for (var i = 0; i < rowCount; i++)
            {
                if (!eval.CalculateForTableRow(i, Model.Field.Index))
                {
                    // TODO: perhaps stop calculation after certain number of failures
                    // TODO: dedicated dialog with the per row errors may be added
                    Logger.Current.Info("Failed to calculate expression for a row: " + i + ". " + eval.LastErrorMessage);
                    continue;
                }
                
                count++;
            }

            if (count != rowCount)
            {
                MessageService.Current.Info(string.Format("Rows calculated: {0} from {1}", count, rowCount));
                return false;
            }

            MessageService.Current.Info("Expression is calculated successfully.");
            return true;
        }

        private bool Validate()
        {
            var expr = View.Expression;
            if (string.IsNullOrWhiteSpace(expr))
            {
                MessageService.Current.Info("Expression is empty.");
                return false;
            }

            var eval = new ExpressionEvaluator();

            if (!eval.ParseForTable(expr, Model.Table))
            {
                MessageService.Current.Info("Failed to parse expression: " + eval.LastErrorMessage);
                return false;
            }

            object result;
            if (!eval.CalculateForTableRow2(0, out result))
            {
                return
                    MessageService.Current.Ask(
                        "Failed to calculate expression for the first row: " + eval.LastErrorMessage
                        + "Try to calculate for other rows all the same?");
            }

            return true;
        }
    }
}