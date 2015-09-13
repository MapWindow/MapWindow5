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
    public partial class BatchFilenameParameterControl : ParameterControlBase
    {
        private readonly BindingList<InputFilenameGridAdapter> _filenames = new BindingList<InputFilenameGridAdapter>();
        private readonly IFileDialogService _dialogService;
        private DataSourceType _dataType;

        public BatchFilenameParameterControl(IFileDialogService dialogService)
        {
            if (dialogService == null) throw new ArgumentNullException("dialogService");
            _dialogService = dialogService;
            InitializeComponent();

            inputFilenameGrid1.DataSource = _filenames;
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
            get { return inputFilenameGrid1; }
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        public override object GetValue()
        {
            return null;
        }

        /// <summary>
        /// Sets the value.
        /// </summary>
        public override void SetValue(object value)
        {
            // do nothing
        }

        private void OpenDatasource()
        {
            string[] filenames;
            if (_dialogService.OpenFiles(_dataType, out filenames))
            {
                foreach (var f in filenames)
                {
                    _filenames.Add(new InputFilenameGridAdapter(f));
                }
            }
        }

        private void OnOpenClick(object sender, EventArgs e)
        {
            OpenDatasource();
        }

        private void OnClickClear(object sender, EventArgs e)
        {
            if (MessageService.Current.Ask("Remove all layers"))
            {
                _filenames.Clear();
            }
        }

        public IEnumerable<string> Filenames
        {
            get { return _filenames.Select(f => f.Filename); }
        }
    }
}
