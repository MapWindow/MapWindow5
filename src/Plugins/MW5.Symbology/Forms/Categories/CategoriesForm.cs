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
using MW5.Api;
using MW5.Api.Concrete;
using MW5.Api.Interfaces;
using MW5.Api.Legend.Abstract;
using MW5.Plugins.Symbology.Controls;
using MW5.Plugins.Symbology.Forms.Utilities;
using MW5.Plugins.Symbology.Helpers;
using InterpolationMode = System.Drawing.Drawing2D.InterpolationMode;

namespace MW5.Plugins.Symbology.Forms.Categories
{
    public partial class CategoriesForm : Form
    {
        #region Member variables
        // shapefile
        IFeatureSet m_shapefile;

        // refernce to the plug-in        
        IMuteLegend m_legend;

        // the layer handle 
        int m_layerHandle;

        // supress control events on the loading
        bool m_noEvents = false;

        // the active tab
        static int _tabIndex = 0;

        // serialized state of the categories
        private string m_initState = "";

        /// <summary>
        /// The columns of the dgvLabelCategories control
        /// </summary>
        private const int CMN_VISIBLE = 0;
        private const int CMN_STYLE = 1;
        private const int CMN_NAME = 2;
        private const int CMN_COUNT = 3;
        private const int CMN_WIDTH = 4;
        #endregion

        #region Initialization

        /// <summary>
        /// Creates a new instance of the CategoriesForm class
        /// </summary>
        public CategoriesForm(IMuteLegend legend, IFeatureSet sf, int layerHandle)
        {
            Init(legend, sf, layerHandle);
        }

        public CategoriesForm(IMuteLegend legend, int layerHandle)
        {
            var layer = legend.Layers.ItemByHandle(layerHandle);
            if (layer != null)
            {
                var sf = layer.FeatureSet;
                if (sf != null)
                {
                    Init(legend, sf, layerHandle);
                }
            }
        }

        private void Init(IMuteLegend legend, IFeatureSet sf, int layerHandle)
        {
            InitializeComponent();
            m_shapefile = sf;
            m_legend = legend;
            m_layerHandle = layerHandle;

            m_initState = m_shapefile.Categories.Serialize();

            m_noEvents = true;
            //m_plugin.LayerColors.SetDefaultColorScheme(m_shapefile);

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

            if (sf.GeometryType == GeometryType.Point)
            {
                groupPoint.Visible = true;
            }
            else if (sf.GeometryType == GeometryType.Polyline)
            {
                groupLine.Visible = true;
            }
            else if (sf.GeometryType == GeometryType.Polygon)
            {
                groupFill.Visible = true;
            }

            clpLine.SelectedColorChanged += new EventHandler(GUI2Categories);
            clpPointFill.SelectedColorChanged += new EventHandler(GUI2Categories);
            clpPolygonFill.SelectedColorChanged += new EventHandler(GUI2Categories);

            icbFillStyle.SelectedIndexChanged += new EventHandler(GUI2Categories);
            icbLineWidth.SelectedIndexChanged += new EventHandler(GUI2Categories);
            udPointSize.ValueChanged += new EventHandler(GUI2Categories);

            udFontSize.ValueChanged += new EventHandler(GUI2Categories);
            clpFrame.SelectedColorChanged += new EventHandler(GUI2Categories);
            clpFont.SelectedColorChanged += new EventHandler(GUI2Categories);
            chkFrameVisible.CheckedChanged += new EventHandler(GUI2Categories);

            var layer = m_legend.Layers.ItemByHandle(m_layerHandle);

            // updates the list
            this.RefreshCategoriesList(dgvCategories);
            tabControl1.SelectedTab = tabControl1.TabPages[1];
            this.RefreshCategoriesList(dgvLabels);
            m_noEvents = false;

            RefreshControlState(true);
            RefreshControlState(false);

            if (m_shapefile.Labels.Empty)
            {
                tabControl1.TabPages.Remove(tabControl1.TabPages[1]);
            }

            tabControl1.SelectedIndex = _tabIndex;
        }
        #endregion
                
        #region Buttons
        /// <summary>
        /// Applies the options, saves the settings
        /// </summary>
        private void btnOk_Click(object sender, EventArgs e)
        {
            var layer = m_legend.Layers.ItemByHandle(m_layerHandle);
            if (m_shapefile.Categories.Serialize() != m_initState)
            {
                //m_mapWin.Project.Modified = true;
            }
            _tabIndex = tabControl1.SelectedIndex;

            // saves options for default loading behavior
            Globals.SaveLayerOptions(m_layerHandle);
        }
        #endregion

        #region CATEGORIES

