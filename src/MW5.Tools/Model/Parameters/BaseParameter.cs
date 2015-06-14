// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BaseParameter.cs" company="MapWindow OSS Team - www.mapwindow.org">
//   MapWindow OSS Team - 2015
// </copyright>
// <summary>
//   The base parameter.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MW5.Tools.Model.Parameters
{
    #region

    using System;

    using MW5.Tools.Views.Controls;

    #endregion

    /// <summary>
    /// The base parameter.
    /// </summary>
    public abstract class BaseParameter
    {
        #region Fields

        private ParameterControlBase _control;

        #endregion

        #region Public Events

        /// <summary>
        /// The value changed.
        /// </summary>
        public event Action ValueChanged;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the control.
        /// </summary>
        public ParameterControlBase Control
        {
            get
            {
                return _control;
            }

            set
            {
                _control = value;
                _control.ValueChanged += _control_ValueChanged;
            }
        }

        /// <summary>
        /// Gets or sets the display name.
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the index.
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="BaseParameter"/> is required.
        /// </summary>
        public bool Required { get; set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The create control.
        /// </summary>
        /// <returns>
        /// The <see cref="ParameterControlBase"/>.
        /// </returns>
        public abstract ParameterControlBase CreateControl();

        #endregion

        #region Methods

        /// <summary>
        /// The _control_ value changed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void _control_ValueChanged(object sender, EventArgs e)
        {
            var handler = ValueChanged;
            if (handler != null)
            {
                handler();
            }
        }

        #endregion
    }
}