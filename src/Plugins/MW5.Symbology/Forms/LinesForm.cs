// -------------------------------------------------------------------------------------------
// <copyright file="LinesForm.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;
using MW5.Api.Concrete;
using MW5.Api.Enums;
using MW5.Api.Interfaces;
using MW5.Api.Legend;
using MW5.Api.Legend.Abstract;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Symbology.Helpers;
using MW5.UI.Enums;
using MW5.UI.Forms;

namespace MW5.Plugins.Symbology.Forms
{
    public partial class LinesForm : MapWindowForm
    {
        // column indices for the grid
        private const int CMN_PICTURE = 0;
        private const int CMN_TYPE = 1;
        private static int _tabIndex;

        private readonly IMuteLegend _legend;
        private readonly ILegendLayer _layer;
        private readonly IGeometryStyle _style;
        private string _initState;
        private bool _noEvents;

        /// <summary>
        /// Creates a new instance of PolygonsForm class
        /// </summary>
        public LinesForm(IAppContext _context, ILegendLayer layer, IGeometryStyle style, bool applyDisabled) : base(_context)
        {
            if (layer == null) throw new ArgumentNullException("layer");
            if (style == null) throw new ArgumentNullException("style");

            InitializeComponent();

            _style = style;
            _legend = _context.Legend;
            _layer = layer;
            _initState = style.Serialize();

            btnApply.Visible = !applyDisabled;

            Initialize();
        }

        private void Initialize()
        {
            icbLineType.ComboStyle = ImageComboStyle.LineStyle;
            icbLineWidth.ComboStyle = ImageComboStyle.LineWidth;

            groupMarker.Parent = tabLine;
            groupMarker.Top = groupLine.Top;
            groupMarker.Left = groupLine.Left;

            cboVerticesType.Items.Clear();
            cboVerticesType.Items.Add("Square");
            cboVerticesType.Items.Add("Circle");

            cboOrientation.Items.Clear();
            cboOrientation.Items.Add("Horizontal");
            cboOrientation.Items.Add("Parallel");
            cboOrientation.Items.Add("Perpendicular");

            cboLineType.Items.Clear();
            cboLineType.Items.Add("Line");
            cboLineType.Items.Add("Marker");

            cboLineType.SelectedIndexChanged += cboLineType_SelectedIndexChanged;
            cboLineType.SelectedIndex = 0;

            // vertices
            chkVerticesVisible.CheckedChanged += Ui2Options;
            cboVerticesType.SelectedIndexChanged += Ui2Options;
            clpVerticesColor.SelectedColorChanged += Ui2Options;
            chkVerticesFillVisible.CheckedChanged += Ui2Options;
            udVerticesSize.ValueChanged += Ui2Options;

            // Visibility
            var zoom = _context.Map.CurrentZoom;
            var scale = _context.Map.CurrentScale;
            dynamicVisibilityControl1.Initialize(_style, zoom, scale);
            dynamicVisibilityControl1.ValueChanged += (s, e) => {
                btnApply.Enabled = true;
                dynamicVisibilityControl1.ApplyChanges();
            };

            InitLinePattern();

            Options2Grid();

            Options2Ui();

            linePatternControl1.LoadFromXml();

            _noEvents = true;
            tabControl1.SelectedIndex = _tabIndex;
            _noEvents = false;
        }

        /// <summary>
        /// Chooses in which form to draw line, as common line or pattern
        /// </summary>
        private void ApplyPattern()
        {
            if (_style.Line.Pattern == null)
            {
                // using line settings
                _style.Line.UsePattern = false;
            }
            else if (_style.Line.Pattern.Count == 1 && _style.Line.Pattern[0].LineType == LineType.Simple)
            {
                // the pattern can be represented as a single line
                // we need to copy the options only, as all settings were set to pattern
                var line = _style.Line.Pattern[0];
                if (line != null)
                {
                    _style.Line.DashStyle = line.LineStyle;
                    _style.Line.Width = line.LineWidth;
                    _style.Line.Color = line.Color;
                }
                _style.Line.UsePattern = false;
            }
            else
            {
                // line pattern
                _style.Line.UsePattern = true;
            }
        }

