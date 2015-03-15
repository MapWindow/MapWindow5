using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Abstract;
using MW5.Plugins.Mvp;

namespace MW5.Presenters
{
    internal class ConfigPresenter: BasePresenter<IConfigView>
    {
        public ConfigPresenter(IConfigView view) : base(view)
        {
        }
    }
}
