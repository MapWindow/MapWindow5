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
    /// A tool that can be added to GIS toolbox.
    /// </summary>
    public interface ITool
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
        bool Run();

        /// <summary>
        /// Gets the identity of plugin that created this tool.
        /// </summary>
        PluginIdentity PluginIdentity { get; }

        /// <summary>
        /// Initializes the tool.
        /// </summary>
        void Initialize(IAppContext context);

        /// <summary>
        /// Returns true if a tool can be executed asynchronously using tasks.
        /// </summary>
        bool SupportsTasks { get; }
    }
}
