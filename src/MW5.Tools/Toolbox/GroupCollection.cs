// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GroupCollection.cs" company="MapWindow OSS Team - www.mapwindow.org">
//   MapWindow OSS Team - 2015
// </copyright>
// <summary>
//   Provides access to the list of groups of group toolbox.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MW5.Tools.Toolbox
{
    #region

    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;

    using MW5.Plugins.Concrete;
    using MW5.Plugins.Interfaces;

    using Syncfusion.Windows.Forms.Tools;

    #endregion

    /// <summary>
    ///     Provides access to the list of groups of group toolbox.
    /// </summary>
    public class GroupCollection : IToolboxGroups
    {
        #region Fields

        private readonly TreeNodeAdvCollection _nodes;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="GroupCollection"/> class.
        /// </summary>
        /// <param name="nodes">The nodes.</param>
        internal GroupCollection(TreeNodeAdvCollection nodes)
        {
            if (nodes == null)
            {
                throw new NullReferenceException();
            }

            _nodes = nodes;
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     Returns the number of groups in the list.
        /// </summary>
        public int Count
        {
            get
            {
                return _nodes.Cast<TreeNode>().Count(node => (node.Tag is IToolboxGroup));
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Adds the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        public void Add(IToolboxGroup item)
        {
            if (Equals(item))
            {
                throw new InvalidOperationException();
            }

            var group = item as GroupNode;
            if (group == null)
            {
                throw new InvalidCastException();
            }

            var i = 0;
            for (; i < _nodes.Count; i++)
            {
                if (!(_nodes[i].Tag is IToolboxGroup))
                {
                    break;
                }
            }

            var node = ((GroupNode)item).Node;

            if (i < _nodes.Count)
            {
                _nodes.Insert(i, node);
            }
            else
            {
                _nodes.Add(node);
            }
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
        /// Returns a value indicating whether list of groups contain particular group.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>True on found</returns>
        public bool Contains(IToolboxGroup item)
        {
            if (item == null)
            {
                return false;
            }

            for (var i = 0; i < _nodes.Count; i++)
            {
                var group = _nodes[i].Tag as IToolboxGroup;
                if (group == item)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Collections.Generic.IEnumerator`1" /> that can be used to iterate through the collection.
        /// </returns>
        public IEnumerator<IToolboxGroup> GetEnumerator()
        {
            for (var i = 0; i < _nodes.Count; i++)
            {
                if (_nodes[i].Tag is IToolboxGroup)
                {
                    yield return _nodes[i].Tag as IToolboxGroup;
                }
            }
        }

        /// <summary>
        /// Removes the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>True on successfully removed</returns>
        public bool Remove(IToolboxGroup item)
        {
            foreach (var node in _nodes.Cast<TreeNode>().Where(node => node.Tag as IToolboxGroup == item))
            {
                _nodes.Remove(node);
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
            for (var i = _nodes.Count - 1; i >= 0; i--)
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

        #endregion

        #region Explicit Interface Methods

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

        #endregion
    }
}