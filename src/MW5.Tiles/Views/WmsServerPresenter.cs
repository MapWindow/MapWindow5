using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Concrete;
using MW5.Plugins.Mvp;
using MW5.Tiles.Views.Abstract;

namespace MW5.Tiles.Views
{
    internal class WmsServerPresenter: BasePresenter<IWmsServerView, WmsServer>
    {
        public WmsServerPresenter(IWmsServerView view)
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
            if (!View.ValidateInput())
            {
                return false;
            }

            View.ApplyChanges();

            return true;
        }
    }
}
