// -------------------------------------------------------------------------------------------
// <copyright file="FieldCalculatorView.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MW5.Api.Concrete;
using MW5.Api.Enums;
using MW5.Attributes.Model;
using MW5.Plugins.TableEditor.Views.Abstract;
using MW5.Shared;
using MW5.UI.Forms;
using Syncfusion.Windows.Forms.Grid.Grouping;
using Syncfusion.Windows.Forms.Tools;
using Action = System.Action;

namespace MW5.Plugins.TableEditor.Views
{
    public partial class FieldCalculatorView : FieldCalculatorViewBase, IFieldCalculatorView
    {
        public FieldCalculatorView()
        {
            InitializeComponent();

            InitOperators();

            KeyPreview = true;

            btnTest.Click += (s, e) => Invoke(TestClicked);
        }

        public void Initialize()
        {
            functionTreeView1.Initialize();

            InitFieldsList();

            lblField.Text = string.Format("[{0}] = ", Model.Field.Name);
            lblType.Text = string.Format("({0})", Model.Field.Type.EnumToString());

            txtExpression.Text = Model.Field.Expression;
        }

        public event Action TestClicked;

        public string Expression
        {
            get { return txtExpression.Text; }
        }

        public ButtonBase OkButton
        {
            get { return btnOk; }
        }

        private void AddFunctionToExpression(string signature)
        {
            signature = ExpressionFunction.PadSignature(signature);

            int start, end;
            if (ExpressionFunction.GetFirstArgumentWithinSignature(signature, out start, out end))
            {
                int pos = txtExpression.SelectionStart;
                txtExpression.SelectedText = signature + " ";
                pos += start;
                int length = end - start + 1;
                txtExpression.Select(pos, length);
            }
            else
            {
                AddTextToExpression(signature);
            }
        }

        private void AddTextToExpression(string value)
        {
            txtExpression.SelectedText = value + " ";
            txtExpression.Focus();
        }

        private void FieldCalculatorView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F && e.Control)
            {
                txtSearch.Focus();
            }
        }

        private void FieldGridDoubleClick(object sender, GridTableControlCellClickEventArgs e)
        {
            var f = fieldTypeGrid1.Adapter.SelectedItem;
            if (f != null)
            {
                var value = string.Format("[{0}]", f.Name);
                AddTextToExpression(value);
            }
        }

        private void FunctionTreeView1DoubleClick(object sender, TreeViewAdvMouseClickEventArgs e)
        {
            var fn = functionTreeView1.SelectedFunction;
            if (fn == null) return;

            var signature = fn.Signature;

            AddFunctionToExpression(signature);
        }

        private void InitFieldsList()
        {
            fieldTypeGrid1.DataSource = Model.Table.Fields.Select(f => new FieldTypeWrapper(f)).ToList();
            fieldTypeGrid1.TableControlCellDoubleClick += FieldGridDoubleClick;
            fieldTypeGrid1.ShowColumnHeaders = false;
        }

        private void InitOperators()
        {
            btnMultiply.Tag = "*";
            btnDivide.Tag = "/";
            btnPlus.Tag = "+";
            btnMinus.Tag = "-";

            btnMultiply.Click += OperatorClicked;
            btnDivide.Click += OperatorClicked;
            btnPlus.Click += OperatorClicked;
            btnMinus.Click += OperatorClicked;
        }

        private void OnExpressionTextChanged(object sender, EventArgs e)
        {
            ValidateOnTheFly();
        }

        private void OperatorClicked(object sender, EventArgs e)
        {
            var btn = sender as Control;
            if (btn != null)
            {
                AddTextToExpression(btn.Tag.ToString());
            }
        }

        private void ValidateOnTheFly()
        {
            if (string.IsNullOrWhiteSpace(txtExpression.Text))
            {
                lblValidation.Text = "Expression is empty";
                lblValidation.ForeColor = Color.Black;
                return;
            }

            string errorMsg;
            if (Model.Table.TestExpression(txtExpression.Text, Model.ReturnType, out errorMsg))
            {
                lblValidation.Text = "Expression is valid";
                lblValidation.ForeColor = Color.Green;
                return;
            }

            lblValidation.Text = "Error: " + errorMsg;
            lblValidation.ForeColor = Color.Red;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtExpression.Text = string.Empty;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            functionTreeView1.Filter(txtSearch.Text);
        }
    }

    public class FieldCalculatorViewBase : MapWindowView<FieldCalculatorModel>
    {
    }
}