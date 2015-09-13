using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MW5.Api.Concrete;
using MW5.Api.Enums;
using MW5.Api.Interfaces;
using MW5.Plugins.Enums;
using MW5.Plugins.Services;
using MW5.Services.Helpers;
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
        private List<InputLayerGridAdapter> _layers = new List<InputLayerGridAdapter>();

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

            if (_dataSourceType == DataSourceType.Raster)
            {
                int height = panel1.Height;
                panel1.Height = 0;
                panel1.Visible = false;
                Height -= height;
            }
        }

        public void SetLayers(IEnumerable<ILayer> layers)
        {
            _layers = layers.Select(l => new InputLayerGridAdapter(l)).ToList();
            
            UpdateDatasource();

            if (comboBoxAdv1.Items.Count > 0)
            {
                comboBoxAdv1.SelectedIndex = 0;
            }
        }

        public event EventHandler<InputLayerEventArgs> SelectedLayerChanged;

        public override object GetValue()
        {
            var layer = SelectedLayer;

            var vector = layer as IVectorInput;
            if (vector != null)
            {
                vector.SelectedOnly = chkSelectedOnly.Checked;
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

        /// <summary>
        /// Gets control to display tooltip for.
        /// </summary>
        public override Control ToolTipControl
        {
            get { return comboBoxAdv1; }
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
                int imageIndex = GetImageIndex(_layers[i].Source);
                comboBoxAdv1.ImageIndexes[i] = imageIndex;
            }
        }

        private int GetImageIndex(IDatasourceInput input)
        {
            return LayerIconHelper.GetIcon(input.Datasource);
        }

        private void PopulateImageList()
        {
            comboBoxAdv1.ShowImageInTextBox = true;
            comboBoxAdv1.ShowImagesInComboListBox = true;
            comboBoxAdv1.ImageList = LayerIconHelper.CreateImageList(); ;
        }

        private void OpenDatasource()
        {
            string filename;
            if (_dialogService.OpenFile(_dataSourceType, out filename))
            {
                var item = new InputLayerGridAdapter(filename);
                _layers.Add(item);

                UpdateDatasource();
                comboBoxAdv1.SelectedItem = item;
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

        public IDatasourceInput SelectedLayer
        {
            get
            {
                var wrapper = comboBoxAdv1.SelectedItem as InputLayerGridAdapter;
                return wrapper != null ? wrapper.Source : null;
            }
        }

        private void OnSelectedLayerChanged(object sender, EventArgs e)
        {
            var layer = SelectedLayer as IVectorInput;
            
            SetNumSelected(layer != null ? layer.Datasource.NumSelected : 0);

            FireSelectedLayerChanged();
        }

        private void FireSelectedLayerChanged()
        {
            var handler = SelectedLayerChanged;
            if (handler != null)
            {
                handler(this, new InputLayerEventArgs(SelectedLayer));
            }
        }

        private void SetNumSelected(int count)
        {
            lblNumSelected.Text = "Number of selected: " + count;
            chkSelectedOnly.Enabled = count > 0;
        }
    }
}
