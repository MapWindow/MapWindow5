using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syncfusion.Windows.Forms.Tools;

namespace MW5.UI.Controls
{
    public class ToolTipGridEventArgs: ToolTipEventArgs
    {
        public ToolTipGridEventArgs(ToolTipInfo info, int recordIndex) : base(info)
        {
            RecordIndex = recordIndex;
        }

        public int RecordIndex { get; private set; }
    }
}
