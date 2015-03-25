// ********************************************************************************************************
// <copyright file="frmRenameField.cs" company="TopX Geo-ICT">
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
// ********************************************************************************************************

using System;
using System.Data;
using System.Windows.Forms;
using MW5.Plugins.TableEditor.BO;

namespace MW5.Plugins.TableEditor.Forms
{
    /// <summary>
    ///  Form-class for renaming a field
    /// </summary>
    public partial class RenameFieldForm : Form
    {
        /// <summary>The datatable with shape-data</summary> 
        private DataTable dt;

        /// <summary>Initializes a new instance of the frmRenameField class</summary>
        /// <param name = "dataTable">The datatable.</param>
        public RenameFieldForm(DataTable dataTable)
        {
            InitializeComponent();

            this.dt = dataTable;

            string[] names = ShapeData.GetVisibleFieldNames(this.dt);
            cmbField.Items.AddRange(names);
        }

        /// <summary>Enable the OK-button if a field is selected</summary>
        /// <param name = "sender">The sender of the event.</param>
        /// <param name = "e">The arguments.</param>
        private void cmbField_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.btnOK.Enabled = true;
        }

        /// <summary>Change the fieldname</summary>
        /// <param name = "sender">The sender of the event.</param>
        /// <param name = "e">The arguments.</param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            string errorMessage = string.Empty;

            // Check if name is valid
            if (!ShapeData.IsNameValid(txtNewName.Text, this.dt, ref errorMessage))
            {
                MessageBox.Show(errorMessage);
            }
            else
            {
                this.dt.Columns[cmbField.SelectedIndex + 1].ColumnName = txtNewName.Text;
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
