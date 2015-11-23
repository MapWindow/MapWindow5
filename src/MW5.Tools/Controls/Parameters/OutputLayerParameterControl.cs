// -------------------------------------------------------------------------------------------
// <copyright file="OutputLayerParameterControl.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.IO;
using System.Windows.Forms;
using MW5.Api.Enums;
using MW5.Api.Interfaces;
using MW5.Plugins.Concrete;
using MW5.Plugins.Services;
using MW5.Shared;
using MW5.Tools.Controls.Parameters.Interfaces;
using MW5.Tools.Helpers;
using MW5.Tools.Model;
using MW5.Tools.Model.Layers;

namespace MW5.Tools.Controls.Parameters
{
    /// <summary>
    /// Represents control for setting the name of output datasource and additional parameters (e.g. add to map, overwrite).
    /// </summary>
    public partial class OutputLayerParameterControl : ParameterControlBase, IOuputputParameterControl
    {
        private readonly IFileDialogService _dialogService;
        private string _extension;
        private string _filename;
        private string _inputFilename;
        private LayerType _layerType;
        private string _templateName;

        /// <summary>
        /// Initializes a new instance of the <see cref="OutputLayerParameterControl"/> class.
        /// </summary>
        public OutputLayerParameterControl(IFileDialogService dialogService)
        {
            if (dialogService == null) throw new ArgumentNullException("dialogService");
            _dialogService = dialogService;

            InitializeComponent();

            InitFlags();

            RefreshControls();
        }

        /// <summary>
        /// Gets or sets the caption.
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
            get { return textBoxExt1; }
        }

        private bool IsInMemoryLayer(IDatasourceInput layer)
        {
            return layer != null && 
                   layer.InputType == Enums.InputType.Layer && 
                   layer.Datasource is IFeatureSet &&
                   (layer.Datasource as IFeatureSet).SourceType == FeatureSourceType.InMemory;
        }

        /// <summary>
        /// Called when datasource is changed.
        /// </summary>
        /// <param name="layer">The layer.</param>
        public void OnDatasourceChanged(IDatasourceInput layer)
        {
            _filename = string.Empty;

            if (IsInMemoryLayer(layer))
            {
                _inputFilename = layer.Name;
            }
            else
            {
                _inputFilename = layer != null ? layer.Filename : string.Empty;
            }

            RefreshName();
        }

        /// <summary>
        /// Called when input filename is changed.
        /// </summary>
        /// <param name="filename"></param>
        public void OnFilenameChanged(string filename)
        {
            _filename = string.Empty;
            _inputFilename = filename;
            RefreshName();
        }

        /// <summary>
        /// Changes output name after new format / extension is selected.
        /// </summary>
        /// <param name="extension"></param>
        public void SetExtension(string extension)
        {
            _extension = extension;
            RefreshName();
        }

        /// <summary>
        /// Gets instance of OutputLayerInfo class with parameters set by user.
        /// </summary>
        public override object GetValue()
        {
            // it's probably the best place to do it without cluttering
            // interface with dedicated calls when form is closed
            SaveFlags();

            return new OutputLayerInfo
                       {
                           AddToMap = chkAddToMap.Checked,
                           MemoryLayer = chkMemoryLayer.Checked,
                           Overwrite = chkOverwrite.Checked,
                           Filename = textBoxExt1.Text
                       };
        }

        /// <summary>
        /// Initializes output control with specified layer type.
        /// </summary>
        public void Initialize(LayerType layerType, bool supportsInMemory = true)
        {
            _layerType = layerType;
            chkMemoryLayer.Enabled = supportsInMemory;

            if (!supportsInMemory)
            {
                chkMemoryLayer.Checked = false;
            }
        }

        /// <summary>
        /// Sets the value.
        /// </summary>
        /// <param name="value">String value holding template is expected.</param>
        public override void SetValue(object value)
        {
            var s = Convert.ToString(value);
            _templateName = s;
            RefreshControls();
        }

        /// <summary>
        /// Initializes the values of output flags from application config.
        /// </summary>
        private void InitFlags()
        {
            chkAddToMap.Checked = AppConfig.Instance.ToolOutputAddToMap;
            chkMemoryLayer.Checked = chkMemoryLayer.Enabled && AppConfig.Instance.ToolOutputInMemory;
            chkOverwrite.Checked = AppConfig.Instance.ToolOutputOverwrite;
        }

        private void MemoryLayerChecked(object sender, EventArgs e)
        {
            RefreshControls();
        }

        private void OnOverwriteCheckedChanged(object sender, EventArgs e)
        {
            FireValueChanged();
        }

        private void OnSaveClick(object sender, EventArgs e)
        {
            string filter = _dialogService.GetLayerFilter(_layerType);
            string filename = textBoxExt1.Text;

            if (_dialogService.SaveFile(filter, ref filename))
            {
                _filename = filename;
                RefreshControls();
            }
        }

        private void RefreshControls()
        {
            if (chkMemoryLayer.Checked)
            {
                chkAddToMap.Checked = true;
            }

            chkAddToMap.Enabled = !chkMemoryLayer.Checked;

            RefreshName();
        }

        /// <summary>
        /// Update the name of output datasource based on template.
        /// </summary>
        private void RefreshName()
        {
            if (!string.IsNullOrWhiteSpace(_filename))
            {
                textBoxExt1.Text = chkMemoryLayer.Checked ? Path.GetFileNameWithoutExtension(_filename) : _filename;
            }
            else
            {
                if (string.IsNullOrWhiteSpace(_templateName) || string.IsNullOrWhiteSpace(_inputFilename))
                {
                    return;
                }

                textBoxExt1.Text = TemplateNameResolver.Resolve(_inputFilename, _templateName, chkMemoryLayer.Checked);
            }

            if (!string.IsNullOrWhiteSpace(_extension))
            {
                textBoxExt1.Text = Path.ChangeExtension(textBoxExt1.Text, _extension);
            }
        }

        /// <summary>
        /// Saves the state of output flags to the application config.
        /// </summary>
        private void SaveFlags()
        {
            AppConfig.Instance.ToolOutputAddToMap = chkAddToMap.Checked;
            AppConfig.Instance.ToolOutputOverwrite = chkOverwrite.Checked;
            AppConfig.Instance.ToolOutputInMemory = chkMemoryLayer.Checked;
        }
    }
}