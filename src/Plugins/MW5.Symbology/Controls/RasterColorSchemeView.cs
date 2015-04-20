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
using MW5.Api.Interfaces;
using MW5.Plugins.Symbology.Views.Abstract;
using MW5.UI.Helpers;

namespace MW5.Plugins.Symbology.Controls
{
    public partial class RasterColorSchemeView : UserControl, IRasterColorSchemeView
    {
        private RasterColorScheme _pseudoColorsScheme;
        private RasterColorScheme _colorScheme;
        private IRasterSource _raster;

        public RasterColorSchemeView()
        {
            InitializeComponent();

            colorSchemeCombo1.SelectedIndex = 0;
        }

        public void Initialize(IRasterSource raster)
        {
            _raster = raster;

            if (_raster == null)
            {
                return;
            }

            InitRenderModeCombo();

            FillBandCombo();

            ChangeRenderingMode();
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
                    case RasterRendering.MultiBand:
                        break;
                    case RasterRendering.PseudoColors:
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
        }

        public double BandMaxValue
        {
            get { return txtMaximum.DoubleValue; }
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
        private void ChangeRenderingMode()
        {
            var rendering = Rendering;
            groupPseudoColors.Visible = rendering == RasterRendering.PseudoColors;

            switch (Rendering)
            {
                case RasterRendering.SingleBand:
                case RasterRendering.MultiBand:
                    ColorScheme = null;
                    break;
                case RasterRendering.PseudoColors:
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
                list.Add(RasterRendering.MultiBand);
            }

            list.Add(RasterRendering.PseudoColors);

            if (_raster.HasBuiltInColorTable)
            {
                list.Add(RasterRendering.BuiltInColorTable);
            }

            cboRasterRendering.Items.AddRange(ComboBoxHelper.GetComboItems(list).ToArray<object>());

            cboRasterRendering.SelectedIndex = 0;
        }

        /// <summary>
        /// Fills the band combo.
        /// </summary>
        private void FillBandCombo()
        {
            cboSelectedBand.Items.Clear();

            for (int i = 1; i <= _raster.Bands.Count; i++)
            {
                var band = _raster.Bands[i];
                string bandName = "Band " + i + " (" + band.ColorInterpretation + ")";
                cboSelectedBand.Items.Add(bandName);
            }

            if (cboSelectedBand.Items.Count > 0)
            {
                cboSelectedBand.SelectedIndex = 0;
            }
        }

        public void ModelToUiRaster()
        {
            chkUseHistogram.Checked = _raster.UseHistogram;
        }

        public void UiToModelRaster()
        {
            _raster.UseHistogram = chkUseHistogram.Checked;
        }

        public IEnumerable<Control> Buttons
        {
            get
            {
                yield return btnGenerateColorScheme;
                yield return btnCalculateMinMax;
            }
        }

        private void cboSelectedBand_SelectedIndexChanged(object sender, EventArgs e)
        {
            var bandIndex = cboSelectedBand.SelectedIndex + 1;
            if (bandIndex >= 1)
            {
                var band = _raster.Bands[bandIndex];
                txtMinimum.DoubleValue = band.Minimum;
                txtMaximum.DoubleValue = band.Maximum;
            }
        }

        private void cboRasterRendering_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeRenderingMode();
        }
    }
}
