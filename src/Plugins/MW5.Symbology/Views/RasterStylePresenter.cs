using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Concrete;
using MW5.Api.Enums;
using MW5.Api.Interfaces;
using MW5.Api.Legend;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mvp;
using MW5.Plugins.Services;
using MW5.Plugins.Symbology.Views.Abstract;
using MW5.Projections.UI.Forms;
using MW5.Shared;

namespace MW5.Plugins.Symbology.Views
{
    public class RasterStylePresenter: ComplexPresenter<IRasterStyleView, RasterCommand, ILayer>
    {
        private readonly IAppContext _context;
        private IRasterSource _raster;

        public RasterStylePresenter(IAppContext context, IRasterStyleView view) : base(view)
        {
            if (context == null) throw new ArgumentNullException("context");
            _context = context;
        }

        public override void RunCommand(RasterCommand command)
        {
            switch (command)
            {
                case RasterCommand.DefaultMinMax:
                    {
                        var band = _raster.Bands[View.ColorSchemeControl.ActiveBandIndex];
                        View.ColorSchemeControl.BandMinValue = band.Minimum;
                        View.ColorSchemeControl.BandMaxValue = band.Maximum; 
                        break;
                    }
                case RasterCommand.ProjectionDetails:
                    using (var form = new ProjectionPropertiesForm(Model.Projection))
                    {
                        AppViewFactory.Instance.ShowChildView(form);
                    }
                    break;
                case RasterCommand.CalculateMinMax:
                    {
                        var band = _raster.Bands[View.ColorSchemeControl.ActiveBandIndex];
                        var model = new RasterMinMaxModel(band);
                        if (_context.Container.Run<RasterMinMaxPresenter, RasterMinMaxModel>(model))
                        {
                            View.ColorSchemeControl.BandMinValue = model.Min;
                            View.ColorSchemeControl.BandMaxValue = model.Max;
                        }
                        break;
                    }
                case RasterCommand.ClearColorAdjustments:
                    View.ClearColorAdjustments();
                    break;
                case RasterCommand.Apply:
                    Apply();
                    break;
                default:
                    throw new ArgumentOutOfRangeException("command");
            }
        }

        private bool Apply()
        {
            if (!View.ColorSchemeControl.ValidateUserInput())
            {
                return false;
            }
            
            View.UiToModel();

            var colors = View.ColorSchemeControl;
            _raster.ForceSingleBandRendering = false;
            _raster.UseRgbBandMapping = false;
            _raster.IgnoreColorTable = true;

            switch (colors.Rendering)
            {
                case RasterRendering.SingleBand:
                    _raster.AllowGridRendering = GridRendering.Never;
                    _raster.ForceSingleBandRendering = true;
                    _raster.ActiveBandIndex = colors.ActiveBandIndex;
                    _raster.SetBandMinMax(colors.ActiveBandIndex, colors.BandMinValue, colors.BandMaxValue);
                    break;
                case RasterRendering.Rgb:
                    _raster.AllowGridRendering = GridRendering.Never;
                    _raster.UseRgbBandMapping = true;
                    break;
                case RasterRendering.BuiltInColorTable:
                    _raster.AllowGridRendering = GridRendering.Never;
                    _raster.IgnoreColorTable = false;
                    break;
                case RasterRendering.ColorScheme:
                    _raster.AllowGridRendering = GridRendering.ForceForAllFormats;
                    if (colors.ColorScheme != null && _raster != null)
                    {
                        _raster.ActiveBandIndex = colors.ActiveBandIndex;
                        _raster.CustomColorScheme = colors.ColorScheme;
                    }
                    break;
                default:
                    Logger.Current.Warn("Unexpected RasterRendering enum value: " + colors.Rendering);
                    break;
            }

            _context.Legend.Redraw(LegendRedraw.LegendAndMap);

            return true;
        }

        public override bool ViewOkClicked()
        {
            return Apply();
        }

        public override void Initialize()
        {
            _raster = Model.ImageSource as IRasterSource;
        }
    }
}
