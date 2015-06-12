// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GroupNode.cs" company="MapWindow OSS Team - www.mapwindow.org">
//   MapWindow OSS Team - 2015
// </copyright>
// <summary>
//   Group of tools in the toolbox.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

using MW5.Plugins.Concrete;
using MW5.Plugins.Interfaces;

using Syncfusion.Windows.Forms.Tools;

namespace MW5.Tools.Toolbox
{
    /// <summary>
    ///     Group of tools in the toolbox.
    /// </summary>
    public class GroupNode : IToolboxGroup
    {
        #region Fields

        private readonly PluginIdentity _identity;
        private readonly TreeNodeAdv _node;
        private string _name;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="GroupNode"/> class.
        ///     Creates a new instance of GIS tool class
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <param name="description">
        /// The description.
        /// </param>
        /// <param name="identity">
        /// The identity.
        /// </param>
        internal GroupNode(string name, string description, PluginIdentity identity)
        {
            if (identity == null)
            {
                throw new ArgumentNullException("identity");
            }

            _identity = identity;
            _name = name;

            Description = description;

            _node = new TreeNodeAdv { Text = name, LeftImageIndices = new[] { ToolboxControl.IconFolder } };
            _node.Expand();
            _node.Tag = this;
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     Description of the tool
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        ///     Gets or sets the expanded state of group in treeview
        /// </summary>
        public bool Expanded
        {
            get
            {
                return _node.Expanded;
            }

            set
            {
                _node.Expanded = value;
            }
        }

        /// <summary>
        ///     Gets or sets the name of tool
        /// </summary>
        public string Name
        {
            get
            {
                return _name;
            }

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
        /// Gets identity of the plugin that created this group.
        /// </summary>
        public PluginIdentity PluginIdentity
        {
            get
            {
                return _identity;
            }
        }


        /// <summary>
        /// List of sub groups inside the group
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
        ///     A property to store additional data associated with tool
        /// </summary>
        public object Tag { get; set; }

        /// <summary>
        ///     Gets list of tools for current group
        /// </summary>
        public IToolCollection Tools
        {
            get
            {
                return new ToolCollection(_node.Nodes);
            }
        }

        #endregion

        #region Properties

        /// <summary>
        ///     Source tree node for the group
        /// </summary>
        internal TreeNodeAdv Node
        {
            get
            {
                return _node;
            }
        }

        #endregion
    }
}