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
        private GridCellColorRenderer _renderer;
        private bool _showDropDowns;

        public GridCellColorModel(GridModel grid) : base(grid)
        {
            ButtonBarSize = new Size(16, 20);
        }

        protected GridCellColorModel(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public bool ShowDropDowns 
        {
            get { return _showDropDowns; }
            set
            {
                _showDropDowns = value;
                if (_renderer != null)
                {
                    _renderer.ShowDropDownButton = value;
                }
            }
         }

        public override GridCellRendererBase CreateRenderer(Syncfusion.Windows.Forms.Grid.GridControlBase control)
        {
            _renderer = new GridCellColorRenderer(control, this) {ShowDropDownButton = _showDropDowns};
            return _renderer;
        }
    }
}
