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
    public class ExpressionBuilderPresenter : BasePresenter<IExpressionBuilderView, IExpressionBuilderModel>
    {
        private readonly IAppContext _context;
        private string _lastQuery = string.Empty;

        public ExpressionBuilderPresenter(IExpressionBuilderView view, IAppContext context)
            : base(view)
        {
            if (context == null) throw new ArgumentNullException("context");
            _context = context;

            view.TestClicked += OnTestClicked;
        }

        public override bool ViewOkClicked()
        {
            Model.Expression = View.Expression;
            return true;
        }

        private void OnTestClicked()
        {
            if (!View.ValidateOnTheFly(false))
            {
                return;
            }

            if (Test(out object result))
            {
                View.ValidationResults = "Example value: " + result.ToString();
            }
        }

        private bool Test(out object result)
        {
            var table = Model.Layer.FeatureSet.Table;

            string err;

            result = null;

            if (!table.ParseExpression(View.Expression, out err))
            {
                MessageService.Current.Info("Failed to parse expression.");
                return false;
            }


            if (!table.TestExpression(View.Expression, Model.OutputType, out err))
            {
                MessageService.Current.Info("Expression does not return correct type.");
                return false;
            }

            return table.Calculate(View.Expression, 0, out result, out err);
        }
    }
}