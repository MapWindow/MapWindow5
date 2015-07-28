// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Enums.cs" company="MapWindow OSS Team - www.mapwindow.org">
//   MapWindow OSS Team - 2015
// </copyright>
// <summary>
//   The parameter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MW5.Tools.Enums
{
    /// <summary>
    /// The parameter type.
    /// </summary>
    public enum ParameterType
    {
        /// <summary>The input layer.</summary>
        InputLayer = 0, 

        /// <summary>The options.</summary>
        Options = 1, 

        /// <summary>The boolean.</summary>
        Boolean = 2
    }

    public enum ToolboxResultsCommand
    {
        Clear = 0,
        ToggleGroup = 1,
    }
}