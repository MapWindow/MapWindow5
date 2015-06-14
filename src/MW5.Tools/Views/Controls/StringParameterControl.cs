// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StringParameterControl.cs" company="MapWindow OSS Team - www.mapwindow.org">
//   MapWindow OSS Team - 2015
// </copyright>
// <summary>
//   Defines the StringParameterControl type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MW5.Tools.Views.Controls
{
    using System.Windows.Forms;

    public partial class StringParameterControl : ParameterControlBase, IParameterControl
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="StringParameterControl"/> class.
        /// </summary>
        public StringParameterControl()
        {
            InitializeComponent();
            buttonAdv1.Visible = false;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the caption.
        /// </summary>
        public string Caption
        {
            get
            {
                return label1.Text;
            }

            set
            {
                label1.Text = value;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The get table.
        /// </summary>
        /// <returns>
        /// The <see cref="TableLayoutPanel" />.
        /// </returns>
        public TableLayoutPanel GetTable()
        {
            return tableLayoutPanel1;
        }

        /// <summary>
        /// The get value.
        /// </summary>
        /// <returns>
        /// The <see cref="object" />.
        /// </returns>
        public object GetValue()
        {
            return textBoxExt1.Text;
        }

        #endregion
    }
}