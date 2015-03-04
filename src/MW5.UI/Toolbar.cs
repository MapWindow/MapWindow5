using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Interfaces;
using Syncfusion.Windows.Forms.Tools;
using Syncfusion.Windows.Forms.Tools.XPMenus;

namespace MW5.UI
{
    public class Toolbar: IToolbar
    {
        private MainFrameBarManager _manager;
        private readonly CommandBar _commandBar;
        private readonly Bar _bar;

        internal Toolbar(MainFrameBarManager manager, Bar bar)
        {
            _manager = manager;
            _bar = bar;
            _commandBar = _manager.GetBarControl(_bar);
            if (bar == null || _commandBar == null)
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

        public bool Visible
        {
            get { return _commandBar.Visible; }
            set { _commandBar.Visible = value; }
        }

        public object Tag
        {
            get { return _commandBar.Tag; }
            set { _commandBar.Tag = value; }
        }
    }
}
