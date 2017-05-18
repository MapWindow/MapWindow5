// -------------------------------------------------------------------------------------------
// <copyright file="QueryBuilderPresenter.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MW5.Api.Enums;
using MW5.Attributes.Views.Abstract;
using MW5.Plugins.Concrete;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mvp;
using MW5.Plugins.Services;
using MW5.Shared;
using MW5.UI.Helpers;

namespace MW5.Attributes.Views
{
    public class QueryBuilderPresenter : BasePresenter<IQueryBuilderView, QueryBuilderModel>
    {
        private readonly IAppContext _context;
        private string _lastQuery = string.Empty;

        public QueryBuilderPresenter(IQueryBuilderView view, IAppContext context)
            : base(view)
        {
            if (context == null) throw new ArgumentNullException("context");
            _context = context;

            view.TestClicked += OnTestClicked;
            view.RunClicked += OnRunClicked;
        }

        public override bool ViewOkClicked()
        {
            if (Model.IsQuery && !_lastQuery.EqualsIgnoreCase(View.Expression))
            {
                // run the query on hitting OK button
                // if the query has not been executed yet
                OnRunClicked();
            }

            Model.Expression = View.Expression;
            return true;
        }

        private void OnRunClicked()
        {
            if (!View.ValidateOnTheFly(false))
            {
                return;
            }

            _lastQuery = View.Expression;

            var results = new List<int>();
            if (!Query(results)) return;

            // Open extra form with selection options:
            var list = new List<SelectionOperation>
                           {
                               SelectionOperation.New,
                               SelectionOperation.Add,
                               SelectionOperation.Exclude,
                               SelectionOperation.Invert,
                           };

            var operation = AppConfig.Instance.QueryBuilderSelectionOperation;
            const string msg = "Please choose selection mode:";

            var selectedColor = Model.Layer.FeatureSet.SelectionColor;
            if (OptionListHelper.Select(list, ref operation, msg, ref selectedColor, View as IWin32Window))
            {
                AppConfig.Instance.QueryBuilderSelectionOperation = operation;
                Model.Layer.UpdateSelection(results, operation, selectedColor);
                _context.Map.Redraw();
            }
        }

        private void OnTestClicked()
        {
            if (!View.ValidateOnTheFly(false))
            {
                return;
            }

            var results = new List<int>();
            if (Query(results))
            {
                View.ValidationResults = "Number of features selected: " + results.Count;
            }
        }

        private bool Query(List<int> results)
        {
            results.Clear();

            var table = Model.Layer.FeatureSet.Table;

            string err;

            if (!table.ParseExpression(View.Expression, out err))
            {
                MessageService.Current.Info("Failed to parse expression.");
                return false;
            }

            int[] arr;

            if (table.Query(View.Expression, out arr, out err))
            {
                results.AddRange(arr);
                return true;
            }

            return true;
        }
    }
}