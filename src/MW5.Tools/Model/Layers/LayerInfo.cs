using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Interfaces;

namespace MW5.Tools.Model.Layers
{
    public class LayerInfo: ILayerInfo
    {
        public LayerInfo(ILayerSource source)
        {
            if (source == null) throw new ArgumentNullException("source");
            Datasource = source;
        }

        public bool CloseAfterRun { get; set; }

        public ILayerSource Datasource { get; set; }
    }
}
