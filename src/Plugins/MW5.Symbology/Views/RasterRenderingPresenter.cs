using System;
using MW5.Api.Concrete;
using MW5.Api.Enums;
using MW5.Api.Interfaces;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mvp;
using MW5.Plugins.Services;
using Syncfusion.Windows.Forms.Tools;

namespace MW5.Plugins.Symbology.Views
{
    public class RasterRenderingPresenter :
        SubViewPresenter<RasterRenderingSubView, RasterRenderingCommand, IRasterSource>
    {
        private readonly IAppContext _context;

        public RasterRenderingPresenter(IAppContext context, RasterRenderingSubView subView)
            : base(subView)
        {
            if (context == null) throw new ArgumentNullException("context");
            _context = context;
        }

        public override void RunCommand(RasterRenderingCommand command)
        {
            switch (command)
            {
                case RasterRenderingCommand.CalculateMinMax:
                    {
                        var band = Model.Bands[View.ActiveBandIndex];
                        var model = new RasterMinMaxModel(band);
                        if (_context.Container.Run<RasterMinMaxPresenter, RasterMinMaxModel>(model))
                        {
                            View.BandMinValue = model.Min;
                            View.BandMaxValue = model.Max;
                        }
                    }
                    break;
                case RasterRenderingCommand.DefaultMinMax:
                    {
                        var band = Model.Bands[View.ActiveBandIndex];
                        View.BandMinValue = band.Minimum;
                        View.BandMaxValue = band.Maximum;
                    }
                    break;
                case RasterRenderingCommand.EditColorScheme:
                    {
                        var scheme = View.ColorScheme;
                        var presenter = _context.Container.GetInstance<RasterColorSchemePresenter>();
                        if (presenter.Run(scheme))
                        {
                            View.ColorScheme = presenter.ColorScheme;
                        }
                    }
                    break;
                case RasterRenderingCommand.GenerateColorScheme:
                    {
                        var scheme = new RasterColorScheme();
                        scheme.SetPredefined(View.BandMinValue, View.BandMaxValue, (PredefinedColors)View.SelectedPredefinedColorScheme);
                        View.ColorScheme = scheme;
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException("command");
            }
        }

        public bool ValidateUserInput()
        {
            switch (View.Rendering)
            {
                case RasterRendering.Unknown:
                    break;
                case RasterRendering.SingleBand:
                    break;
                case RasterRendering.Rgb:
                    if (!View.HasRgbMapping)
                    {
                        MessageService.Current.Info("No RGB mapping is specified. Please select at least one of R, G, B bands.");
                        return false;
                    }
                    break;
                case RasterRendering.ColorScheme:
                    if (View.ColorScheme == null || View.ColorScheme.NumBreaks == 0)
                    {
                        MessageService.Current.Info("No color scheme is specified. Use Generate button to do it.");
                        return false;
                    }
                    break;
                case RasterRendering.BuiltInColorTable:
                    break;
            }

            return true;
        }
    }
}
