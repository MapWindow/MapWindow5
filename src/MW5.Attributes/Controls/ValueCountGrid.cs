using System.Drawing;
using System.Windows.Forms;
using MW5.Attributes.Model;
using MW5.UI.Controls;
using MW5.UI.Helpers;
using Syncfusion.Windows.Forms.Grid;

namespace MW5.Attributes.Controls
{
    public partial class ValueCountGrid : StronglyTypedGrid<ValueCountItem>
    {
        public ValueCountGrid()
        {
            InitializeComponent();

            Init();
        }

        private void Init()
        {
            ShowColumnHeaders = false;
            Adapter.ReadOnly = true;
            Adapter.WrapText = true;
            Adapter.AllowCurrentCell = false;
            Adapter.ShowEditors = false;
        }

        protected override void UpdateColumns()
        {
            Adapter.HideColumns();

            Init();

            Adapter.ShowColumn(f => f.Count);
            Adapter.ShowColumn(f => f.Value);

            const int scrollbarWidth = 40;
            const int typeWidth = 40;

            var cmn = Adapter.GetColumn(f => f.Count);
            cmn.Width = typeWidth;
            cmn.Appearance.AnyCell.Borders.Right = new GridBorder(GridBorderStyle.Solid, Color.LightGray);

            cmn = Adapter.GetColumn(f => f.Value);
            cmn.Width = Width - typeWidth - scrollbarWidth;
        }
    }
}
