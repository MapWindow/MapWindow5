using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Api.Interfaces;
using MW5.Plugins.TableEditor.Views.Abstract;
using MW5.Shared;
using MW5.UI.Forms;
using Syncfusion.Windows.Forms.Tools;

namespace MW5.Plugins.TableEditor.Views
{
    public partial class FieldCalculatorView : FieldCalculatorViewBase, IFieldCalculatorView
    {
        public FieldCalculatorView()
        {
            InitializeComponent();
        }

        public void Initialize()
        {
            functionTreeView1.Initialize();

            InitFieldsList();

            lblField.Text = "[" + Model.Field.Name + "] = ";
        }

        private void InitFieldsList()
        {
            listBox1.Items.Clear();

            foreach (var fld in Model.Table.Fields)
            {
                listBox1.Items.Add(fld.Name);
            }
        }

        public ButtonBase OkButton
        {
            get { return btnOk; }
        }

        #region Handlers

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            functionTreeView1.Filter(txtSearch.Text);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems.Count <= 0) return;

            string value = string.Format("[{0}]", listBox1.SelectedItems[0]);
            AddTextToExpression(value);
        }

        private void FunctionTreeView1DoubleClick(object sender, TreeViewAdvMouseClickEventArgs e)
        {
            var fn = functionTreeView1.SelectedFunction;
            if (fn == null) return;
            
            var name = fn.Name;

            if (!name.StartsWith("$"))
            {
                string args = fn.NumParameters > 1 ? "( " + StringHelper.Fill("; ", fn.NumParameters - 1) + ")" : "()";
                name += args;
            }

            AddTextToExpression(name);
        }

        private void txtExpression_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtExpression.Text))
            {
                lblValidation.Text = "Expression is empty";
                lblValidation.ForeColor = Color.Black;
                lblValidation.Font = new Font(lblValidation.Font, FontStyle.Regular);
                return;
            }

            string errorMsg;
            if (Model.Table.TestExpression(txtExpression.Text, Model.ReturnType, out errorMsg))
            {
                lblValidation.Text = "Expression is valid";
                lblValidation.ForeColor = Color.Green;
                lblValidation.Font = new Font(lblValidation.Font, FontStyle.Bold);
            }
            else
            {
                lblValidation.Text = "Error: " + errorMsg;
                lblValidation.ForeColor = Color.Red;
                lblValidation.Font = new Font(lblValidation.Font, FontStyle.Bold);
            }
        }

        #endregion

        #region Expression TextBox

        private void AddTextToExpression(string value)
        {
            string formulaTxt = txtExpression.Text;

            if (txtExpression.Text.Length > 0)
            {
                string beforeS = formulaTxt.Substring(0, txtExpression.SelectionStart);
                string afterS = formulaTxt.Substring(txtExpression.SelectionStart + txtExpression.SelectionLength);

                formulaTxt = beforeS + value + afterS;
            }
            else
            {
                formulaTxt = formulaTxt != string.Empty ? formulaTxt + " " + value : formulaTxt + value;
            }

            txtExpression.Text = formulaTxt;
        }

        #endregion
    }

    public class FieldCalculatorViewBase : MapWindowView<FieldCalculatorModel> { }
}
