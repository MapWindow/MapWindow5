// -------------------------------------------------------------------------------------------
// <copyright file="ToolboxGroup.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using MW5.Plugins.Concrete;
using MW5.Plugins.Interfaces;
using Syncfusion.Windows.Forms.Tools;

namespace MW5.Tools.Toolbox
{
    /// <summary>
    /// Group of tools in the toolbox.
    /// </summary>
    internal class ToolboxGroup : IToolboxGroup
    {
        private readonly TreeNodeAdv _node;

        public ToolboxGroup(TreeNodeAdv node)
        {
            if (node == null) throw new ArgumentNullException("node");

            if (!(node.Tag is ToolboxGroupMetadata))
            {
                throw new ApplicationException("No metadata is found for toolbox group node.");
            }

            _node = node;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ToolboxGroup"/> class.
        /// </summary>
        internal ToolboxGroup(string name, string key, PluginIdentity identity)
        {
            if (identity == null) throw new ArgumentNullException("identity");

            _node = new TreeNodeAdv
                        {
                            Text = name,
                            LeftImageIndices = new[] { ToolboxDockPanel.IconFolder },
                            Tag = new ToolboxGroupMetadata(key, name, identity)
                        };

            _node.Expand();
        }

        private ToolboxGroupMetadata Metadata
        {
            get
            {
                var metadata = _node.Tag as ToolboxGroupMetadata;

                if (metadata == null)
                {
                    throw new NullReferenceException("Metadata for toolbox group was not set.");
                }

                return metadata;
            }
        }

        /// <summary>
        /// Source tree node for the group
        /// </summary>
        public object InnerObject
        {
            get { return _node; }
        }

        /// <summary>
        /// Description of the tool
        /// </summary>
        public string Description
        {
            get { return Metadata.Description; }
            set { Metadata.Description = value; }
        }

        /// <summary>
        /// Gets or sets the expanded state of group in treeview
        /// </summary>
        public bool Expanded
        {
            get { return _node.Expanded; }
            set { _node.Expanded = value; }
        }

        /// <summary>
        /// Gets or sets the unique key for the group. 
        /// </summary>
        public string Key
        {
            get { return Metadata.Key; }
        }

        /// <summary>
        /// Gets or sets the name of tool
        /// </summary>
        public string Name
        {
            get { return _node.Text; }
            set { _node.Text = value; }
        }

        /// <summary>
        /// Gets identity of the plugin that created this group.
        /// </summary>
        public PluginIdentity PluginIdentity
        {
            get { return Metadata.PluginIdentity; }
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

                return new ToolboxGroupCollection(_node.Nodes);
            }
        }

        /// <summary>
        /// A property to store additional data associated with tool
        /// </summary>
        public object Tag
        {
            get { return Metadata.Tag; }
            set { Metadata.Tag = value; }
        }

        /// <summary>
        /// Gets list of tools for current group
        /// </summary>
        public IToolCollection Tools
        {
            get { return new ToolboxToolCollection(_node.Nodes); }
        }
    }
}