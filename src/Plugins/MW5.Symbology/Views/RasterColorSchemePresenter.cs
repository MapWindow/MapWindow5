using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Concrete;
using MW5.Plugins.Mvp;
using MW5.Plugins.Services;
using MW5.Plugins.Symbology.Views.Abstract;

namespace MW5.Plugins.Symbology.Views
{
    public class RasterColorSchemePresenter
        : ComplexPresenter<IRasterColorSchemeView, RasterColorSchemeCommand, RasterColorScheme>
    {
        private readonly IRasterColorSchemeView _view;

        public RasterColorSchemePresenter(IRasterColorSchemeView view) : base(view)
        {
            if (view == null) throw new ArgumentNullException("view");
            _view = view;
        }

        public RasterColorScheme ColorScheme
        {
            get
            {
                var scheme = new RasterColorScheme();

                foreach (var item in View.Intervals)
                {
                    scheme.AddInterval(item);
                }

                return scheme;
            }
        }

        public override void RunCommand(RasterColorSchemeCommand command)
        {
            switch (command)
            {
                case RasterColorSchemeCommand.AddInterval:
                    var interval = new RasterInterval()
                    {
                        LowValue = 0.0,
                        HighValue = 0.0,
                    };
                    _view.Intervals.Add(interval);
                    break;
                case RasterColorSchemeCommand.RemoveInterval:
                    var item = _view.SelectedInterval;
                    if (item != null)
                    {
                        View.Intervals.Remove(item);
                    }
                    break;
                case RasterColorSchemeCommand.Clear:
                    if (MessageService.Current.Ask("Do you want to remove all the intervals?"))
                    {
                        _view.Intervals.Clear();
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException("command");
            }
        }

        public override bool ViewOkClicked()
        {
            return true;
        }
    }
}
