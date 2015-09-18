// -------------------------------------------------------------------------------------------
// <copyright file="BatchOutputParameterControl.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.IO;
using System.Windows.Forms;
using MW5.Api.Enums;
using MW5.Plugins.Concrete;
using MW5.Plugins.Services;
using MW5.Tools.Controls.Parameters.Interfaces;
using MW5.Tools.Model;
using MW5.Tools.Model.Layers;

namespace MW5.Tools.Controls.Parameters
{
    /// <summary>
    /// Represents control to set path and name template for the names of output datasources.
    /// </summary>
    public partial class BatchOutputParameterControl : ParameterControlBase, IOuputputParameterControl
    {
        private readonly IFileDialogService _dialogService;
        private string _extension = string.Empty;
        private LayerType _layerType = LayerType.Invalid;
        private string _template = string.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="BatchOutputParameterControl"/> class.
        /// </summary>
        public BatchOutputParameterControl(IFileDialogService dialogService)
        {
            if (dialogService == null) throw new ArgumentNullException("dialogService");
            _dialogService = dialogService;

            InitializeComponent();

            InitFlags();

            RefreshControls();

            txtPath.Cue = "<same folder as input>";
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
            get { return txtTemplate; }
        }

        public void SetExtension(string extension)
        {
            _extension = extension;
            RefreshTemplate();
        }

        public void OnFilenameChanged(string filename)
        {
            // do nothing
        }

        public void OnDatasourceChanged(IDatasourceInput input)
        {
            // do nothing
        }

        /// <summary>
        /// Gets the control value.
        /// </summary>
        /// <returns>Instance of OutputLayerInfo class.</returns>
        public override object GetValue()
        {
            SaveFlags();

            var info = new OutputLayerInfo
                           {
                               AddToMap = chkAddToMap.Checked,
                               MemoryLayer = chkMemoryLayer.Checked,
                               Overwrite = chkOverwrite.Checked,
                           };

            info.SetTemplate(txtPath.Text, txtTemplate.Text);

            return info;
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
        /// <param name="value">String value is expected.</param>
        public override void SetValue(object value)
        {
            _template = Convert.ToString(value);

            RefreshTemplate();
        }

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
            string filename;
            if (_dialogService.ChooseFolder(Directory.GetCurrentDirectory(), out filename))
            {
                txtPath.Text = filename;
            }
        }

        private void RefreshControls()
        {
            if (chkMemoryLayer.Checked)
            {
                chkAddToMap.Checked = true;
            }

            chkAddToMap.Enabled = !chkMemoryLayer.Checked;
        }

        private void RefreshTemplate()
        {
            string s = _template;

            if (!string.IsNullOrWhiteSpace(_extension))
            {
                s = Path.ChangeExtension(s, _extension);
            }

            txtTemplate.Text = s;
        }

        private void SaveFlags()
        {
            AppConfig.Instance.ToolOutputAddToMap = chkAddToMap.Checked;
            AppConfig.Instance.ToolOutputOverwrite = chkOverwrite.Checked;

            if (chkMemoryLayer.Enabled)
            {
                AppConfig.Instance.ToolOutputInMemory = chkMemoryLayer.Checked;
            }
        }
    }
}