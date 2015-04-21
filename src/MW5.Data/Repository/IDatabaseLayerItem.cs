using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Concrete;
using MW5.Api.Enums;
using MW5.Api.Interfaces;

namespace MW5.Data.Repository
{
    public interface IDatabaseLayerItem: ILayerItem
    {
        string Connection { get; }
        string Name { get; }
        GeometryType GeometryType { get; }
        int NumFeatures { get; }
        ISpatialReference Projection { get; }
    }
}
