// -------------------------------------------------------------------------------------------
// <copyright file="TablePresenter.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using MW5.Plugins.Mvp;
using MW5.Plugins.Printing.Views.Abstract;

namespace MW5.Plugins.Printing.Views
{
    internal class TablePresenter : BasePresenter<ITableView, TableViewModel>
    {
        public TablePresenter(ITableView view)
            : base(view)
        {
            View.ApplyClicked += ViewApplyClicked;
        }

        /// <summary>
        /// A handler for the IView.OkButton.Click event. 
        /// If the method returns true, View will be closed and presenter.ReturnValue set to true.
        /// If the method return false, no actions are taken, so View.Close, presenter.ReturnValue
        /// should be called / set manually.
        /// </summary>
        public override bool ViewOkClicked()
        {
            View.Save();

            return true;
        }

        private void ViewApplyClicked()
        {
            View.Save();
            Model.Table.RefreshElement();
        }
    }
}