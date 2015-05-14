using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using MW5.Api.Concrete;
using MW5.Api.Enums;
using MW5.Api.Interfaces;
using MW5.Plugins.Mvp;
using MW5.Plugins.Services;
using MW5.Plugins.Symbology.Helpers;
using MW5.Shared;
using MW5.UI.Helpers;

namespace MW5.Plugins.Symbology.Views
{
    public partial class RasterRenderingSubView : RasterRenderingSubViewBase, ISubView
    {
        private RasterColorScheme _colorScheme;

        public RasterRenderingSubView() 
        {
            InitializeComponent();

            if (colorSchemeCombo1.Items.Count > 0)
            {
                colorSchemeCombo1.SelectedIndex = 0;
            }

            cboClassification.AddItemsFromEnum<RasterClassification>();

            colorSchemeCombo1.UpdateItems();
        }

        public void Initialize()
        {
            if (Model == null)
            {
                return;
            }

            ColorScheme = Model.CustomColorScheme;

            ControlHelper.MakeSameLocation(chkUseHistogram, chkHillshade);

            InitRenderModeCombo();

            cboSelectedBand.AddRasterBands(Model);

            OnChangeRenderingMode();

            cboClassification.SetValue(RasterClassification.EqualIntervals);

            rgbBandControl1.Initialize(Model);
        }

        [Browsable(false)]
        public RasterColorScheme ColorScheme
        {
            get { return _colorScheme; }
            set
            {
                SetColorSchemeCore(value);
                _colorScheme = value;
            }
        }

        public void SetColorSchemeCore(RasterColorScheme value)
        {
            rasterColorSchemeGrid1.ShowDropDowns(Rendering != RasterRendering.BuiltInColorTable);

            rasterColorSchemeGrid1.DataSource = value != null ? value.ToList() : null;
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
                    SetColorSchemeCore(null);
                    break;
                case RasterRendering.ColorScheme:
                    SetColorSchemeCore(_colorScheme);
                    break;
                case RasterRendering.BuiltInColorTable:
                    var table = Model.Bands[1].ColorTable;
                    SetColorSchemeCore(table);
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

            if (Model.NumBands > 1)
            {
                list.Add(RasterRendering.Rgb);
            }

            list.Add(RasterRendering.ColorScheme);

            if (Model.HasBuiltInColorTable)
            {
                list.Add(RasterRendering.BuiltInColorTable);
            }

            cboRasterRendering.Items.AddRange(ComboBoxHelper.GetComboItems(list).ToArray<object>());

            cboRasterRendering.SetValue(Model.RenderingType);
        }

        public void ModelToUiRaster()
        {
            chkUseHistogram.Checked = Model.UseHistogram;
            chkAlphaRendering.Checked = Model.UseActiveBandAsAlpha;
            chkHillshade.Checked = Model.GridRendering;
            chkReverse.Checked = Model.ReverseGreyScale;
        }

        public void UiToModelRaster()
        {
            Model.UseHistogram = chkUseHistogram.Checked;
            Model.UseActiveBandAsAlpha = chkAlphaRendering.Checked;
            Model.AllowGridRendering = chkHillshade.Checked ? GridRendering.ForceForAllFormats : GridRendering.Never;
            Model.ReverseGreyScale = chkReverse.Checked;

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
                yield return btnCalculateMinMax;
                yield return btnDefaultMinMax;
                yield return btnEditColorScheme;
            }
        }

        private void cboSelectedBand_SelectedIndexChanged(object sender, EventArgs e)
        {
            var bandIndex = cboSelectedBand.SelectedIndex + 1;
            if (bandIndex >= 1)
            {
                BandMinValue = Model.GetBandMinimum(bandIndex);
                BandMaxValue = Model.GetBandMaximum(bandIndex);
            }
        }

        private void cboRasterRendering_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnChangeRenderingMode();
        }

        private void btnGenerateColorScheme_Click(object sender, EventArgs e)
        {
            var scheme = new RasterColorScheme();
            scheme.SetPredefined(BandMinValue, BandMaxValue, (PredefinedColors)SelectedPredefinedColorScheme);
            ColorScheme = scheme;
        }

        public bool ValidateUserInput()
        {
            switch (Rendering)
            {
                case RasterRendering.Unknown:
                    break;
                case RasterRendering.SingleBand:
                    break;
                case RasterRendering.Rgb:
                    if (!rgbBandControl1.HasMapping())
                    {
                        MessageService.Current.Info("No RGB mapping is specified. Please select at least one of R, G, B bands.");
                        return false;
                    }
                    break;
                case RasterRendering.ColorScheme:
                    if (_colorScheme == null || _colorScheme.NumBreaks == 0)
                    {
                        MessageService.Current.Info("No color scheme is specified. Use Generate button to do it.");
                        return false;
                    }
                    break;
                case RasterRendering.BuiltInColorTable:
                    break;
            }

            return true;
        }
    }

    public class RasterRenderingSubViewBase : SubViewBase<IRasterSource> { }
}
