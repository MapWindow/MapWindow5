using System;
using MapWinGIS;
using MW5.Api.Enums;
using MW5.Api.Interfaces;

namespace MW5.Api.Concrete
{
    public class RasterBand : ISimpleComWrapper
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

        public RasterColorScheme Classify(double minValue, double maxValue, Classification classification, int numBreaks)
        {
            var scheme = _band.Classify(minValue, maxValue, (tkClassificationType) classification, numBreaks);
            return scheme != null ? new RasterColorScheme(scheme) : null;
        }

        public bool ComputeMinMax(bool allowApproximate, out double min, out double max)
        {
            return _band.ComputeMinMax(allowApproximate, out min, out max);
        }

        public bool GetValue(int column, int row, out double value)
        {
            return _band.get_Value(column, row, out value);
        }

        public bool ComputeLocalStatistics(int column, int row, int range, out double min, out double max,
            out double mean, out double stdDev, out int count)
        {
            return _band.ComputeLocalStatistics(column, row, range, out min, out max, out mean, out stdDev, out count);
        }

        public object InternalObject
        {
            get { return _band; }
        }
    }
}
