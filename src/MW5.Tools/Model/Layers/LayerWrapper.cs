using System;
using System.ComponentModel;
using System.Linq;
using MW5.Api.Concrete;
using MW5.Api.Enums;
using MW5.Api.Helpers;
using MW5.Api.Interfaces;
using MW5.Api.Static;

namespace MW5.Tools.Model.Layers
{
    public class LayerWrapper: IRasterLayerInfo, IVectorLayerInfo
    {
        private readonly ILayer _layer;
        private readonly LayerIdentity _identity;
        private IDatasource _datasource;

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

        public LayerWrapper(string filename)
        {
            var identity = new LayerIdentity(filename);
            _identity = identity;
        }

        [Browsable(false)]
        public LayerIdentity Identity
        {
            get { return _identity ?? _layer.Identity; }
        }

        [Browsable(false)]
        public ILayerSource Datasource
        {
            get
            {
                if (Opened)
                {
                    return _layer.LayerSource;
                }

                if (_datasource == null)
                {
                    _datasource = GeoSource.OpenFromIdentity(_identity);
                }

                return _datasource.GetLayers().FirstOrDefault();
            }
            set { throw new NotSupportedException("Datasource.set isn't supported"); }
        }

        [Browsable(false)]
        IRasterSource IRasterLayerInfo.Datasource
        {
            get
            {
                return Raster;
            }
            set { throw new NotSupportedException("Raster.set isn't supported"); }
        }

        [Browsable(false)]
        IFeatureSet IVectorLayerInfo.Datasource
        {
            get { return FeatureSet; }
            set  {  throw new NotSupportedException("FeatureSet.set isn't supported"); }
        }

        [Browsable(false)]
        public IRasterSource Raster
        {
            get { return Datasource as IRasterSource; }
        }

        [Browsable(false)]
        public IFeatureSet FeatureSet
        {
            get { return Datasource as IFeatureSet; }
        }

        [Browsable(false)]
        public bool SelectedOnly { get; set; }
        
        [Browsable(false)]
        public bool CloseAfterRun
        {
            get { return !Opened; }
            set { throw new NotSupportedException("CloseAfterRun.set isn't supported"); }
        }

        [Browsable(false)]
        public bool Opened
        {
            get { return _layer != null; }
        }

        [Browsable(false)]
        public string Name
        {
            get { return Opened ? _layer.Name : _identity.ToString(); }
        }

        [Browsable(false)]
        public string Filename
        {
            get
            {
                if (Opened)
                {
                    return !string.IsNullOrWhiteSpace(_layer.Filename) ? _layer.Filename : Layer.Name;
                }

                return _identity.ToString();
            }
        }

        [Browsable(false)]
        public ILayer Layer
        {
            get { return _layer;  }
        }

        public string Description
        {
            get { return ToString(); }
        }

        public override string ToString()
        {
            if (_layer != null)
            {
                return Name + " " + _layer.SizeInfo;
            }
            
            return Name;
        }
    }
}
