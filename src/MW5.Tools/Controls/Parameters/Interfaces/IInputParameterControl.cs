// -------------------------------------------------------------------------------------------
// <copyright file="IInputParameterControl.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using MW5.Plugins.Enums;
using MW5.Plugins.Services;

namespace MW5.Tools.Controls.Parameters.Interfaces
{
    /// <summary>
    /// Represents control for input datasource or filename selection.
    /// </summary>
    public interface IInputParameterControl
    {
        /// <summary>
        /// Occurs when control value is changed.
        /// </summary>
        event EventHandler<EventArgs> ValueChanged;

        /// <summary>
        /// Gets a value indicating whether control allows selection of multiple files (batch mode).
        /// </summary>
        bool BatchMode { get; }

        /// <summary>
        /// Gets values of the control.
        /// </summary>
        object GetValue();

        /// <summary>
        /// Initializes the control with specified datasource type.
        /// </summary>
        /// <param name="dataType">Type of the data.</param>
        /// <param name="dialogService">File dialog service.</param>
        void Initialize(DataSourceType dataType, IFileDialogService dialogService);
    }
}