using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL.BO
{
    [Serializable]
    public class LayerGroup : Layer
    {
        public Group Group { get; set; }

        internal static LayerGroup CreateLayerGroup(Layer item, Group group)
        {
            LayerGroup layerGroup = new LayerGroup();

            layerGroup.Group = group;
            layerGroup.Filename = item.Filename;
            layerGroup.Handle = item.Handle;
            layerGroup.LayerKey = item.LayerKey;
            layerGroup.LayerType = item.LayerType;
            layerGroup.LayerVisible = item.LayerVisible;
            layerGroup.Name = item.Name;
            layerGroup.PositionInGroup = item.PositionInGroup;
            layerGroup.Position = item.Position;

            return layerGroup;
        }
    }
}
