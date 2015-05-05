using System;
using System.Windows.Forms;
using MW5.Api.Enums;
using MW5.Api.Interfaces;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mvp;
using MW5.Plugins.Services;
using MW5.Views;

namespace MW5.Menu
{
    public class ContextMenuPresenter : CommandDispatcher<ContextMenuView, ContextMenuCommand>
    {
        private readonly IAppContext _context;

        public ContextMenuPresenter(IAppContext context, ContextMenuView view)
            :base(view)
        {
            if (context == null) throw new ArgumentNullException("context");
            _context = context;
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
                    measuring.Options.LengthUnits = LengthDisplay.Metric;
                    return true;
                case ContextMenuCommand.American:
                    measuring.Options.LengthUnits = LengthDisplay.American;
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
                    _context.Container.Run<MeasuringPresenter, IMeasuringSettings>(measuring.Options);
                    return true;
            }

            return false;
        }
    }
}
