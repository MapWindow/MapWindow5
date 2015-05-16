using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Concrete;
using MW5.Api.Interfaces;
using MW5.Plugins.Services;

namespace MW5.Plugins.Symbology.Views
{
    public class RasterMinMaxModel
    {
        private readonly RasterBand _band;

        public RasterMinMaxModel(RasterBand band)
        {
            _band = band;

            RangeLowPercent = 2.0;
            RangeHightPercent = 98.0;
            StdDevRange = 2.0;
        }

        public void Calculate()
        {
            if (_band == null)
            {
                return;
            }

            switch (CalculationType)
            {
                case MinMaxCalculationType.Precise:
                    double min, max;
                    if (_band.ComputeMinMax(false, out min, out max))
                    {
                        Min = min;
                        Max = max;
                    }
                    break;
                case MinMaxCalculationType.StdDev:
                    var stats = _band.GetStatistics(false, true);
                    if (stats == null)
                    {
                        MessageService.Current.Warn("Failed to calculate statistics for the band.");
                        return;
                    }

                    Min = stats.Mean - StdDevRange * stats.StdDev;
                    Max = stats.Mean + StdDevRange * stats.StdDev;
                    break;
                case MinMaxCalculationType.PercentRange:
                    double bandMin = _band.Minimum;     // TODO: use compute
                    double bandMax = _band.Maximum;

                    var ht = _band.GetHistogram(bandMin, bandMax, 512);

                    int count = 0;
                    int targetCount = Convert.ToInt32(RangeLowPercent/100.0*ht.get_TotalCount());

                    Min = _band.Maximum;
                    for (int i = 0; i < 512; i++)
                    {
                        count += ht.get_Count(i);
                        if (count > targetCount)
                        {
                            Min = ht.get_Value(i);
                            break;
                        }
                    }

                    count = 0;
                    targetCount = Convert.ToInt32((1 - RangeHightPercent / 100.0) * ht.get_TotalCount());

                    Max = _band.Minimum;
                    for (int i = 511; i >= 0; i--)
                    {
                        count += ht.get_Count(i);
                        if (count > targetCount)
                        {
                            Max = ht.get_Value(i);
                            break;
                        }
                    }
                    break;
            }
        }

        public MinMaxCalculationType CalculationType { get; set; }

        public double RangeLowPercent { get; set; }
        public double RangeHightPercent { get; set; }
        public double StdDevRange { get; set; }

        public double Min { get; private set; }
        public double Max { get; private set; }
    }
}
