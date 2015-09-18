// -------------------------------------------------------------------------------------------
// <copyright file="BatchFilenameParameterControl.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using MW5.Plugins.Enums;
using MW5.Plugins.Services;
using MW5.Tools.Controls.Parameters.Interfaces;

namespace MW5.Tools.Controls.Parameters
{
    /// <summary>
    /// Represents listbox type control for multiple filename selection.
    /// </summary>
    public partial class BatchFilenameParameterControl : ParameterControlBase, IInputParameterControl
    {
        private readonly IFileDialogService _dialogService;
        private readonly BindingList<InputFilenameGridAdapter> _filenames = new BindingList<InputFilenameGridAdapter>();
        private DataSourceType _dataType;

        /// <summary>
        /// Initializes a new instance of the <see cref="BatchFilenameParameterControl"/> class.
        /// </summary>
        public BatchFilenameParameterControl(IFileDialogService dialogService)
        {
            if (dialogService == null) throw new ArgumentNullException("dialogService");
            _dialogService = dialogService;
            InitializeComponent();

            inputFilenameGrid1.DataSource = _filenames;
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
        /// Gets the filenames.
        /// </summary>
        public IEnumerable<string> Filenames
        {
            get { return _filenames.Select(f => f.Filename); }
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
        /// Initializes the control
        /// </summary>
        public void Initialize(DataSourceType dataType)
        {
            _dataType = dataType;
        }

        /// <summary>
        /// Gets a value indicating whether control allows selection of multiple files (batch mode).
        /// </summary>
        public bool BatchMode
        {
            get { return true; }
        }

        /// <summary>
        /// Sets the value.
        /// </summary>
        public override void SetValue(object value)
        {
            // do nothing
        }

        private void OnClickClear(object sender, EventArgs e)
        {
            if (MessageService.Current.Ask("Remove all layers"))
            {
                _filenames.Clear();
            }
        }

        private void OnOpenClick(object sender, EventArgs e)
        {
            OpenDatasource();
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
    }
}