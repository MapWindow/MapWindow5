using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MW5.Plugins.Concrete;
using MW5.Plugins.Interfaces;
using MW5.Shared.Log;
using MW5.Tools.Services;

namespace MW5.Tools.Model
{
    public abstract class GisToolBase: IGisTool
    {
        private PluginIdentity _identity;

        /// <summary>
        /// Gets the identity of plugin that created this tool.
        /// </summary>
        public PluginIdentity PluginIdentity
        {
            get { return _identity; }
        }

        /// <summary>
        /// The name of the tool.
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// Description of the tool.
        /// </summary>
        public abstract string Description { get; }

        /// <summary>
        /// Runs the tool.
        /// </summary>
        public abstract bool Run(ITaskHandle task);

        /// <summary>
        /// Initializes the tool.
        /// </summary>
        public abstract void Initialize(IAppContext context);

        /// <summary>
        /// Gets the logger associated with the tool.
        /// </summary>
        public abstract IToolLogger Log { get; }

        /// <summary>
        /// Sets callback to all input datasource to report progress of operation. 
        /// Must be set to null when execution is finished.
        /// </summary>
        public virtual void SetCallback(IApplicationCallback callback) { }

        /// <summary>
        /// Removes callbacks assigned to the input layers.
        /// </summary>
        public virtual void CleanUp() { }

        /// <summary>
        /// Gets a value indicating whether the tool suppports cancelling.
        /// </summary>
        public virtual bool SupportsCancel
        {
            get { return false; }
        }
    }
}
