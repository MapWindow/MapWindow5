using MW5.Api.Concrete;
using MW5.Data.Views.Abstract;
using MW5.Plugins.Mvp;

namespace MW5.Data.Views
{
    public class DriversPresenter: BasePresenter<IDriversView, DriverManager>
    {
        public DriversPresenter(IDriversView view) : base(view)
        {
            
        }

        public override bool ViewOkClicked()
        {
            return true;
        }
    }
}
