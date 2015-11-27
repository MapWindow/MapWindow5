using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MapWinGIS;

namespace MW5.Api.Concrete
{
    /// <summary>
    /// Intended for direct access to the GDAL functionality without using specialized classes such as RasterSource or GridSource.
    /// </summary>
    public class GdalRasterDataset: IDisposable
    {
        private readonly GdalDataset _dataset;

        public GdalRasterDataset()
        {
            _dataset = new GdalDataset();
        }

        public bool Open(string Filename, bool readOnly)
        {
            return _dataset.Open(Filename, readOnly);
        }

        public void Close()
        {
            _dataset.Close();
        }

        public bool SetGeoTransform(double xLeft, double dX, double yProjOnX, double yTop, double xProjOnY, double dY)
        {
            return _dataset.SetGeoTransform(xLeft, dX, yProjOnX, yTop, xProjOnY, dY);
        }

        public bool SetProjection(string projection)
        {
            return _dataset.SetProjection(projection);
        }

        public GdalDriver Driver
        {
            get { return _dataset.Driver; }
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Close();
        }
    }
}
