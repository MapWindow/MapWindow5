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

            InitBuildColorSchemeGroup();

            rgbBandControl1.MakeSameLocation(panelColorScheme);

            colorSchemeGrid.ShowDropDowns(false);
        }

        private void InitBuildColorSchemeGroup()
        {
            panelSingleBand.MakeSameLocation(groupBuildColorScheme);

            cboGradientModel.AddItemsFromEnum<GridGradientModel>();
            cboGradientModel.SetValue(GridGradientModel.Linear);

            cboClassification.AddItemsFromEnum<RasterClassification>();

            colorSchemeCombo1.UpdateItems();

            if (colorSchemeCombo1.Items.Count > 0)
            {
                colorSchemeCombo1.SelectedIndex = 0;
            }
        }

        public void Initialize()
        {
            if (Model == null)
            {
                return;
            }

            ColorScheme = Model.CustomColorScheme;

            InitRenderModeCombo();

            cboSelectedBand.AddRasterBands(Model);

            OnChangeRenderingMode();

            cboClassification.SetValue(RasterClassification.EqualIntervals);

            rgbBandControl1.Initialize(Model);
        }

        public bool EqualCount
        {
            get { return Classification == RasterClassification.EqualCount; }
        }

        public bool HasRgbMapping
        {
            get { return rgbBandControl1.HasMapping(); }
        }

        public ColorRamp ColorRamp
        {
            get
            {
                var ramp = new ColorRamp();
                ramp.SetColors((PredefinedColors)SelectedPredefinedColorScheme);

                if (chkReverseColorScheme.Checked)
                {
                    ramp.Reverse();
                }

                return ramp;
            }
        }

        [Browsable(false)]
        public RasterColorScheme ColorScheme
        {
            get
            {
                if (_colorScheme != null)
                {
                    _colorScheme.ApplyGradientModel(GradientModel);

                    if (chkHillshade.Checked)
                    {
                        Model.AllowHillshade = true;
                    }

                    _colorScheme.ApplyColoringType(chkHillshade.Checked
                        ? GridColoringType.Hillshade
                        : GridColoringType.Gradient);
                }

                return _colorScheme;
            }
            set
            {
                SetColorSchemeCore(value);
                _colorScheme = value;
            }
        }

        public int NumBreaks
        {
            get
            {
                return (int)udBreakCount.Value;
            }
        }

        public double BandMinValue
        {
            get { return txtMinimum.DoubleValue; }
            set { txtMinimum.DoubleValue = Math.Floor(value*100.0)/100.0; }
        }

        public double BandMaxValue
        {
            get { return txtMaximum.DoubleValue; }
            set { txtMaximum.DoubleValue = Math.Ceiling(value*100.0)/100.0; }
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

        public RasterClassification Classification
        {
            get { return cboClassification.GetValue<RasterClassification>(); }
        }

        public bool GradientWithinCategory
        {
            get { return chkGradientWithinCategory.Checked; }
        }

        private GridGradientModel GradientModel
        {
            get { return cboGradientModel.GetValue<GridGradientModel>(); }
        }

        /// <summary>
        /// Sets datasource for color scheme grid.
        /// </summary>
        private void OnChangeRenderingMode()
        {
            var rendering = Rendering;
            groupMinMax.Visible = rendering != RasterRendering.Rgb;

            colorSchemeGrid.Visible = rendering == RasterRendering.BuiltInColorTable ||
                                       rendering == RasterRendering.ColorScheme;

            colorSchemeGrid.Adapter.ReadOnly = true;

            rgbBandControl1.Visible = rendering == RasterRendering.Rgb;
            groupBuildColorScheme.Visible = rendering == RasterRendering.ColorScheme;
            panelColorScheme.Visible = rendering == RasterRendering.ColorScheme ||
                                       rendering == RasterRendering.BuiltInColorTable;

            if (Rendering == RasterRendering.Rgb)
            {
                panelSingleBand.MakeSameLocation(groupMinMax);
                panelSingleBand.Left -= 20;
                panelSingleBand.Top += 5;
            }
            else
            {
                panelSingleBand.MakeSameLocation(groupBuildColorScheme);    
            }
            
            panelSingleBand.Visible = rendering != RasterRendering.ColorScheme;

            chkUseHistogram.Visible = rendering == RasterRendering.Rgb || rendering == RasterRendering.SingleBand;
            chkReverse.Visible = rendering == RasterRendering.Rgb || rendering == RasterRendering.SingleBand;
            chkAlphaRendering.Visible = rendering == RasterRendering.SingleBand;

            UpdateActiveColorScheme();
        }

        private void UpdateActiveColorScheme()
        {
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
            var list = new List<RasterRendering> {RasterRendering.SingleBand};

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
            Model.AllowGridRendering = Rendering == RasterRendering.ColorScheme ? GridRendering.ForceForAllFormats : GridRendering.Never;
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
                yield return btnGenerateColorScheme;
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

        public void SetColorSchemeCore(RasterColorScheme value)
        {
            colorSchemeGrid.DataSource = value != null ? value.ToList() : null;
            
            if (value != null)
            {
                colorSchemeGrid.ShowGradient = value.GradientWithinCategory;
            }
        }

        private void chkGradientWithinCategory_CheckStateChanged(object sender, EventArgs e)
        {
            colorSchemeGrid.ShowGradient = chkGradientWithinCategory.Checked;
        }

        private void cboClassification_SelectedIndexChanged(object sender, EventArgs e)
        {
            udBreakCount.Enabled = Classification == RasterClassification.EqualCount;
        }
    }

    public class RasterRenderingSubViewBase : SubViewBase<IRasterSource> { }
}
