using System;
using System.Collections.Generic;
using System.Linq;
using MapWinGIS;
using MW5.Api.Enums;
using MW5.Api.Interfaces;

namespace MW5.Api.Concrete
{
    public class RasterSource : BitmapSource, IRasterSource
    {
        public RasterSource(Image image)
            : base(image)
        {

        }

        #region Static methods

        public static IRasterSource Open(string filename)
        {
            var img = new Image();
            if (!img.Open(filename))
            {
                throw new ApplicationException("Failed to open datasource: " + img.ErrorMsg[img.LastErrorCode]);
            }
            if (img.SourceType != tkImageSourceType.istGDALBased)
            {
                // TODO: force opening BMP files with GDAL as well for uniformity
                throw new ApplicationException("Image format isn't supported by RasterSource");
            }
            return new RasterSource(img);
        }

        #endregion

        public override double Dx
        {
            get { return _image.OriginalDX; }
            set { throw new InvalidOperationException("Dx property isn't supported for RasterSource."); }
        }

        public override double Dy
        {
            get { return _image.OriginalDY; }
            set { throw new InvalidOperationException("Dy property isn't supported for RasterSource."); }
        }

        public override int Width
        {
            get { return _image.OriginalWidth; }
        }

        public override int Height
        {
            get { return _image.OriginalHeight; }
        }

        public override double XllCenter
        {
            get { return _image.OriginalXllCenter; }
            set { throw new InvalidOperationException("XllCenter property isn't supported for RasterSource."); }
        }

        public override double YllCenter
        {
            get { return _image.OriginalYllCenter; }
            set { throw new InvalidOperationException("YllCenter property isn't supported for RasterSource."); }
        }

        public override string ToolTipText
        {
            get
            {
                string s = base.ToolTipText;
                // TODO: add number of bands
                return s;
            }
        }

        public override int NumBands
        {
            get { return _image.NoBands; }
        }

        public int NumOverviews
        {
            get { return _image.NumOverviews; }
        }

        public bool BuildOverviews(RasterOverviewSampling method, IEnumerable<int> scales)
        {
            scales = scales.ToList();
            return _image.BuildOverviews((tkGDALResamplingMethod) method, scales.Count(), scales.ToArray());
        }
    }
}
