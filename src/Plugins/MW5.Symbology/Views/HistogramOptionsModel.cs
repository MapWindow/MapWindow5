using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Plugins.Symbology.Views
{
    public class HistogramOptionsModel
    {
        public HistogramOptionsModel()
        {
            
        }

        public double Mimimum { get; set; }
        public double Maximum { get; set; }
        public int NumBuckets { get; set; }
    }
}
