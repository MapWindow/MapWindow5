using System;
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
    internal partial class PluginsConfigPage : PluginGrid, IConfigPage
    {
        private readonly IPluginManager _manager;
        private readonly IAppContext _context;
        private PluginProvider _pluginProvider;

        public PluginsConfigPage(IPluginManager manager, IAppContext context)
        {
            if (manager == null) throw new ArgumentNullException("manager");
            if (context == null) throw new ArgumentNullException("context");
            _manager = manager;
            _context = context;

            InitializeComponent();

            Initialize();

            KeyDown += PluginsConfigPage_KeyDown;

            Adapter.PrepareToolTip += ListControlPrepareToolTip;
        }

        public void Initialize()
        {
            _pluginProvider = new PluginProvider(_manager);
            DataSource = _pluginProvider.List;
        }

        private void PluginsConfigPage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                Adapter.ToggleProperty(info => info.Selected);
            }
        }

        private void ListControlPrepareToolTip(object sender, UI.Controls.ToolTipGridEventArgs e)
        {
            var info = Adapter[e.RecordIndex];
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
            var dict = _pluginProvider.List.Where(p => p.Selected).ToDictionary(p => p.BasePlugin.Identity.Guid, p => p);
            foreach (var plugin in _manager.AllPlugins)
            {
                bool appPlugin = dict.ContainsKey(plugin.Identity.Guid);
                plugin.SetApplicationPlugin(appPlugin);

                if (appPlugin && !_manager.PluginActive(plugin.Identity))
                {
                    _manager.LoadPlugin(plugin.Identity, _context);
                }
            }
        }

        public Bitmap Icon
        {
            get { return Resources.img_plugin32; }
        }

        public bool PluginPage
        {
            get { return false; }
        }

        public ConfigPageType PageTypeType
        {
            get { return ConfigPageType.Plugins; }
        }

        public string Description
        {
            get { return "Plugins checked in this list will become a permanent part of application, i.e." +
                         "will be loaded in this list and won't listed in the plugins menu for unloading."; }
        }
    }
}
