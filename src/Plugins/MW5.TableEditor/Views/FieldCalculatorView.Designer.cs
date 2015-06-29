using MW5.Attributes.Controls;
using MW5.Data.Controls;

namespace MW5.Plugins.TableEditor.Views
{
    partial class FieldCalculatorView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FieldCalculatorView));
            this.btnCancel = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnOk = new Syncfusion.Windows.Forms.ButtonAdv();
            this.functionTreeView1 = new MW5.Plugins.TableEditor.Controls.FunctionTreeView();
            this.txtSearch = new MW5.UI.Controls.WatermarkTextbox();
            this.lblValidation = new System.Windows.Forms.Label();
            this.txtExpression = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblField = new System.Windows.Forms.Label();
            this.btnMinus = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnMultiply = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnClear = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnPlus = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnDivide = new Syncfusion.Windows.Forms.ButtonAdv();
            this.fieldTypeGrid1 = new MW5.Attributes.Controls.FieldTypeGrid();
            this.btnTest = new Syncfusion.Windows.Forms.ButtonAdv();
            ((System.ComponentModel.ISupportInitialize)(this.functionTreeView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fieldTypeGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro;
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.btnCancel.BeforeTouchSize = new System.Drawing.Size(85, 26);
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.IsBackStageButton = false;
            this.btnCancel.Location = new System.Drawing.Point(482, 384);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 26);
            this.btnCancel.TabIndex = 34;
            this.btnCancel.Text = "Cancel";
            // 
            // btnOk
            // 
            this.btnOk.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro;
            this.btnOk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.btnOk.BeforeTouchSize = new System.Drawing.Size(85, 26);
            this.btnOk.ForeColor = System.Drawing.Color.White;
            this.btnOk.IsBackStageButton = false;
            this.btnOk.Location = new System.Drawing.Point(392, 384);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(85, 26);
            this.btnOk.TabIndex = 33;
            this.btnOk.Text = "Calculate";
            // 
            // functionTreeView1
            // 
            this.functionTreeView1.ApplyStyle = true;
            this.functionTreeView1.BeforeTouchSize = new System.Drawing.Size(206, 326);
            this.functionTreeView1.CanSelectDisabledNode = false;
            // 
            // 
            // 
            this.functionTreeView1.HelpTextControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.functionTreeView1.HelpTextControl.Location = new System.Drawing.Point(0, 0);
            this.functionTreeView1.HelpTextControl.Name = "helpText";
            this.functionTreeView1.HelpTextControl.Size = new System.Drawing.Size(49, 15);
            this.functionTreeView1.HelpTextControl.TabIndex = 0;
            this.functionTreeView1.HelpTextControl.Text = "help text";
            this.functionTreeView1.Location = new System.Drawing.Point(361, 52);
            this.functionTreeView1.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.functionTreeView1.Name = "functionTreeView1";
            this.functionTreeView1.ShowFocusRect = true;
            this.functionTreeView1.ShowSuperTooltip = true;
            this.functionTreeView1.Size = new System.Drawing.Size(206, 326);
            this.functionTreeView1.TabIndex = 35;
            this.functionTreeView1.Text = "functionsTreeView1";
            // 
            // 
            // 
            this.functionTreeView1.ToolTipControl.BackColor = System.Drawing.SystemColors.Info;
            this.functionTreeView1.ToolTipControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.functionTreeView1.ToolTipControl.Location = new System.Drawing.Point(0, 0);
            this.functionTreeView1.ToolTipControl.Name = "toolTip";
            this.functionTreeView1.ToolTipControl.Size = new System.Drawing.Size(41, 15);
            this.functionTreeView1.ToolTipControl.TabIndex = 1;
            this.functionTreeView1.ToolTipControl.Text = "toolTip";
            this.functionTreeView1.ToolTipDuration = 5000;
            this.functionTreeView1.NodeMouseDoubleClick += new Syncfusion.Windows.Forms.Tools.TreeNodeAdvMouseClickArgs(this.FunctionTreeView1DoubleClick);
            // 
            // txtSearch
            // 
            this.txtSearch.BeforeTouchSize = new System.Drawing.Size(206, 20);
            this.txtSearch.Cue = "Type to find function (Ctrl + F)";
            this.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearch.FarImage = ((System.Drawing.Image)(resources.GetObject("txtSearch.FarImage")));
            this.txtSearch.Location = new System.Drawing.Point(361, 25);
            this.txtSearch.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.ShowClearButton = true;
            this.txtSearch.Size = new System.Drawing.Size(206, 20);
            this.txtSearch.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
            this.txtSearch.TabIndex = 39;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // lblValidation
            // 
            this.lblValidation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblValidation.Location = new System.Drawing.Point(12, 384);
            this.lblValidation.Name = "lblValidation";
            this.lblValidation.Size = new System.Drawing.Size(338, 24);
            this.lblValidation.TabIndex = 41;
            this.lblValidation.Text = "Expression is empty";
            // 
            // txtExpression
            // 
            this.txtExpression.HideSelection = false;
            this.txtExpression.Location = new System.Drawing.Point(12, 233);
            this.txtExpression.Multiline = true;
            this.txtExpression.Name = "txtExpression";
            this.txtExpression.Size = new System.Drawing.Size(338, 145);
            this.txtExpression.TabIndex = 42;
            this.txtExpression.TextChanged += new System.EventHandler(this.OnExpressionTextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 44;
            this.label1.Text = "Fields";
            // 
            // lblField
            // 
            this.lblField.AutoSize = true;
            this.lblField.Location = new System.Drawing.Point(12, 217);
            this.lblField.Name = "lblField";
            this.lblField.Size = new System.Drawing.Size(70, 13);
            this.lblField.TabIndex = 45;
            this.lblField.Text = "Field name = ";
            // 
            // btnMinus
            // 
            this.btnMinus.BeforeTouchSize = new System.Drawing.Size(32, 23);
            this.btnMinus.IsBackStageButton = false;
            this.btnMinus.Location = new System.Drawing.Point(280, 54);
            this.btnMinus.Name = "btnMinus";
            this.btnMinus.Size = new System.Drawing.Size(32, 23);
            this.btnMinus.TabIndex = 50;
            this.btnMinus.Text = "-";
            // 
            // btnMultiply
            // 
            this.btnMultiply.BeforeTouchSize = new System.Drawing.Size(32, 23);
            this.btnMultiply.IsBackStageButton = false;
            this.btnMultiply.Location = new System.Drawing.Point(280, 112);
            this.btnMultiply.Name = "btnMultiply";
            this.btnMultiply.Size = new System.Drawing.Size(32, 23);
            this.btnMultiply.TabIndex = 56;
            this.btnMultiply.Text = "*";
            // 
            // btnClear
            // 
            this.btnClear.BeforeTouchSize = new System.Drawing.Size(70, 23);
            this.btnClear.IsBackStageButton = false;
            this.btnClear.Location = new System.Drawing.Point(280, 178);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(70, 23);
            this.btnClear.TabIndex = 64;
            this.btnClear.Text = "Clear";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnPlus
            // 
            this.btnPlus.BeforeTouchSize = new System.Drawing.Size(32, 23);
            this.btnPlus.IsBackStageButton = false;
            this.btnPlus.Location = new System.Drawing.Point(280, 25);
            this.btnPlus.Name = "btnPlus";
            this.btnPlus.Size = new System.Drawing.Size(32, 23);
            this.btnPlus.TabIndex = 46;
            this.btnPlus.Text = "+";
            // 
            // btnDivide
            // 
            this.btnDivide.BeforeTouchSize = new System.Drawing.Size(32, 23);
            this.btnDivide.IsBackStageButton = false;
            this.btnDivide.Location = new System.Drawing.Point(280, 83);
            this.btnDivide.Name = "btnDivide";
            this.btnDivide.Size = new System.Drawing.Size(32, 23);
            this.btnDivide.TabIndex = 47;
            this.btnDivide.Text = "/";
            // 
            // fieldTypeGrid1
            // 
            this.fieldTypeGrid1.Appearance.AnyCell.Borders.Bottom = new Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.None);
            this.fieldTypeGrid1.Appearance.AnyCell.Borders.Left = new Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.None);
            this.fieldTypeGrid1.Appearance.AnyCell.Borders.Right = new Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.None);
            this.fieldTypeGrid1.Appearance.AnyCell.Borders.Top = new Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.None);
            this.fieldTypeGrid1.Appearance.AnyCell.VerticalAlignment = Syncfusion.Windows.Forms.Grid.GridVerticalAlignment.Middle;
            this.fieldTypeGrid1.BackColor = System.Drawing.SystemColors.Window;
            this.fieldTypeGrid1.FreezeCaption = false;
            this.fieldTypeGrid1.Location = new System.Drawing.Point(12, 26);
            this.fieldTypeGrid1.Name = "fieldTypeGrid1";
            this.fieldTypeGrid1.Size = new System.Drawing.Size(262, 175);
            this.fieldTypeGrid1.TabIndex = 65;
            this.fieldTypeGrid1.TableDescriptor.TableOptions.ListBoxSelectionCurrentCellOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionCurrentCellOptions.None;
            this.fieldTypeGrid1.TableOptions.AllowDropDownCell = true;
            this.fieldTypeGrid1.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None;
            this.fieldTypeGrid1.TableOptions.ListBoxSelectionColorOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionColorOptions.ApplySelectionColor;
            this.fieldTypeGrid1.TableOptions.ListBoxSelectionMode = System.Windows.Forms.SelectionMode.One;
            this.fieldTypeGrid1.TableOptions.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.fieldTypeGrid1.TableOptions.SelectionTextColor = System.Drawing.Color.Black;
            this.fieldTypeGrid1.Text = "fieldTypeGrid1";
            this.fieldTypeGrid1.TopLevelGroupOptions.ShowAddNewRecordBeforeDetails = false;
            this.fieldTypeGrid1.TopLevelGroupOptions.ShowCaption = false;
            this.fieldTypeGrid1.TopLevelGroupOptions.ShowColumnHeaders = true;
            this.fieldTypeGrid1.VersionInfo = "0.0.1.0";
            this.fieldTypeGrid1.WrapWithPanel = true;
            // 
            // btnTest
            // 
            this.btnTest.BeforeTouchSize = new System.Drawing.Size(70, 23);
            this.btnTest.IsBackStageButton = false;
            this.btnTest.Location = new System.Drawing.Point(280, 149);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(70, 23);
            this.btnTest.TabIndex = 66;
            this.btnTest.Text = "Test";
            // 
            // FieldCalculatorView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(575, 417);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.fieldTypeGrid1);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnMultiply);
            this.Controls.Add(this.btnMinus);
            this.Controls.Add(this.btnDivide);
            this.Controls.Add(this.btnPlus);
            this.Controls.Add(this.lblField);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtExpression);
            this.Controls.Add(this.lblValidation);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.functionTreeView1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Name = "FieldCalculatorView";
            this.Text = "Field Calculator";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FieldCalculatorView_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.functionTreeView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fieldTypeGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Syncfusion.Windows.Forms.ButtonAdv btnCancel;
        private Syncfusion.Windows.Forms.ButtonAdv btnOk;
        private Controls.FunctionTreeView functionTreeView1;
        private UI.Controls.WatermarkTextbox txtSearch;
        private System.Windows.Forms.Label lblValidation;
        private System.Windows.Forms.TextBox txtExpression;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblField;
        private Syncfusion.Windows.Forms.ButtonAdv btnMinus;
        private Syncfusion.Windows.Forms.ButtonAdv btnMultiply;
        private Syncfusion.Windows.Forms.ButtonAdv btnClear;
        private Syncfusion.Windows.Forms.ButtonAdv btnPlus;
        private Syncfusion.Windows.Forms.ButtonAdv btnDivide;
        private FieldTypeGrid fieldTypeGrid1;
        private Syncfusion.Windows.Forms.ButtonAdv btnTest;
    }
}