        /// <summary>
        /// Returns true if the current line should be represented by the line pattern
        /// </summary>
        private bool CanUseLinePattern()
        {
            if (_style.Line.Pattern != null)
            {
                if (_style.Line.Pattern.Count > 0)
                {
                    return _style.Line.Pattern.Count > 1 || (_style.Line.Pattern.Count == 1 && _style.Line.Pattern[0].LineType == LineType.Marker);
                }
            }
            return false;
        }

        /// <summary>
        /// Draws preview based on the chosen options
        /// </summary>
        private void DrawPreview()
        {
            if (_noEvents) return;

            if (pctPreview.Image != null)
            {
                pctPreview.Image.Dispose();
            }

            var rect = pctPreview.ClientRectangle;
            var bmp = new Bitmap(rect.Width, rect.Height, PixelFormat.Format32bppArgb);
            var g = Graphics.FromImage(bmp);

            _style.Line.Pattern.Draw(g, 20, 0, rect.Width - 40, rect.Height, BackColor);

            //bmp.MakeTransparent(Color.White);
            pctPreview.Image = bmp;
        }

        /// <summary>
        /// Take cate that a line pattern actually exists
        /// </summary>
        private void InitLinePattern()
        {
            if (_style.Line.Pattern == null)
            {
                _style.Line.Pattern = new CompositeLine();
            }
            if (_style.Line.Pattern.Count == 0)
            {
                _style.Line.Pattern.AddLine(_style.Line.Color, _style.Line.Width, _style.Line.DashStyle);
            }
        }

        /// <summary>
        /// Fills grid using ShapeDrawingOptions
        /// </summary>
        private void Options2Grid()
        {
            dgv.Rows.Clear();
            if (CanUseLinePattern())
            {
                dgv.Rows.Add(_style.Line.Pattern.Count);
                for (int i = 0; i < _style.Line.Pattern.Count; i++)
                {
                    dgv[CMN_TYPE, i].Value = _style.Line.Pattern[i].LineType == LineType.Simple ? "line" : "marker";
                    var bmp = new Bitmap(60, 14);
                    dgv[CMN_PICTURE, i].Value = bmp;
                }
                _style.Line.UsePattern = true;
            }
            else
            {
                // a single line
                dgv.Rows.Add(1);
                dgv[CMN_TYPE, 0].Value = "line";
                var bmp = new Bitmap(60, 14);
                dgv[CMN_PICTURE, 0].Value = bmp;
                _style.Line.UsePattern = false;
            }
        }

