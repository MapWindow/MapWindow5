// ********************************************************************************************************
// <copyright file="MWLite.Symbology.cs" company="MapWindow.org">
// Copyright (c) MapWindow.org. All rights reserved.
// </copyright>
// The contents of this file are subject to the Mozilla Public License Version 1.1 (the "License"); 
// you may not use this file except in compliance with the License. You may obtain a copy of the License at 
// http:// Www.mozilla.org/MPL/ 
// Software distributed under the License is distributed on an "AS IS" basis, WITHOUT WARRANTY OF 
// ANY KIND, either express or implied. See the License for the specificlanguage governing rights and 
// limitations under the License. 
// 
// The Initial Developer of this version of the Original Code is Sergei Leschinski
// 
// Contributor(s): (Open source contributors should list themselves and their modifications here). 
// Change Log: 
// Date            Changed By      Notes
// ********************************************************************************************************

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using MW5.Api;
using MW5.Api.Concrete;
using MW5.Api.Interfaces;
using MW5.Api.Legend;
using MW5.Api.Legend.Abstract;
using MW5.Plugins.Symbology.Controls;
using MW5.UI;

namespace MW5.Plugins.Symbology.Forms.Symbology
{
    public partial class LinesForm : MapWindowForm
    {
        private static int _tabIndex = 0;

        // column indices for the grid
        private const int CMN_PICTURE = 0;
        private const int CMN_TYPE = 1;

        private readonly IMuteLegend _legend;
        private readonly IGeometryStyle _options;
        private string _initState;
        private bool _noEvents;

        #region Initialization
        /// <summary>
        /// Creates a new instance of PolygonsForm class
        /// </summary>
        public LinesForm(IMuteLegend legend, ILegendLayer layer, IGeometryStyle options, bool applyDisabled)
        {
            InitializeComponent();

            if (options == null || layer == null)
            {
                throw new Exception("PolygonsForm: unexpected null parameter");
            }
            
            _options = options;

            _legend = legend;
            btnApply.Visible = !applyDisabled;
            _initState = options.Serialize();
            

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

            cboLineType.SelectedIndexChanged += new EventHandler(cboLineType_SelectedIndexChanged);
            cboLineType.SelectedIndex = 0;

            // vertices
            chkVerticesVisible.CheckedChanged += new EventHandler(Ui2Options);
            cboVerticesType.SelectedIndexChanged += new EventHandler(Ui2Options);
            clpVerticesColor.SelectedColorChanged += new EventHandler(Ui2Options);
            chkVerticesFillVisible.CheckedChanged += new EventHandler(Ui2Options);
            udVerticesSize.ValueChanged += new EventHandler(Ui2Options);

            InitLinePattern();

            Options2Grid();

            Options2Ui();

            linePatternControl1.LoadFromXml();

            _noEvents = true;
            tabControl1.SelectedIndex = _tabIndex;
            _noEvents = false;
        }

        /// <summary>
        /// Take cate that a line pattern actually exists
        /// </summary>
        void InitLinePattern()
        {
            if (_options.Line.Pattern == null)
            {
                _options.Line.Pattern = new CompositeLine();
            }
            if (_options.Line.Pattern.Count == 0)
            {
                _options.Line.Pattern.AddLine(_options.Line.Color, _options.Line.Width, _options.Line.DashStyle);
            }
        }

        /// <summary>
        /// Updates the enabled state of the controls
        /// </summary>
        void RefreshControlState()
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
        #endregion

