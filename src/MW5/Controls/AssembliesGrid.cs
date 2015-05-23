using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.UI.Controls;

namespace MW5.Controls
{
    public class AssembliesGrid: StronglyTypedGrid<AssemblyInfo>
    {
        public AssembliesGrid()
        {
            Adapter.ReadOnly = true;
            Adapter.HotTracking = true;
            WrapWithPanel = false;
        }
    }
}
