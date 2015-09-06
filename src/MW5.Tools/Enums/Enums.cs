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
        Auto = 0, 
        Field = 1, 
        Combo = 2,
    }

    public enum ToolboxResultsCommand
    {
        Clear = 0,
        OpenLog = 2,
        CancelTask = 3,
        PauseTask = 4,
        RemoveTask = 5,
    }

    internal enum TaskIcons
    {
        InProgress = 0,
        Success = 1,
        Error = 2,
        Input = 3,
        Result = 4,
        Execution = 5,
        Log = 6,
        Cancel = 7,
        Pause = 8,
    }

    public enum ToolIcon
    {
        Folder = 0,
        ToolDefault = 1,
        Vector = 2,
        Database = 3,
        Hammer = 4,
    }

    public enum ToolboxCommand
    {
        Run = 0,
        BatchRun = 1,
    }
}