using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Concrete;
using MW5.Api.Enums;
using MW5.Api.Interfaces;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mvp;
using MW5.Plugins.Services;
using MW5.Plugins.Symbology.Views.Abstract;
using MW5.Shared;

namespace MW5.Plugins.Symbology.Views
{
    public class RasterStylePresenter: ComplexPresenter<IRasterStyleView, RasterStyleCommand, ILayer>
    {
        private readonly IAppContext _context;
        private IRasterSource _raster;

        public RasterStylePresenter(IAppContext context, IRasterStyleView view) : base(view)
        {
            if (context == null) throw new ArgumentNullException("context");
            _context = context;
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
                case RasterStyleCommand.CalculateMinMax:
                    if (_context.Container.Run<RasterMinMaxPresenter, IRasterSource>(_raster))
                    {
                        // TODO: set the resulting values
                    }
                    break;
                case RasterStyleCommand.GenerateColorScheme:
                    var scheme = new RasterColorScheme();
                    scheme.SetPredefined(View.BandMinValue, View.BandMaxValue, (PredefinedColors)View.SelectedPredefinedColorScheme);
                    View.ColorScheme = scheme;
                    break;
                case RasterStyleCommand.Apply:
                    Apply();
                    break;
                default:
                    throw new ArgumentOutOfRangeException("command");
            }
        }

        private void Apply()
        {
            if (View.ColorScheme != null && _raster != null)
            {
                _raster.ForceGridRendering = true;
                _raster.ActiveBandIndex = View.ActiveBandIndex;
                _raster.CustomColorScheme = View.ColorScheme;
                _context.Map.Redraw();
            }
        }

        public override bool ViewOkClicked()
        {
            View.UiToModel();
            
            return true;
        }

        public override void Initialize()
        {
            _raster = Model.ImageSource as IRasterSource;
        }
    }
}
