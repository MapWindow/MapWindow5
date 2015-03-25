using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MapWinGIS;
using MW5.Api;
using MW5.Plugins.TableEditor.BO;
using MW5.Plugins.TableEditor.Utils;

namespace MW5.Plugins.TableEditor.Forms
{
    /// <summary>
    /// Form-class which show the shape-data
    /// </summary>
    public partial class TableEditorForm : Form
    {
        private const int FastloadAmount = 1000;
        private bool _dataStillLoading;
        private bool _isStructureChanged;
        private int _selectColumnIndex;
        private ShapefileWrapper _sf;
        private bool _toolTipShown;
        private readonly AppContextWrapper _appContextWrapper;

        /// <summary>
        /// Initializes a new instance of the TableEditorForm class
        /// </summary>
        public TableEditorForm(ShapefileWrapper boSf, AppContextWrapper mapWindow)
        {
            InitializeComponent();

            ShapefileWrapper = boSf;
            _appContextWrapper = mapWindow;
        }

        #region Public Properties

        /// <summary>
        ///   Gets or sets the BOShapeFile-object
        /// </summary>
        public ShapefileWrapper ShapefileWrapper
        {
            get { return _sf; }

            set
            {
                _sf = value;
                SetTitle();
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Check if data is changed and save data if necessary
        /// </summary>
        /// <returns>
        /// Value indicating if saving was successfull
        /// </returns>
        public bool CheckAndSaveChanges()
        {
            var noChangesOrUpdated = true;

            var dt = (DataTable) TableEditorDataGrid.DataSource;

            if (ShapefileWrapper.ShapeData.DataChanged(dt))
            {
                var dialogResult = FormUtils.TopMostMessageBox("Save changes?", "TableEditor", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Save();
                }
                else
                {
                    noChangesOrUpdated = false;
                }
            }

            return noChangesOrUpdated;
        }

        /// <summary>
        /// The fill data grid.
        /// </summary>
        /// <param name="shapeFileData"> The shape file data. </param>
        public void FillDataGrid(DataTable shapeFileData)
        {
            TableEditorDataGrid.DataSource = shapeFileData;
            TableEditorDataGrid.ReadOnly = ShapefileWrapper.IsReadOnly;
            TableEditorDataGrid.Columns[0].ReadOnly = true;
            btnApply.Visible = !ShapefileWrapper.IsReadOnly;

            for (var i = 1; i < shapeFileData.Columns.Count; i++)
            {
                TableEditorDataGrid.Columns[i].Visible = !(bool) shapeFileData.Columns[i].ExtendedProperties["removed"];

                var joined = (bool) shapeFileData.Columns[i].ExtendedProperties["joined"];
                TableEditorDataGrid.Columns[i].DefaultCellStyle.BackColor = joined ? Color.OldLace : Color.White;
            }
        }

        /// <summary>
        /// Initializes the form
        /// </summary>
        public void InitForm()
        {
            SetTitle();

            SetDataGrid();

            TableEditorDataGrid.SelectionChanged += TableEditorDataGridSelectionChanged;
        }

        /// <summary>
        /// Filter gridview
        /// </summary>
        /// <param name="queryString"> The query to perform. </param>
        public void Query(string queryString)
        {
            var dt = (DataTable) TableEditorDataGrid.DataSource;

            try
            {
                var foundRows = dt.Select(queryString);

                if (foundRows.Length > 0)
                {
                    var updateSelection = new UpdateSelectionForm(foundRows.Length);
                    var result = updateSelection.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        var operation = updateSelection.SelectedOption;

                        var selectedIds = foundRows.Select(elm => Convert.ToInt32(elm[0])).ToList();

                        UpdateFromQuerySelection(operation, selectedIds);
                    }
                }
                else
                {
                    SetAllRows(false);
                }
            }
            catch (EvaluateException)
            {
                MessageBox.Show(@"The query you have entered is not valid. Please adjust your query syntax");
            }
        }

        /// <summary>
        /// Fill the datagrid with shape-data
        /// </summary>
        public void SetDataGrid()
        {
            var boShapeData = ShapefileWrapper.ShapeData;

            DataTable shapeFileData;

            if (boShapeData.NumShapes > FastloadAmount)
            {
                shapeFileData = boShapeData.GetDataTable(FastloadAmount);

                SetControlsEnabled(false);

                FillDataGrid(shapeFileData);

                lblAmountSeleted.Text = string.Format("{0} of {1} retrieved", FastloadAmount, boShapeData.NumShapes);
            }
            else
            {
                shapeFileData = boShapeData.GetDataTable(int.MaxValue);

                FillDataGrid(shapeFileData);

                SetControlsEnabled(true);

                lblAmountSeleted.Text = string.Format("{0} of {1} retrieved", boShapeData.NumShapes,
                    boShapeData.NumShapes);

                // PM Added: Select rows of previously selected shapes:
                SetSelected();
            }
        }

        /// <summary>
        /// Set the selected shapes in the grid equal to the map
        /// </summary>
        public void SetSelected()
        {
            // PM: Added, no need to loop through records if no shapes are selected:
            if (ShapefileWrapper.ShapeFile.NumSelected == 0)
            {
                lblAmountSeleted.Text = string.Format("{0} of {1} selected.", 0, TableEditorDataGrid.Rows.Count);
                return;
            }

            if (((DataTable) TableEditorDataGrid.DataSource).DefaultView.RowFilter == string.Empty)
            {
                // No filter
                // Paul Meems, 17-05-2013: Added some optimization:
                SelectRowsBasedOnSelectedShapes();

                /*
        for (int j = 0; j < boShapeFile.ShapeFile.NumShapes; j++)
        {
          TableEditorDataGrid.Rows[j].Selected = boShapeFile.ShapeFile.get_ShapeSelected(j);
        }
        */
            }
            else
            {
                var newRowfilter = CreateSelectedFilterFromShapeFile();

                ((DataTable) TableEditorDataGrid.DataSource).DefaultView.RowFilter = newRowfilter;

                SetAllRows(true);
            }

            lblAmountSeleted.Text = string.Format(
                "{0} of {1} selected.", TableEditorDataGrid.SelectedRows.Count, TableEditorDataGrid.Rows.Count);

            // Enable 'Show selected' button:
            btnShowSelected.Enabled = true;
            if (btnShowSelected.Tag != null && btnShowSelected.Tag.ToString() != string.Empty)
            {
                toolTip1.SetToolTip(btnShowSelected, btnShowSelected.Tag.ToString());
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Allow the user to specify a value for all of the selected records in the active column
        /// </summary>
        private void AssignValues()
        {
            var value = string.Empty;

            var result = FormUtils.InputBox(
                "Assign Values (Selected Records)", "Input:  (No Quotes Needed for String Values)", ref value);

            if (result != DialogResult.OK)
            {
                return;
            }

            try
            {
                var isValidValue = CheckCurrentColumn(_selectColumnIndex, value);

                if (isValidValue)
                {
                    for (var i = 0; i < TableEditorDataGrid.Rows.Count; i++)
                    {
                        if (TableEditorDataGrid.Rows[i].Selected)
                        {
                            ///////
                            // There seems to be a bug in the datatable, if only the first record is changed it doesn't
                            // get the status modified, so force it here!!
                            var dt = (DataTable) TableEditorDataGrid.DataSource;

                            if (i == 0 && dt.Rows[0].RowState != DataRowState.Modified)
                            {
                                dt.Rows[0].SetModified();
                            }

                            //////
                            TableEditorDataGrid[_selectColumnIndex, i].Value = value;
                        }
                    }
                }
                else
                {
                    MessageBox.Show(@"Syntax Error", @"Syntax Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Error in assign values", ex.Message);
            }
        }

        /// <summary>
        /// Check if a given value is valid for columntype
        /// </summary>
        /// <param name="columnId"> the column. </param>
        /// <param name="value"> The value to check. </param>
        /// <returns> Value indicating if value is valid </returns>
        private bool CheckCurrentColumn(int columnId, string value)
        {
            var checkCurrentColomn = true;

            // Get column type
            var type = TableEditorDataGrid[columnId, 0].ValueType;

            if (type == typeof (int))
            {
                checkCurrentColomn = NummericHelper.IsNumeric(value, NumberStyles.Integer);
            }
            else if (type == typeof (double))
            {
                checkCurrentColomn = NummericHelper.IsNumeric(value, NumberStyles.Float);
            }

            return checkCurrentColomn;
        }

        /// <summary>
        /// Create a filter based on selectedrow(s)
        /// </summary>
        /// <param name="selectedRows"> The selected rows. </param>
        /// <returns> The filter </returns>
        private static string CreateSelectedFilterFromGrid(DataGridViewSelectedRowCollection selectedRows)
        {
            string newRowfilter;

            if (selectedRows != null && selectedRows.Count != 0)
            {
                var query = new StringBuilder();
                query.Append("(");

                foreach (DataGridViewRow row in selectedRows)
                {
                    query.Append(row.Cells[0].Value).Append(",");
                }

                query.Remove(query.Length - 1, 1).Append(")");

                newRowfilter = string.Format("SHAPE__ID IN {0}", query);
            }
            else
            {
                newRowfilter = "1 = 3";
            }

            return newRowfilter;
        }

        /// <summary>
        /// Create a filter which retreives the selected shapes
        /// </summary>
        /// <returns> The filter </returns>
        private string CreateSelectedFilterFromShapeFile()
        {
            var query = new StringBuilder();
            query.Append("(");

            for (var j = 0; j < ShapefileWrapper.ShapeFile.NumShapes; j++)
            {
                if (ShapefileWrapper.ShapeFile.get_ShapeSelected(j))
                {
                    query.Append(j.ToString()).Append(",");
                }
            }

            query.Remove(query.Length - 1, 1).Append(")");

            var newRowfilter = "1 = 3";
            if (query.Length > 2)
            {
                newRowfilter = string.Format("SHAPE__ID IN {0}", query);
            }

            return newRowfilter;
        }

        /// <summary>
        /// Deselect all shapes in grid
        /// </summary>
        private void DeSelectAllRows()
        {
            foreach (DataGridViewRow row in TableEditorDataGrid.Rows)
            {
                row.Selected = false;
            }
        }

        /// <summary>
        /// Checks which buttons should be enabled or disabled
        /// </summary>
        private void EnableButtons()
        {
            // Default tooltip is in de tag:
            toolTip1.SetToolTip(UpdateMeasurements, "Update measurements");

            // Issue #2219: check shapefile type and projection
            if (ShapefileWrapper.ShapeFile.GeoProjection.IsEmpty &&
                ShapefileWrapper.ShapeFile.Projection == string.Empty)
            {
                updateMeasurementsToolStripMenuItem.Enabled = false;
                UpdateMeasurements.Enabled = false;
                toolTip1.SetToolTip(UpdateMeasurements, "The shapefile has no projection");
            }

            if (ShapefileWrapper.ShapeFile.ShapefileType == ShpfileType.SHP_POINT
                || ShapefileWrapper.ShapeFile.ShapefileType == ShpfileType.SHP_POINTM
                || ShapefileWrapper.ShapeFile.ShapefileType == ShpfileType.SHP_POINTZ)
            {
                updateMeasurementsToolStripMenuItem.Enabled = false;
                UpdateMeasurements.Enabled = false;
                toolTip1.SetToolTip(UpdateMeasurements, "The shapefile is a point shapefile");
            }
        }

        /// <summary>
        /// Open form for fieldcalculator
        /// </summary>
        /// <param name="selectedColumnIndex">
        /// The index of the selected Column
        /// </param>
        private void FieldCalculator(int selectedColumnIndex)
        {
            // Check if data has changed
            if (CheckAndSaveChanges())
            {
                var calculator = new FieldCalculatorForm(ShapefileWrapper, TableEditorDataGrid, selectedColumnIndex);
                calculator.ShowDialog();

                if (calculator.ShowTextEditor)
                {
                    new TextCalculatorForm(TableEditorDataGrid, selectedColumnIndex).ShowDialog();
                }
            }
            else
            {
                MessageBox.Show(@"Changes must be saved first.");
            }
        }

        /// <summary>
        /// Generate or update shapeId's
        /// </summary>
        /// <param name="destField">
        /// The field where the id's will be written to.
        /// </param>
        private void GenerateShapeIDField(string destField)
        {
            var status = "updated";
            var idColumnNr = -1;

            var dt = (DataTable) TableEditorDataGrid.DataSource;

            for (var i = 0; i < dt.Columns.Count; i++)
            {
                if (dt.Columns[i].ColumnName.ToLower() == destField.ToLower())
                {
                    idColumnNr = i;
                    break;
                }
            }

            if (idColumnNr == -1)
            {
                status = "created";

                ShapeData.AddDataColumn(dt, destField, "Integer", "10", 10);
                idColumnNr = dt.Columns.Count - 1;
            }

            for (var j = 0; j < dt.Rows.Count; j++)
            {
                dt.Rows[j][idColumnNr] = j;
            }

            MessageBox.Show(string.Format("The {0} field has been {1}.", destField, status));
        }

        /// <summary>
        /// Import fielddefinitions
        /// </summary>
        private void ImportFieldsFromDbf()
        {
            if (ShapefileWrapper.IsReadOnly)
            {
                MessageBox.Show(@"Shapefile is readonly.");
                return;
            }

            var dialog = new OpenFileDialog
            {
                Filter = @"DBF Files (*.dbf)|*.dbf",
                Title = @"Please choose the DBF file whose field definitions you would like to import..."
            };

            if (dialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            var impTable = new Table();

            if (!impTable.Open(dialog.FileName, null))
            {
                MessageBox.Show(@"The table could not be opened.");
                return;
            }

            Field field = null;

            for (var i = 0; i < impTable.NumFields; i++)
            {
                var skipField = false;
                foreach (DataGridViewColumn column in TableEditorDataGrid.Columns)
                {
                    field = impTable.get_Field(i);

                    if (column.Name == field.Name)
                    {
                        MessageBox.Show(string.Format("The field {0} already exists and will be skipped!", field.Name));
                        skipField = true;
                    }
                }

                if (!skipField)
                {
                    ShapeData.AddDataColumn(
                        (DataTable) TableEditorDataGrid.DataSource,
                        field.Name,
                        field.Type.ToString(),
                        field.Precision.ToString(),
                        field.Width);
                    _isStructureChanged = true;
                }
            }
        }

        /// <summary>
        /// Invert selected shapes in grid
        /// </summary>
        private void InvertSelection()
        {
            foreach (DataGridViewRow row in TableEditorDataGrid.Rows)
            {
                row.Selected = !row.Selected;
            }
        }

        /// <summary>
        /// Open form to import external data
        /// </summary>
        /// <param name="sender">
        /// The sender of the event.
        /// </param>
        /// <param name="e">
        /// The arguments.
        /// </param>
        private void MnuImportExtDataClick(object sender, EventArgs e)
        {
            var frmExtData = new ImportExtDataForm((DataTable) TableEditorDataGrid.DataSource);
            frmExtData.ShowDialog();
        }

        /// <summary>
        /// Opens the form to update the measurements
        /// </summary>
        /// <remarks>
        /// Added by Paul Meems, 29 May 2012
        /// </remarks>
        private void OpenUpdateMeasurmentsForm()
        {
            if (ShapefileWrapper.IsReadOnly)
            {
                MessageBox.Show(@"Shapefile is readonly.");
                return;
            }

            // Issue #2219: check shapefile type and projection
            if (ShapefileWrapper.ShapeFile.GeoProjection.IsEmpty &&
                ShapefileWrapper.ShapeFile.Projection == string.Empty)
            {
                MessageBox.Show(
                    @"The shapefile has no projection. The measurements cannot be calculated for shapefiles without projection.");
                return;
            }

            if (ShapefileWrapper.ShapeFile.ShapefileType == ShpfileType.SHP_POINT
                || ShapefileWrapper.ShapeFile.ShapefileType == ShpfileType.SHP_POINTM
                || ShapefileWrapper.ShapeFile.ShapefileType == ShpfileType.SHP_POINTZ)
            {
                MessageBox.Show(
                    @"You've opened a point shapefile. The measurements cannot be calculated for point shapefiles");
                return;
            }

            var dt = TableEditorDataGrid.DataSource as DataTable;

            var frm = new UpdateMeasurementsForm(dt, ShapefileWrapper) {TopMost = true};
            frm.ShowDialog();
        }

        /// <summary>
        /// The mouse move event to show tooltips of disabled buttons
        /// </summary>
        private void Panel1MouseMove(object sender, MouseEventArgs e)
        {
            var parent = sender as Control;
            if (parent == null)
            {
                return;
            }

            var ctrl = parent.GetChildAtPoint(e.Location);
            if (ctrl != null)
            {
                if (ctrl.Visible && toolTip1.Tag == null)
                {
                    if (!_toolTipShown)
                    {
                        var tipstring = toolTip1.GetToolTip(ctrl);
                        toolTip1.Show(tipstring.Trim(), ctrl, ctrl.Width/2, ctrl.Height);
                        toolTip1.Tag = ctrl;
                        _toolTipShown = true;
                    }
                }
            }
            else
            {
                ctrl = toolTip1.Tag as Control;
                if (ctrl != null)
                {
                    toolTip1.Hide(ctrl);
                    toolTip1.Tag = null;
                    _toolTipShown = false;
                }
            }
        }

        /// <summary>
        /// Open form to perform a query
        /// </summary>
        private void QueryForm()
        {
            if (((DataTable) TableEditorDataGrid.DataSource).DefaultView.RowFilter != string.Empty)
            {
                ShowSelected();
            }

            var queryBuilder = new QueryBuilderForm((DataTable) TableEditorDataGrid.DataSource, Query);
            queryBuilder.ShowDialog();
        }

        /// <summary>
        /// Save changed data
        /// </summary>
        private void Save()
        {
            var dt = (DataTable) TableEditorDataGrid.DataSource;
            if (dt != null)
            {
                ShapefileWrapper.ShapeData.SaveData(dt);

                // PM: only needed when the structure is changes:
                if (_isStructureChanged)
                {
                    SetDataGrid();
                }
            }
        }

        /// <summary>
        /// The select rows based on selected shapes.
        /// </summary>
        private void SelectRowsBasedOnSelectedShapes()
        {
            Application.DoEvents();
            var numSelectedShapes = ShapefileWrapper.ShapeFile.NumSelected;
            var numSelectedRows = 0;
            var scrollTo = -1;
            for (var j = 0; j < ShapefileWrapper.ShapeFile.NumShapes; j++)
            {
                if (ShapefileWrapper.ShapeFile.get_ShapeSelected(j))
                {
                    if (scrollTo == -1)
                    {
                        scrollTo = j;
                    }

                    TableEditorDataGrid.Rows[j].Selected = true;
                    numSelectedRows++;
                    if (numSelectedRows == numSelectedShapes)
                    {
                        // Selected all needed rows.
                        // No need to continue:
                        break;
                    }
                }
                else
                {
                    TableEditorDataGrid.Rows[j].Selected = false;
                }
            }

            // Scroll to the first selected row:
            if (scrollTo > -1)
            {
                TableEditorDataGrid.FirstDisplayedScrollingRowIndex = scrollTo;
            }
        }

        /// <summary>
        /// Select or deselect all shapes
        /// </summary>
        /// <param name="selected">
        /// Indicates if rows have to be selected or deselected.
        /// </param>
        private void SetAllRows(bool selected)
        {
            foreach (DataGridViewRow row in TableEditorDataGrid.Rows)
            {
                row.Selected = selected;
            }
        }

        /// <summary>
        /// Enable the controls
        /// </summary>
        /// <param name="enabled">
        /// Enabled or disable
        /// </param>
        private void SetControlsEnabled(bool enabled)
        {
            mnuGridView.Enabled = enabled;
            menuStrip1.Enabled = enabled;

            // Enable specific menu items:
            editToolStripMenuItem.Enabled = true;
            mnuStatistics.Enabled = true;

            foreach (Control c in panel1.Controls)
            {
                if (c is Button)
                {
                    var b = (Button) c;
                    b.Enabled = enabled;
                    if (!enabled)
                    {
                        b.Tag = toolTip1.GetToolTip(b);
                        toolTip1.SetToolTip(b, "Click the 'Get all' button to enable all options");
                    }
                    else
                    {
                        if (b.Tag != null && b.Tag.ToString() != string.Empty)
                        {
                            toolTip1.SetToolTip(b, b.Tag.ToString());
                        }
                    }
                }
            }

            btnGetAll.Visible = !enabled;
            btnGetAll.Enabled = !enabled;

            btnClose.Visible = true;
            btnClose.Enabled = true;

            // Paul Meems, 9 Oct. 2012: Issue #2219: check shapefile type and projection
            EnableButtons();
        }

        /// <summary>
        /// Set the title of the form
        /// </summary>
        private void SetTitle()
        {
            // Text += " - " + boShapeFile.ShapefileName;
            Text = @"Attribute Table Editor - " + ShapefileWrapper.ShapefileName;

            // Check if shape is readonly
            if (ShapefileWrapper.IsReadOnly)
            {
                Text += @" [ReadOnly]";
            }
        }

        /// <summary>
        /// Set selected shapes in grid
        /// </summary>
        private void ShowSelected()
        {
            // Disable grid-changed event
            TableEditorDataGrid.SelectionChanged -= TableEditorDataGridSelectionChanged;

            if (((DataTable) TableEditorDataGrid.DataSource).DefaultView.RowFilter == string.Empty)
            {
                // Only show selected records
                var newRowfilter = CreateSelectedFilterFromGrid(TableEditorDataGrid.SelectedRows);

                // Apply filter on grid
                ((DataTable) TableEditorDataGrid.DataSource).DefaultView.RowFilter = newRowfilter;

                // Select all rows
                SetAllRows(true);
            }
            else
            {
                // Remove filter from grid
                ((DataTable) TableEditorDataGrid.DataSource).DefaultView.RowFilter = string.Empty;

                // Select rows in grid again
                // Paul Meems, 17-05-2013: Added some optimization:
                SelectRowsBasedOnSelectedShapes();
            }

            Application.DoEvents();
        }

        /// <summary>
        /// The show statistics.
        /// </summary>
        private void ShowStatistics()
        {
            if (TableEditorDataGrid.SelectedRows.Count == 0)
            {
                MessageBox.Show(@"No rows selected");
                return;
            }

            var values = new List<double>();

            for (var i = 0; i < TableEditorDataGrid.Rows.Count; i++)
            {
                if (TableEditorDataGrid.Rows[i].Selected)
                {
                    values.Add(
                        Convert.ToDouble(TableEditorDataGrid[_selectColumnIndex, i].Value, CultureInfo.InvariantCulture));
                }
            }

            if (values.Count == 0)
            {
                MessageBox.Show(@"No rows selected");
                return;
            }

            var sum = values.Sum();
            double count = values.Count;
            var min = values.Min();
            var max = values.Max();

            var mean = sum/count;
            var range = max - min;

            var sumMeanDiff = values.Sum(value => Math.Pow(value - mean, 2));

            var stdev = Math.Sqrt(sumMeanDiff/999);

            var summary =
                string.Format(
                    "Column: {0}\r\nSum: {1}\r\nCount: {2}\r\nMean: {3}\r\nMaximum: {4}\r\nMinimum: {5}\r\nRange: {6}\r\nStandard Deviation: {7}",
                    TableEditorDataGrid.Columns[_selectColumnIndex].HeaderText,
                    Math.Round(sum, 2).ToString(CultureInfo.InvariantCulture),
                    count,
                    Math.Round(mean, 2).ToString(CultureInfo.InvariantCulture),
                    Math.Round(max, 2).ToString(CultureInfo.InvariantCulture),
                    Math.Round(min, 2).ToString(CultureInfo.InvariantCulture),
                    Math.Round(range, 2).ToString(CultureInfo.InvariantCulture),
                    Math.Round(stdev, 2).ToString(CultureInfo.InvariantCulture));

            MessageBox.Show(summary);
        }

        /// <summary>
        /// The table editor data grid_ column header mouse click.
        /// </summary>
        private void TableEditorDataGridColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
            {
                return;
            }

            _selectColumnIndex = e.ColumnIndex;

            mnuGridView.Show(
                TableEditorDataGrid,
                TableEditorDataGrid.PointToClient(Cursor.Position).X,
                TableEditorDataGrid.PointToClient(Cursor.Position).Y + (TableEditorDataGrid.ColumnHeadersHeight/2));

            var type = TableEditorDataGrid[e.ColumnIndex, 0].ValueType;

            mnuStatistics.Enabled = type == typeof (int) || type == typeof (double);
        }

        /// <summary>
        /// Show error
        /// </summary>
        private void TableEditorDataGridDataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception == null)
            {
                return;
            }

            MessageBox.Show(e.Exception.Message);
            var dt = (DataTable) TableEditorDataGrid.DataSource;
            dt.Rows[e.RowIndex][e.ColumnIndex] = DBNull.Value;
        }

        /// <summary>
        /// Update map if selection is changed in grid
        /// </summary>
        private void TableEditorDataGridSelectionChanged(object sender, EventArgs e)
        {
            var rowCollection = TableEditorDataGrid.SelectedRows;

            lblAmountSeleted.Text = string.Format(
                "{0} of {1} selected.", rowCollection.Count, TableEditorDataGrid.Rows.Count);

            var indices = new int[rowCollection.Count];

            for (var i = 0; i < rowCollection.Count; i++)
            {
                var index = Convert.ToInt32(rowCollection[i].Cells[0].Value);
                indices[i] = index;
            }

            if (!_dataStillLoading)
            {
                _appContextWrapper.UpdateMap(indices);
            }

            // Paul Meems, 17-05-2013. Enabled the zoom to selected button even if not all rows are loaded:
            if (TableEditorDataGrid.SelectedRows.Count > 0)
            {
                btnZoomToSelected.Enabled = true;
                if (btnZoomToSelected.Tag != null && btnZoomToSelected.Tag.ToString() != string.Empty)
                {
                    toolTip1.SetToolTip(btnZoomToSelected, btnZoomToSelected.Tag.ToString());
                }
            }
        }

        /// <summary>
        /// The trim column.
        /// </summary>
        /// <param name="selectedOnly">
        /// The selected only.
        /// </param>
        private void TrimColumn(bool selectedOnly)
        {
            // Get column type
            var type = TableEditorDataGrid[_selectColumnIndex, 0].ValueType;

            if (type == typeof (string))
            {
                for (var i = 0; i < TableEditorDataGrid.Rows.Count; i++)
                {
                    if (!selectedOnly || TableEditorDataGrid.Rows[i].Selected)
                    {
                        TableEditorDataGrid[_selectColumnIndex, i].Value =
                            TableEditorDataGrid[_selectColumnIndex, i].Value.ToString().Trim();
                    }
                }
            }
        }

        /// <summary>
        /// Exectue a query
        /// </summary>
        /// <param name="operation">
        /// The operation to perform.
        /// </param>
        /// <param name="selectedIds">
        /// The list of selecteds shapes to perform the operation on.
        /// </param>
        private void UpdateFromQuerySelection(SelectionOperation operation, List<int> selectedIds)
        {
            switch (operation)
            {
                case SelectionOperation.New:
                    foreach (DataGridViewRow row in TableEditorDataGrid.Rows)
                    {
                        row.Selected = selectedIds.Exists(elm => elm == Convert.ToInt32(row.Cells[0].Value));
                    }

                    break;
                case SelectionOperation.Add:
                    foreach (var row in
                        TableEditorDataGrid.Rows.Cast<DataGridViewRow>()
                            .Where(row => selectedIds.Exists(elm => elm == Convert.ToInt32(row.Cells[0].Value))))
                    {
                        row.Selected = true;
                    }

                    break;

                case SelectionOperation.Exclude:
                    foreach (var row in
                        TableEditorDataGrid.Rows.Cast<DataGridViewRow>()
                            .Where(row => selectedIds.Exists(elm => elm == Convert.ToInt32(row.Cells[0].Value))))
                    {
                        row.Selected = false;
                    }

                    break;
                case SelectionOperation.Invert:
                    foreach (var row in
                        TableEditorDataGrid.Rows.Cast<DataGridViewRow>()
                            .Where(row => selectedIds.Exists(elm => elm == Convert.ToInt32(row.Cells[0].Value))))
                    {
                        row.Selected = !row.Selected;
                    }

                    break;
            }
        }

        /// <summary>
        /// Button click event
        /// </summary>
        private void UpdateMeasurementsClick(object sender, EventArgs e)
        {
            OpenUpdateMeasurmentsForm();
        }

        /// <summary>
        /// Menu item click event
        /// </summary>
        private void UpdateMeasurementsToolStripMenuItemClick(object sender, EventArgs e)
        {
            OpenUpdateMeasurmentsForm();
        }

        /// <summary>
        /// Zoom to selected/edited shape
        /// </summary>
        private void ZoomToEdit()
        {
            _appContextWrapper.ZoomToEdit(
                Convert.ToInt32(TableEditorDataGrid.CurrentRow.Cells[0].Value), ShapefileWrapper.ShapeFile);
        }

        /// <summary>
        /// Zoom to selected shape(s)
        /// </summary>
        private void ZoomToSelected()
        {
            if (TableEditorDataGrid.SelectedRows.Count == 0)
            {
                return;
            }

            if ((ShapefileWrapper.ShapeFile.ShapefileType == ShpfileType.SHP_POINT
                 || ShapefileWrapper.ShapeFile.ShapefileType == ShpfileType.SHP_MULTIPOINT)
                && TableEditorDataGrid.SelectedRows.Count == 1)
            {
                _appContextWrapper.MoveToSelected(TableEditorDataGrid.SelectedRows, ShapefileWrapper.ShapeFile);
            }
            else
            {
                _appContextWrapper.ZoomToSelected(TableEditorDataGrid.SelectedRows, ShapefileWrapper.ShapeFile);
            }
        }

        /// <summary>
        /// Open form to add new field
        /// </summary>
        private void AddFieldToolStripMenuItemClick(object sender, EventArgs e)
        {
            if (ShapefileWrapper.IsReadOnly)
            {
                MessageBox.Show(@"Shapefile is readonly.");
                return;
            }

            var dt = TableEditorDataGrid.DataSource as DataTable;

            var frm = new NewFieldForm(dt) {TopMost = true};
            if (frm.ShowDialog() == DialogResult.OK)
            {
                _isStructureChanged = true;
            }
        }

        /// <summary>
        /// Save changed data
        /// </summary>
        private void BtnApplyClick(object sender, EventArgs e)
        {
            Save();
        }

        /// <summary>
        /// Save changed data
        /// </summary>
        private void BtnCloseClick(object sender, EventArgs e)
        {
            CheckAndSaveChanges();

            Close();
        }

        /// <summary>
        /// Open form for fieldcalculator
        /// </summary>
        private void BtnFieldCalculatorClick(object sender, EventArgs e)
        {
            FieldCalculator(0);
        }

        /// <summary>
        /// The btn get all_ click.
        /// </summary>
        private void BtnGetAllClick(object sender, EventArgs e)
        {
            btnGetAll.Enabled = false;
            _dataStillLoading = true;

            var boShapeData = ShapefileWrapper.ShapeData;

            lblAmountSeleted.Text = string.Format("Busy loading {0} records...", boShapeData.NumShapes);

            var shapeFileData = boShapeData.GetDataTable(int.MaxValue);

            FillDataGrid(shapeFileData);

            SetControlsEnabled(true);

            lblAmountSeleted.Text = string.Format("{0} of {1} retrieved", boShapeData.NumShapes, boShapeData.NumShapes);

            // PM Added: Select rows of previously selected shapes:
            Debug.WriteLine("Num selected: " + ShapefileWrapper.ShapeFile.NumSelected);
            SetSelected();

            _dataStillLoading = false;
        }

        /// <summary>
        /// Import fielddefinitions
        /// </summary>
        private void BtnImportFieldsFromDbfClick(object sender, EventArgs e)
        {
            ImportFieldsFromDbf();
        }

        /// <summary>
        /// Opens joins manager
        /// </summary>
        private void BtnJoinClick(object sender, EventArgs e)
        {
            if (CheckAndSaveChanges())
            {
                var tbl = ShapefileWrapper.ShapeFile.Table;
                var state = tbl.Serialize();

                var form = new JoinManagerForm((DataTable) TableEditorDataGrid.DataSource, tbl);
                form.ShowDialog(this);

                if (tbl.Serialize() != state)
                {
                    // reload it completely in case of any changes
                    SetDataGrid();
                    _appContextWrapper.MarkProjectModified(); // join operations can be saved in the project
                }
            }
        }

        /// <summary>
        /// Set selected shapes in grid
        /// </summary>
        private void BtnShowSelectedClick(object sender, EventArgs e)
        {
            ShowSelected();
        }

        /// <summary>
        /// Zoom to selected shape(s)
        /// </summary>
        private void BtnZoomToSelectedClick(object sender, EventArgs e)
        {
            ZoomToSelected();
        }

        /// <summary>
        /// The mnu assign values_ click.
        /// </summary>
        private void MnuAssignValuesClick(object sender, EventArgs e)
        {
            AssignValues();
        }

        /// <summary>
        /// The mnu calc values_ click.
        /// </summary>
        private void MnuCalcValuesClick(object sender, EventArgs e)
        {
            FieldCalculator(_selectColumnIndex - 1);
        }

        /// <summary>
        /// Copy shapeId's
        /// </summary>
        private void MnuCopyShapeIDsClick(object sender, EventArgs e)
        {
            var result = string.Empty;
            FormUtils.InputBox(
                "Assign Feature ID to a field", "Enter the name of the target field  (Data will be overwritten)",
                ref result);

            if (result == string.Empty)
            {
                MessageBox.Show(@"No field name was specified. Aborting.");
            }
            else if (result.Length > 10)
            {
                MessageBox.Show(@"The field name can only be 10 characters long. Aborting.");
            }
            else
            {
                GenerateShapeIDField(result);
            }
        }

        /// <summary>
        /// Export features
        /// </summary>
        private void MnuExportFeaturesClick(object sender, EventArgs e)
        {
            // Check if data has changed
            if (CheckAndSaveChanges())
            {
                _appContextWrapper.ExportShapes(ShapefileWrapper.ShapeFile);
            }
            else
            {
                MessageBox.Show(@"No data exported. Changes must be saved first.");
            }
        }

        /// <summary>
        /// Open form for fieldcalculator
        /// </summary>
        private void MnuFieldCalculatorClick(object sender, EventArgs e)
        {
            FieldCalculator(0);
        }

        /// <summary>
        /// Perform a search
        /// </summary>
        private void MnuFindClick(object sender, EventArgs e)
        {
            var value = string.Empty;
            if (FormUtils.InputBox("Find", "Search:", ref value) == DialogResult.OK && value != string.Empty)
            {
                for (var i = 0; i < TableEditorDataGrid.Rows.Count; i++)
                {
                    for (var j = 0; j < TableEditorDataGrid.Columns.Count; j++)
                    {
                        try
                        {
                            var cellValue = TableEditorDataGrid[j, i].Value.ToString();

                            TableEditorDataGrid.Rows[i].Cells[j].Selected = cellValue.ToLower().Contains(value);
                        }
                        catch
                        {
                        }
                    }
                }

                if (TableEditorDataGrid.SelectedCells.Count == 0)
                {
                    MessageBox.Show(@"No results found.");
                }
            }
        }

        /// <summary>
        /// Generate or update shapeId's
        /// </summary>
        private void MnuGenerateOrUpdateShapeIDClick(object sender, EventArgs e)
        {
            if (ShapefileWrapper.IsReadOnly)
            {
                MessageBox.Show(@"Shapefile is readonly.");
            }
            else
            {
                GenerateShapeIDField("MWShapeID");
            }
        }

        /// <summary>
        /// Import fielddefinitions
        /// </summary>
        private void MnuImportFieldDefinitionsClick(object sender, EventArgs e)
        {
            ImportFieldsFromDbf();
        }

        /// <summary>
        /// Invert selected shapes in grid
        /// </summary>
        private void MnuInvertSelectionClick(object sender, EventArgs e)
        {
            InvertSelection();
        }

        /// <summary>
        /// Open form to perform a query
        /// </summary>
        private void MnuQueryClick(object sender, EventArgs e)
        {
            QueryForm();
        }

        /// <summary>
        /// Perform a replace
        /// </summary>
        private void MnuReplaceClick(object sender, EventArgs e)
        {
            var search = string.Empty;
            var replace = string.Empty;
            var totalChanged = 0;

            if (FormUtils.ReplaceBox(ref search, ref replace) == DialogResult.OK && search != string.Empty)
            {
                for (var j = 1; j < TableEditorDataGrid.Columns.Count; j++)
                {
                    var checkCurrentColomn = CheckCurrentColumn(j, replace);

                    if (checkCurrentColomn)
                    {
                        for (var i = 0; i < TableEditorDataGrid.Rows.Count; i++)
                        {
                            try
                            {
                                var cellValue = TableEditorDataGrid[j, i].Value.ToString();
                                if (cellValue.ToLower().Contains(search.ToLower()))
                                {
                                    ///////
                                    // There seems to be a bug in the datatable, if only the first record is changed it doesn't
                                    // get the status modified, so force it here!!
                                    var dt = (DataTable) TableEditorDataGrid.DataSource;

                                    if (i == 0 && dt.Rows[0].RowState != DataRowState.Modified)
                                    {
                                        dt.Rows[0].SetModified();
                                    }

                                    //////
                                    TableEditorDataGrid[j, i].Value = Regex.Replace(
                                        cellValue, search, replace, RegexOptions.IgnoreCase);
                                    totalChanged++;
                                }
                            }
                            catch
                            {
                            }
                        }
                    }
                }
            }

            MessageBox.Show(string.Format("{0} replacements were made.", totalChanged));
        }

        /// <summary>
        /// Select all shapes in grid
        /// </summary>
        /// <param name="sender">
        /// The sender of the event.
        /// </param>
        /// <param name="e">
        /// The arguments.
        /// </param>
        private void MnuSelectAllClick(object sender, EventArgs e)
        {
            SetAllRows(true);
        }

        /// <summary>
        /// Deselect all shapes in grid
        /// </summary>
        /// <param name="sender">
        /// The sender of the event.
        /// </param>
        /// <param name="e">
        /// The arguments.
        /// </param>
        private void MnuSelectNoneClick(object sender, EventArgs e)
        {
            DeSelectAllRows();
        }

        /// <summary>
        /// Show selected shapes
        /// </summary>
        /// <param name="sender">
        /// The sender of the event.
        /// </param>
        /// <param name="e">
        /// The arguments.
        /// </param>
        private void MnuShowSelectedClick(object sender, EventArgs e)
        {
            ShowSelected();
        }

        /// <summary>
        /// The mnu statistics_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void MnuStatisticsClick(object sender, EventArgs e)
        {
            ShowStatistics();
        }

        /// <summary>
        /// The mnu trim all_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void MnuTrimAllClick(object sender, EventArgs e)
        {
            TrimColumn(false);
        }

        /// <summary>
        /// The mnu trim selected_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void MnuTrimSelectedClick(object sender, EventArgs e)
        {
            TrimColumn(true);
        }

        /// <summary>
        /// Zoom to selected/edited shape
        /// </summary>
        /// <param name="sender">
        /// The sender of the event.
        /// </param>
        /// <param name="e">
        /// The arguments.
        /// </param>
        private void MnuZoomToEditedClick(object sender, EventArgs e)
        {
            ZoomToEdit();
        }

        /// <summary>
        /// Zoom to selected shapes
        /// </summary>
        /// <param name="sender">
        /// The sender of the event.
        /// </param>
        /// <param name="e">
        /// The arguments.
        /// </param>
        private void MnuZoomToSelectedClick(object sender, EventArgs e)
        {
            ZoomToSelected();
        }

        /// <summary>
        /// Open form to remove field
        /// </summary>
        /// <param name="sender">
        /// The sender of the event.
        /// </param>
        /// <param name="e">
        /// The arguments.
        /// </param>
        private void RemoveFieldToolStripMenuItemClick(object sender, EventArgs e)
        {
            if (ShapefileWrapper.IsReadOnly)
            {
                MessageBox.Show(@"Shapefile is readonly.");
                return;
            }

            var dt = TableEditorDataGrid.DataSource as DataTable;

            var frm = new DeleteFieldForm(dt) {TopMost = true};

            if (frm.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            for (var i = 1; i < dt.Columns.Count; i++)
            {
                if ((bool) dt.Columns[i].ExtendedProperties["removed"])
                {
                    TableEditorDataGrid.Columns[i].Visible = false;
                    _isStructureChanged = true;
                }
            }
        }

        /// <summary>
        /// Open form to rename field
        /// </summary>
        /// <param name="sender">
        /// The sender of the event.
        /// </param>
        /// <param name="e">
        /// The arguments.
        /// </param>
        private void RenameFieldToolStripMenuItemClick(object sender, EventArgs e)
        {
            if (ShapefileWrapper.IsReadOnly)
            {
                MessageBox.Show(@"Shapefile is readonly.");
                return;
            }

            var dt = TableEditorDataGrid.DataSource as DataTable;

            var frm = new RenameFieldForm(dt) {TopMost = true};

            frm.ShowDialog();
        }

        /// <summary>
        /// Open form to perform a query
        /// </summary>
        /// <param name="sender">
        /// The sender of the event.
        /// </param>
        /// <param name="e">
        /// The arguments.
        /// </param>
        private void TbbQueryClick(object sender, EventArgs e)
        {
            QueryForm();
        }

        #endregion
    }
}