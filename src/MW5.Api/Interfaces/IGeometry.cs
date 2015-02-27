using System;
using System.Collections.Generic;
using MW5.Api.Concrete;

namespace MW5.Api.Interfaces
{
    public interface IGeometry : IDisposable, IComWrapper
    {
        GeometryType GeometryType { get; }
        CoordinateList Points { get; }
        GeometryPartCollection Parts { get; }
        Coordinate Center { get; }
        Coordinate Centroid { get; }
        Coordinate InteriorPoint { get; }
        IEnvelope Extents { get; }
        bool IsEmpty { get; }
        bool IsValid { get; }
        string IsValidReason { get; }
        double Length { get; }
        double Perimeter { get; }
        IGeometry Boundary();
        IGeometry Buffer(double distance, int numSegments);

        IGeometry BufferWithParams(double distance, int numSegments = 30, bool singleSided = false,
            BufferCap capStyle = BufferCap.Round, BufferJoin joinStyle = BufferJoin.Round,
            double mitreLimit = 5);

        IGeometry Clip(IGeometry g, ClipOperation operation);
        IGeometry Clone();
        IGeometry ClosestPoints(IGeometry g);
        bool Contains(IGeometry g);
        IGeometry ConvexHull();
        bool CopyFrom(IGeometry g);
        bool Crosses(IGeometry g);
        bool Disjoint(IGeometry g);
        double Distance(IGeometry g);
        IEnumerable<IGeometry> Explode();
        byte[] ExportToBinary();
        string ExportToWkt();
        IGeometry FixUp();
        IEnumerable<IGeometry> Intersection(IGeometry g);
        bool ImportFromBinary(byte[] bytes);
        bool ImportFromWkt(string serialized);
        bool Intersects(IGeometry g);
        void Move(double offsetX, double offsetY);
        bool Overlaps(IGeometry g);
        bool PointInThisPoly(ICoordinate pt);
        bool Relates(IGeometry g, SpatialRelation relation);
        void Rotate(double originX, double originY, double angle);
        IEnumerable<IGeometry> SplitByPolyline(IGeometry polyline);
        bool Touches(IGeometry g);
        bool Within(IGeometry g);
    }
}