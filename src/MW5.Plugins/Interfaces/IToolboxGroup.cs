using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Concrete;

namespace MW5.Plugins.Interfaces
{
    /// <summary>
    /// Holds information about tool from geoprocessing toolbox. Must be created with GisToolbox.CreateGroup.
    /// </summary>
    public interface IToolboxGroup
    {
        /// <summary>
        /// Gets or sets the unique key for the group. 
        /// </summary>
        string Key { get; }

        /// <summary>
        /// The name of the tool
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Description of the tool
        /// </summary>
        string Description { get; set; }

        /// <summary>
        /// A property to store additional data associated with tool
        /// </summary>
        object Tag { get; set; }

        /// <summary>
        /// List of tools inside the groups
        /// </summary>
        IToolCollection Tools { get; }

        /// <summary>
        /// List of sub groups inside the group
        /// </summary>
        IToolboxGroups SubGroups { get; }

        /// <summary>
        /// Gets or sets the expanded state of the group
        /// </summary>
        bool Expanded { get; set; }

        /// <summary>
        /// Gets identity of the plugin that created this group.
        /// </summary>
        PluginIdentity PluginIdentity { get; }

        object InnerObject { get; }
    }
}