        #region PropertyExchange
        /// <summary>
        /// Sets the values entered by user to the class
        /// </summary>
        private void Ui2Options(object sender, EventArgs e)
        {
            if (_noEvents)
                return;

            // vertices
            var vert = _options.Vertices;
            vert.Visible = chkVerticesVisible.Checked;
            vert.FillVisible = chkVerticesFillVisible.Checked;
            vert.Size = (int)udVerticesSize.Value;
            vert.Color = clpVerticesColor.Color;
            vert.VertexType = (VertexType)cboVerticesType.SelectedIndex;

            // transparency
            _options.Line.AlphaTransparency = transparencyControl1.Value;
            if (_options.Line.Pattern != null)
            {
                _options.Line.Pattern.AlphaTransparency = (byte)_options.Line.AlphaTransparency;
            }

            if (dgv.SelectedRows.Count > 0)
            {
                int index = dgv.SelectedRows[0].Index;
                if (_options.Line.Pattern != null)
                {
                    var line = _options.Line.Pattern[index];
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
                            line.MarkerSize = (float)udMarkerSize.Value;
                            line.Color =  clpMarkerFill.Color;
                            line.MarkerOutlineColor =  clpMarkerOutline.Color;
                            line.MarkerOrientation = (LabelOrientation)cboOrientation.SelectedIndex;
                            line.MarkerOffset = (float)udMarkerOffset.Value;

                            if (pointSymbolControl1.ForeColor != clpMarkerFill.Color)
                            {
                                pointSymbolControl1.ForeColor = clpMarkerFill.Color;
                            }
                        }
                        dgv.Invalidate();
                    }
                }
            }

