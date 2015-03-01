using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Interfaces;
using Syncfusion.Windows.Forms.Tools.XPMenus;

namespace MW5.UI
{
    public class Toolbar: IToolbar
    {
        private readonly Bar _bar;

        public Toolbar(Bar bar)
        {
            _bar = bar;
            if (bar == null)
            {
                throw new NullReferenceException("Internal toolbar reference is null.");
            }
        }

        public string Name
        {
            get { return _bar.BarName; }
            set { _bar.BarName = value; }
        }

        public IMenuItemCollection Items
        {
            get { return new MenuItemCollection(_bar.Items); }
        }
    }
}
