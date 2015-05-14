using System;
using MW5.Api.Concrete;
using MW5.Api.Interfaces;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mvp;

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
                        if (_context.Container.Run<RasterColorSchemePresenter, RasterColorScheme>(scheme))
                        {
                            // TODO: update grid
                        }
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException("command");
            }
        }
    }
}
