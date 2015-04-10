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
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MW5.Api;
using MW5.Api.Enums;
using MW5.Api.Interfaces;
using MW5.Plugins.Symbology.Services;
using MW5.UI;
using MW5.UI.Forms;

namespace MW5.Plugins.Symbology.Forms.Categories
{
    public partial class QueryBuilderForm : MapWindowForm
    {
        private const int CMN_ICON = 0;
        private const int CMN_NAME = 1;

        private readonly IFeatureSet _shapefile;
        private readonly int _layerHandle;
        private readonly ILayer _layer;
        private readonly bool _selectionMode;
        private readonly SymbologyMetadata _metadata;
        private bool _noEvents;

        /// <summary>
        /// Creates a new instance of frmQueryBuilder class
        /// </summary>
        public QueryBuilderForm(ILayer layer, string expression, bool selectionMode)
        {
            if (layer == null || layer.FeatureSet == null)
            {
                throw new ArgumentNullException("layer");
            }

            InitializeComponent();

            var sf = layer.FeatureSet;

            _shapefile = sf;
            _layer = layer;
            _selectionMode = selectionMode;
            _metadata = SymbologyPlugin.Metadata(layer.Handle);
            _layerHandle = layer.Handle;

            btnTest.Text = selectionMode ? "Select" : "Test";

            dgvField.BorderStyle = BorderStyle.None;
            dgvValues.BorderStyle = BorderStyle.None;
            dgvField.Rows.Clear();
            dgvField.Rows.Add(_shapefile.Table.Fields.Count);

            for (int i = 0; i < _shapefile.Fields.Count; i++)
            {
                dgvField[CMN_NAME, i].Value = _shapefile.Fields[i].Name;
                if (_shapefile.Fields[i].Type == AttributeType.String)
                {
                    dgvField[CMN_ICON, i].Value = "Aa";
                    dgvField[CMN_ICON, i].Style.ForeColor = Color.Maroon;
                }
                else
                {
                    dgvField[CMN_ICON, i].Value = "09";
                    //dgvField[CMN_ICON, i].Style.ForeColor = Color.Blue;
                }
            }

            if (dgvField.Rows.Count > 0)
            {
                // TODO: show unique values    
            }
            richTextBox1.Text = expression;
            richTextBox1.HideSelection = false;
            richTextBox1.SelectAll();
            richTextBox1.Focus();

            if (chkShowValues.Checked)
            {
                ShowValues(0);
            }

            _noEvents = true;

            // restoring values
            chkShowValues.Checked = _metadata.ShowQueryValues;
            chkShowDynamically.Checked = _metadata.ShowQueryOnMap;

            _noEvents = false;
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
            if (chkShowValues.Checked)
            {
                ShowValues(e.RowIndex);
            }
        }

        /// <summary>
        /// Showing values
        /// </summary>
        private void ShowValues(int fieldIndex)
        {
            _noEvents = true;
            dgvValues.Rows.Clear();

            if (_shapefile.Fields.Count - 1 < fieldIndex)
            {
                _noEvents = false;
                return;
            }

            var tbl = _shapefile.Table;
            object obj = null;
            SortedDictionary<object, int> hashTable = new SortedDictionary<object, int>();

            bool isString = (_shapefile.Fields[fieldIndex].Type == AttributeType.String);

            if (true)
            {
                Cursor = Cursors.WaitCursor;

                for (int i = 0; i < tbl.NumRows; i++)
                {
                    obj = tbl.CellValue(fieldIndex, i);
                    if (hashTable.ContainsKey(obj))
                    {
                        hashTable[obj] += 1;
                    }
                    else
                    {
                        hashTable.Add(obj, 1);
                    }
                }
                int[] values = hashTable.Values.ToArray();
                object[] keys = hashTable.Keys.ToArray();

                dgvValues.Rows.Add(values.Length);
                for (int i = 0; i < values.Length; i++)
                {
                    if (isString)
                    {
                        dgvValues[1, i].Value = "\"" + keys[i].ToString() + "\"";
                    }
                    else
                    {
                        dgvValues[1, i].Value = keys[i].ToString();
                    }
                    dgvValues[0, i].Value = values[i];
                }

                this.Cursor = Cursors.Default;
            }
            else
            {
                // field stats: aren't used currently
                // for numeric fields we shall provide statistics
                dgvValues.Rows.Add(7);
                dgvValues[0, 0].Value = "Avg";
                dgvValues[0, 1].Value = "StDev";
                dgvValues[0, 2].Value = "0%";
                dgvValues[0, 3].Value = "25%";
                dgvValues[0, 4].Value = "50%";
                dgvValues[0, 5].Value = "75%";
                dgvValues[0, 6].Value = "100%";

                List<object> list = new List<object>();
                for (int i = 0; i < tbl.NumRows; i++)
                {
                    list.Add((object)tbl.CellValue(fieldIndex, i));
                }
                list.Sort();

                int quater = list.Count / 4;
                for (int i = 0; i < list.Count; i++)
                {
                    if (i == quater)
                    {
                        dgvValues[1, 3].Value = list[i];
                    }
                    else if (i == quater * 2)
                    {
                        dgvValues[1, 4].Value = list[i];
                    }
                    else if (i == quater * 3)
                    {
                        dgvValues[1, 5].Value = list[i];
                    }
                }

                //dgvValues[1, 0].Value = (float)tbl.get_MeanValue(FieldIndex);
                //dgvValues[1, 1].Value = (float)tbl.get_StandardDeviation(FieldIndex);
                //dgvValues[1, 2].Value = tbl.get_MinValue(FieldIndex);
                //dgvValues[1, 6].Value = tbl.get_MaxValue(FieldIndex);
            }

            dgvValues.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            _noEvents = false;
        }

