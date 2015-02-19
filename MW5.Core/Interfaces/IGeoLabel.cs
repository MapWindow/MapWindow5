namespace MW5.Core.Interfaces
{
    public interface IGeoLabel: IComWrapper
    {
        int CategoryIndex { get; set; }
        bool IsDrawn { get; }
        double Rotation { get; set; }
        IEnvelope ScreenExtents { get; }
        string Text { get; set; }
        bool Visible { get; set; }
        double X { get; set; }
        double Y { get; set; }
    }
}
