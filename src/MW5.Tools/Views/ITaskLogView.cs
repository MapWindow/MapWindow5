using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mvp;
using MW5.Tools.Model;

namespace MW5.Tools.Views
{
    internal interface ITaskLogView: IView<IGisTask>
    {
        event Action Cancel;
    }
}
