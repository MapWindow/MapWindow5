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
using System.Drawing.Text;
using System.Windows.Forms;
using MW5.Api;
using MW5.Api.Enums;
using MW5.Api.Interfaces;
using MW5.Api.Legend;
using MW5.Api.Legend.Abstract;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Services;
using MW5.Plugins.Symbology.Forms.Categories;
using MW5.Plugins.Symbology.Helpers;
using MW5.Plugins.Symbology.Services;
using MW5.UI;
using MW5.UI.Forms;

namespace MW5.Plugins.Symbology.Forms.Style
{
    /// <summary>
    /// GUI for setting options for Labels and LabelCategory classes
    /// </summary>
    public partial class LabelStyleForm : MapWindowForm
    {
        private static int tabNumber = 0;

        private ILayer _layer;
        private IFeatureSet _shapefile;
        private readonly bool _categoryEdited;

        private ILabelStyle _category;
        private bool _noEvents;
        private string _initState = "";

        /// <summary>
        /// Constructor for setting label expression and options
        /// </summary>
        public LabelStyleForm(IAppContext context, ILayer layer):
            base(context)
        {
            InitLayer(context, layer);

            InitializeComponent();
           
            // old-style labels not based on expression
            if (_shapefile.Labels.Expression == "" && !_shapefile.Labels.Empty &&
                _shapefile.Labels.Items[0].Text != "")
            {
                richTextBox1.Text = "<no expression>";
                listBox1.Enabled = false;
                btnPlus.Enabled = false;
                btnQuotes.Enabled = false;
                btnNewLine.Enabled = false;
                richTextBox1.Enabled = false;
            }
            else
            {
                richTextBox1.Text = LabelHelper.StripNewLineQuotes(_shapefile.Labels.Expression);
            }

            Initialize(_shapefile.Labels.Style);

            tabControl1.SelectedIndex = tabNumber;
        }

        /// <summary>
        /// Constructor for editing single category
        /// </summary>
        public LabelStyleForm(IAppContext context,  ILayer layer, ILabelStyle lb) 
        {
            InitLayer(context, layer);

            _categoryEdited = true;

            InitializeComponent();
            Initialize(lb);
           
            tabControl1.SelectedIndex = tabNumber;
            
            // expression isn't available for the categories
            if (_categoryEdited)
            {
                tabControl1.TabPages.Remove(tabControl1.TabPages[4]);   // visibility
                tabControl1.TabPages.Remove(tabControl1.TabPages[3]);   // position
                tabControl1.TabPages.Remove(tabControl1.TabPages[0]);   // expression
            }
            lblResult.Visible = false;
            btnApply.Visible = false;
        }

        private void InitLayer(IAppContext context, ILayer layer)
        {
            if (context == null) throw new ArgumentNullException("context");

            if (layer == null || layer.FeatureSet == null)
            {
                throw new ArgumentNullException("layer");
            }

            _layer = layer;
            _shapefile = _layer.FeatureSet;
        }

