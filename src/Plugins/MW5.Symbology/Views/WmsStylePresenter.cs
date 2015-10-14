using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Legend.Abstract;
using MW5.Plugins.Mvp;
using MW5.Plugins.Symbology.Views.Abstract;

namespace MW5.Plugins.Symbology.Views
{
    internal class WmsStylePresenter: BasePresenter<IWmsStyleView, ILegendLayer>
    {
        public WmsStylePresenter(IWmsStyleView view)
            : base(view)
        {
        }

        /// <summary>
        /// A handler for the IView.OkButton.Click event. 
        /// If the method returns true, View will be closed and presenter.ReturnValue set to true.
        /// If the method return false, no actions are taken, so View.Close, presenter.ReturnValue
        /// should be called / set manually.
        /// </summary>
        public override bool ViewOkClicked()
        {
            return true;
        }
    }
}
