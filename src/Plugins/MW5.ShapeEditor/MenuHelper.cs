using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Interfaces;
using MW5.UI;

namespace MW5.Plugins.ShapeEditor
{
    internal static class MenuHelper
    {
        public static void InitMenu(IAppContext context)
        {
            //var items = context.Menu.Items;
            //items.AddDropDown("Shape Editor");

            context.Toolbars.Add("Shape Editor");
        }
    }
}
