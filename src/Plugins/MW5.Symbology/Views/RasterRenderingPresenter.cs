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
                        GenerateColorScheme();
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException("command");
            }
        }

        private void GenerateColorScheme()
        {
            RasterColorScheme scheme = null;

            var band = Model.Bands[View.ActiveBandIndex];
            if (band == null)
            {
                return;
            }

            double minValue = View.BandMinValue;
            double maxValue = View.BandMaxValue;

            switch (View.Classification)
            {
                case RasterClassification.EqualIntervals:
                    scheme = band.Classify(minValue, maxValue, Classification.EqualIntervals, View.NumBreaks);
                    break;
                case RasterClassification.EqualCount:
                    scheme = band.Classify(minValue, maxValue, Classification.EqualCount, View.NumBreaks);
                    break;
                case RasterClassification.UniqueValues:
                    scheme = band.Classify(minValue, maxValue, Classification.UniqueValues, 256);
                    if (scheme == null)
                    {
                        MessageService.Current.Info("To many values for unique values classification (256 is max).");
                        return;
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            if (scheme != null)
            {
                bool singleColor = View.Classification == RasterClassification.UniqueValues ||
                                   !View.GradientWithinCategory;

                scheme.ApplyColoringType(singleColor ? GridColoringType.Random : GridColoringType.Hillshade);
                
                var ramp = new ColorRamp();
                ramp.SetColors((PredefinedColors) View.SelectedPredefinedColorScheme);

                var type = View.Classification == RasterClassification.UniqueValues ? SchemeType.Random : SchemeType.Graduated;
                scheme.ApplyColors(type, ramp, View.GradientWithinCategory);

                View.ColorScheme = scheme;
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
