using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Api.Enums;
using MW5.Api.Interfaces;
using MW5.UI.Helpers;

namespace MW5.Plugins.Symbology.Controls
{
    public partial class OverviewControl : UserControl
    {
        private IRasterSource _raster;

        public OverviewControl()
        {
            InitializeComponent();

            cboOverviewSampling.AddItemsFromEnum<RasterOverviewSampling>();
            cboOverviewType.AddItemsFromEnum<RasterOverviewType>();

            cboOverviewType.SetValue(RasterOverviewType.External);
            cboOverviewSampling.SetValue(RasterOverviewSampling.Nearest);
        }
        
        public void Initialize(IRasterSource raster)
        {
            _raster = raster;

            ShowOverviews();
        }

        private void ShowOverviews()
        {
            if (_raster == null)
            {
                return;
            }

            //var list = Overviews.ToList();
            var list = PotentialOverviews.ToList();
            _overviewGrid1.DataSource = list;
        }

        private IEnumerable<OverviewScale> Overviews
        {
            get
            {
                var band = _raster.Bands[1];
                if (band != null)
                {
                    int xSize = band.XSize;
                    int ySize = band.YSize;

                    foreach (var ov in band.Overviews)
                    {
                        yield return new OverviewScale(ov.XSize, ov.YSize, xSize, ySize);
                    }
                }
            }
        }

        private IEnumerable<OverviewScale> PotentialOverviews
        {
            get
            {
                var band = _raster.Bands[1];
                if (band != null)
                {
                    int xSize = band.XSize;
                    int ySize = band.YSize;

                    foreach (var ratio in GetDefaultOverviewRatios())
                    {
                        yield return new OverviewScale(xSize, ySize, ratio);
                    }
                }
            }
        }

        private IEnumerable<int> GetDefaultOverviewRatios()
        {
            var band = _raster.Bands[1];
            if (band == null)
            {
                yield break;
            }
            
            const int maxSize = 512;

            double w = band.XSize;
            double h = band.YSize;
            int ratio = 2;
            
            while (w/2 > maxSize || h/2 > maxSize)
            {
                yield return ratio;
                w /= 2.0;
                h /= 2.0;
                ratio *= 2;
            }
        }

        private void btnClearOverviews_Click(object sender, EventArgs e)
        {
            _raster.ClearOverviews();
        }

        private void btnBuildOverviews_Click(object sender, EventArgs e)
        {
            var scales = new List<int>() { 2, 4, 8 };
            _raster.BuildOverviews(cboOverviewSampling.GetValue<RasterOverviewSampling>(), scales);
        }
    }
}
