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

        public IdentifierNodeMetadata(int layerHandle, int rasterX, int rasterY)
        {
            LayerHandle = layerHandle;
            RasterX = rasterX;
            RasterY = rasterY;
            NodeType = IdentifierNodeType.Pixel;
        }

        public IdentifierNodeMetadata()
        {
            NodeType = IdentifierNodeType.Attribute;
        }

        public IdentifierNodeType NodeType { get; private set; }
        public int LayerHandle { get; private set; }
        public int ShapeIndex { get; private set; }
        public int RasterX { get; private set; }
        public int RasterY { get; private set; }
    }
}