        /// <summary>
        /// Initializes controls of the form
        /// </summary>
        private void Initialize(ILabelStyle lb)
        {
            _category = lb;

            _noEvents = true;
            cboFontName.Items.Clear();
            foreach (FontFamily family in FontFamily.Families)
            {
                cboFontName.Items.Add(family.Name);
            }

            cboDecimalPlaces.Items.Add("Auto");
            for (int i = 1; i <= 6; i++)
                cboDecimalPlaces.Items.Add(i.ToString());
            cboDecimalPlaces.SelectedIndex = 0;

            icbLineType.ComboStyle = ImageComboStyle.LineStyle;
            icbLineWidth.ComboStyle = ImageComboStyle.LineWidth;

            icbFrameType.Color1 = Color.Transparent;
            icbFrameType.ComboStyle = ImageComboStyle.FrameType;
            icbFrameType.SelectedIndex = 0;

            if (!_categoryEdited)
            {
                foreach (var fld in _shapefile.Fields)
                {
                    string name = fld.Name;
                    if (name.ToLower() != "mwshapeid")
                        listBox1.Items.Add(name);
                }
            }

            string[] scales = { "1", "10", "100", "1000", "5000", "10000", "25000", "50000", "100000", 
                                "250000", "500000", "1000000", "10000000" };
            cboMinScale.Items.Clear();
            cboMaxScale.Items.Clear();
            cboBasicScale.Items.Clear();
            foreach (string t in scales)
            {
                cboMinScale.Items.Add(t);
                cboMaxScale.Items.Add(t);
                cboBasicScale.Items.Add(t);
            }

            // displaying options in the GUI
            LabelStyle2Ui(_category);

            TestExpression();

            txtLabelExpression.Text = _shapefile.Labels.VisibilityExpression;

            // serialization
            if (_categoryEdited)
            {
                _initState = _category.Serialize();
            }
            else
            {
                var mode = _shapefile.Labels.SavingMode;
                _shapefile.Labels.SavingMode = PersistenceType.None;
                _initState = _shapefile.Labels.Serialize();
                _shapefile.Labels.SavingMode = mode;
            }

            cboLabelsVerticalPosition.Items.Clear();
            cboLabelsVerticalPosition.Items.Add("Above layer");
            cboLabelsVerticalPosition.Items.Add("Above all layers");
            
            var labels = _shapefile.Labels;

            cboLabelsVerticalPosition.SelectedIndex = (int)labels.VerticalPosition;
            chkLabelsRemoveDuplicates.Checked = labels.RemoveDuplicates;
            chkAviodCollisions.Checked = labels.AvoidCollisions;
            chkScaleLabels.Checked = labels.ScaleLabels;
            cboBasicScale.Text = labels.BasicScale.ToString();

            udLabelOffsetX.SetValue(labels.OffsetX);
            udLabelOffsetY.SetValue(labels.OffsetY);
            udLabelsBuffer.SetValue(labels.CollisionBuffer);

            // alignment
            var alignment = labels.Style.Alignment;
            optAlignBottomCenter.Checked = (alignment == LabelAlignment.BottomCenter);
            optAlignBottomLeft.Checked = (alignment == LabelAlignment.BottomLeft);
            optAlignBottomRight.Checked = (alignment == LabelAlignment.BottomRight);
            optAlignCenter.Checked = (alignment == LabelAlignment.Center);
            optAlignCenterLeft.Checked = (alignment == LabelAlignment.CenterLeft);
            optAlignCenterRight.Checked = (alignment == LabelAlignment.CenterRight);
            optAlignTopCenter.Checked = (alignment == LabelAlignment.TopCenter);
            optAlignTopLeft.Checked = (alignment == LabelAlignment.TopLeft);
            optAlignTopRight.Checked = (alignment == LabelAlignment.TopRight);

            
            optAlignCenter.Enabled = !_shapefile.PointOrMultiPoint;

            btnApply.Enabled = (_shapefile.Labels.Expression != "" && _shapefile.Labels.Empty);
            string[] list = {
                                            "Default",
                                            "SingleBitPerPixelGridFit",
                                            "SingleBitPerPixel",
                                            "AntiAliasGridFit",
                                            "HintAntiAlias",
                                            "ClearType"};
            cboTextRenderingHint.DataSource = list;
            SetSelectedIndex(cboTextRenderingHint, (int)_shapefile.Labels.TextRenderingHint);
            cboTextRenderingHint.SelectedIndexChanged += Ui2LabelStyle;

            _noEvents = false;

            // initial drawing
            DrawPreview();
        }

        /// <summary>
        /// Sets selected index in the combo in case it's the valid one
        /// </summary>
        private static void SetSelectedIndex(ComboBox combo, int index)
        {
            if (index >= 0 && index < combo.Items.Count)
                combo.SelectedIndex = index;
        }

