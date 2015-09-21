using MW5.Shared.Log;

namespace MW5.Plugins.Interfaces
{
    /// <summary>
    /// A tool that can be added to GIS toolbox. 
    /// Supports tasks / asyncronous execution and automatic UI generation.
    /// </summary>
    public interface IGisTool: ITool
    {
        /// <summary>
        /// A method to be called after the main IGisTool.Run method is successfully finished.
        /// Is executed on the UI thread. Typically used to save output datasources.
        /// </summary>
        bool AfterRun();

        /// <summary>
        /// Gets or sets callback object used to stop execution of MapWinGIS methods.
        /// </summary>
        IGlobalListener Callback { get; set; }

        /// <summary>
        /// Clears callbacks and closes inputs datasources.
        /// </summary>
        void CleanUp();
        
        /// <summary>
        /// Gets the logger associated with tool.
        /// </summary>
        IToolLogger Log { get; }

        /// <summary>
        /// Executes the tool.
        /// </summary>
        bool Run(ITaskHandle task);

        /// <summary>
        /// Gets a value indicating whether tasks should be executed 
        /// in sequence rather than in parallel when running in batch mode.
        /// </summary>
        bool SequentialBatchExecution { get; }

        /// <summary>
        /// Gets a value indicating whether the tool supports canceling.
        /// </summary>
        bool SupportsCancel { get; }

        /// <summary>
        /// Gets the name of the task running the current tool.
        /// </summary>
        string TaskName { get; }

        /// <summary>
        /// Validates the values of input and output parameters.
        /// </summary>
        /// <returns>True if the values are valid.</returns>
        bool Validate();
    }
}
