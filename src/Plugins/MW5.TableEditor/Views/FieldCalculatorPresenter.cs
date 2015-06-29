// -------------------------------------------------------------------------------------------
// <copyright file="FieldCalculatorPresenter.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Diagnostics;
using MW5.Api.Concrete;
using MW5.Plugins.Mvp;
using MW5.Plugins.Services;
using MW5.Plugins.TableEditor.Views.Abstract;
using MW5.Shared;

namespace MW5.Plugins.TableEditor.Views
{
    /// <summary>
    /// Validates and calculates expression for a given field.
    /// </summary>
    public class FieldCalculatorPresenter : BasePresenter<IFieldCalculatorView, FieldCalculatorModel>
    {
        public FieldCalculatorPresenter(IFieldCalculatorView view)
            : base(view)
        {
            view.TestClicked += OnTestClicked;
        }

        public override bool ViewOkClicked()
        {
            return Validate() && CalculateField();
        }

        /// <summary>
        /// Calculates expression and saves results in to the table.
        /// </summary>
        private bool CalculateField()
        {
            var eval = ParseExpression();

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

            // TODO: normalize it
            Model.Field.Expression = View.Expression;   

            if (count != rowCount)
            {
                MessageService.Current.Info(string.Format("Rows calculated: {0} from {1}", count, rowCount));
                return false;
            }

            return true;
        }

        /// <summary>
        /// Parses expression and calculates if for the first row.
        /// </summary>
        private bool Validate()
        {
            var eval = ParseExpression();
            if (eval == null)
            {
                return false;
            }

            object result;
            if (!eval.CalculateForTableRow2(0, out result))
            {
                return MessageService.Current.Ask(
                        "Failed to calculate expression for the first row: " + eval.LastErrorMessage
                        + "Try to calculate for other rows all the same?");
            }

            return true;
        }

        /// <summary>
        /// Calculates expression for first 5 rows of the table and displays results in message box.
        /// </summary>
        private void OnTestClicked()
        {
            var eval = ParseExpression();
            if (eval == null)
            {
                return;
            }

            var results = new List<string>();

            for (int i = 0; i < 5; i++)
            {
                object result;
                if (!eval.CalculateForTableRow2(i, out result))
                {
                    results.Add("<failed to calculate>");
                }
                else
                {
                    string s= string.Format("record {0}: ", i) + result;
                    results.Add( s);
                }
            }

            string msg = "Calculation results: " + Environment.NewLine + Environment.NewLine;
            msg += StringHelper.Join(results, Environment.NewLine + Environment.NewLine);

            MessageService.Current.Info(msg);
        }

        /// <summary>
        /// Parses the expression and returns evaluator instances if it succeeds.
        /// </summary>
        private ExpressionEvaluator ParseExpression()
        {
            var expr = View.Expression;
            if (string.IsNullOrWhiteSpace(expr))
            {
                MessageService.Current.Info("Expression is empty.");
                return null;
            }

            var eval = new ExpressionEvaluator();

            if (!eval.ParseForTable(expr, Model.Table))
            {
                MessageService.Current.Info("Failed to parse expression: " + eval.LastErrorMessage);
                return null;
            }

            return eval;
        }
    }
}