using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LayerControl.LegendControl
{
    public class ColapseExpandEventArgs
    {
        public string NodeName { get; set; }
        public bool IsExpanded { get; set; }

        public ColapseExpandEventArgs(string nodeName, bool isExpanded)
        {
            this.NodeName = nodeName;
            this.IsExpanded = isExpanded;
        }
    }
}
