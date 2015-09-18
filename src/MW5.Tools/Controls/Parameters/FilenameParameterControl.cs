// -------------------------------------------------------------------------------------------
// <copyright file="FilenameParameterControl.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Windows.Forms;
using MW5.Plugins.Enums;
using MW5.Plugins.Services;
using MW5.Tools.Controls.Parameters.Interfaces;

namespace MW5.Tools.Controls.Parameters
{
    /// <summary>
    /// Represents parameter control for filename selection.
    /// </summary>
    public partial class FilenameParameterControl : ParameterControlBase, IInputParameterControl
    {
        private readonly IFileDialogService _dialogService;
        private DataSourceType _dataType;

        /// <summary>
        /// Initializes a new instance of the <see cref="FilenameParameterControl"/> class.
        /// </summary>
        public FilenameParameterControl(IFileDialogService dialogService)
        {
            if (dialogService == null) throw new ArgumentNullException("dialogService");
            _dialogService = dialogService;
            InitializeComponent();
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

        /// <summary>
        /// Gets the value.
        /// </summary>
        public override object GetValue()
        {
            return textBoxExt1.Text;
        }

        /// <summary>
        /// Initializes the control with specified datasource type.
        /// </summary>
        /// <param name="dataType">Type of the data.</param>
        public void Initialize(DataSourceType dataType)
        {
            _dataType = dataType;
        }

        /// <summary>
        /// Gets a value indicating whether control allows selection of multiple files (batch mode).
        /// </summary>
        public bool BatchMode 
        {
            get { return false;} 
        }

        /// <summary>
        /// Sets the value.
        /// </summary>
        public override void SetValue(object value)
        {
            textBoxExt1.SelectedText = value as string;
            FireValueChanged();
        }

        private void OnOpenClick(object sender, EventArgs e)
        {
            string filename;
            if (_dialogService.OpenFile(_dataType, out filename))
            {
                textBoxExt1.Text = filename;
                FireValueChanged();
            }
        }
    }
}