using System;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using MW5.Plugins.Concrete;
using MW5.Plugins.Interfaces;

namespace MW5.Plugins.Mvp
{
    public abstract class CommandDispatcher<TView, TCommand>
        where TCommand : struct, IConvertible
        where TView: IMenuProvider
    {
        protected TView View { get; private set; }

        public abstract void RunCommand(TCommand command);

        protected abstract void CommandNotFound(string itemName);

        protected CommandDispatcher()
        {
            
        }

        protected CommandDispatcher(TView view)
        {
            View = view;
            WireUpMenus(view);
        }

        protected void WireUpMenus(IMenuProvider view)
        {
            foreach (var btn in view.Buttons)
            {
                btn.Click += ItemClick;
            }

            foreach (var item in view.ToolStrips)
            {
                item.Click += ItemClick;
            }

            //if (view.Toolbars != null)
            //{
            //    foreach (var menu in view.Toolbars)
            //    {
            //        InitMenu(menu.Items);
            //    }
            //}
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
                if (item.Tag != null)
                {
                    if (item.Tag.GetType() != typeof (PluginIdentity))
                    {
                        continue; // those items are handled by somebody else
                    }
                }

                item.AttachClickEventHandler(ItemClick);
                
                var dropDown = item as IDropDownMenuItem;
                if (dropDown != null)
                {
                    InitMenu(dropDown.SubItems);
                }
            }
        }

        private bool CommandFromName(string itemName, ref TCommand command)
        {
            itemName = itemName.ToLower();

            var prefixes = new[] { "tool", "mnu", "ctx", "btn" };
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
        /// Runs menu commands
        /// </summary>
        private void ItemClick(object sender, EventArgs e)
        {
            string key = string.Empty;
            var item = sender as IMenuItem;
            if (item != null)
            {
                key = item.Key;
            }
            else
            {
                var btn = sender as Control;
                if (btn != null)
                {
                    key = btn.Name;
                }
            }

            if (key == string.Empty)
            {
                throw new InvalidOperationException("Unexpected type of menu item.");
            }

            var command = Activator.CreateInstance<TCommand>();
            if (CommandFromName(key, ref command))
            {
                RunCommand(command);
            }  

        }
    }
}
