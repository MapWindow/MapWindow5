// -------------------------------------------------------------------------------------------
// <copyright file="ToolBase.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015-2019
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using MW5.Plugins.Concrete;
using MW5.Plugins.Interfaces;

namespace MW5.Tools.Model
{
    /// <summary>
    /// A base class for custom tools which don't task support and automatic UI generation.
    /// </summary>
    public abstract class ToolBase: ITool
    {
        protected IAppContext _context;

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
        public virtual void Initialize(IAppContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// Returns true if a tool can be executed asynchronously using tasks.
        /// </summary>
        public bool SupportsTasks => false;

        /// <summary>
        /// Gets a value indicating whether the tool supports batch execution.
        /// </summary>
        public bool SupportsBatchExecution => false;
    }
}
