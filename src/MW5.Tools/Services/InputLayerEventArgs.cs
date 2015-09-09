using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Interfaces;
using MW5.Tools.Model;
using MW5.Tools.Model.Layers;

namespace MW5.Tools.Services
{
    internal class InputLayerEventArgs: EventArgs
    {
        public InputLayerEventArgs(IDatasourceInput input)
        {
            if (input == null) throw new ArgumentNullException("layer");
            Datasource = input;
        }

        public IDatasourceInput Datasource { get; private set; }
    }
}
