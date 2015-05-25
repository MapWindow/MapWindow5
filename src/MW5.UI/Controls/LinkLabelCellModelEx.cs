using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Syncfusion.GridHelperClasses;
using Syncfusion.Windows.Forms.Grid;

namespace MW5.UI.Controls
{
    public class LinkLabelCellModelEx: LinkLabelCellModel
    {
        private LinkLabelCellRendererEx _renderer;

        protected LinkLabelCellModelEx(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public LinkLabelCellModelEx(GridModel grid) : base(grid)
        {
        }

        public override GridCellRendererBase CreateRenderer(GridControlBase control)
        {
            return _renderer ?? (_renderer = new LinkLabelCellRendererEx(control, this));
        }
    }
}
