using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MW5.Api.Concrete;
using MW5.Api.Enums;
using MW5.Plugins.Enums;
using MW5.Plugins.Services;
using MW5.Tools.Model;
using MW5.Tools.Properties;

namespace MW5.Tools.Controls.Parameters
{
    /// <summary>
    /// Represents combobox with a list of layers and a button to open datasource from disk.
    /// </summary>
    internal partial class LayerParameterControl : ParameterControlBase
    {
        private readonly List<LayerWrapper> _layers = new List<LayerWrapper>();
        private readonly IFileDialogService _dialogService;
        private readonly DataSourceType _dataSourceType;

        internal LayerParameterControl(IEnumerable<LayerWrapper> layers, DataSourceType dataSourceType, IFileDialogService dialogService)
        {
            if (layers == null) throw new ArgumentNullException("layers");
            if (dialogService == null) throw new ArgumentNullException("dialogService");

            _dialogService = dialogService;
            _dataSourceType = dataSourceType;

            InitializeComponent();

            SetNumSelected(0);

            PopulateImageList();

            _layers = layers.ToList();
            UpdateDatasource();

            if (comboBoxAdv1.Items.Count > 0)
            {
                comboBoxAdv1.SelectedIndex = 0;
            }
        }

        public event EventHandler SelectedLayerChanged;

        public override object GetValue()
        {
            var layer = SelectedLayer;
            if (layer != null)
            {
                layer.SelectedOnly = chkSelectedOnly.Checked;
            }

            return layer;
        }

        /// <summary>
        /// Sets the value.
        /// </summary>
        public override void SetValue(object value)
        {
            throw new NotSupportedException("SetValue method isn't supported.");
        }

        public override TableLayoutPanel GetTable()
        {
            return tableLayoutPanel1;
        }

        public override string Caption
        {
            get { return label1.Text; }
            set { label1.Text = value; }
        }

        private void OpenClick(object sender, EventArgs e)
        {
            OpenDatasource();
        }

        private void RefreshImages()
        {
            comboBoxAdv1.ItemsImageIndexes.Clear();

            for (int i = 0; i < _layers.Count(); i++)
            {
                int imageIndex = GetImageIndex(_layers[i]);
                comboBoxAdv1.ImageIndexes[i] = imageIndex;
            }
        }

        private int GetImageIndex(LayerWrapper layer)
        {
            var type = layer.Source.LayerType;
            switch (type)
            {
                case LayerType.Shapefile:
                case LayerType.VectorLayer:
                    var fs = layer.FeatureSet;
                    if (fs != null)
                    {
                        switch (fs.GeometryType)
                        {
                            case GeometryType.Point:
                            case GeometryType.MultiPoint:
                                return 1;
                            case GeometryType.Polyline:
                                return 2;
                            case GeometryType.Polygon:
                                return 3;
                        }
                    }
                    return 0;
                case LayerType.Grid:
                case LayerType.Image:
                    return 4;
            }

            return -1;
        }

        private void PopulateImageList()
        {
            imageList1.Images.Clear();

            imageList1.Images.Add(Resources.img_geometry);
            imageList1.Images.Add(Resources.img_point);
            imageList1.Images.Add(Resources.img_line);
            imageList1.Images.Add(Resources.img_polygon);
            imageList1.Images.Add(Resources.img_raster);

            comboBoxAdv1.ShowImageInTextBox = true;
            comboBoxAdv1.ShowImagesInComboListBox = true;
            comboBoxAdv1.ImageList = imageList1;
        }

        private void OpenDatasource()
        {
            string filename;
            if (_dialogService.OpenFile(_dataSourceType, out filename))
            {
                var identity = new LayerIdentity(filename);
                var wrapper = new LayerWrapper(identity);
                _layers.Add(wrapper);

                UpdateDatasource();
                comboBoxAdv1.SelectedItem = wrapper;
            }
        }

        private void UpdateDatasource()
        {
            // image list doesn't work when binding is on
            //comboBoxAdv1.DataSource = _layers;

            comboBoxAdv1.Items.Clear();

            foreach (var item in _layers)
            {
                comboBoxAdv1.Items.Add(item);
            }

            RefreshImages();
        }

        public LayerWrapper SelectedLayer
        {
            get { return comboBoxAdv1.SelectedItem as LayerWrapper; }
        }

        private void OnSelectedLayerChanged(object sender, EventArgs e)
        {
            var layer = SelectedLayer;
            if (layer != null && layer.FeatureSet != null)
            {
                SetNumSelected(layer.FeatureSet.NumSelected);
            }
            else
            {
                SetNumSelected(0);
            }

            FireSelectedLayerChanged();
        }

        private void FireSelectedLayerChanged()
        {
            var handler = SelectedLayerChanged;
            if (handler != null)
            {
                handler(this, new EventArgs());
            }
        }

        private void SetNumSelected(int count)
        {
            lblNumSelected.Text = "Number of selected: " + count;
            chkSelectedOnly.Enabled = count > 0;
        }
    }
}
