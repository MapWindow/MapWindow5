using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Configuration.Plugins;
using MW5.UI.Controls;
using Syncfusion.Grouping;

namespace MW5.Configuration
{
    internal class PluginGrid: StronglyTypedGrid<PluginInfo>
    {
        public PluginGrid()
        {
            Adapter.HotTracking = true;
            Adapter.ShowSuperTooltips = true;
            Adapter.ReadOnly = false;
            Adapter.AllowCurrentCell = false;
            WrapWithPanel = false;
        }

        protected override void UpdateColumns()
        {
            // do nothing
        }
    }
}
