using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MapWinGIS;

namespace MW5.Api.Concrete
{
    public class RasterHistogram
    {
        private readonly IHistogram _histogram;

        internal RasterHistogram(IHistogram histogram)
        {
            if (histogram == null) throw new ArgumentNullException("histogram");
            _histogram = histogram;
        }

        public int NumBuckets
        {
            get { return _histogram.NumBuckets; }
        }

        public double MinValue
        {
            get { return _histogram.MinValue; }
        }

        public double MaxValue
        {
            get { return _histogram.MaxValue; }
        }

        public int get_Count(int bucketIndex)
        {
            return _histogram.Count[bucketIndex];
        }

        public double get_Value(int bucketIndex)
        {
            return _histogram.Value[bucketIndex];
        }

        public int get_TotalCount()
        {
            int count = 0;
            for (int i = 0; i < NumBuckets; i++)
            {
                count += get_Count(i);
            }

            return count;
        }
    }
}
