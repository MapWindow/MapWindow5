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
using Syncfusion.Grouping;
using Syncfusion.Windows.Forms.Grid;
using Syncfusion.Windows.Forms.Grid.Grouping;

namespace MW5.Configuration
{
    internal partial class PluginsConfigPage : UserControl, IConfigPage
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

            chkSelectAll.CheckedChanged += chkSelectAll_CheckedChanged;

            Initialize();

            KeyDown += PluginsConfigPage_KeyDown;

            pluginGrid1.Adapter.PrepareToolTip += ListControlPrepareToolTip;
        }

        public void Initialize()
        {
            _pluginProvider = new PluginProvider(_manager);
            pluginGrid1.DataSource = _pluginProvider.ToList();

            _ignoreEvents = true;
            chkSelectAll.Checked = _pluginProvider.Any(p => !p.Selected);
            _ignoreEvents = false;
        }

        private void PluginsConfigPage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                pluginGrid1.Adapter.ToggleProperty(info => info.Selected);
            }
        }

        private void ListControlPrepareToolTip(object sender, UI.Controls.ToolTipGridEventArgs e)
        {
            var info = pluginGrid1.Adapter[e.RecordIndex];
            if (info != null)
            {
                e.ToolTip.Header.Text = info.Name;
                e.ToolTip.Body.Text = info.BasePlugin.Description;
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

        public bool PluginPage
        {
            get { return false; }
        }

        public ConfigPageType PageType
        {
            get { return ConfigPageType.Plugins; }
        }

        public string Description
        {
            get { return "Plugins checked in this list will become a permanent part of application, i.e." +
                         "will be loaded in this list and won't listed in the plugins menu for unloading."; }
        }

        public bool VariableHeight
        {
            get { return true; }
        }

        private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (_ignoreEvents) return;

            pluginGrid1.Adapter.SetPropertyForEach(item => item.Selected, chkSelectAll.Checked);
        }
    }
}
