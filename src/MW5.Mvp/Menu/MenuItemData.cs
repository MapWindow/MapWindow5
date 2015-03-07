using System;
using System.Drawing;

namespace MW5.Mvp.Menu
{
    public class MenuItemData
    {
        internal MenuItemData()
        {
            
        }

        internal MenuItemData(string key, string text, Bitmap icon)
        {
            Key = key;
            Icon = icon;
            Text = text;
        }

        public string Key { get; set; }
        public Bitmap Icon { get; set; }
        public string Text { get; set; }

        public bool BeginGroup { get; set; }
    }
}