            btnApply.Enabled = true;
            DrawPreview();
        }
        
        /// <summary>
        /// Loads the values of the class instance to the controls
        /// </summary>
        private void Options2Ui()
        {
            _noEvents = true;

            // vertices
            chkVerticesVisible.Checked = _options.Vertices.Visible;
            chkVerticesFillVisible.Checked = _options.Vertices.FillVisible;
            udVerticesSize.SetValue(_options.Vertices.Size);
            clpVerticesColor.Color =  _options.Vertices.Color;
            cboVerticesType.SelectedIndex = (int)_options.Vertices.VertexType;

            // transparency
            if (_options.Line.Pattern != null)
            {
                transparencyControl1.Value = _options.Line.Pattern.AlphaTransparency;
            }

            if (dgv.SelectedRows.Count > 0)
            {
                int index = dgv.SelectedRows[0].Index;
                if (_options.Line.Pattern != null)
                {
                    var line = _options.Line.Pattern[index];
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
                            clpOutline.Color =  line.Color;
                            _noEvents = false;
                        }
                        else
                        {
                            _noEvents = true;
                            pointSymbolControl1.SelectedIndex = (int)line.Marker;
                            udMarkerInterval.SetValue(line.MarkerInterval);
                            udMarkerSize.SetValue(line.MarkerSize);
                            clpMarkerFill.Color =  line.Color;
                            clpMarkerOutline.Color =  line.MarkerOutlineColor;
                            udMarkerOffset.SetValue(line.MarkerOffset);
                            cboOrientation.SelectedIndex = (int)line.MarkerOrientation;
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
        #endregion

        #region Drawing
        /// <summary>
        /// Draws preview based on the chosen options
        /// </summary>
        private void DrawPreview()
        {
            if (_noEvents)
                return;

            if (pctPreview.Image != null)
            {
                pctPreview.Image.Dispose();
            }

            var rect = pctPreview.ClientRectangle;
            var bmp = new Bitmap(rect.Width, rect.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            var g = Graphics.FromImage(bmp);
            
            _options.Line.Pattern.Draw(g, 20, 0, rect.Width - 40, rect.Height, BackColor);
            
            //bmp.MakeTransparent(Color.White);
            pctPreview.Image = bmp;
        }
        #endregion

        #region User input
        // Toggle between simaple and marker line
        void cboLineType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_noEvents)
                return;

            if (dgv.SelectedRows.Count > 0)
            {
                int index = dgv.SelectedRows[0].Index;
                var line = _options.Line.Pattern[index];
                line.LineType = (LineType)cboLineType.SelectedIndex;
                dgv[CMN_TYPE, index].Value = line.LineType == LineType.Simple ? "line" : "marker";
                Options2Ui();
                dgv.Invalidate();
                btnApply.Enabled = true;
                
            }
        }
        #endregion

        #region Grid
        
        /// <summary>
        /// Drawing of images in the style column
        /// </summary>
        private void dgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (_options.Line.Pattern == null)
            {
                return;
            }

            if (e.RowIndex >= 0 && e.RowIndex < _options.Line.Pattern.Count)
            {
                if (e.ColumnIndex == CMN_PICTURE)
                {
                    var img = e.Value as Image;
                    if (img != null)
                    {
                        var line = _options.Line.Pattern[e.RowIndex];
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
        #endregion

        #region Managing lines
        /// <summary>
        /// Adds a line to the pattern
        /// </summary>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (_options.Line.Pattern == null)
            {
                _options.Line.Pattern = new CompositeLine();
            }

            if (cboLineType.SelectedIndex == (int)LineType.Simple)
            {
                _options.Line.Pattern.AddLine( Color.Black, 1.0f, DashStyle.Solid);
            }
            else
            {
                var segment = _options.Line.Pattern.AddMarker(VectorMarker.Circle);
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
        /// Removes the current line. It's impossible to remove the last line
        /// </summary>
        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count > 0 && dgv.Rows.Count > 1)
            {
                int index = dgv.SelectedRows[0].Index;
                _options.Line.Pattern.RemoveLine(index);
                Options2Grid();
                DrawPreview();

                // restoring selection
                _noEvents = true;
                dgv.ClearSelection();
                _noEvents = false;
                if (index >= dgv.Rows.Count )
                    index--;
                dgv.Rows[index].Selected = true;

                btnApply.Enabled = true;
                RefreshControlState();
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
                    var segm = _options.Line.Pattern[index];
                    var segmBefore = _options.Line.Pattern[index - 1];
                    _options.Line.Pattern.set_Line(index - 1, segm);
                    _options.Line.Pattern.set_Line(index, segmBefore);

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
        /// Moves the selected line to the bottom of the pattern
        /// </summary>
        private void btnMoveDown_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                int index = dgv.SelectedRows[0].Index;
                if (index < dgv.Rows.Count - 1)
                {
                    var segm = _options.Line.Pattern[index];
                    var segmAfter = _options.Line.Pattern[index + 1];
                    _options.Line.Pattern.set_Line(index + 1, segm);
                    _options.Line.Pattern.set_Line(index, segmAfter);

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
        /// Chnages the marker for the current line
        /// </summary>
        private void pointSymbolControl1_SelectionChanged()
        {
            Ui2Options(null, null);
        }

        #endregion

        /// <summary>
        /// Preserving the selected index
        /// </summary>
        private void btnOk_Click(object sender, EventArgs e)
        {
            ApplyPattern();
            if (_initState != _options.Serialize())
            {
                //m_legend.FireLayerPropertiesChanged(m_layer.Handle);
                _legend.Redraw(LegendRedraw.LegendAndMap);
            }
            _tabIndex = tabControl1.SelectedIndex;

            // saves options for default loading behavior
            //SymbologyPlugin.SaveLayerOptions(_layerHandle);

            linePatternControl1.SaveToXml();
        }

        private void transparencyControl1_ValueChanged(object sender, byte value)
        {
            Ui2Options(null, null);
        }

        /// <summary>
        /// Updates map and saves the changes without closing the window
        /// </summary>
        private void btnApply_Click(object sender, EventArgs e)
        {
            ApplyPattern();
            if (_legend != null)
            {
                _legend.Redraw(LegendRedraw.LegendAndMap);
                //m_legend.FireLayerPropertiesChanged(m_layer.Handle);
            }
            _initState = _options.Serialize();
            btnApply.Enabled = false;
        }

        /// <summary>
        /// Reverts the changes if cancel was selected
        /// </summary>
        private void frmLines_FormClosing(object sender, FormClosingEventArgs e)
        {
            _tabIndex = tabControl1.SelectedIndex;
            if (DialogResult == DialogResult.Cancel)
            {
                _options.Deserialize(_initState);
            }
        }
        #region Synchronization
        /// <summary>
        /// Returns true if the current line should be represented by the line pattern
        /// </summary>
        private bool CanUseLinePattern()
        {
            if (_options.Line.Pattern != null)
            {
                if (_options.Line.Pattern.Count > 0)
                {
                    return _options.Line.Pattern.Count > 1 || (_options.Line.Pattern.Count == 1 &&
                           _options.Line.Pattern[0].LineType == LineType.Marker);
                }
            }
            return false;
        }

        /// <summary>
        /// Fills grid using ShapeDrawingOptions
        /// </summary>
        private void Options2Grid()
        {
            dgv.Rows.Clear();
            if (CanUseLinePattern())
            {
                dgv.Rows.Add(_options.Line.Pattern.Count);
                for (int i = 0; i < _options.Line.Pattern.Count; i++)
                {
                    dgv[CMN_TYPE, i].Value = _options.Line.Pattern[i].LineType == LineType.Simple ? "line" : "marker";
                    Bitmap bmp = new Bitmap(60, 14);
                    dgv[CMN_PICTURE, i].Value = bmp;
                }
                _options.Line.UsePattern = true;
            }
            else
            {
                // a single line
                dgv.Rows.Add(1);
                dgv[CMN_TYPE, 0].Value = "line";
                Bitmap bmp = new Bitmap(60, 14);
                dgv[CMN_PICTURE, 0].Value = bmp;
                _options.Line.UsePattern = false;
            }
        }
        #endregion

        /// <summary>
        /// Chooses in which form to draw line, as common line or pattern
        /// </summary>
        void ApplyPattern()
        {
            if (_options.Line.Pattern == null)
            {
                // using line settings
                _options.Line.UsePattern = false;
            }
            else if (_options.Line.Pattern.Count == 1 && _options.Line.Pattern[0].LineType == LineType.Simple)
            {
                // the pattern can be represented as a single line
                // we need to copy the options only, as all settings were set to pattern
                var line = _options.Line.Pattern[0];
                if (line != null)
                {
                    _options.Line.DashStyle = line.LineStyle;
                    _options.Line.Width = line.LineWidth;
                    _options.Line.Color = line.Color;
                }
                _options.Line.UsePattern = false;
            }
            else
            {
                // line pattern
                _options.Line.UsePattern = true;
            }
        }

        #region Line pattern styles
        /// <summary>
        /// Handles the change of the style (style is displayed in preview)
        /// </summary>
        private void linePatternControl1_SelectionChanged()
        {
            if (_noEvents)
                return;

            var pattern = linePatternControl1.SelectedPattern;
            if (pattern != null)
            {
                string s = pattern.Serialize();

                _options.Line.Pattern = new CompositeLine();
                _options.Line.Pattern.Deserialize(s);
                ApplyPattern();

                Options2Grid();
                Options2Ui();
                
                btnApply.Enabled = true;
            }
        }

        /// <summary>
        /// Adds current options as a style to the list
        /// </summary>
        private void btnAddStyle_Click(object sender, EventArgs e)
        {
            var pattern = new CompositeLine();
            this.ApplyPattern();

            if (_options.Line.UsePattern && _options.Line.Pattern != null)
            {
                string s = _options.Line.Pattern.Serialize();
                pattern.Deserialize(s);
            }
            else
            {
                // there is no actual patter, a single line only;
                // pattern object should be created on the fly
                pattern.AddLine(_options.Line.Color, _options.Line.Width, _options.Line.DashStyle);
            }
            linePatternControl1.AddPattern(pattern);
        }
        
        /// <summary>
        /// Removes selected style from the list
        /// </summary>
        private void btnRemoveStyle_Click(object sender, EventArgs e)
        {
            linePatternControl1.RemovePattern(linePatternControl1.SelectedIndex);
        }
        
        /// <summary>
        /// Tests saving. Temporary
        /// </summary>
        private void btnSaveStyles_Click(object sender, EventArgs e)
        {
            linePatternControl1.SaveToXml();
        }
        
        /// <summary>
        /// Tests loading. Temporary
        /// </summary>
        private void btnLoadStyles_Click(object sender, EventArgs e)
        {
            linePatternControl1.LoadFromXml();
        }
        #endregion
    }
}