        /// <summary>
        /// Loads label options to the GUI controls
        /// </summary>
        private bool LabelStyle2Ui(ILabelStyle lb)
        {
            if (lb == null) 
                return false;

            chkVisible.Checked = _category.Visible;

            string fontName = lb.FontName;
            int j = 0;
            foreach (FontFamily family in FontFamily.Families)
            {
                if (family.Name == fontName)
                    cboFontName.SelectedIndex = j;
                j++;
            }
            if (cboFontName.SelectedIndex == -1)
            {
                cboFontName.SelectedItem = "Arial";
            }

            // font style
            chkFontBold.Checked = lb.FontBold;
            chkFontItalic.Checked = lb.FontItalic;
            chkFontUnderline.Checked = lb.FontUnderline;
            chkFontStrikeout.Checked = lb.FontStrikeOut;

            udFontSize.Value = lb.FontSize;

            clpFont1.Color =  lb.FontColor;

            udFramePaddingX.SetValue(lb.FramePaddingX);
            udFramePaddingY.SetValue(lb.FramePaddingY);

            // font outlines
            chkHaloVisible.Checked = lb.HaloVisible;
            chkShadowVisible.Checked = lb.ShadowVisible;

            clpShadow.Color =  lb.ShadowColor;
            clpHalo.Color =  lb.HaloColor;

            udHaloSize.SetValue(lb.HaloSize);
            udShadowOffsetX.SetValue(lb.ShadowOffsetX);
            udShadowOffsetY.SetValue(lb.ShadowOffsetY);

            // frame options
            chkUseFrame.Checked = lb.FrameVisible;
            icbFrameType.SelectedIndex = (int)lb.FrameType;

            icbLineType.SelectedIndex = (int)lb.FrameOutlineStyle;

            clpFrame1.Color =  lb.FrameBackColor;
            clpFrameBorder.Color =  lb.FrameOutlineColor;

            udFramePaddingX.SetValue(lb.FramePaddingX);
            udFramePaddingY.SetValue(lb.FramePaddingY);

            if (lb.FrameOutlineWidth < 1) lb.FrameOutlineWidth = 1;
            if (lb.FrameOutlineWidth > icbLineWidth.Items.Count) lb.FrameOutlineWidth = icbLineWidth.Items.Count;
            icbLineWidth.SelectedIndex = (int)lb.FrameOutlineWidth - 1;

            transparencyControl1.Value = (byte)lb.FrameTransparency;

            cboMinScale.Text = _shapefile.Labels.MinVisibleScale.ToString();
            cboMaxScale.Text = _shapefile.Labels.MaxVisibleScale.ToString();
            chkDynamicVisibility.Checked = _shapefile.Labels.DynamicVisibility;

            return true;
        }

