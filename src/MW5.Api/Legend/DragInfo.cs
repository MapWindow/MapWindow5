using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Api.Legend
{
    internal class DragInfo
    {
        public bool Dragging;
        public bool MouseDown;
        public bool LegendLocked;
        public int DragLayerIndex;
        public int DragGroupIndex;
        public int TargetGroupIndex;
        public int TargetLayerIndex;
        public int StartY;
        //public int StopY;

        public DragInfo()
        {
            Reset();
        }
        public void Reset()
        {
            Dragging = false;
            MouseDown = false;
            StartY = 0;
            LegendLocked = false;
            DragLayerIndex = -1;
            DragGroupIndex = -1;
            TargetGroupIndex = -1;
            TargetLayerIndex = -1;
        }

        public bool DraggingLayer
        {
            get
            {
                return DragLayerIndex != -1;
            }
        }

        public void StartGroupDrag(int mouseY, int groupIndex)
        {
            MouseDown = true;
            DragGroupIndex = groupIndex;
            DragLayerIndex = Constants.INVALID_INDEX;
            StartY = mouseY;
        }

        public void StartLayerDrag(int mouseY, int groupIndex, int layerIndex)
        {
            MouseDown = true;
            DragGroupIndex = groupIndex;
            DragLayerIndex = layerIndex;
            StartY = mouseY;
        }
    }
}
