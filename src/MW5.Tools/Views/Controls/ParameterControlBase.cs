// -------------------------------------------------------------------------------------------
// <copyright file="ParameterControlBase.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Windows.Forms;

namespace MW5.Tools.Views.Controls
{
    #region

    

    #endregion

    /// <summary>
    /// The parameter control base.
    /// </summary>
    public partial class ParameterControlBase : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ParameterControlBase"/> class.
        /// </summary>
        public ParameterControlBase()
        {
            InitializeComponent();
        }

        /// <summary>
        /// The value changed.
        /// </summary>
        public event EventHandler<EventArgs> ValueChanged;

        /// <summary>
        /// Gets the as base.
        /// </summary>
        public IParameterControl AsBase
        {
            get { return this as IParameterControl; }
        }

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
    }
}