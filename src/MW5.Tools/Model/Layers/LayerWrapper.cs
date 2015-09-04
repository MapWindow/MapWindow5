using System;
using System.Linq;
using MW5.Api.Concrete;
using MW5.Api.Helpers;
using MW5.Api.Interfaces;
using MW5.Api.Static;

namespace MW5.Tools.Model.Layers
{
    internal class LayerWrapper: IRasterLayerInfo, IVectorLayerInfo
    {
        private readonly ILayer _layer;
        private readonly LayerIdentity _identity;

        public LayerWrapper(ILayer layer)
        {
            if (layer == null) throw new ArgumentNullException("layer");
            _layer = layer;
        }

        public LayerWrapper(LayerIdentity identity)
        {
            if (identity == null) throw new ArgumentNullException("identity");
            _identity = identity;
        }

        public LayerIdentity Identity
        {
            get { return _identity ?? _layer.Identity; }
        }

        public ILayerSource Datasource
        {
            get
            {
                if (Opened)
                {
                    return _layer.LayerSource;
                }

                var ds = GeoSource.OpenFromIdentity(_identity);
                return ds.GetLayers().FirstOrDefault();
            }
            set { throw new NotSupportedException("Datasource.set isn't supported"); }
        }

        IRasterSource IRasterLayerInfo.Datasource
        {
            get { return Raster; }
            set { throw new NotSupportedException("Raster.set isn't supported"); }
        }

        IFeatureSet IVectorLayerInfo.Datasource
        {
            get { return FeatureSet; }
            set  {  throw new NotSupportedException("FeatureSet.set isn't supported"); }
        }

        public IRasterSource Raster
        {
            get
            {
                if (_layer != null && _layer.IsRaster)
                {
                    return _layer.ImageSource as IRasterSource;
                }

                return null;
            }
        }

        public IFeatureSet FeatureSet
        {
            get
            {
                if (_layer != null && _layer.IsVector)
                {
                    return _layer.FeatureSet;
                }

                return null;
            }
        }

        public bool SelectedOnly { get; set; }

        public bool CloseAfterRun
        {
            get { return !Opened; }
            set { throw new NotSupportedException("CloseAfterRun.set isn't supported"); }
        }

        public bool Opened
        {
            get { return _layer != null; }
        }

        public string Name
        {
            get { return Opened ? _layer.Name : _identity.ToString(); }
        }

        public override string ToString()
        {
            if (_layer != null)
            {
                if (_layer.IsVector)
                {
                    var fs = Datasource as IFeatureSet;
                    if (fs != null)
                    {
                        return Name + " [" + fs.NumFeatures + " features]";
                    }
                }
                else
                {
                    var img = Datasource as IRasterSource;
                    if (img != null)
                    {
                        return Name + string.Format(" [{0}×{1} pixels]", img.Width, img.Height);
                    }
                }
            }

            return Name;
        }
    }
}
