namespace MW5.Plugins.TableEditor.Forms
{
    partial class FieldCalculatorForm
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
          System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FieldCalculatorForm));
          this.lstFunctions = new System.Windows.Forms.TreeView();
          this.LinkLabel2 = new System.Windows.Forms.LinkLabel();
          this.AssignmentLabel = new System.Windows.Forms.Label();
          this.btnDivide = new System.Windows.Forms.Button();
          this.btnMultiply = new System.Windows.Forms.Button();
          this.btnSubtract = new System.Windows.Forms.Button();
          this.btnAdd = new System.Windows.Forms.Button();
          this.btnCancel = new System.Windows.Forms.Button();
          this.btnOK = new System.Windows.Forms.Button();
          this.ComputationTextBox = new System.Windows.Forms.TextBox();
          this.DestFieldComboBox = new System.Windows.Forms.ComboBox();
          this.DestFieldTitleLabel = new System.Windows.Forms.Label();
          this.FieldsTitleLabel = new System.Windows.Forms.Label();
          this.FieldsListView = new System.Windows.Forms.ListView();
          this.SuspendLayout();
          // 
          // lstFunctions
          // 
          resources.ApplyResources(this.lstFunctions, "lstFunctions");
          this.lstFunctions.Name = "lstFunctions";
          this.lstFunctions.DoubleClick += new System.EventHandler(this.lstFunctions_DoubleClick);
          // 
          // LinkLabel2
          // 
          resources.ApplyResources(this.LinkLabel2, "LinkLabel2");
          this.LinkLabel2.Name = "LinkLabel2";
          this.LinkLabel2.TabStop = true;
          this.LinkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel2_LinkClicked);
          // 
          // AssignmentLabel
          // 
          resources.ApplyResources(this.AssignmentLabel, "AssignmentLabel");
          this.AssignmentLabel.Name = "AssignmentLabel";
          // 
          // btnDivide
          // 
          resources.ApplyResources(this.btnDivide, "btnDivide");
          this.btnDivide.Name = "btnDivide";
          this.btnDivide.Click += new System.EventHandler(this.btnDivide_Click);
          // 
          // btnMultiply
          // 
          resources.ApplyResources(this.btnMultiply, "btnMultiply");
          this.btnMultiply.Name = "btnMultiply";
          this.btnMultiply.Click += new System.EventHandler(this.btnMultiply_Click);
          // 
          // btnSubtract
          // 
          resources.ApplyResources(this.btnSubtract, "btnSubtract");
          this.btnSubtract.Name = "btnSubtract";
          this.btnSubtract.Click += new System.EventHandler(this.btnSubtract_Click);
          // 
          // btnAdd
          // 
          resources.ApplyResources(this.btnAdd, "btnAdd");
          this.btnAdd.Name = "btnAdd";
          this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
          // 
          // btnCancel
          // 
          this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
          resources.ApplyResources(this.btnCancel, "btnCancel");
          this.btnCancel.Name = "btnCancel";
          this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
          // 
          // btnOK
          // 
          resources.ApplyResources(this.btnOK, "btnOK");
          this.btnOK.Name = "btnOK";
          this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
          // 
          // ComputationTextBox
          // 
          resources.ApplyResources(this.ComputationTextBox, "ComputationTextBox");
          this.ComputationTextBox.Name = "ComputationTextBox";
          // 
          // DestFieldComboBox
          // 
          this.DestFieldComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
          resources.ApplyResources(this.DestFieldComboBox, "DestFieldComboBox");
          this.DestFieldComboBox.Name = "DestFieldComboBox";
          // 
          // DestFieldTitleLabel
          // 
          resources.ApplyResources(this.DestFieldTitleLabel, "DestFieldTitleLabel");
          this.DestFieldTitleLabel.Name = "DestFieldTitleLabel";
          // 
          // FieldsTitleLabel
          // 
          resources.ApplyResources(this.FieldsTitleLabel, "FieldsTitleLabel");
          this.FieldsTitleLabel.Name = "FieldsTitleLabel";
          // 
          // FieldsListView
          // 
          resources.ApplyResources(this.FieldsListView, "FieldsListView");
          this.FieldsListView.Name = "FieldsListView";
          this.FieldsListView.UseCompatibleStateImageBehavior = false;
          this.FieldsListView.View = System.Windows.Forms.View.List;
          this.FieldsListView.DoubleClick += new System.EventHandler(this.FieldsListView_DoubleClick);
          // 
          // frmFieldCalculator
          // 
          resources.ApplyResources(this, "$this");
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.Controls.Add(this.lstFunctions);
          this.Controls.Add(this.LinkLabel2);
          this.Controls.Add(this.AssignmentLabel);
          this.Controls.Add(this.btnDivide);
          this.Controls.Add(this.btnMultiply);
          this.Controls.Add(this.btnSubtract);
          this.Controls.Add(this.btnAdd);
          this.Controls.Add(this.btnCancel);
          this.Controls.Add(this.btnOK);
          this.Controls.Add(this.ComputationTextBox);
          this.Controls.Add(this.DestFieldComboBox);
          this.Controls.Add(this.DestFieldTitleLabel);
          this.Controls.Add(this.FieldsTitleLabel);
          this.Controls.Add(this.FieldsListView);
          this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
          this.MaximizeBox = false;
          this.MinimizeBox = false;
          this.Name = "FieldCalculatorForm";
          this.ShowInTaskbar = false;
          this.ResumeLayout(false);
          this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TreeView lstFunctions;
        internal System.Windows.Forms.LinkLabel LinkLabel2;
        internal System.Windows.Forms.Label AssignmentLabel;
        internal System.Windows.Forms.Button btnDivide;
        internal System.Windows.Forms.Button btnMultiply;
        internal System.Windows.Forms.Button btnSubtract;
        internal System.Windows.Forms.Button btnAdd;
        internal System.Windows.Forms.Button btnCancel;
        internal System.Windows.Forms.Button btnOK;
        internal System.Windows.Forms.TextBox ComputationTextBox;
        internal System.Windows.Forms.ComboBox DestFieldComboBox;
        internal System.Windows.Forms.Label DestFieldTitleLabel;
        internal System.Windows.Forms.Label FieldsTitleLabel;
        internal System.Windows.Forms.ListView FieldsListView;
    }
}