// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BooleanParameterControl.cs" company="MapWindow OSS Team - www.mapwindow.org">
//   MapWindow OSS Team - 2015
// </copyright>
// <summary>
//   The boolean parameter control.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MW5.Tools.Views.Controls
{
    #region

    using System.Windows.Forms;

    #endregion

    /// <summary>
    /// The boolean parameter control.
    /// </summary>
    public partial class BooleanParameterControl : ParameterControlBase, IParameterControl
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BooleanParameterControl"/> class.
        /// </summary>
        public BooleanParameterControl()
        {
            InitializeComponent();
            ButtonVisible = false;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets a value indicating whether button visible.
        /// </summary>
        public bool ButtonVisible
        {
            get
            {
                return false;
            }

            set
            {
            }
        }

        /// <summary>
        /// Gets or sets the caption.
        /// </summary>
        public string Caption
        {
            get
            {
                return checkBoxAdv1.Text;
            }

            set
            {
                checkBoxAdv1.Text = value;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The get table.
        /// </summary>
        /// <returns>
        /// The <see cref="TableLayoutPanel"/>.
        /// </returns>
        public TableLayoutPanel GetTable()
        {
            return tableLayoutPanel1;
        }

        /// <summary>
        /// The get value.
        /// </summary>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        public object GetValue()
        {
            return checkBoxAdv1.Checked;
        }

        #endregion
    }
}