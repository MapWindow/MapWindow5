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
    internal class ImageBandCollection: IEnumerable<RasterBand>, IRasterBandCollection
    {
        private readonly Image _image;

        internal ImageBandCollection(Image image)
        {
            if (image == null) throw new ArgumentNullException("image");
            _image = image;
        }

        public IEnumerator<RasterBand> GetEnumerator()
        {
            for (int i = 1; i <= _image.NoBands; i++)   // bands are 1-based
            {
                yield return this[i];
            }
        }

        public RasterBand this[int index]
        {
            get
            {
                if (index < 1 || index > _image.NoBands)
                {
                    return null;
                }

                return new RasterBand(_image.Band[index]);
            }
        }

        public int Count
        {
            get { return _image.NoBands; }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
