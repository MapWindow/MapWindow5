using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Api.Enums;
using MW5.Api.Interfaces;
using MW5.Shared;

namespace MW5.Plugins.Symbology.Controls
{
    public partial class CategoriesGrid : DataGridViewBase
    {
        private const int CmnCategoryId = 0;
        private const int CmnVisible = 1;
        private const int CmnStyle = 2;
        private const int CmnName = 3;
        private const int CmnExpression = 4;
        private const int CmnCount = 5;

        private IFeatureSet _shapefile;

        public event EventHandler<CategoryGridEventArgs> StyleClicked;
        public event EventHandler<CategoryGridEventArgs> CategoryNameChanged;

        public CategoriesGrid()
        {
            InitializeComponent();

            CellDoubleClick += dgvCategories_CellDoubleClick;
            CellFormatting += dgvCategories_CellFormatting;
            CellValueChanged += dgvCategories_CellValueChanged;
            CurrentCellDirtyStateChanged += dgvCategories_CurrentCellDirtyStateChanged;
            CellBeginEdit += dgvCategories_CellBeginEdit;
            CellEndEdit += dgvCategories_CellEndEdit;
        }

        public void Initialize(IFeatureSet shapefile)
        {
            _shapefile = shapefile;
        }

        public bool LockUpdate { get; set; }

        public int CurrentCategoryIndex
        {
            get { return CurrentCell != null ? CurrentCell.RowIndex : -1; }
        }

        /// <summary>
        /// Opening forms for editing the category
        /// </summary>
        private void dgvCategories_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == CmnStyle)
            {
                FireEvent(StyleClicked);
            }
        }

        /// <summary>
        /// Drawing of images in the style column
        /// </summary>
        private void dgvCategories_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex != CmnStyle) return;

            if (e.RowIndex >= 0 && e.RowIndex < _shapefile.Categories.Count)
            {
                var img = e.Value as Image;
                if (img == null) return;

                var cat = _shapefile.Categories[e.RowIndex];
                if (cat == null) return;
                IGeometryStyle sdo = cat.Style;

                Graphics g = Graphics.FromImage(img);
                g.Clear(Color.White);
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = SmoothingMode.HighQuality;

                if (_shapefile.GeometryType == GeometryType.Polygon)
                {
                    sdo.DrawRectangle(g, 0, 0, img.Width - 1, img.Height - 1, true, img.Width, img.Height, BackgroundColor);
                }
                else if (_shapefile.GeometryType == GeometryType.Polyline)
                {
                    sdo.DrawLine(g, 0, 0, img.Width - 1, img.Height - 1, true, img.Width, img.Height, BackgroundColor);
                }
                else if (_shapefile.GeometryType == GeometryType.Point)
                {
                    sdo.DrawPoint(g, 0.0f, 0.0f, img.Width, img.Height, BackgroundColor);
                }

                g.Dispose();
            }
        }

        /// <summary>
        /// Toggles visibility of the categories
        /// </summary>
        private void dgvCategories_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == -1 || LockUpdate)
            {
                return;
            }

            if (e.ColumnIndex == CmnVisible)
            {
                int index = (int)this[CmnCategoryId, e.RowIndex].Value;
                _shapefile.Categories[index].Style.Visible = (bool)this[e.ColumnIndex, e.RowIndex].Value;
            }
        }

        /// <summary>
        /// Committing changes of the checkbox state immediately, CellValueChanged event won't be triggered otherwise
        /// </summary>
        private void dgvCategories_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (CurrentCell.ColumnIndex == CmnVisible)
            {
                if (IsCurrentCellDirty)
                {
                    CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
            }
        }

        /// <summary>
        /// Bans editing of the count column
        /// </summary>
        private void dgvCategories_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == CmnCount)
                e.Cancel = true;
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

            if (e.ColumnIndex == CmnName)
            {
                _shapefile.Categories[e.RowIndex].Name = this[CmnName, e.RowIndex].Value.ToString();
                FireEvent(CategoryNameChanged);
            }
        }

        /// <summary>
        /// Fills the data grid view with information about label categories
        /// </summary>
        public void RefreshList()
        {
            SuspendLayout();
            Rows.Clear();

            int numCategories = _shapefile.Categories.Count;
            if (numCategories == 0)
            {
                ColumnHeadersVisible = false;
                ResumeLayout();
                return;
            }

            ColumnHeadersVisible = true;
            Rows.Add(numCategories);

            bool noEventsState = LockUpdate;
            LockUpdate = true;

            FillCategories();

            ResumeLayout();

            AutoSizeColumns();

            LockUpdate = noEventsState;
        }

        private void FillCategories()
        {
            int numCategories = _shapefile.Categories.Count;

            var values = CalculateCount();

            for (int i = 0; i < numCategories; i++)
            {
                var cat = _shapefile.Categories[i];
                this[CmnCategoryId, i].Value = i;
                this[CmnVisible, i].Value = cat.Style.Visible;
                this[CmnStyle, i].Value = new Bitmap(Columns[CmnStyle].Width - 20, Rows[i].Height - 8);
                this[CmnName, i].Value = cat.Name;
                this[CmnExpression, i].Value = cat.Expression;
                this[CmnCount, i].Value = values.ContainsKey(i) ? values[i] : 0;
            }
        }

        private Dictionary<int, int> CalculateCount()
        {
            // calculating the number of shapes per category
            var values = new Dictionary<int, int>();  // id of category, count

            foreach (var ft in _shapefile.Features)
            {
                var category = ft.CategoryIndex;
                if (values.ContainsKey(category))
                {
                    values[category] += 1;
                }
                else
                {
                    values.Add(category, 1);
                }
            }

            return values;
        }

        private void AutoSizeColumns()
        {
            for (int i = 1; i < Columns.Count; i++)
            {
                if (i != CmnStyle && i != CmnCount)
                {
                    AutoResizeColumn(i, DataGridViewAutoSizeColumnMode.AllCells);
                    Columns[i].Width += 10;
                }
            }
        }

        public bool RemoveSelectedCategory()
        {
            if (CurrentRow == null) return false;

            try
            {
                int cmn = CurrentCell.ColumnIndex;
                int index = CurrentRow.Index;

                int realIndex = (int)this[CmnCategoryId, CurrentRow.Index].Value;
                _shapefile.Categories.RemoveAt(realIndex);
                RefreshList();

                if (index >= 0 && index < Rows.Count)
                {
                    CurrentCell = this[cmn, index];
                }
                else if (Rows.Count > 0)
                {
                    CurrentCell = this[cmn, Rows.Count];
                }

                // updating the map
                _shapefile.Categories.ApplyExpressions();

                return true;
            }
            catch (Exception ex)
            {
                Logger.Current.Warn("Failed to remove category", ex);
            }

            return false;
        }

        private void FireEvent(EventHandler<CategoryGridEventArgs> handler)
        {
            if (handler != null)
            {
                handler(this, new CategoryGridEventArgs(this, CurrentCategoryIndex));
            }
        }
    }
}
