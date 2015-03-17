using System;
using MW5.Plugins.Concrete;
using MW5.Plugins.IdentifierTestPlugin.Menu;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Services;

namespace MW5.Plugins.IdentifierTestPlugin.Listeners
{
    public class MenuListener
    {
        private IAppContext _context;
        private readonly IMessageService _messageService;

        public MenuListener(IAppContext context, IdentifierTestPlugin plugin, IMessageService messageService)
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
                case MenuKeys.IdentifyTool:
                    _messageService.Info("Hello from Template plugin");
                    break;
            }
        }
    }
}
