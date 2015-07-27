using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Concrete;
using MW5.Api.Helpers;
using MW5.Api.Interfaces;
using MW5.Api.Static;

namespace MW5.Tools.Model
{
    public class LayerWrapper
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

        public ILayerSource Source
        {
            get
            {
                if (Opened)
                {
                    return _layer.LayerSource;
                }

                var ds = GeoSource.OpenFromIdentity(_identity);
                return LayerSourceHelper.GetLayers(ds).FirstOrDefault();
            }
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
            return Name;
        }
    }
}
