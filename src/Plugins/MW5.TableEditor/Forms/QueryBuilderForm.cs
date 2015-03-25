// ********************************************************************************************************
// <copyright file="frmQueryBuilder.cs" company="TopX Geo-ICT">
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

namespace MW5.Plugins.TableEditor.Forms
{
    /// <summary>
    ///  Form-class for quering the shape-data
    /// </summary>
    public partial class QueryBuilderForm : Form
    {
        /// <summary>The method which will execute the query</summary> 
        public ExecuteQueryMethod QueryMethod = null;

        /// <summary>Initializes a new instance of the frmQueryBuilder class</summary>
        /// <param name = "dt">The datatable.</param>
        /// <param name = "executeQueryMethod">The method which will execute the query.</param>
        public QueryBuilderForm(DataTable dt, ExecuteQueryMethod executeQueryMethod)
        {
            InitializeComponent();

            this.QueryMethod = executeQueryMethod;

            this.lvFields.Columns[0].Width = Convert.ToInt32(this.lvFields.Size.Width * 0.6);
            this.lvFields.Columns[1].Width = Convert.ToInt32(this.lvFields.Size.Width * 0.35);

            this.FillFieldsList(dt);
        }

        /// <summary>Delegate to execute query</summary> 
        /// <param name = "queryString">The string with the query to execute.</param>
        public delegate void ExecuteQueryMethod(string queryString);

        /// <summary>Fill list with fields</summary>
        /// <param name = "dt">The datatable.</param>
        private void FillFieldsList(DataTable dt)
        {
            for (int i = 1; i < dt.Columns.Count; i++)
            {
                this.lvFields.Items.Add(dt.Columns[i].ColumnName).SubItems.Add(dt.Columns[i].DataType.Name);
            }
        }

        /// <summary>Close the form</summary>
        /// <param name = "sender">The sender of the event.</param>
        /// <param name = "e">The arguments.</param>
        private void Close_bn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>Add to query-text</summary>
        /// <param name = "sender">The sender of the event.</param>
        /// <param name = "e">The arguments.</param>
        private void equals_op_Click(object sender, EventArgs e)
        {
            this.AddToQuery(" = ");
        }

        /// <summary>Add text to query-text</summary>
        /// <param name = "value">The text to add.</param>
        private void AddToQuery(string value)
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

        /// <summary>Add to query-text</summary>
        /// <param name = "sender">The sender of the event.</param>
        /// <param name = "e">The arguments.</param>
        private void notequal_op_Click(object sender, EventArgs e)
        {
            this.AddToQuery("<>");
        }

        /// <summary>Add to query-text</summary>
        /// <param name = "sender">The sender of the event.</param>
        /// <param name = "e">The arguments.</param>
        private void greaterthan_op_Click(object sender, EventArgs e)
        {
            this.AddToQuery(">");
        }

        /// <summary>Add to query-text</summary>
        /// <param name = "sender">The sender of the event.</param>
        /// <param name = "e">The arguments.</param>
        private void greaterthanorequal_op_Click(object sender, EventArgs e)
        {
            this.AddToQuery(">=");
        }

        /// <summary>Add to query-text</summary>
        /// <param name = "sender">The sender of the event.</param>
        /// <param name = "e">The arguments.</param>
        private void lessthan_op_Click(object sender, EventArgs e)
        {
            this.AddToQuery("<");
        }

        /// <summary>Add to query-text</summary>
        /// <param name = "sender">The sender of the event.</param>
        /// <param name = "e">The arguments.</param>
        private void lessthanorequal_op_Click(object sender, EventArgs e)
        {
            this.AddToQuery("<=");
        }

        /// <summary>Add to query-text</summary>
        /// <param name = "sender">The sender of the event.</param>
        /// <param name = "e">The arguments.</param>
        private void and_op_Click(object sender, EventArgs e)
        {
            this.AddToQuery("And");
        }

        /// <summary>Add to query-text</summary>
        /// <param name = "sender">The sender of the event.</param>
        /// <param name = "e">The arguments.</param>
        private void or_op_Click(object sender, EventArgs e)
        {
            this.AddToQuery("Or");
        }

        /// <summary>Add to query-text</summary>
        /// <param name = "sender">The sender of the event.</param>
        /// <param name = "e">The arguments.</param>
        private void not_op_Click(object sender, EventArgs e)
        {
            this.AddToQuery("Not");
        }

        /// <summary>Add to query-text</summary>
        /// <param name = "sender">The sender of the event.</param>
        /// <param name = "e">The arguments.</param>
        private void like_op_Click(object sender, EventArgs e)
        {
            this.AddToQuery("Like");
        }

        /// <summary>Execute the query</summary>
        /// <param name = "sender">The sender of the event.</param>
        /// <param name = "e">The arguments.</param>
        private void Apply_Click(object sender, EventArgs e)
        {
            try
            {
                string queryString = this.query_text_tb.Text;

                if (queryString.Contains("\"") && !queryString.Contains("'"))
                {
                    queryString = queryString.Replace("\"", "'");
                }

                this.QueryMethod.Invoke(queryString);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>Show help</summary>
        /// <param name = "sender">The sender of the event.</param>
        /// <param name = "e">The arguments.</param>
        private void Query_help_Click(object sender, EventArgs e)
        {
            string text = "Boolean Operators:\r\nAND, OR, NOT \r\n\r\nComparison Operators:\r\n< >, <=, >=, <>, IN, LIKE \r\n\r\nNumeric Constants: \r\n50 or 50.0 or 5E1 (Numeric constants can be represented as integers, floating point or in scientific notation\r\n\r\nString Constants:\r\n'Tenure' (String Constants should be quoted with single quotes)\r\n\r\nArithmetic Operators:\r\n+, -, *, /, %" +
                "\r\n\r\nString Concatentation Operator:\r\n+ (eg 'cat' + 'inhat' = 'catinhat')\r\n\r\nAggregate Functions:\r\nSum(), Avg(), Min(), Max(), StDev(), Var()\r\n\r\nString Manipulators:\r\nTRIM(Expression) - Removes leading and trailing blanks\r\nSUBSTRING(Expression, start, length) - Returns a substring of an existing string at a given length from the specified starting point" +
                "\r\n\r\nExample1 - Multi Criteria Query\r\ntenure_type = 'Freehold' AND tenure_area > 5000";

            HelpForm helpForm = new HelpForm(text);
            helpForm.ShowDialog();
        }

        /// <summary>Perform default buttons</summary>
        /// <param name = "sender">The sender of the event.</param>
        /// <param name = "e">The arguments.</param>
        private void frmQueryBuilder_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F5:
                    this.Apply_Click(sender, EventArgs.Empty);
                    break;
                case Keys.Escape:
                    this.Close_bn_Click(sender, EventArgs.Empty);
                    break;
                default:
                    break;
            }
        }

        /// <summary>Add to query-text</summary>
        /// <param name = "sender">The sender of the event.</param>
        /// <param name = "e">The arguments.</param>
        private void lvFields_DoubleClick(object sender, EventArgs e)
        {
            this.AddToQuery("[" + this.lvFields.SelectedItems[0].Text + "]");
        }

        /// <summary>Clear the query-text</summary>
        /// <param name = "sender">The sender of the event.</param>
        /// <param name = "e">The arguments.</param>
        private void btnClearQuery_Click(object sender, EventArgs e)
        {
            this.query_text_tb.Clear();
        }
    }
}
