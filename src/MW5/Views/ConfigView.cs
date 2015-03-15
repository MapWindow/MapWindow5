using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Abstract;
using MW5.Plugins;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Services;
using MW5.Services.Config;
using MW5.UI;

namespace MW5.Views
{
    public partial class ConfigView : MapWindowForm, IConfigView
    {
        public ConfigView()
        {
            InitializeComponent();
        }

        public ConfigView(IAppContext context, PluginManager manager, IConfigService config): base(context)
        {
            InitializeComponent();

            var page = new PluginsConfigPage(manager, config);
            page.Dock = DockStyle.Fill;
            panel1.Controls.Add(page);

        }

        public void UpdateView()
        {
            
        }
    }
}
