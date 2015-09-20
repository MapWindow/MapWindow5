using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Concrete;
using MW5.UI.Controls;
using Syncfusion.Windows.Forms.Grid;

namespace MW5.Plugins.Symbology.Controls
{
    public class AttributeGrid: StronglyTypedGrid<AttributeField>
    {
        public AttributeGrid()
        {
            Adapter.ReadOnly = false;
            Adapter.HotTracking = false;
            Adapter.ShowEditors = false;
            WrapWithPanel = false;

            ActivateCurrentCellBehavior = GridCellActivateAction.DblClickOnCell;

            TableOptions.AllowSortColumns = false;
        }

        protected override void UpdateColumns()
        {
            Adapter.HideColumns();

            Adapter.ShowColumn(f => f.Visible);
            Adapter.ShowColumn(f => f.Name);
            Adapter.ShowColumn(f => f.Alias);
            Adapter.ShowColumn(f => f.Type);
            Adapter.ShowColumn(f => f.Width);
            Adapter.ShowColumn(f => f.Precision);
            Adapter.ShowColumn(f => f.Joined);

            Adapter.GetColumn(f => f.Name).Width = 100;
            Adapter.GetColumn(f => f.Alias).Width = 80;

            Adapter.GetColumnStyle(item => item.Name).Enabled = false;
            Adapter.GetColumnStyle(item => item.Type).Enabled = false;
            Adapter.GetColumnStyle(item => item.Precision).Enabled = false;
            Adapter.GetColumnStyle(item => item.Width).Enabled = false;
            Adapter.GetColumnStyle(item => item.Joined).Enabled = false;
        }
    }
}
