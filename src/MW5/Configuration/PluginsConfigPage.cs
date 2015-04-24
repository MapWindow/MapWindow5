using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MW5.Configuration.Plugins;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Services;
using MW5.Services.Config;
using Syncfusion.Grouping;
using Syncfusion.Windows.Forms.Grid;
using Syncfusion.Windows.Forms.Grid.Grouping;

namespace MW5.Configuration
{
    internal partial class PluginsConfigPage : PluginInfoGrid, IConfigPage
    {
        private readonly PluginProvider _pluginProvider;
        private readonly IPluginManager _manager;
        private readonly IAppContext _context;

        public PluginsConfigPage(IPluginManager manager, IAppContext context)
        {
            if (manager == null) throw new ArgumentNullException("manager");
            if (context == null) throw new ArgumentNullException("context");
            _manager = manager;
            _context = context;

            InitializeComponent();

            _pluginProvider = new PluginProvider(manager);
            
            DataSource = _pluginProvider.List;
            KeyDown += PluginsConfigPage_KeyDown;

            PrepareToolTip += ListControlPrepareToolTip;
        }

        private void PluginsConfigPage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                ToggleProperty(info => info.Selected);
            }
        }

        private void ListControlPrepareToolTip(object sender, UI.Controls.ToolTipGridEventArgs e)
        {
            var info = this[e.RecordIndex];
            if (info != null)
            {
                e.ToolTip.Header.Text = info.Name;
                e.ToolTip.Body.Text = info.BasePlugin.Description;
            }
        }

        public string PageName
        {
            get { return "Application Plugins"; }
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
    }
}
