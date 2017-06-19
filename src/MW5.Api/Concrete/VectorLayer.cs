using System;
using System.Collections.Generic;
using MapWinGIS;
using MW5.Api.Enums;
using MW5.Api.Helpers;
using MW5.Api.Interfaces;
using MW5.Api.Static;
using MW5.Shared;
using MW5.Shared.Log;

namespace MW5.Api.Concrete
{
    public class VectorLayer: IVectorLayer
    {
        private readonly OgrLayer _layer;

        internal VectorLayer(OgrLayer layer)
        {
            _layer = layer;
            if (layer == null)
            {
                throw new NullReferenceException("Internal layer is null.");
            }
        }

        public VectorLayer()
        {
            _layer = new OgrLayer();
        }

        public VectorLayer(string connectionString, string sql)
            : this()
        {
            if (!OpenFromQuery(connectionString, sql))
            {
                ReportOpenFailure();
            }
        }

        public VectorLayer(string connectionString, string layerName, bool forUpdate = false)
            : this()
        {
            if (!Open(connectionString, layerName, forUpdate))
            {
                ReportOpenFailure();
            }
        }

        public VectorLayer(string filename, bool forUpdate = false)
            : this()
        {
            if (!Open(filename, forUpdate))
            {
                ReportOpenFailure();
            }
        }

        public void ReloadFromSource()
        {
            _layer.ReloadFromSource();
        }

        public bool Open(string filename, bool forUpdate = false)
        {
            return _layer.OpenFromFile(filename, forUpdate);
        }

        public bool OpenFromQuery(string connectionString, string sql)
        {
            return _layer.OpenFromQuery(connectionString, sql);
        }

        public bool Open(string connectionString, string layerName, bool forUpdate = false)
        {
            return _layer.OpenFromDatabase(connectionString, layerName, forUpdate);
        }

        private void ReportOpenFailure()
        {
            throw new ApplicationException("Failed to open vector layer: " + _layer.ErrorMsg[_layer.LastErrorCode]);
        }

        public object InternalObject
        {
            get { return _layer; }
        }

        public string LastError
        {
            get { return _layer.ErrorMsg[_layer.LastErrorCode]; }
        }

        public string Tag
        {
            get { return _layer.Key; }
            set { _layer.Key = value; }
        }

        public bool TestCapability(LayerCapability capability)
        {
            return _layer.TestCapability((tkOgrLayerCapability) capability);
        }

        public string Serialize()
        {
            return _layer.Serialize();
        }

        public bool Deserialize(string state)
        {
            return _layer.Deserialize(state);
        }

        public int GetNumStyles()
        {
            return _layer.GetNumStyles();
        }

        public bool ClearStyles()
        {
            return _layer.ClearStyles();
        }

        public bool RemoveStyle(string styleName)
        {
            return _layer.RemoveStyle(styleName);
        }

        public string Name
        {
            get { return _layer.Name; }
        }

        public GeometryType GeometryType
        {
            get { return GeometryHelper.ShapeType2GeometryType(_layer.ShapeType); }
        }

        public bool DataIsReprojected
        {
            get { return _layer.DataIsReprojected; }
        }

        public string FidColumnName
        {
            get { return _layer.FIDColumnName; }
        }

        public int UpdateSourceErrorCount
        {
            get { return _layer.UpdateSourceErrorCount; }
        }

        public string get_UpdateSourceErrorMsg(int errorIndex)
        {
            return _layer.UpdateSourceErrorMsg[errorIndex];
        }

        public int get_UpdateSourceErrorGeometryIndex(int errorIndex)
        {
            return _layer.UpdateSourceErrorShapeIndex[errorIndex];
        }

        public int get_FeatureCount(bool forceLoading = false)
        {
            return _layer.FeatureCount[forceLoading];
        }

        public string GeometryColumnName
        {
            get { return _layer.GeometryColumnName; }
        }

        public bool get_SupportsEditing(SaveType editingType)
        {
            return _layer.SupportsEditing[(tkOgrSaveType)editingType];
        }

        public VectorSourceType SourceType
        {
            get { return (VectorSourceType)_layer.SourceType; }
        }

        public string GdalLastErrorMsg
        {
            get { return _layer.GdalLastErrorMsg; }
        }

        public bool DynamicLoading
        {
            get { return _layer.DynamicLoading; }
            set { _layer.DynamicLoading = value; }
        }

        public int MaxFeatureCount
        {
            get { return _layer.MaxFeatureCount; }
            set { _layer.MaxFeatureCount = value; }
        }