        /// <summary>
        /// Saves the options from the GUI to labels style class
        /// </summary>
        private void Ui2LabelStyle(object sender, EventArgs e)
        {
            if (_noEvents)
            {
                return;
            }
           
            var lb = _category;

            lb.Visible = chkVisible.Checked;

            // alignment
            lb.FramePaddingX = (int)udFramePaddingX.Value;
            lb.FramePaddingY = (int)udFramePaddingY.Value;

            // font 
            lb.FontBold = chkFontBold.Checked;
            lb.FontItalic = chkFontItalic.Checked;
            lb.FontUnderline = chkFontUnderline.Checked;
            lb.FontStrikeOut = chkFontStrikeout.Checked;
            lb.FontName = cboFontName.Text;
            lb.FontColor = clpFont1.Color;
            lb.FontSize = (int)udFontSize.Value;

            // outline
            lb.HaloVisible = chkHaloVisible.Checked;
            lb.ShadowVisible = chkShadowVisible.Checked;

            lb.HaloColor = clpHalo.Color;
            lb.ShadowColor = clpShadow.Color;

            lb.HaloSize = (int)udHaloSize.Value;
            lb.ShadowOffsetX = (int)udShadowOffsetX.Value;
            lb.ShadowOffsetY = (int)udShadowOffsetY.Value;
            
            // frame fill
            lb.FrameBackColor = clpFrame1.Color;

            if (tabControl1.SelectedTab.Name == "tabFrameFill")
            {
                lb.FrameVisible = chkUseFrame.Checked;
                lb.FrameType = (FrameType)icbFrameType.SelectedIndex;
            }

            // frame outline
            lb.FrameOutlineColor = clpFrameBorder.Color;
            if (icbLineType.SelectedIndex >= 0)
            {
                lb.FrameOutlineStyle = (DashStyle)icbLineType.SelectedIndex;
            }
            lb.FrameOutlineWidth = (int)icbLineWidth.SelectedIndex + 1;

            lb.FrameTransparency = transparencyControl1.Value;
            lb.FontTransparency = transparencyControl1.Value;

            // passed from the main form
            var labels = _shapefile.Labels;
            labels.RemoveDuplicates = chkLabelsRemoveDuplicates.Checked;
            labels.AvoidCollisions = chkAviodCollisions.Checked;
            labels.ScaleLabels = chkScaleLabels.Checked;
            
            double val;
            labels.BasicScale = (double.TryParse(cboBasicScale.Text, out val)) ? val : 0.0;
            labels.VerticalPosition = (VerticalPosition)cboLabelsVerticalPosition.SelectedIndex;

            lb.OffsetX = (double)udLabelOffsetX.Value;
            lb.OffsetY = (double)udLabelOffsetY.Value;
            _shapefile.Labels.CollisionBuffer = (int)udLabelsBuffer.Value;

            // alignment
            if (optAlignBottomCenter.Checked) lb.Alignment = LabelAlignment.BottomCenter;
            if (optAlignBottomLeft.Checked) lb.Alignment = LabelAlignment.BottomLeft;
            if (optAlignBottomRight.Checked) lb.Alignment = LabelAlignment.BottomRight;
            if (optAlignCenter.Checked) lb.Alignment = LabelAlignment.Center;
            if (optAlignCenterLeft.Checked) lb.Alignment = LabelAlignment.CenterLeft;
            if (optAlignCenterRight.Checked) lb.Alignment = LabelAlignment.CenterRight;
            if (optAlignTopCenter.Checked) lb.Alignment = LabelAlignment.TopCenter;
            if (optAlignTopLeft.Checked) lb.Alignment = LabelAlignment.TopLeft;
            if (optAlignTopRight.Checked) lb.Alignment = LabelAlignment.TopRight;

            // categories will have the same alignment
            //if (!m_categoryEdited)
            //{
            //    for (int i = 0; i < m_shapefile.Labels.NumCategories; i++)
            //    {
            //        var cat = m_shapefile.Labels.Category[i];
            //        cat.Alignment = lb.Alignment;
            //        cat.OffsetX = lb.OffsetX;
            //        cat.OffsetY = lb.OffsetY;
            //    }
            //}

            if (double.TryParse(cboMinScale.Text, out val))
            {
                _shapefile.Labels.MinVisibleScale = val;
            }

            if (double.TryParse(cboMaxScale.Text, out val))
            {
                _shapefile.Labels.MaxVisibleScale = val;
            }
            _shapefile.Labels.DynamicVisibility = chkDynamicVisibility.Checked;

            btnApply.Enabled = true;

            _shapefile.Labels.TextRenderingHint = (TextRenderingHint)cboTextRenderingHint.SelectedIndex;

            string format = _shapefile.Labels.FloatNumberFormat;
            string newFormat = GetFloatFormat();
            _shapefile.Labels.FloatNumberFormat = newFormat;
            if (newFormat != format)
            {
                //m_shapefile.Labels.ForceRecalculateExpression();
            }
            DrawPreview();
        }

