using System.Collections.Generic;
using MW5.Plugins.Concrete;
using MW5.Plugins.TemplatePlugin.Properties;

namespace MW5.Plugins.TemplatePlugin.Menu
{
    public class MenuCommands : CommandProviderBase
    {
        public MenuCommands(PluginIdentity identity) : base(identity)
        {
        }

        public override List<MenuCommand> GetCommands()
        {
            return new List<MenuCommand>()
            {
                new MenuCommand("Show dialog", MenuKeys.ShowPluginDialog, Resources.monitor)
            };
        }
    }
}
