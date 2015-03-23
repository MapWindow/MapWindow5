using System.Drawing;

namespace MW5.Api.Interfaces
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
        Rectangle ToRectangle();
        void SetBounds(double xMin, double xMax, double yMin, double yMax);
    }
}
