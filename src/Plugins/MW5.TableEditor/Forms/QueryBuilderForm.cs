using System;
using System.Data;
using System.Windows.Forms;
using MW5.UI;

namespace MW5.Plugins.TableEditor.Forms
{
    /// <summary>
    ///  Form-class for quering the shape-data
    /// </summary>
    public partial class QueryBuilderForm : MapWindowForm
    {
        /// <summary>Delegate to execute query</summary> 
        /// <param name = "queryString">The string with the query to execute.</param>
        public delegate void ExecuteQueryMethod(string queryString);

        /// <summary>The method which will execute the query</summary> 
        public ExecuteQueryMethod QueryMethod;

        /// <summary>Initializes a new instance of the frmQueryBuilder class</summary>
        /// <param name = "dt">The datatable.</param>
        /// <param name = "executeQueryMethod">The method which will execute the query.</param>
        public QueryBuilderForm(DataTable dt, ExecuteQueryMethod executeQueryMethod)
        {
            InitializeComponent();

            QueryMethod = executeQueryMethod;

            lvFields.Columns[0].Width = Convert.ToInt32(lvFields.Size.Width*0.6);
            lvFields.Columns[1].Width = Convert.ToInt32(lvFields.Size.Width*0.35);

            FillFieldsList(dt);
        }

        /// <summary>Fill list with fields</summary>
        /// <param name = "dt">The datatable.</param>
        private void FillFieldsList(DataTable dt)
        {
            for (var i = 1; i < dt.Columns.Count; i++)
            {
                lvFields.Items.Add(dt.Columns[i].ColumnName).SubItems.Add(dt.Columns[i].DataType.Name);
            }
        }

        /// <summary>Close the form</summary>
        /// <param name = "sender">The sender of the event.</param>
        /// <param name = "e">The arguments.</param>
        private void Close_bn_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>Add to query-text</summary>
        /// <param name = "sender">The sender of the event.</param>
        /// <param name = "e">The arguments.</param>
        private void equals_op_Click(object sender, EventArgs e)
        {
            AddToQuery(" = ");
        }

        /// <summary>Add text to query-text</summary>
        /// <param name = "value">The text to add.</param>
        private void AddToQuery(string value)
        {
            var formulaTxt = query_text_tb.Text;

            if (query_text_tb.SelectionLength > 0)
            {
                var beforeS = formulaTxt.Substring(0, query_text_tb.SelectionStart);
                var afterS = formulaTxt.Substring(query_text_tb.SelectionStart + query_text_tb.SelectionLength);

                formulaTxt = beforeS + value + afterS;
            }
            else
            {
                formulaTxt = formulaTxt != string.Empty ? formulaTxt + " " + value : formulaTxt + value;
            }

            query_text_tb.Text = formulaTxt;
        }

        /// <summary>Add to query-text</summary>
        /// <param name = "sender">The sender of the event.</param>
        /// <param name = "e">The arguments.</param>
        private void notequal_op_Click(object sender, EventArgs e)
        {
            AddToQuery("<>");
        }

        /// <summary>Add to query-text</summary>
        /// <param name = "sender">The sender of the event.</param>
        /// <param name = "e">The arguments.</param>
        private void greaterthan_op_Click(object sender, EventArgs e)
        {
            AddToQuery(">");
        }

        /// <summary>Add to query-text</summary>
        /// <param name = "sender">The sender of the event.</param>
        /// <param name = "e">The arguments.</param>
        private void greaterthanorequal_op_Click(object sender, EventArgs e)
        {
            AddToQuery(">=");
        }

        /// <summary>Add to query-text</summary>
        /// <param name = "sender">The sender of the event.</param>
        /// <param name = "e">The arguments.</param>
        private void lessthan_op_Click(object sender, EventArgs e)
        {
            AddToQuery("<");
        }

        /// <summary>Add to query-text</summary>
        /// <param name = "sender">The sender of the event.</param>
        /// <param name = "e">The arguments.</param>
        private void lessthanorequal_op_Click(object sender, EventArgs e)
        {
            AddToQuery("<=");
        }

        /// <summary>Add to query-text</summary>
        /// <param name = "sender">The sender of the event.</param>
        /// <param name = "e">The arguments.</param>
        private void and_op_Click(object sender, EventArgs e)
        {
            AddToQuery("And");
        }

        /// <summary>Add to query-text</summary>
        /// <param name = "sender">The sender of the event.</param>
        /// <param name = "e">The arguments.</param>
        private void or_op_Click(object sender, EventArgs e)
        {
            AddToQuery("Or");
        }

        /// <summary>Add to query-text</summary>
        /// <param name = "sender">The sender of the event.</param>
        /// <param name = "e">The arguments.</param>
        private void not_op_Click(object sender, EventArgs e)
        {
            AddToQuery("Not");
        }

        /// <summary>Add to query-text</summary>
        /// <param name = "sender">The sender of the event.</param>
        /// <param name = "e">The arguments.</param>
        private void like_op_Click(object sender, EventArgs e)
        {
            AddToQuery("Like");
        }

        /// <summary>Execute the query</summary>
        /// <param name = "sender">The sender of the event.</param>
        /// <param name = "e">The arguments.</param>
        private void Apply_Click(object sender, EventArgs e)
        {
            try
            {
                var queryString = query_text_tb.Text;

                if (queryString.Contains("\"") && !queryString.Contains("'"))
                {
                    queryString = queryString.Replace("\"", "'");
                }

                QueryMethod.Invoke(queryString);
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
            var text =
                "Boolean Operators:\r\nAND, OR, NOT \r\n\r\nComparison Operators:\r\n< >, <=, >=, <>, IN, LIKE \r\n\r\nNumeric Constants: \r\n50 or 50.0 or 5E1 (Numeric constants can be represented as integers, floating point or in scientific notation\r\n\r\nString Constants:\r\n'Tenure' (String Constants should be quoted with single quotes)\r\n\r\nArithmetic Operators:\r\n+, -, *, /, %" +
                "\r\n\r\nString Concatentation Operator:\r\n+ (eg 'cat' + 'inhat' = 'catinhat')\r\n\r\nAggregate Functions:\r\nSum(), Avg(), Min(), Max(), StDev(), Var()\r\n\r\nString Manipulators:\r\nTRIM(Expression) - Removes leading and trailing blanks\r\nSUBSTRING(Expression, start, length) - Returns a substring of an existing string at a given length from the specified starting point" +
                "\r\n\r\nExample1 - Multi Criteria Query\r\ntenure_type = 'Freehold' AND tenure_area > 5000";

            var helpForm = new HelpForm(text);
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
                    Apply_Click(sender, EventArgs.Empty);
                    break;
                case Keys.Escape:
                    Close_bn_Click(sender, EventArgs.Empty);
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
            AddToQuery("[" + lvFields.SelectedItems[0].Text + "]");
        }

        /// <summary>Clear the query-text</summary>
        /// <param name = "sender">The sender of the event.</param>
        /// <param name = "e">The arguments.</param>
        private void btnClearQuery_Click(object sender, EventArgs e)
        {
            query_text_tb.Clear();
        }
    }
}