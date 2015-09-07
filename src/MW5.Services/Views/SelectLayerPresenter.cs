using System.Linq;
using MW5.Plugins.Mvp;
using MW5.Plugins.Services;
using MW5.Services.Views.Abstract;

namespace MW5.Services.Views
{
    public class SelectLayerPresenter: BasePresenter<ISelectLayerView, SelectLayerModel>
    {
        public SelectLayerPresenter(ISelectLayerView view)
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
            if (!Model.Layers.Any(l => l.Selected))
            {
                MessageService.Current.Info("No layers are selected.");
                return false;
            }
            
            return true;
        }
    }
}
