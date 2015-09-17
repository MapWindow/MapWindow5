using MW5.Shared.Log;

namespace MW5.Plugins.Interfaces
{
    /// <summary>
    /// A tool that can be added to GIS toolbox. 
    /// Supports tasks / asyncronous execution and automatic UI generation.
    /// </summary>
    public interface IGisTool: ITool
    {
        IToolLogger Log { get; }

        bool SupportsCancel { get; }

        bool AfterRun();

        bool Run(ITaskHandle task);

        IApplicationCallback Callback { get; set; }

        void CleanUp();

        bool Validate();

        /// <summary>
        /// Gets the name of the task running the current tool.
        /// </summary>
        string TaskName { get; }

        /// <summary>
        /// Gets a value indicating whether tasks should be executed 
        /// in sequence rather than in parallel when running in batch mode.
        /// </summary>
        bool SequentialBatchExecution { get; }
    }
}
