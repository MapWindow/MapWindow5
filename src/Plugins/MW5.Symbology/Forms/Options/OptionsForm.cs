// ********************************************************************************************************
// <copyright file="MWLite.Symbology.cs" company="MapWindow.org">
// Copyright (c) MapWindow.org. All rights reserved.
// </copyright>
// The contents of this file are subject to the Mozilla Public License Version 1.1 (the "License"); 
// you may not use this file except in compliance with the License. You may obtain a copy of the License at 
// http:// Www.mozilla.org/MPL/ 
// Software distributed under the License is distributed on an "AS IS" basis, WITHOUT WARRANTY OF 
// ANY KIND, either express or implied. See the License for the specificlanguage governing rights and 
// limitations under the License. 
// 
// The Initial Developer of this version of the Original Code is Sergei Leschinski
// 
// Contributor(s): (Open source contributors should list themselves and their modifications here). 
// Change Log: 
// Date            Changed By      Notes
// ********************************************************************************************************

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MW5.UI;
using MW5.UI.Forms;

namespace MW5.Plugins.Symbology.Forms.Options
{
    /// <summary>
    /// Shows a list of options to choose from
    /// </summary>
    public partial class OptionsForm : MapWindowForm
    {
        private readonly List<string> _options = null;
        private readonly List<bool> _states = null;
        
        /// <summary>
        /// Creates a new instance of frmOptions class
        /// </summary>
        public OptionsForm(List<string> options, List<bool> states, string caption, string text)
        {
            InitializeComponent();
            if (options.Count != states.Count)
            {
                throw new ApplicationException("Invalid lenth of the list.");
            }

            if (options.Count == 0)
            {
                throw new ApplicationException("Invalid lenth of the list.");
            }

            _options = options;
            _states = states;

            Text = caption;
            lblText.Text = text;

            FillGrid();

            if (_options.Count > 8 && _options.Count <= 20)
                Height += (_options.Count - 8) * grid.Rows[0].Height;
            else
                Height += 12 * grid.Rows[0].Height;
        }
        
        /// <summary>
        /// Fills grid with options form the list
        /// </summary>
        private void FillGrid()
        {
            grid.Rows.Clear();
            if (_options.Count > 0)
            {
                grid.Rows.Add(_options.Count);

                for (int i = 0; i < _options.Count; i++)
                {
                    grid[0, i].Value = _states[i];
                    grid[1, i].Value = _options[i];
                }
            }
        }

        /// <summary>
        /// Committing changes of the checkbox state immediately, CellValueChanged event won't be triggered otherwise
        /// </summary>
        private void grid_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (grid.CurrentCell.ColumnIndex == 0)
            {
                if (grid.IsCurrentCellDirty)
                {
                    grid.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
            }
        }

        /// <summary>
        /// Saves the values of the checkboxes
        /// </summary>
        private void btnOk_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < _states.Count; i++)
            {
                _states[i] = (bool)grid[0, i].Value;
            }
        }

        /// <summary>
        /// Prhibits editing of the name column
        /// </summary>
        private void grid_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == 1)
                e.Cancel = true;
        }

        /// <summary>
        /// Selects or deselects all the options
        /// </summary>
        private void chkToggleAll_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < grid.Rows.Count; i++ )
                grid[0, i].Value = chkToggleAll.Checked;
        }
    }
}
