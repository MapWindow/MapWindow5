using System;
using System.Windows.Forms;
using MW5.Api.Enums;
using MW5.Plugins.Services;
using MW5.Tools.Model;

namespace MW5.Tools.Controls.Parameters
{
    public partial class OutputParameterControl : ParameterControlBase
    {
        private readonly IFileDialogService _dialogService;
        private readonly LayerType _layerType;
        private readonly OutputLayerInfo _output = new OutputLayerInfo();
        private string _defaultValue;

        public OutputParameterControl(IFileDialogService dialogService, LayerType layerType)
        {
            if (dialogService == null) throw new ArgumentNullException("dialogService");
            _dialogService = dialogService;
            _layerType = layerType;

            InitializeComponent();

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
        /// The get table.
        /// </summary>
        public override TableLayoutPanel GetTable()
        {
            return tableLayoutPanel1;
        }

        /// <summary>
        /// The get value.
        /// </summary>
        public override object GetValue()
        {
            // OutputLayerInfo.Result property is set after tool execution, 
            // so we very much want to use the same instance of it rather then generate 
            // a new one on the fly
            _output.AddToMap = chkAddToMap.Checked;
            _output.MemoryLayer = chkMemoryLayer.Checked;
            _output.Overwrite = chkOverwrite.Checked;
            _output.Name = textBoxExt1.Text;
            return _output;
        }

        /// <summary>
        /// Sets the value.
        /// </summary>
        public override void SetValue(object value)
        {
            var s = Convert.ToString(value);
            _defaultValue = s;
            RefreshControls();
        }

        private void OnSaveClick(object sender, EventArgs e)
        {
            string filename = _defaultValue;

            string filter = _dialogService.GetLayerFilter(_layerType);

            if (_dialogService.SaveFile(filter, ref filename))
            {
                textBoxExt1.Text = filename;
            }
        }

        private void RefreshControls()
        {
            if (chkMemoryLayer.Checked)
            {
                chkAddToMap.Checked = true;
            }

            chkAddToMap.Enabled = !chkMemoryLayer.Checked;

            textBoxExt1.Text = chkMemoryLayer.Checked ? _defaultValue : string.Empty;
        }

        private void MemoryLayerChecked(object sender, EventArgs e)
        {
            RefreshControls();
        }
    }
}
