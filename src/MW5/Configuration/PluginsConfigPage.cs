using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MW5.Configuration.Plugins;
using MW5.Plugins.Enums;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Services;
using MW5.Properties;
using MW5.Services.Config;
using MW5.Shared;
using MW5.UI.Controls;
using MW5.UI.Helpers;
using Syncfusion.Grouping;
using Syncfusion.Windows.Forms.Grid;
using Syncfusion.Windows.Forms.Grid.Grouping;

namespace MW5.Configuration
{
    internal partial class PluginsConfigPage : ConfigPageBase, IConfigPage
    {
        private readonly IPluginManager _manager;
        private readonly IAppContext _context;
        private PluginProvider _pluginProvider;
        private bool _ignoreEvents;

        public PluginsConfigPage(IPluginManager manager, IAppContext context)
        {
            if (manager == null) throw new ArgumentNullException("manager");
            if (context == null) throw new ArgumentNullException("context");
            _manager = manager;
            _context = context;

            InitializeComponent();

            chkSelectAll.CheckedChanged += OnSelectAllCheckedChanged;

            pluginGrid1.Adapter.SelectionChanged += OnPluginSelectionChanged;

            KeyDown += OnPluginsConfigPageKeyDown;

            richTextBox1.InitDockPanelFooter();
            splitContainerAdv1.InitDockPanel(0.8);

            Initialize();
        }

        private void OnPluginSelectionChanged(object sender, EventArgs e)
        {
            var plugin = pluginGrid1.Adapter.SelectedItem;
            if (plugin != null)
            {
                string msg = string.Format("{0}{2}{2}{1}", plugin.Name, plugin.BasePlugin.Description, Environment.NewLine);
                richTextBox1.SetDescription(msg);
            }
        }

        public void Initialize()
        {
            _pluginProvider = new PluginProvider(_manager);
            pluginGrid1.DataSource = _pluginProvider.OrderBy(p => p.Name).ToList();
            pluginGrid1.Adapter.SelectFirstRecord();

            _ignoreEvents = true;
            chkSelectAll.Checked = _pluginProvider.Any(p => !p.Selected);
            _ignoreEvents = false;
        }

        private void OnPluginsConfigPageKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                pluginGrid1.Adapter.ToggleProperty(info => info.Selected);
            }
        }

        public string PageName
        {
            get { return "Plugins"; }
        }

        public void Save()
        {
            var list = _pluginProvider.Where(p => p.Selected).Select(p => p.BasePlugin.Identity.Guid);
            var dict = new HashSet<Guid>(list);
            _manager.RestoreApplicationPlugins(dict, _context);
        }

        public Bitmap Icon
        {
            get { return Resources.img_plugin32; }
        }

        public ConfigPageType PageType
        {
            get { return ConfigPageType.Plugins; }
        }

        public string Description
        {
            get { return "Plugins checked in this list will become a permanent part of application " +
                         "and will not be listed in the plugins menu for unloading."; }
        }

        public bool VariableHeight
        {
            get { return true; }
        }

        private void OnSelectAllCheckedChanged(object sender, EventArgs e)
        {
            if (_ignoreEvents) return;

            pluginGrid1.Adapter.SetPropertyForEach(item => item.Selected, chkSelectAll.Checked);
        }
    }
}
