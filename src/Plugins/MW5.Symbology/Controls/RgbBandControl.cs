using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Api.Concrete;
using MW5.Api.Enums;
using MW5.Api.Interfaces;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Symbology.Helpers;
using MW5.Plugins.Symbology.Views;
using MW5.UI.Helpers;
using Syncfusion.Windows.Forms;
using Syncfusion.Windows.Forms.Tools;

namespace MW5.Plugins.Symbology.Controls
{
    // TODO: split into view and presentation
    public partial class RgbBandControl : UserControl
    {
        private IAppContext _context;
        private IRasterSource _raster;
        private readonly Dictionary<RgbChannel, BandInfo> _dict = new Dictionary<RgbChannel, BandInfo>();

        public RgbBandControl()
        {
            InitializeComponent();

            InitBandInfo();
        }

        private void InitBandInfo()
        {
            _dict.Add(RgbChannel.Red, new BandInfo(txtMinRed, txtMaxRed, cboRed));
            _dict.Add(RgbChannel.Green, new BandInfo(txtMinGreen, txtMaxGreen, cboGreen));
            _dict.Add(RgbChannel.Blue, new BandInfo(txtMinBlue, txtMaxBlue,cboBlue));

            cboRed.Tag = RgbChannel.Red;
            cboGreen.Tag = RgbChannel.Green;
            cboBlue.Tag = RgbChannel.Blue;

            btnRedDefault.Tag = RgbChannel.Red;
            btnGreenDefault.Tag = RgbChannel.Green;
            btnBlueDefault.Tag = RgbChannel.Blue;

            btnRedCustom.Tag = RgbChannel.Red;
            btnGreenCustom.Tag = RgbChannel.Green;
            btnBlueCustom.Tag = RgbChannel.Blue;
        }

        public void Initialize(IAppContext context, IRasterSource raster)
        {
            if (raster == null) throw new ArgumentNullException("raster");
            if (context == null) throw new ArgumentNullException("raster");
            _context = context;
            _raster = raster;

            InitComboBoxes();
        }

        public IEnumerable<ComboBoxAdv> BandCombos
        {
            get
            {
                ComboBoxAdv[] combos = 
                {
                    cboRed, cboGreen, cboBlue
                };

                return combos.Where(item => item.SelectedIndex != -1);
            }
        }

        public void ApplyChanges()
        {
            _raster.RedBandIndex = cboRed.SelectedIndex;
            _raster.GreenBandIndex = cboGreen.SelectedIndex;
            _raster.BlueBandIndex = cboBlue.SelectedIndex;
            _raster.AlphaBandIndex = cboAlpha.SelectedIndex;

            _raster.UseRgbBandMapping = true;

            if (chkCustomMinMax.Checked)
            {
                foreach (var combo in BandCombos)
                {
                    var bandInfo = GetBandInfo(combo);
                    _raster.SetBandMinMax(combo.SelectedIndex, bandInfo.Min.DoubleValue, bandInfo.Max.DoubleValue);
                }
            }
        }

        private void InitComboBoxes()
        {
            cboRed.AddRasterBands(_raster, true);
            cboRed.SetSelectedIndexSafe(_raster.RedBandIndex);

            cboGreen.AddRasterBands(_raster, true);
            cboGreen.SetSelectedIndexSafe(_raster.GreenBandIndex);

            cboBlue.AddRasterBands(_raster, true);
            cboBlue.SetSelectedIndexSafe(_raster.BlueBandIndex);

            cboAlpha.AddRasterBands(_raster, true);
            cboAlpha.SetSelectedIndexSafe(_raster.AlphaBandIndex);
        }

        private void ClearMapping()
        {
            cboRed.SetSelectedIndexSafe(0);
            cboGreen.SetSelectedIndexSafe(0);
            cboBlue.SetSelectedIndexSafe(0);
            cboAlpha.SetSelectedIndexSafe(0);
        }

        public bool HasMapping()
        {
            return cboRed.SelectedIndex != 0 || cboBlue.SelectedIndex != 0 || cboGreen.SelectedIndex != 0;
        }

        private void chkCustomMinMax_CheckedChanged(object sender, EventArgs e)
        {
            panel1.Visible = chkCustomMinMax.Checked;
        }

