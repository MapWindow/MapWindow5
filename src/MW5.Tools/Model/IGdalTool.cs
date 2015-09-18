// -------------------------------------------------------------------------------------------
// <copyright file="IGdalTool.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

namespace MW5.Tools.Model
{
    /// <summary>
    /// Represents a GDAL tool. Provides methods to work with command line options.
    /// </summary>
    public interface IGdalTool
    {
        /// <summary>
        /// Gets or sets complete list of options that will be used during tool execution.
        /// </summary>
        string EffectiveOptions { get; }

        /// <summary>
        /// Gets or sets a value indicating whether additional option should override all other options set via UI.
        /// </summary>
        bool OverrideOptions { get; set; }

        /// <summary>
        /// Gets or sets the additional command line options.
        /// </summary>
        string AdditionalOptions { get; set; }

        /// <summary>
        /// Gets the command line options.
        /// </summary>
        /// <param name="mainOnly">If set to <c>true</c> additional options set by user won't be included.</param>
        string GetOptions(bool mainOnly = false);

        /// <summary>
        /// Gets a value indicating whether tool support command line driver creation options (-co).
        /// </summary>
        bool SupportDriverCreationOptions { get; }
    }
}