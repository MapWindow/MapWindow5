// -------------------------------------------------------------------------------------------
// <copyright file="JoinTablePresenter.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Linq;
using MW5.Attributes.Views.Abstract;
using MW5.Plugins.Mvp;
using MW5.Plugins.Services;
using MW5.Shared;

namespace MW5.Attributes.Views
{
    public class JoinTablePresenter : BasePresenter<IJoinTableView, JoinViewModel>
    {
        private const string OpenDialogFilter =
            "Dbf tables (*.dbf)|*.dbf|Excel workbooks (*.xls, *.xlsx)|*.xls;*.xlsx|CSV files (*.csv)|*.csv|All|*.csv;*.dbf;*.xls;*.xlsx";

        private readonly IFileDialogService _dialogService;

        private bool _hasMatches;

        public JoinTablePresenter(IJoinTableView view, IFileDialogService dialogService)
            : base(view)
        {
            if (dialogService == null) throw new ArgumentNullException("dialogService");
            _dialogService = dialogService;
            view.TryJoin += view_TryJoin;
            view.OpenClicked += view_OpenClicked;
        }

        public override bool ViewOkClicked()
        {
            return PerformJoin();
        }

        private bool PerformJoin()
        {
            if (!Validate()) return false;

            var fields = View.SelectedFields.Select(f => f.Name);

            if (Model.Join != null)
            {
                if (!Model.Table.StopJoin(Model.Join.JoinIndex))
                {
                    Logger.Current.Warn("Failed to stop join: " + Model.Join.Filename);
                    return false;
                }
            }

            var result = Model.Table.Join(
                Model.External,
                View.FieldTo.Name,
                View.FieldFrom.Name,
                Model.Filename,
                Model.GetOptionsString(),
                fields);
            if (!result)
            {
                MessageService.Current.Warn("Failed to join tables.");
            }

            return result;
        }

        private bool Validate()
        {
            if (!View.SelectedFields.Any())
            {
                MessageService.Current.Info("No fields are selected for the join.");
                return false;
            }

            if (View.FieldTo == null || View.FieldFrom == null)
            {
                MessageService.Current.Info("Key fields aren't selected.");
                return false;
            }

            if (!_hasMatches)
            {
                MessageService.Current.Info("Unable to join. No matching field values were found.");
                return false;
            }

            return true;
        }

        private void view_OpenClicked()
        {
            string filename;
            if (!_dialogService.Open(OpenDialogFilter, out filename, 4))
            {
                return;
            }

            if (Model.OpenDatasource(filename))
            {
                View.SetDatasource();
            }
        }

        private void view_TryJoin()
        {
            if (View.FieldTo == null || View.FieldFrom == null)
            {
                return;
            }

            int rowCount, joinRowCount;

            if (Model.Table.TryJoin(
                Model.External,
                View.FieldTo.Name,
                View.FieldFrom.Name,
                out rowCount,
                out joinRowCount))
            {
                View.SetRowCount(rowCount, joinRowCount);
                _hasMatches = rowCount > 0;
                return;
            }

            View.SetRowCount(0, 0);
            _hasMatches = false;
        }
    }
}