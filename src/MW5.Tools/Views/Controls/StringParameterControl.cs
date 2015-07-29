// -------------------------------------------------------------------------------------------
// <copyright file="StringParameterControl.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System.Windows.Forms;

namespace MW5.Tools.Views.Controls
{
    public partial class StringParameterControl : ParameterControlBase, IParameterControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StringParameterControl"/> class.
        /// </summary>
        public StringParameterControl()
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
            return textBoxExt1.Text;
        }

        /// <summary>
        /// Sets the value.
        /// </summary>
        public override void SetValue(object value)
        {
            textBoxExt1.Text = (string)value;
        }
    }
}