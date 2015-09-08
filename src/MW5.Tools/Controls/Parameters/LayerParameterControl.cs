using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MW5.Api.Concrete;
using MW5.Api.Enums;
using MW5.Api.Interfaces;
using MW5.Plugins.Enums;
using MW5.Plugins.Services;
using MW5.Tools.Model;
using MW5.Tools.Model.Layers;
using MW5.Tools.Model.Parameters;
using MW5.Tools.Properties;
using MW5.Tools.Services;

namespace MW5.Tools.Controls.Parameters
{
    /// <summary>
    /// Represents combobox with a list of layers and a button to open datasource from disk.
    /// </summary>
    internal partial class LayerParameterControl : ParameterControlBase
    {
        private readonly IFileDialogService _dialogService;
        private DataSourceType _dataSourceType;
        private List<InputSource> _layers = new List<InputSource>();

        public LayerParameterControl(IFileDialogService dialogService)
        {
            if (dialogService == null) throw new ArgumentNullException("dialogService");

            _dialogService = dialogService;

            InitializeComponent();

            SetNumSelected(0);

            PopulateImageList();
        }

        public void Initialize(DataSourceType dataSourceType)
        {
            _dataSourceType = dataSourceType;
        }

        public void SetLayers(IEnumerable<ILayer> layers)
        {
            _layers = layers.Select(l => new InputSource(l)).ToList();
            
            UpdateDatasource();

            if (comboBoxAdv1.Items.Count > 0)
            {
                comboBoxAdv1.SelectedIndex = 0;
            }
        }

        public event EventHandler<LayerEventArgs> SelectedLayerChanged;

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

        private int GetImageIndex(InputSource layer)
        {
            var type = layer.Datasource.LayerType;
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
                var wrapper = new InputSource(filename);
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

        public InputSource SelectedLayer
        {
            get { return comboBoxAdv1.SelectedItem as InputSource; }
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
                handler(this, new LayerEventArgs(SelectedLayer));
            }
        }

        private void SetNumSelected(int count)
        {
            lblNumSelected.Text = "Number of selected: " + count;
            chkSelectedOnly.Enabled = count > 0;
        }
    }
}
