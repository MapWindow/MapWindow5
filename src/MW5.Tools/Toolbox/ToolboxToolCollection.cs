// -------------------------------------------------------------------------------------------
// <copyright file="ToolboxToolCollection.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MW5.Plugins.Concrete;
using MW5.Plugins.Interfaces;
using Syncfusion.Windows.Forms.Tools;

namespace MW5.Tools.Toolbox
{
    /// <summary>
    /// Represents collection of tree nodes with tools.
    /// </summary>
    internal class ToolboxToolCollection : IToolCollection
    {
        private readonly TreeNodeAdvCollection _nodes;

        /// <summary>
        /// Initializes a new instance of the <see cref="ToolboxToolCollection"/> class.
        /// </summary>
        internal ToolboxToolCollection(TreeNodeAdvCollection nodes)
        {
            if (nodes == null) throw new NullReferenceException();

            _nodes = nodes;
        }

        /// <summary>
        /// Returns the number of groups in the list.
        /// </summary>
        public int Count
        {
            get { return _nodes.Cast<TreeNode>().Count(node => (node.Tag is IGisTool)); }
        }

        /// <summary>
        /// Adds new tool to the group
        /// </summary>
        public void Add(IGisTool item)
        {
            if (item == null) throw new ArgumentNullException("item");

            var node = new TreeNodeAdv
            {
                Tag = item,
                Text = item.Name,
                LeftImageIndices = new[] { ToolboxDockPanel.IconTool }
            };
            
            _nodes.Add(node);
        }

        /// <summary>
        /// Clears all the groups
        /// </summary>
        public void Clear()
        {
            for (var i = _nodes.Count - 1; i >= 0; i++)
            {
                var tool = GetTool(_nodes[i]);
                if (tool != null)
                {
                    _nodes.RemoveAt(i);
                }
            }
        }

        /// <summary>
        /// The get enumerator.
        /// </summary>
        public IEnumerator<IGisTool> GetEnumerator()
        {
            for (var i = 0; i < _nodes.Count; i++)
            {
                if (_nodes[i].Tag is IGisTool)
                {
                    yield return _nodes[i].Tag as IGisTool;
                }
            }
        }

        /// <summary>
        /// Removes group at specified position
        /// </summary>
        public bool Remove(IGisTool item)
        {
            foreach (var node in _nodes.Cast<TreeNodeAdv>().Where(node => GetTool(node) == item))
            {
                _nodes.Remove(node);
                return true;
            }

            return false;
        }

        /// <summary>
        /// The remove items for plugin.
        /// </summary>
        public void RemoveItemsForPlugin(PluginIdentity identity)
        {
            for (var i = _nodes.Count - 1; i >= 0; i--)
            {
                var tool = GetTool(_nodes[i]);
                if (tool != null && tool.PluginIdentity == identity)
                {
                    _nodes.RemoveAt(i);
                }
            }
        }

        /// <summary>
        /// The get enumerator.
        /// </summary>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private IGisTool GetTool(TreeNodeAdv node)
        {
            return node.Tag as IGisTool;
        }
    }
}