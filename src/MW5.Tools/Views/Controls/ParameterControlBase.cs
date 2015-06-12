// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParameterControlBase.cs" company="MapWindow OSS Team - www.mapwindow.org">
//   MapWindow OSS Team - 2015
// </copyright>
// <summary>
//   The parameter control base.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MW5.Tools.Views.Controls
{
    #region

    using System;
    using System.Windows.Forms;

    #endregion

    /// <summary>
    /// The parameter control base.
    /// </summary>
    public partial class ParameterControlBase : UserControl
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ParameterControlBase"/> class.
        /// </summary>
        public ParameterControlBase()
        {
            InitializeComponent();
        }

        #endregion

        #region Public Events

        /// <summary>
        /// The value changed.
        /// </summary>
        public event EventHandler<EventArgs> ValueChanged;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the as base.
        /// </summary>
        public IParameterControl AsBase
        {
            get
            {
                return this as IParameterControl;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// The fire value changed.
        /// </summary>
        protected void FireValueChanged()
        {
            var handler = ValueChanged;
            if (handler != null)
            {
                handler(this, new EventArgs());
            }
        }

        #endregion
    }
}