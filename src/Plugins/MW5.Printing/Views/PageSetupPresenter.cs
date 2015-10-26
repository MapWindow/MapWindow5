// -------------------------------------------------------------------------------------------
// <copyright file="PageSetupPresenter.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Drawing.Printing;
using System.Windows.Forms;
using MW5.Plugins.Mvp;
using MW5.Plugins.Printing.Views.Abstract;

namespace MW5.Plugins.Printing.Views
{
    internal class PageSetupPresenter : BasePresenter<IPageSetupView, PrinterSettings>
    {
        public PageSetupPresenter(IPageSetupView view)
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
            var page = Model.DefaultPageSettings;

            page.PaperSize = View.PaperSize;
            page.Margins.Left = ConvertMargin(View.LeftMargin);
            page.Margins.Top = ConvertMargin(View.TopMargin);
            page.Margins.Bottom = ConvertMargin(View.BottomMargin);
            page.Margins.Right = ConvertMargin(View.RightMargin);
            page.Landscape = View.Orientation == Orientation.Horizontal;

            return true;
        }

        private int ConvertMargin(double value)
        {
            return Convert.ToInt32(value * 100.0 / View.CentimetersPerInch + 0.5);
        }
    }
}