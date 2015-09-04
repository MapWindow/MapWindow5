using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Interfaces;

namespace MW5.Tools.Model.Layers
{
    public interface IRasterLayerInfo: ILayerInfo
    {
        new IRasterSource Datasource { get; set; }
    }
}
