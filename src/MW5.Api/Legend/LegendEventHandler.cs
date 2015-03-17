using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Legend.Abstract;

namespace MW5.Api.Legend
{
    public delegate void LegendEventHandler<TArgs>(IMuteLegend legend, TArgs e)
        where TArgs : EventArgs;
}
