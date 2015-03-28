using System;
using System.Data;
using System.Threading;
using System.Windows.Forms;
using MW5.Plugins.TableEditor.BO;
using MW5.Plugins.TableEditor.Legacy;
using MW5.UI;

namespace MW5.Plugins.TableEditor.Forms
{
    /// <summary>
    ///  Form-class for textcalculator
    /// </summary>
    public partial class TextCalculatorForm : MapWindowForm
    {
        /// <summary>The gridview with shape-data</summary> 
        private readonly DataGridView _dataGridView;

        /// <summary>Initializes a new instance of the frmTextCalculator class</summary>
        /// <param name = "gridView">The gridview.</param>
        /// <param name="selectedColumnIndex">The index of the selected Column</param>
        public TextCalculatorForm(DataGridView gridView, int selectedColumnIndex)
        {
            InitializeComponent();

            _dataGridView = gridView;

            InitializeFieldValues((DataTable) gridView.DataSource, selectedColumnIndex);
        }

        /// <summary>Initializes the controls on the form</summary>
        /// <param name = "dt">The datatable.</param>
        /// <param name="selectedColumnIndex">The index of the selected Column</param>
        private void InitializeFieldValues(DataTable dt, int selectedColumnIndex)
        {
            Fields_lb.Items.Clear();

            var columnNames = ShapeData.GetVisibleFieldNames(dt);
            foreach (var colName in columnNames)
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
            Close();
        }

        /// <summary>Execute the calculation</summary>
        /// <param name = "sender">The sender of the event.</param>
        /// <param name = "e">The arguments.</param>
        private void Apply_Click(object sender, EventArgs e)
        {
            var isColumnExpression = functions_lb.Text == "+" || functions_lb.Text == "Trim()" ||
                                     functions_lb.Text == "Substring()";
            var isDestinationInQuery = query_text_tb.Text.ToLower().Contains(DestFieldComboBox.Text.ToLower().Trim());

            // Test first to see if using a column expression -- if so, make sure there are no circular references
            if (isColumnExpression && isDestinationInQuery)
            {
                MessageBox.Show(
                    "The +, Trim(), and Substring() functions cannot operate on the same field as you are setting.");
            }
            else
            {
                DoForumula();
            }
        }

        /// <summary>Execute the calculation</summary>
        private void DoForumula()
        {
            var destCol = GetDestinationColumn();

            if (destCol == -1)
            {
                MessageBox.Show("Could not find destination field!");
            }
            else
            {
                // Ensure that it's not tolower or toupper -- these can't be done as an expression
                if (query_text_tb.Text.ToLower().Contains("tolower") || query_text_tb.Text.ToLower().Contains("toupper") ||
                    query_text_tb.Text.ToLower().Contains("proper"))
                {
                    if (!query_text_tb.Text.Contains("("))
                    {
                        MessageBox.Show("The expression doesn't contain parenthesis!");
                    }
                    else
                    {
                        var fromfield = query_text_tb.Text.Substring(query_text_tb.Text.IndexOf("(") + 1).Trim();
                        fromfield = fromfield.Trim(')');

                        var fromColumn = GetColumnIndex(fromfield);

                        if (fromColumn == -1)
                        {
                            MessageBox.Show("Could not find source field!");
                        }
                        else
                        {
                            for (var j = 0; j < _dataGridView.RowCount; j++)
                            {
                                if (query_text_tb.Text.ToLower().Contains("tolower"))
                                {
                                    _dataGridView.Rows[j].Cells[destCol].Value =
                                        _dataGridView.Rows[j].Cells[fromColumn].Value.ToString().ToLower();
                                }
                                else if (query_text_tb.Text.ToLower().Contains("toupper"))
                                {
                                    _dataGridView.Rows[j].Cells[destCol].Value =
                                        _dataGridView.Rows[j].Cells[fromColumn].Value.ToString().ToUpper();
                                }
                                else if (query_text_tb.Text.ToLower().Contains("proper"))
                                {
                                    var cultureInfo = Thread.CurrentThread.CurrentCulture;
                                    var textInfo = cultureInfo.TextInfo;

                                    _dataGridView.Rows[j].Cells[destCol].Value =
                                        textInfo.ToTitleCase(_dataGridView.Rows[j].Cells[fromColumn].Value.ToString());
                                }
                            }
                        }
                    }
                }
                else
                {
                    var dt = (DataTable) _dataGridView.DataSource;
                    dt.Columns[destCol].Expression = query_text_tb.Text;
                }
            }
        }

        /// <summary>Get the columnid of the column where the result will be written to</summary>
        /// <returns>The id of the column</returns>
        private int GetDestinationColumn()
        {
            var destCol = -1;

            for (var i = 0; i < _dataGridView.Columns.Count; i++)
            {
                if (_dataGridView.Columns[i].Name.ToLower().Trim() == DestFieldComboBox.Text.ToLower().Trim())
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
            var fromColumn = -1;
            for (var i = 0; i < _dataGridView.Columns.Count; i++)
            {
                if (_dataGridView.Columns[i].Name.ToLower().Trim() == fromfield.ToLower().Trim())
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

        /// <summary>Add text to formula</summary>
        /// <param name = "sender">The sender of the event.</param>
        /// <param name = "e">The arguments.</param>
        private void Fields_lb_DoubleClick(object sender, EventArgs e)
        {
            if (Fields_lb.SelectedItems.Count > 0)
            {
                var value = Fields_lb.SelectedItems[0].ToString();
                AddTextToFormula(value);
            }
        }

        /// <summary>Add text to formula</summary>
        /// <param name = "sender">The sender of the event.</param>
        /// <param name = "e">The arguments.</param>
        private void functions_lb_DoubleClick(object sender, EventArgs e)
        {
            if (functions_lb.SelectedItems.Count > 0)
            {
                var value = functions_lb.SelectedItems[0].ToString();
                AddTextToFormula(value);
            }
        }
    }
}