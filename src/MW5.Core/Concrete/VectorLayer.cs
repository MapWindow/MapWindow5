using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MapWinGIS;
using MW5.Core.Interfaces;

namespace MW5.Core.Concrete
{
    public class VectorLayer: IVectorLayer
    {
        private readonly OgrLayer _layer;

        public VectorLayer(OgrLayer layer)
        {
            _layer = layer;
            if (layer == null)
            {
                throw new NullReferenceException("Internal style reference is null.");
            }
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
            get { return _layer.Key; }
            set { _layer.Key = value; }
        }

        public string Serialize()
        {
            return _layer.Serialize();
        }

        public bool Deserialize(string state)
        {
            return _layer.Deserialize(state);
        }

        public IEnvelope Envelope
        {
            get
            {
                Extents extents;
                if (_layer.get_Extents(out extents))
                {
                    return new Envelope(extents);
                }
                return null;
            }
        }

        public string Filename
        {
            get { return _layer.GetConnectionString(); }
        }

        public SpatialReference SpatialReference
        {
            get { return new SpatialReference(_layer.GeoProjection); }
        }

        public bool IsEmpty
        {
            get { return _layer.FeatureCount == 0; }
        }

        public void Close()
        {
            _layer.Close();
        }

        public string OpenDialogFilter
        {
            get
            {
                return GeoSourceManager.VectorFilter;
            }
        }
    }
}
