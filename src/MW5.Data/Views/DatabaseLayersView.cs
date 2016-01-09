using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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
        private BindingList<VectorLayerGridAdapter> _layers = new BindingList<VectorLayerGridAdapter>();
        private SynchronizationContext _syncContext;

        public DatabaseLayersView()
        {
            InitializeComponent();
        }

        public void Initialize()
        {
            Text = @"Database Layers: " + Model.Connection.Name;

            _syncContext = SynchronizationContext.Current;

            StartWait();

            InitGrid();

            LoadLayersAsync();
        }

        private void InitGrid()
        {
            databaseLayersGrid1.DataSource = _layers;

            var style = databaseLayersGrid1.Adapter.GetColumnStyle(r => r.Name);
            style.ImageList = imageList1;
            style.ImageIndex = 0;

            databaseLayersGrid1.Adapter.SetColumnIcon(r => r, GetIcon);
            databaseLayersGrid1.Adapter.HotTracking = true;
        }

        private void LoadLayersAsync()
        {
            Task<bool>.Factory.StartNew(() =>
            {
                if (Model.Datasource.Open(Model.Connection.ConnectionString))
                {

                    LoadLayers();
                    return true;
                }
                else
                {
                    const string msg = "Failed to open database connection.";
                    Logger.Current.Warn(msg + ": " + Model.Datasource.GdalLastErrorMsg);
                    MessageService.Current.Info(msg);
                    return false;
                }

            }).ContinueWith(t =>
                {
                    StopWait();
                    databaseLayersGrid1.Enabled = true;
                }, TaskScheduler.FromCurrentSynchronizationContext());
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
                case GeometryType.None:
                    return 3;
            }

            return -1;
        }

        public override Plugins.Mvp.ViewStyle Style
        {
            get { return new Plugins.Mvp.ViewStyle(true); }
        }

        private void LoadLayers()
        {
            var enumerator = Model.Datasource.GetEnumerator();

            while (enumerator.MoveNext())
            {
                // TODO: right now it will list only the geometry type of the layer
                var layer = new VectorLayerGridAdapter(enumerator.Current);
                _syncContext.Post(o =>
                    {
                        _layers.Add(o as VectorLayerGridAdapter);
                        databaseLayersGrid1.AdjustColumnWidths();
                    }, layer);
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
