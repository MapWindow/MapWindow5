using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Interfaces;

namespace MW5.Plugins.ShapeEditor.Views
{
    public class AttributeViewModel
    {
        public AttributeViewModel(ILayer layer, int shapeIndex)
        {
            Layer = layer;
            ShapeIndex = shapeIndex;
        }
        
        public ILayer Layer { get; private set; }
        public int ShapeIndex { get; private set; }
    }
}
