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
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;
using MW5.Api.Enums;
using MW5.Api.Helpers;
using MW5.Api.Interfaces;
using MW5.Api.Legend;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Services;
using MW5.Plugins.Symbology.Controls.ImageCombo;
using MW5.Plugins.Symbology.Helpers;
using MW5.UI.Enums;
using MW5.UI.Forms;

namespace MW5.Plugins.Symbology.Forms
{
    public partial class CategoriesForm : MapWindowForm
    {
        private const string CATEGORIES_FILE_FILTER = "Legend categories (*.mwleg)|*.mwleg";

        private const int CMN_VISIBLE = 0;
        private const int CMN_STYLE = 1;
        private const int CMN_NAME = 2;
        private const int CMN_COUNT = 3;
        private const int CMN_WIDTH = 4;

        private readonly ILayer _layer;
        private readonly IFeatureSet _shapefile;
        private readonly int _layerHandle;
        private bool _noEvents;
        private string _initState = "";

        #region Initialization

        /// <summary>
        /// Creates a new instance of the CategoriesForm class
        /// </summary>
        public CategoriesForm(IAppContext context, ILayer layer)
            : base(context)
        {
            if (context == null) throw new ArgumentNullException("context");

            if (layer == null || layer.FeatureSet == null)
            {
                throw new ArgumentNullException("layer");
            }
            _shapefile = layer.FeatureSet;
            _layer = layer;
            _layerHandle = layer.Handle;

            Init();
        }

        private void Init()
        {
            InitializeComponent();

            _initState = _shapefile.Categories.Serialize();

            _noEvents = true;
            ColorSchemeProvider.SetFirstColorScheme(SchemeTarget.Vector, _shapefile);

            icbFillStyle.ComboStyle = ImageComboStyle.HatchStyleWithNone;
            icbLineWidth.ComboStyle = ImageComboStyle.LineWidth;

            groupLine.Visible = false;
            groupFill.Visible = false;
            groupPoint.Visible = false;

            groupLine.Parent = groupFill.Parent;
            groupPoint.Parent = groupFill.Parent;
            groupLine.Top = groupFill.Top;
            groupLine.Left = groupFill.Left;
            groupPoint.Top = groupFill.Top;
            groupPoint.Left = groupFill.Left;

            if (_shapefile.GeometryType == GeometryType.Point)
            {
                groupPoint.Visible = true;
            }
            else if (_shapefile.GeometryType == GeometryType.Polyline)
            {
                groupLine.Visible = true;
            }
            else if (_shapefile.GeometryType == GeometryType.Polygon)
            {
                groupFill.Visible = true;
            }

            clpLine.SelectedColorChanged += Ui2Categories;
            clpPointFill.SelectedColorChanged += Ui2Categories;
            clpPolygonFill.SelectedColorChanged += Ui2Categories;

            icbFillStyle.SelectedIndexChanged += Ui2Categories;
            icbLineWidth.SelectedIndexChanged += Ui2Categories;
            udPointSize.ValueChanged += Ui2Categories;

            // updates the list
            RefreshCategoriesList();
            _noEvents = false;

            RefreshControlState();
        }
        #endregion

        #region Categories buttons
        
        /// <summary>
        /// Generation of categories with the full set of options
        /// </summary>
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            using (var form = new GenerateCategoriesForm(_context, _layer))
            {
                if (_context.View.ShowChildView(form, this))
                {
                    Enabled = false;
                    Cursor = Cursors.WaitCursor;
                    try
                    {
                        RefreshCategoriesList();
                    }
                    finally
                    {
                        Enabled = true;
                        Cursor = Cursors.Default;
                    }

                    if (dgvCategories.RowCount > 0)
                    {
                        dgvCategories.CurrentCell = dgvCategories[1, 0];
                    }
                }
            }
        }

