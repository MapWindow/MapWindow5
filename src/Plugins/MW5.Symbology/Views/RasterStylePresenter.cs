using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Interfaces;
using MW5.Plugins.Mvp;
using MW5.Plugins.Services;
using MW5.Plugins.Symbology.Views.Abstract;
using MW5.Shared;

namespace MW5.Plugins.Symbology.Views
{
    public class RasterStylePresenter: ComplexPresenter<IRasterStyleView, RasterStyleCommand, ILayer>
    {
        public RasterStylePresenter(IRasterStyleView view) : base(view)
        {
        }

        public override void RunCommand(RasterStyleCommand command)
        {
            switch (command)
            {
                case RasterStyleCommand.ProjectionDetails:
                    using (var form = new Projections.UI.Forms.ProjectionPropertiesForm(Model.Projection))
                    {
                        AppViewFactory.Instance.ShowChildView(form);
                    }
                    break;
                case RasterStyleCommand.BuildOverviews:
                    MessageService.Current.Info("About to build overviews");
                    break;
                case RasterStyleCommand.ClearOverviews:
                    MessageService.Current.Info("About to clear overviews");
                    break;
                default:
                    throw new ArgumentOutOfRangeException("command");
            }
        }

        public override bool ViewOkClicked()
        {
            return true;
        }

        public override void Initialize()
        {
            TestBands();
        }

        private void TestBands()
        {
            var image = Model.ImageSource as IRasterSource;
            if (image != null)
            {
                var logger = Logger.Current;
                foreach (var band in image.Bands)
                {
                    logger.Info("BAND: ");
                    logger.Info("No data value: " + band.NoDataValue);
                    logger.Info("Minimum: " + band.Minimum);
                    logger.Info("Maximum: " + band.Maximum);
                    logger.Info("Overview count: " + band.OverviewCount);
                    logger.Info("Color interpretation: " + band.ColorInterpretation);
                }
            }
        }

        private void WriteDebugInfo()
        {
            var image = Model.ImageSource as IRasterSource;
            if (image != null)
            {
                Logger.Current.Info("Raster; dx = {0}; dy = {1}; width = {2}; height = {3}; xllcenter = {4}; yllcenter = {5}",
                                    image.BufferDx, image.BufferDy, image.BufferWidth, image.BufferHeight, image.BufferXllCenter, image.BufferYllCenter);
            }
        }
    }
}
