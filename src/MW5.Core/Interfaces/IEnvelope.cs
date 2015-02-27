namespace MW5.Core.Interfaces
{
    public interface IEnvelope: IComWrapper
    {
        double MinX { get; }
        double MinY { get; }
        double MinZ { get; }
        double MinM { get; }
        double MaxX { get; }
        double MaxY { get; }
        double MaxZ { get; }
        double MaxM { get; }
    }
}