        private string GetFloatFormat()
        {
            if (cboDecimalPlaces.SelectedIndex == 0) return "%g";
            return string.Format("%.{0}f", cboDecimalPlaces.SelectedIndex);
        }

        /// <summary>
        /// Draws preview of the label
        /// </summary>
        private void DrawPreview()
        {
            // this function is called after each change of state, therefore it makes sense to update availability of controls here
            RefreshControls();

            if (_noEvents)
            {
                return;
            }

            if (_category.Visible)
            {
                string text = _categoryEdited ? _shapefile.Labels.Expression : richTextBox1.Text;
                LabelHelper.DrawPreview(_category, _shapefile, pctPreview, text, true);
            }
            else
            {
                Bitmap img = new Bitmap((int)pctPreview.ClientRectangle.Width, (int)pctPreview.ClientRectangle.Height);
                if (pctPreview.Image != null)
                {
                    pctPreview.Image.Dispose();
                }
                pctPreview.Image = img;
            }
        }

        /// <summary>
        /// Enables or disables controls which are dependent upon others
        /// </summary>
        private void RefreshControls()
        {
            _noEvents = true;

            // drawing of frame
            bool drawFrame = chkUseFrame.Checked;
            clpFrame1.Enabled = drawFrame;
            icbLineType.Enabled = drawFrame;
            icbLineWidth.Enabled = drawFrame;
            clpFrameBorder.Enabled = drawFrame;
            udFramePaddingX.Enabled = drawFrame;
            udFramePaddingY.Enabled = drawFrame;

            //outlines
            udHaloSize.Enabled = chkHaloVisible.Checked;
            clpHalo.Enabled = chkHaloVisible.Checked;
            label15.Enabled = chkHaloVisible.Checked;

            udShadowOffsetX.Enabled = chkShadowVisible.Checked;
            udShadowOffsetY.Enabled = chkShadowVisible.Checked;
            clpShadow.Enabled = chkShadowVisible.Checked;
            label12.Enabled = chkShadowVisible.Checked;
            label9.Enabled = chkShadowVisible.Checked;

            icbFrameType.Enabled = chkUseFrame.Checked;
            btnSetFrameGradient.Enabled = chkUseFrame.Checked;

            panel1.Enabled = chkDynamicVisibility.Checked;

            cboBasicScale.Enabled = chkScaleLabels.Checked;
            btnSetCurrent.Enabled = chkScaleLabels.Checked;
            lblScaleLabels.Enabled = chkScaleLabels.Checked;

            bool noLabels = false;;
            bool hasExpression = richTextBox1.Text.Length > 0;
            if (!_categoryEdited)
            {
                noLabels = !hasExpression;
                groupBox6.Enabled = hasExpression;
                groupBox11.Enabled = hasExpression;
                groupBox13.Enabled = hasExpression;
                groupBox20.Enabled = hasExpression;
                groupLabelAlignment.Enabled = hasExpression;
                chkUseFrame.Enabled = hasExpression;
                groupBox2.Enabled = hasExpression;
                groupBox3.Enabled = hasExpression;
                groupBox4.Enabled = hasExpression;
                groupBox5.Enabled = hasExpression;
                chkScaleLabels.Enabled = hasExpression;
            }

            groupBox4.Enabled = !noLabels && chkUseFrame.Checked;
            groupBox2.Enabled = !noLabels && chkUseFrame.Checked;

            _noEvents = false;
        }
        
        /// <summary>
        /// Sets gradient for the frame color
        /// </summary>
        private void btnSetFrameGradient_Click(object sender, EventArgs e)
        {
            using (var form = new FontGradientForm(_category, false))
            {
                if (_context.View.ShowChildView(form, this))
                {
                    DrawPreview();
                    clpFrame1.Color = _category.FrameBackColor;
                    btnApply.Enabled = true;
                }
            }
        }
        
