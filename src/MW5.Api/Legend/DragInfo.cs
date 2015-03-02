namespace MW5.Api.Legend
{
    internal class DragInfo
    {
        public DragInfo()
        {
            Reset();
        }

        public bool Dragging { get; set; }
        public int DragGroupIndex { get; set; }
        public int DragLayerIndex { get; set; }
        public bool LegendLocked { get; set; }
        public bool MouseDown { get; set; }
        public int StartY { get; set; }
        public int TargetGroupIndex { get; set; }
        public int TargetLayerIndex { get; set; }

        public bool DraggingLayer
        {
            get { return DragLayerIndex != -1; }
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

        public void StartGroupDrag(int mouseY, int groupIndex)
        {
            MouseDown = true;
            DragGroupIndex = groupIndex;
            DragLayerIndex = Constants.InvalidIndex;
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