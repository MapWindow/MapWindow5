using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MapWinGIS;
using MW5.Core.Concrete;
using MW5.Core.Interfaces;

namespace MW5.Core.Helpers
{
    public static class LayerSourceHelper
    {
        public static IDatasource Convert(object source)
        {
            if (source is Shapefile)
            {
                return new FeatureSet(source as Shapefile);
            }
            if (source is Image)
            {
                return BitmapSource.Wrap(source as Image);
            }
            if (source is OgrLayer)
            {
                return new VectorLayer(source as OgrLayer);
            }
            if (source is OgrDatasource)
            {
                return new VectorDatasource(source as OgrDatasource);
            }
            if (source is Grid)
            {
                // TODO: implement
                return null;
            }
            return null;
        }
    }
}
