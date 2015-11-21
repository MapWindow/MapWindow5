using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Enums;
using MW5.Api.Helpers;
using MW5.Api.Interfaces;
using MapWinGIS;
using MW5.Shared;
using MW5.Shared.Log;

namespace MW5.Api.Concrete
{
    public class WmsSource: ILayerSource
    {
        private readonly WmsLayer _layer;

        public WmsSource(string name)
        {
            _layer = new WmsLayer() { Name = name };
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
            set
            {
                _layer.Epsg = value;
                UpdateId();
            }
        }

        public string Layers
        {
            get { return _layer.Layers; }
            set
            {
                _layer.Layers = value;
                UpdateId();
            }
        }

        public string BaseUrl
        {
            get { return _layer.BaseUrl; }
            set
            {
                _layer.BaseUrl = value;
                UpdateId();
            }
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

        public string Serialize()
        {
            return _layer.Serialize();
        }

        public bool Deserialize(string state)
        {
            return _layer.Deserialize(state);
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

        /// <summary>
        /// Assigns projection to the layer if the layer doesn't have one.
        /// </summary>
        public void AssignProjection(ISpatialReference proj)
        {
            Logger.Current.Warn("WmsSource: assign projection method isn't supported.");
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

        /// <summary>
        /// Generates Id for the provider.
        /// </summary>
        /// <remarks>The primary use of Id is for caching (both RAM and disk cache).</remarks>
        private void UpdateId()
        {
            // TODO: there is a slim chance to get duplicated Id for different providers
            // therefore adding some additional safeguards maybe necessary.
            // Storing a list which maps Ids to particular servers may be a good thing too,
            // to be able to find out what tiles in disk cache belong to particular server.
            // There is no way to do it by id only.

            // TODO: add any other properties that make cache invalid (tile size for example)
            Id = (BaseUrl + Layers + Epsg).GetHashCode();
        }

        public float Brightness
        {
            get { return _layer.Brightness; }
            set { _layer.Brightness = value; }
        }

        public float Contrast
        {
            get { return _layer.Contrast; }
            set { _layer.Contrast = value; }
        }

        public float Hue
        {
            get { return _layer.Hue; }
            set { _layer.Hue = value; }
        }

        public float Saturation
        {
            get { return _layer.Saturation; }
            set { _layer.Saturation = value; }
        }

        public float Gamma
        {
            get { return _layer.Gamma; }
            set { _layer.Gamma = value; }
        }

        public bool UseCache
        {
            get { return _layer.UseCache; }
            set { _layer.UseCache = value;  }
        }

        public bool DoCaching
        {
            get { return _layer.DoCaching; }
            set { _layer.DoCaching = value; }
        }

        public Color TransparentColor
        {
            get { return ColorHelper.UintToColor(_layer.TransparentColor); }
            set { _layer.TransparentColor = ColorHelper.ColorToUInt(value); }
        }

        public bool UseTransparentColor
        {
            get { return _layer.UseTransparentColor; }
            set { _layer.UseTransparentColor = value; }
        }

        public WmsVersion Version
        {
            get { return (WmsVersion)_layer.Version; }
            set { _layer.Version = (tkWmsVersion)value; }
        }

        public string Styles
        {
            get { return _layer.Styles; }
            set { _layer.Styles = value; }
        }
    }
}