        /// <summary>
        /// Adds a single category
        /// </summary>
        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            using (var form = new AddCategoriesForm())
            {
                if (_context.View.ShowChildView(form, this))
                {
                    var blend = form.icbColors.ColorSchemes[form.icbColors.SelectedIndex];
                    var scheme = blend.ToColorScheme();
                    int count = (int) form.numericUpDownExt1.Value;

                    for (int i = 0; i < count; i++)
                    {
                        Color color;
                        if (form.chkRandom.Checked)
                        {
                            color = scheme.GetRandomColor((i + 1)/(double) count);
                        }
                        else
                        {
                            color = scheme.GetGraduatedColor((i + 1)/(double) count);
                        }

                        var cat = _shapefile.Categories.Add("Category " + _shapefile.Categories.Count);

                        if (_shapefile.PointOrMultiPoint || _shapefile.GeometryType == GeometryType.Polygon)
                        {
                            cat.Style.Fill.Color = color;
                        }
                        else if (_shapefile.GeometryType == GeometryType.Polyline)
                        {
                            cat.Style.Line.Color = color;
                        }
                    }

                    form.Dispose();

                    int rowIndex = dgvCategories.CurrentCell != null ? dgvCategories.CurrentCell.RowIndex : 0;

                    RefreshCategoriesList();

                    if (dgvCategories.RowCount > 0)
                    {
                        dgvCategories.CurrentCell = dgvCategories[rowIndex, 0];
                    }
                }
            }
        }

        /// <summary>
        /// Removes the selected category
        /// </summary>
        private void btnCategoriesRemove_Click(object sender, EventArgs e)
        {
            if (dgvCategories.CurrentCell == null)
            {
                return;
            }

            int index = dgvCategories.CurrentCell.RowIndex;
            int cmnIndex = dgvCategories.CurrentCell.ColumnIndex;
            _shapefile.Categories.RemoveAt(index);

            RefreshCategoriesList();

            if (dgvCategories.Rows.Count != 0)
            {
                if (index > dgvCategories.Rows.Count - 1) 
                {
                    index--;
                }
                dgvCategories.CurrentCell = dgvCategories[cmnIndex, index];
            }

            RefreshControlState();
        }

        /// <summary>
        /// Moves the selected category up
        /// </summary>
        private void btnCategoryMoveUp_Click(object sender, EventArgs e)
        {
            if (dgvCategories.CurrentCell == null)
            {
                return;
            }

            if (dgvCategories.CurrentCell.RowIndex > 0)
            {
                int index = dgvCategories.CurrentCell.RowIndex;
                int colIndex = dgvCategories.CurrentCell.ColumnIndex;

                bool result = _shapefile.Categories.MoveUp(index);
                    
                if (result)
                {
                    UpdateGridCategory(index);
                    UpdateGridCategory(index - 1);
                    _noEvents = true;
                    dgvCategories.CurrentCell = dgvCategories[colIndex, index - 1];
                    _noEvents = false;
                        
                    RefreshControlState();
                }
            }
        }

        /// <summary>
        /// Moves the selected category down
        /// </summary>
        private void btnCategoryMoveDown_Click(object sender, EventArgs e)
        {
            if (dgvCategories.CurrentCell == null)
            {
                return;
            }
            
            if (dgvCategories.CurrentCell.RowIndex < dgvCategories.Rows.Count - 1)
            {
                int index = dgvCategories.CurrentCell.RowIndex;
                int colIndex = dgvCategories.CurrentCell.ColumnIndex;

                bool result = _shapefile.Categories.MoveDown(index);

                if (result)
                {
                    UpdateGridCategory(index);
                    UpdateGridCategory(index +1);
                }

                _noEvents = true;
                dgvCategories.CurrentCell = dgvCategories[colIndex, index + 1];
                _noEvents = false;

                RefreshControlState();
            }
        }

        /// <summary>
        /// Clears all the categories
        /// </summary>
        private void btnCategoriesClear_Click(object sender, EventArgs e)
        {
            if (MessageService.Current.Ask("Do you want to remove all the categories?"))
            {
                _shapefile.Categories.Clear();
                RefreshCategoriesList();
                RefreshControlState();
            }
        }

        /// <summary>
        /// Edit the current expression
        /// </summary>
        private void btnEditExpression_Click(object sender, EventArgs e)
        {
            if (dgvCategories.CurrentCell != null)
            {
                int index = dgvCategories.CurrentCell.RowIndex;
                var category = _shapefile.Categories[index];

                string expression = category.Expression;
                if (FormHelper.ShowQueryBuilder(_context, _layer, this, ref expression, false))
                {
                    category.Expression = expression;
                    txtExpression.Text = category.Expression;
                    RefreshCategoriesCount();
                }
            }
        }

        /// <summary>
        /// Changes the style of the selected category
        /// </summary>
        private void btnCategoryStyle_Click(object sender, EventArgs e)
        {
            if (dgvCategories.CurrentCell != null)
            {
                int row = dgvCategories.CurrentCell.RowIndex;
                ChangeCategoryStyle(row);
            }
        }

        /// <summary>
        /// Changes the style of the specified category
        /// </summary>
        private void ChangeCategoryStyle(int row)
        {
            var cat = _shapefile.Categories[row];
            if (cat == null)
            {
                return;
            }

            using (var form = _context.GetSymbologyForm(_layerHandle, cat.Style, true))
            {
                form.Text = "Category drawing options";

                if (_context.View.ShowChildView(form, this))
                {
                    RefreshControlState();
                    dgvCategories.Invalidate();
                    btnApply.Enabled = true;
                }
            }
        }
        #endregion

        #region Filling categories grid
        
        /// <summary>
        /// Updats the representation of category in the grid, by rereading the values
        /// </summary>
        private void UpdateGridCategory(int index)
        {
            if (index >= _shapefile.Categories.Count || index < 0)
            {
                return;
            }

            dgvCategories[CMN_STYLE, index].Value = new Bitmap(30, 14);
            var cat = _shapefile.Categories[index];
            dgvCategories[CMN_VISIBLE, index].Value = cat.Style.Visible;
            dgvCategories[CMN_NAME, index].Value = cat.Name;
            
            if (!_noEvents)
            {
                btnApply.Enabled = true;
            }
        }
        
        /// <summary>
        /// Fills the data grid view with information about label categories
        /// </summary>
        private void RefreshCategoriesList()
        {
            if (!_noEvents)
            {
                btnApply.Enabled = true;
            }

            bool noEvents = _noEvents; // preserving init state

            _noEvents = true;
            dgvCategories.SuspendLayout();
            dgvCategories.Rows.Clear();

            int numCategories = _shapefile.Categories.Count;

            dgvCategories.ColumnHeadersVisible = numCategories > 0;
            if (numCategories == 0)
            {
                _noEvents = noEvents;
                dgvCategories.ResumeLayout();
                return;
            }

            var maxSize = new Size(0, 0);
            for (int i = 0; i < numCategories; i++)
            {
                dgvCategories.Rows.Add();
                dgvCategories.Rows[i].Visible = false;
                UpdateGridCategory(i);
            }

            for (int i = 0; i < numCategories; i++)
            {
                dgvCategories.Rows[i].Visible = true;
            }

            RefreshCategoriesCount();

            _noEvents = noEvents;

            dgvCategories.ResumeLayout();
        }
        #endregion

        #region Categories count
        
        /// <summary>
        /// Calculates the number of shapes in each category
        /// </summary>
        private void RefreshCategoriesCount()
        {
            _shapefile.Categories.ApplyExpressions();
            
            var values = _shapefile.GetCategoryCounts(); // id of category, count

            int count = _shapefile.Categories.Count;

            for (int i = 0; i < count; i++)
            {
                dgvCategories[CMN_COUNT, i].Value = values.ContainsKey(i) ? values[i] : 0;
            }
        }
        #endregion

        #region Data grid view events
        /// <summary>
        /// Opening forms for editing the category
        /// </summary>
        private void dgvLabelCategories_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            if (e.ColumnIndex == CMN_STYLE )
            {
                ChangeCategoryStyle(e.RowIndex);
            }
        }

        /// <summary>
        /// Drawing of images in the style column
        /// </summary>
        private void dgvCategories_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex != CMN_STYLE)
            {
                return;
            }

            if (e.RowIndex >= 0 && e.RowIndex < _shapefile.Categories.Count)
            {
                var img = e.Value as Image;
                if (img == null) return;

                var cat = _shapefile.Categories[e.RowIndex];
                if (cat == null)
                {
                    return;
                }
                IGeometryStyle sdo = cat.Style;

                Graphics g = Graphics.FromImage(img);
                g.Clear(Color.White);
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = SmoothingMode.HighQuality;

                if (_shapefile.GeometryType == GeometryType.Polygon)
                {
                    sdo.DrawRectangle(g, 0.0f, 0.0f, img.Width - 1, img.Height - 1, true, img.Width, img.Height,  dgvCategories.BackgroundColor);
                }
                else if (_shapefile.GeometryType == GeometryType.Polyline)
                {
                    sdo.DrawLine(g, 0.0f, 0.0f, img.Width - 1, img.Height - 1, true, img.Width, img.Height,  dgvCategories.BackgroundColor);
                }
                else if (_shapefile.PointOrMultiPoint)
                {
                    sdo.DrawPoint(g, 0.0f, 0.0f, img.Width, img.Height,  dgvCategories.BackgroundColor);
                }
                g.Dispose();
            }
        }

        /// <summary>
        /// Drawing the focus rectangle
        /// </summary>
        private void dgvLabelCategories_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (dgvCategories.CurrentCell == null)
            {
                return;
            }

            if (e.ColumnIndex == dgvCategories.CurrentCell.ColumnIndex && e.RowIndex == dgvCategories.CurrentCell.RowIndex)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                using (Pen p = new Pen(Color.Black, 4))
                {
                    Rectangle rect = e.CellBounds;
                    rect.Width -= 1;
                    rect.Height -= 1;
                    ControlPaint.DrawFocusRectangle(e.Graphics, rect);
                }
                e.Handled = true;
            }
        }
        #endregion

        #region Categories interaction

        /// <summary>
        /// Bans the editing of the certain columns
        /// </summary>
        private void dgvCategories_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == CMN_COUNT)
            {
                e.Cancel = true;
            }
        }

        /// <summary>
        /// Saves editing of the category names
        /// </summary>
        private void dgvCategories_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            
            if (e.ColumnIndex == CMN_NAME)
            {
                _shapefile.Categories[e.RowIndex].Name = dgvCategories[CMN_NAME, e.RowIndex].Value.ToString();
            }
        }

        /// <summary>
        /// Toggles visibility of the categories
        /// </summary>
        private void dgvCategories_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (_noEvents || e.RowIndex == -1 || e.ColumnIndex == -1)
            {
                return;
            }
            
            int index = e.RowIndex;
            if (e.ColumnIndex == CMN_VISIBLE)
            {
                bool visible = (bool)dgvCategories[e.ColumnIndex, e.RowIndex].Value;
                _shapefile.Categories[index].Style.Visible = visible;
            }
            btnApply.Enabled = true;
        }

        /// <summary>
        /// Committing changes of the checkbox state immediately, CellValueChanged event won't be triggered otherwise
        /// </summary>
        private void dgvCategories_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvCategories.CurrentCell.ColumnIndex == CMN_VISIBLE)
            {
                if (dgvCategories.IsCurrentCellDirty)
                {
                    dgvCategories.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
            }
        }

        /// <summary>
        /// Saves user input to the drawing options
        /// </summary>
        private void Ui2Categories(object sender, EventArgs e)
        {
            if (_noEvents)
            {
                return;
            }

            var dgv = dgvCategories;

            if (dgv == null || dgv.CurrentCell == null)
            {
                return;
            }

            int index = dgv.CurrentCell.RowIndex;
            
            var category = _shapefile.Categories[index];
            if (category != null)
            {
                            
                if (_shapefile.PointOrMultiPoint)
                {
                    category.Style.Fill.Color =  clpPointFill.Color;
                    category.Style.Marker.Size = (float)udPointSize.Value;
                }
                else if (_shapefile.GeometryType == GeometryType.Polyline)
                {
                    category.Style.Line.Color =  clpLine.Color;
                    category.Style.Line.Width = icbLineWidth.SelectedIndex;
                }
                else if (_shapefile.GeometryType == GeometryType.Polygon)
                {
                    category.Style.Fill.Color =  clpPolygonFill.Color;
                    icbFillStyle.Color1 = clpPolygonFill.Color;
                    if (icbFillStyle.SelectedIndex == 0 && category.Style.Fill.Type == FillType.Hatch)
                    {
                        category.Style.Fill.Type = FillType.Solid;
                    }
                    else
                    {
                        category.Style.Fill.Type = FillType.Hatch;
                        category.Style.Fill.HatchStyle = (HatchStyle)icbFillStyle.SelectedIndex - 1;
                    }
                }
            }
            
            UpdateGridCategory(index);
            btnApply.Enabled = true;
        }
        #endregion

        #region Category properties
        /// <summary>
        /// Displays the values for the selected category
        /// </summary>
        private void dgvCategories_CurrentCellChanged(object sender, EventArgs e)
        {
            RefreshControlState();
        }

        /// <summary>
        /// Sets the enabled state of the control accorging to the state categories
        /// </summary>
        private void RefreshControlState()
        {
            if (_noEvents)
            {
                return;
            }

            DataGridView dgv = dgvCategories;
            if (dgv != null)
            {
                bool exists = (dgv.CurrentCell != null);

                icbFillStyle.Enabled = exists;
                clpPolygonFill.Enabled = exists;
                icbLineWidth.Enabled = exists;
                udPointSize.Enabled = exists;
                clpLine.Enabled = exists;
                clpPointFill.Enabled = exists;
                txtExpression.Visible = exists;
                groupExpression.Enabled = exists;
                groupFill.Enabled = exists;
                groupLine.Enabled = exists;
                groupPoint.Enabled = exists;

                btnCategoryRemove.Enabled = exists;
                btnCategoryMoveUp.Enabled = exists;
                btnCategoryMoveDown.Enabled = exists;
                btnCategoryStyle.Enabled = exists;
                btnEditExpression.Enabled = exists;
                   
                //txtExpression.ReadOnly = exists;

                if (dgv.CurrentCell != null)
                {
                    int index = dgv.CurrentCell.RowIndex;
                    UpdateCategoryOptions(index);
                    btnCategoryMoveUp.Enabled = index > 0;
                    btnCategoryMoveDown.Enabled = index < _shapefile.Categories.Count - 1;
                }
                else
                {
                    clpLine.Color = Color.White;
                    clpPointFill.Color = Color.White;
                    clpPolygonFill.Color = Color.White;
                    txtExpression.Text = "";
                }
            }
        }

        /// <summary>
        /// Updates the state of the category appearance controls
        /// </summary>
        void UpdateCategoryOptions(int index)
        {
            var category = _shapefile.Categories[index];
            if (category == null)
            {
                return;
            }

            _noEvents = true;
                
            txtExpression.Text = category.Expression;
               
            if (_shapefile.PointOrMultiPoint)
            {
                clpPointFill.Color =  category.Style.Fill.Color;
                //udMarker.Size.SetValue(category.Style.Marker.Size);
            }
            else if (_shapefile.GeometryType == GeometryType.Polyline)
            {
                clpLine.Color =  category.Style.Line.Color;
                icbLineWidth.SelectedIndex = (int)category.Style.Line.Width;
            }
            else if (_shapefile.GeometryType == GeometryType.Polygon)
            {
                clpPolygonFill.Color =  category.Style.Fill.Color;
                icbFillStyle.Color1 = clpPolygonFill.Color;

                bool canChangeColor = category.Style.Fill.Type != FillType.Picture;
                icbFillStyle.Enabled = canChangeColor;
                clpPolygonFill.Enabled = canChangeColor;

                if (category.Style.Fill.Type != FillType.Hatch)
                {
                    icbFillStyle.SelectedIndex = 0;
                }
                else
                {
                    icbFillStyle.SelectedIndex = (int)category.Style.Fill.HatchStyle + 1;
                }
                icbFillStyle.Invalidate();
            }
            _noEvents = false;
        }

        #endregion

        #region Buttons
        
        /// <summary>
        /// Applies the options, saves the settings
        /// </summary>
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (_shapefile.Categories.Serialize() != _initState)
            {
                _context.Project.SetModified();
            }
        }

        /// <summary>
        /// Reverts  changes and closes the form
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            // cancel will be run in form_closing handler
        }

        /// <summary>
        /// Saves changes and updates map without closing the form
        /// </summary>
        private void btnApply_Click(object sender, EventArgs e)
        {
            _shapefile.Categories.ApplyExpressions();
            RefreshCategoriesCount();
            _context.Legend.Redraw(LegendRedraw.LegendAndMap);
            _context.Project.SetModified();
            _initState = _shapefile.Categories.Serialize();
            btnApply.Enabled = false;
        }

        /// <summary>
        /// Shows apply button after editing expression
        /// </summary>
        private void txtExpression_TextChanged(object sender, EventArgs e)
        {
            if (!_noEvents)
            {
                btnApply.Enabled = true;
            }
        }

        /// <summary>
        /// Applying the expression entered
        /// </summary>
        private void txtExpression_Validated(object sender, EventArgs e)
        {
            if (dgvCategories.CurrentCell != null)
            {
                int index = dgvCategories.CurrentCell.RowIndex;
                   
                var category = _shapefile.Categories[index];
                if (category != null)
                {
                    category.Expression = txtExpression.Text;
                }
            }
        }

        /// <summary>
        /// Cancels edits if needed
        /// </summary>
        private void frmCategories_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.Cancel)
            {
                CancelEdits();
            }
        }

        /// <summary>
        /// Cancels changes made by user
        /// </summary>
        private void CancelEdits()
        {
            // redraw will occur only when state has changed
            // there is an assumption here that additional serialization will work faster than aditional redraw
            string state = _shapefile.Categories.Serialize();
            if (_initState != state)
            {
                _shapefile.Categories.Deserialize(_initState);
            }
        }

        /// <summary>
        /// Copies categories from labels
        /// </summary>
        private void btnCopy_Click(object sender, EventArgs e)
        {
            //if (dgvCategories.Rows.Count  > 0)
            //{
            //    if (!MessageService.Current.Ask("Do you want to copy categories definitions from labels?"))
            //    {
            //        return;
            //    }
            //}
            
            // clear categories
            //var categories = _shapefile.Categories;
            //var labels = _shapefile.Labels;
            //categories.Clear();

            //for (int i = 0; i < labels.NumCategories; i++)
            //{
            //    MapWinGIS.LabelCategory labelCat = labels.get_Category(i);
            //    if (labelCat != null)
            //    {
            //        MapWinGIS.ShapefileCategory cat = categories.Add(labelCat.Name);
            //        cat.Expression = labelCat.Expression;
            //    }
            //}
            
            //RefreshCategoriesList();
            //RefreshControlState();
            //btnApply.Enabled = true;
        }

        /// <summary>
        ///  Shows context menu with additional options
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMore_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Show(Cursor.Position);
        }

        #endregion

        #region Context menu
        
        /// <summary>
        /// Handles clicks of context menu
        /// </summary>
        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            contextMenuStrip1.Visible = false;
            Application.DoEvents();

            switch(e.ClickedItem.Name)
            {
                case "btnSaveCategories":
                    SaveToXml();
                    break;
                case "btnLoadCategories":
                    LoadFromXml();
                    break;
                case "btnClear":
                    btnCategoriesClear_Click(null, null);
                    break;
                case "btnCopy":
                    MessageService.Current.Info("Not implemented");
                    break;
                case "btnAddRange":
                    btnAddCategory_Click(null, null);
                    break;
            }
        }

        /// <summary>
        /// Before opening context menu
        /// </summary>
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            btnCopyFrom.Text = "Create categories for labels";
            btnCopyFrom.Enabled = false;
            btnSaveCategories.Enabled = _shapefile.Categories.Count > 0;
            btnClear.Enabled = _shapefile.Categories.Count > 0;
            btnSaveCategories.Visible = true;
            btnLoadCategories.Visible = true;
        }

        #endregion

        #region Serialization
        
        /// <summary>
        /// Saves list of styles to XML
        /// </summary>
        public void SaveToXml()
        {
            using (var dlg = new SaveFileDialog {Filter = CATEGORIES_FILE_FILTER})
            {
                if (_shapefile.SourceType == FeatureSourceType.DiskBased)
                {
                    dlg.InitialDirectory = Path.GetDirectoryName(_shapefile.Filename);
                }

                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    try
                    {
                        _shapefile.Categories.SaveToFile(dlg.FileName);
                    }
                    catch (Exception ex)
                    {
                        MessageService.Current.Warn("Failed to save categories: " + ex.Message);
                    }
                }
            }
        }

        /// <summary>
        /// Loads all the icons form the current path
        /// </summary>
        public void LoadFromXml()
        {
            var dlg = new OpenFileDialog {Filter = CATEGORIES_FILE_FILTER};

            if (_shapefile.SourceType == FeatureSourceType.DiskBased)
            {
                dlg.InitialDirectory = Path.GetDirectoryName(_shapefile.Filename);
            }

            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                try
                {
                    _shapefile.Categories.LoadFromFile(dlg.FileName);
                    RefreshCategoriesList();
                    RefreshControlState();
                }
                catch(Exception ex)
                {
                    MessageService.Current.Warn("Failed to load categories: " + ex.Message);
                }
            }
            dlg.Dispose();
        }

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            MessageService.Current.Info("Not implemented");
        }
    }
}