        /// <summary>
        /// Loads the values of the class instance to the controls
        /// </summary>
        private void Options2Ui()
        {
            _noEvents = true;

            // vertices
            chkVerticesVisible.Checked = _style.Vertices.Visible;
            chkVerticesFillVisible.Checked = _style.Vertices.FillVisible;
            udVerticesSize.SetValue(_style.Vertices.Size);
            clpVerticesColor.Color = _style.Vertices.Color;
            cboVerticesType.SelectedIndex = (int)_style.Vertices.VertexType;

            // transparency
            if (_style.Line.Pattern != null)
            {
                transparencyControl1.Value = _style.Line.Pattern.AlphaTransparency;
            }

            if (dgv.SelectedRows.Count > 0)
            {
                int index = dgv.SelectedRows[0].Index;
                if (_style.Line.Pattern != null)
                {
                    var line = _style.Line.Pattern[index];
                    if (line != null)
                    {
                        cboLineType.SelectedIndex = (int)line.LineType;

                        groupLine.Visible = false;
                        groupMarker.Visible = false;
                        if (cboLineType.SelectedIndex == 0)
                        {
                            groupLine.Visible = true;
                        }
                        else
                        {
                            groupMarker.Visible = true;
                        }

                        // showing the options
                        if (line.LineType == LineType.Simple)
                        {
                            _noEvents = true;
                            icbLineType.SelectedIndex = (int)line.LineStyle;
                            icbLineWidth.SelectedIndex = (int)line.LineWidth - 1;
                            clpOutline.Color = line.Color;
                            _noEvents = false;
                        }
                        else
                        {
                            _noEvents = true;
                            pointSymbolControl1.SelectedIndex = (int)line.Marker;
                            udMarkerInterval.SetValue(line.MarkerInterval);
                            chkIntervalIsRelative.Checked = line.MarkerIntervalIsRelative;
                            udMarkerSize.SetValue(line.MarkerSize);
                            clpMarkerFill.Color = line.Color;
                            clpMarkerOutline.Color = line.MarkerOutlineColor;
                            udMarkerOffset.Minimum = -udMarkerOffset.Maximum;
                            udMarkerOffset.SetValue(line.MarkerOffset);
                            chkOffsetIsRelative.Checked = line.MarkerOffsetIsRelative;
                            cboOrientation.SelectedIndex = (int)line.MarkerOrientation;
                            chkMarkerFlipFirst.Checked = line.MarkerFlipFirst;
                            chkMarkerAllowOverflow.Checked = line.MarkerAllowOverflow;

                            if (pointSymbolControl1.ForeColor != clpMarkerFill.Color)
                            {
                                pointSymbolControl1.ForeColor = clpMarkerFill.Color;
                            }

                            _noEvents = false;
                        }
                        DrawPreview();
                    }
                }
            }
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
        /// Updates the enabled state of the controls
        /// </summary>
        private void RefreshControlState()
        {
            bool exists = (dgv.SelectedRows.Count > 0) && (dgv.Rows.Count > 1);
            btnRemove.Enabled = exists;
            if (exists)
            {
                int index = dgv.SelectedRows[0].Index;
                btnMoveUp.Enabled = index > 0;
                btnMoveDown.Enabled = index < dgv.Rows.Count - 1;
            }
            else
            {
                btnMoveDown.Enabled = false;
                btnMoveUp.Enabled = false;
            }
        }

        /// <summary>
        /// Sets the values entered by user to the class
        /// </summary>
        private void Ui2Options(object sender, EventArgs e)
        {
            if (_noEvents) return;

            // vertices
            var vert = _style.Vertices;
            vert.Visible = chkVerticesVisible.Checked;
            vert.FillVisible = chkVerticesFillVisible.Checked;
            vert.Size = (int)udVerticesSize.Value;
            vert.Color = clpVerticesColor.Color;
            vert.VertexType = (VertexType)cboVerticesType.SelectedIndex;

            // transparency
            _style.Line.Transparency = transparencyControl1.Value;
            if (_style.Line.Pattern != null)
            {
                _style.Line.Pattern.AlphaTransparency = _style.Line.Transparency;
            }

            if (dgv.SelectedRows.Count > 0)
            {
                int index = dgv.SelectedRows[0].Index;
                if (_style.Line.Pattern != null)
                {
                    var line = _style.Line.Pattern[index];
                    if (line != null)
                    {
                        line.LineType = cboLineType.SelectedIndex == 0 ? LineType.Simple : LineType.Marker;

                        // showing the options
                        if (cboLineType.SelectedIndex == 0)
                        {
                            line.LineStyle = (DashStyle)icbLineType.SelectedIndex;
                            line.LineWidth = icbLineWidth.SelectedIndex + 1;
                            line.Color = clpOutline.Color;
                        }
                        else
                        {
                            line.Marker = (VectorMarker)pointSymbolControl1.SelectedIndex;
                            line.MarkerInterval = (float)udMarkerInterval.Value;
                            line.MarkerIntervalIsRelative = chkIntervalIsRelative.Checked;
                            line.MarkerSize = (float)udMarkerSize.Value;
                            line.Color = clpMarkerFill.Color;
                            line.MarkerOutlineColor = clpMarkerOutline.Color;
                            line.MarkerOrientation = (LabelOrientation)cboOrientation.SelectedIndex;
                            line.MarkerOffset = (float)udMarkerOffset.Value;
                            line.MarkerOffsetIsRelative = chkOffsetIsRelative.Checked;
                            line.MarkerFlipFirst = chkMarkerFlipFirst.Checked;
                            line.MarkerAllowOverflow = chkMarkerAllowOverflow.Checked;
                            pointSymbolControl1.ForeColor = clpMarkerFill.Color;
                        }
                        dgv.Invalidate();
                    }
                }
            }

            // visibility
            dynamicVisibilityControl1.ApplyChanges();

            btnApply.Enabled = true;
            DrawPreview();
        }

        /// <summary>
        /// Adds current options as a style to the list
        /// </summary>
        private void btnAddStyle_Click(object sender, EventArgs e)
        {
            var pattern = new CompositeLine();
            ApplyPattern();

            if (_style.Line.UsePattern && _style.Line.Pattern != null)
            {
                string s = _style.Line.Pattern.Serialize();
                pattern.Deserialize(s);
            }
            else
            {
                // there is no actual patter, a single line only;
                // pattern object should be created on the fly
                pattern.AddLine(_style.Line.Color, _style.Line.Width, _style.Line.DashStyle);
            }
            linePatternControl1.AddPattern(pattern);
        }

        /// <summary>
        /// Adds a line to the pattern
        /// </summary>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (_style.Line.Pattern == null)
            {
                _style.Line.Pattern = new CompositeLine();
            }

            if (cboLineType.SelectedIndex == (int)LineType.Simple)
            {
                _style.Line.Pattern.AddLine(Color.Black, 1.0f, DashStyle.Solid);
            }
            else
            {
                var segment = _style.Line.Pattern.AddMarker(VectorMarker.Circle);
            }
            Options2Grid();
            DrawPreview();

            // selecting the added line
            _noEvents = true;
            dgv.ClearSelection();
            _noEvents = false;
            int index = dgv.Rows.Count - 1;
            dgv.Rows[index].Selected = true;
            btnApply.Enabled = true;

            RefreshControlState();
        }

