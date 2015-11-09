using System;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using MW5.Plugins.Concrete;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Services;

namespace MW5.Plugins.Mvp
{
    public abstract class CommandDispatcher<TCommand>
        where TCommand : struct, IConvertible
    {
        public abstract void RunCommand(TCommand command);

        protected virtual void CommandNotFound(string itemName)
        {
            MessageService.Current.Info("No handler was found for the item with the key: " + itemName);
        }

        protected void WireUpMenus(Control parent)
        {
            var provider = parent as IMenuProvider;
            if (provider != null)
            {
                AddHandlers(provider);
            }

            //foreach (Control item in parent.Controls)
            //{
            //    WireUpMenus(item);
            //}
        }

        protected void AddHandlers(IMenuProvider view)
        {
            foreach (var btn in view.Buttons)
            {
                btn.Click += ItemClick;
            }

            foreach (var items in view.ToolStrips)
            {
                InitMenu(items);
            }
        }

        /// <summary>
        /// Sets event handlers for menu items
        /// </summary>
        public void InitMenu(ToolStripItemCollection items)
        {
            if (items == null)
            {
                return;
            }

            foreach (ToolStripItem item in items)
            {
                if (item is ToolStripSeparator)
                {
                    continue;
                }

                var menuItem = item as ToolStripDropDownItem;
                bool hasChildren = menuItem != null && menuItem.DropDownItems.Count > 0;
                
                if (item.Tag == null && !hasChildren)
                {
                    item.Click += ItemClick;
                }
                
                if (menuItem != null)
                {
                    InitMenu(menuItem.DropDownItems);
                }
            }
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

                item.ItemClicked += ItemClick;
                
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

            CommandNotFound(itemName);
            return false;
        }

        /// <summary>
        /// Runs menu commands
        /// </summary>
        private void ItemClick(object sender, EventArgs e)
        {
            var btn = sender as Control;
            if (btn != null)
            {
                RunCommandCore(btn.Name);
                return;
            }
            
            var toolstripItem = sender as ToolStripItem;
            if (toolstripItem != null)
            {
                RunCommandCore(toolstripItem.Name);
                return;
            }

            var item = sender as IMenuItem;
            if (item != null)
            {
                RunCommandCore(item.Key);
                return;
            }
                        
            throw new InvalidOperationException("Unexpected type of menu item.");
        }

        private void RunCommandCore(string key)
        {
            var command = Activator.CreateInstance<TCommand>();
            if (CommandFromName(key, ref command))
            {
                RunCommand(command);
            }  
        }
    }
}