        /// <summary>
        /// Clears gradient of the frame
        /// </summary>
        private void btnClearFrameGradient_Click(object sender, EventArgs e)
        {
            _category.FrameGradientMode = LinearGradient.None;
            DrawPreview();
        }

        /// <summary>
        ///  Saves the options, closes the form.
        /// </summary>
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!ApplyOptions())
            {
                return;
            }

            tabNumber = tabControl1.SelectedIndex;

            if (_shapefile.Labels.Serialize() != _initState)
            {
                //m_legend.FireLayerPropertiesChanged(m_handle);
            }

            DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Applies the options
        /// </summary>
        bool ApplyOptions()
        {
            if (_categoryEdited)
            {
                return true;
            }

            if (richTextBox1.Text == "" && !_shapefile.Labels.Empty)
            {
                if (MessageService.Current.Ask("Expression is empty. Remove all the labels?"))
                {
                    _shapefile.Labels.Items.Clear();
                    _shapefile.Labels.Expression = "";
                }
                else
                {
                    return false;
                }
            }
            else if ((!_shapefile.Labels.Synchronized  || _shapefile.Labels.Empty) && richTextBox1.Text != "")
            {
                // generate
                using (var form = new AddLabelsForm(_shapefile, _category.Alignment))
                {
                    if (_context.View.ShowChildView(form, this))
                    {
                        if (_shapefile.PointOrMultiPoint)
                        {
                            _category.Alignment = form.Alignment;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            else if (richTextBox1.Text == "" && _shapefile.Labels.Empty)
            {
                MessageService.Current.Info("No expression was entered.");
                return false;
            }

            if (!_categoryEdited)
            {
                // in case of labels we are editing a copy of the LabelsCategory class, so options should be applied
                _shapefile.Labels.Style = _category;

                if (_shapefile.Labels.Expression != richTextBox1.Text )
                {
                    _shapefile.Labels.Expression = LabelHelper.FixExpression(richTextBox1.Text);
                }
            }

            return true;
        }

        /// <summary>
        ///  Handles the change of transparency by user
        /// </summary>
        private void transparencyControl1_ValueChanged(object sender, byte value)
        {
            Ui2LabelStyle(sender, null);
        }

        #region Expression
        /// <summary>
        /// Adds field to the expression
        /// </summary>
        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
                return;

            richTextBox1.SelectedText = "[" + listBox1.SelectedItem + "] ";
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectedText = "+ ";
        }

        private void btnQuotes_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectedText = "\"\"";
        }

        private void btnNewLine_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectedText = Environment.NewLine;
        }

        /// <summary>
        /// Tests expression entered by user
        /// </summary>
        private void btnTest_Click(object sender, EventArgs e)
        {
            TestExpression();
        }

        private void TestExpression()
        {
            if (richTextBox1.Text.ToLower() == "<no expression>")
            {
                return;
            }

            string expr = LabelHelper.FixExpression(richTextBox1.Text);
            if (expr == String.Empty)
            {
                lblResult.ForeColor = Color.Black;
                lblResult.Text = "No expression";
            }
            else
            {
                string err = "";
                if (!_shapefile.Table.TestExpression(expr, TableValueType.String, ref err))
                {
                    lblResult.ForeColor = Color.Red;
                    lblResult.Text = err;
                }
                else
                {
                    lblResult.ForeColor = Color.Green;
                    lblResult.Text = "Expression is valid";
                }
            }
        }

        /// <summary>
        /// Adds field to the expression
        /// </summary>
        private void listBox1_DoubleClick_1(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
            {
                return;
            }

            richTextBox1.SelectedText = "[" + listBox1.SelectedItem + "] ";
        }
        #endregion

        /// <summary>
        /// Checks the expression during editing
        /// </summary>
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            TestExpression();
            
            if (!_noEvents)
            {
                LabelHelper.DrawPreview(_category, _shapefile, pctPreview, richTextBox1.Text, true);
                RefreshControls();
            }

            btnApply.Enabled = true;
        }

