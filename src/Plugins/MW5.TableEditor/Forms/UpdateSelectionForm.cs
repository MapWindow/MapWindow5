// ********************************************************************************************************
// <copyright file="frmUpdateSelection.cs" company="TopX Geo-ICT">
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
using System.Windows.Forms;
using MW5.Api;

namespace MW5.Plugins.TableEditor.Forms
{
    /// <summary>
    ///  Form-class for updating a selection
    /// </summary>
    public partial class UpdateSelectionForm : Form
    {
        /// <summary>Initializes a new instance of the frmUpdateSelection class</summary>
        /// <param name = "numShapes">The amount of shapefile.</param>
        public UpdateSelectionForm(int numShapes)
        {
            InitializeComponent();

            lblNumOfShapes.Text = string.Format("Number of shapes = {0}", numShapes);

            this.FillOptions();
        }

        /// <summary>Gets the selected operation</summary>
        public SelectionOperation selectedOption
        {
            get
            {
                return (SelectionOperation)lbOptions.SelectedIndex;
            }
        }

        /// <summary>Fill the operation-options in the control</summary>
        private void FillOptions()
        {
            lbOptions.Items.Add("1 - New selection");
            lbOptions.Items.Add("2 - Add to selection");
            lbOptions.Items.Add("3 - Exclude from selection");
            lbOptions.Items.Add("4 - Invert in selection");
        }

        /// <summary>Performs the operation</summary>
        /// <param name = "sender">The sender of the event.</param>
        /// <param name = "e">The arguments.</param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (lbOptions.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an option.");
            }
            else
            {
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
