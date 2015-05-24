using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Concrete;
using MW5.UI.Controls;

namespace MW5.Controls
{
    public class DriversGrid: StronglyTypedGrid<DatasourceDriver>
    {
        public DriversGrid()
        {
            Adapter.ReadOnly = true;
            Adapter.HotTracking = true;
        }
    }
}
