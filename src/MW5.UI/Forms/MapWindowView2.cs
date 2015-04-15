using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mvp;
using Syncfusion.Windows.Forms;

namespace MW5.UI.Forms
{
    public class MapWindowView<TModel> : MapWindowView, IViewInternal<TModel>
    {
        protected TModel _model;

        public void InitInternal(TModel model)
        {
            _model = model;
        }

        public TModel Model
        {
            get { return _model; }
        }
    }
}
