using System.Drawing;
using MW5.Api.Concrete;
using MW5.UI.Controls;
using MW5.UI.Helpers;

namespace MW5.Data.Controls
{
    public class DriverMetadataGrid: StronglyTypedGrid<DriverMetadata>
    {
        private readonly string HyperLinkModelName = "HyperLinkModel";

        public DriverMetadataGrid()
        {
            Adapter.ReadOnly = true;
            Adapter.HotTracking = true;
            WrapWithPanel = false;

            TableControlResizingColumns += DriverMetadataGrid_TableControlResizingColumns;

            InitHyperLink();
        }

        private void InitHyperLink()
        {
            var model = new LinkLabelCellModelEx(TableControl.Model);
            TableControl.Model.CellModels.Add(HyperLinkModelName, model);

            var rend = TableControl.CellRenderers[HyperLinkModelName] as LinkLabelCellRendererEx;
            if (rend != null)
            {
                rend.ActiveLinkColor = Color.Blue;
                rend.VisitedLinkColor = Color.Purple;
            }

            QueryCellStyleInfo += DriverMetadataGrid_QueryCellStyleInfo;
        }

        private void DriverMetadataGrid_QueryCellStyleInfo(object sender, Syncfusion.Windows.Forms.Grid.Grouping.GridTableCellStyleInfoEventArgs e)
        {
            int index = Adapter.RowIndexToRecordIndex(e.TableCellIdentity.RowIndex);
            var data = Adapter[index];

            if (data != null && data.Type == Api.Enums.GdalDriverMetadata.HelpTopic)
            {
                var cmnIndex = Adapter.GetColumnIndex(item => item.Value);
                if (cmnIndex == e.TableCellIdentity.ColIndex)
                {
                    e.Style.CellType = HyperLinkModelName;
                    e.Style.Tag = e.Style.Text;
                }
            }
        }

        public new object DataSource
        {
            get { return base.DataSource; }
            set
            {
                base.DataSource = value;
                this.AdjustRowHeights();
            }
        }

        void DriverMetadataGrid_TableControlResizingColumns(object sender, Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlResizingColumnsEventArgs e)
        {
            this.AdjustRowHeights();
        }
    }
}
