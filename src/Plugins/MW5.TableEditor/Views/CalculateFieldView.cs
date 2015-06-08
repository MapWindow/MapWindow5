using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Api.Helpers;
using MW5.Api.Interfaces;
using MW5.Plugins.Interfaces;
using MW5.Plugins.TableEditor.Helpers;
using MW5.Plugins.TableEditor.Views.Abstract;
using MW5.Shared;
using MW5.UI;
using MW5.UI.Forms;
using MW5.UI.Helpers;

namespace MW5.Plugins.TableEditor.Views
{
    public partial class CalculateFieldView : CalculateFieldViewBase, ICalculateFieldView
    {
        public CalculateFieldView()
        {
            InitializeComponent();

            btnAdd.Click += (s, e) => AddTextToComputation("+");
            btnSubtract.Click += (s, e) => AddTextToComputation("-");
            btnMultiply.Click += (s, e) => AddTextToComputation("*");
            btnDivide.Click += (s, e) => AddTextToComputation("/");
        }

        public ButtonBase OkButton
        {
            get { return btnOk; }
        }

        public void Initialize()
        {
            PopulateTreeView(Model);
            PopulateCombos(Model);
        }

        public string Expression
        {
            get
            {
                ComputationTextBox.Text = CloseParenthesis(ComputationTextBox.Text);
                return ComputationTextBox.Text;
            }
        }

        public int TargetFieldIndex
        {
            get { return DestFieldComboBox.SelectedIndex; }
        }

        private void PopulateCombos(IFeatureSet fs)
        {
            foreach (var fld in fs.Fields)
            {
                FieldsListView.Items.Add(fld.Name);
                DestFieldComboBox.Items.Add(fld.Name);
            }
        }

        private void PopulateTreeView(IFeatureSet fs)
        {
            var values = Enum.GetValues(typeof (CalculatorFunction));

            foreach (CalculatorFunction val in values)
            {
                TreeNode node = lstFunctions.Nodes.Add(val.EnumToString());
                var s =  val == CalculatorFunction.Shapes ? fs.GeometryType.GetShapeFunction() : val.GetFunction();

                foreach (string subNode in s.Split(' '))
                {
                    node.Nodes.Add(subNode);
                }
            }
        }

        /// <summary>
        /// Add the text to the formula
        /// </summary>
        /// <param name = "value">The value to add.</param>
        private void AddTextToComputation(string value)
        {
            string formulaTxt = ComputationTextBox.Text;

            if (ComputationTextBox.SelectionLength > 0)
            {
                string beforeS = formulaTxt.Substring(0, ComputationTextBox.SelectionStart);
                string afterS = formulaTxt.Substring(ComputationTextBox.SelectionStart + ComputationTextBox.SelectionLength);

                formulaTxt = beforeS + value + afterS;
            }
            else
            {
                formulaTxt = formulaTxt != string.Empty ? formulaTxt + " " + value : formulaTxt + value;
            }

            ComputationTextBox.Text = formulaTxt;
        }

        /// <summary>Adds missing parenthesis</summary>
        /// <param name = "text">The text to be checked.</param>
        /// <returns>The resulting string</returns>
        private string CloseParenthesis(string text)
        {
            char[] textChars = text.ToCharArray();

            int openCount = textChars.Count(elm => elm == '(');
            int closeCount = textChars.Count(elm => elm == ')');
            int totalCount = openCount - closeCount;

            for (int i = 0; i < totalCount; i++)
            {
                text += ")";
            }

            return text;
        }

        /// <summary>Add the text in the fieldlist to the formula</summary>
        /// <param name = "sender">The sender of the event.</param>
        /// <param name = "e">The arguments.</param>
        private void FieldsListView_DoubleClick(object sender, EventArgs e)
        {
            if (FieldsListView.SelectedItems.Count > 0)
            {
                string value = string.Format("[{0}]", FieldsListView.SelectedItems[0].Text);
                AddTextToComputation(value);
            }
        }
        
        /// <summary>Add text to forumula</summary>
        /// <param name = "sender">The sender of the event.</param>
        /// <param name = "e">The arguments.</param>
        private void lstFunctions_DoubleClick(object sender, EventArgs e)
        {
            if (lstFunctions.SelectedNode.Level > 0)
            {
                AddTextToComputation(lstFunctions.SelectedNode.Text);
            }
        }
    }

    public class CalculateFieldViewBase : MapWindowView<IFeatureSet> { }
}
