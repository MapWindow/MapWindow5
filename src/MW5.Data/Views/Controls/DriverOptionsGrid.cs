using MW5.Api.Concrete;
using MW5.UI.Controls;

namespace MW5.Data.Views.Controls
{
    public class DriverOptionsGrid: StronglyTypedGrid<DriverOption>
    {
        public DriverOptionsGrid()
        {
            Adapter.ReadOnly = true;
            Adapter.HotTracking = true;
            WrapWithPanel = false;

            TableControlResizingColumns += DriverMetadataGrid_TableControlResizingColumns;
        }

        void DriverMetadataGrid_TableControlResizingColumns(object sender, Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlResizingColumnsEventArgs e)
        {
            UI.Helpers.GroupingGridHelper.AdjustRowHeights(this);
        }
    }
}
