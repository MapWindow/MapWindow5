// -------------------------------------------------------------------------------------------
// <copyright file="IParameterControl.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;

namespace MW5.Tools.Controls.Parameters
{
    /// <summary>
    /// The ParameterControl interface.
    /// </summary>
    public interface IParameterControl
    {
        /// <summary>
        /// The value changed event
        /// </summary>
        event EventHandler<EventArgs> ValueChanged;

        /// <summary>
        /// Gets or sets the caption.
        /// </summary>
        string Caption { get; set; }

        /// <summary>
        /// Gets the value.
        /// </summary>
        object GetValue();

        /// <summary>
        /// Sets the value.
        /// </summary>
        void SetValue(object value);
    }
}