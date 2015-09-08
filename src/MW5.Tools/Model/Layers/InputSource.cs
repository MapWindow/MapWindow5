// -------------------------------------------------------------------------------------------
// <copyright file="InputSource.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Linq;
using MW5.Api.Concrete;
using MW5.Api.Helpers;
using MW5.Api.Interfaces;
using MW5.Api.Static;

namespace MW5.Tools.Model.Layers
{
    public class InputSource : IRasterLayerInfo, IVectorLayerInfo
    {
        private readonly LayerIdentity _identity;
        private readonly ILayer _layer;
        private IDatasource _datasource;

        public InputSource(ILayer layer)
        {
            if (layer == null) throw new ArgumentNullException("layer");
            _layer = layer;
        }

        public InputSource(string filename)
        {
            var identity = new LayerIdentity(filename);
            _identity = identity;
        }

        public string Description
        {
            get { return ToString(); }
        }

        public IFeatureSet FeatureSet
        {
            get { return Datasource as IFeatureSet; }
        }

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

        public ILayer Layer
        {
            get { return _layer; }
        }

        public IRasterSource Raster
        {
            get { return Datasource as IRasterSource; }
        }

        private bool Opened
        {
            get { return _layer != null; }
        }

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

        IRasterSource IRasterLayerInfo.Datasource
        {
            get { return Raster; }
            set { throw new NotSupportedException("Raster.set isn't supported"); }
        }

        public bool CloseAfterRun
        {
            get { return !Opened; }
            set { throw new NotSupportedException("CloseAfterRun.set isn't supported"); }
        }

        public void CloseIfNeeded()
        {
            if (CloseAfterRun)
            {
                if (_datasource != null)
                {
                    _datasource.Dispose();
                    _datasource = null;
                }
            }
        }

        public string Name
        {
            get { return Opened ? _layer.Name : _identity.ToString(); }
        }

        IFeatureSet IVectorLayerInfo.Datasource
        {
            get { return FeatureSet; }
            set { throw new NotSupportedException("FeatureSet.set isn't supported"); }
        }

        public bool SelectedOnly { get; set; }

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