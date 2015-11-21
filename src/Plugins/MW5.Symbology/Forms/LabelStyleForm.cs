// -------------------------------------------------------------------------------------------
// <copyright file="LabelStyleForm.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using MW5.Api.Enums;
using MW5.Api.Helpers;
using MW5.Api.Interfaces;
using MW5.Api.Legend;
using MW5.Attributes.Model;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Services;
using MW5.Plugins.Symbology.Helpers;
using MW5.Plugins.Symbology.Model;
using MW5.Shared;
using MW5.UI.Enums;
using MW5.UI.Forms;

namespace MW5.Plugins.Symbology.Forms
{
    /// <summary>
    /// A dialog to generate labels and change their style.
    /// </summary>
    public partial class LabelStyleForm : MapWindowForm
    {
        private const string NoExpression = "<no expression>";
        private static int tabNumber;
        private readonly bool _categoryEdited;
        private ILabelStyle _category;
        private IFeatureSet _featureSet;
        private string _initState = "";
        private bool _fieldSelection;   // field was just selected in the main tab combo box
        private ILayer _layer;
        private bool _noEvents;

        /// <summary>
        /// Constructor for setting label expression and options
        /// </summary>
        public LabelStyleForm(IAppContext context, ILayer layer)
            : base(context)
        {
            InitializeComponent();

            InitLayer(context, layer);

            // old-style labels not based on expression
            if (_featureSet.Labels.Expression == "" && !_featureSet.Labels.Empty &&
                _featureSet.Labels.Items[0].Text != "")
            {
                txtExpression.Text = NoExpression;
                listBox1.Enabled = false;
                btnPlus.Enabled = false;
                btnQuotes.Enabled = false;
                btnNewLine.Enabled = false;
                txtExpression.Enabled = false;
            }
            else
            {
                txtExpression.Text = LabelHelper.StripNewLineQuotes(_featureSet.Labels.Expression);
            }

            dynamicVisibilityControl1.Initialize(_featureSet.Labels, _context.Map.CurrentZoom, _context.Map.CurrentScale);
            dynamicVisibilityControl1.ValueChanged += (s, e) => { btnApply.Enabled = true; };

            Initialize(_featureSet.Labels.Style);

            tabControlAdv1.SelectedIndex = tabNumber;
        }

        /// <summary>
        /// Constructor for editing single category
        /// </summary>
        public LabelStyleForm(IAppContext context, ILayer layer, ILabelStyle lb)
        {
            InitializeComponent();

            InitLayer(context, layer);

            _categoryEdited = true;
            Initialize(lb);

            tabControlAdv1.SelectedIndex = tabNumber;

            // expression isn't available for the categories
            if (_categoryEdited)
            {
                tabControlAdv1.TabPages.Remove(tabVisibility);
                tabControlAdv1.TabPages.Remove(tabPosition); 
                tabControlAdv1.TabPages.Remove(tabExpression);
            }

            lblResult.Visible = false;
            btnApply.Visible = false;
        }

        private IAttributeField SelectedField
        {
            get { return (cboField.SelectedItem as FieldAdapter).Field; }
        }

        /// <summary>
        /// Applies the options and generates labels if needed.
        /// </summary>
        private bool ApplyOptions()
        {
            if (_categoryEdited)
            {
                return true;
            }

            bool hasExpression = !string.IsNullOrWhiteSpace(txtExpression.Text);
            bool hasLabels = !_featureSet.Labels.Empty;

            if (!hasExpression && hasLabels)
            {
                if (MessageService.Current.Ask("Expression is empty. Remove all the labels?"))
                {
                    _featureSet.Labels.Items.Clear();
                    _featureSet.Labels.Expression = "";
                }
                else
                {
                    return false;
                }
            }
            else if ((!hasLabels || !_featureSet.Labels.Synchronized) && hasExpression)
            {
                GenerateLabels();
            }
            else if (!hasExpression && _featureSet.Labels.Empty)
            {
                MessageService.Current.Info("No expression was entered.");
                return false;
            }

            ApplyStyle();

            return true;
        }

