// ********************************************************************************************************
// <copyright file="frmDeleteField.cs" company="TopX Geo-ICT">
//     Copyright (c) 201 TopX Geo-ICT. All rights reserved.
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
// ********************************************************************************************************

using System;
using System.Data;
using System.Windows.Forms;
using MW5.Plugins.TableEditor.BO;

namespace MW5.Plugins.TableEditor.Forms
{
    /// <summary>
    ///  Form-class for deleting a field
    /// </summary>
    public partial class DeleteFieldForm : Form
    {
        /// <summary>The datatable</summary>
        private DataTable dataTable;

        /// <summary>Initializes a new instance of the frmDeleteField class</summary>
        /// <param name = "dt">The datatable.</param>
        public DeleteFieldForm(DataTable dt)
        {
            this.InitializeComponent();

            this.dataTable = dt;

            string[] names = ShapeData.GetVisibleFieldNames(dt);
            this.clb.Items.AddRange(names);
        }

        /// <summary>Set status of field to deleted</summary>
        /// <param name = "sender">The sender of the event.</param>
        /// <param name = "e">The arguments.</param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.clb.Items.Count; i++)
            {
                if (this.clb.GetItemChecked(i))
                {
                    this.dataTable.Columns[i + 1].ExtendedProperties["removed"] = true;
                }
            }

            this.DialogResult = DialogResult.OK;
        }

        /// <summary>Enable btnOk if fields are checked for deleting</summary>
        /// <param name = "sender">The sender of the event.</param>
        /// <param name = "e">The arguments.</param>
        private void clb_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            this.btnOK.Enabled = this.clb.SelectedItems.Count > 0;
        }
    }
}
