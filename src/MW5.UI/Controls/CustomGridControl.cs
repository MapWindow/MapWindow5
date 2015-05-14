using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syncfusion.Windows.Forms.Grid.Grouping;

namespace MW5.UI.Controls
{
    public class CustomGridControl: GridGroupingControl
    {
        public CustomGridControl()
        {
            WrapWithPanel = true;
        }

        [Browsable(false)]
        public bool WrapWithPanel { get; set; }
    }
}
