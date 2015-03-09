using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Api.Interfaces;
using MW5.Api.Legend;
using MW5.Api.Legend.Abstract;
using MW5.Plugins.Mvp;

namespace MW5.Plugins.Interfaces
{
    public interface IMainForm
    {
        object DockingManager { get; }
        object MenuManager { get;}
        IMap Map { get; }
        IMuteLegend Legend { get; }
        IView View { get; }
    }
}