        private void ApplyStyle()
        {
            Ui2LabelStyle(null, null);

            _featureSet.Labels.Style = _category;

            dynamicVisibilityControl1.ApplyChanges();

            if (_featureSet.Labels.Expression != txtExpression.Text)
            {
                _featureSet.Labels.Expression = LabelHelper.FixExpression(txtExpression.Text);
            }
        }

        private void ClearLabels()
        {
            var lb = _featureSet.Labels.Items;

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
            txtExpression.Enabled = true;
            txtExpression.Text = "";

            _featureSet.Labels.SavingMode = PersistenceType.XmlOverwrite;

            //lb.Synchronized = true;
            //if (!lb.Synchronized)
            //{
            //    lb.Clear();
            //}
        }

        /// <summary>
        /// Draws preview of the label
        /// </summary>
        private void DrawPreview()
        {
            RefreshControls();

            if (_noEvents)
            {
                return;
            }

            if (_category.Visible)
            {
                string text = _categoryEdited ? _featureSet.Labels.Expression : txtExpression.Text;
                LabelHelper.DrawPreview(_category, _featureSet, pctPreview, text, true);
            }
            else
            {
                var img = new Bitmap(pctPreview.ClientRectangle.Width, pctPreview.ClientRectangle.Height);
                if (pctPreview.Image != null)
                {
                    pctPreview.Image.Dispose();
                }
                pctPreview.Image = img;
            }
        }

        private bool GenerateLabels()
        {
            using (var form = new AddLabelsForm(_featureSet, _category.Alignment))
            {
                if (_context.View.ShowChildView(form, this))
                {
                    if (_featureSet.PointOrMultiPoint)
                    {
                        _category.Alignment = form.Alignment;
                    }

                    return true;
                }
            }

            return false;
        }

        private string GetFloatFormat()
        {
            if (cboDecimalPlaces.SelectedIndex == 0) return "%g";
            return string.Format("%.{0}f", cboDecimalPlaces.SelectedIndex);
        }

        private void InitAlignment(ILabelsLayer labels)
        {
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
        }

        private void InitDecimalPlaces()
        {
            cboDecimalPlaces.Items.Add("Auto");

            for (int i = 1; i <= 6; i++)
            {
                cboDecimalPlaces.Items.Add(i.ToString(CultureInfo.InvariantCulture));
            }

            cboDecimalPlaces.SelectedIndex = 0;
        }

        private void InitFields()
        {
            if (_categoryEdited) return;

            var fields = _featureSet.Fields.Where(f => !f.Name.EqualsIgnoreCase(ShapefileHelper.MWShapeIdField)).ToList();

            listBox1.DataSource = fields.ToList();

            var wrappers = fields.Select(f => new FieldAdapter(f)).ToList();
            wrappers.Insert(0, new FieldAdapter("<none>"));
            cboField.DataSource = wrappers.ToList();

            wrappers.Add(new FieldAdapter("<expression>"));
            wrappers = fields.Where(f => f.Type != AttributeType.String).Select(f => new FieldAdapter(f)).ToList();
            
            cboSortField.DataSource = wrappers.ToList();
        }

        private void InitFonts()
        {
            cboFontName.Items.Clear();

            foreach (var family in FontFamily.Families)
            {
                cboFontName.Items.Add(family.Name);
            }
        }

        private void InitLayer(IAppContext context, ILayer layer)
        {
            if (context == null) throw new ArgumentNullException("context");

            if (layer == null || layer.FeatureSet == null)
            {
                throw new ArgumentNullException("layer");
            }

            _layer = layer;
            _featureSet = _layer.FeatureSet;

            Text = "Label Style: " + layer.Name;
        }

        private void InitScales()
        {
            string[] scales =
                {
                    "1", "10", "100", "1000", "5000", "10000", "25000", "50000", "100000", "250000",
                    "500000", "1000000", "10000000"
                };

            cboBasicScale.Items.Clear();

            foreach (string t in scales)
            {
                cboBasicScale.Items.Add(t);
            }
        }

