// ********************************************************************************************************
// <copyright file="frmNewField.cs" company="TopX Geo-ICT">
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
    ///  Form-class for adding a new field
    /// </summary>
    public partial class NewFieldForm : Form
    {
        /// <summary>The datatable with shapedata</summary>
        private DataTable dt;

        /// <summary>Initializes a new instance of the frmNewField class</summary>
        /// <param name = "dataTable">The datatable.</param>
        public NewFieldForm(DataTable dataTable)
        {
            InitializeComponent();
            this.dt = dataTable;
        }

        /// <summary>Add the new field</summary>
        /// <param name = "sender">The sender of the event.</param>
        /// <param name = "e">The arguments.</param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            string errorMessage = string.Empty;

            if (!ShapeData.IsNameValid(txtFieldName.Text, this.dt, ref errorMessage))
            {
                MessageBox.Show(errorMessage);
                this.DialogResult = DialogResult.Cancel;
                return;
            }

            ShapeData.AddDataColumn(this.dt, txtFieldName.Text, cmbFieldType.Text
              , fldPrecision.Value.ToString(), Convert.ToInt32(fldWidth.Value));
            this.DialogResult = DialogResult.OK;
        }

        /// <summary>Enable the control Precision if fieldtype 'double' is selected</summary>
        /// <param name = "sender">The sender of the event.</param>
        /// <param name = "e">The arguments.</param>
        private void cmbFieldType_SelectedIndexChanged(object sender, EventArgs e)
        {
            fldPrecision.Enabled = cmbFieldType.Text == "Double";
            lblPrecision.Enabled = cmbFieldType.Text == "Double";
        }
    }
}
