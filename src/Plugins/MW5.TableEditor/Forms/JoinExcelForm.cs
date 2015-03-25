// ********************************************************************************************************
// <copyright file="frmJoinExcel.cs" company="TopX Geo-ICT">
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
// The Initial Developer of this version is Sergei Leschinsky.
// 
// Contributor(s): (Open source contributors should list themselves and their modifications here). 
// Change Log: 
// Date           Changed By           Notes
// 3 Sept. 2012   Sergei Leschinsky    Inital coding
// 31 May 2013    Paul Meems           Made the source code Style-cop compliant
// ********************************************************************************************************

using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using MapWinGIS;
using MW5.Plugins.TableEditor.utils;

namespace MW5.Plugins.TableEditor.Forms
{
  #region

    

    #endregion

  /// <summary>
  /// The frm join excel.
  /// </summary>
  public partial class JoinExcelForm : Form
  {
    #region Constants and Fields

    /// <summary>
    /// The filename.
    /// </summary>
    private readonly string filename = string.Empty;

    /// <summary>
    /// The table.
    /// </summary>
    private readonly Table table; // underlying dbf of current shapefile

    #endregion

    #region Constructors and Destructors

    /// <summary>
    /// Initializes a new instance of the <see cref="JoinExcelForm"/> class. 
    /// Initializes a new instance of the frmJoinExtData class
    /// </summary>
    /// <param name="dt">
    /// The datatable.
    /// </param>
    /// <param name="tbl">
    /// The tbl.
    /// </param>
    /// <param name="filename">
    /// The filename.
    /// </param>
    /// <param name="joinId">
    /// The join Id.
    /// </param>
    public JoinExcelForm(DataTable dt, Table tbl, string filename, int joinId)
    {
      this.InitializeComponent();

      this.table = tbl;
      this.filename = filename;

      this.FillCurrentKeyColumns();

      this.UpdateControlsState();

      this.Text = @"Joining file: " + filename;
    }

    #endregion

    #region Methods

    /// <summary>
    /// Fill combobox with fields from shape
    /// </summary>
    private void FillCurrentKeyColumns()
    {
      var names = new List<string>();
      
      for (var i = 0; i < this.table.NumFields; i++)
      {
        names.Add(this.table.get_Field(i).Name);
      }

      this.cboCurrentKeyCol.DataSource = names;
    }

    /// <summary>
    /// Fill combobox with workbooks
    /// </summary>
    private void FillWorkBooks()
    {
      // Get workbooks
      var books = XLSImport.GetWorkbooks(this.filename);
      this.cboWorkBooks.DataSource = books.Distinct().ToList();
        
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
      if (this.cboWorkBooks.Visible)
      {
        var colNames = XLSImport.GetColumnNames(this.filename, this.cboWorkBooks.SelectedItem.ToString());

        this.cboExternalKeyCol.DataSource = colNames;

        this.groupBox1.Enabled = true;
      }
      else
      {
        if (this.cboDelimiter.Text == string.Empty)
        {
          MessageBox.Show(@"No delimiter selected.");
          return;
        }
        
        var colNames = CSVImport.GetColumnNames(this.filename, this.cboDelimiter.Text);

        this.cboExternalKeyCol.DataSource = colNames;

        this.groupBox1.Enabled = true;
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
        return;
      }
      
      DataTable dt;
      string options;

      if (this.cboWorkBooks.Visible)
      {
        options = "workbook=" + this.cboWorkBooks.SelectedItem;
        dt = XLSImport.GetData(this.filename, this.cboWorkBooks.SelectedItem.ToString());
      }
      else
      {
        options = "separator=" + this.cboDelimiter.SelectedItem;
        dt = CSVImport.GetData(this.filename, this.cboDelimiter.Text);
      }

      var tblNew = new Table();
      if (!DbfImport.FillMapWinGisTable(dt, tblNew))
      {
        this.DialogResult = DialogResult.Cancel;
        return;
      }

      var result = this.table.Join2(
        tblNew, this.cboCurrentKeyCol.Text, this.cboExternalKeyCol.Text, this.filename, options);
      MessageBox.Show(result ? "Joining is successful" : "Joining has failed");
      this.DialogResult = result ? DialogResult.OK : DialogResult.Cancel;
    }

    /// <summary>
    /// Updates the state of controls depending of the file type
    /// </summary>
    private void UpdateControlsState()
    {
      this.lblWorkbook.Visible = false;
      this.cboWorkBooks.Visible = false;
      this.lblDelimiter.Visible = false;
      this.cboDelimiter.Visible = false;
      this.btnGetColumns.Visible = false;
      this.groupBox1.Enabled = false;

      if (!File.Exists(this.filename))
      {
        MessageBox.Show(@"File does not exist.");
        return;
      }
      
      this.btnGetColumns.Visible = true;

      var extension = Path.GetExtension(this.filename);
      if (extension == ".xls" || extension == ".xlsx")
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
        this.btnGetColumns.Visible = false;
        MessageBox.Show(@"File type not supported.");
      }
    }

    #endregion
  }
}