using System.Collections.Generic;
using MW5.Plugins.Concrete;
using MW5.Plugins.Identifier.Properties;

namespace MW5.Plugins.Identifier.Menu
{
    public class MenuCommands : CommandProviderBase
    {
        public MenuCommands(PluginIdentity identity) : base(identity)
        {
        }

        public override IEnumerable<MenuCommand> GetCommands()
        {
            return new List<MenuCommand>()
            {
                new MenuCommand("Identify shapes", MenuKeys.IdentifyTool, Resources.icon_identify)
            };
        }
    }
}
