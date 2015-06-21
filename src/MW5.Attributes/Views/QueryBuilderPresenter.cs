// -------------------------------------------------------------------------------------------
// <copyright file="QueryBuilderPresenter.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MW5.Api.Enums;
using MW5.Attributes.Views.Abstract;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mvp;
using MW5.Plugins.Services;
using MW5.UI.Helpers;

namespace MW5.Attributes.Views
{
    public class QueryBuilderPresenter : BasePresenter<IQueryBuilderView, QueryBuilderModel>
    {
        private readonly IAppContext _context;

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
            Model.Expression = View.Expression;
            return true;
        }

        private void OnRunClicked()
        {
            if (!View.ValidateOnTheFly(false))
            {
                return;
            }

            var results = new List<int>();
            if (Query(results))
            {
                var list = new List<SelectionOperation>
                               {
                                   SelectionOperation.New,
                                   SelectionOperation.Add,
                                   SelectionOperation.Exclude,
                                   SelectionOperation.Invert,
                               };

                var operation = SelectionOperation.New;
                const string msg = "Please choose selection mode:";

                if (OptionListHelper.Select(list, ref operation, msg, View as IWin32Window))
                {
                    Model.Layer.UpdateSelection(results, operation);
                    _context.Map.Redraw();
                }
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

            object result = null;

            if (table.Query(View.Expression, ref result, ref err))
            {
                var arr = result as int[];
                if (arr != null)
                {
                    results.AddRange(arr);
                    return true;
                }
            }

            return true;
        }
    }
}