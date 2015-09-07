using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Interfaces;

namespace MW5.Tools.Model.Layers
{
    public interface ILayerInfo
    {
        bool CloseAfterRun { get; set; }

        ILayerSource Datasource { get; set; }

        string Name { get; }
    }
}
