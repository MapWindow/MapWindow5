// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IEnvelope.cs" company="MapWindow OSS Team - www.mapwindow.org">
//   MapWindow OSS Team - 2015
// </copyright>
// <summary>
//   Defines the IEnvelope type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Drawing;

namespace MW5.Api.Interfaces
{
    public interface IEnvelope : IComWrapper
    {
        ICoordinate Center { get; }

        double Height { get; }

        double MaxM { get; }

        double MaxX { get; }

        double MaxY { get; }

        double MaxZ { get; }

        double MinM { get; }

        double MinX { get; }

        double MinY { get; }

        double MinZ { get; }

        double Width { get; }

        IEnvelope Adjust(double xyRatio);

        bool EqualsTo(IEnvelope env, double threshold = 0d);

        IEnvelope Inflate(double dx, double dy);

        IEnvelope Move(double dx, double dy);

        bool PointWithin(double x, double y);

        void SetBounds(double xMin, double xMax, double yMin, double yMax);

        void SetBounds(ICoordinate center, double width, double height);

        IGeometry ToGeometry();

        Rectangle ToRectangle();

        void Union(IEnvelope env);

        void MoveCenterTo(double xCenter, double yCenter);

        IEnvelope Clone();
    }
}