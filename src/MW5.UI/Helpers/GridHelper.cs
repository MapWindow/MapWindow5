using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syncfusion.Windows.Forms.Grid;
using Syncfusion.Windows.Forms.Grid.Grouping;

namespace MW5.UI.Helpers
{
    public static class GridHelper
    {
        public static void AdjustColumnWidths(this GridGroupingControl grid)
        {
            grid.TableModel.ColWidths.ResizeToFit(GridRangeInfo.Table());
        }

        public static void AdjustRowHeights(this GridGroupingControl grid)
        {
            grid.TableModel.RowHeights.ResizeToFit(GridRangeInfo.Table());
        }
    }
}
