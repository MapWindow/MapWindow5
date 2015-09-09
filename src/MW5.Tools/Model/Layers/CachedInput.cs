using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Concrete;

namespace MW5.Tools.Model.Layers
{
    /// <summary>
    /// Stores information sufficient to reopen the input datasource of a GIS task.
    /// </summary>
    public class DatasourcePointer
    {
        public DatasourcePointer(LayerIdentity identity)
        {
            if (identity == null) throw new ArgumentNullException("identity");
            LayerIdentity = identity;
            LayerHandle = -1;
        }

        public DatasourcePointer(string filename)
        {
            LayerIdentity = new LayerIdentity(filename);
            LayerHandle = -1;
        }

        public DatasourcePointer(int layerHandle)
        {
            LayerHandle = layerHandle;
        }

        /// <summary>
        /// Gets layer handler of the in-memory layer.
        /// </summary>
        public int LayerHandle { get; private set; }

        /// <summary>
        /// Gets layer identity of the file-based or database layer.
        /// </summary>
        public LayerIdentity LayerIdentity { get; private set; }
    }
}
