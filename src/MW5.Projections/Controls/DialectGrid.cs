using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Projections.BL;
using MW5.UI.Controls;
using MW5.UI.Helpers;

namespace MW5.Projections.Controls
{
    internal class DialectGrid: StronglyTypedGrid<ProjectionDialect>
    {
        public DialectGrid()
        {
            Adapter.ReadOnly = true;
            Adapter.HotTracking = false;
            Adapter.AutoAdjustRowHeights = true;
        }

        protected override void UpdateColumns()
        {
            Adapter.HideColumns();

            Adapter.ShowColumn(d => d.Format);

            Adapter.ShowColumn(d => d.Definition);
        }
    }
}
