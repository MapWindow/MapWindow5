// -------------------------------------------------------------------------------------------
// <copyright file="ICreateTableView.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using MW5.Plugins.Mvp;

namespace MW5.Plugins.Printing.Views.Abstract
{
    internal interface ICreateTableView : IView<CreateTableModel>
    {
        int ColumnCount { get; }

        int RowCount { get; }
    }
}