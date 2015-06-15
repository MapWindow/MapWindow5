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
            this.buttonAdv5 = new Syncfusion.Windows.Forms.ButtonAdv();
            this.buttonAdv6 = new Syncfusion.Windows.Forms.ButtonAdv();
            this.buttonAdv7 = new Syncfusion.Windows.Forms.ButtonAdv();
            this.buttonAdv8 = new Syncfusion.Windows.Forms.ButtonAdv();
            this.buttonAdv10 = new Syncfusion.Windows.Forms.ButtonAdv();
            this.buttonAdv11 = new Syncfusion.Windows.Forms.ButtonAdv();
            this.buttonAdv12 = new Syncfusion.Windows.Forms.ButtonAdv();
            this.buttonAdv13 = new Syncfusion.Windows.Forms.ButtonAdv();
            this.buttonAdv14 = new Syncfusion.Windows.Forms.ButtonAdv();
            this.buttonAdv15 = new Syncfusion.Windows.Forms.ButtonAdv();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.buttonAdv16 = new Syncfusion.Windows.Forms.ButtonAdv();
            this.buttonAdv17 = new Syncfusion.Windows.Forms.ButtonAdv();
            this.buttonAdv1 = new Syncfusion.Windows.Forms.ButtonAdv();
            this.buttonAdv2 = new Syncfusion.Windows.Forms.ButtonAdv();
            this.buttonAdv3 = new Syncfusion.Windows.Forms.ButtonAdv();
            this.buttonAdv4 = new Syncfusion.Windows.Forms.ButtonAdv();
            this.buttonAdv9 = new Syncfusion.Windows.Forms.ButtonAdv();
            this.buttonAdv18 = new Syncfusion.Windows.Forms.ButtonAdv();
            ((System.ComponentModel.ISupportInitialize)(this.functionTreeView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch)).BeginInit();
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
            this.functionTreeView1.ShowSuperTooltip = false;
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
            this.functionTreeView1.ToolTipDuration = 0;
            this.functionTreeView1.NodeMouseDoubleClick += new Syncfusion.Windows.Forms.Tools.TreeNodeAdvMouseClickArgs(this.FunctionTreeView1DoubleClick);
            // 
            // txtSearch
            // 
            this.txtSearch.BeforeTouchSize = new System.Drawing.Size(206, 20);
            this.txtSearch.Cue = "Type to find function";
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
            this.lblValidation.Location = new System.Drawing.Point(12, 384);
            this.lblValidation.Name = "lblValidation";
            this.lblValidation.Size = new System.Drawing.Size(338, 24);
            this.lblValidation.TabIndex = 41;
            this.lblValidation.Text = "Expression is empty";
            // 
            // txtExpression
            // 
            this.txtExpression.Location = new System.Drawing.Point(12, 220);
            this.txtExpression.Multiline = true;
            this.txtExpression.Name = "txtExpression";
            this.txtExpression.Size = new System.Drawing.Size(338, 158);
            this.txtExpression.TabIndex = 42;
            this.txtExpression.TextChanged += new System.EventHandler(this.txtExpression_TextChanged);
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
            this.lblField.Location = new System.Drawing.Point(12, 204);
            this.lblField.Name = "lblField";
            this.lblField.Size = new System.Drawing.Size(70, 13);
            this.lblField.TabIndex = 45;
            this.lblField.Text = "Field name = ";
            // 
            // buttonAdv5
            // 
            this.buttonAdv5.BeforeTouchSize = new System.Drawing.Size(32, 23);
            this.buttonAdv5.IsBackStageButton = false;
            this.buttonAdv5.Location = new System.Drawing.Point(268, 25);
            this.buttonAdv5.Name = "buttonAdv5";
            this.buttonAdv5.Size = new System.Drawing.Size(32, 23);
            this.buttonAdv5.TabIndex = 50;
            this.buttonAdv5.Text = "buttonAdv5";
            // 
            // buttonAdv6
            // 
            this.buttonAdv6.BeforeTouchSize = new System.Drawing.Size(32, 23);
            this.buttonAdv6.IsBackStageButton = false;
            this.buttonAdv6.Location = new System.Drawing.Point(268, 54);
            this.buttonAdv6.Name = "buttonAdv6";
            this.buttonAdv6.Size = new System.Drawing.Size(32, 23);
            this.buttonAdv6.TabIndex = 51;
            this.buttonAdv6.Text = "buttonAdv6";
            // 
            // buttonAdv7
            // 
            this.buttonAdv7.BeforeTouchSize = new System.Drawing.Size(32, 23);
            this.buttonAdv7.IsBackStageButton = false;
            this.buttonAdv7.Location = new System.Drawing.Point(268, 83);
            this.buttonAdv7.Name = "buttonAdv7";
            this.buttonAdv7.Size = new System.Drawing.Size(32, 23);
            this.buttonAdv7.TabIndex = 52;
            this.buttonAdv7.Text = "buttonAdv7";
            // 
            // buttonAdv8
            // 
            this.buttonAdv8.BeforeTouchSize = new System.Drawing.Size(32, 23);
            this.buttonAdv8.IsBackStageButton = false;
            this.buttonAdv8.Location = new System.Drawing.Point(268, 112);
            this.buttonAdv8.Name = "buttonAdv8";
            this.buttonAdv8.Size = new System.Drawing.Size(32, 23);
            this.buttonAdv8.TabIndex = 53;
            this.buttonAdv8.Text = "buttonAdv8";
            // 
            // buttonAdv10
            // 
            this.buttonAdv10.BeforeTouchSize = new System.Drawing.Size(32, 23);
            this.buttonAdv10.IsBackStageButton = false;
            this.buttonAdv10.Location = new System.Drawing.Point(268, 141);
            this.buttonAdv10.Name = "buttonAdv10";
            this.buttonAdv10.Size = new System.Drawing.Size(32, 23);
            this.buttonAdv10.TabIndex = 55;
            this.buttonAdv10.Text = "buttonAdv10";
            // 
            // buttonAdv11
            // 
            this.buttonAdv11.BeforeTouchSize = new System.Drawing.Size(32, 23);
            this.buttonAdv11.IsBackStageButton = false;
            this.buttonAdv11.Location = new System.Drawing.Point(306, 25);
            this.buttonAdv11.Name = "buttonAdv11";
            this.buttonAdv11.Size = new System.Drawing.Size(32, 23);
            this.buttonAdv11.TabIndex = 56;
            this.buttonAdv11.Text = "buttonAdv11";
            // 
            // buttonAdv12
            // 
            this.buttonAdv12.BeforeTouchSize = new System.Drawing.Size(32, 23);
            this.buttonAdv12.IsBackStageButton = false;
            this.buttonAdv12.Location = new System.Drawing.Point(306, 54);
            this.buttonAdv12.Name = "buttonAdv12";
            this.buttonAdv12.Size = new System.Drawing.Size(32, 23);
            this.buttonAdv12.TabIndex = 57;
            this.buttonAdv12.Text = "buttonAdv12";
            // 
            // buttonAdv13
            // 
            this.buttonAdv13.BeforeTouchSize = new System.Drawing.Size(32, 23);
            this.buttonAdv13.IsBackStageButton = false;
            this.buttonAdv13.Location = new System.Drawing.Point(306, 83);
            this.buttonAdv13.Name = "buttonAdv13";
            this.buttonAdv13.Size = new System.Drawing.Size(32, 23);
            this.buttonAdv13.TabIndex = 58;
            this.buttonAdv13.Text = "buttonAdv13";
            // 
            // buttonAdv14
            // 
            this.buttonAdv14.BeforeTouchSize = new System.Drawing.Size(32, 23);
            this.buttonAdv14.IsBackStageButton = false;
            this.buttonAdv14.Location = new System.Drawing.Point(306, 112);
            this.buttonAdv14.Name = "buttonAdv14";
            this.buttonAdv14.Size = new System.Drawing.Size(32, 23);
            this.buttonAdv14.TabIndex = 59;
            this.buttonAdv14.Text = "buttonAdv14";
            // 
            // buttonAdv15
            // 
            this.buttonAdv15.BeforeTouchSize = new System.Drawing.Size(32, 23);
            this.buttonAdv15.IsBackStageButton = false;
            this.buttonAdv15.Location = new System.Drawing.Point(306, 141);
            this.buttonAdv15.Name = "buttonAdv15";
            this.buttonAdv15.Size = new System.Drawing.Size(32, 23);
            this.buttonAdv15.TabIndex = 60;
            this.buttonAdv15.Text = "buttonAdv15";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(15, 25);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(196, 173);
            this.listBox1.TabIndex = 61;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // buttonAdv16
            // 
            this.buttonAdv16.BeforeTouchSize = new System.Drawing.Size(32, 23);
            this.buttonAdv16.IsBackStageButton = false;
            this.buttonAdv16.Location = new System.Drawing.Point(306, 170);
            this.buttonAdv16.Name = "buttonAdv16";
            this.buttonAdv16.Size = new System.Drawing.Size(32, 23);
            this.buttonAdv16.TabIndex = 64;
            this.buttonAdv16.Text = "buttonAdv16";
            // 
            // buttonAdv17
            // 
            this.buttonAdv17.BeforeTouchSize = new System.Drawing.Size(32, 23);
            this.buttonAdv17.IsBackStageButton = false;
            this.buttonAdv17.Location = new System.Drawing.Point(268, 170);
            this.buttonAdv17.Name = "buttonAdv17";
            this.buttonAdv17.Size = new System.Drawing.Size(32, 23);
            this.buttonAdv17.TabIndex = 63;
            this.buttonAdv17.Text = "buttonAdv17";
            // 
            // buttonAdv1
            // 
            this.buttonAdv1.BeforeTouchSize = new System.Drawing.Size(32, 23);
            this.buttonAdv1.IsBackStageButton = false;
            this.buttonAdv1.Location = new System.Drawing.Point(230, 25);
            this.buttonAdv1.Name = "buttonAdv1";
            this.buttonAdv1.Size = new System.Drawing.Size(32, 23);
            this.buttonAdv1.TabIndex = 46;
            this.buttonAdv1.Text = "buttonAdv1";
            // 
            // buttonAdv2
            // 
            this.buttonAdv2.BeforeTouchSize = new System.Drawing.Size(32, 23);
            this.buttonAdv2.IsBackStageButton = false;
            this.buttonAdv2.Location = new System.Drawing.Point(230, 54);
            this.buttonAdv2.Name = "buttonAdv2";
            this.buttonAdv2.Size = new System.Drawing.Size(32, 23);
            this.buttonAdv2.TabIndex = 47;
            this.buttonAdv2.Text = "buttonAdv2";
            // 
            // buttonAdv3
            // 
            this.buttonAdv3.BeforeTouchSize = new System.Drawing.Size(32, 23);
            this.buttonAdv3.IsBackStageButton = false;
            this.buttonAdv3.Location = new System.Drawing.Point(230, 83);
            this.buttonAdv3.Name = "buttonAdv3";
            this.buttonAdv3.Size = new System.Drawing.Size(32, 23);
            this.buttonAdv3.TabIndex = 48;
            this.buttonAdv3.Text = "buttonAdv3";
            // 
            // buttonAdv4
            // 
            this.buttonAdv4.BeforeTouchSize = new System.Drawing.Size(32, 23);
            this.buttonAdv4.IsBackStageButton = false;
            this.buttonAdv4.Location = new System.Drawing.Point(230, 112);
            this.buttonAdv4.Name = "buttonAdv4";
            this.buttonAdv4.Size = new System.Drawing.Size(32, 23);
            this.buttonAdv4.TabIndex = 49;
            this.buttonAdv4.Text = "buttonAdv4";
            // 
            // buttonAdv9
            // 
            this.buttonAdv9.BeforeTouchSize = new System.Drawing.Size(32, 23);
            this.buttonAdv9.IsBackStageButton = false;
            this.buttonAdv9.Location = new System.Drawing.Point(230, 141);
            this.buttonAdv9.Name = "buttonAdv9";
            this.buttonAdv9.Size = new System.Drawing.Size(32, 23);
            this.buttonAdv9.TabIndex = 54;
            this.buttonAdv9.Text = "buttonAdv9";
            // 
            // buttonAdv18
            // 
            this.buttonAdv18.BeforeTouchSize = new System.Drawing.Size(32, 23);
            this.buttonAdv18.IsBackStageButton = false;
            this.buttonAdv18.Location = new System.Drawing.Point(230, 170);
            this.buttonAdv18.Name = "buttonAdv18";
            this.buttonAdv18.Size = new System.Drawing.Size(32, 23);
            this.buttonAdv18.TabIndex = 62;
            this.buttonAdv18.Text = "buttonAdv18";
            // 
            // FieldCalculatorView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(575, 417);
            this.Controls.Add(this.buttonAdv16);
            this.Controls.Add(this.buttonAdv17);
            this.Controls.Add(this.buttonAdv18);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.buttonAdv15);
            this.Controls.Add(this.buttonAdv14);
            this.Controls.Add(this.buttonAdv13);
            this.Controls.Add(this.buttonAdv12);
            this.Controls.Add(this.buttonAdv11);
            this.Controls.Add(this.buttonAdv10);
            this.Controls.Add(this.buttonAdv9);
            this.Controls.Add(this.buttonAdv8);
            this.Controls.Add(this.buttonAdv7);
            this.Controls.Add(this.buttonAdv6);
            this.Controls.Add(this.buttonAdv5);
            this.Controls.Add(this.buttonAdv4);
            this.Controls.Add(this.buttonAdv3);
            this.Controls.Add(this.buttonAdv2);
            this.Controls.Add(this.buttonAdv1);
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
            ((System.ComponentModel.ISupportInitialize)(this.functionTreeView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch)).EndInit();
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
        private Syncfusion.Windows.Forms.ButtonAdv buttonAdv5;
        private Syncfusion.Windows.Forms.ButtonAdv buttonAdv6;
        private Syncfusion.Windows.Forms.ButtonAdv buttonAdv7;
        private Syncfusion.Windows.Forms.ButtonAdv buttonAdv8;
        private Syncfusion.Windows.Forms.ButtonAdv buttonAdv10;
        private Syncfusion.Windows.Forms.ButtonAdv buttonAdv11;
        private Syncfusion.Windows.Forms.ButtonAdv buttonAdv12;
        private Syncfusion.Windows.Forms.ButtonAdv buttonAdv13;
        private Syncfusion.Windows.Forms.ButtonAdv buttonAdv14;
        private Syncfusion.Windows.Forms.ButtonAdv buttonAdv15;
        private System.Windows.Forms.ListBox listBox1;
        private Syncfusion.Windows.Forms.ButtonAdv buttonAdv16;
        private Syncfusion.Windows.Forms.ButtonAdv buttonAdv17;
        private Syncfusion.Windows.Forms.ButtonAdv buttonAdv1;
        private Syncfusion.Windows.Forms.ButtonAdv buttonAdv2;
        private Syncfusion.Windows.Forms.ButtonAdv buttonAdv3;
        private Syncfusion.Windows.Forms.ButtonAdv buttonAdv4;
        private Syncfusion.Windows.Forms.ButtonAdv buttonAdv9;
        private Syncfusion.Windows.Forms.ButtonAdv buttonAdv18;
    }
}