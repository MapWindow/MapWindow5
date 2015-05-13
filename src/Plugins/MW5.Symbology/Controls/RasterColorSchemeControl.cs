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
using MW5.Plugins.Mvp;
using MW5.Plugins.Symbology.Helpers;
using MW5.Plugins.Symbology.Views;
using MW5.Plugins.Symbology.Views.Abstract;
using MW5.Shared;
using MW5.UI.Helpers;

namespace MW5.Plugins.Symbology.Controls
{
    public partial class RasterColorSchemeControl : UserControl, IRasterColorSchemeView, IMenuProvider
    {
        private RasterColorScheme _pseudoColorsScheme;
        private RasterColorScheme _colorScheme;
        private IRasterSource _raster;

        public RasterColorSchemeControl()
        {
            InitializeComponent();

            if (colorSchemeCombo1.Items.Count > 0)
            {
                colorSchemeCombo1.SelectedIndex = 0;
            }

            cboClassification.AddItemsFromEnum<RasterClassification>();
        }

        public void Initialize(IRasterSource raster)
        {
            _raster = raster;

            if (_raster == null)
            {
                return;
            }

            ControlHelper.MakeSameLocation(chkUseHistogram, chkHillshade);

            InitRenderModeCombo();

            cboSelectedBand.AddRasterBands(_raster);

            OnChangeRenderingMode();

            cboClassification.SetValue(RasterClassification.EqualIntervals);

            rgbBandControl1.Initialize(_raster);
        }

        [Browsable(false)]
        public RasterColorScheme ColorScheme
        {
            get { return _colorScheme; }
            set
            {
                _colorScheme = value;
                
                rasterColorSchemeGrid1.ShowDropDowns(Rendering != RasterRendering.BuiltInColorTable);

                rasterColorSchemeGrid1.DataSource = value != null ? value.ToList() : null;

                switch (Rendering)
                {
                    case RasterRendering.SingleBand:
                    case RasterRendering.BuiltInColorTable:
                    case RasterRendering.Rgb:
                        break;
                    case RasterRendering.ColorScheme:
                        _pseudoColorsScheme = value;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        public double BandMinValue
        {
            get { return txtMinimum.DoubleValue; }
            set
            {
                txtMinimum.DoubleValue = Math.Floor(value * 100.0) / 100.0;
            }
        }

        public double BandMaxValue
        {
            get { return txtMaximum.DoubleValue; }
            set
            {
                txtMaximum.DoubleValue = Math.Ceiling(value * 100.0) / 100.0; ;
            }
        }

        public int SelectedPredefinedColorScheme
        {
            get { return colorSchemeCombo1.SelectedIndex; }
        }

        public int ActiveBandIndex
        {
            get { return cboSelectedBand.SelectedIndex + 1; }
        }

        public RasterRendering Rendering
        {
            get { return cboRasterRendering.GetValue<RasterRendering>(); }
        }

        /// <summary>
        /// Sets datasource for color scheme grid.
        /// </summary>
        private void OnChangeRenderingMode()
        {
            var rendering = Rendering;
            groupMinMax.Visible = rendering != RasterRendering.Rgb;

            rasterColorSchemeGrid1.Visible = rendering == RasterRendering.BuiltInColorTable || 
                                             rendering == RasterRendering.ColorScheme;
            
            rgbBandControl1.Visible = rendering == RasterRendering.Rgb;
            groupColorScheme.Visible = rendering == RasterRendering.ColorScheme;

            chkHillshade.Visible = rendering == RasterRendering.ColorScheme;

            chkUseHistogram.Visible = rendering == RasterRendering.Rgb || rendering == RasterRendering.SingleBand;
            chkReverse.Visible = rendering == RasterRendering.Rgb || rendering == RasterRendering.SingleBand;
            chkAlphaRendering.Visible = rendering == RasterRendering.SingleBand;

            switch (Rendering)
            {
                case RasterRendering.Rgb:
                case RasterRendering.SingleBand:
                    ColorScheme = null;
                    break;
                case RasterRendering.ColorScheme:
                    ColorScheme = _pseudoColorsScheme;
                    break;
                case RasterRendering.BuiltInColorTable:
                    var table = _raster.Bands[1].ColorTable;
                    ColorScheme = table;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        /// Initializes the rendering mode combo box.
        /// </summary>
        private void InitRenderModeCombo()
        {
            var list = new List<RasterRendering> { RasterRendering.SingleBand };

            if (_raster.NumBands > 1)
            {
                list.Add(RasterRendering.Rgb);
            }

            list.Add(RasterRendering.ColorScheme);

            if (_raster.HasBuiltInColorTable)
            {
                list.Add(RasterRendering.BuiltInColorTable);
            }

            cboRasterRendering.Items.AddRange(ComboBoxHelper.GetComboItems(list).ToArray<object>());

            cboRasterRendering.SetValue(_raster.RenderingType);
        }

        public void ModelToUiRaster()
        {
            chkUseHistogram.Checked = _raster.UseHistogram;
            chkAlphaRendering.Checked = _raster.UseActiveBandAsAlpha;
            chkHillshade.Checked = _raster.GridRendering;
            chkReverse.Checked = _raster.ReverseGreyScale;
        }

        public void UiToModelRaster()
        {
            _raster.UseHistogram = chkUseHistogram.Checked;
            _raster.UseActiveBandAsAlpha = chkAlphaRendering.Checked;
            _raster.AllowGridRendering = chkHillshade.Checked ? GridRendering.ForceForAllFormats : GridRendering.Never;
            _raster.ReverseGreyScale = chkReverse.Checked;

            if (Rendering == RasterRendering.Rgb)
            {
                rgbBandControl1.ApplyChanges();
            }
        }

        public IEnumerable<ToolStripItemCollection> ToolStrips
        {
            get { yield break; }
        }

        public IEnumerable<Control> Buttons
        {
            get
            {
                yield return btnGenerateColorScheme;
                yield return btnCalculateMinMax;
                yield return btnDefaultMinMax;
            }
        }

        private void cboSelectedBand_SelectedIndexChanged(object sender, EventArgs e)
        {
            var bandIndex = cboSelectedBand.SelectedIndex + 1;
            if (bandIndex >= 1)
            {
                BandMinValue = _raster.GetBandMinimum(bandIndex);
                BandMaxValue = _raster.GetBandMaximum(bandIndex);
            }
        }

        private void cboRasterRendering_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnChangeRenderingMode();
        }
    }
}
