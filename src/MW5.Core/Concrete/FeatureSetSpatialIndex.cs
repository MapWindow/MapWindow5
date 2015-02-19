using System;
using MapWinGIS;

namespace MW5.Core.Concrete
{
    public class FeatureSetSpatialIndex
    {
        private readonly Shapefile _shapefile;

        internal FeatureSetSpatialIndex(Shapefile shapefile)
        {
            _shapefile = shapefile;
            if (shapefile == null)
            {
                throw new NullReferenceException("Internal reference is null");
            }
        }

        public bool DiskIndexExists
        {
            get { return _shapefile.HasSpatialIndex; }
            
        }
        public double MaxAreaPercent
        {
            get { return _shapefile.SpatialIndexMaxAreaPercent; }
            set { _shapefile.SpatialIndexMaxAreaPercent = value; }
        }

        public bool UseDiskIndex
        {
            get { return _shapefile.UseSpatialIndex; }
            set { _shapefile.UseSpatialIndex = value; }
        }

        public bool CreateDiskIndex()
        {
            return _shapefile.CreateSpatialIndex(_shapefile.Filename);
        }

        public bool DiskIndexValid
        {
            get { return _shapefile.IsSpatialIndexValid(); }
        }

        public bool RemoveDiskIndex()
        {
            return _shapefile.RemoveSpatialIndex();
        }

        public bool UseRamIndex
        {
            get { return _shapefile.UseQTree; }
            set { _shapefile.UseQTree = value; }
        }
    }
}
