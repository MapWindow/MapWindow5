using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MapWindowControls.LegendControl
{
    public class LegendDroppedEventArgs :EventArgs
    {
        public string destinationNode;
        public string movingNode;
      //  public string originNode;

        public LegendDroppedEventArgs(string destNode, string moveNode)
        {
            this.destinationNode = destNode;
            this.movingNode = moveNode;
        //    this.originNode = originNode;
        }

    }
}
