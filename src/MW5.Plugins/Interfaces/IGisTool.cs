using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MW5.Plugins.Concrete;
using MW5.Shared.Log;

namespace MW5.Plugins.Interfaces
{
    /// <summary>
    /// A tool from geoprocessing toolbox.
    /// </summary>
    public interface IGisTool
    {
        /// <summary>
        /// The name of the tool.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Description of the tool.
        /// </summary>
        string Description { get; }

        /// <summary>
        /// Runs the tool.
        /// </summary>
        bool Run(ITaskHandle task);

        /// <summary>
        /// Gets the identity of plugin that created this tool.
        /// </summary>
        PluginIdentity PluginIdentity { get; }

        /// <summary>
        /// Initializes the tool.
        /// </summary>
        void Initialize(IAppContext context);

        /// <summary>
        /// Gets the logger associated with the tool.
        /// </summary>
        IToolLogger Log { get; }

        /// <summary>
        /// Sets callback to all input datasource to report progress of operation. 
        /// Must be set to null when execution is finished.
        /// </summary>
        void SetCallback(IApplicationCallback callback);

        /// <summary>
        /// Gets a value indicating whether the tool suppports cancelling.
        /// </summary>
        /// <remarks>In case of long running MapWinGIS geoprocessing, the method must accept 
        /// IStopExecution interface as a parameter or use an instance of the class implementing this interface
        /// assigned via property, e.g. Shapefile.StopExecution. 
        /// For tools with the main loop in the managed code it's enough to call ITaskHandle.AbortIfCancelled or 
        /// ITaskHandle.CheckPauseAndCancel.
        /// </remarks>
        bool SupportsCancel { get; }
    }
}
