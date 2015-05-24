using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Concrete;
using MW5.Plugins.Mvp;
using MW5.Views.Abstract;

namespace MW5.Views
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