        #region Categories buttons
        /// <summary>
        /// Generation of categories with the full set of options
        /// </summary>
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            Form form = null;
            if (tabControl1.SelectedIndex == 0)
            {
                form = new GenerateCategoriesForm(m_shapefile, m_layerHandle);
            }
            else
            {
                form = new GenerateLabelCategoriesForm(m_legend, m_shapefile, m_layerHandle);
            }
            DataGridView dgv = tabControl1.SelectedIndex == 0 ? dgvCategories : dgvLabels;
            
            if (form.ShowDialog() == DialogResult.OK)
            {
                
                this.Enabled = false;
                this.Cursor = Cursors.WaitCursor;
                try
                {
                    RefreshCategoriesList(dgv);
                }
                finally
                {
                    this.Enabled = true;
                    this.Cursor = Cursors.Default;
                }

                if (dgv.RowCount > 0)
                {
                    dgv.CurrentCell = dgv[1, 0];
                }
            }
            form.Dispose();
        }

        /// <summary>
        /// Adds a single category
        /// </summary>
        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            bool labels = tabControl1.SelectedIndex == 1;
            AddCategoriesForm form = new AddCategoriesForm(labels);
            if (form.ShowDialog() == DialogResult.OK)
            {
                ColorBlend blend =  form.icbColors.ColorSchemes.List[form.icbColors.SelectedIndex];
                ColorRamp scheme = ColorSchemeProvider.ColorBlend2ColorScheme(blend);
                int count = (int)form.numericUpDownExt1.Value;

                for (int i = 0; i < count; i++)
                {
                    Color color;
                    if (form.chkRandom.Checked)
                    {
                        color = scheme.GetRandomColor((double)(i + 1) / (double)count);
                    }
                    else
                    {
                        color = scheme.GetGraduatedColor((double)(i + 1) / (double)count);
                    }
                    
                    if (tabControl1.SelectedIndex == 0)
                    {
                        IFeatureCategory cat = null; //m_shapefile.Categories.Add("Category " + m_shapefile.Categories.Count);
                        if (m_shapefile.PointOrMultiPoint || m_shapefile.GeometryType == GeometryType.Polygon)
                        {
                            cat.Style.Fill.Color = color;
                        }
                        else if (m_shapefile.GeometryType == GeometryType.Polyline)
                        {
                            cat.Style.Line.Color = color;
                        }
                    }
                }
                
                form.Dispose();

                DataGridView dgv = tabControl1.SelectedIndex == 0 ? dgvCategories : dgvLabels;
                int rowIndex = - 1;
                if (dgv.CurrentCell != null)
                {
                    rowIndex = dgv.CurrentCell.RowIndex;
                }
                else
                {
                    rowIndex = 0;
                }

                RefreshCategoriesList(dgv);

                if (dgv.RowCount > 0)
                {
                    dgv.CurrentCell = dgv[rowIndex, 0];
                }
            }
        }

        /// <summary>
        /// Removes the selected category
        /// </summary>
        private void btnCategoriesRemove_Click(object sender, EventArgs e)
        {
            DataGridView dgv = tabControl1.SelectedIndex == 0 ? dgvCategories : dgvLabels;

            if (dgv.CurrentCell != null)
            {
                int index = dgv.CurrentCell.RowIndex;
                int cmnIndex = dgv.CurrentCell.ColumnIndex;
                if (tabControl1.SelectedIndex == 0)
                {
                    m_shapefile.Categories.RemoveAt(index);
                }
                else
                {
                    //m_shapefile.Labels.RemoveCategory(index);
                }

                RefreshCategoriesList(dgv);

                if (dgv.Rows.Count != 0)
                {
                    if (index > dgv.Rows.Count - 1) 
                    {
                        index--;
                    }
                    dgv.CurrentCell = dgv[cmnIndex, index];
                }

                RefreshControlState();
            }
        }

        /// <summary>
        /// Moves the selected category up
        /// </summary>
        private void btnCategoryMoveUp_Click(object sender, EventArgs e)
        {
            DataGridView dgv = tabControl1.SelectedIndex == 0 ? dgvCategories : dgvLabels;

            if (dgv.CurrentCell != null)
            {
                if (dgv.CurrentCell.RowIndex > 0)
                {
                    int index = dgv.CurrentCell.RowIndex;
                    int colIndex = dgv.CurrentCell.ColumnIndex;

                    bool result = false;

                    if (tabControl1.SelectedIndex == 0)
                    {
                        result = m_shapefile.Categories.MoveUp(index);
                    }
                    else
                    {
                        //result = m_shapefile.Labels.MoveCategoryUp(index);
                    }

                    if (result)
                    {
                        UpdateGridCategory(index);
                        UpdateGridCategory(index - 1);
                        m_noEvents = true;
                        dgv.CurrentCell = dgv[colIndex, index - 1];
                        m_noEvents = false;
                        
                        RefreshControlState();
                    }
                }
            }
        }

        /// <summary>
        /// Moves the selected category down
        /// </summary>
        private void btnCategoryMoveDown_Click(object sender, EventArgs e)
        {
            DataGridView dgv = tabControl1.SelectedIndex == 0 ? dgvCategories : dgvLabels;

            if (dgv.CurrentCell != null)
            {
                if (dgv.CurrentCell.RowIndex < dgv.Rows.Count - 1)
                {
                    int index = dgv.CurrentCell.RowIndex;
                    int colIndex = dgv.CurrentCell.ColumnIndex;

                    bool result = false;
                    if (tabControl1.SelectedIndex == 0)
                    {
                        result = m_shapefile.Categories.MoveDown(index);
                    }
                    else
                    {
                        //result = m_shapefile.Labels.MoveCategoryDown(index);
                    }

                    if (result)
                    {
                        UpdateGridCategory(index);
                        UpdateGridCategory(index +1);
                    }

                    m_noEvents = true;
                    dgv.CurrentCell = dgv[colIndex, index + 1];
                    m_noEvents = false;

                    RefreshControlState();
                }
            }
        }

        /// <summary>
        /// Clears all the categories
        /// </summary>
        private void btnCategoriesClear_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to remove all the categories?",
                            "MapWindow_5", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (tabControl1.SelectedIndex == 0)
                {
                    m_shapefile.Categories.Clear();
                    RefreshCategoriesList(dgvCategories);
                }
                else
                {
                    //m_shapefile.Labels.ClearCategories();
                    RefreshCategoriesList(dgvLabels);
                }
                RefreshControlState();
            }
        }

        /// <summary>
        /// Edit the current expression
        /// </summary>
        private void btnEditExpression_Click(object sender, EventArgs e)
        {
            DataGridView dgv = (tabControl1.SelectedIndex == 0) ? dgvCategories : dgvLabels;
            if (dgv != null)
            {
                if (dgv.CurrentCell != null)
                {
                    int index = dgv.CurrentCell.RowIndex;

                    if (dgv == dgvCategories)
                    {
                        var category = m_shapefile.Categories[index];
                        var form = new frmQueryBuilder(m_shapefile, m_layerHandle, category.Expression, false);
                        if (form.ShowDialog(this) == DialogResult.OK)
                        {
                            category.Expression = form.Tag.ToString();
                            txtExpression.Text = category.Expression;
                            //RefreshCategoriesCount(true);
                        }
                    }
                    else
                    {
                        //LabelCategory category = m_shapefile.Labels.get_Category(index);
                        //frmQueryBuilder form = new frmQueryBuilder(m_shapefile, m_layerHandle, category.Expression, false);
                        //if (form.ShowDialog(this) == DialogResult.OK)
                        //{
                        //    category.Expression = form.Tag.ToString();
                        //    txtLabelExpression.Text = category.Expression;
                        //    //RefreshCategoriesCount(false);
                        //}
                    }
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
            var cat = m_shapefile.Categories[row];
            if (cat == null) return;

            Form form = FormHelper.GetSymbologyForm(m_legend, m_layerHandle, m_shapefile.GeometryType, cat.Style, true);
            form.Text = "Category drawing options";

            if (form.ShowDialog(this) == DialogResult.OK)
            {
                RefreshControlState(tabControl1.SelectedIndex == 0);
                DataGridView dgv = tabControl1.SelectedIndex == 0 ? dgvCategories : dgvLabels;
                dgv.Invalidate();
                btnApply.Enabled = true;
            }
            form.Dispose();
        }
        #endregion

        #region Filling categories grid
        
        /// <summary>
        /// Updats the representation of category in the grid, by rereading the values
        /// </summary>
        void UpdateGridCategory(int index)
        {
            UpdateGridCategory(index, tabControl1.SelectedIndex == 0);
            
        }
        
        /// <summary>
        /// Updats the representation of category in the grid, by rereading the values
        /// </summary>
        void UpdateGridCategory(int index, bool labels)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                //if (index >= m_shapefile.Labels.NumCategories || index < 0)
                //    return;

                //MapWinGIS.LabelCategory cat = m_shapefile.Labels.get_Category(index);
                //LabelStyle style = new LabelStyle(cat);

                //// calculating size
                //Bitmap img = new Bitmap(500, 200);
                //Size size = style.MeasureString(Graphics.FromImage(img), "Style " + m_shapefile.Labels.NumCategories.ToString(), 20);
                //size.Width += 2;
                //if (style.FrameVisible)
                //    size.Width += (int)(size.Height * 0.3);
                //size.Height += 2;
                //img.Dispose();

                //System.Drawing.Bitmap bmp = (dgvLabels[CMN_STYLE, index].Value as System.Drawing.Bitmap);
                //if (bmp != null)
                //{
                //    bmp.Dispose();
                //}
                //dgvLabels[CMN_STYLE, index].Value = new System.Drawing.Bitmap(size.Width, size.Height);

                //dgvLabels[CMN_VISIBLE, index].Value = cat.Visible;
                //dgvLabels[CMN_NAME, index].Value = cat.Name;

                //if (size.Height < 21)
                //{
                //    size.Height = 21;
                //}
                //dgvLabels.Rows[index].Height = size.Height + 2;
                //dgvLabels[CMN_WIDTH, index].Value = size.Width;

                //int maxWidth = 0;
                //for (int i = 0; i < dgvLabels.Rows.Count; i++)
                //{
                //    int val = (int)dgvLabels[CMN_WIDTH, i].Value;
                //    if (val > maxWidth)
                //    {
                //        maxWidth = val;
                //    }
                //}

                //dgvLabels.Columns[1].Width = maxWidth;
                
            }
            else
            {
                if (index >= m_shapefile.Categories.Count || index < 0)
                    return;

                dgvCategories[CMN_STYLE, index].Value = new Bitmap(30, 14);
                var cat = m_shapefile.Categories[index];
                dgvCategories[CMN_VISIBLE, index].Value = cat.Style.Visible;
                dgvCategories[CMN_NAME, index].Value = cat.Name;
            }
            if (!m_noEvents)
                btnApply.Enabled = true;
        }
        
        /// <summary>
        /// Fills the data grid view with information about label categories
        /// </summary>
        private void RefreshCategoriesList(DataGridView dgv)
        {
            if (!m_noEvents)
                btnApply.Enabled = true;

            bool noEvents = m_noEvents; // preserving init state

            m_noEvents = true;
            dgv.SuspendLayout();
            dgv.Rows.Clear();

            bool categories = (dgv == dgvCategories);

            int numCategories = 0;
            //int numCategories = categories ? m_shapefile.Categories.Count : m_shapefile.Labels.NumCategories;
            

            dgv.ColumnHeadersVisible = numCategories > 0;
            if (numCategories == 0)
            {
                m_noEvents = noEvents;
                dgv.ResumeLayout();
                return;
            }

            Size maxSize = new Size(0, 0);
            for (int i = 0; i < numCategories; i++)
            {
                dgv.Rows.Add();
                dgv.Rows[i].Visible = false;
                UpdateGridCategory(i);
            }

            for (int i = 0; i < numCategories; i++)
            {
                dgv.Rows[i].Visible = true;
            }

            RefreshCategoriesCount(dgv == dgvCategories);

            m_noEvents = noEvents;

            // updaing controls
            dgv.ResumeLayout();
        }
        #endregion

        #region Categories count
        /// <summary>
        /// Calculates the number of shapes in each category
        /// </summary>
        private void RefreshCategoriesCount(bool categories)
        {
            if (m_noEvents)
                return;
            
            if (categories)
            {
                m_shapefile.Categories.ApplyExpressions();
            }
            else
            {
                //m_shapefile.Labels.ApplyCategories();
            }
            
            Dictionary<int, int> values = new Dictionary<int, int>();  // id of category, count
            int category;

            int count = 0;
            if (categories)
            {
                foreach(var ft in m_shapefile.Features)
                {
                    category = ft.CategoryIndex;
                    if (values.ContainsKey(category))
                    {
                        values[category] += 1;
                    }
                    else
                    {
                        values.Add(category, 1);
                    }
                }
                count = m_shapefile.Categories.Count;
            }
            else
            {
                //for (int i = 0; i < m_shapefile.Labels.Count; i++)
                //{
                //    category = m_shapefile.Labels.get_Label(i, 0).Category;
                //    if (values.ContainsKey(category))
                //    {
                //        values[category] += 1;
                //    }
                //    else
                //    {
                //        values.Add(category, 1);
                //    }
                //}
                //count = m_shapefile.Labels.NumCategories;
            }

            DataGridView dgv = categories ? dgvCategories : dgvLabels;
            for (int i = 0; i < count; i++)
            {
                if (values.ContainsKey(i))
                {
                    dgv[CMN_COUNT, i].Value = values[i];
                }
                else
                {
                    dgv[CMN_COUNT, i].Value = 0;
                }
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
                return;

            if (e.ColumnIndex == CMN_STYLE )
            {
                if (tabControl1.SelectedIndex == 0)
                {
                    ChangeCategoryStyle(e.RowIndex);
                }
                else
                {
                    ChangeLabelCategoryStyle(e.RowIndex);
                }
            }
        }

        /// <summary>
        /// Drawing of images in the style column
        /// </summary>
        private void dgvCategories_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == CMN_STYLE)
            {
                if (tabControl1.SelectedIndex == 0)
                {
                    if (e.RowIndex >= 0 && e.RowIndex < m_shapefile.Categories.Count)
                    {
                        System.Drawing.Image img = e.Value as System.Drawing.Image;
                        if (img == null) return;

                        var cat = m_shapefile.Categories[e.RowIndex];
                        if (cat == null) return;
                        IGeometryStyle sdo = cat.Style;

                        Graphics g = Graphics.FromImage(img);
                        g.Clear(Color.White);
                        g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        g.SmoothingMode = SmoothingMode.HighQuality;


                        if (m_shapefile.GeometryType == GeometryType.Polygon)
                        {
                            //sdo.DrawRectangle(g.GetHdc(), 0.0f, 0.0f, img.Width - 1, img.Height - 1, true, img.Width, img.Height,  dgvCategories.BackgroundColor));
                        }
                        else if (m_shapefile.GeometryType == GeometryType.Polyline)
                        {
                            //sdo.DrawLine(g.GetHdc(), 0.0f, 0.0f, img.Width - 1, img.Height - 1, true, img.Width, img.Height,  dgvCategories.BackgroundColor));
                        }
                        else if (m_shapefile.GeometryType == GeometryType.Point)
                        {
                            //sdo.DrawPoint(g.GetHdc(), 0.0f, 0.0f, img.Width, img.Height,  dgvCategories.BackgroundColor));
                        }
                        g.ReleaseHdc();
                        g.Dispose();
                    }
                }
                else if (tabControl1.SelectedIndex == 1)
                {
                    //if (e.RowIndex >= 0 && e.RowIndex < m_shapefile.Labels.NumCategories)
                    //{
                    //    System.Drawing.Image img = e.Value as System.Drawing.Image;
                    //    if (img == null) return;
                    //    Graphics g = Graphics.FromImage(img);
                    //    g.Clear(Color.White);
                    //    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    //    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

                    //    LabelCategory cat = m_shapefile.Labels.get_Category(e.RowIndex);
                    //    if (cat != null)
                    //    {
                    //        LabelStyle style = new LabelStyle(cat);
                    //        System.Drawing.Point pnt = new System.Drawing.Point();
                    //        pnt.Y = 0;
                    //        int size = style.FontSize > 20 ? 20 : style.FontSize;
                    //        pnt.X = style.FrameVisible ? (int)(size * 0.4) : 0;
                    //        style.Draw(g, pnt, "Style " + Convert.ToString(e.RowIndex + 1), false, 20);
                    //    }
                    //    g.Dispose();
                    //}
                }
            }
        }

        /// <summary>
        /// Drawing the focus rectangle
        /// </summary>
        private void dgvLabelCategories_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            DataGridView dgv = tabControl1.SelectedIndex == 0 ? dgvCategories : dgvLabels;

            if (dgv.CurrentCell == null) return;
            if (e.ColumnIndex == dgv.CurrentCell.ColumnIndex && e.RowIndex == dgv.CurrentCell.RowIndex)
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
                if (tabControl1.SelectedIndex == 0)
                {
                    m_shapefile.Categories[e.RowIndex].Name = dgvCategories[CMN_NAME, e.RowIndex].Value.ToString();
                }
                else
                {
                    //m_shapefile.Labels.get_Category(e.RowIndex).Name = dgvLabels[CMN_NAME, e.RowIndex].Value.ToString();
                }
            }
        }

        /// <summary>
        /// Toggles visibility of the categories
        /// </summary>
        private void dgvCategories_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (m_noEvents) return;
            if (e.RowIndex == -1 || e.ColumnIndex == -1) return;

            DataGridView dgv = tabControl1.SelectedIndex == 0 ? dgvCategories : dgvLabels;
            if (dgv != null)
            {
                int index = e.RowIndex;
                if (e.ColumnIndex == CMN_VISIBLE)
                {
                    bool visible = (bool)dgv[e.ColumnIndex, e.RowIndex].Value;
                    if (dgv == dgvCategories)
                    {
                        m_shapefile.Categories[index].Style.Visible = visible;
                    }
                    else
                    {
                        ////m_shapefile.Labels.get_Category(index).Visible = visible;
                    }
                }
                btnApply.Enabled = true;
            }
        }

        /// <summary>
        /// Committing changes of the checkbox state immediately, CellValueChanged event won't be triggered otherwise
        /// </summary>
        private void dgvCategories_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            DataGridView dgv = tabControl1.SelectedIndex == 0 ? dgvCategories : dgvLabels;
            if (dgv != null)
            {
                if (dgv.CurrentCell.ColumnIndex == CMN_VISIBLE)
                {
                    if (dgv.IsCurrentCellDirty)
                    {
                        dgv.CommitEdit(DataGridViewDataErrorContexts.Commit);
                    }
                }
            }
        }

        /// <summary>
        /// Saves user input to the drawing options
        /// </summary>
        private void GUI2Categories(object sender, EventArgs e)
        {
            if (m_noEvents)
            {
                return;
            }
            
            DataGridView dgv = (tabControl1.SelectedIndex == 0) ? dgvCategories : dgvLabels;
             
            if (dgv != null)
            {
                if (dgv.CurrentCell != null)
                {
                    int index = dgv.CurrentCell.RowIndex;

                    if (dgv == dgvCategories)
                    {
                        var category = m_shapefile.Categories[index];
                        if (category != null)
                        {
                            
                            if (m_shapefile.PointOrMultiPoint)
                            {
                                category.Style.Fill.Color =  clpPointFill.Color;
                                category.Style.Marker.Size = (float)udPointSize.Value;
                            }
                            else if (m_shapefile.GeometryType == GeometryType.Polyline)
                            {
                                category.Style.Line.Color =  clpLine.Color;
                                category.Style.Line.Width = icbLineWidth.SelectedIndex;
                            }
                            else if (m_shapefile.GeometryType == GeometryType.Polygon)
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
                    }
                    else
                    {
                        //var category = m_shapefile.Labels.get_Category(index);

                        //category.FontColor =  clpFont.Color;
                        //category.FrameBackColor =  clpFrame.Color;
                        //category.FontSize = (int)udFontSize.Value;
                        //category.FrameVisible = chkFrameVisible.Checked;
                    }
                    UpdateGridCategory(index);
                    btnApply.Enabled = true;
                }
            }
        }
        #endregion

        #region Category properties
        /// <summary>
        /// Displays the values for the selected category
        /// </summary>
        private void dgvCategories_CurrentCellChanged(object sender, EventArgs e)
        {
            RefreshControlState(tabControl1.SelectedIndex == 0);
        }
        
        /// <summary>
        /// Sets the enabled state of the control accorging to the state categories
        /// </summary>
        private void RefreshControlState()
        {
            RefreshControlState(tabControl1.SelectedIndex == 0);
        }

        /// <summary>
        /// Sets the enabled state of the control accorging to the state categories
        /// </summary>
        private void RefreshControlState(bool categories)
        {
            if (m_noEvents)
            {
                return;
            }

            DataGridView dgv = categories ? dgvCategories : dgvLabels;
            if (dgv != null)
            {
                if (dgv == dgvCategories)
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
                        btnCategoryMoveDown.Enabled = index < m_shapefile.Categories.Count - 1;
                    }
                    else
                    {
                        clpLine.Color = Color.White;
                        clpPointFill.Color = Color.White;
                        clpPolygonFill.Color = Color.White;
                        txtExpression.Text = "";
                    }
                }
                else
                {
                    bool exists = (dgv.CurrentCell != null);
                    groupLabels.Enabled = exists;
                    txtLabelExpression.Visible = exists;
                    groupLabelExpression.Enabled = exists;

                    btnLabelsRemove.Enabled = exists;
                    btnLabelsMoveUp.Enabled = exists;
                    btnLabelsMoveDown.Enabled = exists;
                    btnLabelOptions.Enabled = exists;
                    btnLabelExpression.Enabled = exists;
                    //txtLabelExpression.ReadOnly = exists;

                    if (dgv.CurrentCell != null)
                    {
                        int index = dgv.CurrentCell.RowIndex;
                        UpdateLabelOptions(index);
                        btnLabelsMoveUp.Enabled = index > 0;
                        //btnLabelsMoveDown.Enabled = index < m_shapefile.Labels.NumCategories - 1;
                    }
                    else
                    {
                        clpFont.Color = Color.White;
                        clpFrame.Color = Color.White;
                        txtLabelExpression.Text = "";
                    }
                }
            }
        }

        /// <summary>
        /// Updates the state of the category appearance controls
        /// </summary>
        /// <param name="index"></param>
        void UpdateCategoryOptions(int index)
        {
            var category = m_shapefile.Categories[index];
            if (category != null)
            {
                m_noEvents = true;
                
                txtExpression.Text = category.Expression;
                
               
                if (m_shapefile.PointOrMultiPoint)
                {
                    clpPointFill.Color =  category.Style.Fill.Color;
                    //udMarker.Size.SetValue(category.Style.Marker.Size);
                }
                else if (m_shapefile.GeometryType == GeometryType.Polyline)
                {
                    clpLine.Color =  category.Style.Line.Color;
                    icbLineWidth.SelectedIndex = (int)category.Style.Line.Width;
                }
                else if (m_shapefile.GeometryType == GeometryType.Polygon)
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
                m_noEvents = false;
            }
        }

        /// <summary>
        ///  Update the state of label appearance controls
        /// </summary>
        void UpdateLabelOptions(int index)
        {
            //var category = m_shapefile.Labels.get_Category(index);
            //if (category != null)
            //{
            //    m_noEvents = true;

            //    txtLabelExpression.Text = category.Expression;
            //    ShpfileType type = Globals.ShapefileType2D(m_shapefile.ShapefileType);
               
            //    clpFont.Color =  category.FontColor;
            //    clpFrame.Color =  category.FrameBackColor;
            //    udFontSize.SetValue(category.FontSize); 
            //    chkFrameVisible.Checked = category.FrameVisible;

            //    m_noEvents = false;
            //}
        }
        #endregion

        #endregion

        #region LABELS
        
        /// <summary>
        /// Clears all categories
        /// </summary>
        private void btnLabelCategoriesClear_Click(object sender, EventArgs e)
        {
            m_shapefile.Categories.Clear();
            RefreshCategoriesList(dgvLabels);
        }

        /// <summary>
        ///  Changes the style of the active category
        /// </summary>
        private void btnLabelCategoriesStyle_Click(object sender, EventArgs e)
        {
            if (dgvLabels.CurrentRow != null)
            {
                ChangeLabelCategoryStyle(dgvLabels.CurrentRow.Index);
            }
        }

        /// <summary>
        /// Changes the style of the selected category
        /// </summary>
        private void ChangeLabelCategoryStyle(int row)
        {
            //LabelCategory cat = (LabelCategory)m_shapefile.Labels.get_Category(row);
            //if (cat == null)
            //{
            //    return;
            //}
 
            //string s = "Style " + (row + 1);
            //LabelStyleForm styleFormForm = new LabelStyleForm(m_shapefile, cat);

            //if (styleFormForm.ShowDialog(this) == DialogResult.OK)
            //{
            //    UpdateGridCategory(row);
            //    dgvLabels.Invalidate();
            //    RefreshControlState();
            //    btnApply.Enabled = true;
            //}
            //styleFormForm.Dispose();
        }
        #endregion


        /// <summary>
        /// Adds a single category to label categories
        /// </summary>
        private void btnLabelsAdd_Click(object sender, EventArgs e)
        {
            //int cmn = 0;
            //if (dgvLabels.CurrentCell != null)
            //{
            //    cmn = dgvLabels.CurrentCell.ColumnIndex;
            //}
            //string name = "Style " + m_shapefile.Labels.NumCategories;
            //m_shapefile.Labels.AddCategory(name);
            //RefreshCategoriesList(dgvLabels);

            //dgvLabels.CurrentCell = dgvLabels[cmn, dgvLabels.Rows.Count - 1];
            //RefreshControlState();
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
            m_shapefile.Categories.ApplyExpressions();
            this.RefreshCategoriesCount(true);
            this.RefreshCategoriesCount(false);
            //m_mapWin.View.ForceFullRedraw();
            //m_mapWin.Project.Modified = true;
            m_initState = m_shapefile.Categories.Serialize();
            btnApply.Enabled = false;
        }

        /// <summary>
        /// Shows apply button after editing expression
        /// </summary>
        private void txtExpression_TextChanged(object sender, EventArgs e)
        {
            if (!m_noEvents)
                btnApply.Enabled = true;
        }

        /// <summary>
        /// Applying the expression entered
        /// </summary>
        private void txtExpression_Validated(object sender, EventArgs e)
        {
            DataGridView dgv = (tabControl1.SelectedIndex == 0) ? dgvCategories : dgvLabels;
            if (dgv != null)
            {
                if (dgv.CurrentCell != null)
                {
                    int index = dgv.CurrentCell.RowIndex;

                    if (dgv == dgvCategories)
                    {
                        var category = m_shapefile.Categories[index];
                        if (category != null)
                            category.Expression = txtExpression.Text;
                    }
                    //else
                    //{
                    //    LabelCategory category = m_shapefile.Labels.get_Category(index);
                    //    if (category != null)
                    //        category.Expression = txtLabelExpression.Text;
                    //}
                }
            }
        }

        /// <summary>
        /// Cancels edits if needed
        /// </summary>
        private void frmCategories_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.Cancel)
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
            string state = m_shapefile.Categories.Serialize();
            if (m_initState != state)
            {
                m_shapefile.Categories.Deserialize(m_initState);
            }
        }

        /// <summary>
        /// Copies categories from labels
        /// </summary>
        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (dgvLabels.Rows.Count == 0)
            {
                Globals.Message.Info("No categories to copy");
                return;
            }

            if (dgvCategories.Rows.Count  > 0)
            {
                if (MessageBox.Show("Do you want to copy categories definitions from labels?", "MapWindow_5",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
            }
            // clear categories
            var categories = m_shapefile.Categories;
            var labels = m_shapefile.Labels;
            categories.Clear();

            //for (int i = 0; i < labels.NumCategories; i++)
            //{
            //    MapWinGIS.LabelCategory labelCat = labels.get_Category(i);
            //    if (labelCat != null)
            //    {
            //        MapWinGIS.ShapefileCategory cat = categories.Add(labelCat.Name);
            //        cat.Expression = labelCat.Expression;
            //    }
            //}
            RefreshCategoriesList(dgvCategories);
            RefreshControlState();
            btnApply.Enabled = true;
        }

        /// <summary>
        /// Copies categories from shapefile
        /// </summary>
        private void btnLabelsCopy_Click(object sender, EventArgs e)
        {
            if (dgvCategories.Rows.Count == 0)
            {
                Globals.Message.Info("No categories to copy");
                return;
            }

            if (dgvLabels.Rows.Count > 0)
            {
                if (MessageBox.Show("Do you want to copy categories definitions from shapefile?", "MapWindow_5",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
            }
            // clear categories
            var categories = m_shapefile.Categories;
            var labels = m_shapefile.Labels;
            //labels.ClearCategories();

            //for (int i = 0; i < categories.Count; i++)
            //{
            //    var cat = categories[i];
            //    if (cat != null)
            //    {
            //        LabelCategory labelCat = labels.AddCategory(cat.Name);
            //        labelCat.Expression = cat.Expression;
            //    }
            //}
            RefreshCategoriesList(dgvLabels);
            RefreshControlState(true);
            RefreshControlState(false);
            btnApply.Enabled = true;
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
                    this.SaveToXML();
                    break;
                case "btnLoadCategories":
                    this.LoadFromXML();
                    break;
                case "btnClear":
                    this.btnCategoriesClear_Click(null, null);
                    break;
                case "btnCopy":
                    if (tabControl1.SelectedIndex == 0)
                        this.btnCopy_Click(null, null);
                    else
                        this.btnLabelsCopy_Click(null, null);
                    break;
                case "btnAddRange":
                    if (tabControl1.SelectedIndex == 0)
                        this.btnAddCategory_Click(null, null);
                    else
                        this.btnLabelsAdd_Click(null, null);
                    break;
            }
        }

        /// <summary>
        /// Before opening context menu
        /// </summary>
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            //btnCopyFrom.Text = tabControl1.SelectedIndex == 0 ? "Copy from labels" : "Copy from shapefile";
            //btnCopyFrom.Enabled = tabControl1.SelectedIndex == 0 ? m_shapefile.Labels.NumCategories > 0 : m_shapefile.Categories.Count > 0;
            //btnSaveCategories.Enabled = tabControl1.SelectedIndex == 0 ? m_shapefile.Categories.Count > 0 : m_shapefile.Labels.NumCategories > 0;
            //btnClear.Enabled = tabControl1.SelectedIndex == 0 ? m_shapefile.Categories.Count > 0 : m_shapefile.Labels.NumCategories > 0;
            //btnSaveCategories.Visible = tabControl1.SelectedIndex == 0;
            //btnLoadCategories.Visible = tabControl1.SelectedIndex == 0;
        }
        #endregion

        #region Serialization
        /// <summary>
        /// Saves list of styles to XML
        /// </summary>
        public void SaveToXML()
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Legend categories (*.mwleg)|*.mwleg";
            if (m_shapefile.SourceType == FeatureSourceType.DiskBased)
            {
                dlg.InitialDirectory = Path.GetDirectoryName(m_shapefile.Filename);
            }
            
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                var layer = m_legend.Layers.ItemByHandle(m_layerHandle);
                if (layer != null)
                {
                    //layer.SaveShapefileCategories(dlg.FileName);
                }
                
                //XmlDocument xmlDoc = new XmlDocument();
                //xmlDoc.LoadXml("<MapWindow version= '" + "'></MapWindow>");     // TODO: add version

                //XmlElement xelRoot = xmlDoc.DocumentElement;
                //XmlAttribute attr = xmlDoc.CreateAttribute("FileType");
                //attr.InnerText = "ShapefileCategories";
                //xelRoot.Attributes.Append(attr);

                //attr = xmlDoc.CreateAttribute("FileVersion");
                //attr.InnerText = "0";
                //xelRoot.Attributes.Append(attr);

                //XmlElement xel = xmlDoc.CreateElement("Categories");
                //string s = m_shapefile.Categories.Serialize();
                //xel.InnerText = s;

                //xelRoot.AppendChild(xel);

                //try
                //{
                //    xmlDoc.Save(dlg.FileName);
                //}
                //catch(System.Xml.XmlException ex)
                //{
                //    Globals.Message.Warn("Failed to save options: " + ex.Message);
                //}
            }
            dlg.Dispose();
        }

        /// <summary>
        /// Loads all the icons form the current path
        /// </summary>
        public void LoadFromXML()
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Legend categories (*.mwleg)|*.mwleg";
            if (m_shapefile.SourceType == FeatureSourceType.DiskBased)
            {
                dlg.InitialDirectory = Path.GetDirectoryName(m_shapefile.Filename);
            }

            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                var layer = m_legend.Layers.ItemByHandle(m_layerHandle);
                if (layer != null)
                {
                    //layer.LoadShapefileCategories(dlg.FileName);
                    this.RefreshCategoriesList(dgvCategories);
                    this.RefreshControlState(true);
                }
            }
            dlg.Dispose();
        }
        #endregion
    }
}


