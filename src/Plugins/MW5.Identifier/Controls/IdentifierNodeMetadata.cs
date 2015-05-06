using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Identifier.Enums;

namespace MW5.Plugins.Identifier.Controls
{
    public class IdentifierNodeMetadata
    {
        public IdentifierNodeMetadata(int layerHandle)
        {
            LayerHandle = layerHandle;
            NodeType = IdentifierNodeType.Layer;
        }

        public IdentifierNodeMetadata(int layerHandle, int shapeIndex)
        {
            LayerHandle = layerHandle;
            ShapeIndex = shapeIndex;
            NodeType = IdentifierNodeType.Geometry;
        }

        public IdentifierNodeMetadata()
        {
            NodeType = IdentifierNodeType.Attribute;
        }

        public IdentifierNodeType NodeType { get; set; }
        public int LayerHandle { get; set; }
        public int ShapeIndex { get; set; }
    }
}
