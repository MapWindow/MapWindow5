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
    public class OpenFileDialogCellModel : GridTextBoxCellModel
    {
        protected OpenFileDialogCellModel(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            ButtonBarSize = new Size(20, 20);
        }
        
        public OpenFileDialogCellModel(GridModel grid): base(grid)
        {
            
        }

        public override GridCellRendererBase CreateRenderer(GridControlBase control)
        {
            return new OpenFileDialogCellRenderer(control, this);
        }
    }
}
