using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Concrete;
using MW5.Plugins.TableEditor.Model;
using MW5.Shared;
using MW5.UI.Controls;
using Syncfusion.Windows.Forms.Grid.Grouping;

namespace MW5.Plugins.TableEditor.Controls
{
    public class FieldsGrid: StronglyTypedGrid<FieldWrapper>
    {
        public FieldsGrid()
        {
            Adapter.HotTracking = true;
            Adapter.ReadOnly = false;
            Adapter.AllowCurrentCell = false;
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
            Adapter.HideColumns();

            Adapter.ShowColumn(f => f.Selected);
            Adapter.ShowColumn(f => f.Name);

            UI.Helpers.GroupingGridHelper.AdjustColumnWidths(this);
        }
    }
}
