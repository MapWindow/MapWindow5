// -------------------------------------------------------------------------------------------
// <copyright file="ToolboxGroupCollection.cs" company="MapWindow OSS Team - www.mapwindow.org">
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
    /// Provides access to the list of groups of group toolbox.
    /// </summary>
    public class ToolboxGroupCollection : IToolboxGroups
    {
        private readonly TreeNodeAdvCollection _nodes;

        /// <summary>
        /// Initializes a new instance of the <see cref="ToolboxGroupCollection"/> class.
        /// </summary>
        internal ToolboxGroupCollection(TreeNodeAdvCollection nodes)
        {
            if (nodes == null) throw new NullReferenceException();

            _nodes = nodes;
        }

        /// <summary>
        ///     Returns the number of groups in the list.
        /// </summary>
        public int Count
        {
            get { return _nodes.Cast<TreeNode>().Count(node => (node.Tag is IToolboxGroup)); }
        }

        /// <summary>
        /// Adds the specified item.
        /// </summary>
        public IToolboxGroup Add(string name, string key, PluginIdentity identity)
        {
            var group = new ToolboxGroup(name, key, identity);

            _nodes.Add(group.InnerObject);

            return group;
        }

        /// <summary>
        ///     Clears all the groups.
        /// </summary>
        public void Clear()
        {
            for (var i = _nodes.Count - 1; i >= 0; i--)
            {
                var group = _nodes[i].Tag as IToolboxGroup;
                if (group != null)
                {
                    _nodes.RemoveAt(i);
                }
            }
        }


        /// <summary>
        /// Runs recursive search of the group by its key at the current and nested levels.
        /// </summary>
        public IToolboxGroup FindGroup(string groupKey)
        {
            foreach (var g in this)
            {
                if (g.Key == groupKey)
                {
                    return g;
                }
            }

            foreach (var g in this)
            {
                var subGroup = g.SubGroups.FindGroup(groupKey);
                if (subGroup != null)
                {
                    return subGroup;
                }
            }

            return null;
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Collections.Generic.IEnumerator`1" /> that can be used to iterate through the collection.
        /// </returns>
        public IEnumerator<IToolboxGroup> GetEnumerator()
        {
            // group may have tools apart from nested groups,
            // therefore we don't use usual this[index] property
            for (var i = 0; i < _nodes.Count; i++)
            {
                if (_nodes[i].Tag is ToolboxGroupMetadata)
                {
                    yield return new ToolboxGroup(_nodes[i]);
                }
            }
        }

        /// <summary>
        /// Removes the specified item.
        /// </summary>
        public bool Remove(string key)
        {
            var group = this.FirstOrDefault(g => g.Key == key);
            if (group != null)
            {
                _nodes.Remove(group.InnerObject);
                return true;
            }
            
            return false;
        }

        /// <summary>
        /// Removes the items for plugin.
        /// </summary>
        /// <param name="identity">The identity.</param>
        public void RemoveItemsForPlugin(PluginIdentity identity)
        {
            var removeList = new List<IToolboxGroup>();

            foreach (var g in this)
            {
                if (g.PluginIdentity == identity)
                {
                    removeList.Add(g);
                    continue;
                }

                g.SubGroups.RemoveItemsForPlugin(identity);
                g.Tools.RemoveItemsForPlugin(identity);
            }

            foreach (var g in removeList)
            {
                Remove(g.Key);
            }
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerator" /> object that can be used to iterate through the collection.
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}