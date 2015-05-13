using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MapWinGIS;
using MW5.Api.Interfaces;

namespace MW5.Api.Concrete
{
    internal class RasterOverviewCollection: IRasterBandCollection
    {
        private readonly GdalRasterBand _band;

        internal RasterOverviewCollection(GdalRasterBand band)
        {
            if (band == null) throw new ArgumentNullException("band");
            _band = band;
        }

        public IEnumerator<RasterBand> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return this[i];
            }
        }

        public RasterBand this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                {
                    throw new IndexOutOfRangeException("Invalid overview index.");
                }

                var ov = _band.Overview[index];
                return ov != null ? new RasterBand(ov, index) : null;
            }
        }

        public int Count
        {
            get { return _band.OverviewCount; }
        }
    }
}
