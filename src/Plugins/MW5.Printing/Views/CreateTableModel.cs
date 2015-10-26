// -------------------------------------------------------------------------------------------
// <copyright file="CreateTableModel.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

namespace MW5.Plugins.Printing.Views
{
    internal class CreateTableModel
    {
        public CreateTableModel()
        {
            ColumnCount = 2;
            RowCount = 2;
        }

        public int ColumnCount { get; set; }

        public int RowCount { get; set; }
    }
}