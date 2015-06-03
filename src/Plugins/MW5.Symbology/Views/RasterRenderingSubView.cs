using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using MW5.Api.Concrete;
using MW5.Api.Enums;
using MW5.Api.Interfaces;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mvp;
using MW5.Plugins.Services;
using MW5.Plugins.Symbology.Controls.ImageCombo;
using MW5.Plugins.Symbology.Helpers;
using MW5.Plugins.Symbology.Services;
using MW5.Shared;
using MW5.UI.Helpers;

namespace MW5.Plugins.Symbology.Views
{
    public partial class RasterRenderingSubView : RasterRenderingSubViewBase, ISubView
    {
        private readonly IAppContext _context;
        private RasterColorScheme _colorScheme;

        public RasterRenderingSubView(IAppContext context)
        {
            if (context == null) throw new ArgumentNullException("context");
            _context = context;

            InitializeComponent();

            InitBuildColorSchemeGroup();

            rgbBandControl1.Top = panelColorScheme.Top;
            rgbBandControl1.Left = 0;

            colorSchemeGrid.ShowDropDowns(false);
        }

        private void InitBuildColorSchemeGroup()
        {
            chkGradientWithinCategory.CheckedChanged += chkGradientWithinCategory_CheckedChanged;

            panelSingleBand.MakeSameLocation(groupBuildColorScheme);

            cboGradientModel.AddItemsFromEnum(new List<GridGradientModel>()
            {
                GridGradientModel.Logorithmic,
                GridGradientModel.Linear,
                GridGradientModel.Exponential,
            });

            cboGradientModel.SetValue(GridGradientModel.Linear);

            cboClassification.AddItemsFromEnum<RasterClassification>();

            colorSchemeCombo1.UpdateItems();

            if (colorSchemeCombo1.Items.Count > 0)
            {
                colorSchemeCombo1.SelectedIndex = 0;
            }
        }

        private void chkGradientWithinCategory_CheckedChanged(object sender, EventArgs e)
        {
            cboGradientModel.Enabled = chkGradientWithinCategory.Checked;
            chkHillshade.Enabled = chkGradientWithinCategory.Checked;
        }

        public void Initialize()
        {
            if (Model == null)
            {
                return;
            }

            ColorScheme = Model.ActiveColorScheme;

            InitRenderModeCombo();

            cboSelectedBand.AddRasterBands(Model);

            OnChangeRenderingMode();

            cboClassification.SetValue(RasterClassification.EqualIntervals);

            rgbBandControl1.Initialize(_context, Model);

            LoadMetadata();
        }

        private void LoadMetadata()
        {
            if (Metadata == null)
            {
                return;
            }

            cboClassification.SetValue(Metadata.RasterClassification);
            chkReverseColorScheme.Checked = Metadata.RasterReverseColorScheme;
            colorSchemeCombo1.SetSelectedItem(Metadata.RasterColorScheme);
            udBreakCount.SetValue(Metadata.RasterNumCategories);
        }

        public void SaveMetadata()
        {
            if (Metadata == null)
            {
                return;
            }

            Metadata.RasterClassification = cboClassification.GetValue<RasterClassification>();
            Metadata.RasterReverseColorScheme = chkReverseColorScheme.Checked;
            Metadata.RasterColorScheme = colorSchemeCombo1.GetSelectedItem();
            Metadata.RasterNumCategories = (int)udBreakCount.Value;
        }

        internal ColorSchemeCollection ColorSchemes
        {
            get { return colorSchemeCombo1.ColorSchemes; }
        }

        public SymbologyMetadata Metadata { get; set; }

        public bool HasRgbMapping
        {
            get { return rgbBandControl1.HasMapping(); }
        }

        public ColorRamp ColorRamp
        {
            get
            {
                var blend = colorSchemeCombo1.GetSelectedItem();
                var scheme = blend.ToColorScheme();

                if (chkReverseColorScheme.Checked)
                {
                    scheme.Reverse();
                }

                return scheme;
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
                panelSingleBand.Left = 10;
                panelSingleBand.Top = rgbBandControl1.Top + rgbBandControl1.Height;
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

            cboRasterRendering.Items.Clear();

            cboRasterRendering.Items.AddRange(ComboBoxHelper.GetComboItems(list).ToArray<object>());

            cboRasterRendering.SetValue(Model.RenderingType);
        }

        public void ModelToUiRaster()
        {
            chkUseHistogram.Checked = Model.UseHistogram;
            chkAlphaRendering.Checked = Model.UseActiveBandAsAlpha;
            chkHillshade.Checked = Model.IsUsingHillshade;
            chkReverse.Checked = Model.ReverseGreyScale;

            var colorScheme = Model.ActiveColorScheme;
            chkGradientWithinCategory.Checked = colorScheme != null && colorScheme.ColorGradientWithinCategory;

            var model = Model.GradientModel;
            if (model != GridGradientModel.Mixed)
            {
                cboGradientModel.SetValue(model);
            }
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
                yield return btnEditColorSchemeList;
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
            bool showGradient = value != null && value.ColoringType != GridColoringType.Random;

            colorSchemeGrid.DataSource = null;              // to avoid flicker on setting ShowGradient
            colorSchemeGrid.ShowGradient = showGradient;

            colorSchemeGrid.DataSource = value != null ? value.ToList() : null;
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
