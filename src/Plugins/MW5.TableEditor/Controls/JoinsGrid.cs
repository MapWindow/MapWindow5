using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Concrete;
using MW5.UI.Controls;
using Syncfusion.Windows.Forms.Grid.Grouping;

namespace MW5.Plugins.TableEditor.Controls
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

        public new object DataSource
        {
            get { return base.DataSource; }
            set
            {
                base.DataSource = value;
                UpdateColumns();
            }
        }

        private void UpdateColumns()
        {
            Adapter.GetColumn(j => j.DisplayName).Width = 150;
            Adapter.GetColumn(j => j.FieldsCsv).Width = 150;

            UI.Helpers.GroupingGridHelper.AdjustColumnWidths(this);
        }
    }
}
