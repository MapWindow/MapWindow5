// -------------------------------------------------------------------------------------------
// <copyright file="CheckBoxForm.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MW5.UI.Forms
{
    /// <summary>
    /// Shows a list of options to choose from
    /// </summary>
    internal partial class CheckBoxForm : MapWindowForm
    {
        private readonly List<string> _options;
        private readonly List<bool> _states;

        /// <summary>
        /// Creates a new instance of frmOptions class
        /// </summary>
        public CheckBoxForm(List<string> options, List<bool> states, string caption, string text)
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

            if (_options.Count > 8 && _options.Count <= 20) Height += (_options.Count - 8) * grid.Rows[0].Height;
            else Height += 12 * grid.Rows[0].Height;
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
        /// Selects or deselects all the options
        /// </summary>
        private void chkToggleAll_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < grid.Rows.Count; i++)
            {
                grid[0, i].Value = chkToggleAll.Checked;
            }
        }

        /// <summary>
        /// Prhibits editing of the name column
        /// </summary>
        private void grid_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == 1) e.Cancel = true;
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

        private void CheckBoxForm_Load(object sender, EventArgs e)
        {
            // Fixing CORE-160
            CaptionFont = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
        }
    }
}