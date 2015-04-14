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
        public TView View { get; private set; }

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

            foreach (var items in view.Toolstrips)
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
                if (item.Tag == null)
                {
                    item.Click += ItemClick;
                }

                var menuItem = item as ToolStripDropDownItem;
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
