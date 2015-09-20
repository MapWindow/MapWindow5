using System.Windows.Forms;
using MW5.Api.Enums;
using MW5.Services.Helpers;
using MW5.Services.Properties;
using MW5.Services.Views;
using MW5.UI.Controls;

namespace MW5.Services.Controls
{
    public partial class SelectLayerGrid : StronglyTypedGrid<SelectLayerGridAdapter>
    {
        public SelectLayerGrid()
        {
            InitializeComponent();

            Adapter.HotTracking = false;
            Adapter.ReadOnly = false;
            Adapter.AllowCurrentCell = false;

            TableControlCellClick += OnTableControlCellClick;
        }

        /// <summary>
        /// Toggles checkbox checked state by clicking on any cell of the row.
        /// </summary>
        private void OnTableControlCellClick(object sender, Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventArgs e)
        {
            int columnIndex = Adapter.GetColumnIndex(m => m.Selected);

            var model = Table.TableModel[e.Inner.RowIndex, columnIndex];
            if (model == null)
            {
                return;
            }

            model.CellValue = !(bool)(model.CellValue);
        }

        protected override void UpdateColumns()
        {
            Adapter.HideColumns();

            Adapter.ShowColumn(f => f.Selected);
            Adapter.ShowColumn(f => f.Name);
            Adapter.ShowColumn(f => f.Description);

            InitImageList();

            UI.Helpers.GroupingGridHelper.AdjustColumnWidths(this);
        }

        private void InitImageList()
        {
            var style = Adapter.GetColumnStyle(r => r.Name);
            style.ImageList = LayerIconHelper.CreateImageList();
            style.ImageIndex = 0;
            Adapter.SetColumnIcon(r => r.Name, item => LayerIconHelper.GetIcon(item.Layer));
        }
    }
}
