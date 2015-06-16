using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Concrete;
using MW5.Plugins.TableEditor.Model;
using MW5.Shared;
using MW5.UI.Controls;
using Syncfusion.Windows.Forms.Grid;
using Syncfusion.Windows.Forms.Grid.Grouping;

namespace MW5.Plugins.TableEditor.Controls
{
    public class FieldTypeGrid: StronglyTypedGrid<FieldTypeWrapper>
    {
        public FieldTypeGrid()
        {
            Adapter.HotTracking = false;
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

            Adapter.ShowColumn(f => f.Type);
            Adapter.ShowColumn(f => f.Name);

            const int scrollbarWidth = 40;
            const int typeWidth = 40;

            var cmn = Adapter.GetColumn(f => f.Type);
            cmn.Width = typeWidth;
            cmn.Appearance.AnyCell.Borders.Right = new GridBorder(GridBorderStyle.Solid, Color.LightGray);

            cmn = Adapter.GetColumn(f => f.Name);
            cmn.Width = Width - typeWidth - scrollbarWidth;
        }
    }
}
