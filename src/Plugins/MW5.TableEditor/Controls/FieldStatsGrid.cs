using MW5.Plugins.TableEditor.Model;
using MW5.UI.Controls;

namespace MW5.Plugins.TableEditor.Controls
{
    internal partial class FieldStatsGrid : StronglyTypedGrid<FieldStat>
    {
        public FieldStatsGrid()
        {
            InitializeComponent();

            Adapter.HotTracking = false;
            Adapter.ReadOnly = true;
            Adapter.AllowCurrentCell = false;
        }

        protected override void UpdateColumns()
        {
            // do nothing
        }
    }
}
