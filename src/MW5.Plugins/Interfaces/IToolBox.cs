using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Concrete;

namespace MW5.Plugins.Interfaces
{
    /// <summary>
    /// Methods and properties provided by MapWindow GIS toolbox.
    /// </summary>
    public interface IToolbox
    {
        /// <summary>
        /// List of groups provided by toolbox
        /// </summary>
        IToolboxGroups Groups { get; }

        /// <summary>
        /// Provides access to all tools as common list
        /// </summary>
        IToolCollection Tools { get; }

        /// <summary>
        /// Creates a new instance of GisTool class
        /// </summary>
        IGisTool CreateTool(string name, string key, PluginIdentity identity);

        /// <summary>
        /// Creates a new instance of GisToolboxGroup class
        /// </summary>
        IToolboxGroup CreateGroup(string name, string key, PluginIdentity identity);

        /// <summary>
        /// Should be fired when a tool is selected
        /// </summary>
        event EventHandler<ToolboxToolEventArgs> ToolSelected;

        /// <summary>
        /// Should be fired when user wants to execute the tool
        /// </summary>
        event EventHandler<ToolboxToolEventArgs> ToolClicked;

        /// <summary>
        /// Should be fired when a group is selected
        /// </summary>
        event EventHandler<ToolboxGroupEventArgs> GroupSelected;

        /// <summary>
        /// Expands all the groups up to the target level
        /// </summary>
        void ExpandGroups(int level);
    }
}


