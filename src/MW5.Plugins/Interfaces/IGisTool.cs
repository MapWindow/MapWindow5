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
    }
}