        /// <summary>
        /// Tests the expression typed by user, showing syntax errors
        /// </summary>
        private void btnTest_Click(object sender, EventArgs e)
        {
            var tbl = _shapefile.Table;
            if (richTextBox1.Text == string.Empty)
            {
                SymbologyPlugin.Msg.Info("No expression is entered");
                return;
            }
            
            object result = null;
            string err = string.Empty;

            if (!tbl.ParseExpression(richTextBox1.Text, ref err))
            {
                return;
            }
            
            if (tbl.Query(richTextBox1.Text, ref result, ref err))
            {
                lblResult.ForeColor = Color.Green;
                int[] arr = result as int[];
                if (arr != null)
                {
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
        /// Updating selection
        /// </summary>
        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Tag = richTextBox1.Text;
            var settings = SymbologyPlugin.Metadata(_layer.Handle);
            settings.ShowQueryValues = chkShowValues.Checked;
            settings.ShowQueryOnMap = chkShowDynamically.Checked;
        }

        // Adding field to the text control
        private void dgvField_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            richTextBox1.SelectedText = "[" + dgvField[CMN_NAME, e.RowIndex].Value + "] ";
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
        /// Adding operators. The text on the buttons is used
        /// </summary>
        private void button0_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            if (btn != null)
            {
                richTextBox1.SelectedText = btn.Text + " ";
            }
        }

        /// <summary>
        /// Warning while turning on the mode
        /// </summary>
        private void chkShowDynamically_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowDynamically.Checked)
            {
                //SymbologyPlugin.Msg.Info("Dynamic selection mode was turned on.\nThe selection will be changed after each click\n on the value to show corresponding objects.");
            }
        }

        /// <summary>
        /// Changing selection while in dynamic mode
        /// </summary>
        private void dgvValues_SelectionChanged(object sender, EventArgs e)
        {
            if (_noEvents)
            {
                return;
            }

            if (!chkShowDynamically.Checked)
            {
                return;
            }

            if (dgvField.SelectedRows.Count != 0 && dgvValues.SelectedRows.Count != 0)
            {
                var expr = "[" + dgvField[CMN_NAME, dgvField.SelectedRows[0].Index].Value + "] = ";
                expr += dgvValues[1, dgvValues.SelectedRows[0].Index].Value.ToString();

                object result = null;
                string errorMessage = string.Empty;
                if (_shapefile.Table.Query(expr, ref result, ref errorMessage))
                {
                    int[] arr = result as int[];

                    if (arr != null)
                    {
                        _layer.UpdateSelection(arr.ToList(), SelectionOperation.New);
                    }
                }
            }
        }

        /// <summary>
        /// Clear the expression
        /// </summary>
        private void btnClear_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        // Shows the list of unique values
        private void btnShowValues_Click(object sender, EventArgs e)
        {
            if (dgvField.CurrentCell != null)
            {
                ShowValues(dgvField.CurrentCell.RowIndex);
            }
        }

        /// <summary>
        /// Toggles between automatic and manual showing of the unique values
        /// </summary>
        private void chkShowValues_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowValues.Checked)
            {
                if (dgvField.CurrentCell != null)
                {
                    ShowValues(dgvField.CurrentCell.RowIndex);
                }
            }
        }
    }
}
