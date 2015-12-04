using System;
using System.Windows.Forms;
using MW5.Api.Enums;
using MW5.Api.Interfaces;
using MW5.Helpers;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mvp;
using MW5.Plugins.Services;
using MW5.Views;

namespace MW5.Menu
{
    public class ContextMenuPresenter : CommandDispatcher<ContextMenuView, ContextMenuCommand>
    {
        private readonly IAppContext _context;
        private readonly IConfigService _configService;

        public ContextMenuPresenter(IAppContext context, ContextMenuView view, IConfigService configService)
            :base(view)
        {
            if (context == null) throw new ArgumentNullException("context");
            if (configService == null) throw new ArgumentNullException("configService");

            _context = context;
            _configService = configService;
        }

        public ContextMenuStrip MeasuringMenu
        {
            get { return View.MeasuringMenu; }
        }

        public ContextMenuStrip ZoomingMenu
        {
            get { return View.ZoomingMenu; }
        }

        public override void RunCommand(ContextMenuCommand command)
        {
            if (HandleMeasuringCommand(command))
            {
                _context.Map.Redraw(RedrawType.SkipDataLayers);
                return;
            }

            if (HandleZoomingCommand(command))
            {
                return;
            }
        }

        private bool HandleZoomingCommand(ContextMenuCommand command)
        {
            switch (command)
            {
                case ContextMenuCommand.ZoomIn:
                    _context.Map.ZoomIn();
                    return true;
                case ContextMenuCommand.ZoomOut:
                    _context.Map.ZoomOut();
                    return true;
                case ContextMenuCommand.ZoomToMaxExtents:
                    _context.Map.ZoomToMaxVisibleExtents();
                    return true;
            }

            return false;
        }

        private bool HandleMeasuringCommand(ContextMenuCommand command)
        {
            var measuring = _context.Map.Measuring;
            
            switch (command)
            {
                case ContextMenuCommand.UndoPoint:
                    measuring.UndoPoint();
                    return true;
                case ContextMenuCommand.ShowBearing:
                    measuring.Options.ShowBearing = !measuring.Options.ShowBearing;
                    return true;
                case ContextMenuCommand.ShowLength:
                    measuring.Options.ShowLength = !measuring.Options.ShowLength;
                    return true;
                case ContextMenuCommand.Metric:
                    _configService.Config.MeasuringAreaUnits = AreaDisplay.Metric;
                    _configService.Config.MeasuringLengthUnits = LengthDisplay.Metric;
                    _context.Map.ApplyConfig(_configService);
                    return true;
                case ContextMenuCommand.American:
                    _configService.Config.MeasuringAreaUnits = AreaDisplay.American;
                    _configService.Config.MeasuringLengthUnits = LengthDisplay.American;
                    _context.Map.ApplyConfig(_configService);
                    return true;
                case ContextMenuCommand.Degrees:
                    measuring.Options.AngleFormat = AngleFormat.Degrees;
                    return true;
                case ContextMenuCommand.Minutes:
                    measuring.Options.AngleFormat = AngleFormat.Minutes;
                    return true;
                case ContextMenuCommand.Seconds:
                    measuring.Options.AngleFormat = AngleFormat.Seconds;
                    return true;
                case ContextMenuCommand.MeasuringProperties:
                    var model = _context.Container.GetInstance<ConfigViewModel>();
                    model.SelectedPage = Plugins.Enums.ConfigPageType.Measuring;
                    model.UseSelectedPage = true;
                    _context.Container.Run<ConfigPresenter, ConfigViewModel>(model);
                    return true;
            }

            return false;
        }
    }
}
