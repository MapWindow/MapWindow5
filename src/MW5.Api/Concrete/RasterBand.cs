using System;
using MapWinGIS;
using MW5.Api.Enums;

namespace MW5.Api.Concrete
{
    public class RasterBand
    {
        private GdalRasterBand _band;

        internal RasterBand(GdalRasterBand band)
        {
            if (band == null) throw new ArgumentNullException("band");
            _band = band;
        }

        public double NoDataValue
        {
            get { return _band.NodataValue; }
        }

        public double Minimum
        {
            get { return _band.Minimum; }
        }

        public double Maximum
        {
            get { return _band.Maximum; }
        }

        public int OverviewCount
        {
            get { return _band.OverviewCount; }
        }

        public ColorInterpretation ColorInterpretation
        {
            get { return (ColorInterpretation)_band.ColorInterpretation; }
            set { _band.ColorInterpretation = (tkColorInterpretation)value; }
        }
    }
}
