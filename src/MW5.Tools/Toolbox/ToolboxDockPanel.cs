// -------------------------------------------------------------------------------------------
// <copyright file="ToolboxDockPanel.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015-2019
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MW5.Plugins.Concrete;
using MW5.Plugins.Events;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mvp;
using MW5.Shared;
using MW5.Tools.Model;
using MW5.UI.Controls;
using MW5.UI.Helpers;
using Syncfusion.Windows.Forms.Tools;

namespace MW5.Tools.Toolbox
{
    /// <summary>
    /// Toolbox control
    /// </summary>
    public partial class ToolboxDockPanel : DockPanelControlBase, IToolbox, IMenuProvider
    {
        /// <summary>
        /// Creates a new instance of GIS toolbox class.
        /// </summary>
        public ToolboxDockPanel()
        {
            InitializeComponent();

            Init();

            AddEventHandlers();

            contextMenuStripEx1.Opening += OnContextMenuOpening;

            _treeView.ToolClicked += (s, e) => FireToolClicked(e.Tool);
        }

        public event KeyEventHandler ToolboxKeyDown
        {
            add => _treeView.KeyDown += value;
            remove => _treeView.KeyDown -= value;
        }

        private void OnContextMenuOpening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var tool = _treeView.SelectedTool;
            mnuBatchRun.Enabled = tool != null && tool.SupportsBatchExecution;
        }

        public override void SetFocus()
        {
            txtSearch.Focus();
        }

        public ITool SelectedTool => _treeView.SelectedTool;

        public event EventHandler<ToolboxToolEventArgs> ToolClicked;

        /// <summary>
        /// Returns list of groups located at the top level of toolbox.
        /// </summary>
        public IToolboxGroups Groups => new ToolboxGroupCollection(_treeView.Nodes);

        /// <summary>
        /// Returns list of all tools in the toolbox
        /// </summary>
        public IToolCollection Tools => new ToolboxToolCollection(_treeView.Nodes);

        /// <summary>
        /// Expands all the groups up to the specified level.
        /// </summary>
        public void ExpandGroups(int level)
        {
            ExpandGroups(Groups, level);
        }

        /// <summary>
        /// Removes groups and tools added by specified plugin.
        /// </summary>
        public void RemoveItemsForPlugin(PluginIdentity identity)
        {
            Tools.RemoveItemsForPlugin(identity);
            Groups.RemoveItemsForPlugin(identity);
        }

        private void AddEventHandlers()
        {
            _treeView.ToolSelected += OnToolSelected;
            _treeView.GroupSelected += OnGroupSelected;
        }

        /// <summary>
        /// Recursively expands all the child groups up to the specified level.
        /// </summary>
        private static void ExpandGroups(IToolboxGroups groups, int level)
        {
            foreach (var group in groups)
            {
                group.Expanded = true;
                level--;

                if (level > 0)
                {
                    ExpandGroups(group.SubGroups, level);
                }
            }
        }

        private void Init()
        {
            splitContainerAdv1.InitDockPanel(0.9);

            _textbox.InitDockPanelFooter();
            _textbox.Text = @"No tool is selected.";
        }

        private void OnGroupSelected(object sender, ToolboxGroupEventArgs e)
        {
            _textbox.SetDescription(e.Group.Name + Environment.NewLine + Environment.NewLine + e.Group.Description);
            UpdateToolbar();
        }

        private void OnToolSelected(object sender, ToolboxToolEventArgs e)
        {
            _textbox.SetDescription(e.Tool.Name + Environment.NewLine + Environment.NewLine + e.Tool.Description);
            UpdateToolbar();
        }

        private void UpdateToolbar()
        {
            var tool = SelectedTool;
            toolRun.Enabled = tool != null;
            toolBatchRun.Enabled = tool != null && tool.SupportsBatchExecution;
        }

