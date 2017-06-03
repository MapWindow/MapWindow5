using System;
using MW5.Api.Enums;
using MW5.Api.Interfaces;

namespace MW5.Data.Repository
{
    internal class DatabaseLayerMetadata: IItemMetadata
    {
        public DatabaseLayerMetadata(IVectorLayer layer)
        {
            if (layer == null) throw new ArgumentNullException("layer");

            // we don't want to keep the connection open all the time, so simply grab the necessary data
            Name = layer.Name;
            GeometryType = layer.ActiveGeometryType;
            NumFeatures = layer.get_FeatureCount();
            Projection = layer.Projection;
            Connection = layer.ConnectionString;
        }

        public string Name { get; set; }
        public GeometryType GeometryType { get; set; }
        public int NumFeatures { get; set; }
        public ISpatialReference Projection { get; set; }
        public string Connection { get; set; }
        public bool AddedToMap { get; set; }
        public bool Loading { get; set; }
    }
}
