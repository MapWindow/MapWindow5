using System;
using MapWinGIS;
using MW5.Api.Enums;
using MW5.Api.Interfaces;

namespace MW5.Api.Concrete
{
    public class RasterBand
    {
        private readonly GdalRasterBand _band;
        private readonly int _index;

        internal RasterBand(GdalRasterBand band, int index)
        {
            if (band == null) throw new ArgumentNullException("band");
            _band = band;
            _index = index;
        }

        public int Index
        {
            get { return _index; }
        }

        public double NoDataValue
        {
            get { return _band.NodataValue; }
        }

        public RasterHistogram GetDefaultHistogram(bool forceCalculate = false)
        {
            var ht = _band.GetDefaultHistogram(forceCalculate);
            return ht != null ? new RasterHistogram(ht) : null;
        }

        public RasterHistogram GetHistogram(double minValue, double maxValue, int numBuckets, bool includeOutOfRange = false, bool allowApproximate = true)
        {
            var ht = _band.GetHistogram(minValue, maxValue, numBuckets, includeOutOfRange, allowApproximate);
            return ht != null ? new RasterHistogram(ht) : null;
        }

        public double Minimum
        {
            get { return _band.Minimum; }
        }

        public double Maximum
        {
            get { return _band.Maximum; }
        }

        public GdalDataType DataType
        {
            get { return (GdalDataType)_band.DataType; }
        }

        public int XSize
        {
            get { return _band.XSize; }
        }

        public int YSize
        {
            get { return _band.YSize; }
        }

        public int BlockSizeX
        {
            get { return _band.BlockSizeX; }
        }

        public int BlockSizeY
        {
            get { return _band.BlockSizeY; }
        }

        public string UnitType
        {
            get
            {
                var type = _band.UnitType;
                return string.IsNullOrWhiteSpace(type) ? "Not set" : type;
            }
        }

        public double Scale
        {
            get { return _band.Scale; }
        }

        public double Offset
        {
            get { return _band.Offset; }
        }

        public bool HasColorTable
        {
            get { return _band.HasColorTable; }
        }

        public int MetadataCount
        {
            get { return _band.MetadataCount; }
        }

        public string get_MetadataItem(int itemIndex)
        {
            return _band.MetadataItem[itemIndex];
        }

        public RasterColorScheme ColorTable
        {
            get
            {
                var table = _band.ColorTable;
                if (table != null)
                {
                    return new RasterColorScheme(table);
                }

                return null;
            }
        }

        public ColorInterpretation ColorInterpretation
        {
            get { return (ColorInterpretation)_band.ColorInterpretation; }
            set { _band.ColorInterpretation = (tkColorInterpretation)value; }
        }

        public int[] GetUniqueValues()
        {
            object arr;
            if (_band.GetUniqueValues(10000, out arr))
            {
                return arr as int[];
            }

            return null;
        }

        public IRasterBandCollection Overviews
        {
            get { return new RasterOverviewCollection(_band); }
        }

        public RasterBandStatistics GetStatistics(bool allowApproximate, bool forceCalculation)
        {
            double min, max, mean, stdDev;

            if (_band.GetStatistics(allowApproximate, forceCalculation, out min, out max, out mean, out stdDev))
            {
                return new RasterBandStatistics()
                {
                    Min = min,
                    Max = max,
                    Mean = mean,
                    StdDev = stdDev
                };
            }

            return null;
        }

        public RasterColorScheme GenerateColorScheme(Classification classification, int numBreaks)
        {
            var scheme = _band.GenerateColorScheme((tkClassificationType) classification, numBreaks);
            return scheme != null ? new RasterColorScheme(scheme) : null;
        }
    }
}
