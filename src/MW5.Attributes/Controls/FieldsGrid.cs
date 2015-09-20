using MW5.Attributes.Model;
using MW5.UI.Controls;

namespace MW5.Attributes.Controls
{
    public class FieldsGrid: StronglyTypedGrid<FieldWrapper>
    {
        public FieldsGrid()
        {
            Adapter.HotTracking = true;
            Adapter.ReadOnly = false;
            Adapter.AllowCurrentCell = false;
        }

        protected override void UpdateColumns()
        {
            Adapter.HideColumns();

            Adapter.ShowColumn(f => f.Selected);
            Adapter.ShowColumn(f => f.Name);

            UI.Helpers.GroupingGridHelper.AdjustColumnWidths(this);
        }
    }
}
