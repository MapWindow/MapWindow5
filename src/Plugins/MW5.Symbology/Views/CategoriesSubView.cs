// -------------------------------------------------------------------------------------------
// <copyright file="CategoriesSubView.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using MW5.Api.Enums;
using MW5.Api.Interfaces;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mvp;
using MW5.Plugins.Symbology.Model;
using MW5.Plugins.Symbology.Services;
using MW5.Shared;

namespace MW5.Plugins.Symbology.Views
{
    /// <summary>
    /// UI for displaying and generating list of categories for FeatureSet.
    /// </summary>
    [HasRegions]
    public partial class CategoriesSubView : CategoriesSubViewBase, ISubView
    {
        private readonly IAppContext _context;

        #region Constructors

        public CategoriesSubView(IAppContext context)
        {
            if (context == null) throw new ArgumentNullException("context");
            _context = context;

            InitializeComponent();
        }

        #endregion

        #region Events

        public event Action CategoryStyleClicked;

        public event Action CategoryNameChanged;

        #endregion

        #region Properties

        public IEnumerable<Control> Buttons
        {
            get
            {
                yield return btnCategoryClear;
                yield return btnCategoryGenerate;
                yield return btnCategoryRemove;
                yield return btnCategoryAppearance;
                yield return btnChangeColorScheme;
            }
        }

        public Classification Classification
        {
            get { return UniqueValues ? Classification.UniqueValues : Classification.NaturalBreaks; }
        }

        public IFeatureSet FeatureSet
        {
            get { return Model.Layer.FeatureSet; }
        }

        public int FieldIndex
        {
            get
            {
                if (lstFields1.SelectedItem == null)
                {
                    return -1;
                }

                string name = lstFields1.SelectedItem.ToString().ToLower().Trim();
                return FeatureSet.Fields.IndexByName(name);
            }
        }

        public string FieldName
        {
            get { return lstFields1.SelectedItem != null ? lstFields1.SelectedItem.ToString() : string.Empty; }
        }

        public int MaxPointSize
        {
            get { return Convert.ToInt32(udMaxSize.Value); }
        }

        public SymbologyMetadata Metadata
        {
            get { return Model.Metadata; }
        }

        public int MinPointSize
        {
            get { return Convert.ToInt32(udMinSize.Value); }
        }

        public int NumCategories
        {
            get { return Convert.ToInt32(udNumCategories.Value); }
        }

        public bool RandomColors
        {
            get { return chkRandomColors.Checked; }
        }

        public IFeatureCategory SelectedCategory
        {
            get
            {
                if (dgvCategories.CurrentCell == null)
                {
                    return null;
                }

                int rowIndex = dgvCategories.CurrentCell.RowIndex;
                return Model.FeatureSet.Categories[rowIndex];
            }
        }

        public ColorBlend SelectedColorScheme
        {
            get { return icbCategories.GetSelectedItem(); }
        }

        public bool SetGradient
        {
            get { return chkSetGradient.Checked; }
        }

        public IEnumerable<ToolStripItemCollection> ToolStrips
        {
            get { yield break; }
        }

        public bool UniqueValues
        {
            get { return chkUniqueValues.Checked; }
        }

        public bool UseVariableSize
        {
            get { return chkUseVariableSize.Checked; }
        }

        #endregion

        #region Public Methods

        public void RemoveSelectedCategory()
        {
            dgvCategories.RemoveSelectedCategory();
        }

        public void Initialize()
        {
            dgvCategories.StyleClicked += (s, e) => Invoke(CategoryStyleClicked);
            dgvCategories.CategoryNameChanged += (s, e) => Invoke(CategoryNameChanged);
            dgvCategories.Initialize(FeatureSet);

            icbCategories.ComboStyle = SchemeType.Graduated;
            icbCategories.SchemeTarget = SchemeTarget.Vector;
            if (icbCategories.Items.Count > 0)
            {
                icbCategories.SelectedIndex = 0;
            }

            // layer settings
            var metadata = Metadata;
            chkSetGradient.Checked = metadata.CategoriesUseGradient;
            chkRandomColors.Checked = metadata.CategoriesRandomColors;
            udNumCategories.Value = metadata.CategoriesCount;
            chkUniqueValues.Checked = metadata.CategoriesClassification == Classification.UniqueValues;
            chkUseVariableSize.Checked = metadata.CategoriesVariableSize;

            // fills in the list of fields
            FillFieldList(metadata.CategoriesFieldName);

            // setting the color scheme that is in use
            icbCategories.SetSelectedItem(metadata.CategoriesColorScheme);

            var fs = FeatureSet;
            var type = fs.GeometryType;
            groupVariableSize.Visible = (type == GeometryType.Point || type == GeometryType.Polyline);

            switch (type)
            {
                case GeometryType.Point:
                    udMinSize.SetValue(fs.Style.Marker.Size);
                    break;
                case GeometryType.Polyline:
                    udMinSize.SetValue(fs.Style.Line.Width);
                    break;
            }

            udMaxSize.SetValue((double)udMinSize.Value + metadata.CategoriesSizeRange);

            UpdateView();

            if (dgvCategories.Rows.Count > 0 && dgvCategories.Columns.Count > 0)
            {
                dgvCategories[0, 0].Selected = true;
            }

            InitToolTips();
        }

