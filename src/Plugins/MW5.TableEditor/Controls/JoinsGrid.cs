using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Concrete;
using MW5.UI.Controls;

namespace MW5.Plugins.TableEditor.Controls
{
    public class JoinsGrid: StronglyTypedGrid<FieldJoin>
    {
        public JoinsGrid()
        {
            Adapter.ReadOnly = true;
            Adapter.HotTracking = true;
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
            Adapter.GetColumn(j => j.Filename).Width = 230;
        }
    }
}
