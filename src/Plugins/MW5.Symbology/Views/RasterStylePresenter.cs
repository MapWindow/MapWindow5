using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Interfaces;
using MW5.Plugins.Mvp;
using MW5.Plugins.Services;
using MW5.Plugins.Symbology.Views.Abstract;

namespace MW5.Plugins.Symbology.Views
{
    public class RasterStylePresenter: ComplexPresenter<IRasterStyleView, RasterStyleCommand, ILayer>
    {
        public RasterStylePresenter(IRasterStyleView view) : base(view)
        {
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
                default:
                    throw new ArgumentOutOfRangeException("command");
            }
        }

        public override bool ViewOkClicked()
        {
            return true;
        }

        public override void Initialize()
        {

        }
    }
}