        private void InitTextRendering()
        {
            var hints = EnumHelper.GetValues<TextRenderingHint>();
            cboTextRenderingHint.DataSource = hints;
            SetSelectedIndex(cboTextRenderingHint, (int)_featureSet.Labels.TextRenderingHint);
            cboTextRenderingHint.SelectedIndexChanged += Ui2LabelStyle;
        }

        /// <summary>
        /// Initializes controls of the form
        /// </summary>
        private void Initialize(ILabelStyle lb)
        {
            _category = lb;

            _noEvents = true;

            InitFonts();

            InitDecimalPlaces();

            icbLineType.ComboStyle = ImageComboStyle.LineStyle;
            icbLineWidth.ComboStyle = ImageComboStyle.LineWidth;

            icbFrameType.Color1 = Color.Transparent;
            icbFrameType.ComboStyle = ImageComboStyle.FrameType;
            icbFrameType.SelectedIndex = 0;

            InitFields();

            InitScales();

            // displaying options in the GUI
            LabelStyle2Ui(_category);

            TestExpression();

            txtLabelExpression.Text = _featureSet.Labels.VisibilityExpression;

            // serialization
            if (_categoryEdited)
            {
                _initState = _category.Serialize();
            }
            else
            {
                var mode = _featureSet.Labels.SavingMode;
                _featureSet.Labels.SavingMode = PersistenceType.None;
                _initState = _featureSet.Labels.Serialize();
                _featureSet.Labels.SavingMode = mode;
            }

            cboLabelsVerticalPosition.Items.Clear();
            cboLabelsVerticalPosition.Items.Add("Above layer");
            cboLabelsVerticalPosition.Items.Add("Above all layers");

            var labels = _featureSet.Labels;

            cboLabelsVerticalPosition.SelectedIndex = (int)labels.VerticalPosition;
            chkLabelsRemoveDuplicates.Checked = labels.RemoveDuplicates;
            chkAviodCollisions.Checked = labels.AvoidCollisions;
            chkScaleLabels.Checked = labels.ScaleLabels;
            cboBasicScale.Text = labels.BasicScale.ToString(CultureInfo.InvariantCulture);

            RestoreFields(labels);

            udLabelOffsetX.SetValue(labels.OffsetX);
            udLabelOffsetY.SetValue(labels.OffsetY);
            udLabelsBuffer.SetValue(labels.CollisionBuffer);

            InitAlignment(labels);

            optAlignCenter.Enabled = !_featureSet.PointOrMultiPoint;

            btnApply.Enabled = !string.IsNullOrWhiteSpace(txtExpression.Text) && _featureSet.Labels.Empty;

            InitTextRendering();

            _noEvents = false;

            DrawPreview();
        }

        private void RestoreFields(ILabelsLayer labels)
        {
            string name = GetLabelField(labels);

            if (string.IsNullOrWhiteSpace(name))
            {
                cboField.SelectedIndex = !string.IsNullOrWhiteSpace(labels.Expression) ? cboField.Items.Count - 1 : 0;
            }
            else
            {
                SetFieldValue(cboField, name);
            }
            
            if (_featureSet != null)
            {
                SetFieldValue(cboSortField, _featureSet.SortField);
                chkSortAscending.Checked = _featureSet.SortAscending;
            }

            chkLogScaleForSize.Checked = labels.LogScaleForSize;
            chkUseVariableSize.Checked = labels.UseVariableSize;
        }

        private string GetLabelField(ILabelsLayer labels)
        {
            var s = labels.Expression.Trim();
            if (s.StartsWith("[") && s.EndsWith("]"))
            {
                return s.Substring(1, s.Length - 2);
            }

            return string.Empty;
        }

        private void SetFieldValue(ComboBox combo, string text)
        {
            foreach (var item in combo.Items)
            {
                if (item.ToString().EqualsIgnoreCase(text))
                {
                    combo.SelectedItem = item;
                    break;
                }
            }
        }

