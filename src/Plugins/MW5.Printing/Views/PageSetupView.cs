// -------------------------------------------------------------------------------------------
// <copyright file="PageSetupView.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;
using MW5.Api.Enums;
using MW5.Plugins.Concrete;
using MW5.Plugins.Printing.Enums;
using MW5.Plugins.Printing.Helpers;
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
        }

        /// <summary>
        /// Called before view is shown. Allows to initialize UI from this.Model property.
        /// </summary>
        public void Initialize()
        {
            var ps = Model.DefaultPageSettings;

            var orientation = ps.Landscape ? Orientation.Horizontal : Orientation.Vertical;

            optPortrait.Checked = orientation == Orientation.Vertical;
            optLandscape.Checked = orientation == Orientation.Horizontal;

            InitPaperSizes();

            var size = _sizes.FirstOrDefault(s => s.PaperName == ps.PaperSize.PaperName);
            cboPaperSizes.SelectedItem = size;

           InitializeUnits();
        }

        private void InitializeUnits()
        {
            double left, right, top, bottom;
            ConfigHelper.GetMargins(Model.DefaultPageSettings, out left, out right, out top, out bottom);

            txtMarginLeft.DoubleValue = left;
            txtMarginRight.DoubleValue = right;
            txtMarginTop.DoubleValue = top;
            txtMarginBottom.DoubleValue = bottom;

            string units = ConfigHelper.GetUnitShortString();
            lblBottomUnit.Text = units;
            lblTopUnit.Text = units;
            lblLeftUnit.Text = units;
            lblRightUnit.Text = units;

            var decimals = ConfigHelper.GetDecimalDigitsForUnits();
            txtMarginLeft.NumberDecimalDigits = decimals;
            txtMarginRight.NumberDecimalDigits = decimals;
            txtMarginTop.NumberDecimalDigits = decimals;
            txtMarginBottom.NumberDecimalDigits = decimals;
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
            get { return optLandscape.Checked ? Orientation.Horizontal : Orientation.Vertical; }
        }

        public ButtonBase OkButton
        {
            get { return btnOk; }
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