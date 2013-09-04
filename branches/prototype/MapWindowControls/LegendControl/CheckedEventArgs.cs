using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MapWindowControls.LegendControl
{
    public class CheckedEventArgs
    {
        public string ItemName { get; set; }
        public bool Visible { get; set; }
        public int Handle { get; set; }

        public CheckedEventArgs(string itemName, bool visible, int handle)
        {
            this.ItemName = itemName;
            this.Visible = visible;
            this.Handle = handle;
        }
    }
}
