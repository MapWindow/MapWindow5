// ********************************************************************************************************
// <copyright file="frmImportExtData.cs" company="TopX Geo-ICT">
//     Copyright (c) 2012 TopX Geo-ICT. All rights reserved.
// </copyright>
// ********************************************************************************************************
// The contents of this file are subject to the Mozilla Public License Version 1.1 (the "License"); 
// you may not use this file except in compliance with the License. You may obtain a copy of the License at 
// http:// www.mozilla.org/MPL/ 
// Software distributed under the License is distributed on an "AS IS" basis, WITHOUT WARRANTY OF 
// ANY KIND, either express or implied. See the License for the specificlanguage governing rights and 
// limitations under the License. 
// 
// The Initial Developer of this version is Jeen de Vegt.
// 
// Contributor(s): (Open source contributors should list themselves and their modifications here). 
// Change Log: 
// Date           Changed By      Notes
// 29 March 2012  Jeen de Vegt    Inital coding
// 31 May 2013    Paul Meems      Made the source code Style-cop compliant
// ********************************************************************************************************

using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using MW5.Plugins.TableEditor.BO;
using MW5.Plugins.TableEditor.utils;

namespace MW5.Plugins.TableEditor.Forms
{
  #region

    

    #endregion

  /// <summary>
  /// Form-class for joining with external data
  /// </summary>
  public partial class ImportExtDataForm : Form
  {
    #region Constants and Fields

    /// <summary>
    ///   Filter for the filetypes to import from
    /// </summary>
    private const string OpenFileFilter = "Excel Files (*.xls)|*.xls|CSV Files (*.csv)|*.csv|All Files|*.*";

    // private const string OpenFileFilter = "Excel Files (*.xls)|*.xls|Open Office Files (*.ods)|*.ods|CSV Files (*.csv)|*.csv|All Files|*.*";

    /// <summary>
    ///   The shapedata
    /// </summary>
    private readonly DataTable shapeData;

    #endregion

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
      this.InitializeComponent();

      this.shapeData = dt;

      this.FillCurrentKeyColumns(dt);
    }

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
      this.cboCurrentKeyCol.DataSource = ShapeData.GetVisibleFieldNames(dt);
    }

    /// <summary>
    /// Fill combobox with workbooks
    /// </summary>
    private void FillWorkBooks()
    {
      // Get workbooks
      var books = XLSImport.GetWorkbooks(this.txtInputFile.Text);

      this.cboWorkBooks.DataSource = books;
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

      if (this.cboWorkBooks.Visible)
      {
        importedData = XLSImport.GetData(this.txtInputFile.Text, this.cboWorkBooks.SelectedItem.ToString());
      }
      else
      {
        importedData = CSVImport.GetData(this.txtInputFile.Text, this.cboDelimiter.Text);
      }

      for (var i = 0; i < importedData.Columns.Count; i++)
      {
        var dc = importedData.Columns[i];
        var addColumn = true;

        foreach (DataColumn dataColumn in this.shapeData.Columns)
        {
          if (dataColumn.ColumnName.PadRight(10).Substring(0, 10) == dc.ColumnName.PadRight(10).Substring(0, 10))
          {
            MessageBox.Show(
              string.Format(
                "Column {0} already exists. Column will be skipped", dc.ColumnName.PadRight(10).Substring(0, 10)));
            addColumn = false;
          }
        }

        // to be changed in next version? Set length default to 50
        if (addColumn)
        {
          ShapeData.AddDataColumn(this.shapeData, importedData.Rows[0][i].ToString(), "String", "0", 50);
        }
      }

      for (var i = 0; i < this.shapeData.Rows.Count; i++)
      {
        var currentKeyValue = this.shapeData.Rows[i][this.cboCurrentKeyCol.SelectedItem.ToString()].ToString();

        var searchString = string.Format("{0} = '{1}'", this.cboExternalKeyCol.SelectedItem, currentKeyValue);
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

            foreach (DataColumn dataColumn in this.shapeData.Columns)
            {
              if (dataColumn.ColumnName.PadRight(10).Substring(0, 10)
                  == importedData.Columns[j].ColumnName.PadRight(10).Substring(0, 10))
              {
                addColumn = false;
              }
            }

            if (addColumn)
            {
              this.shapeData.Rows[i][importedData.Columns[j].ColumnName] =
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
      if (this.cboWorkBooks.Visible)
      {
        var colNames = XLSImport.GetColumnNames(this.txtInputFile.Text, this.cboWorkBooks.SelectedItem.ToString());

        this.cboExternalKeyCol.DataSource = colNames;

        this.groupBox1.Enabled = true;
      }
      else
      {
        if (this.cboDelimiter.Text == string.Empty)
        {
          MessageBox.Show(@"No delimiter selected.");
        }
        else
        {
          var colNames = CSVImport.GetColumnNames(this.txtInputFile.Text, this.cboDelimiter.Text);

          this.cboExternalKeyCol.DataSource = colNames;

          this.groupBox1.Enabled = true;
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
      var ofd = new OpenFileDialog { Filter = OpenFileFilter };

      if (ofd.ShowDialog() == DialogResult.OK)
      {
        this.txtInputFile.Text = ofd.FileName;
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
      if (this.cboExternalKeyCol.SelectedItem == null || this.cboExternalKeyCol.SelectedItem.ToString() == string.Empty)
      {
        MessageBox.Show(@"Please select key columns.");
      }
      else
      {
        var importSuccess = this.ImportData();

        if (importSuccess)
        {
          this.Close();
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
      this.lblWorkbook.Visible = false;
      this.cboWorkBooks.Visible = false;
      this.lblDelimiter.Visible = false;
      this.cboDelimiter.Visible = false;
      this.btnGetColumns.Visible = false;
      this.groupBox1.Enabled = false;

      if (!File.Exists(this.txtInputFile.Text))
      {
        MessageBox.Show(@"File does not exist.");
      }
      else
      {
        // groupBox1.Enabled = true;
        this.btnGetColumns.Visible = true;

        var extension = Path.GetExtension(this.txtInputFile.Text);

        // if (extension == ".xls" || extension == ".ods")
        if (extension == ".xls")
        {
          this.lblWorkbook.Visible = true;
          this.cboWorkBooks.Visible = true;

          this.FillWorkBooks();
        }
        else if (extension == ".csv")
        {
          this.lblDelimiter.Visible = true;
          this.cboDelimiter.Visible = true;
        }
        else
        {
          // groupBox1.Enabled = false;
          this.btnGetColumns.Visible = false;
          MessageBox.Show(@"File type not supported.");
        }
      }
    }
    #endregion
  }
}