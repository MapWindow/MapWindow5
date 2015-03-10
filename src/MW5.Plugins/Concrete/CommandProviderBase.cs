using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Interfaces;

namespace MW5.Plugins.Concrete
{
    public abstract class CommandProviderBase
    {
        private readonly PluginIdentity _identity;
        protected Dictionary<string, MenuCommand> _commands = new Dictionary<string, MenuCommand>();

        protected CommandProviderBase(PluginIdentity identity)
        {
            if (identity == null) throw new ArgumentNullException("identity");
            _identity = identity;

            var list = GetCommands();
            foreach (var cmd in list)
            {
                cmd.PluginIdentity = identity;
                _commands.Add(cmd.Key, cmd);
            }
        }

        public abstract List<MenuCommand> GetCommands();

        public MenuCommand Get(string key)
        {
            return _commands[key];      // don't catch it, if there is a mistake we want to know at once
        }

        public void AddToMenu(IMenuItemCollection items, string key, bool beginGroup = false)
        {
            var btn = items.AddButton(Get(key));
            if (beginGroup)
            {
                btn.BeginGroup = true;
            }
        }
    }
}
