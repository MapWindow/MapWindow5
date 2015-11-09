// -------------------------------------------------------------------------------------------
// <copyright file="TemplatePresenter.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using MW5.Api.Concrete;
using MW5.Api.Helpers;
using MW5.Plugins.Concrete;
using MW5.Plugins.Helpers;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mvp;
using MW5.Plugins.Printing.Helpers;
using MW5.Plugins.Printing.Model;
using MW5.Plugins.Printing.Views.Abstract;
using MW5.Plugins.Services;
using MW5.Shared;

namespace MW5.Plugins.Printing.Views
{
    internal class TemplatePresenter : BasePresenter<ITemplateView, TemplateModel>
    {
        
        private readonly IAppContext _context;

        public TemplatePresenter(ITemplateView view, IAppContext context)
            : base(view)
        {
            _context = context;

            View.LayoutSizeChanged += OnLayoutSizeChanged;

            View.FitToPage += FitToPage;
            View.ViewShown += FitToPage;
        }

        private void OnLayoutSizeChanged()
        {
            Validate();

            View.UpdateView();
        }

        /// <summary>
        /// Called when fit to page is clicked.
        /// </summary>
        private void FitToPage()
        {
            GeoSize geoSize;
            if (_context.Map.GetGeodesicSize(View.MapExtents, out geoSize))
            {
                var size = GetUsablePaperSize();
                if (size == default(SizeF))
                {
                    return;
                }

                size.Width -= PrintingConstants.DefaultMapOffset * 2;
                size.Height -= PrintingConstants.DefaultMapOffset * 2;

                double scale = LayoutScaleHelper.CalcMapScale(geoSize, size, Enums.ScaleType.Smallest);

                View.PopulateScales(Convert.ToInt32(scale));
            }
        }

        /// <summary>
        /// A handler for the IView.OkButton.Click event. 
        /// If the method returns true, View will be closed and presenter.ReturnValue set to true.
        /// If the method return false, no actions are taken, so View.Close, presenter.ReturnValue
        /// should be called / set manually.
        /// </summary>
        public override bool ViewOkClicked()
        {
            if (!Validate())
            {
                string msg = View.IsNewLayout ? "Invalid layout size." : "No template is selected.";
                MessageService.Current.Info(msg);
                return false;
            }

            Model.PaperFormat = View.PaperFormat;
            Model.PaperOrientation = View.Orientation;
            Model.TemplateName = TemplateFilename;
            Model.Extents = View.MapExtents;
            Model.Scale = View.MapScale;

            SaveConfig();

            PrinterManager.InitPaperSize();

            return true;
        }

        private string TemplateFilename
        {
            get
            {
                if (View.IsNewLayout)
                {
                    return string.Empty;
                }

                var template = View.Template;
                return template != null ? template.Filename : string.Empty;
            }
        }

        /// <summary>
        /// Calculates canvas size in pixels.
        /// </summary>
        private bool CalculateCanvasSize(out SizeF size)
        {
            size = default(SizeF);

            var extents = View.MapExtents;

            GeoSize geoSize;
            if (!_context.Map.GetGeodesicSize(extents, out geoSize))
            {
                return false;
            }

            if (!NumericHelper.Equal(View.MapScale, 0.0))
            {
                size = LayoutScaleHelper.CalcMapSize(View.MapScale, geoSize, extents.Width / extents.Height);
            }

            return true;
        }

        private SizeF GetUsablePaperSize()
        {
            var paperSize = PaperSizes.PaperSizeByFormatName(View.PaperFormat, PrinterManager.PrinterSettings);
            if (paperSize != null)
            {
                var margins = AppConfig.Instance.PrintingMargins;
                float width = paperSize.Width - margins.Left - margins.Right;
                float height = paperSize.Height - margins.Top - margins.Bottom;

                bool swap = View.Orientation != Orientation.Vertical;

                return new SizeF(swap ? height : width, swap ? width : height);
            }

            Logger.Current.Warn("Failed to find specified paper format: " + View.PaperFormat);
            return default(SizeF);
        }

        /// <summary>
        /// Calculates the number of pages
        /// </summary>
        private void CalculatePageCount(SizeF size)
        {
            var usableSize = GetUsablePaperSize();
            if (usableSize == default(SizeF))
            {
                Model.PageCountX = -1;
                Model.PageCountY = -1;
                return;
            }

            Model.PageCountX = (int)Math.Ceiling(size.Width / usableSize.Width);
            Model.PageCountY = (int)Math.Ceiling(size.Height / usableSize.Height);
        }

        private void SaveConfig()
        {
            var config = AppConfig.Instance;

            config.PrintingOrientation = View.Orientation;
            config.PrintingPaperFormat = View.PaperFormat;
            config.PrintingTemplate = TemplateFilename;
        }

        /// <summary>
        /// Calculates canvas size and returns true if it's within limits.
        /// </summary>
        private bool Validate()
        {
            if (View.IsNewLayout)
            {
                SizeF size;
                if (!CalculateCanvasSize(out size))
                {
                    return false;
                }

                Model.Valid = size.Width * size.Height / 10000 <= Math.Pow(PrintingConstants.MaxSizeInches, 2.0);

                CalculatePageCount(size);

                return Model.Valid;
            }

            return View.Template != null;
        }
    }
}