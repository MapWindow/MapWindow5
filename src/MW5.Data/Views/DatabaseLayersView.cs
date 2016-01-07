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
using MW5.Data.Model;
using MW5.Data.Properties;
using MW5.Data.Views.Abstract;
using MW5.Plugins.Services;
using MW5.Shared;
using MW5.UI.Forms;
using MW5.UI.Helpers;

namespace MW5.Data.Views
{
    public partial class DatabaseLayersView : DatabaseLayersViewBase, IDatabaseLayersView
    {
        private List<VectorLayerGridAdapter> _layers;

        public DatabaseLayersView()
        {
            InitializeComponent();

            Shown += DatabaseLayersView_Shown;
        }

        void DatabaseLayersView_Shown(object sender, EventArgs e)
        {
            StartWait();

            try
            {
                if (Model.Datasource.Open(Model.Connection.ConnectionString))
                {
                    var layers = GetLayers().ToList();

                    databaseLayersGrid1.DataSource = layers;
                    _layers = layers;
                }
                else
                {
                    const string msg = "Failed to open database connection.";
                    Logger.Current.Warn(msg + ": " + Model.Datasource.GdalLastErrorMsg);
                    MessageService.Current.Info(msg);
                }
            }
            finally
            {
                StopWait();
            }

            var style = databaseLayersGrid1.Adapter.GetColumnStyle(r => r.Name);
            style.ImageList = imageList1;
            style.ImageIndex = 0;
            databaseLayersGrid1.Adapter.SetColumnIcon(r => r, GetIcon);

            databaseLayersGrid1.AdjustColumnWidths();
            databaseLayersGrid1.Adapter.HotTracking = true;
        }

        public void Initialize()
        {
            Text = @"Database Layers: " + Model.Connection.Name;
        }

        private int GetIcon(VectorLayerGridAdapter info)
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

        public override Plugins.Mvp.ViewStyle Style
        {
            get { return new Plugins.Mvp.ViewStyle(true); }
        }

        private IEnumerable<VectorLayerGridAdapter> GetLayers()
        {
            var enumerator = Model.Datasource.GetFastEnumerator();

            while (enumerator.MoveNext())
            {
                // TODO: right now it will list only the geometry type of the layer
                yield return new VectorLayerGridAdapter(enumerator.Current);
            }
        }

        public ButtonBase OkButton
        {
            get { return btnOk; }
        }

        public IEnumerable<VectorLayerGridAdapter> Layers
        {
            get { return _layers; }
        }

        private void OnSelectAllChecked(object sender, EventArgs e)
        {
            databaseLayersGrid1.Adapter.SetPropertyForEach(item => item.Selected, chkSelectAll.Checked);
        }
    }

    public class DatabaseLayersViewBase: MapWindowView<DatabaseLayersModel> {}
}
