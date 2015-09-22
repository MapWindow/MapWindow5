// -------------------------------------------------------------------------------------------
// <copyright file="FilenameParameterControl.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Windows.Forms;
using MW5.Shared;

namespace MW5.Tools.Controls.Parameters.Input
{
    /// <summary>
    /// Represents parameter control for filename selection.
    /// </summary>
    [TypeDescriptionProvider(typeof(ReplaceControlDescripterProvider<InputParameterControlBase, UserControl>))]
    public partial class FilenameParameterControl : InputParameterControlBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FilenameParameterControl"/> class.
        /// </summary>
        public FilenameParameterControl()
        {
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
        /// Gets a value indicating whether control allows selection of multiple files (batch mode).
        /// </summary>
        public override bool BatchMode 
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