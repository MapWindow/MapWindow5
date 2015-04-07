using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        string Name { get; set; }

        /// <summary>
        /// Description of the tool.
        /// </summary>
        string Description { get; set; }

        /// <summary>
        /// A key of the tool.
        /// </summary>
        string Key { get; set; }

        /// <summary>
        /// A property to store additional data associated with tool.
        /// </summary>
        object Tag { get; set; }

        /// <summary>
        /// Gets the identity of plugin that created this tool.
        /// </summary>
        PluginIdentity PluginIdentity { get; }
    }
}
