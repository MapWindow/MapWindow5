using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Plugins.Concrete;
using MW5.Plugins.Interfaces;


namespace MW5.Mvp
{
    public abstract class CommandPresenter<TView, TCommand>
        where TCommand : struct, IConvertible
        where TView: IMenuProvider
    {
        protected TView View { get; private set; }

        public abstract void RunCommand(TCommand command);

        protected abstract void CommandNotFound(string itemName);

        protected CommandPresenter()
        {
            
        }

        protected CommandPresenter(TView view)
        {
            View = view;
            WireUpMenus(view);
        }

        protected void WireUpMenus(IMenuProvider view)
        {
            if (view.Toolbars != null)
            {
                foreach (var menu in view.Toolbars)
                {
                    InitMenu(menu.Items);
                }
            }
        }

        private bool CommandFromName(string itemName, ref TCommand command)
        {
            itemName = itemName.ToLower();
            
            var prefixes = new[] { "tool", "mnu", "ctx" };
            foreach (var prefix in prefixes)
            {
                if (itemName.StartsWith(prefix) && itemName.Length > prefix.Length)
                {
                    itemName = itemName.Substring(prefix.Length);
                }
            }

            var dict = Enum.GetValues(typeof(TCommand)).Cast<TCommand>()
                .ToDictionary(v => v.ToString(CultureInfo.InvariantCulture).ToLower(), v => v);

            if (dict.ContainsKey(itemName))
            {
                command = dict[itemName];
                return true;
            }

            Debug.Print("Command not found: " + itemName);

            CommandNotFound(itemName);
            return false;
        }

        /// <summary>
        /// Sets event handlers for menu items
        /// </summary>
        private void InitMenu(IMenuItemCollection items)
        {
            if (items == null)
            {
                return;
            }

            foreach (var item in items)
            {
                if (item.Tag != null && item.Tag.GetType() != typeof(PluginIdentity))
                {
                    continue;       // those items are handled by somebody else
                }

                item.Click += ItemClick;
                
                var dropDown = item as IDropDownMenuItem;
                if (dropDown != null)
                {
                    InitMenu(dropDown.SubItems);
                }
            }
        }

        /// <summary>
        /// Runs menu commands
        /// </summary>
        private void ItemClick(object sender, EventArgs e)
        {
            var item = sender as IMenuItem;
            if (item == null)
            {
                return;
            }

            var command = Activator.CreateInstance<TCommand>();
            if (CommandFromName(item.Name, ref command))
            {
                RunCommand(command);
            }
        }
    }
}
