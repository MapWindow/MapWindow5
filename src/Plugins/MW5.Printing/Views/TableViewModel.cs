// -------------------------------------------------------------------------------------------
// <copyright file="TableViewModel.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using MW5.Plugins.Printing.Model.Elements;

namespace MW5.Plugins.Printing.Views
{
    internal class TableViewModel
    {
        public TableViewModel(LayoutTable table, bool adding)
        {
            if (table == null) throw new ArgumentNullException("table");

            Table = table;
            Adding = adding;
        }

        public bool Adding { get; private set; }

        public LayoutTable Table { get; private set; }
    }
}