using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MW5.Api.Legend.Events
{
    public class LayerCategoryEventArgs: LayerMouseEventArgs
    {
        public int CategoryIndex { get; internal set; }

        public LayerCategoryEventArgs(int layerHandle, MouseButtons buttons, int category) : base(layerHandle, buttons)
        {
            CategoryIndex = category;
        }
    }
}
