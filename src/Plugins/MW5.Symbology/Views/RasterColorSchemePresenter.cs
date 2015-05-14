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
        public RasterColorSchemePresenter(IRasterColorSchemeView view) : base(view)
        {
        }

        public override void Initialize()
        {
            
        }

        public override void RunCommand(RasterColorSchemeCommand command)
        {
            switch (command)
            {
                case RasterColorSchemeCommand.AddInterval:
                    MessageService.Current.Info("About to add interval");
                    break;
                case RasterColorSchemeCommand.RemoveInterval:
                    break;
                case RasterColorSchemeCommand.Clear:
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
