using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MW5.Plugins.Concrete;
using MW5.Plugins.Interfaces;

namespace MW5.Tools.Toolbox
{
    /// <summary>
    /// Provides access to the list of groups.
    /// </summary>
    internal class ToolCollection : IToolCollection
    {
        private readonly TreeNodeCollection _nodes = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="ToolCollection"/> class.
        /// </summary>
        internal ToolCollection(TreeNodeCollection nodes)
        {
            if (nodes == null) throw new NullReferenceException();
            _nodes = nodes;
        }

        /// <summary>
        /// Adds new tool to the group
        /// </summary>
        public void Add(IGisTool item)
        {
            var tool = item as ToolNode;
            if (tool == null)
            {
                throw new InvalidCastException("A tool must be created by calling GisToolBox.CreateTool.");
            }

            _nodes.Add(tool.Node);
        }

        public void RemoveItemsForPlugin(PluginIdentity identity)
        {
            for (int i = _nodes.Count - 1; i >= 0 ; i--)
            {
                var tool = _nodes[i].Tag as IGisTool;
                if (tool != null && tool.PluginIdentity == identity)
                {
                    _nodes.RemoveAt(i);
                }
            }
        }

        /// <summary>
        /// Clears all the groups
        /// </summary>
        public void Clear()
        {
            for (int i = _nodes.Count - 1; i >= 0; i++)
            {
                var tool = _nodes[i].Tag as IGisTool;
                if (tool != null)
                {
                    _nodes.RemoveAt(i);
                }
            }
        }

        /// <summary>
        /// Determines whether the list contains specified tool.
        /// </summary>
        public bool Contains(IGisTool item)
        {
            if (item == null)
            {
                return false;
            }

            for (int i = 0; i < _nodes.Count; i++)
            {
                var tool = _nodes[i].Tag as IGisTool;
                if (tool == item)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Returns the number of groups in the list.
        /// </summary>
        public int Count
        {
            get
            {
                return _nodes.Cast<TreeNode>().Count(node => (node.Tag is IGisTool));
            }
        }

        /// <summary>
        /// Removes group at specified position
        /// </summary>
        public bool Remove(IGisTool item)
        {
            foreach (TreeNode node in _nodes)
            {
                if (node.Tag as IGisTool == item)
                {
                    _nodes.Remove(node);
                    return true;
                }
            }
            return false;
        }

        public IEnumerator<IGisTool> GetEnumerator()
        {
            for (int i = 0; i < _nodes.Count; i++)
            {
                if (_nodes[i].Tag is IGisTool)
                {
                    yield return _nodes[i].Tag as IGisTool;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
