// -------------------------------------------------------------------------------------------
// <copyright file="IPageSetupView.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System.Drawing.Printing;
using System.Windows.Forms;
using MW5.Plugins.Mvp;

namespace MW5.Plugins.Printing.Views.Abstract
{
    internal interface IPageSetupView : IView<PrinterSettings>
    {
        double BottomMargin { get; }

        double LeftMargin { get; }

        Orientation Orientation { get; }

        PaperSize PaperSize { get; }

        double RightMargin { get; }

        double TopMargin { get; }
    }
}