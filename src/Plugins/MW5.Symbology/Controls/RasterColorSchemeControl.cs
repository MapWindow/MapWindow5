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

            InitRenderModeCombo();

            cboSelectedBand.AddRasterBands(_raster);

            ChangeRenderingMode();

            cboClassification.SetValue(RasterClassification.EqualIntervals);

            rgbBandControl1.Initialize(_raster);

            groupSingleBand.Top = rgbBandControl1.Top;

            cboSingleBand.AddRasterBands(_raster);
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
                    case RasterRendering.MultiBandRgb:
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
            get
            {
                if (Rendering == RasterRendering.SingleBand)
                {
                    return cboSingleBand.SelectedIndex + 1;
                }
                
                return cboSelectedBand.SelectedIndex + 1;
            }
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
            groupPseudoColors.Visible = rendering == RasterRendering.ColorScheme;

            rasterColorSchemeGrid1.Visible = Rendering == RasterRendering.BuiltInColorTable || 
                                             Rendering == RasterRendering.ColorScheme;
            
            rgbBandControl1.Visible = Rendering == RasterRendering.MultiBandRgb;

            groupSingleBand.Visible = Rendering == RasterRendering.SingleBand;

            switch (Rendering)
            {
                case RasterRendering.MultiBandRgb:
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
                list.Add(RasterRendering.MultiBandRgb);
            }

            list.Add(RasterRendering.ColorScheme);

            if (_raster.HasBuiltInColorTable)
            {
                list.Add(RasterRendering.BuiltInColorTable);
            }

            cboRasterRendering.Items.AddRange(ComboBoxHelper.GetComboItems(list).ToArray<object>());

            cboRasterRendering.SelectedIndex = 0;
        }

        public void ModelToUiRaster()
        {
            chkUseHistogram.Checked = _raster.UseHistogram;
        }

        public void UiToModelRaster()
        {
            _raster.UseHistogram = chkUseHistogram.Checked;

            if (Rendering == RasterRendering.MultiBandRgb)
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
