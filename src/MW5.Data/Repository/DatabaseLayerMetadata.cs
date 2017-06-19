using System;
using MW5.Api.Enums;
using MW5.Api.Interfaces;
using MW5.Shared;

namespace MW5.Data.Repository
{
    internal class DatabaseLayerMetadata: IItemMetadata
    {
        public DatabaseLayerMetadata(IVectorLayer layer)
        {
            if (layer == null) throw new ArgumentNullException("layer");

            Logger.Current.Trace("In DatabaseLayerMetadata");
            // we don't want to keep the connection open all the time, so simply grab the necessary data
            Name = layer.Name;
            Logger.Current.Trace("Name: " + Name);
            GeometryType = layer.ActiveGeometryType;
            Logger.Current.Trace("GeometryType: " + GeometryType);
            NumFeatures = layer.get_FeatureCount();
            Logger.Current.Trace("NumFeatures: " + NumFeatures);
            Projection = layer.Projection;
            Logger.Current.Trace("Projection: " + Projection);
            Connection = layer.ConnectionString;
            Logger.Current.Trace("Connection: " + Connection);
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
