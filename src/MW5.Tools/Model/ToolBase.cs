using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Concrete;
using MW5.Plugins.Interfaces;

namespace MW5.Tools.Model
{
    /// <summary>
    /// A base class for custom tools which don't task support and automatic UI generation.
    /// </summary>
    public abstract class ToolBase: ITool
    {
        /// <summary>
        /// The name of the tool.
        /// </summary>
        public abstract string Name { get;  }

        /// <summary>
        /// Description of the tool.
        /// </summary>
        public abstract string Description { get; }

        /// <summary>
        /// Runs the tool.
        /// </summary>
        public abstract bool Run();

        /// <summary>
        /// Gets the identity of plugin that created this tool.
        /// </summary>
        public abstract PluginIdentity PluginIdentity { get;  }

        /// <summary>
        /// Initializes the tool.
        /// </summary>
        public abstract void Initialize(IAppContext context);

        /// <summary>
        /// Returns true if a tool can be executed asynchronously using tasks.
        /// </summary>
        public bool SupportsTasks
        {
            get { return false; }
        }

        /// <summary>
        /// Gets a value indicating whether the tool supports batch execution.
        /// </summary>
        public bool SupportsBatchExecution
        {
            get { return false; }
        }
    }
}
