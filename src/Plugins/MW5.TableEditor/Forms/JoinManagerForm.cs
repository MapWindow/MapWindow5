// ********************************************************************************************************
// <copyright file="frmJoinManager.cs" company="TopX Geo-ICT">
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
using System.Data;
using System.Windows.Forms;
using MapWinGIS;

namespace MW5.Plugins.TableEditor.Forms
{
  #region

    

    #endregion

  /// <summary>
  /// The frm join manager.
  /// </summary>
  public partial class JoinManagerForm : Form
  {
    #region Constants and Fields

    /// <summary>
    /// The dt.
    /// </summary>
    private readonly DataTable dt;

    /// <summary>
    /// The table.
    /// </summary>
    private readonly Table table;

    #endregion

    #region Constructors and Destructors

    /// <summary>
    /// Initializes a new instance of the <see cref="JoinManagerForm"/> class. 
    /// Creates a new instance of the frmJoinManager class
    /// </summary>
    /// <param name="dt">
    /// The dt.
    /// </param>
    /// <param name="tbl">
    /// The tbl.
    /// </param>
    public JoinManagerForm(DataTable dt, Table tbl)
    {
      this.InitializeComponent();
      this.table = tbl;
      this.dt = dt;
      this.UpdateList();
    }

    #endregion

    #region Methods

    /// <summary>
    /// Opens form to edit selected join
    /// </summary>
    private void EditJoin()
    {
      if (this.listView1.SelectedItems.Count != 1)
      {
        MessageBox.Show(@"Select a datasource", @"Table editor", MessageBoxButtons.OK, MessageBoxIcon.Information);
      }
      else
      {
        var index = this.listView1.SelectedIndices[0];
        var filename = this.table.get_JoinFilename(index);
        if (filename.ToLower().EndsWith(".dbf"))
        {
          var form = new JoinNativeForm(this.dt, this.table, filename, index);
          form.ShowDialog(this);
          this.UpdateList();
        }
        else
        {
          MessageBox.Show(
            @"Editing unavailable for this data source", @"Table editor", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
      }
    }

    /// <summary>
    /// Updates state of the buttons after user actions
    /// </summary>
    private void UpdateControls()
    {
      this.btnStop.Enabled = this.listView1.SelectedItems.Count != 0;
      this.btnEditJoin.Enabled = this.listView1.SelectedItems.Count != 0;
      this.btnStopAll.Enabled = this.listView1.Items.Count > 0;
    }

    /// <summary>
    /// Fills the listview with joins
    /// </summary>
    private void UpdateList()
    {
      this.listView1.Items.Clear();
      for (var i = 0; i < this.table.JoinCount; i++)
      {
        var item = this.listView1.Items.Add(this.table.get_JoinFilename(i));
        item.SubItems.Add(this.table.get_JoinFromField(i));
        item.SubItems.Add(this.table.get_JoinToField(i));
        item.Selected = true;
      }

      if (this.listView1.Items.Count > 0)
      {
        this.listView1.Items[0].Selected = true;
      }

      this.UpdateControls();
    }

    /// <summary>
    /// Opens form to edit selected join
    /// </summary>
    /// <param name="sender">
    /// The sender.
    /// </param>
    /// <param name="e">
    /// The e.
    /// </param>
    private void BtnEditJoinClick(object sender, EventArgs e)
    {
      this.EditJoin();
    }

    /// <summary>
    /// Opens form to create a new join
    /// </summary>
    /// <param name="sender">
    /// The sender.
    /// </param>
    /// <param name="e">
    /// The e.
    /// </param>
    private void BtnJoinClick(object sender, EventArgs e)
    {
      var dialog = new OpenFileDialog
        {
          Filter = @"Dbf tables (*.dbf)|*.dbf|Excel workbooks (*.xls, *.xlsx)|*.xls;*.xlsx|CSV files (*.csv)|*.csv", 
          FilterIndex = 0
        };

      if (dialog.ShowDialog() == DialogResult.OK)
      {
        if (dialog.FileName.ToLower().EndsWith(".dbf"))
        {
          var form = new JoinNativeForm(this.dt, this.table, dialog.FileName, -1);
          form.ShowDialog(this);
        }
        else
        {
          var form = new JoinExcelForm(this.dt, this.table, dialog.FileName, -1);
          form.ShowDialog(this);
        }

        this.UpdateList();
      }
    }

    /// <summary>
    /// Stops all join operations
    /// </summary>
    /// <param name="sender">
    /// The sender.
    /// </param>
    /// <param name="e">
    /// The e.
    /// </param>
    private void BtnStopAllClick(object sender, EventArgs e)
    {
      this.table.StopAllJoins();
      MessageBox.Show(@"All joins are stopped", @"Table editor", MessageBoxButtons.OK, MessageBoxIcon.Information);
      this.UpdateList();
    }

    /// <summary>
    /// Stops the selected join
    /// </summary>
    /// <param name="sender">
    /// The sender.
    /// </param>
    /// <param name="e">
    /// The e.
    /// </param>
    private void BtnStopClick(object sender, EventArgs e)
    {
      if (this.listView1.SelectedItems.Count != 1)
      {
        MessageBox.Show(@"Select a datasource", @"Table editor", MessageBoxButtons.OK, MessageBoxIcon.Information);
      }
      else
      {
        var index = this.listView1.SelectedIndices[0];
        var name = this.table.get_JoinFilename(index);
        if (this.table.StopJoin(index))
        {
          MessageBox.Show(@"Join is stopped: " + name, @"Table editor", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        this.UpdateList();
      }
    }

    /// <summary>
    /// Opens editing form
    /// </summary>
    /// <param name="sender">
    /// The sender.
    /// </param>
    /// <param name="e">
    /// The e.
    /// </param>
    private void ListView1MouseDoubleClick(object sender, MouseEventArgs e)
    {
      var info = this.listView1.HitTest(e.Location);
      if (info.Item != null)
      {
        this.EditJoin();
      }
    }

    /// <summary>
    /// Updates buttons
    /// </summary>
    /// <param name="sender">
    /// The sender.
    /// </param>
    /// <param name="e">
    /// The e.
    /// </param>
    private void ListView1SelectedIndexChanged(object sender, EventArgs e)
    {
      this.UpdateControls();
    }

    #endregion
  }
}