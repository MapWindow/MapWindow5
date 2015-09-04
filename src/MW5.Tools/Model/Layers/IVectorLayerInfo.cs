using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Interfaces;

namespace MW5.Tools.Model.Layers
{
    public interface IVectorLayerInfo: ILayerInfo
    {
        new IFeatureSet Datasource { get; set; }

        bool SelectedOnly { get; set; }
    }
}
