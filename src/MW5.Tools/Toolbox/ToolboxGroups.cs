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
    /// Provides access to the list of groups of group toolbox.
    /// </summary>
    public class ToolboxGroups: IToolboxGroups
    {
        private readonly TreeNodeCollection _nodes = null;

        /// <summary>
        /// Creates a new instance of GisToolboxGroups class. 
        /// </summary>
        internal ToolboxGroups(TreeNodeCollection nodes)
        {
            if (nodes == null) throw new NullReferenceException();
            _nodes = nodes;
        }
    
        /// <summary>
        /// Adds new tool to the group
        /// </summary>
        public void Add(IToolboxGroup item)
        {
            if (Equals(item)) throw new InvalidOperationException();
            
            var group = item as ToolboxGroup;
            if (group == null)
            {
                throw new InvalidCastException();
            }

            int i = 0;
            for (; i < _nodes.Count; i++)
            {
                if (!(_nodes[i].Tag is IToolboxGroup))
                {
                    break;
                }
            }

            TreeNode node = ((ToolboxGroup)item).Node;

            if (i < _nodes.Count)
            {
                _nodes.Insert(i, node);
            }
            else
            {
                _nodes.Add(node);
            }
        }

        public void RemoveItemsForPlugin(PluginIdentity identity)
        {
            for (int i = _nodes.Count - 1; i >= 0; i--)
            {
                var group = _nodes[i].Tag as IToolboxGroup;

                if (group == null)
                {
                    continue;
                }

                if (group.PluginIdentity == identity)
                {
                    _nodes.RemoveAt(i);
                }
                else
                {
                    group.SubGroups.RemoveItemsForPlugin(identity);
                    group.Tools.RemoveItemsForPlugin(identity);
                }
            }
        }

        /// <summary>
        /// Clears all the groups.
        /// </summary>
        public void Clear()
        {
            for (int i = _nodes.Count - 1; i >= 0; i--)
            {
                IToolboxGroup group = _nodes[i].Tag as IToolboxGroup;
                if (group != null)
                {
                    _nodes.RemoveAt(i);
                }
            }
        }

        /// <summary>
        /// Returns a value indicating whether list of groups contain particular group.
        /// </summary>
        public bool Contains(IToolboxGroup item)
        {
            if (item == null)
            {
                return false;
            }

            for (int i = 0; i < _nodes.Count; i++ )
            {
                IToolboxGroup group = _nodes[i].Tag as IToolboxGroup;
                if (group == item)
                    return true;
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
                return _nodes.Cast<TreeNode>().Count(node => (node.Tag is IToolboxGroup));
            }
        }

        /// <summary>
        /// Removes the specified item.
        /// </summary>
        public bool Remove(IToolboxGroup item)
        {
            foreach (TreeNode node in _nodes)
            {
                if (node.Tag as IToolboxGroup == item)
                {
                    _nodes.Remove(node);
                    return true;
                }
            }
            return false;
        }

        public IEnumerator<IToolboxGroup> GetEnumerator()
        {
            for (int i = 0; i < _nodes.Count; i++)
            {
                if (_nodes[i].Tag is IToolboxGroup)
                {
                    yield return _nodes[i].Tag as IToolboxGroup;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}