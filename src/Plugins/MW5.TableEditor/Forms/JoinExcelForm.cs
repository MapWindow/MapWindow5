using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using MapWinGIS;
using MW5.Plugins.TableEditor.Helpers;
using MW5.UI;
using MW5.UI.Forms;

namespace MW5.Plugins.TableEditor.Forms
{
    /// <summary>
    /// The frm join excel.
    /// </summary>
    public partial class JoinExcelForm : MapWindowForm
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="JoinExcelForm"/> class. 
        /// Initializes a new instance of the frmJoinExtData class
        /// </summary>
        /// <param name="dt"> The datatable. </param>
        /// <param name="tbl"> The tbl. </param>
        /// <param name="filename"> The filename. </param>
        /// <param name="joinId"> The join Id. </param>
        public JoinExcelForm(DataTable dt, Table tbl, string filename, int joinId)
        {
            InitializeComponent();

            _table = tbl;
            _filename = filename;

            FillCurrentKeyColumns();

            UpdateControlsState();

            Text = @"Joining file: " + filename;
        }

        #endregion

        #region Constants and Fields

        /// <summary>
        /// The filename.
        /// </summary>
        private readonly string _filename = string.Empty;

        /// <summary>
        /// The table.
        /// </summary>
        private readonly Table _table; // underlying dbf of current shapefile

        #endregion

        #region Methods

        /// <summary>
        /// Fill combobox with fields from shape
        /// </summary>
        private void FillCurrentKeyColumns()
        {
            var names = new List<string>();

            for (var i = 0; i < _table.NumFields; i++)
            {
                names.Add(_table.get_Field(i).Name);
            }

            cboCurrentKeyCol.DataSource = names;
        }

        /// <summary>
        /// Fill combobox with workbooks
        /// </summary>
        private void FillWorkBooks()
        {
            // Get workbooks
            var books = XlsImportHelper.GetWorkbooks(_filename);
            cboWorkBooks.DataSource = books.Distinct().ToList();

            // strange, but I got a replica of the worksheet for .xlsx format
        }

        /// <summary>
        /// Fills the list of columns of external datasource
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
                var colNames = XlsImportHelper.GetColumnNames(_filename, cboWorkBooks.SelectedItem.ToString());

                cboExternalKeyCol.DataSource = colNames;

                groupBox1.Enabled = true;
            }
            else
            {
                if (cboDelimiter.Text == string.Empty)
                {
                    MessageBox.Show(@"No delimiter selected.");
                    return;
                }

                var colNames = CsvImportHelper.GetColumnNames(_filename, cboDelimiter.Text);

                cboExternalKeyCol.DataSource = colNames;

                groupBox1.Enabled = true;
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
                return;
            }

            DataTable dt;
            string options;

            if (cboWorkBooks.Visible)
            {
                options = "workbook=" + cboWorkBooks.SelectedItem;
                dt = XlsImportHelper.GetData(_filename, cboWorkBooks.SelectedItem.ToString());
            }
            else
            {
                options = "separator=" + cboDelimiter.SelectedItem;
                dt = CsvImportHelper.GetData(_filename, cboDelimiter.Text);
            }

            var tblNew = new Table();
            if (!DbfImportHelper.FillMapWinGisTable(dt, tblNew))
            {
                DialogResult = DialogResult.Cancel;
                return;
            }

            var result = _table.Join2(
                tblNew, cboCurrentKeyCol.Text, cboExternalKeyCol.Text, _filename, options);
            MessageBox.Show(result ? "Joining is successful" : "Joining has failed");
            DialogResult = result ? DialogResult.OK : DialogResult.Cancel;
        }

        /// <summary>
        /// Updates the state of controls depending of the file type
        /// </summary>
        private void UpdateControlsState()
        {
            lblWorkbook.Visible = false;
            cboWorkBooks.Visible = false;
            lblDelimiter.Visible = false;
            cboDelimiter.Visible = false;
            btnGetColumns.Visible = false;
            groupBox1.Enabled = false;

            if (!File.Exists(_filename))
            {
                MessageBox.Show(@"File does not exist.");
                return;
            }

            btnGetColumns.Visible = true;

            var extension = Path.GetExtension(_filename);
            if (extension == ".xls" || extension == ".xlsx")
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
                btnGetColumns.Visible = false;
                MessageBox.Show(@"File type not supported.");
            }
        }

        #endregion
    }
}