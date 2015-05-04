using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Legend;
using MW5.Api.Legend.Abstract;
using MW5.Plugins.Mvp;
using MW5.Plugins.Services;
using MW5.Views.Abstract;

namespace MW5.Views
{
    public class LegendGroupPresenter: BasePresenter<ILegendGroupView, ILegendGroup>
    {
        public LegendGroupPresenter(ILegendGroupView view) : base(view)
        {
        }

        public override bool ViewOkClicked()
        {
            if (string.IsNullOrWhiteSpace(View.GroupName))
            {
                MessageService.Current.Info("Group name can't be empty");
                return false;
            }

            Model.Text = View.GroupName;

            return true;
        }
    }
}
