using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Api.Concrete;
using MW5.Api.Enums;
using MW5.Data.Properties;
using MW5.Data.Views.Abstract;
using MW5.Data.Views.Controls;
using MW5.UI.Forms;
using MW5.UI.Helpers;

namespace MW5.Data.Views
{
    public partial class DatabaseLayersView : DatabaseLayersViewBase, IDatabaseLayersView
    {
        private List<VectorLayerInfo> _layers;

        public DatabaseLayersView()
        {
            InitializeComponent();
        }

        public void Initialize()
        {
            var layers = GetLayers().ToList();
            
            databaseLayersGrid1.DataSource = layers;
            _layers = layers;

            var style = databaseLayersGrid1.Adapter.GetColumnStyle(r => r.Name);
            style.ImageList = imageList1;
            style.ImageIndex = 0;
            databaseLayersGrid1.Adapter.SetColumnIcon(r => r, GetIcon);

            databaseLayersGrid1.AdjustColumnWidths();
            databaseLayersGrid1.Adapter.HotTracking = true;
        }

        private int GetIcon(VectorLayerInfo info)
        {
            switch (info.GeometryType)
            {
                case GeometryType.Point:
                case GeometryType.MultiPoint:
                    return 0;
                case GeometryType.Polyline:
                    return 1;
                case GeometryType.Polygon:
                    return 2;
            }

            return -1;
        }

        private IEnumerable<VectorLayerInfo> GetLayers()
        {
            foreach (var layer in Model.Where(l => l.GeometryType != GeometryType.None))
            {
                yield return new VectorLayerInfo(layer);
            }
        }

        public ButtonBase OkButton
        {
            get { return btnOk; }
        }

        public IEnumerable<VectorLayerInfo> Layers
        {
            get { return _layers; }
        }
    }

    public class DatabaseLayersViewBase: MapWindowView<VectorDatasource> {}
}
