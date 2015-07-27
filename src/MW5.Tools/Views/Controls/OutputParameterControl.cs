using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Plugins.Enums;
using MW5.Plugins.Services;
using MW5.Tools.Model;

namespace MW5.Tools.Views.Controls
{
    public partial class OutputParameterControl : ParameterControlBase, IParameterControl
    {
        private readonly IFileDialogService _dialogService;

        public OutputParameterControl(IFileDialogService dialogService)
        {
            if (dialogService == null) throw new ArgumentNullException("dialogService");
            _dialogService = dialogService;

            InitializeComponent();
        }

        /// <summary>
        /// Gets or sets the caption.
        /// </summary>
        public string Caption
        {
            get { return label1.Text; }
            set { label1.Text = value; }
        }

        /// <summary>
        /// The get table.
        /// </summary>
        public TableLayoutPanel GetTable()
        {
            return tableLayoutPanel1;
        }

        /// <summary>
        /// The get value.
        /// </summary>
        public object GetValue()
        {
            return new OutputLayerInfo()
            {
                AddToMap = chkAddToMap.Checked,
                MemoryLayer = chkMemoryLayer.Checked,
                Overwrite = chkOverwrite.Checked,
                Name = textBoxExt1.Text
            };
        }

        private void OnSaveClick(object sender, EventArgs e)
        {
            string filename = string.Empty;
            if (_dialogService.SaveFile("All files|*.*", ref filename))
            {
                textBoxExt1.Text = filename;
            }
        }
    }
}
