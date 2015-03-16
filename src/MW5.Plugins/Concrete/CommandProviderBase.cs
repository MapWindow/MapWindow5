using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Interfaces;

namespace MW5.Plugins.Concrete
{
    /// <summary>
    /// Stores a list of menu commands, that can be added both to toolbars and main menu.
    /// </summary>
    public abstract class CommandProviderBase
    {
        protected Dictionary<string, MenuCommand> _commands = new Dictionary<string, MenuCommand>();

        protected CommandProviderBase(PluginIdentity identity)
        {
            if (identity == null) throw new ArgumentNullException("identity");

            var list = GetCommands();
            foreach (var cmd in list)
            {
                cmd.PluginIdentity = identity;
                _commands.Add(cmd.Key, cmd);
            }
        }

        /// <summary>
        /// Defines the list of menu commands, populate a List with commands that your plugin is using.
        /// </summary>
        public abstract IEnumerable<MenuCommand> GetCommands();

        protected MenuCommand Get(string key)
        {
            return _commands[key];      // don't catch it, if there is a mistake we want to know at once
        }

        /// <summary>
        /// Adds to menu.
        /// </summary>
        /// <param name="items">Collection of items. Can be accessed either through IToolbar.Items or IDropDownMenuItem.Items.</param>
        /// <param name="key">The key of commands (MenuKey.CommandName).</param>
        /// <param name="beginGroup">True in case the item must be preceded by separator.</param>
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
