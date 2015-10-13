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
        private readonly WmsLayer _provider;

        public WmsSource(int id, string name)
        {
            _provider = new WmsLayer() { Id = id, Name = name };
        }

        internal WmsSource(WmsLayer provider)
        {
            if (provider == null) throw new ArgumentNullException("provider");
            _provider = provider;
        }

        public object InternalObject
        {
            get { return _provider; }
        }

        public string LastError
        {
            get { return _provider.ErrorMsg[_provider.LastErrorCode]; }
        }

        public string Tag
        {
            get { return _provider.Key;  }
            set { _provider.Key = value; }
        }

        public string Name
        {
            get { return _provider.Name; }
            set { _provider.Name = value; }
        }

        public IEnvelope BoundingBox
        {
            get
            {
                return new Envelope(_provider.BoundingBox);
            }
            set
            {
                if (value == null) throw new ArgumentNullException("value");
                var box = value.GetInternal();
                _provider.BoundingBox = box;
            }
        }

        public int Epsg
        {
            get { return _provider.Epsg; }
            set { _provider.Epsg = value; }
        }

        public string Layers
        {
            get { return _provider.Layers; }
            set { _provider.Layers = value; }
        }

        public string BaseUrl
        {
            get { return _provider.BaseUrl; }
            set { _provider.BaseUrl = value; }
        }

        public int Id
        {
            get { return _provider.Id; }
            set { _provider.Id = value; }
        }

        public string Format
        {
            get { return _provider.Format; }
            set { _provider.Format = value; }
        }

        #region ILayerSource members

        public string Serialize()
        {
            // TODO: implement
            return string.Empty;
        }

        public bool Deserialize(string state)
        {
            // TODO: implement
            return true;
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
            _provider.Close();
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
                sb.AppendLine("Bounds: " + _provider.BoundingBox.ToDebugString());
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
                var extents = _provider.MapExtents;
                return extents != null ? new Envelope(extents) : null;
            }
        }

        public ISpatialReference Projection
        {
            get
            {
                if (_provider.Epsg > 0)
                {
                    var sr = new SpatialReference();
                    if (sr.ImportFromEpsg(_provider.Epsg))
                    {
                        return sr;
                    }
                }

                return null;
            }
        }

        public bool IsEmpty
        {
            get { return _provider.IsEmpty; }
        }

        /// <summary>
        /// Gets string with the information on datasource size, i.e. number of features, pixels, etc.
        /// </summary>
        public string SizeInfo 
        {
            get { return "Bounds: " + _provider.BoundingBox.ToDebugString(); } 
        }

        #endregion
    }
}
