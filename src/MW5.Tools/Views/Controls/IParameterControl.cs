// -------------------------------------------------------------------------------------------
// <copyright file="IParameterControl.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Windows.Forms;

namespace MW5.Tools.Views.Controls
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
        /// The get table.
        /// </summary>
        TableLayoutPanel GetTable();

        /// <summary>
        /// The get value.
        /// </summary>
        object GetValue();
    }
}