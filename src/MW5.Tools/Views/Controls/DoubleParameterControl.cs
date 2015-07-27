// -------------------------------------------------------------------------------------------
// <copyright file="DoubleParameterControl.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System.Windows.Forms;

namespace MW5.Tools.Views.Controls
{
    public partial class DoubleParameterControl : ParameterControlBase, IParameterControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StringParameterControl"/> class.
        /// </summary>
        public DoubleParameterControl()
        {
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
            return doubleTextBox1.DoubleValue;
        }
    }
}