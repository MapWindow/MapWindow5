using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MapWinGIS;
using MW5.Api.Interfaces;

namespace MW5.Api.Concrete
{
    internal class GridBandCollection : IEnumerable<RasterBand>, IRasterBandCollection
    {
        private readonly Grid _grid;

        internal GridBandCollection(Grid grid)
        {
            if (grid == null) throw new ArgumentNullException("grid");
            _grid = grid;
        }

        public IEnumerator<RasterBand> GetEnumerator()
        {
            for (int i = 1; i <= _grid.NumBands; i++)   // bands are 1-based
            {
                yield return this[i];
            }
        }

        public RasterBand this[int index]
        {
            get
            {
                if (index < 1 || index > _grid.NumBands)
                {
                    return null;
                }

                return new RasterBand(_grid.Band[index]);
            }
        }

        public int Count
        {
            get { return _grid.NumBands; }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
