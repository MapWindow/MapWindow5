using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Concrete;

namespace MW5.Api.Interfaces
{
    public interface IRasterBandCollection
    {
        IEnumerator<RasterBand> GetEnumerator();
        RasterBand this[int index] { get; }
        int Count { get; }
    }
}
