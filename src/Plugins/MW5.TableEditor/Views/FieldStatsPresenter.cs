using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Mvp;
using MW5.Plugins.TableEditor.Views.Abstract;

namespace MW5.Plugins.TableEditor.Views
{
    internal class FieldStatsPresenter: BasePresenter<IFieldStatsView, FieldStatsModel>
    {
        public FieldStatsPresenter(IFieldStatsView view)
            : base(view)
        {
        }

        public override bool ViewOkClicked()
        {
            return true;
        }
    }
}
