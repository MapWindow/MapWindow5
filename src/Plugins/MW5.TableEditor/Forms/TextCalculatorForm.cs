// ********************************************************************************************************
// <copyright file="frmTextCalculator.cs" company="TopX Geo-ICT">
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
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using MW5.Plugins.TableEditor.BO;

namespace MW5.Plugins.TableEditor.Forms
{
    /// <summary>
    ///  Form-class for textcalculator
    /// </summary>
    public partial class TextCalculatorForm : Form
    {
        /// <summary>The gridview with shape-data</summary> 
        private readonly DataGridView dataGridView;

        /// <summary>Initializes a new instance of the frmTextCalculator class</summary>
        /// <param name = "gridView">The gridview.</param>
        /// <param name="selectedColumnIndex">The index of the selected Column</param>
        public TextCalculatorForm(DataGridView gridView, int selectedColumnIndex)
        {
            InitializeComponent();

            this.dataGridView = gridView;

            this.InitializeFieldValues((DataTable)gridView.DataSource, selectedColumnIndex);
        }

        /// <summary>Initializes the controls on the form</summary>
        /// <param name = "dt">The datatable.</param>
        /// <param name="selectedColumnIndex">The index of the selected Column</param>
        private void InitializeFieldValues(DataTable dt, int selectedColumnIndex)
        {
            Fields_lb.Items.Clear();

            string[] columnNames = ShapeData.GetVisibleFieldNames(dt);
            foreach (string colName in columnNames)
            {
                Fields_lb.Items.Add(colName);
            }

            DestFieldComboBox.Items.AddRange(columnNames);

            if (DestFieldComboBox.Items.Count > 0)
            {
              DestFieldComboBox.SelectedIndex = selectedColumnIndex;
            }
        }

        /// <summary>Close the form</summary>
        /// <param name = "sender">The sender of the event.</param>
        /// <param name = "e">The arguments.</param>
        private void Close_bn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>Execute the calculation</summary>
        /// <param name = "sender">The sender of the event.</param>
        /// <param name = "e">The arguments.</param>
        private void Apply_Click(object sender, EventArgs e)
        {
            bool isColumnExpression = functions_lb.Text == "+" || functions_lb.Text == "Trim()" || functions_lb.Text == "Substring()";
            bool isDestinationInQuery = query_text_tb.Text.ToLower().Contains(DestFieldComboBox.Text.ToLower().Trim());

            // Test first to see if using a column expression -- if so, make sure there are no circular references
            if (isColumnExpression && isDestinationInQuery)
            {
                MessageBox.Show("The +, Trim(), and Substring() functions cannot operate on the same field as you are setting.");
            }
            else
            {
                this.DoForumula();
            }
        }

        /// <summary>Execute the calculation</summary>
        private void DoForumula()
        {
            int destCol = this.GetDestinationColumn();

            if (destCol == -1)
            {
                MessageBox.Show("Could not find destination field!");
            }
            else
            {
                // Ensure that it's not tolower or toupper -- these can't be done as an expression
                if (query_text_tb.Text.ToLower().Contains("tolower") || query_text_tb.Text.ToLower().Contains("toupper") || query_text_tb.Text.ToLower().Contains("proper"))
                {
                    if (!query_text_tb.Text.Contains("("))
                    {
                        MessageBox.Show("The expression doesn't contain parenthesis!");
                    }
                    else
                    {
                        string fromfield = query_text_tb.Text.Substring(query_text_tb.Text.IndexOf("(") + 1).Trim();
                        fromfield = fromfield.Trim(new char[] { ')' });

                        int fromColumn = this.GetColumnIndex(fromfield);

                        if (fromColumn == -1)
                        {
                            MessageBox.Show("Could not find source field!");
                        }
                        else
                        {
                            for (int j = 0; j < this.dataGridView.RowCount; j++)
                            {
                                if (query_text_tb.Text.ToLower().Contains("tolower"))
                                {
                                    this.dataGridView.Rows[j].Cells[destCol].Value = this.dataGridView.Rows[j].Cells[fromColumn].Value.ToString().ToLower();
                                }
                                else if (query_text_tb.Text.ToLower().Contains("toupper"))
                                {
                                    this.dataGridView.Rows[j].Cells[destCol].Value = this.dataGridView.Rows[j].Cells[fromColumn].Value.ToString().ToUpper();
                                }
                                else if (query_text_tb.Text.ToLower().Contains("proper"))
                                {
                                    CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
                                    TextInfo textInfo = cultureInfo.TextInfo;

                                    this.dataGridView.Rows[j].Cells[destCol].Value = textInfo.ToTitleCase(this.dataGridView.Rows[j].Cells[fromColumn].Value.ToString());
                                }
                            }
                        }
                    }
                }
                else
                {
                    DataTable dt = (DataTable)this.dataGridView.DataSource;
                    dt.Columns[destCol].Expression = query_text_tb.Text;
                }
            }
        }

        /// <summary>Get the columnid of the column where the result will be written to</summary>
        /// <returns>The id of the column</returns>
        private int GetDestinationColumn()
        {
            int destCol = -1;

            for (int i = 0; i < this.dataGridView.Columns.Count; i++)
            {
                if (this.dataGridView.Columns[i].Name.ToLower().Trim() == DestFieldComboBox.Text.ToLower().Trim())
                {
                    destCol = i;
                    break;
                }
            }

            return destCol;
        }

        /// <summary>Get the columnindex of a given columnn</summary>
        /// <param name = "fromfield">The given column.</param>
        /// <returns>The index of the column</returns>
        private int GetColumnIndex(string fromfield)
        {
            int fromColumn = -1;
            for (int i = 0; i < this.dataGridView.Columns.Count; i++)
            {
                if (this.dataGridView.Columns[i].Name.ToLower().Trim() == fromfield.ToLower().Trim())
                {
                    fromColumn = i;
                    break;
                }

            }

            return fromColumn;
        }

        /// <summary>Add given text to formula</summary>
        /// <param name = "value">The given text.</param>
        private void AddTextToFormula(string value)
        {
            string formulaTxt = this.query_text_tb.Text;

            if (this.query_text_tb.SelectionLength > 0)
            {
                string beforeS = formulaTxt.Substring(0, this.query_text_tb.SelectionStart);
                string afterS = formulaTxt.Substring(this.query_text_tb.SelectionStart + this.query_text_tb.SelectionLength);

                formulaTxt = beforeS + value + afterS;
            }
            else
            {
                formulaTxt = formulaTxt != string.Empty ? formulaTxt + " " + value : formulaTxt + value;
            }

            this.query_text_tb.Text = formulaTxt;
        }

        /// <summary>Add text to formula</summary>
        /// <param name = "sender">The sender of the event.</param>
        /// <param name = "e">The arguments.</param>
        private void Fields_lb_DoubleClick(object sender, EventArgs e)
        {
            if (Fields_lb.SelectedItems.Count > 0)
            {
                string value = Fields_lb.SelectedItems[0].ToString();
                this.AddTextToFormula(value);
            }
        }

        /// <summary>Add text to formula</summary>
        /// <param name = "sender">The sender of the event.</param>
        /// <param name = "e">The arguments.</param>
        private void functions_lb_DoubleClick(object sender, EventArgs e)
        {
            if (functions_lb.SelectedItems.Count > 0)
            {
                string value = functions_lb.SelectedItems[0].ToString();
                this.AddTextToFormula(value);
            }
        }
    }
}
