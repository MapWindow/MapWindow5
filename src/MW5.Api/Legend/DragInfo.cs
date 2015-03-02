namespace MW5.Api.Legend
{
    internal class DragInfo
    {
        public DragInfo()
        {
            this.Reset();
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
            get
            {
                return this.DragLayerIndex != -1;
            }
        }

        public void Reset()
        {
            this.Dragging = false;
            this.MouseDown = false;
            this.StartY = 0;
            this.LegendLocked = false;
            this.DragLayerIndex = -1;
            this.DragGroupIndex = -1;
            this.TargetGroupIndex = -1;
            this.TargetLayerIndex = -1;
        }

        public void StartGroupDrag(int mouseY, int groupIndex)
        {
            this.MouseDown = true;
            this.DragGroupIndex = groupIndex;
            this.DragLayerIndex = Constants.InvalidIndex;
            this.StartY = mouseY;
        }

        public void StartLayerDrag(int mouseY, int groupIndex, int layerIndex)
        {
            this.MouseDown = true;
            this.DragGroupIndex = groupIndex;
            this.DragLayerIndex = layerIndex;
            this.StartY = mouseY;
        }
    }
}