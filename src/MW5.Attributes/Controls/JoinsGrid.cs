using System;
using MW5.Api.Concrete;
using MW5.UI.Controls;
using Syncfusion.Windows.Forms.Grid.Grouping;

namespace MW5.Attributes.Controls
{
    public class JoinsGrid: StronglyTypedGrid<FieldJoin>
    {
        public event Action JoinDoubleClicked;

        public JoinsGrid()
        {
            Adapter.ReadOnly = true;
            Adapter.HotTracking = true;

            TableControlCellDoubleClick += JoinsGrid_TableControlCellDoubleClick;
        }

        private void JoinsGrid_TableControlCellDoubleClick(object sender, GridTableControlCellClickEventArgs e)
        {
            int recIndex = Adapter.RowIndexToRecordIndex(e.Inner.RowIndex);
            if (recIndex == -1)
            {
                return;
            }

            var join = Adapter[recIndex];
            if (join != null && JoinDoubleClicked != null)
            {
                JoinDoubleClicked();
            }
        }

        protected override void UpdateColumns()
        {
            Adapter.GetColumn(j => j.DisplayName).Width = 150;
            Adapter.GetColumn(j => j.FieldsCsv).Width = 150;

            UI.Helpers.GroupingGridHelper.AdjustColumnWidths(this);
        }
    }
}