        /// <summary>
        /// Updates map and saves the changes without closing the window
        /// </summary>
        private void btnApply_Click(object sender, EventArgs e)
        {
            ApplyPattern();

            RefreshCategories();

            if (_legend != null)
            {
                _legend.Redraw(LegendRedraw.LegendAndMap);
            }

            _initState = _style.Serialize();
            btnApply.Enabled = false;
        }

        /// <summary>
        /// Moves the selected line to the bottom of the pattern
        /// </summary>
        private void btnMoveDown_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                int index = dgv.SelectedRows[0].Index;
                if (index < dgv.Rows.Count - 1)
                {
                    var segm = _style.Line.Pattern[index];
                    var segmAfter = _style.Line.Pattern[index + 1];
                    _style.Line.Pattern.set_Line(index + 1, segm);
                    _style.Line.Pattern.set_Line(index, segmAfter);

                    Options2Grid();
                    DrawPreview();

                    _noEvents = true;
                    dgv.ClearSelection();
                    _noEvents = false;
                    dgv.Rows[index + 1].Selected = true;

                    btnApply.Enabled = true;
                    RefreshControlState();
                }
            }
        }

        /// <summary>
        /// Moves the selected line to the top of the pattern
        /// </summary>
        private void btnMoveUp_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                int index = dgv.SelectedRows[0].Index;
                if (index > 0)
                {
                    var segm = _style.Line.Pattern[index];
                    var segmBefore = _style.Line.Pattern[index - 1];
                    _style.Line.Pattern.set_Line(index - 1, segm);
                    _style.Line.Pattern.set_Line(index, segmBefore);

                    Options2Grid();
                    DrawPreview();

                    _noEvents = true;
                    dgv.ClearSelection();
                    _noEvents = false;
                    dgv.Rows[index - 1].Selected = true;

                    btnApply.Enabled = true;
                    RefreshControlState();
                }
            }
        }

        /// <summary>
        /// Preserving the selected index
        /// </summary>
        private void btnOk_Click(object sender, EventArgs e)
        {
            ApplyPattern();

            RefreshCategories();

            if (_initState != _style.Serialize())
            {
                _legend.Redraw(LegendRedraw.LegendAndMap);
            }

            _tabIndex = tabControl1.SelectedIndex;

            // saves options for default loading behavior
            //SymbologyPlugin.SaveLayerOptions(_layerHandle);

            linePatternControl1.SaveToXml();
        }

        /// <summary>
        /// Removes selected style from the list
        /// </summary>
        private void btnRemoveStyle_Click(object sender, EventArgs e)
        {
            linePatternControl1.RemovePattern(linePatternControl1.SelectedIndex);
        }

        /// <summary>
        /// Removes the current line. It's impossible to remove the last line
        /// </summary>
        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count > 0 && dgv.Rows.Count > 1)
            {
                int index = dgv.SelectedRows[0].Index;
                _style.Line.Pattern.RemoveLine(index);
                Options2Grid();
                DrawPreview();

                // restoring selection
                _noEvents = true;
                dgv.ClearSelection();
                _noEvents = false;
                if (index >= dgv.Rows.Count) index--;
                dgv.Rows[index].Selected = true;

                btnApply.Enabled = true;
                RefreshControlState();
            }
        }

        private void cboLineType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_noEvents) return;

            if (dgv.SelectedRows.Count > 0)
            {
                int index = dgv.SelectedRows[0].Index;
                var line = _style.Line.Pattern[index];
                line.LineType = (LineType)cboLineType.SelectedIndex;
                dgv[CMN_TYPE, index].Value = line.LineType == LineType.Simple ? "line" : "marker";
                Options2Ui();
                dgv.Invalidate();
                btnApply.Enabled = true;
            }
        }

        /// <summary>
        /// Drawing of images in the style column
        /// </summary>
        private void dgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (_style.Line.Pattern == null)
            {
                return;
            }

            if (e.RowIndex >= 0 && e.RowIndex < _style.Line.Pattern.Count)
            {
                if (e.ColumnIndex == CMN_PICTURE)
                {
                    var img = e.Value as Image;
                    if (img != null)
                    {
                        var line = _style.Line.Pattern[e.RowIndex];
                        if (line != null)
                        {
                            var g = Graphics.FromImage(img);
                            g.Clear(Color.White);
                            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                            g.SmoothingMode = SmoothingMode.HighQuality;

                            line.Draw(g, 0, 0, img.Width, img.Height, BackColor);

                            g.Dispose();

                            ((Bitmap)img).MakeTransparent(BackColor);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Shows the options of the curently selected line
        /// </summary>
        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            Options2Ui();
            RefreshControlState();
        }

        /// <summary>
        /// Reverts the changes if cancel was selected
        /// </summary>
        private void frmLines_FormClosing(object sender, FormClosingEventArgs e)
        {
            _tabIndex = tabControl1.SelectedIndex;
            if (DialogResult == DialogResult.Cancel)
            {
                _style.Deserialize(_initState);
            }
        }

        /// <summary>
        /// Handles the change of the style (style is displayed in preview)
        /// </summary>
        private void linePatternControl1_SelectionChanged()
        {
            if (_noEvents) return;

            var pattern = linePatternControl1.SelectedPattern;
            if (pattern != null)
            {
                string s = pattern.Serialize();

                _style.Line.Pattern = new CompositeLine();
                _style.Line.Pattern.Deserialize(s);
                ApplyPattern();

                Options2Grid();
                Options2Ui();

                btnApply.Enabled = true;
            }
        }

        /// <summary>
        /// Chnages the marker for the current line
        /// </summary>
        private void pointSymbolControl1_SelectionChanged()
        {
            Ui2Options(null, null);
        }

        private void transparencyControl1_ValueChanged(object sender, byte value)
        {
            Ui2Options(null, null);
        }

        private void LinesForm_Load(object sender, EventArgs e)
        {
            // Fixing CORE-160
            CaptionFont = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
        }

        private void OnOffsetIsRelativeChanged(object sender, EventArgs e)
        {
            udMarkerOffset.DecimalPlaces = chkOffsetIsRelative.Checked ? 4 : 0;
            Ui2Options(null, null);
        }

        private void OnIntervalIsRelativeChanged(object sender, EventArgs e)
        {
         
            udMarkerInterval.DecimalPlaces = chkIntervalIsRelative.Checked ? 4 : 0;
            Ui2Options(null, null);
        }
    }
}