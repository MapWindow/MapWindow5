using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MW5.Plugins.Concrete;

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
    }
}