        /// <summary>
        /// Loads label options to the GUI controls
        /// </summary>
        private bool LabelStyle2Ui(ILabelStyle lb)
        {
            if (lb == null) return false;

            chkVisible.Checked = _category.Visible;

            string fontName = lb.FontName;
            int j = 0;
            foreach (var family in FontFamily.Families)
            {
                if (family.Name == fontName) cboFontName.SelectedIndex = j;
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
            udFontSize2.Value = lb.FontSize2;

            clpFont1.Color = lb.FontColor;

            udFramePaddingX.SetValue(lb.FramePaddingX);
            udFramePaddingY.SetValue(lb.FramePaddingY);

            // font outlines
            chkHaloVisible.Checked = lb.HaloVisible;
            chkShadowVisible.Checked = lb.ShadowVisible;

            clpShadow.Color = lb.ShadowColor;
            clpHalo.Color = lb.HaloColor;

            udHaloSize.SetValue(lb.HaloSize);
            udShadowOffsetX.SetValue(lb.ShadowOffsetX);
            udShadowOffsetY.SetValue(lb.ShadowOffsetY);

            // frame options
            chkUseFrame.Checked = lb.FrameVisible;
            icbFrameType.SelectedIndex = (int)lb.FrameType;

            icbLineType.SelectedIndex = (int)lb.FrameOutlineStyle;

            clpFrame1.Color = lb.FrameBackColor;
            clpFrameBorder.Color = lb.FrameOutlineColor;

            udFramePaddingX.SetValue(lb.FramePaddingX);
            udFramePaddingY.SetValue(lb.FramePaddingY);

            if (lb.FrameOutlineWidth < 1) lb.FrameOutlineWidth = 1;
            if (lb.FrameOutlineWidth > icbLineWidth.Items.Count) lb.FrameOutlineWidth = icbLineWidth.Items.Count;
            icbLineWidth.SelectedIndex = lb.FrameOutlineWidth - 1;

            transparencyControl1.Value = lb.FrameTransparency;

            return true;
        }

        /// <summary>
        /// Saves the options and updates the map without closing the form
        /// </summary>
        private void OnApplyClick(object sender, EventArgs e)
        {
            if (ApplyOptions())
            {
                //m_legend.FireLayerPropertiesChanged(m_handle);
                _context.Legend.Redraw(LegendRedraw.LegendAndMap);

                _initState = _featureSet.Labels.Serialize();

                RefreshControls();

                btnApply.Enabled = false;
            }
        }

        /// <summary>
        /// Clears the expression in the textbox
        /// </summary>
        private void OnClearClick(object sender, EventArgs e)
        {
            if (txtExpression.Text.ToLower() == NoExpression)
            {
                if (MessageService.Current.Ask("Remove labels?"))
                {
                    ClearLabels();
                }
            }
            else
            {
                txtExpression.Text = "";
            }
        }

        /// <summary>
        /// Clears gradient of the frame
        /// </summary>
        private void OnClearFrameGradientClick(object sender, EventArgs e)
        {
            _category.FrameGradientMode = LinearGradient.None;
            DrawPreview();
        }

        /// <summary>
        /// Clears the label expression
        /// </summary>
        private void OnClearLabelsExpressionClick(object sender, EventArgs e)
        {
            txtLabelExpression.Clear();
            _featureSet.Labels.VisibilityExpression = "";
        }

        /// <summary>
        /// Adds field to the expression
        /// </summary>
        private void OnFieldListBoxDoubleClick(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
            {
                return;
            }

            txtExpression.SelectedText = "[" + listBox1.SelectedItem + "] ";
        }

        /// <summary>
        /// Reverts the changes if cancel was hit
        /// </summary>
        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.Cancel && btnApply.Enabled)
            {
                if (_categoryEdited)
                {
                    _category.Deserialize(_initState);
                }
                else
                {
                    var mode = _featureSet.Labels.SavingMode;
                    _featureSet.Labels.SavingMode = PersistenceType.None;
                    _featureSet.Labels.Deserialize(_initState);
                    _featureSet.Labels.SavingMode = mode;
                }
            }
        }