        private void SelectedBandChanged(object sender, EventArgs e)
        {
            var combo = sender as ComboBoxAdv;
            if (combo == null || combo.Tag == null)
            {
                return;
            }

            var bandInfo = _dict[(RgbChannel) combo.Tag];
            int bandIndex = combo.SelectedIndex;
            
            bandInfo.Min.DoubleValue = bandIndex > 0 ? _raster.GetBandMinimum(bandIndex) : double.NaN;
            bandInfo.Max.DoubleValue = bandIndex > 0 ? _raster.GetBandMaximum(bandIndex) : double.NaN;

            bandInfo.Min.Enabled = bandIndex > 0;
            bandInfo.Max.Enabled = bandIndex > 0;
        }
        
        private void SetBandMinMax(object sender, bool custom)
        {
            var btn = sender as ButtonAdv;
            if (btn == null)
            {
                return;
            }

            SetMinMax(GetBandInfo(btn), custom);
        }

        private void SetMinMax(BandInfo bandInfo, bool custom)
        {
            if (bandInfo == null)
            {
                return;
            }

            var band = GetBand(bandInfo.Combo);
            if (band == null)
            {
                return;
            }
            
            if (custom)
            {
                var model = new RasterMinMaxModel(band);
                if (_context.Container.Run<RasterMinMaxPresenter, RasterMinMaxModel>(model, ParentForm))
                {
                    bandInfo.Min.DoubleValue = model.Min;
                    bandInfo.Max.DoubleValue = model.Max;
                }
            }
            else
            {
                ComputeBandMinMax(band, bandInfo);
            }
        }

        private RasterBand GetBand(ComboBoxAdv combo)
        {
            if (combo.SelectedIndex == 0)
            {
                return null;
            }

            return _raster.Bands[combo.SelectedIndex];
        }

        private BandInfo GetBandInfo(Control control)
        {
            if (control != null && control.Tag != null)
            {
                return _dict[(RgbChannel) control.Tag];
            }

            return null;
        }

        private void ComputeBandMinMax(RasterBand band, BandInfo bandInfo)
        {
            if (band == null || bandInfo == null)
            {
                return;
            }

            double min, max;
            if (band.ComputeMinMax(false, out min, out max))
            {
                bandInfo.Min.DoubleValue = min;
                bandInfo.Max.DoubleValue = max;
            }
        }

        private void SetAllDefaultClick(object sender, EventArgs e)
        {
            foreach (var combo in BandCombos)
            {
                ComputeBandMinMax(GetBand(combo), GetBandInfo(combo));
            }
        }

        private bool GetCalculationType(out MinMaxCalculationType calculationType)
        {
            var model = new RasterMinMaxModel(null);
            if (_context.Container.Run<RasterMinMaxPresenter, RasterMinMaxModel>(model, ParentForm))
            {
                calculationType = model.CalculationType;
                return true;
            }

            calculationType = MinMaxCalculationType.Precise;
            return false;
        }

        private void BandSetDefaultClick(object sender, EventArgs e)
        {
            SetBandMinMax(sender, false);
        }

        private void BandSetCustomClick(object sender, EventArgs e)
        {
            SetBandMinMax(sender, true);
        }

        private void SetAllCustomClick(object sender, EventArgs e)
        {
            MinMaxCalculationType calculationType;
            if (!GetCalculationType(out calculationType))
            {
                return;
            }

            foreach (var combo in BandCombos)
            {
                var band = GetBand(combo);
                var bandInfo = GetBandInfo(combo);

                var model = new RasterMinMaxModel(band) {CalculationType = calculationType};
                model.Calculate();

                bandInfo.Min.DoubleValue = model.Min;
                bandInfo.Max.DoubleValue = model.Max;
            }
        }

        private void SetDefaultMappingClick(object sender, EventArgs e)
        {
            ClearMapping();

            foreach (var band in _raster.Bands)
            {
                switch (band.ColorInterpretation)
                {
                    case ColorInterpretation.RedBand:
                        cboRed.SetSelectedIndexSafe(band.Index);
                        break;
                    case ColorInterpretation.GreenBand:
                        cboGreen.SetSelectedIndexSafe(band.Index);
                        break;
                    case ColorInterpretation.BlueBand:
                        cboBlue.SetSelectedIndexSafe(band.Index);
                        break;
                    case ColorInterpretation.AlphaBand:
                        cboAlpha.SetSelectedIndexSafe(band.Index);
                        break;
                }
            }
        }

        private void ClearMappingClick(object sender, EventArgs e)
        {
            ClearMapping();
        }

        private class BandInfo
        {
            public BandInfo(DoubleTextBox min, DoubleTextBox max, ComboBoxAdv combo)
            {
                Min = min;
                Max = max;
                Combo = combo;
            }

            public DoubleTextBox Min { get; set; }
            public DoubleTextBox Max { get; set; }
            public ComboBoxAdv Combo { get; set; }
        }

    }
}
