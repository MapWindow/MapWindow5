using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Enums;
using MW5.Api.Helpers;
using MW5.Api.Interfaces;
using MapWinGIS;
using MW5.Shared.Log;

namespace MW5.Api.Concrete
{
    public class WmsSource: ILayerSource
    {
        private readonly WmsLayer _layer;

        public WmsSource(int id, string name)
        {
            _layer = new WmsLayer() { Id = id, Name = name };
        }

        internal WmsSource(WmsLayer provider)
        {
            if (provider == null) throw new ArgumentNullException("provider");
            _layer = provider;
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
            get { return _layer.Key;  }
            set { _layer.Key = value; }
        }

        public string Name
        {
            get { return _layer.Name; }
            set { _layer.Name = value; }
        }

        public IEnvelope BoundingBox
        {
            get
            {
                return new Envelope(_layer.BoundingBox);
            }
            set
            {
                if (value == null) throw new ArgumentNullException("value");
                var box = value.GetInternal();
                _layer.BoundingBox = box;
            }
        }

        public int Epsg
        {
            get { return _layer.Epsg; }
            set { _layer.Epsg = value; }
        }

        public string Layers
        {
            get { return _layer.Layers; }
            set { _layer.Layers = value; }
        }

        public string BaseUrl
        {
            get { return _layer.BaseUrl; }
            set { _layer.BaseUrl = value; }
        }

        public int Id
        {
            get { return _layer.Id; }
            set { _layer.Id = value; }
        }

        public string Format
        {
            get { return _layer.Format; }
            set { _layer.Format = value; }
        }

        #region ILayerSource members

        public string Serialize()
        {
            throw new NotImplementedException();
        }

        public bool Deserialize(string state)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Close();
        }

        public string Filename
        {
            get { return string.Empty; }
        }

        public void Close()
        {
            _layer.Close();
        }

        public string OpenDialogFilter
        {
            get { return "WMS definition (*.xml)|*.xml"; }
        }

        public LayerType LayerType
        {
            get { return LayerType.WmsLayer; }
        }

        public string ToolTipText
        {
            get
            {
                var sb = new StringBuilder("Coordinate system: " + Projection);
                sb.AppendLine("Bounds: " + _layer.BoundingBox.ToDebugString());
                return sb.ToString();
            }
        }

        public bool IsVector
        {
            get { return false; }
        }

        public bool IsRaster
        {
            get { return false; }
        }

        // not supported
        public IGlobalListener Callback
        {
            get { return null; }
            set { }
        }

        public IEnvelope Envelope
        {
            get
            {
                var extents = _layer.MapExtents;
                return extents != null ? new Envelope(extents) : null;
            }
        }

        public ISpatialReference Projection
        {
            get
            {
                var gp = _layer.GeoProjection;
                return gp != null ? new SpatialReference(gp) : null;
            }
        }

        public byte Opacity
        {
            get { return _layer.Opacity;  }
            set { _layer.Opacity = value; }
        }

        public bool IsEmpty
        {
            get { return _layer.IsEmpty; }
        }

        /// <summary>
        /// Gets string with the information on datasource size, i.e. number of features, pixels, etc.
        /// </summary>
        public string SizeInfo 
        {
            get { return "Bounds: " + _layer.BoundingBox.ToDebugString(); } 
        }

        #endregion
    }
}
