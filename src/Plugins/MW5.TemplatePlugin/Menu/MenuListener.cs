using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Concrete;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Services;

namespace MW5.Plugins.TemplatePlugin.Menu
{
    public class MenuListener
    {
        private IAppContext _context;
        private readonly IMessageService _messageService;

        public MenuListener(IAppContext context, TemplatePlugin plugin, IMessageService messageService)
        {
            if (context == null) throw new ArgumentNullException("context");
            if (messageService == null) throw new ArgumentNullException("messageService");

            _context = context;
            _messageService = messageService;

            plugin.ItemClicked += Plugin_ItemClicked;
        }

        private void Plugin_ItemClicked(object sender, MenuItemEventArgs e)
        {
            switch (e.ItemKey)
            {
                case MenuKeys.ShowPluginDialog:
                    _messageService.Info("Hello from Template plugin");
                    break;
            }
        }
    }
}
