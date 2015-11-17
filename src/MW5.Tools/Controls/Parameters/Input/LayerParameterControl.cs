// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LayerParameterControl.cs" company="MapWindow OSS Team - www.mapwindow.org">
//   MapWindow OSS Team - 2015
// </copyright>
// <summary>
//   Represents combobox with a list of layers and a button to open datasource from disk.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using MW5.Api.Interfaces;
using MW5.Plugins.Enums;
using MW5.Plugins.Services;
using MW5.Services.Helpers;
using MW5.Shared;
using MW5.Tools.Model.Layers;
using MW5.Tools.Services;

namespace MW5.Tools.Controls.Parameters.Input
{
    /// <summary>
    /// Represents combobox with a list of layers and a button to open datasource from disk.
    /// </summary>
    [TypeDescriptionProvider(typeof(ReplaceControlDescripterProvider<InputParameterControlBase, UserControl>))]
    internal partial class LayerParameterControl : InputParameterControlBase
    {
        private List<InputLayerGridAdapter> _layers = new List<InputLayerGridAdapter>();
        private ILayer _currentLayer;

        public LayerParameterControl()
        {
            InitializeComponent();

            SetNumSelected(0);

            PopulateImageList();
        }

        /// <summary>
        /// Occurs when the layer is selected.
        /// </summary>
        public event EventHandler<InputLayerEventArgs> SelectedLayerChanged;

        /// <summary>
        /// Gets a value indicating whether control allows selection of multiple files (batch mode).
        /// </summary>
        public override bool BatchMode
        {
            get { return false; }
        }

        /// <summary>
        /// Gets or sets control caption.
        /// </summary>
        public override string Caption
        {
            get { return label1.Text; }
            set { label1.Text = value; }
        }

        /// <summary>
        /// Gets control to display tooltip for.
        /// </summary>
        public override Control ToolTipControl
        {
            get { return comboBoxAdv1; }
        }

        /// <summary>
        /// Gets the selected layer.
        /// </summary>
        private IDatasourceInput SelectedLayer
        {
            get
            {
                var wrapper = comboBoxAdv1.SelectedItem as InputLayerGridAdapter;
                return wrapper != null ? wrapper.Source : null;
            }
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <returns>
        /// Value type that must match the type of parameter the control was generated for.
        /// </returns>
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
        /// Initializes the control with specified datasource type.
        /// </summary>
        /// <param name="dataType">Type of the data.</param>
        /// <param name="dialogService">File dialog service.</param>
        /// <param name="currentLayer">The current layer</param>
        public override void Initialize(DataSourceType dataType, IFileDialogService dialogService, ILayer currentLayer)
        {
            base.Initialize(dataType, dialogService, currentLayer);

            _currentLayer = currentLayer;

            if (_dataType == DataSourceType.Raster)
            {
                var height = panel1.Height;
                panel1.Height = 0;
                panel1.Visible = false;
                Height -= height;
            }
        }

        /// <summary>
        /// Sets the list of layers.
        /// </summary>
        public void SetLayers(IEnumerable<ILayer> layers)
        {
            // Only add the layers of the correct type:
            _layers = layers.Where(CheckLayerType).Select(l => new InputLayerGridAdapter(l)).ToList();

            UpdateComboBox();

            SetSelectionComboBox();
        }

        private void SetSelectionComboBox()
        {
            if (_currentLayer != null)
            {
                // Make current selected layer the selected option in the combobox
                // It is possible the selected layer is not on the combobox:
                var layer = _layers.FirstOrDefault(l => l.Source.LayerHandle == _currentLayer.Handle);
                if (layer != null)
                {
                    comboBoxAdv1.SelectedItem = layer;
                    return;
                }
            }

            // Default value:
            if (comboBoxAdv1.Items.Count > 0)
            {
                comboBoxAdv1.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// Checks the type of the layer.
        /// </summary>
        /// <param name="layer">The layer.</param>
        /// <returns>True when it is the correct type</returns>
        private bool CheckLayerType(ILayer layer)
        {
            switch (_dataType)
            {
                case DataSourceType.Vector:
                    if (layer.IsVector)
                    {
                        return true;
                    }

                    break;
                case DataSourceType.Raster:
                    if (layer.IsRaster)
                    {
                        return true;
                    }

                    break;
                case DataSourceType.All:
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Sets the value.
        /// </summary>
        /// <param name="value">Value type must match the type of parameter the control was generated for.</param>
        /// <exception cref="System.NotSupportedException">SetValue method isn't supported.</exception>
        public override void SetValue(object value)
        {
            throw new NotSupportedException("SetValue method isn't supported.");
        }

        /// <summary>
        /// Fires the selected layer changed event.
        /// </summary>
        private void FireSelectedLayerChanged()
        {
            var handler = SelectedLayerChanged;
            if (handler != null)
            {
                handler(this, new InputLayerEventArgs(SelectedLayer));
            }
        }

        /// <summary>
        /// Gets icon index for datasource.
        /// </summary>
        private int GetImageIndex(IDatasourceInput input)
        {
            return LayerIconHelper.GetIcon(input.Datasource);
        }

        /// <summary>
        /// Fires events after selected layer was changed.
        /// </summary>
        private void OnSelectedLayerChanged(object sender, EventArgs e)
        {
            var layer = SelectedLayer as IVectorInput;

            SetNumSelected(layer != null && layer.Datasource != null ? layer.Datasource.NumSelected : 0);

            FireSelectedLayerChanged();

            FireValueChanged();
        }

        /// <summary>
        /// Opens the datasource from file dialog.
        /// </summary>
        private void OpenClick(object sender, EventArgs e)
        {
            string filename;
            if (_dialogService.OpenFile(_dataType, out filename))
            {
                var item = new InputLayerGridAdapter(filename);
                _layers.Add(item);

                UpdateComboBox();
                comboBoxAdv1.SelectedItem = item;
            }
        }

        /// <summary>
        /// Populates the image list.
        /// </summary>
        private void PopulateImageList()
        {
            comboBoxAdv1.ShowImageInTextBox = true;
            comboBoxAdv1.ShowImagesInComboListBox = true;
            comboBoxAdv1.ImageList = LayerIconHelper.CreateImageList();
        }

        /// <summary>
        /// Refreshes layer icons.
        /// </summary>
        private void RefreshImages()
        {
            comboBoxAdv1.ItemsImageIndexes.Clear();

            for (int i = 0; i < _layers.Count(); i++)
            {
                int imageIndex = GetImageIndex(_layers[i].Source);
                comboBoxAdv1.ImageIndexes[i] = imageIndex;
            }
        }

        /// <summary>
        /// Sets the number selected features.
        /// </summary>
        private void SetNumSelected(int count)
        {
            lblNumSelected.Text = @"Number of selected: " + count;
            chkSelectedOnly.Enabled = count > 0;
        }

        /// <summary>
        /// Updates combo box after the changes of layer list.
        /// </summary>
        private void UpdateComboBox()
        {
            // image list doesn't work when binding is on
            // comboBoxAdv1.DataSource = _layers;
            comboBoxAdv1.Items.Clear();

            foreach (var item in _layers)
            {
                comboBoxAdv1.Items.Add(item);
            }

            RefreshImages();
        }
    }
}