        public void Lock(bool value)
        {
            btnCategoryGenerate.Enabled = !value;
        }

        public void UpdateView()
        {
            dgvCategories.RefreshList();
            RefreshControls();
        }

        public void InvalidateView()
        {
            dgvCategories.Invalidate();
            RefreshControls();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Fills the list of fields
        /// </summary>
        private void FillFieldList(string name)
        {
            if (name == string.Empty)
            {
                // we need to preserve currently selected field
                name = lstFields1.SelectedItem != null ? lstFields1.SelectedItem.ToString().Trim() : string.Empty;
            }
            // else  = we need some particular field as selected

            lstFields1.Items.Clear();

            // adding names
            var fs = FeatureSet;

            foreach (var fld in fs.Fields)
            {
                if (!chkUniqueValues.Checked && fld.Type == AttributeType.String || chkUniqueValues.Checked && fld.Type != AttributeType.String)
                {
                    continue;
                }

                lstFields1.Items.Add("  " + fld.Name);
            }

            // setting the selected field back
            if (name != string.Empty)
            {
                for (int i = 0; i < lstFields1.Items.Count; i++)
                {
                    if (lstFields1.Items[i].ToString().ToLower().Trim() == name.ToLower())
                    {
                        lstFields1.SelectedIndex = i;
                        break;
                    }
                }
            }

            if (lstFields1.SelectedItem == null && lstFields1.Items.Count > 0)
            {
                lstFields1.SelectedIndex = 0;
            }

            RefreshControls();
        }

        private void InitToolTips()
        {
            // categories
            toolTip1.SetToolTip(lstFields1, "List of fields from the attribute table");
            toolTip1.SetToolTip(udNumCategories, "Specifies the number of classes to be generated");
            toolTip1.SetToolTip(chkUniqueValues, "A separate category will be generated for every unique lock of the field");
            toolTip1.SetToolTip(icbCategories, "List of available color schemes. \nNew color schemes can be added by clicking <...> button");
            toolTip1.SetToolTip(chkSetGradient, "Sets color gradient for particular shapes");
            toolTip1.SetToolTip(chkRandomColors, "Chooses the colors from color scheme randomly");
            toolTip1.SetToolTip(btnChangeColorScheme, "Opens color schemes editor");
            toolTip1.SetToolTip(dgvCategories, "List of categories. \nClick on the preview to change settings." + "\nClick on the name to edit it.\nCount column displays number of shapes which fell in the category");

            toolTip1.SetToolTip(chkUseVariableSize, "Enables the graduated symbol size.\nApplicable for point layers only");
            toolTip1.SetToolTip(udMinSize, "Minimum size of symbols");
            toolTip1.SetToolTip(udMinSize, "Maximum size of symbols");
            toolTip1.SetToolTip(btnCategoryGenerate, "Generates categories and applies new settings");
            toolTip1.SetToolTip(btnCategoryAppearance, "Changes style of the selected category");
            toolTip1.SetToolTip(btnCategoryRemove, "Removes selected category");
            toolTip1.SetToolTip(btnCategoryClear, "Removes all categories");
        }

        /// <summary>
        /// Toggles between random and graduated colors schemes
        /// </summary>
        private void OnRandomColorsChecked(object sender, EventArgs e)
        {
            int index = icbCategories.SelectedIndex;
            icbCategories.ComboStyle = chkRandomColors.Checked ? SchemeType.Random : SchemeType.Graduated;
            icbCategories.UpdateItems();

            if (index >= 0 && index < icbCategories.Items.Count)
            {
                icbCategories.SelectedIndex = index;
            }
        }

        /// <summary>
        /// Toggles between unique values and natural breaks. Natural break are available for numeric fields only.
        /// </summary>
        private void OnUniqueValuesChecked(object sender, EventArgs e)
        {
            FillFieldList(string.Empty);
        }

        private void RefreshControls()
        {
            udMinSize.Enabled = chkUseVariableSize.Checked;
            udMaxSize.Enabled = chkUseVariableSize.Checked;
            udNumCategories.Enabled = !chkUniqueValues.Checked;
            btnCategoryRemove.Enabled = (dgvCategories.SelectedCells.Count > 0);
            btnCategoryClear.Enabled = (dgvCategories.Rows.Count > 0);
        }

        #endregion
    }

    public class CategoriesSubViewBase : SubViewBase<CategoriesSubViewModel>
    {
    }
}