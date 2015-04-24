using System;
using System.Drawing;
using System.Windows.Forms;
using MW5.Plugins.Concrete;
using MW5.Plugins.Events;
using MW5.Plugins.Interfaces;
using MW5.Tools.Properties;
using MW5.UI.Controls;
using Syncfusion.Windows.Forms.Tools;

namespace MW5.Tools.Toolbox
{
    /// <summary>
    /// Toolbox control
    /// </summary>
    public class ToolboxControl : SplitContainerAdv, IToolbox 
    {
        // icon indices
        internal const int IconFolder = 0;
        internal const int IconTool = 1;

        private ToolboxTreeView _tree;
        private RichTextBox _textbox;

        public event EventHandler<ToolboxToolEventArgs> ToolClicked;
        public event EventHandler<ToolboxToolEventArgs> ToolSelected;
        public event EventHandler<ToolboxGroupEventArgs> GroupSelected;

        #region Initialization

        /// <summary>
        /// Creates a new instance of GIS toolbox class.
        /// </summary>
        public ToolboxControl()
        {
            Init();

            AddEventHandlers();
        }

        private void Init()
        {
            Orientation = Orientation.Vertical;
            BorderStyle = BorderStyle.None;

            InitTreeView();

            InitTextBox();

            SplitterDistance = Convert.ToInt32(Height * 0.9);
        }

        private void InitTreeView()
        {
            _tree = new ToolboxTreeView
            {
                BorderStyle = BorderStyle.None,
                Dock = DockStyle.Fill
            };


            _tree.PrepareToolTip += PrepareToolTip;

            Panel1.Controls.Add(_tree);
            Panel1MinSize = 0;
        }

        private void PrepareToolTip(object sender, ToolTipEventArgs e)
        {
            e.Cancel = true;        // don't show them
            return;

            if (_tree.SelectedTool == null)
            {
                e.Cancel = true;
            }

            var tool = _tree.SelectedTool;
            if (tool != null)
            {
                e.ToolTip.Header.Text = tool.Name;
                e.ToolTip.Body.Text = tool.Description;
            }
        }

        private void InitTextBox()
        {
            _textbox = new RichTextBox
            {
                BorderStyle = BorderStyle.None,
                Dock = DockStyle.Fill,
                ScrollBars = RichTextBoxScrollBars.None,
                BackColor = Color.FromKnownColor(KnownColor.Control),
                ReadOnly = true,
                Text = "No tool is selected."
            };

            Panel2.Controls.Add(_textbox);
            Panel2MinSize = 0;
        }

        private void AddEventHandlers()
        {
            _tree.AfterSelect += TreeAfterSelect;
            _tree.MouseDoubleClick += TreeMouseDoubleClick;
            ToolSelected += GisToolbox_ToolSelected;
            GroupSelected += GisToolbox_GroupSelected;
        }


        #endregion

        #region IGisToolBox Members

        /// <summary>
        /// Returns list of groups located at the top level of toolbox.
        /// </summary>
        public IToolboxGroups Groups
        {
            get 
            {
                return new GroupCollection(_tree.Nodes);
            }
        }

        /// <summary>
        /// Returns list of all tools in the toolbox
        /// </summary>
        public IToolCollection Tools
        {
            get { return new ToolCollection(_tree.Nodes); }
        }
        
        /// <summary>
        /// Creates a new tool.
        /// </summary>
        public IGisTool CreateTool(string name, string key, PluginIdentity identity)
        {
            var tool = new ToolNode(name, key, identity);
            return tool;
        }

        /// <summary>
        /// Creates a new group.
        /// </summary>
        public IToolboxGroup CreateGroup(string name, string description, PluginIdentity identity)
        {
            return new GroupNode(name, description, identity);
        }

        /// <summary>
        /// Expands all the groups up to the specified level
        /// </summary>
        public void ExpandGroups(int level)
        {
            ExpandGroups(Groups, level);
        }

        /// <summary>
        /// Removes groups and tools added by specified plugin
        /// </summary>
        public void RemoveItemsForPlugin(PluginIdentity identity)
        {
            Tools.RemoveItemsForPlugin(identity);
            Groups.RemoveItemsForPlugin(identity);
        }

        /// <summary>
        /// Recursively expans all the child groups up to the specified level
        /// </summary>
        private void ExpandGroups(IToolboxGroups groups, int level)
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

        #endregion
        
        #region Events

        /// <summary>
        /// Fires events, sets the same icons for selected mode as for regular mode
        /// </summary>
        void TreeAfterSelect(object sender, EventArgs e)
        {
            if (_tree.SelectedNode == null)
            {
                return;
            }

            var tool = _tree.SelectedNode.Tag as IGisTool;
            if (tool != null)
            {
                FireToolSelected(tool);
            }

            var group = _tree.SelectedNode.Tag as IToolboxGroup;
            if (group != null)
            {
                FireGroupSelected(group);
            }
        }

        /// <summary>
        /// Generates tool clicked event for plug-ins
        /// </summary>
        private void TreeMouseDoubleClick(object sender, MouseEventArgs e)
        {
            var node = _tree.SelectedNode;
            if (node == null || node.Tag is IToolboxGroup)
            {
                return;
            }

            var tool = node.Tag as IGisTool;
            if (tool != null)
            {
                FireToolClicked(tool);
            }
        }

        private void GisToolbox_GroupSelected(object sender, ToolboxGroupEventArgs e)
        {
            var group = e.Group;

            _textbox.Clear();
            _textbox.Text = group.Name + Environment.NewLine + Environment.NewLine + group.Description;
            _textbox.Select(0, group.Name.Length);
            _textbox.SelectionFont = new Font(Font, FontStyle.Bold);
        }

        private void GisToolbox_ToolSelected(object sender, ToolboxToolEventArgs e)
        {
            var tool = e.Tool;
            _textbox.Clear();
            _textbox.Text = tool.Name + Environment.NewLine + Environment.NewLine + tool.Description;

            if (tool.Name.Length > 0)
            {
                _textbox.Select(0, tool.Name.Length);
                _textbox.SelectionFont = new Font(Font, FontStyle.Bold);
            }
        }

        private void FireToolClicked(IGisTool tool)
        {
            FireEvent(ToolClicked, new ToolboxToolEventArgs(tool));
        }

        private void FireToolSelected(IGisTool tool)
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

        #endregion
    }
}