using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syncfusion.Windows.Forms.Tools;

namespace MW5.UI.Controls
{
    public class ToolTipEventArgs: CancelEventArgs
    {
        public ToolTipEventArgs(ToolTipInfo info)
        {
            ToolTip = info;
        }
        public ToolTipInfo ToolTip { get; private set; }
    }
}
