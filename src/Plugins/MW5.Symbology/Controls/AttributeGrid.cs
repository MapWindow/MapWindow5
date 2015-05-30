using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Concrete;
using MW5.UI.Controls;

namespace MW5.Plugins.Symbology.Controls
{
    public class AttributeGrid: StronglyTypedGrid<AttributeField>
    {
        public AttributeGrid()
        {
            Adapter.ReadOnly = false;
            Adapter.HotTracking = false;
            Adapter.ShowEditors = false;
        }

        public new object DataSource
        {
            get { return base.DataSource; }
            set
            {
                base.DataSource = value;

                if (value != null)
                {
                    UpdateColumnState();
                }
            }
        }

        public void UpdateColumnState()
        {
            int index = Adapter.GetRelativeColumnIndex(f => f.Name);
            if (index != -1)
            {
                TableDescriptor.Columns.Move(index, 0);
            }

            Adapter.GetColumn(f => f.Name).Width = 100;
            
            Adapter.GetColumnStyle(item => item.Name).Enabled = false;
            Adapter.GetColumnStyle(item => item.Type).Enabled = false;
            Adapter.GetColumnStyle(item => item.Precision).Enabled = false;
            Adapter.GetColumnStyle(item => item.Width).Enabled = false;

            Adapter.GetColumn(item => item.Alias).Width = 80;
        }
    }
}
