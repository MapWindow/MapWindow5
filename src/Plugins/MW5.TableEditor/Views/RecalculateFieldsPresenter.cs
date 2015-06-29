using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Concrete;
using MW5.Api.Interfaces;
using MW5.Plugins.Mvp;
using MW5.Plugins.Services;
using MW5.Plugins.TableEditor.Model;
using MW5.Plugins.TableEditor.Views.Abstract;
using MW5.Shared;

namespace MW5.Plugins.TableEditor.Views
{
    internal class RecalculateFieldsPresenter: BasePresenter<IRecalculateFieldsView, IAttributeTable>
    {
        public RecalculateFieldsPresenter(IRecalculateFieldsView view)
            : base(view)
        {
        }

        public override bool ViewOkClicked()
        {
            var fields = View.Fields.ToList();

            if (fields.Count == 0)
            {
                MessageService.Current.Info("No fields are selected for calculation.");
                return false;
            }

            CalculateFields();

            return false;
        }

        private void CalculateFields()
        {
            var fields = View.Fields.ToList();

            foreach (var f in fields)
            {
                f.ClearResult();
            }

            foreach (var f in fields)
            {
                CalculateField(f);
                View.UpdateField(f);
            }
        }

        private void CalculateField(RecalculateFieldWrapper field)
        {
            var eval = new ExpressionEvaluator();

            if (!eval.ParseForTable(field.Expression, Model))
            {
                field.SetResult(RecalculateFieldResult.Failure, "Failed to parse.");
                return;
            }

            var count = 0;
            var rowCount = Model.NumRows;
            bool errorReported = false;

            for (var i = 0; i < rowCount; i++)
            {
                if (!eval.CalculateForTableRow(i, field.Index))
                {
                    if (!errorReported)
                    {
                        // report only the very first error
                        string s = "Failed to calculate expression for a row: " + i + ". " + eval.LastErrorMessage;
                        Logger.Current.Info(s);
                        errorReported = true;
                    }
                    continue;
                }

                count++;
            }

            if (count == rowCount)
            {
                field.SetResult(RecalculateFieldResult.Success, "Success");
            }
            else
            {
                field.SetResult(RecalculateFieldResult.SomeRows, string.Format("{0} from {1}", count, rowCount));
            }
        }
    }
}
