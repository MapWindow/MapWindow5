using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Plugins.TableEditor.Model
{
    public class TablePanelEventArgs : EventArgs
    {
        public TablePanelEventArgs(ITablePanel panel, int layerHandle)
        {
            if (panel == null) throw new ArgumentNullException("panel");
            if (layerHandle == -1) throw new ArgumentException("layerHandle out of bounds");

            Panel = panel;
            LayerHandle = layerHandle;
        }

        public ITablePanel Panel { get; private set; }
        public int LayerHandle { get; private set; }
    }
}
