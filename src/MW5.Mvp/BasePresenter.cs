using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MW5.Mvp
{
    public abstract class BasePresenter<TView, TCommand, TModel> : IPresenter<TModel>
        where TCommand : struct, IConvertible
        where TView: IView<TModel>
        where TModel: class 
        
    {
        protected TView View { get; private set; }
        protected TModel Model { get; private set; }

        protected BasePresenter(TView view)
        {
            View = view;

            if (view.Menus != null)
            {
                foreach (var menu in view.Menus)
                {
                    InitMenu(menu);
                }
            }
        }

        public void Run(TModel model)
        {
            Model = model;
            
            View.ShowView();
        }

        public void UpdateView()
        {
            View.UpdateView(Model);
        }

        public abstract void RunCommand(TCommand command);
        protected abstract void CommandNotFound(ToolStripItem item);

        public bool CommandFromName(ToolStripItem item, ref TCommand command)
        {
            string itemName = item.Name;
            itemName = itemName.ToLower();
            var prefixes = new[] { "tool", "mnu", "ctx" };
            foreach (var prefix in prefixes)
            {
                if (itemName.StartsWith(prefix) && itemName.Length > prefix.Length)
                    itemName = itemName.Substring(prefix.Length);
            }

            var dict = Enum.GetValues(typeof(TCommand)).Cast<TCommand>().ToDictionary(v => v.ToString(CultureInfo.InvariantCulture).ToLower(), v => v);
            if (dict.ContainsKey(itemName))
            {
                command = dict[itemName];
                return true;
            }

            Debug.Print("Command not found: " + itemName);

            var menu = item as ToolStripDropDownItem;
            if (menu != null && menu.DropDownItems.Count > 0)
                return false;

            if (item is ToolStripSeparator) return false;

            CommandNotFound(item);
            return false;
        }

        /// <summary>
        /// Sets event handlers for menu items
        /// </summary>
        public void InitMenu(ToolStripItemCollection items)
        {
            if (items == null)
                return;

            foreach (ToolStripItem item in items)
            {
                if (item.Tag == null)
                    item.Click += ItemClick;
                var menuItem = item as ToolStripDropDownItem;
                if (menuItem != null)
                {
                    InitMenu(menuItem.DropDownItems);
                }
            }
        }

        /// <summary>
        /// Runs menu commands
        /// </summary>
        private void ItemClick(object sender, EventArgs e)
        {
            var item = sender as ToolStripItem;
            if (item == null)
                return;
            var command = Activator.CreateInstance<TCommand>();
            if (CommandFromName(item, ref command))
                RunCommand(command);
        }
    }
}
