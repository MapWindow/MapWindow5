using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Mvp;
using MW5.Plugins.Symbology.Views.Abstract;

namespace MW5.Plugins.Symbology.Views
{
    public class HistogramOptionsPresenter: BasePresenter<IHistogramOptionsView, HistogramOptionsModel>
    {
        public HistogramOptionsPresenter(IHistogramOptionsView view) : base(view)
        {
        }

        public override bool ViewOkClicked()
        {
            return true;
        }
    }
}
