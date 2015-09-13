using System;
using System.IO;
using System.Windows.Forms;
using MW5.Api.Enums;
using MW5.Plugins.Concrete;
using MW5.Plugins.Services;
using MW5.Tools.Helpers;
using MW5.Tools.Model;
using MW5.Tools.Model.Layers;

namespace MW5.Tools.Controls.Parameters
{
    public partial class OutputParameterControl : ParameterControlBase, IOuputputParameterControl
    {
        private readonly IFileDialogService _dialogService;
        private LayerType _layerType;
        private string _templateName;
        private string _inputFilename;
        private string _filename;
        private string _extension;

        public OutputParameterControl(IFileDialogService dialogService)
        {
            if (dialogService == null) throw new ArgumentNullException("dialogService");
            _dialogService = dialogService;
            
            InitializeComponent();

            InitFlags();

            RefreshControls();
        }

        private void InitFlags()
        {
            chkAddToMap.Checked = AppConfig.Instance.ToolOutputAddToMap;
            chkMemoryLayer.Checked = chkMemoryLayer.Enabled && AppConfig.Instance.ToolOutputInMemory;
            chkOverwrite.Checked = AppConfig.Instance.ToolOutputOverwrite;
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

        public void Initialize(LayerType layerType, bool supportsInMemory = true)
        {
            _layerType = layerType;
            chkMemoryLayer.Enabled = supportsInMemory;
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
        /// The get table.
        /// </summary>
        public override TableLayoutPanel GetTable()
        {
            return tableLayoutPanel1;
        }

        /// <summary>
        /// Gets control to display tooltip for.
        /// </summary>
        public override Control ToolTipControl
        {
            get { return textBoxExt1; }
        }

        /// <summary>
        /// The get value.
        /// </summary>
        public override object GetValue()
        {
            // it's probably the best place to do it without cluttering
            // interface with dedicated calls when form is closed
            SaveFlags();

            return new OutputLayerInfo() { AddToMap = chkAddToMap.Checked,
                                           MemoryLayer = chkMemoryLayer.Checked,
                                           Overwrite = chkOverwrite.Checked,
                                           Filename = textBoxExt1.Text };
        }

        /// <summary>
        /// Sets the value.
        /// </summary>
        public override void SetValue(object value)
        {
            var s = Convert.ToString(value);
            _templateName = s;
            RefreshControls();
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

                if (chkMemoryLayer.Checked)
                {
                    string input = Path.GetFileNameWithoutExtension(_inputFilename);
                    string name = _templateName.Replace(TemplateVariables.Input, input);    
                    textBoxExt1.Text = Path.GetFileNameWithoutExtension(name);
                }
                else
                {
                    string input = Shared.PathHelper.GetFullPathWithoutExtension(_inputFilename);
                    string name = _templateName.Replace(TemplateVariables.Input, input);
                    textBoxExt1.Text = name;
                }
            }

            if (!string.IsNullOrWhiteSpace(_extension))
            {
                textBoxExt1.Text = Path.ChangeExtension(textBoxExt1.Text, _extension);
            }
        }

        private void MemoryLayerChecked(object sender, EventArgs e)
        {
            RefreshControls();
        }

        public void OnLayerChanged(IDatasourceInput layer)
        {
            _filename = string.Empty;
            _inputFilename = layer != null ? layer.Filename : string.Empty;
            RefreshName();
        }

        public void OnFilenameChanged(string filename)
        {
            _filename = string.Empty;
            _inputFilename = filename;
            RefreshName();
        }

        public void SetExtension(string extension)
        {
            _extension = extension;
            RefreshName();
        }
    }
}
