using System;
using System.Windows.Forms;
using MW5.Plugins.Concrete;
using MW5.Plugins.Interfaces;

namespace MW5.Tools.Toolbox
{
    /// <summary>
    /// Group of tools in the toolbox.
    /// </summary>
    public class GroupNode : IToolboxGroup
    {
        private readonly TreeNode _node;
        private string _name;
        private readonly PluginIdentity _identity;

        /// <summary>
        /// Creates a new instance of GIS tool class
        /// </summary>
        internal GroupNode(string name, string description, PluginIdentity identity)
        {
            if (identity == null) throw new ArgumentNullException("identity");
            
            _identity = identity;
            _name = name;

            Description = description;

            _node = new TreeNode {Text = name, ImageIndex = GisToolbox.IconFolder};
            _node.Expand();
            _node.Tag = this;
        }

        /// <summary>
        /// Description of the tool
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// A property to store additional data associated with tool
        /// </summary>
        public object Tag { get; set; }

        /// <summary>
        /// Gets or sets the name of tool
        /// </summary>
        public string Name
        {
            get{ return _name; }
            set
            {
                _name = value;
                if (_node != null)
                {
                    _node.Text = _name;
                }
            }
        }

        /// <summary>
        /// Gets list of tools for current group
        /// </summary>
        public IToolCollection Tools
        {
            get { return new ToolCollection(_node.Nodes); }
        }

        /// <summary>
        /// Gets list of child groups fro current group
        /// </summary>
        public IToolboxGroups SubGroups
        {
            get 
            {
                if (_node == null)
                {
                    throw new NullReferenceException();
                }
                
                return new GroupCollection(_node.Nodes);
            }
        }

        
        /// <summary>
        /// Gets or sets the expanded state of group in treeview
        /// </summary>
        public bool Expanded
        {
            get
            {
                return _node.IsExpanded;
            }
            set
            {
                if (value)
                {
                    _node.Expand();
                }
                else
                {
                    _node.Collapse();
                }
            }
        }

        public PluginIdentity PluginIdentity
        {
            get { return _identity; }
        }

        /// <summary>
        /// Source tree node for the group
        /// </summary>
        internal TreeNode Node
        {
            get { return _node; }
        }
    }
}
