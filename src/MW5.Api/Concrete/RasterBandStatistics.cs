using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Api.Concrete
{
    public class RasterBandStatistics
    {
        public double Min { get; set; }
        public double Max { get; set; }
        public double Mean { get; set; }
        public double StdDev { get; set; }
    }
}
