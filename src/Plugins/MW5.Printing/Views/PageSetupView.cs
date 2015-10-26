// -------------------------------------------------------------------------------------------
// <copyright file="PageSetupView.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;
using MW5.Plugins.Printing.Model;
using MW5.Plugins.Printing.Views.Abstract;
using MW5.UI.Forms;
using MW5.UI.Helpers;

namespace MW5.Plugins.Printing.Views
{
    public partial class PageSetupView : PageSetupViewBase, IPageSetupView
    {
        private List<PaperSizeAdapter> _sizes;

        public PageSetupView()
        {
            InitializeComponent();

            InitControls();
        }

        /// <summary>
        /// Called before view is shown. Allows to initialize UI from this.Model property.
        /// </summary>
        public void Initialize()
        {
            var orientation = Model.DefaultPageSettings.Landscape ? Orientation.Horizontal : Orientation.Vertical;
            cboOrientation.SetValue(orientation);

            InitPaperSizes();

            var size = _sizes.FirstOrDefault(s => s.PaperName == Model.DefaultPageSettings.PaperSize.PaperName);
            cboPaperSizes.SelectedItem = size;

            // TODO: add support for American units
            var margins = Model.DefaultPageSettings.Margins;
            txtMarginLeft.DoubleValue = ConvertMargin(margins.Left);
            txtMarginTop.DoubleValue = ConvertMargin(margins.Top);
            txtMarginBottom.DoubleValue = ConvertMargin(margins.Bottom);
            txtMarginRight.DoubleValue = ConvertMargin(margins.Right);
        }

        public PaperSize PaperSize
        {
            get
            {
                var item = cboPaperSizes.SelectedItem as PaperSizeAdapter;
                return item != null ? item.Item : null;
            }
        }

        public double LeftMargin
        {
            get { return txtMarginLeft.DoubleValue; }
        }

        public double RightMargin
        {
            get { return txtMarginRight.DoubleValue; }
        }

        public double TopMargin
        {
            get { return txtMarginTop.DoubleValue; }
        }

        public double BottomMargin
        {
            get { return txtMarginBottom.DoubleValue; }
        }

        public Orientation Orientation
        {
            get { return cboOrientation.GetValue<Orientation>(); }
        }

        public double CentimetersPerInch
        {
            get { return 2.54; }
        }

        public ButtonBase OkButton
        {
            get { return btnOk; }
        }

        private double ConvertMargin(int margin)
        {
            // TODO: implement as a service
            return margin / 100.0 * CentimetersPerInch;
        }

        private void InitControls()
        {
            cboOrientation.AddItemsFromEnum<Orientation>();
        }

        private void InitPaperSizes()
        {
            cboPaperSizes.SuspendLayout();
            cboPaperSizes.Items.Clear();

            _sizes =
                Model.PaperSizes.Cast<PaperSize>()
                    .OrderBy(size => size.PaperName)
                    .Select(item => new PaperSizeAdapter(item))
                    .ToList();

            cboPaperSizes.DataSource = _sizes;

            cboPaperSizes.ResumeLayout();
        }
    }

    public class PageSetupViewBase : MapWindowView<PrinterSettings>
    {
    }
}