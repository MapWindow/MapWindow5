using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Api.Legend.Events
{
    public class LayerCancelEventArgs: LayerEventArgs
    {
        public bool NewState { get; internal set; }
        public bool Cancel { get; set; }

        public LayerCancelEventArgs(int layerHandle, bool newState) : base(layerHandle)
        {
            NewState = newState;
        }
    }
}
