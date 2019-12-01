// -------------------------------------------------------------------------------------------
// <copyright file="ToolboxGroupCollection.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015-2019
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MW5.Plugins.Concrete;
using MW5.Plugins.Interfaces;
using MW5.Tools.Enums;
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
            _nodes = nodes ?? throw new NullReferenceException();
        }

        /// <summary>
        /// Returns the number of groups in the list.
        /// </summary>
        public int Count
        {
            get { return _nodes.Cast<TreeNodeAdv>().Count(node => (node.Tag is IToolboxGroup)); }
        }

        /// <summary>
        /// Adds the specified item.
        /// </summary>
        public IToolboxGroup Add(string name, string key, PluginIdentity identity)
        {
            var metadata = new ToolboxGroupMetadata(key, name, identity);

            var node = new TreeNodeAdv
            {
                Tag = metadata,
                Text = metadata.Name,
                LeftImageIndices = new[] { (int)ToolIcon.Folder }
            };

            _nodes.Add(node);
            node.Expanded = true;

            return new ToolboxGroup(node);
        }

        /// <summary>
        /// Clears all the groups.
        /// </summary>
        public void Clear()
        {
            for (var i = _nodes.Count - 1; i >= 0; i--)
            {
                if (IsGroup(_nodes[i]))
                {
                    _nodes.RemoveAt(i);
                }
            }
        }

        private bool IsGroup(TreeNodeAdv node)
        {
            return node.Tag is ToolboxGroupMetadata;
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
        public IEnumerator<IToolboxGroup> GetEnumerator()
        {
            // group may have tools apart from nested groups,
            // therefore we don't use usual this[index] property
            for (var i = 0; i < _nodes.Count; i++)
            {
                var g = GetGroup(i);
                if (g != null)
                {
                    yield return g;
                }
            }
        }

        private ToolboxGroup GetGroup(int index)
        {
            return IsGroup(_nodes[index]) ? new ToolboxGroup(_nodes[index]) : null;
        }

        /// <summary>
        /// Removes the specified item.
        /// </summary>
        public bool Remove(string key)
        {
            var group = this.FirstOrDefault(g => g.Key == key);
            if (group == null) return false;

            _nodes.Remove(group.InnerObject);
            return true;
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
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}