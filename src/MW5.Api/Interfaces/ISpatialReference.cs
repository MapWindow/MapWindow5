using MW5.Api.Enums;

namespace MW5.Api.Interfaces
{
    public interface ISpatialReference : IComWrapper
    {
        string GeogCoordinateSystemName { get; }
        bool HasTransformation { get; }
        double InverseFlattening { get; }
        bool IsEmpty { get; }
        bool IsFrozen { get; }
        bool IsGeographic { get; }
        bool IsLocal { get; }
        bool IsProjected { get; }
        string Name { get; }
        string ProjectionName { get; }
        double SemiMajor { get; }
        double SemiMinor { get; }
        bool Clear();
        ISpatialReference Clone();
        bool CopyFrom(ISpatialReference sourceProj);
        string ExportToProj4();
        string ExportToWkt();
        bool GetGeogCoordinateSystemParam(CoordinateSystemParameter name, ref double value);
        bool IsSame(ISpatialReference proj);
        bool IsSameExt(ISpatialReference proj, IEnvelope bounds, int numSamplingPoints = 8);
        bool GetIsSameGeogCoordinateSystem(ISpatialReference proj);
        bool GetProjectionParam(ProjectionParameter name, ref double value);
        bool ImportFromAutoDetect(string proj);
        bool ImportFromEpsg(int projCode);
        bool ImportFromEsri(string proj);
        bool ImportFromProj4(string proj);
        bool ImportFromWkt(string proj);
        bool ReadFromFile(string filename);
        bool SetGoogleMercator();
        bool SetWgs84();
        void SetWgs84Projection(Wgs84Projection projection);
        bool StartTransform(ISpatialReference target);
        void StopTransform();
        bool Transform(ref double x, ref double y);
        bool TryAutoDetectEpsg(out int epsgCode);
        bool WriteToFile(string filename);
        string ExportToEsri();
        ISpatialReference MorphToEsri();
    }
}
