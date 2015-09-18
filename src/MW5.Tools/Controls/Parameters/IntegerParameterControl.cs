// -------------------------------------------------------------------------------------------
// <copyright file="IntegerParameterControl.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Windows.Forms;

namespace MW5.Tools.Controls.Parameters
{
    /// <summary>
    /// Represents control for entering value of integer parameter. Doesn't allow empty values.
    /// </summary>
    public partial class IntegerParameterControl : ParameterControlBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StringParameterControl"/> class.
        /// </summary>
        public IntegerParameterControl()
        {
            InitializeComponent();
            buttonAdv1.Visible = false;
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
            get { return integerTextBox1; }
        }

        /// <summary>
        /// The get value.
        /// </summary>
        public override object GetValue()
        {
            return Convert.ToInt32(integerTextBox1.IntegerValue);
        }

        /// <summary>
        /// Sets the value.
        /// </summary>
        public override void SetValue(object value)
        {
            integerTextBox1.IntegerValue = Convert.ToInt32(value);
        }
    }
}