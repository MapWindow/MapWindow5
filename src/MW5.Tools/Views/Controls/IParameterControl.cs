// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IParameterControl.cs" company="MapWindow OSS Team - www.mapwindow.org">
//   MapWindow OSS Team - 2015
// </copyright>
// <summary>
//   The ParameterControl interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MW5.Tools.Views.Controls
{
    #region

    using System;
    using System.Windows.Forms;

    #endregion

    /// <summary>
    /// The ParameterControl interface.
    /// </summary>
    public interface IParameterControl
    {
        #region Public Events

        /// <summary>
        /// The value changed event
        /// </summary>
        event EventHandler<EventArgs> ValueChanged;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the caption.
        /// </summary>
        string Caption { get; set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The get table.
        /// </summary>
        /// <returns>The <see cref="TableLayoutPanel"/>.</returns>
        TableLayoutPanel GetTable();

        /// <summary>
        /// The get value.
        /// </summary>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        object GetValue();

        #endregion
    }
}