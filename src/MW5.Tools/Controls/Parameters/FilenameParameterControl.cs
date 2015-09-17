using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Api.Interfaces;
using MW5.Plugins.Enums;
using MW5.Plugins.Services;
using MW5.Tools.Model.Layers;

namespace MW5.Tools.Controls.Parameters
{
    public partial class FilenameParameterControl : ParameterControlBase, IInputParameterControl
    {
        private readonly IFileDialogService _dialogService;
        private DataSourceType _dataType;

        public FilenameParameterControl(IFileDialogService dialogService)
        {
            if (dialogService == null) throw new ArgumentNullException("dialogService");
            _dialogService = dialogService;
            InitializeComponent();
        }

        public void Initialize(DataSourceType dataType)
        {
            _dataType = dataType;
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
        /// Gets the value.
        /// </summary>
        public override object GetValue()
        {
            return textBoxExt1.Text;
        }

        /// <summary>
        /// Sets the value.
        /// </summary>
        public override void SetValue(object value)
        {
            textBoxExt1.SelectedText = value as string;
            FireValueChanged();
        }

        private void OpenDatasource()
        {
            string filename;
            if (_dialogService.OpenFile(_dataType, out filename))
            {
                textBoxExt1.Text = filename;
                FireValueChanged();
            }
        }

        private void OnOpenClick(object sender, EventArgs e)
        {
            OpenDatasource();
        }
    }
}
