// -------------------------------------------------------------------------------------------
// <copyright file="IntegerParameterControl.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Windows.Forms;

namespace MW5.Tools.Views.Controls
{
    public partial class IntegerParameterControl : ParameterControlBase, IParameterControl
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
            return Convert.ToInt32(integerTextBox1.IntegerValue);
        }
    }
}