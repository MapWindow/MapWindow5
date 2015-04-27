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
                case RasterCommand.ProjectionDetails:
                    using (var form = new Projections.UI.Forms.ProjectionPropertiesForm(Model.Projection))
                    {
                        AppViewFactory.Instance.ShowChildView(form);
                    }
                    break;
                case RasterCommand.CalculateMinMax:
                    if (_context.Container.Run<RasterMinMaxPresenter, IRasterSource>(_raster))
                    {
                        // TODO: set the resulting values
                    }
                    break;
                case RasterCommand.GenerateColorScheme:
                    var scheme = new RasterColorScheme();
                    var colorView = View.Colors;
                    scheme.SetPredefined(colorView.BandMinValue, colorView.BandMaxValue, (PredefinedColors)colorView.SelectedPredefinedColorScheme);
                    colorView.ColorScheme = scheme;
                    break;
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

        private void Apply()
        {
            View.UiToModel();

            var colors = View.Colors;

            switch (colors.Rendering)
            {
                case RasterRendering.SingleBand:
                case RasterRendering.MultiBand:
                case RasterRendering.BuiltInColorTable:
                    _raster.ForceGridRendering = false;
                    break;
                case RasterRendering.PseudoColors:
                    if (colors.ColorScheme != null && _raster != null)
                    {
                        _raster.ForceGridRendering = true;
                        _raster.ActiveBandIndex = colors.ActiveBandIndex;
                        _raster.CustomColorScheme = colors.ColorScheme;
                    }
                    break;
                default:
                    Logger.Current.Warn("Unexpected RasterRendering enum value: " + colors.Rendering);
                    break;
            }

            _context.Legend.Redraw(LegendRedraw.LegendAndMap);
        }

        public override bool ViewOkClicked()
        {
            Apply();
            
            return true;
        }

        public override void Initialize()
        {
            _raster = Model.ImageSource as IRasterSource;
        }
    }
}
