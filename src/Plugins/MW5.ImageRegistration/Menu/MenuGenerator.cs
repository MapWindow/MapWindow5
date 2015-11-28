using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.ImageRegistration.Properties;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Menu;

namespace MW5.Plugins.ImageRegistration.Menu
{
    internal class MenuGenerator
    {
        private readonly IAppContext _context;
        private readonly ImageRegistrationPlugin _plugin;

        public MenuGenerator(IAppContext context, ImageRegistrationPlugin plugin)
        {
            _context = context;
            _plugin = plugin;
            if (context == null) throw new ArgumentNullException("context");
            if (plugin == null) throw new ArgumentNullException("plugin");

            InitMenu(context);
        }

        private void InitMenu(IAppContext context)
        {
            var items = context.Menu.ToolsMenu.SubItems;

            items.AddButton("Register Image", MenuKeys.RegisterImage, Resources.img_georectify24,  _plugin.Identity).BeginGroup = true;

            context.Menu.ToolsMenu.Update();
        }
    }
}
