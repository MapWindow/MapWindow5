// -------------------------------------------------------------------------------------------
// <copyright file="ITableView.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using MW5.Plugins.Mvp;

namespace MW5.Plugins.Printing.Views.Abstract
{
    internal interface ITableView : IView<TableViewModel>
    {
        event Action ApplyClicked;

        void Save();
    }
}