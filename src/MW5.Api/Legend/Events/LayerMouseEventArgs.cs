using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MW5.Api.Legend.Events
{
    public class LayerMouseEventArgs : LayerEventArgs
    {
        public MouseButtons Button { get; internal set; }

        public LayerMouseEventArgs(int layerHandle, MouseButtons buttons) : base(layerHandle)
        {
            Button = buttons;
        }
    }
}