        /// <summary>
        /// Building labels visiblity expression
        /// </summary>
        private void OnLabelExpressionClick(object sender, EventArgs e)
        {
            string s = txtLabelExpression.Text;

            if (FormHelper.ShowQueryBuilder(_context, _layer, this, ref s, false))
            {
                if (txtLabelExpression.Text != s)
                {
                    txtLabelExpression.Text = s;
                    _featureSet.Labels.VisibilityExpression = txtLabelExpression.Text;
                    btnApply.Enabled = true;
                }
            }
        }

        private void SetExpressionAfterFieldChange(string expression)
        {
            _fieldSelection = true;
            txtExpression.Text = expression;
            OnExpressionChanged(null, null);
            _fieldSelection = false;
        }

        private void OnFieldChanged(object sender, EventArgs e)
        {
            if (cboField.SelectedIndex == 0)
            {
                SetExpressionAfterFieldChange(string.Empty);
                return;
            }

            var fld = SelectedField;
            if (fld != null)
            {
                SetExpressionAfterFieldChange("[" + fld.Name + "]");
            }
            else
            {
                tabControlAdv1.SelectedTab = tabExpression;
                txtExpression.Focus();
            }
        }

        /// <summary>
        /// Adds field to the expression
        /// </summary>
        private void OnListboxDoubleClick(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null) return;

