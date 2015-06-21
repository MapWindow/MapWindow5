// -------------------------------------------------------------------------------------------
// <copyright file="QueryBuilderForm.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MW5.Api.Enums;
using MW5.Api.Interfaces;
using MW5.Attributes.Helpers;
using MW5.Attributes.Model;
using MW5.Plugins.Services;
using MW5.UI.Forms;

namespace MW5.Attributes.Forms
{
    public partial class QueryBuilderForm : MapWindowForm
    {
        private const int ColumnIcon = 0;
        private const int ColumnName = 1;
        private readonly ILayer _layer;
        private readonly bool _selectionMode;
        private readonly IFeatureSet _shapefile;
        private readonly string _expression;
        private bool _noEvents;

        /// <summary>
        /// Creates a new instance of frmQueryBuilder class
        /// </summary>
        public QueryBuilderForm(ILayer layer, string expression, bool selectionMode)
        {
            if (layer == null) throw new ArgumentNullException("layer");
            if (layer.FeatureSet == null) throw new ApplicationException("Vector layer is expected.");

            InitializeComponent();

            var sf = layer.FeatureSet;

            _shapefile = sf;
            _layer = layer;
            _selectionMode = selectionMode;
            _expression = expression;

            Initialize();
        }

        private void Initialize()
        {
            btnTest.Text = _selectionMode ? "Select" : "Test";

            InitFieldGrid();

            dgvValues.BorderStyle = BorderStyle.None;

            InitTextBox();
        }

        private void InitTextBox()
        {
            richTextBox1.Text = _expression;
            richTextBox1.HideSelection = false;
            richTextBox1.SelectAll();
            richTextBox1.Focus();
        }

        private void InitFieldGrid()
        {
            fieldTypeGrid1.ShowColumnHeaders = false;
            var list = _shapefile.Fields.Select(f => new FieldTypeWrapper(f)).ToList();
            fieldTypeGrid1.DataSource = list;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        /// <summary>
        /// Updating selection
        /// </summary>
        private void btnOk_Click(object sender, EventArgs e)
        {
            Tag = richTextBox1.Text;

            //SaveSettings();
        }

        private void btnShowValues_Click(object sender, EventArgs e)
        {
            ShowValues();
        }

        private void ShowValues()
        {
            if (fieldTypeGrid1.Adapter.SelectedItem != null)
            {
                //ShowValues(dgvField.CurrentCell.RowIndex);
            }
        }

        /// <summary>
        /// Tests the expression typed by user, showing syntax errors
        /// </summary>
        private void btnTest_Click(object sender, EventArgs e)
        {
            var tbl = _shapefile.Table;
            if (richTextBox1.Text == string.Empty)
            {
                MessageService.Current.Info("No expression is entered");
                return;
            }

            object result = null;
            string err;

            if (!tbl.ParseExpression(richTextBox1.Text, out err))
            {
                return;
            }

            if (tbl.Query(richTextBox1.Text, ref result, ref err))
            {
                lblResult.ForeColor = Color.Green;

                var arr = result as int[];
                if (arr == null) return;

                lblResult.Text = "Number of shapes = " + arr.Length;

                // updating shapefile selection
                if (_selectionMode)
                {
                    // TODO: uncomment
                    //ArrayList options = new ArrayList();
                    //options.Add("1 - New selection");
                    //options.Add("2 - Add to selection");
                    //options.Add("3 - Exclude from selection");
                    //options.Add("4 - Invert in selection");
                    //string s = string.Format("Number of shapes = {0}. Choose the way to update selection", arr.Length);
                    //int option = MapWindow.Controls.Dialogs.ChooseOptions(options, 0, s, "Update selection");

                    //// updating selection
                    //if (option != -1)
                    //{
                    //    // _mapWin.View.UpdateSelection(_layerHandle, ref arr, (SelectionOperation)option);
                    //    // _mapWin.View.Redraw();
                    //}
                }
            }
            else
            {
                if (err.ToLower() == "selection is empty")
                {
                    lblResult.ForeColor = Color.Blue;
                    lblResult.Text = err;
                }
                else
                {
                    lblResult.ForeColor = Color.Red;
                    lblResult.Text = err;
                }
            }
        }

        /// <summary>
        /// Adding operators. The text on the buttons is used.
        /// </summary>
        private void OnOperatorClick(object sender, EventArgs e)
        {
            var btn = sender as Button;
            if (btn != null)
            {
                richTextBox1.SelectedText = btn.Text + " ";
            }
        }

        /// <summary>
        /// Warning while turning on the mode.
        /// </summary>
        private void chkShowDynamically_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowDynamically.Checked)
            {
                MessageService.Current.Info(
                    "Dynamic selection mode was turned on.\nThe selection will be changed after each click\n on the value to show corresponding objects.");
            }
        }

        /// <summary>
        /// Toggles between automatic and manual showing of the unique values
        /// </summary>
        private void chkShowValues_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowValues.Checked)
            {
                ShowValues();
            }
        }

        /// <summary>
        /// Builds a list of unique values
        /// </summary>
        private void dgvField_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
        }

        private void dgvField_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex < 0) return;
            //richTextBox1.SelectedText = "[" + dgvField[ColumnName, e.RowIndex].Value + "] ";
        }

        private void dgvValues_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            richTextBox1.SelectedText = dgvValues[1, e.RowIndex].Value + " ";
        }

        /// <summary>
        /// Changing selection while in dynamic mode
        /// </summary>
        private void dgvValues_SelectionChanged(object sender, EventArgs e)
        {
            if (_noEvents || !chkShowDynamically.Checked)
            {
                return;
            }

            if (dgvField.SelectedRows.Count == 0 || dgvValues.SelectedRows.Count == 0) return;

            var expr = "[" + dgvField[ColumnName, dgvField.SelectedRows[0].Index].Value + "] = ";
            expr += dgvValues[1, dgvValues.SelectedRows[0].Index].Value.ToString();

            object result = null;
            string errorMessage = string.Empty;

            if (_shapefile.Table.Query(expr, ref result, ref errorMessage))
            {
                var arr = result as int[];

                if (arr != null)
                {
                    _layer.UpdateSelection(arr.ToList(), SelectionOperation.New);
                }
            }
        }
    }
}