        public void AddTools(IEnumerable<ITool> tools)
        {
            var groups = Groups;

            foreach (var tool in tools.OrderBy(t => t.Name))
            {
                if (!AttributeHelper.HasAttribute<GisToolAttribute>(tool.GetType()))
                {
                    continue;
                }

                var attributes = AttributeHelper.GetAttribute<GisToolAttribute>(tool.GetType());
                var groupKey = attributes.GroupKey;

                if (string.IsNullOrWhiteSpace(groupKey))
                {
                    Logger.Current.Warn("No toolbox group is specified for the tool: " + tool.Name);
                    continue;
                }

                if (string.IsNullOrEmpty(attributes.ParentGroupKey))
                {
                    var group = groups.FindGroup(groupKey); // can be optimized with dictionary to speed it up
                    // ReSharper disable once ConvertIfStatementToNullCoalescingExpression
                    if (group == null)
                    {
                        // Create group:
                        group = groups.Add(attributes.GroupName, groupKey, tool.PluginIdentity);
                    }
                    group.Description = attributes.GroupDescription;
                    group.Name = attributes.GroupName;

                    if (!attributes.OnlyGroup) group.Tools.Add(tool);
                }
                else
                {
                    // Get parent group    
                    var parentGroup = groups.FindGroup(attributes.ParentGroupKey); // Copied from above
                    // ReSharper disable once ConvertIfStatementToNullCoalescingExpression
                    if (parentGroup == null)
                    {
                        // Create group:
                        parentGroup = groups.Add(attributes.ParentGroupKey, attributes.ParentGroupKey,
                            tool.PluginIdentity);
                    }

                    var subGroup = parentGroup.SubGroups.FindGroup(groupKey);
                    if (subGroup == null)
                    {
                        // Add group as subgroup:
                        subGroup = parentGroup.SubGroups.Add(attributes.GroupName, groupKey, tool.PluginIdentity);
                        subGroup.Description = attributes.GroupDescription;
                    }

                    if (!attributes.OnlyGroup) subGroup.Tools.Add(tool);
                }
            }

            _treeView.Nodes.Sort();
            SelectGroup(Groups.FirstOrDefault());
        }

        private void SelectGroup(IToolboxGroup group)
        {
            if (group != null)
            {
                _treeView.SelectedNode = group.InnerObject as TreeNodeAdv;
            }
        }

        /// <summary>
        /// Opens dialog to set parameters and run the specified tool.
        /// </summary>
        public void OpenToolDialog(ITool tool, bool batchMode)
        {
            FireToolClicked(tool);
        }

        public void SelectGroup(string groupKey)
        {
            SelectGroupCore(Groups, groupKey);
        }

        private void SelectGroupCore(IToolboxGroups groups, string groupKey)
        {
            foreach (var g in groups)
            {
                if (g.Key == groupKey)
                {
                    _treeView.SelectedNode = g.InnerObject as TreeNodeAdv;
                    break;
                }

                SelectGroupCore(g.SubGroups, groupKey);
            }
        }

        private void FireToolClicked(ITool tool)
        {
            var handler = ToolClicked;
            handler?.Invoke(tool, new ToolboxToolEventArgs(tool));
        }

        public IEnumerable<ToolStripItemCollection> ToolStrips
        {
            get
            {
                yield return contextMenuStripEx1.Items;
                yield return toolStripEx1.Items;
            }
        }

        public IEnumerable<Control> Buttons
        {
            get { yield break; }
        }

        private void OnSearchTextChanged(object sender, EventArgs e)
        {
            Filter(txtSearch.Text);
        }

        private void OnSearchKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Filter(txtSearch.Text);
            }
        }

        public void Filter(string token)
        {
            try
            {
                _treeView.BeginUpdate();
                Filter(Groups, token);
            }
            finally
            {
                _treeView.EndUpdate();
                _treeView.Invalidate();
            }
        }

        private static bool Filter(IEnumerable<IToolboxGroup> groups, string token)
        {
            var parentVisible = false;

            foreach (var g in groups)
            {
                var result = Filter(g.SubGroups, token);

                foreach (var item in g.Tools)
                {
                    var visible = true;
                    if (!string.IsNullOrEmpty(token))
                        visible = item.Tool.Name.ContainsIgnoreCase(token);

                    item.Visible = visible;
                    if (item.Visible)
                    {
                        result = true;
                    }
                }

                if (g.InnerObject is TreeNodeAdv node)
                {
                    node.Height = result ? ToolboxTreeView.TreeViewNodeHeight : 0;
                    node.IsSelectable = result;
                    node.Expanded = result;
                    // https://mapwindow.atlassian.net/browse/MW5CORE-247
                    if (result)
                    {
                        node.BringIntoView();
                    }
                }

                if (result)
                {
                    parentVisible = true;
                }
            }

            return parentVisible;
        }
    }
}