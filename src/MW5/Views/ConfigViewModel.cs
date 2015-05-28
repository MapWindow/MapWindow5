using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Configuration;
using MW5.Plugins.Enums;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Services;
using MW5.Services.Config;

namespace MW5.Views
{
    public class ConfigViewModel
    {
        private readonly IAppContext _context;
        private readonly IPluginManager _pluginManager;
        private readonly IConfigService _configeService;
        private readonly List<IConfigPage> _pages = new List<IConfigPage>();

        public ConfigViewModel(IAppContext context, IPluginManager pluginManager, IConfigService configeService)
        {
            _context = context;
            _pluginManager = pluginManager;
            _configeService = configeService;

            Initialize();
        }

        private void Initialize()
        {
            _pages.Clear();
            _pages.Add(new GeneralConfigPage(_configeService));
            _pages.Add(new MapConfigPage(_configeService));
            _pages.Add(new WidgetsConfigPage(_configeService));
            _pages.Add(new LayerConfigPage(_configeService));
            _pages.Add(new PluginsConfigPage(_pluginManager, _context));
        }

        public IEnumerable<IConfigPage> Pages
        {
            get { return _pages; }
        }

        public IConfigPage GetPage(ConfigPageType pageType)
        {
            return _pages.FirstOrDefault(p => p.PageTypeType == pageType);
        }
    }
}
