using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Plugins.Events;
using MW5.Plugins.Interfaces;
using MW5.Tools.Enums;
using MW5.Tools.Properties;
using MW5.UI.Controls;
using Syncfusion.Windows.Forms.Tools;

namespace MW5.Tools.Toolbox
{
    public class ToolboxTreeView: TreeViewBase
    {
        public const int TreeViewNodeHeight = 16;

        public ToolboxTreeView()
        {
            BorderStyle = BorderStyle.None;
            Dock = DockStyle.Fill;

            AfterSelect += TreeAfterSelect;
            MouseDoubleClick += TreeMouseDoubleClick;
            PrepareToolTip += OnPrepareToolTip;
        }

        public event EventHandler<ToolboxToolEventArgs> ToolClicked;
        public event EventHandler<ToolboxToolEventArgs> ToolSelected;
        public event EventHandler<ToolboxGroupEventArgs> GroupSelected;

        protected override IEnumerable<Bitmap> OnCreateImageList()
        {
            // must match indices in ToolIcon enumeration
            yield return Resources.img_toolbox16;
            yield return Resources.img_tool;
            yield return Resources.img_geometry;
            yield return Resources.img_database16_2;
            yield return Resources.img_tool;
        }

        public ITool SelectedTool
        {
            get { return SelectedNode.Tag as ITool; }
        }

        private void OnPrepareToolTip(object sender, ToolTipEventArgs e)
        {
            e.Cancel = true; // don't show them

            //if (_tree.SelectedTool == null)
            //{
            //    e.Cancel = true;
            //}

            //var tool = _tree.SelectedTool;
            //if (tool != null)
            //{
            //    e.ToolTip.Header.Text = tool.Name;
            //    e.ToolTip.Body.Text = tool.Description;
            //}
        }

        /// <summary>
        /// Fires events, sets the same icons for selected mode as for regular mode
        /// </summary>
        private void TreeAfterSelect(object sender, EventArgs e)
        {
            if (SelectedNode == null)
            {
                return;
            }

            var tool = SelectedNode.Tag as ITool;
            if (tool != null)
            {
                FireToolSelected(tool);
            }

            if (IsGroup(SelectedNode))
            {
                var group = new ToolboxGroup(SelectedNode);
                FireGroupSelected(group);
            }
        }

        /// <summary>
        /// Generates tool clicked event for plug-ins
        /// </summary>
        private void TreeMouseDoubleClick(object sender, MouseEventArgs e)
        {
            var node = SelectedNode;
            if (node == null || IsGroup(node))
            {
                return;
            }

            var tool = node.Tag as ITool;
            if (tool != null)
            {
                FireToolClicked(tool);
            }
        }

        private bool IsGroup(TreeNodeAdv node)
        {
            return node.Tag is ToolboxGroupMetadata;
        }

        private void FireToolClicked(ITool tool)
        {
            FireEvent(ToolClicked, new ToolboxToolEventArgs(tool));
        }

        private void FireToolSelected(ITool tool)
        {
            FireEvent(ToolSelected, new ToolboxToolEventArgs(tool));
        }

        private void FireGroupSelected(IToolboxGroup group)
        {
            FireEvent(GroupSelected, new ToolboxGroupEventArgs(group));
        }

        private void FireEvent<T>(EventHandler<T> handler, T args)
        {
            if (handler != null)
            {
                handler(this, args);
            }
        }
    }
}
