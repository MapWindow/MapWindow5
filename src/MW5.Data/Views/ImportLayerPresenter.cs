using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Data.Views.Abstract;
using MW5.Plugins.Mvp;

namespace MW5.Data.Views
{
    public class ImportLayerPresenter : BasePresenter<IImportLayerView>
    {
        public ImportLayerPresenter(IImportLayerView view) : base(view)
        {
        }

        public override bool ViewOkClicked()
        {
            return true;
        }
    }
}
