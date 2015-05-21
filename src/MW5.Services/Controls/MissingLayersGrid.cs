using System.Collections.Generic;
using System.Windows.Forms;
using MW5.UI.Controls;
using Syncfusion.Windows.Forms.Grid.Grouping;

namespace MW5.Services.Controls
{
    public class MissingLayersGrid: StronglyTypedGrid<MissingLayer>
    {
        private const string ModelName = "FolderBrowser";

        public MissingLayersGrid()
        {
            Adapter.HotTracking = true;
            Adapter.ReadOnly = true;
            Adapter.AllowCurrentCell = false;

            var model = new OpenFileDialogCellModel(TableControl.Model);
            TableControl.Model.CellModels.Add(ModelName, model);

            TableModel.QueryColWidth += TableModel_QueryColWidth;
        }

        private void TableModel_QueryColWidth(object sender, Syncfusion.Windows.Forms.Grid.GridRowColSizeEventArgs e)
        {
            if (e.Index == TableDescriptor.VisibleColumns.Count)
            {
                e.Size = ClientSize.Width - TableModel.ColWidths.GetTotal(0,
                TableDescriptor.VisibleColumns.Count - 1);
                e.Handled = true;
            }
        }

        public new object DataSource
        {
            get { return base.DataSource; }
            set
            {
                base.DataSource = value;
                UpdateColumnState();
            }
        }

        private void UpdateColumnState()
        {
            Adapter.AdjustColumnWidths();

            var style = Adapter.GetColumnStyle(item => item.Name);
            if (style != null)
            {
                style.Enabled = false;
            }

            var cmn = Adapter.GetColumn(item => item.Filename);
            if (cmn != null)
            {
                style = cmn.Appearance.AnyRecordFieldCell;
                if (style != null)
                {
                    style.CellType = ModelName;
                }
            }
        }
    }
}
