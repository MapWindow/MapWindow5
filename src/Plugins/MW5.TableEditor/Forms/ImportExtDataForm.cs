using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using MW5.Plugins.TableEditor.BO;
using MW5.Plugins.TableEditor.Helpers;
using MW5.Plugins.TableEditor.Legacy;
using MW5.UI;

namespace MW5.Plugins.TableEditor.Forms
{
    /// <summary>
    /// Form-class for joining with external data
    /// </summary>
    public partial class ImportExtDataForm : MapWindowForm
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ImportExtDataForm"/> class. 
        /// Initializes a new instance of the frmJoinExtData class
        /// </summary>
        /// <param name="dt">
        /// The datatable.
        /// </param>
        public ImportExtDataForm(DataTable dt)
        {
            InitializeComponent();

            _shapeData = dt;

            FillCurrentKeyColumns(dt);
        }

        #endregion

        #region Constants and Fields

        /// <summary>
        ///   Filter for the filetypes to import from
        /// </summary>
        private const string OpenFileFilter = "Excel Files (*.xls)|*.xls|CSV Files (*.csv)|*.csv|All Files|*.*";

        // private const string OpenFileFilter = "Excel Files (*.xls)|*.xls|Open Office Files (*.ods)|*.ods|CSV Files (*.csv)|*.csv|All Files|*.*";

        /// <summary>
        ///   The shapedata
        /// </summary>
        private readonly DataTable _shapeData;

        #endregion

        #region Methods

        /// <summary>
        /// Fill combobox with fields from shape
        /// </summary>
        /// <param name="dt">
        /// The datatable.
        /// </param>
        private void FillCurrentKeyColumns(DataTable dt)
        {
            cboCurrentKeyCol.DataSource = ShapeData.GetVisibleFieldNames(dt);
        }

        /// <summary>
        /// Fill combobox with workbooks
        /// </summary>
        private void FillWorkBooks()
        {
            // Get workbooks
            var books = XlsImportHelper.GetWorkbooks(txtInputFile.Text);

            cboWorkBooks.DataSource = books;
        }

        /// <summary>
        /// Import the data
        /// </summary>
        /// <returns>
        /// Value indicating if importing was successfull
        /// </returns>
        private bool ImportData()
        {
            DataTable importedData;

            // csv of excel
            const bool RetVal = true;

            if (cboWorkBooks.Visible)
            {
                importedData = XlsImportHelper.GetData(txtInputFile.Text, cboWorkBooks.SelectedItem.ToString());
            }
            else
            {
                importedData = CsvImportHelper.GetData(txtInputFile.Text, cboDelimiter.Text);
            }

            for (var i = 0; i < importedData.Columns.Count; i++)
            {
                var dc = importedData.Columns[i];
                var addColumn = true;

                foreach (DataColumn dataColumn in _shapeData.Columns)
                {
                    if (dataColumn.ColumnName.PadRight(10).Substring(0, 10) ==
                        dc.ColumnName.PadRight(10).Substring(0, 10))
                    {
                        MessageBox.Show(
                            string.Format(
                                "Column {0} already exists. Column will be skipped",
                                dc.ColumnName.PadRight(10).Substring(0, 10)));
                        addColumn = false;
                    }
                }

                // to be changed in next version? Set length default to 50
                if (addColumn)
                {
                    ShapeData.AddDataColumn(_shapeData, importedData.Rows[0][i].ToString(), "String", "0", 50);
                }
            }

            for (var i = 0; i < _shapeData.Rows.Count; i++)
            {
                var currentKeyValue = _shapeData.Rows[i][cboCurrentKeyCol.SelectedItem.ToString()].ToString();

                var searchString = string.Format("{0} = '{1}'", cboExternalKeyCol.SelectedItem, currentKeyValue);
                var rows = importedData.Select(searchString);
                if (rows.Length == 0)
                {
                    // no matching data
                }
                else
                {
                    for (var j = 0; j < importedData.Columns.Count; j++)
                    {
                        var addColumn = true;

                        foreach (DataColumn dataColumn in _shapeData.Columns)
                        {
                            if (dataColumn.ColumnName.PadRight(10).Substring(0, 10)
                                == importedData.Columns[j].ColumnName.PadRight(10).Substring(0, 10))
                            {
                                addColumn = false;
                            }
                        }

                        if (addColumn)
                        {
                            _shapeData.Rows[i][importedData.Columns[j].ColumnName] =
                                rows[0][importedData.Columns[j].ColumnName].ToString();
                        }
                    }
                }
            }

            // }
            return RetVal;
        }

        /// <summary>
        /// The btn get columns_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void BtnGetColumnsClick(object sender, EventArgs e)
        {
            if (cboWorkBooks.Visible)
            {
                var colNames = XlsImportHelper.GetColumnNames(txtInputFile.Text, cboWorkBooks.SelectedItem.ToString());

                cboExternalKeyCol.DataSource = colNames;

                groupBox1.Enabled = true;
            }
            else
            {
                if (cboDelimiter.Text == string.Empty)
                {
                    MessageBox.Show(@"No delimiter selected.");
                }
                else
                {
                    var colNames = CsvImportHelper.GetColumnNames(txtInputFile.Text, cboDelimiter.Text);

                    cboExternalKeyCol.DataSource = colNames;

                    groupBox1.Enabled = true;
                }
            }

            // Lees eerste regel van bestand in voor de kolomnamen

            // List<string> colNames = XLSImport.GetColumnNames(txtInputFile.Text, cboWorkBooks.SelectedItem.ToString());

            // cboExternalKeyCol.DataSource = colNames;
        }

        /// <summary>
        /// Select file to import from
        /// </summary>
        /// <param name="sender">
        /// The sender of the event.
        /// </param>
        /// <param name="e">
        /// The arguments.
        /// </param>
        private void BtnInputFileClick(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog {Filter = OpenFileFilter};

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtInputFile.Text = ofd.FileName;
            }
        }

        /// <summary>
        /// Import the data
        /// </summary>
        /// <param name="sender">
        /// The sender of the event.
        /// </param>
        /// <param name="e">
        /// The arguments.
        /// </param>
        private void BtnOkClick(object sender, EventArgs e)
        {
            if (cboExternalKeyCol.SelectedItem == null || cboExternalKeyCol.SelectedItem.ToString() == string.Empty)
            {
                MessageBox.Show(@"Please select key columns.");
            }
            else
            {
                var importSuccess = ImportData();

                if (importSuccess)
                {
                    Close();
                }
            }
        }

        /// <summary>
        /// The btn open_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void BtnOpenClick(object sender, EventArgs e)
        {
            lblWorkbook.Visible = false;
            cboWorkBooks.Visible = false;
            lblDelimiter.Visible = false;
            cboDelimiter.Visible = false;
            btnGetColumns.Visible = false;
            groupBox1.Enabled = false;

            if (!File.Exists(txtInputFile.Text))
            {
                MessageBox.Show(@"File does not exist.");
            }
            else
            {
                // groupBox1.Enabled = true;
                btnGetColumns.Visible = true;

                var extension = Path.GetExtension(txtInputFile.Text);

                // if (extension == ".xls" || extension == ".ods")
                if (extension == ".xls")
                {
                    lblWorkbook.Visible = true;
                    cboWorkBooks.Visible = true;

                    FillWorkBooks();
                }
                else if (extension == ".csv")
                {
                    lblDelimiter.Visible = true;
                    cboDelimiter.Visible = true;
                }
                else
                {
                    // groupBox1.Enabled = false;
                    btnGetColumns.Visible = false;
                    MessageBox.Show(@"File type not supported.");
                }
            }
        }

        #endregion
    }
}