        /// <summary>
        /// Clears the expression in the textbox
        /// </summary>
        private void btnClear_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text.ToLower() == "<no expression>")
            {
                if (MessageService.Current.Ask("Remove labels?"))
                {
                    var lb = _shapefile.Labels.Items;
                    for (int i = 0; i < lb.Count; i++)
                    {
                        for (int j = 0; j < lb.NumParts(i); j++)
                        {
                            lb[i, j].Text = "";
                        }
                    }

                    listBox1.Enabled = true;
                    btnPlus.Enabled = true;
                    btnQuotes.Enabled = true;
                    btnNewLine.Enabled = true;
                    richTextBox1.Enabled = true;
                    richTextBox1.Text = "";

                    _shapefile.Labels.SavingMode = PersistenceType.XmlOverwrite;
                    //lb.Synchronized = true;
                    //if (!lb.Synchronized)
                    //{
                    //    lb.Clear();
                    //}
                }
            }
            else
            {
                richTextBox1.Text = "";
            }
        }
        
        /// <summary>
        /// Building labels visiblity expression
        /// </summary>
        private void btnLabelExpression_Click(object sender, EventArgs e)
        {
            string s = txtLabelExpression.Text;
            using (var form = new QueryBuilderForm(_layer, s, false))
            {
                if (_context.View.ShowChildView(form))
                {
                    if (txtLabelExpression.Text != form.Tag.ToString())
                    {
                        txtLabelExpression.Text = form.Tag.ToString();
                        _shapefile.Labels.VisibilityExpression = txtLabelExpression.Text;
                        btnApply.Enabled = true;
                    }
                }
            }
        }

        /// <summary>
        /// Clears the label expression
        /// </summary>
        private void btnClearLabelsExpression_Click(object sender, EventArgs e)
        {
            txtLabelExpression.Clear();
            _shapefile.Labels.VisibilityExpression = "";
        }

        /// <summary>
        /// Saves the options and updates the map without closing the form
        /// </summary>
        private void btnApply_Click(object sender, EventArgs e)
        {
            if (ApplyOptions())
            {
                //m_legend.FireLayerPropertiesChanged(m_handle);
                _context.Legend.Redraw(LegendRedraw.LegendAndMap);

                _initState = _shapefile.Labels.Serialize();
                RefreshControls();
                btnApply.Enabled = false;
            }
        }

        /// <summary>
        /// Reverts the changes if cancel was hit
        /// </summary>
        private void frmLabelStyle_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.Cancel)
            {
                if (_categoryEdited)
                {
                    _category.Deserialize(_initState);
                }
                else
                {
                    var mode = _shapefile.Labels.SavingMode;
                    _shapefile.Labels.SavingMode = PersistenceType.None;
                    _shapefile.Labels.Deserialize(_initState);
                    _shapefile.Labels.SavingMode = mode;
                }
            }
        }

        /// <summary>
        /// Sets current scale as basic one
        /// </summary>
        private void btnSetCurrent_Click(object sender, EventArgs e)
        {
            var map = _context.Map;
            if (map != null)
            {
                cboBasicScale.Text = map.CurrentScale.ToString("0.00");
            }
        }

        /// <summary>
        /// Sets max visible scale to current scale
        /// </summary>
        private void btnSetMaxScale_Click(object sender, EventArgs e)
        {
            var map = _context.Map;
            cboMaxScale.Text = map.CurrentScale.ToString("0.00");
            btnApply.Enabled = true;
        }

        /// <summary>
        /// Sets min visible scale to current scale
        /// </summary>
        private void btnSetMinScale_Click(object sender, EventArgs e)
        {
            cboMinScale.Text = _context.Map.CurrentScale.ToString("0.00");
            btnApply.Enabled = true;
        }
    }
}
