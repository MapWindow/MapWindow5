using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MW5.Plugins.Concrete;
using MW5.Plugins.Interfaces;
using MW5.Tools.Services;

namespace MW5.Tools.Model
{
    public abstract class GisToolBase: IGisTool
    {
        private IToolProgress _progress;
        private PluginIdentity _identity;

        /// <summary>
        /// Gets the identity of plugin that created this tool.
        /// </summary>
        public PluginIdentity PluginIdentity
        {
            get { return _identity; }
        }

        public IToolProgress Progress
        {
            get { return _progress ?? (_progress = new EmptyProgress()); }
            set
            {
                if (value == null) value = new EmptyProgress();
                _progress = value;
            }
        }

        public bool Cancelled { get; set; }

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
        public abstract bool Run(CancellationToken token);

        /// <summary>
        /// Initializes the tool.
        /// </summary>
        public abstract void Initialize(IAppContext context);
    }
}
