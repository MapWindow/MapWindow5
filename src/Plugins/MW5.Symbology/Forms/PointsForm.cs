// -------------------------------------------------------------------------------------------
// <copyright file="PointsForm.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using MW5.Api.Concrete;
using MW5.Api.Enums;
using MW5.Api.Interfaces;
using MW5.Api.Legend;
using MW5.Api.Legend.Abstract;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Symbology.Helpers;
using MW5.Plugins.Symbology.Model;
using MW5.Plugins.Symbology.Services;
using MW5.Shared;
using MW5.UI.Enums;
using MW5.UI.Forms;

namespace MW5.Plugins.Symbology.Forms
{
    public partial class PointsForm : MapWindowForm
    {
        private static int _tabIndex;

        private readonly ILegendLayer _layer;
        private readonly IMuteLegend _legend;
        private readonly IGeometryStyle _style;
        private string _initState;
        private bool _noEvents;

        /// <summary>
        /// Creates a new instance of PointsForm class
        /// </summary>
        public PointsForm(IAppContext context, ILegendLayer layer, IGeometryStyle options, bool applyDisabled) : base(context)
        {
            if (layer == null) throw new ArgumentNullException("layer");
            if (options == null) throw new ArgumentNullException("options");
            
            InitializeComponent();

            _legend = context.Legend;
            _layer = layer;
            _style = options;

            // setting values to the controls
            _initState = _style.Serialize();
            _noEvents = true;

            btnApply.Visible = !applyDisabled;

            pointIconControl1.Initialize(_style.Marker);

            dynamicVisibilityControl1.Initialize(_style, _context.Map.CurrentZoom, _context.Map.CurrentScale);
            dynamicVisibilityControl1.ValueChanged += (s, e) => {
                btnApply.Enabled = true;
                dynamicVisibilityControl1.ApplyChanges();
            };

            InitControls();

            Options2Gui();
            _noEvents = false;

            InitFonts();

            DrawPreview();

            AttachListeners();

            UpdateDefaultColor();

            tabControl1.SelectedIndex = _tabIndex;
        }

        private SymbologyMetadata Metadata
        {
            get { return SymbologyPlugin.GetMetadata(_layer.Handle); }
        }

        private void AttachListeners()
        {
            clpFillColor.SelectedColorChanged += clpFillColor_SelectedColorChanged;
            cboFillType.SelectedIndexChanged += cboFillType_SelectedIndexChanged;

            udRotation.ValueChanged += Gui2Options;
            udPointNumSides.ValueChanged += Gui2Options;
            udSideRatio.ValueChanged += Gui2Options;
            udSize.ValueChanged += Gui2Options;
            chkShowAllFonts.CheckedChanged += RefreshFontList;

            // line
            chkOutlineVisible.CheckedChanged += Gui2Options;
            icbLineType.SelectedIndexChanged += Gui2Options;
            icbLineWidth.SelectedIndexChanged += Gui2Options;
            clpOutline.SelectedColorChanged += clpOutline_SelectedColorChanged;

            chkFillVisible.CheckedChanged += Gui2Options;

            pointIconControl1.SelectedIconChanged += IconControl1SelectionChanged;
            pointIconControl1.ScaleChanged += () => Gui2Options(null, null);

            // character
            characterControl1.SelectionChanged += characterControl1_SelectionChanged;
            symbolControl1.SelectionChanged += SymbolControl1SelectionChanged;

            // hatch
            icbHatchStyle.SelectedIndexChanged += Gui2Options;
            chkFillBgTransparent.CheckedChanged += Gui2Options;
            clpHatchBack.SelectedColorChanged += Gui2Options;

            // gradient
            clpGradient2.SelectedColorChanged += Gui2Options;
            udGradientRotation.ValueChanged += Gui2Options;
            cboGradientType.SelectedIndexChanged += Gui2Options;
        }

