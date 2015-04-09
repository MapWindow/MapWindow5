using System;
using System.Collections;
using System.Collections.Generic;
using MapWinGIS;
using MW5.Api.Helpers;
using MW5.Api.Interfaces;
using MW5.Api.Static;

namespace MW5.Api.Concrete
{
    public class VectorDatasource: IVectorDatasource, IEnumerable<VectorLayer>, IDisposable
    {
        private readonly OgrDatasource _datasource;

        internal VectorDatasource(OgrDatasource datasource)
        {
            _datasource = datasource;
            if (datasource == null)
            {
                throw new NullReferenceException("Internal style reference is null.");
            }
        }

        public VectorDatasource(string connectionString)
        {
            _datasource = new OgrDatasource();
            if (!_datasource.Open(connectionString))
            {
                throw new ApplicationException("Failed to open vector datasource:" +
                                               _datasource.ErrorMsg[_datasource.LastErrorCode]);
            }
        }

        public object InternalObject
        {
            get { return _datasource; }
        }

        public string LastError
        {
            get { return _datasource.ErrorMsg[_datasource.LastErrorCode]; }
        }

        public string Tag
        {
            get { return _datasource.Key; }
            set { _datasource.Key = value; }
        }


        public string Filename
        {
            get
            {
                // TODO: implement in ocx
                //return _datasource.ConnectionString;
                throw new NotImplementedException();
            }
        }

        public void Close()
        {
            _datasource.Close();
        }

        public VectorLayer GetLayer(int index, bool forUpdate = false)
        {
            var layer = _datasource.GetLayer(index, forUpdate);
            if (layer != null)
            {
                return new VectorLayer(layer);
            }
            return null;
        }

        public string GetLayerName(int layerIndex)
        {
            return _datasource.GetLayerName(layerIndex);
        }

        public VectorLayer GetLayerByName(string layerName, bool forUpdate = false)
        {
            var layer = _datasource.GetLayerByName(layerName, forUpdate);
            if (layer != null)
            {
                return new VectorLayer(layer);
            }
            return null;
        }

        public VectorLayer RunQuery(string sql)
        {
            var layer = _datasource.RunQuery(sql);
            if (layer != null)
            {
                return new VectorLayer(layer);
            }
            return null;
        }

        public bool DeleteLayer(int layerIndex)
        {
            return _datasource.DeleteLayer(layerIndex);
        }

        public bool TestCapability(DatasourceCapability capability)
        {
            return _datasource.TestCapability((tkOgrDSCapability) capability);
        }

        public bool CreateLayer(string layerName, GeometryType geometryType, ISpatialReference projection = null, string creationOptions = "")
        {
            var shpType = GeometryHelper.GeometryType2ShpType(geometryType);
            GeoProjection gp = null;
            if (projection != null)
            {
                gp = projection.GetInternal();
            }
            return _datasource.CreateLayer(layerName, shpType, gp, creationOptions);
        }

        public int LayerIndexByName(string layerName)
        {
            return _datasource.LayerIndexByName(layerName);
        }

        public bool ImportLayer(IFeatureSet featureSet, string layerName, string creationOptions = "",
            ValidationMode validationMode = ValidationMode.TryFixSkipOnFailure)
        {
            return _datasource.ImportShapefile(featureSet.GetInternal(), layerName, creationOptions, (tkShapeValidationMode)validationMode);
        }

        public bool ExecuteSql(string sql, out string errorMessage)
        {
            return _datasource.ExecuteSQL(sql, out errorMessage);
        }

        public int LayerCount
        {
            get { return _datasource.LayerCount; }
        }

        public string DriverName
        {
            get { return _datasource.DriverName; }
        }

        public string get_DriverMetadata(GdalDriverMetadata metadata)
        {
            return _datasource.DriverMetadata[(tkGdalDriverMetadata)metadata];
        }

        public int DriverMetadataCount
        {
            get { return _datasource.DriverMetadataCount; }
        }

        public string get_DriverMetadataItem(int metadataIndex)
        {
            return _datasource.DriverMetadataItem[metadataIndex];
        }

        public string GdalLastErrorMsg
        {
            get { return _datasource.GdalLastErrorMsg; }
        }

        public string OpenDialogFilter
        {
            get { return GeoSource.VectorFilter; }
        }

        public LayerType LayerType
        {
            get { return LayerType.VectorLayer; }
        }

        public string ToolTipText
        {
            get
            {
                string s = string.Empty;
                string proj = string.Empty;

                foreach (var source in LayerSourceHelper.GetLayers(this))
                {
                    var layer = source as IVectorLayer;
                    if (layer != null)
                    {
                        if (s != string.Empty)
                        {
                            s += "\n";
                        }

                        s += "Layer name: " + layer.Name + Environment.NewLine;
                        s += "Geometry type: " + layer.GeometryType.EnumToString() +
                                             Environment.NewLine;
                        s += "Feature count: " + layer.get_FeatureCount() + Environment.NewLine;

                        proj = layer.Projection.ExportToProj4();
                    }
                }

                s += "\n" + proj;                

                return s;
            }
        }

        public void Dispose()
        {
            _datasource.Close();
        }

        public IEnumerator<VectorLayer> GetEnumerator()
        {
            for (int i = 0; i < _datasource.LayerCount; i++)
            {
                var layer = _datasource.GetLayer(i);
                yield return new VectorLayer(layer);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
