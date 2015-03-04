using System;
using System.Drawing;

namespace MW5.Plugins.Concrete
{
    public class MenuItemData<TCommand> 
        where TCommand : struct, IConvertible
    {
        public MenuItemData(TCommand command, Bitmap icon, string text)
        {
            Command = command;
            Icon = icon;
            Text = text;
        }

        public TCommand Command { get; set; }
        public Bitmap Icon { get; set; }
        public string Text { get; set; }
    }
}
