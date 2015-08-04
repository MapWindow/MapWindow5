// -------------------------------------------------------------------------------------------
// <copyright file="DoubleParameterControl.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Windows.Forms;

namespace MW5.Tools.Controls.Parameters
{
    public partial class DoubleParameterControl : ParameterControlBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StringParameterControl"/> class.
        /// </summary>
        public DoubleParameterControl()
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
            return doubleTextBox1.DoubleValue;
        }

        /// <summary>
        /// Sets the value.
        /// </summary>
        public override void SetValue(object value)
        {
            doubleTextBox1.DoubleValue = Convert.ToDouble(value);
        }
    }
}