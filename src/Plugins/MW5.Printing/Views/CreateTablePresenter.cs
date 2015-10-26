// -------------------------------------------------------------------------------------------
// <copyright file="CreateTablePresenter.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using MW5.Plugins.Mvp;
using MW5.Plugins.Printing.Views.Abstract;

namespace MW5.Plugins.Printing.Views
{
    internal class CreateTablePresenter : BasePresenter<ICreateTableView, CreateTableModel>
    {
        public CreateTablePresenter(ICreateTableView view)
            : base(view)
        {
        }

        /// <summary>
        /// A handler for the IView.OkButton.Click event. 
        /// If the method returns true, View will be closed and presenter.ReturnValue set to true.
        /// If the method return false, no actions are taken, so View.Close, presenter.ReturnValue
        /// should be called / set manually.
        /// </summary>
        public override bool ViewOkClicked()
        {
            Model.RowCount = View.RowCount;
            Model.ColumnCount = View.ColumnCount;

            return true;
        }
    }
}