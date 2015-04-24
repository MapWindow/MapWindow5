using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Concrete;
using MW5.Api.Enums;
using MW5.Shared;

namespace MW5.Data.Views.Controls
{
    public class VectorLayerInfo
    {
        private readonly VectorLayer _layer;
        private bool _selected;

        public VectorLayerInfo(VectorLayer layer)
        {
            if (layer == null) throw new ArgumentNullException("layer");
            _layer = layer;
        }

        public bool Selected
        {
            get { return _selected; }
            set { _selected = value; }
        }

        public string Name
        {
            get { return _layer.Name; }
        }

        [DisplayName("Features count")]
        public int NumFeatures
        {
            get { return _layer.get_FeatureCount(); }
        }

        [DisplayName("EPSG")]
        public string Epsg
        {
            get
            {
                int epsg;
                if (_layer.Projection.TryAutoDetectEpsg(out epsg))
                {
                    return epsg.ToString();
                }
                return "<not defined>";
            }
        }
        
        [Browsable(false)]
        public GeometryType GeometryType
        {
            get { return _layer.GeometryType; }
        }

        [Browsable(false)]
        public VectorLayer Layer
        {
            get { return _layer; }
        }
    }
}
