using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Syncfusion.Windows.Forms.Tools;

namespace MW5.UI.Helpers
{    
    /// <summary>
    /// Extension methods for SplitContainer control
    /// </summary>
    public static class SplitContainerHelper
    {
        /// <summary>
        /// Initializes split container in the dock panel.
        /// </summary>
        public static void InitDockPanel(this SplitContainerAdv splitContainer, double splitterDistanceRatio)
        {
            splitContainer.Orientation = Orientation.Vertical;
            splitContainer.BorderStyle = BorderStyle.None;
            splitContainer.Panel1MinSize = 0;
            splitContainer.Panel2MinSize = 0;
            splitContainer.SplitterDistance = Convert.ToInt32(splitContainer.Height * splitterDistanceRatio);
        }
    }
}
