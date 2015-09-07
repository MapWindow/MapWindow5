using System;
using System.IO;
using System.Windows.Forms;
using MW5.Api.Enums;
using MW5.Plugins.Services;
using MW5.Tools.Model;

namespace MW5.Tools.Controls.Parameters
{
    public partial class BatchOutputParameterControl : ParameterControlBase
    {
        private readonly IFileDialogService _dialogService;
        private LayerType _layerType = LayerType.Invalid;

        public BatchOutputParameterControl(IFileDialogService dialogService)
        {
            if (dialogService == null) throw new ArgumentNullException("dialogService");
            _dialogService = dialogService;

            InitializeComponent();

            RefreshControls();

            txtPath.Cue = "<same folder as input>";
        }

        public void Initialize(LayerType layerType)
        {
            _layerType = layerType;
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
            var info = new OutputLayerInfo()
                       {
                           AddToMap = chkAddToMap.Checked,
                           MemoryLayer = chkMemoryLayer.Checked,
                           Overwrite = chkOverwrite.Checked,
                       };

            info.SetTemplate(txtPath.Text, txtTemplate.Text);            
            
            return info;
        }

        /// <summary>
        /// Sets the value.
        /// </summary>
        public override void SetValue(object value)
        {
            var s = Convert.ToString(value);
            txtTemplate.Text = s;

            RefreshControls();
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

        private void MemoryLayerChecked(object sender, EventArgs e)
        {
            RefreshControls();
        }
    }
}
