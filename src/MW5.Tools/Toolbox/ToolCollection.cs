// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ToolCollection.cs" company="MapWindow OSS Team - www.mapwindow.org">
//   MapWindow OSS Team - 2015
// </copyright>
// <summary>
//   Provides access to the list of groups.
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
    ///     Provides access to the list of groups.
    /// </summary>
    internal class ToolCollection : IToolCollection
    {
        #region Fields

        private readonly TreeNodeAdvCollection _nodes;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ToolCollection"/> class.
        /// </summary>
        /// <param name="nodes">The nodes.</param>
        internal ToolCollection(TreeNodeAdvCollection nodes)
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
                return _nodes.Cast<TreeNode>().Count(node => (node.Tag is IGisTool));
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Adds new tool to the group
        /// </summary>
        /// <param name="item">The item.</param>
        public void Add(IGisTool item)
        {
            var tool = item as ToolNode;
            if (tool == null)
            {
                throw new InvalidCastException("A tool must be created by calling GisToolBox.CreateTool.");
            }

            _nodes.Add(tool.Node);
        }

        /// <summary>
        ///     Clears all the groups
        /// </summary>
        public void Clear()
        {
            for (var i = _nodes.Count - 1; i >= 0; i++)
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
        /// <param name="item">The item.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        public bool Contains(IGisTool item)
        {
            if (item == null)
            {
                return false;
            }

            for (var i = 0; i < _nodes.Count; i++)
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
        /// The get enumerator.
        /// </summary>
        /// <returns>The <see cref="IEnumerator"/>.</returns>
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
        /// <param name="item">The item.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        public bool Remove(IGisTool item)
        {
            foreach (var node in _nodes.Cast<TreeNode>().Where(node => node.Tag as IGisTool == item))
            {
                _nodes.Remove(node);
                return true;
            }

            return false;
        }

        /// <summary>
        /// The remove items for plugin.
        /// </summary>
        /// <param name="identity">The identity.</param>
        public void RemoveItemsForPlugin(PluginIdentity identity)
        {
            for (var i = _nodes.Count - 1; i >= 0; i--)
            {
                var tool = _nodes[i].Tag as IGisTool;
                if (tool != null && tool.PluginIdentity == identity)
                {
                    _nodes.RemoveAt(i);
                }
            }
        }

        #endregion

        #region Explicit Interface Methods

        /// <summary>
        /// The get enumerator.
        /// </summary>
        /// <returns>The <see cref="IEnumerator"/>.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion
    }
}