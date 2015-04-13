// ----------------------------------------------------------------------------
// MapWindow.Controls.Projections: Data grid view with some commonly used options
// Author: Sergei Leschinski
// ----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using MW5.Api.Enums;
using MW5.Shared;

namespace MW5.UI.Legacy
{
    /// <summary>
    /// Data grid view with some commonly used options
    /// </summary>
    [System.ComponentModel.ToolboxItem(true)]
    [ToolboxBitmap(typeof(DataGridView))]
    public class LayerStyleDataGridView : DataGridView
    {
        /// shapedrawing options associated with rows
        private readonly List<GeometryRowStyle> _shapeOptions = new List<GeometryRowStyle>();

        // the index of column to be treated as shapefile drawing one
        private int _shapeDrawingColumn = -1;

        #region Initialization
        /// <summary>
        /// Creates new instance of DataGridViewMW class
        /// </summary>
        public LayerStyleDataGridView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Designer generated code
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            SuspendLayout();
            // 
            // DataGridViewMW
            // 
            AllowUserToAddRows = false;
            AllowUserToDeleteRows = false;
            AllowUserToResizeRows = false;
            BackgroundColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.White;
            dataGridViewCellStyle1.SelectionForeColor = Color.Black;
            RowsDefaultCellStyle = dataGridViewCellStyle1;
            SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            CellFormatting += DataGridViewMW_CellFormatting;
            RowsAdded += DataGridViewMW_RowsAdded;
            CellPainting += DataGridViewMW_CellPainting;
            CurrentCellChanged += DataGridViewMW_CurrentCellChanged;
            RowsRemoved += DataGridViewMW_RowsRemoved;
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            ResumeLayout(false);

        }
        #endregion

        #region Common Behavior
        /// <summary>
        /// Draws the focus rectangle
        /// </summary>
        private void DataGridViewMW_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (CurrentCell == null) return;
            if (e.ColumnIndex == CurrentCell.ColumnIndex && e.RowIndex == CurrentCell.RowIndex)
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

        /// <summary>
        /// Committing changes of the checkbox state immediately, CellValueChanged event won't be triggered otherwise
        /// </summary>
        private void DataGridViewMW_CurrentCellChanged(object sender, EventArgs e)
        {
            if (CurrentCell == null)
            {
                return;
            }

            int index = CurrentCell.ColumnIndex;
            DataGridViewCheckBoxColumn cmn = Columns[index] as DataGridViewCheckBoxColumn;
            if (cmn != null)
            {
                if (IsCurrentCellDirty)
                {
                    CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
            }
        }
        #endregion

        #region Shapefile Drawing
        
        /// <summary>
        /// Returns drawing options associated with specified row
        /// </summary>
        /// <returns>Reference to the instance of ShapeDrawingOptions class or null on failure</returns>
        public GeometryRowStyle get_ShapefileDrawingOptions(int rowIndex)
        {
            if (!CheckSynchronization())
            {
                return null;
            }

            if (rowIndex >= 0 && rowIndex < _shapeOptions.Count)
            {
                return _shapeOptions[rowIndex];
            }
            
            return null;
        }

        /// <summary>
        /// Sets drawing options for particular row in data grid view
        /// </summary>
        /// <param name="rowIndex">Row index to set options for</param>
        /// <param name="options">Set of options</param>
        public bool set_ShapefileDrawingOptions(int rowIndex, GeometryRowStyle options)
        {
            if (!CheckSynchronization())
            {
                return false;
            }

            if (rowIndex >= 0 && rowIndex < _shapeOptions.Count)
            {
                if (options.Style != null)    // to avoid additional checks later
                {
                    _shapeOptions[rowIndex] = options;
                    return true;
                }
            }
            
            return false;
        }

        /// <summary>
        /// Checks synchronization between shapefile darwing options and rows
        /// </summary>
        /// <returns></returns>
        private bool CheckSynchronization()
        {
            bool val = _shapeOptions.Count == Rows.Count;
            if (!val)
            {
                Logger.Current.Warn("Broken syncronization inside custom data grid view");
            }
            return val;
        }

        /// <summary>
        /// Gets or sets th index if column to treat as shapefile drawing column
        /// This column should have DataGridViewImageColumn type set in client code
        /// </summary>
        public int ShapefileDrawingColumn
        {
            get{return _shapeDrawingColumn;}
            set{_shapeDrawingColumn = value;}
        }

        /// <summary>
        /// Updating the size of custom list
        /// </summary>
        private void DataGridViewMW_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            for (int i = 0; i < e.RowCount; i++)
                _shapeOptions.Insert(e.RowIndex, null);
        }

        /// <summary>
        /// Updating the size of custom list
        /// </summary>
        private void DataGridViewMW_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            for (int i = 0; i < e.RowCount; i++)
                _shapeOptions.RemoveAt(e.RowIndex);
        }

        /// <summary>
        /// Draws shapefile preview in shapefile drawing column
        /// </summary>
        private void DataGridViewMW_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex != _shapeDrawingColumn) return;

            if (!CheckSynchronization())
            {
                return;
            }

            var img = e.Value as Image;
            if (img == null)
            {
                return;
            }
            
            GeometryRowStyle val = _shapeOptions[e.RowIndex];
            if (val == null || val.Style == null)
            {
                return;
            }

            using (Graphics g = Graphics.FromImage(img))
            {
                g.Clear(Color.White);
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = SmoothingMode.HighQuality;

                if (val.Type == GeometryType.Polygon)
                {
                    val.Style.DrawRectangle(g, 0, 0, img.Width - 1, img.Height - 1, true, img.Width, img.Height,
                        BackgroundColor);
                }
                else if (val.Type == GeometryType.Polyline)
                {
                    val.Style.DrawLine(g, 0, 0, img.Width - 1, img.Height - 1, true, img.Width, img.Height,
                        BackgroundColor);
                }
                else if (val.Type == GeometryType.Point)
                {
                    val.Style.DrawPoint(g, 0.0f, 0.0f, img.Width, img.Height, BackgroundColor);
                }
            }
        }
        #endregion
    }

}
