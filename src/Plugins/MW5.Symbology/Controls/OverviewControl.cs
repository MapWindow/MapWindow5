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
using MW5.Api.Static;
using MW5.Plugins.Services;
using MW5.Shared;
using MW5.UI.Helpers;

namespace MW5.Plugins.Symbology.Controls
{
    public partial class OverviewControl : UserControl
    {
        private IRasterSource _raster;
        private List<OverviewScale> _overviews;

        public OverviewControl()
        {
            InitializeComponent();

            cboOverviewSampling.AddItemsFromEnum<RasterOverviewSampling>();
            cboOverviewType.AddItemsFromEnum(new[] {RasterOverviewType.External});
            cboCompression.AddItemsFromEnum<TiffCompression>();

            cboCompression.SetValue(MapConfig.CompressOverviews);
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

            _overviews = Overviews;
            _overviewGrid1.DataSource = _overviews;
        }

        private List<OverviewScale> Overviews
        {
            get
            {
                var list = ExistingOverviews.ToList();
                foreach (var item in list)
                {
                    item.Selected = true;
                }

                // now check what overviews are expected to be here and add them if they are missing
                var set = new HashSet<OverviewScale>(list);
                var candidates = PotentialOverviews.ToList();

                foreach (var item in candidates)
                {
                    if (!set.Contains(item))
                    {
                        list.Add(item);
                    }
                }

                return list;
            }
        }

        private IEnumerable<OverviewScale> ExistingOverviews
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

                    foreach (var ratio in _raster.GetDefaultOverviewRatios())
                    {
                        yield return new OverviewScale(xSize, ySize, ratio);
                    }
                }
            }
        }
        
        private void btnClearOverviews_Click(object sender, EventArgs e)
        {
            bool result = _raster.ClearOverviews();

            ShowOverviews();

            if (result)
            {
                MessageService.Current.Info("Overviews were cleared.");
            }
            else
            {
                MessageService.Current.Warn("Failed to clear overviews.");
            }
        }

        private void btnBuildOverviews_Click(object sender, EventArgs e)
        {
            var scales = _overviews.Where(item => item.Selected).Select(ov => ov.RatioCore).ToList();
            Logger.Current.Info("Scales to calculate overviews: " + string.Join(", ", scales));

            if (scales.Count == 0)
            {
                MessageService.Current.Info("No scales are chosen to calculate overviews for.");
                return;
            }

            MapConfig.CompressOverviews = cboCompression.GetValue<TiffCompression>();

            bool result = _raster.BuildOverviews(cboOverviewSampling.GetValue<RasterOverviewSampling>(), scales);
            if (result)
            {
                MessageService.Current.Info("Overviews were built.");
            }
            else
            {
                MessageService.Current.Warn("Failed to built overviews.");
            }

            ShowOverviews();
        }
    }
}
