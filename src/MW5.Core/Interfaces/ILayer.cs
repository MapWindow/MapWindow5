namespace MW5.Core.Interfaces
{
    public interface ILayer
    {
        int Handle { get; }
        string Name { get; }
        LayerType LayerType { get; }
        bool Visible { get; set; }
        bool DynamicVisibility { get; set; }
        int MinVisibleZoom { get; set; }
        int MaxVisibleZoom { get; set; }
        string Filename { get; }
        int Position { get; }
    }
}