        public bool SupportsStyles
        {
            get { return _layer.SupportsStyles; }
        }

        public string get_StyleName(int styleIndex)
        {
            return _layer.StyleName[styleIndex];
        }

        public string DriverName
        {
            get { return _layer.DriverName; }
        }

        public IEnumerable<ComplexGeometryType> AvailableGeometryTypes
        {
            get
            {
                var list = _layer.AvailableShapeTypes as int[];
                if (list == null)
                {
                    yield break;
                }

                foreach (var item in list)
                {
                    yield return new ComplexGeometryType((ShpfileType)item);
                }
            }
        }

        public void SetActiveGeometryType(GeometryType type, ZValueType zValue)
        {
            _layer.ActiveShapeType = GeometryHelper.GeometryType2ShpType(type, zValue);
        }

        public GeometryType ActiveGeometryType
        {
            get { return GeometryHelper.ShapeType2GeometryType(_layer.ActiveShapeType); }
        }

        public ZValueType ActiveZValueType
        {
            get { return GeometryHelper.ShapeType2ZValueType(_layer.ActiveShapeType); }
        }

        public IEnvelope Envelope
        {
            get
            {
                Extents extents;
                if (_layer.get_Extents(out extents))
                {
                    return new Envelope(extents);
                }
                return null;
            }
        }

        public string Filename
        {
            get { return _layer.GetConnectionString(); }
        }

        public ISpatialReference Projection
        {
            get { return new SpatialReference(_layer.GeoProjection); }
        }

        /// <summary>
        /// Assigns projection to the layer if the layer doesn't have one.
        /// </summary>
        public void AssignProjection(ISpatialReference proj)
        {
            Logger.Current.Warn("VectorLayer: assign projection method isn't supported.");
        }

        public bool IsEmpty
        {
            get { return _layer.FeatureCount == 0; }
        }

        /// <summary>
        /// Gets string with the information on datasource size, i.e. number of features, pixels, etc.
        /// </summary>
        public string SizeInfo 
        {
            get { return "[" + _layer.FeatureCount + " features]"; } 
        }

        public LayerType LayerType
        {
            get { return LayerType.VectorLayer; }
        }

        public string ToolTipText
        {
            get
            {
                string s = "Geometry type: " + GeometryType.EnumToString() + Environment.NewLine;
                s += "Feature count: " + get_FeatureCount() + Environment.NewLine;
                // s += Projection.ExportToProj4();
                s += Projection.Name;
                return s;
            }
        }

        public bool IsVector
        {
            get { return true; }
        }

        public bool IsRaster
        {
            get { return false; }
        }

        public IGlobalListener Callback
        {
            get { return NativeCallback.UnWrap(_layer.GlobalCallback); }
            set { _layer.GlobalCallback = NativeCallback.Wrap(value); }
        }

        public void Close()
        {
            _layer.Close();
        }

        public IFeatureSet Data
        {
            get { return new FeatureSet(_layer.GetBuffer()); }
        }

        public string ConnectionString
        {
            get { return _layer.GetConnectionString(); }
        }

        public string SourceQuery
        {
            get { return _layer.GetSourceQuery(); }
        }

        public SaveResult SaveChanges(out int savedCount, SaveType saveType = SaveType.SaveAll, bool validateShapes = true)
        {
            return (SaveResult)_layer.SaveChanges(out savedCount, (tkOgrSaveType)saveType, validateShapes);
        }

        public string OpenDialogFilter
        {
            get { return GeoSource.VectorFilter; }
        }

        public void Dispose()
        {
            _layer.Close();
        }

        #region Not implemented

        //public bool GenerateCategories(string FieldName, tkClassificationType ClassificationType, int numClasses, tkMapColor colorStart,
        //   tkMapColor colorEnd, tkColorSchemeType schemeType)
        //{
        //    throw new NotImplementedException();
        //}

        //public tkLabelPositioning LabelPosition
        //{
        //    get { throw new NotImplementedException(); }
        //    set { throw new NotImplementedException(); }
        //}

        //public tkLineLabelOrientation LabelOrientation
        //{
        //    get { throw new NotImplementedException(); }
        //    set { throw new NotImplementedException(); }
        //}

        //public bool get_Extents(out Extents layerExtents, bool forceLoading = false)
        //{
        //    throw new NotImplementedException();
        //}

        //public string LabelExpression
        //{
        //    get { throw new NotImplementedException(); }
        //    set { throw new NotImplementedException(); }
        //}

        #endregion

    }
}
