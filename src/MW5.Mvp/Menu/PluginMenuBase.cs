using System;
using System.Collections.Generic;
using System.Drawing;
using MW5.Plugins.Concrete;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mvp;

namespace MW5.Mvp.Menu
{
    public abstract class PluginMenuBase<TCommand> : CommandPresenter<IMenuProvider, TCommand>, IMenuProvider
        where TCommand : struct, IConvertible
    {
        private readonly IAppContext _context;
        private List<IToolbar> _toolbars = new List<IToolbar>();

        public PluginMenuBase(IAppContext context) 
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            _context = context;
        }

        public void AddToolbar(string toolBarName, BasePlugin plugin)
        {
            if (plugin == null)
            {
                throw new NullReferenceException("Plugin reference must not be null.");
            }
            
            var toolbar = _context.Toolbars.Add(toolBarName);
            toolbar.Tag = plugin.Identity;
            var items = GetMenuItems(toolBarName, Create);
            
            foreach (var item in items)
            {
                var btn = toolbar.Items.AddButton(item.Text, "tool" + item.Command);
                btn.Picture = new MenuIcon(item.Icon);
                btn.Tag = plugin.Identity;
            }

            _toolbars.Clear();
            _toolbars.Add(toolbar);
            WireUpMenus(this);
        }

        public void AddMenu(string name, BasePlugin plugin)
        {
            var items = _context.Menu.Items;
            var item = items.AddDropDown(name);
            item.Tag = plugin.Identity;
        }

        public IEnumerable<IToolbar> Toolbars
        {
            get { return _toolbars; }
        }

        protected MenuItemData<TCommand> Create(TCommand command, Bitmap icon, string text)
        {
            return new MenuItemData<TCommand>(command, icon, text);
        }

        public abstract IEnumerable<MenuItemData<TCommand>> GetMenuItems(string toolBarName,
                Func<TCommand, Bitmap, string, MenuItemData<TCommand>> createItem);
    }
}
