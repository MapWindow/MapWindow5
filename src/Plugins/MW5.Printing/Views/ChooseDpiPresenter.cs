using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Mvp;
using MW5.Plugins.Printing.Views.Abstract;
using MW5.Plugins.Services;

namespace MW5.Plugins.Printing.Views
{
    internal class ChooseDpiPresenter: BasePresenter<IChooseDpiView, ChooseDpiModel>
    {
        public ChooseDpiPresenter(IChooseDpiView view)
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
            if (Model.Dpi == 0 || Model.Dpi > 600)
            {
                MessageService.Current.Info("Invalid DPI value.");
                return false;
            }

            View.SaveLastDpi();
            return true;
        }
    }
}