        /// <summary>
        /// Draws preview based on the chosen options
        /// </summary>
        private void DrawPreview()
        {
            if (_noEvents)
            {
                return;
            }

            if (pctPreview.Image != null)
            {
                pctPreview.Image.Dispose();
            }

            var rect = pctPreview.ClientRectangle;
            var bmp = new Bitmap(rect.Width, rect.Height, PixelFormat.Format32bppArgb);
            var g = Graphics.FromImage(bmp);

            _style.DrawPoint(g, 0.0f, 0.0f, rect.Width, rect.Height, BackColor);

            pctPreview.Image = bmp;
        }

        /// <summary>
        /// Sets the values entered by user to the class
        /// </summary>
        private void Gui2Options(object sender, EventArgs e)
        {
            if (_noEvents)
            {
                return;
            }

            var fill = _style.Fill;
            var marker = _style.Marker;
            var line = _style.Line;

            marker.Size = (float)udSize.Value;
            marker.UpdatePictureScale(pointIconControl1.ScaleIcons, (int)udSize.Value);
            marker.Rotation = (double)udRotation.Value;
            marker.VectorMarker = (VectorMarkerType)icbPointShape.SelectedIndex;
            marker.VectorSideCount = (int)udPointNumSides.Value;
            marker.VectorMarkerSideRatio = (float)udSideRatio.Value / 10;

            if (marker.Type != MarkerType.Bitmap)
            {
                marker.Icon = null;
            }

            line.DashStyle = (DashStyle)icbLineType.SelectedIndex;
            line.Width = (float)icbLineWidth.SelectedIndex + 1;
            line.Visible = chkOutlineVisible.Checked;
            line.Transparency = transparencyControl1.Value;

            fill.Color = clpFillColor.Color;
            fill.Visible = chkFillVisible.Checked;
            fill.Type = (FillType)cboFillType.SelectedIndex;

            // hatch
            fill.HatchStyle = (HatchStyle)icbHatchStyle.SelectedIndex;
            fill.BgTransparent = chkFillBgTransparent.Checked;
            fill.BgColor = clpHatchBack.Color;

            // gradient
            fill.GradientType = (GradientType)cboGradientType.SelectedIndex;
            fill.Color2 = clpGradient2.Color;
            fill.Rotation = (double)udGradientRotation.Value;

            fill.Transparency = transparencyControl1.Value;

            // visibility
            dynamicVisibilityControl1.ApplyChanges();

            if (!_noEvents)
            {
                btnApply.Enabled = true;
            }

            DrawPreview();
        }

        /// <summary>
        /// Updates the preview with newly selected icon
        /// </summary>
        private void IconControl1SelectionChanged()
        {
            var filename = pointIconControl1.SelectedIconPath;
            if (string.IsNullOrWhiteSpace(filename) || !File.Exists(filename))
            {
                return;
            }

            var clrTransparent = Color.White;

            var img = BitmapSource.Open(filename, true);
            {
                img.TransparentColorFrom = clrTransparent;
                img.TransparentColorTo = clrTransparent;
                img.UseTransparentColor = true;

                var marker = _style.Marker;
                marker.Type = MarkerType.Bitmap;
                marker.Icon = img;
                marker.UpdatePictureScale(pointIconControl1.ScaleIcons, (int)udSize.Value);

                DrawPreview();
            }

            if (!_noEvents)
            {
                btnApply.Enabled = true;
            }
        }

        private void InitControls()
        {
            icbPointShape.ComboStyle = ImageComboStyle.PointShape;
            icbLineType.ComboStyle = ImageComboStyle.LineStyle;
            icbLineWidth.ComboStyle = ImageComboStyle.LineWidth;
            icbHatchStyle.ComboStyle = ImageComboStyle.HatchStyle;

            pnlFillPicture.Parent = groupBox3; // options
            pnlFillPicture.Top = pnlFillHatch.Top;
            pnlFillPicture.Left = pnlFillHatch.Left;

            pnlFillGradient.Parent = groupBox3; // options
            pnlFillGradient.Top = pnlFillHatch.Top;
            pnlFillGradient.Left = pnlFillHatch.Left;

            cboFillType.Items.Clear();
            cboFillType.Items.Add("Solid");
            cboFillType.Items.Add("Hatch");
            cboFillType.Items.Add("Gradient");

            cboGradientType.Items.Clear();
            cboGradientType.Items.Add("Linear");
            cboGradientType.Items.Add("Retangular");
            cboGradientType.Items.Add("Circle");
        }

