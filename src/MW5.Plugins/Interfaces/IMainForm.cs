using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Api.Interfaces;
using MW5.Api.Legend;
using MW5.Api.Legend.Abstract;

namespace MW5.Plugins.Interfaces
{
    public interface IMainForm
    {
        object MenuManager { get;}
        IMap Map { get; }
        ILegend Legend { get; }
    }
}