            var fld = listBox1.SelectedItem as IAttributeField;
            if (fld != null)
            {
                txtExpression.SelectedText = "[" + fld.Name + "] ";
            }
        }

        /// <summary>
        ///  Saves the options, closes the form.
        /// </summary>
        private void OnOkClick(object sender, EventArgs e)
        {
            if (!ApplyOptions())
            {
                return;
            }

            _context.Legend.Redraw(LegendRedraw.LegendAndMap);

            tabNumber = tabControlAdv1.SelectedIndex;

            if (_featureSet.Labels.Serialize() != _initState)
            {
                //m_legend.FireLayerPropertiesChanged(m_handle);
            }

            DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Sets current scale as basic one
        /// </summary>
        private void OnSetCurrentClick(object sender, EventArgs e)
        {
            var map = _context.Map;
            if (map != null)
            {
                cboBasicScale.Text = map.CurrentScale.ToString("0.00");
            }
        }

        /// <summary>
        /// Sets gradient for the frame color
        /// </summary>
        private void OnSetFrameGradientClick(object sender, EventArgs e)
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
        /// Checks the expression during editing
        /// </summary>
        private void OnExpressionChanged(object sender, EventArgs e)
        {
            TestExpression();

            if (!_noEvents)
            {
                LabelHelper.DrawPreview(_category, _featureSet, pctPreview, txtExpression.Text, true);
                RefreshControls();
            }

            if (!_fieldSelection)
            {
                // it's user input, select the <expression> on the main tab
                cboField.SelectedIndex = cboField.Items.Count - 1;
            }

            btnApply.Enabled = true;
        }

        /// <summary>
        ///  Handles the change of transparency by user
        /// </summary>
        private void OnTransparencyControlValueChanged(object sender, byte value)
        {
            Ui2LabelStyle(sender, null);
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

            cboBasicScale.Enabled = chkScaleLabels.Checked;
            btnSetCurrent.Enabled = chkScaleLabels.Checked;
            lblScaleLabels.Enabled = chkScaleLabels.Checked;

            bool hasSortField = cboSortField.SelectedIndex > 0;
            udFontSize2.Enabled = chkUseVariableSize.Checked && hasSortField;
            chkLogScaleForSize.Enabled = chkUseVariableSize.Checked && hasSortField;
            chkUseVariableSize.Enabled = hasSortField;

            bool noLabels = false;
            bool hasExpression = txtExpression.Text.Length > 0;
            if (!_categoryEdited)
            {
                noLabels = !hasExpression;
                groupBox6.Enabled = hasExpression;
                groupBox11.Enabled = hasExpression;
                groupBox20.Enabled = hasExpression;
                groupLabelAlignment.Enabled = hasExpression;
                chkUseFrame.Enabled = hasExpression;
                groupBox2.Enabled = hasExpression;
                groupBox3.Enabled = hasExpression;
                groupBox4.Enabled = hasExpression;
                groupBox5.Enabled = hasExpression;
                chkScaleLabels.Enabled = hasExpression;
                dynamicVisibilityControl1.Enabled = hasExpression;
            }

            groupBox4.Enabled = !noLabels && chkUseFrame.Checked;
            groupBox2.Enabled = !noLabels && chkUseFrame.Checked;

            _noEvents = false;
        }

        /// <summary>
        /// Sets selected index in the combo in case it's the valid one
        /// </summary>
        private static void SetSelectedIndex(ComboBox combo, int index)
        {
            if (index >= 0 && index < combo.Items.Count)
            {
                combo.SelectedIndex = index;
            }
        }

        private void TestExpression()
        {
            if (txtExpression.Text.ToLower() == NoExpression)
            {
                return;
            }

            string expr = LabelHelper.FixExpression(txtExpression.Text);
            if (expr == String.Empty)
            {
                lblResult.ForeColor = Color.Black;
                lblResult.Text = "No expression";
            }
            else
            {
                string err = "";
                if (!_featureSet.Table.TestExpression(expr, TableValueType.String, out err))
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
            lb.FontSize2 = (int)udFontSize2.Value;

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

            if (tabControlAdv1.SelectedTab == tabFrame)
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
            lb.FrameOutlineWidth = icbLineWidth.SelectedIndex + 1;

            lb.FrameTransparency = transparencyControl1.Value;
            lb.FontTransparency = transparencyControl1.Value;

            // passed from the main form
            var labels = _featureSet.Labels;
            labels.RemoveDuplicates = chkLabelsRemoveDuplicates.Checked;
            labels.AvoidCollisions = chkAviodCollisions.Checked;
            labels.ScaleLabels = chkScaleLabels.Checked;

            double val;
            labels.BasicScale = (double.TryParse(cboBasicScale.Text, out val)) ? val : 0.0;
            labels.VerticalPosition = (VerticalPosition)cboLabelsVerticalPosition.SelectedIndex;

            var fld = cboSortField.SelectedItem as FieldAdapter;
            labels.LogScaleForSize = chkLogScaleForSize.Checked;
            labels.UseVariableSize = chkUseVariableSize.Checked;

            if (_featureSet != null)
            {
                _featureSet.SortField = (fld != null && !fld.Empty) ? fld.Field.Name : string.Empty;
                _featureSet.SortAscending = chkSortAscending.Checked;
            }

            lb.OffsetX = (double)udLabelOffsetX.Value;
            lb.OffsetY = (double)udLabelOffsetY.Value;
            _featureSet.Labels.CollisionBuffer = (int)udLabelsBuffer.Value;

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

            btnApply.Enabled = true;

            _featureSet.Labels.TextRenderingHint = (TextRenderingHint)cboTextRenderingHint.SelectedIndex;

            string format = _featureSet.Labels.FloatNumberFormat;
            string newFormat = GetFloatFormat();
            _featureSet.Labels.FloatNumberFormat = newFormat;

            if (newFormat != format)
            {
                //m_shapefile.Labels.ForceRecalculateExpression();
            }

            DrawPreview();
        }

        private void OnNewLineClick(object sender, EventArgs e)
        {
            txtExpression.SelectedText = Environment.NewLine;
        }

        private void OnPlusClick(object sender, EventArgs e)
        {
            txtExpression.SelectedText = "+ ";
        }

        private void OnQuotesClick(object sender, EventArgs e)
        {
            txtExpression.SelectedText = "\"\"";
        }

        private void UpdateSize(object sender, EventArgs e)
        {
            if (udFontSize2.Value < udFontSize.Value)
            {
                udFontSize2.Value = udFontSize.Value;
            }

            Ui2LabelStyle(null, null);
        }
    }
}