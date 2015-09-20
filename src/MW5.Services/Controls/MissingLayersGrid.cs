using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using MW5.Api.Enums;
using MW5.Services.Properties;
using MW5.UI.Controls;
using MW5.UI.Helpers;
using Syncfusion.Windows.Forms.Grid.Grouping;

namespace MW5.Services.Controls
{
    public class MissingLayersGrid: StronglyTypedGrid<MissingLayer>
    {
        private const string ModelName = "FolderBrowser";
        private readonly ImageList _layerImageList = new ImageList();

        public MissingLayersGrid()
        {
            Adapter.HotTracking = true;
            Adapter.ReadOnly = true;
            Adapter.AllowCurrentCell = false;

            InitLayerImageList();
            Adapter.SetColumnIcon(r => r.LayerType, GetLayerIcon);

            var model = new OpenFileDialogCellModel(TableControl.Model);
            TableControl.Model.CellModels.Add(ModelName, model);

            TableModel.QueryColWidth += TableModel_QueryColWidth;
        }

        private void InitLayerImageList()
        {
            _layerImageList.Images.Clear();
            _layerImageList.ColorDepth = ColorDepth.Depth32Bit;
            _layerImageList.ImageSize = new System.Drawing.Size(16, 16);
            _layerImageList.Images.Add(Resources.img_geometry);
            _layerImageList.Images.Add(Resources.img_raster);
        }

        private int GetLayerIcon(MissingLayer layer)
        {
            switch (layer.LayerType)
            {
                case LayerType.Shapefile:
                case LayerType.VectorLayer:
                    return 0;
                case LayerType.Image:
                case LayerType.Grid:
                    return 1;
            }

            return -1;
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

        protected override void UpdateColumns()
        {
            UpdateColumnVisibility();

            UpdateColumnState();
        }

        private void UpdateColumnVisibility()
        {
            Adapter.HideColumns();

            Adapter.ShowColumn(item => item.Found);
            Adapter.ShowColumn(item => item.Name);
            Adapter.ShowColumn(item => item.Filename);
        }

        private void UpdateColumnState()
        {
            this.AdjustColumnWidths();

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

            style = Adapter.GetColumnStyle(r => r.Name);
            style.ImageList = _layerImageList;
            style.ImageIndex = 0;
        }
    }
}
