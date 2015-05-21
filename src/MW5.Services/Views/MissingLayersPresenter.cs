using System.Collections.Generic;
using MW5.Plugins.Mvp;
using MW5.Services.Controls;
using MW5.Services.Views.Abstract;

namespace MW5.Services.Views
{
    public class MissingLayersPresenter: BasePresenter<IMissingLayersView, List<MissingLayer>>
    {
        public MissingLayersPresenter(IMissingLayersView view) : base(view)
        {
        }

        public override bool ViewOkClicked()
        {
            return true;
        }
    }
}
