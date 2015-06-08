using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Legend.Abstract;
using MW5.Plugins.Interfaces;
using MW5.Plugins.TableEditor.Editor;

namespace MW5.Plugins.TableEditor.Model
{
    internal class TablePanelInfo
    {
        public TablePanelInfo(TableEditorGrid grid, ILegendLayer layer, ITablePanel panel)
        {
            if (grid == null) throw new ArgumentNullException("grid");
            if (layer == null) throw new ArgumentNullException("layer");
            if (panel == null) throw new ArgumentNullException("panel");
            Grid = grid;
            Layer = layer;
            Panel = panel;
        }

        public TableEditorGrid Grid { get; private set; }

        public ILegendLayer Layer { get; private set; }

        public ITablePanel Panel { get; private set; }
    }
}
