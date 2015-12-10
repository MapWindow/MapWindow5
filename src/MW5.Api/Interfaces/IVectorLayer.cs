using System.Collections.Generic;
using MW5.Api.Concrete;
using MW5.Api.Enums;

namespace MW5.Api.Interfaces
{
    public interface IVectorLayer: ILayerSource
    {
        GeometryType GeometryType { get; }
        bool DataIsReprojected { get; }
        string FidColumnName { get; }
        int UpdateSourceErrorCount { get; }
        string GeometryColumnName { get; }
        VectorSourceType SourceType { get; }
        string GdalLastErrorMsg { get; }
        bool DynamicLoading { get; set; }
        int MaxFeatureCount { get; set; }
        bool SupportsStyles { get; }
        string DriverName { get; }
        IFeatureSet Data { get; }
        string ConnectionString { get; }
        string SourceQuery { get; }
        bool TestCapability(LayerCapability capability);
        int GetNumStyles();
        bool ClearStyles();
        bool RemoveStyle(string styleName);
        string get_UpdateSourceErrorMsg(int errorIndex);
        int get_UpdateSourceErrorGeometryIndex(int errorIndex);
        int get_FeatureCount(bool forceLoading = false);
        bool get_SupportsEditing(SaveType editingType);
        string get_StyleName(int styleIndex);
        SaveResult SaveChanges(out int savedCount, SaveType saveType = SaveType.SaveAll, bool validateShapes = true);
        bool Open(string filename, bool forUpdate = false);
        bool Open(string connectionString, string layerName, bool forUpdate = false);
        bool OpenFromQuery(string connectionString, string sql);
        void ReloadFromSource();
        IEnumerable<ComplexGeometryType> AvailableGeometryTypes {get;}
        void SetActiveGeometryType(GeometryType type, ZValueType zValue);
        GeometryType ActiveGeometryType { get; }
        ZValueType ActiveZValueType { get; }
    }
}
