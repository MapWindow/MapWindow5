using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Syncfusion.Windows.Forms.Grid;

namespace MW5.UI.Controls
{
    public class GridCellColorModel: GridDropDownCellModel
    {
        public GridCellColorModel(GridModel grid) : base(grid)
        {
            ButtonBarSize = new Size(16, 20);
        }

        protected GridCellColorModel(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public bool ShowDropDowns { get; set; }

        public override GridCellRendererBase CreateRenderer(Syncfusion.Windows.Forms.Grid.GridControlBase control)
        {
            return new GridCellColorRenderer(control, this);
        }
    }
}
