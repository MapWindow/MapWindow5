using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Api.Interfaces;
using MW5.Plugins.Mvp;
using MW5.Plugins.Services;
using MW5.Plugins.Symbology.Views.Abstract;

namespace MW5.Plugins.Symbology.Views
{
    public class RasterMinMaxPresenter: BasePresenter<IRasterMinMaxView, IRasterSource>
    {
        public RasterMinMaxPresenter(IRasterMinMaxView view) : base(view)
        {
            view.CalculateClicked += view_CalculateClicked;
        }

        private void view_CalculateClicked()
        {
            MessageService.Current.Info("About to do calculations.");
        } 

        public override bool ViewOkClicked()
        {
            return true;
        }
    }
}
