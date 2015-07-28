// -------------------------------------------------------------------------------------------
// <copyright file="ToolboxDockPanel.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Drawing;
using System.Windows.Forms;
using MW5.Plugins.Concrete;
using MW5.Plugins.Events;
using MW5.Plugins.Interfaces;
using MW5.Tools.Model;
using MW5.Tools.Views;
using MW5.UI.Controls;
using Syncfusion.Windows.Forms.Tools;

namespace MW5.Tools.Toolbox
{
    /// <summary>
    /// Toolbox control
    /// </summary>
    public class ToolboxDockPanel : SplitContainerAdv, IToolbox
    {
        private readonly IAppContext _context;

        internal const int IconFolder = 0;
        internal const int IconTool = 1;

        private RichTextBox _textbox;
        private ToolboxTreeView _tree;

        /// <summary>
        /// Creates a new instance of GIS toolbox class.
        /// </summary>
        public ToolboxDockPanel(IAppContext context)
        {
            if (context == null) throw new ArgumentNullException("context");
            _context = context;

            Init();

            AddEventHandlers();

            _tree.ToolClicked += OnToolClicked;
        }

        private void OnToolClicked(object sender, ToolboxToolEventArgs e)
        {
            if (e.Tool == null) return;

            // we don't want the same instance of tool to be used by diffent tasks
            // therefore a new instance is created; it's expected that it must have default empty constructor
            var newTool = Activator.CreateInstance(e.Tool.GetType()) as IGisTool;

            var tool = newTool as GisToolBase;
            if (tool != null)
            {
                _context.Container.Run<GisToolPresenter, GisToolBase>(tool);
            }
            else
            {
                if (newTool != null)
                {
                    newTool.Initialize(_context);
                    newTool.Run(); // tool doesn't have UI or have an embedded  UI
                }
            }
        }

        /// <summary>
        /// Returns list of groups located at the top level of toolbox.
        /// </summary>
        public IToolboxGroups Groups
        {
            get { return new ToolboxGroupCollection(_tree.Nodes); }
        }

        /// <summary>
        /// Returns list of all tools in the toolbox
        /// </summary>
        public IToolCollection Tools
        {
            get { return new ToolboxToolCollection(_tree.Nodes); }
        }

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
            _tree.ToolSelected += OnToolSelected;
            _tree.GroupSelected += OnGroupSelected;
        }

        /// <summary>
        /// Recursively expands all the child groups up to the specified level.
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

        private void Init()
        {
            Orientation = Orientation.Vertical;
            BorderStyle = BorderStyle.None;

            InitTreeView();

            InitTextBox();

            SplitterDistance = Convert.ToInt32(Height * 0.9);
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

        private void InitTreeView()
        {
            _tree = new ToolboxTreeView();
            Panel1.Controls.Add(_tree);
            Panel1MinSize = 0;
        }

        private void OnGroupSelected(object sender, ToolboxGroupEventArgs e)
        {
            var group = e.Group;

            _textbox.Clear();
            _textbox.Text = group.Name + Environment.NewLine + Environment.NewLine + group.Description;
            _textbox.Select(0, group.Name.Length);
            _textbox.SelectionFont = new Font(Font, FontStyle.Bold);
        }

        private void OnToolSelected(object sender, ToolboxToolEventArgs e)
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
    }
}