        private void InitFonts()
        {
            var marker = _style.Marker;

            cboFontName.SelectedIndexChanged += cboFontName_SelectedIndexChanged;
            RefreshFontList(null, null);
            characterControl1.SelectedCharacterCode = (byte)marker.FontCharacter;
        }

        /// <summary>
        /// Saves options and redraws map without closing the form
        /// </summary>
        private void OnApplyClick(object sender, EventArgs e)
        {
            RefreshCategories();

            _legend.Redraw(LegendRedraw.LegendAndMap);

            btnApply.Enabled = false;
            _initState = _style.Serialize();
        }

        /// <summary>
        /// Reverts changes and closes the form
        /// </summary>
        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.Cancel)
            {
                _tabIndex = tabControl1.SelectedIndex;
                _style.Deserialize(_initState);
            }
        }

        /// <summary>
        /// Loads the values of the class instance to the controls
        /// </summary>
        private void Options2Gui()
        {
            _noEvents = true;

            var marker = _style.Marker;
            udSize.SetValue(marker.Size);
            udRotation.SetValue(marker.Rotation);
            clpFillColor.Color = _style.Fill.Color;

            // point
            icbPointShape.SelectedIndex = (int)marker.VectorMarker;
            udPointNumSides.SetValue(marker.VectorSideCount);
            udSideRatio.SetValue(marker.VectorMarkerSideRatio * 10.0);

            // options
            icbLineType.SelectedIndex = (int)_style.Line.DashStyle;
            icbLineWidth.SelectedIndex = (int)_style.Line.Width - 1;
            cboFillType.SelectedIndex = (int)_style.Fill.Type;
            chkOutlineVisible.Checked = _style.Line.Visible;
            clpOutline.Color = _style.Line.Color;
            chkFillVisible.Checked = _style.Fill.Visible;

            // hatch
            icbHatchStyle.SelectedIndex = (int)_style.Fill.HatchStyle;
            chkFillBgTransparent.Checked = _style.Fill.BgTransparent;
            clpHatchBack.Color = _style.Fill.BgColor;

            // gradient
            cboGradientType.SelectedIndex = (int)_style.Fill.GradientType;
            clpGradient2.Color = _style.Fill.Color2;
            udGradientRotation.Value = (decimal)_style.Fill.Rotation;

            transparencyControl1.Value = _style.Fill.Transparency;

            _noEvents = false;
        }

        private void RefreshCategories()
        {
            if (_layer.FeatureSet.Style.InternalObject == _style.InternalObject)
            {
                _layer.FeatureSet.ApplyDefaultStyleToCategories();
            }
        }

        /// <summary>
        /// Refreshes the list of fonts
        /// </summary>
        private void RefreshFontList(object sender, EventArgs e)
        {
            cboFontName.Items.Clear();

            if (!chkShowAllFonts.Checked)
            {
                foreach (var family in FontFamily.Families)
                {
                    string name = family.Name.ToLower();

                    if (name == "webdings" || name == "wingdings" || name == "wingdings 2" || name == "wingdings 3" || name == "times new roman")
                    {
                        cboFontName.Items.Add(family.Name);
                    }
                }
            }
            else
            {
                foreach (var family in FontFamily.Families)
                {
                    cboFontName.Items.Add(family.Name);
                }
            }

            RestoreSelectedFont();
        }

        private void RestoreSelectedFont()
        {
            var fontName = _style.Marker.FontName;

            foreach (var item in cboFontName.Items)
            {
                if (item.ToString().EqualsIgnoreCase(fontName))
                {
                    cboFontName.SelectedItem = item;
                    break;
                }
            }

            if (cboFontName.SelectedIndex == -1)
            {
                cboFontName.SelectedItem = "Arial";
            }
        }

        /// <summary>
        /// Changes the chosen point symbol
        /// </summary>
        private void SymbolControl1SelectionChanged()
        {
            var symbol = (VectorMarker)symbolControl1.SelectedIndex;
            _style.Marker.SetVectorMarker(symbol);
            _style.Marker.Icon = null;

            if (!_noEvents)
            {
                btnApply.Enabled = true;
            }

            Options2Gui();
            DrawPreview();
        }

        private void UpdateDefaultColor()
        {
            symbolControl1.ForeColor = clpFillColor.Color;
            characterControl1.ForeColor = clpFillColor.Color;
            icbPointShape.Color1 = clpFillColor.Color;
        }

        /// <summary>
        /// Saves the selected page
        /// </summary>
        private void btnOk_Click(object sender, EventArgs e)
        {
            _tabIndex = tabControl1.SelectedIndex;

            RefreshCategories();

            if (_style.Serialize() != _initState)
            {
                _legend.Redraw(LegendRedraw.LegendAndMap);
            }
        }

        /// <summary>
        /// Toggles fill type oprions
        /// </summary>
        private void cboFillType_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlFillGradient.Visible = false;
            pnlFillHatch.Visible = false;
            pnlFillPicture.Visible = false;
            lblNoOptions.Visible = false;

            var fill = _style.Fill;
            if (cboFillType.SelectedIndex == (int)FillType.Hatch)
            {
                pnlFillHatch.Visible = true;
                fill.Type = FillType.Hatch;
            }
            else if (cboFillType.SelectedIndex == (int)FillType.Gradient)
            {
                pnlFillGradient.Visible = true;
                fill.Type = FillType.Gradient;
            }
            else if (cboFillType.SelectedIndex == (int)FillType.Picture)
            {
                pnlFillPicture.Visible = true;
                fill.Type = FillType.Picture;
            }
            else
            {
                lblNoOptions.Visible = true;
                fill.Type = FillType.Solid;
            }

            if (!_noEvents)
            {
                btnApply.Enabled = true;
            }

            DrawPreview();
        }

        /// <summary>
        /// Changing the font in the font control
        /// </summary>
        private void cboFontName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_noEvents)
            {
                btnApply.Enabled = true;
            }

            characterControl1.SetFontName(cboFontName.Text);
            _style.Marker.FontName = cboFontName.Text;

            DrawPreview();
        }

        /// <summary>
        /// Updates the preview with the newly selected character
        /// </summary>
        private void characterControl1_SelectionChanged()
        {
            if (!_noEvents)
            {
                btnApply.Enabled = true;
            }

            var marker = _style.Marker;
            marker.Type = MarkerType.FontCharacter;
            marker.FontCharacter = Convert.ToChar(characterControl1.SelectedCharacterCode);
            marker.Icon = null;

            DrawPreview();
        }

        /// <summary>
        /// Updates all the controls with the selected fill color
        /// </summary>
        private void clpFillColor_SelectedColorChanged(object sender, EventArgs e)
        {
            _style.Fill.Color = clpFillColor.Color;

            UpdateDefaultColor();

            if (!_noEvents) btnApply.Enabled = true;

            DrawPreview();
        }

        /// <summary>
        ///  Updates all the control with the selected outline color
        /// </summary>
        private void clpOutline_SelectedColorChanged(object sender, EventArgs e)
        {
            _style.Line.Color = clpOutline.Color;

            UpdateDefaultColor();

            if (!_noEvents) btnApply.Enabled = true;

            DrawPreview();
        }

        /// <summary>
        /// Changes the transparency
        /// </summary>
        private void transparencyControl1_ValueChanged(object sender, byte value)
        {
            Gui2Options(null, null);
        }

        private void PointsForm_Load(object sender, EventArgs e)
        {
            // Fixing CORE-160
            CaptionFont = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
        }
    }
}