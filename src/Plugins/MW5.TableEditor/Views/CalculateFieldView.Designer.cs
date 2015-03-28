namespace MW5.Plugins.TableEditor.Views
{
    partial class CalculateFieldView
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
            this.lstFunctions = new System.Windows.Forms.TreeView();
            this.LinkLabel2 = new System.Windows.Forms.LinkLabel();
            this.AssignmentLabel = new System.Windows.Forms.Label();
            this.btnMultiply = new System.Windows.Forms.Button();
            this.btnSubtract = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.ComputationTextBox = new System.Windows.Forms.TextBox();
            this.DestFieldComboBox = new System.Windows.Forms.ComboBox();
            this.DestFieldTitleLabel = new System.Windows.Forms.Label();
            this.FieldsTitleLabel = new System.Windows.Forms.Label();
            this.FieldsListView = new System.Windows.Forms.ListView();
            this.btnDivide = new System.Windows.Forms.Button();
            this.btnCancel = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnOk = new Syncfusion.Windows.Forms.ButtonAdv();
            this.SuspendLayout();
            // 
            // lstFunctions
            // 
            this.lstFunctions.Location = new System.Drawing.Point(259, 25);
            this.lstFunctions.Name = "lstFunctions";
            this.lstFunctions.Size = new System.Drawing.Size(140, 152);
            this.lstFunctions.TabIndex = 48;
            this.lstFunctions.DoubleClick += new System.EventHandler(this.lstFunctions_DoubleClick);
            // 
            // LinkLabel2
            // 
            this.LinkLabel2.AutoSize = true;
            this.LinkLabel2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LinkLabel2.Location = new System.Drawing.Point(215, 205);
            this.LinkLabel2.Name = "LinkLabel2";
            this.LinkLabel2.Size = new System.Drawing.Size(184, 13);
            this.LinkLabel2.TabIndex = 47;
            this.LinkLabel2.TabStop = true;
            this.LinkLabel2.Text = "Switch to String (Textual) Calculator...";
            // 
            // AssignmentLabel
            // 
            this.AssignmentLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.AssignmentLabel.Location = new System.Drawing.Point(176, 214);
            this.AssignmentLabel.Name = "AssignmentLabel";
            this.AssignmentLabel.Size = new System.Drawing.Size(16, 16);
            this.AssignmentLabel.TabIndex = 46;
            this.AssignmentLabel.Text = "=";
            // 
            // btnMultiply
            // 
            this.btnMultiply.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnMultiply.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnMultiply.Location = new System.Drawing.Point(349, 178);
            this.btnMultiply.Name = "btnMultiply";
            this.btnMultiply.Size = new System.Drawing.Size(24, 24);
            this.btnMultiply.TabIndex = 45;
            this.btnMultiply.Text = "*";
            // 
            // btnSubtract
            // 
            this.btnSubtract.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnSubtract.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSubtract.Location = new System.Drawing.Point(325, 178);
            this.btnSubtract.Name = "btnSubtract";
            this.btnSubtract.Size = new System.Drawing.Size(24, 24);
            this.btnSubtract.TabIndex = 44;
            this.btnSubtract.Text = "-";
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnAdd.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnAdd.Location = new System.Drawing.Point(301, 178);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(24, 24);
            this.btnAdd.TabIndex = 43;
            this.btnAdd.Text = "+";
            // 
            // ComputationTextBox
            // 
            this.ComputationTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ComputationTextBox.Location = new System.Drawing.Point(12, 241);
            this.ComputationTextBox.Multiline = true;
            this.ComputationTextBox.Name = "ComputationTextBox";
            this.ComputationTextBox.Size = new System.Drawing.Size(296, 128);
            this.ComputationTextBox.TabIndex = 40;
            // 
            // DestFieldComboBox
            // 
            this.DestFieldComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DestFieldComboBox.Location = new System.Drawing.Point(12, 209);
            this.DestFieldComboBox.Name = "DestFieldComboBox";
            this.DestFieldComboBox.Size = new System.Drawing.Size(160, 21);
            this.DestFieldComboBox.TabIndex = 36;
            // 
            // DestFieldTitleLabel
            // 
            this.DestFieldTitleLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.DestFieldTitleLabel.Location = new System.Drawing.Point(12, 193);
            this.DestFieldTitleLabel.Name = "DestFieldTitleLabel";
            this.DestFieldTitleLabel.Size = new System.Drawing.Size(128, 23);
            this.DestFieldTitleLabel.TabIndex = 39;
            this.DestFieldTitleLabel.Text = "Destination Table Field:";
            // 
            // FieldsTitleLabel
            // 
            this.FieldsTitleLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.FieldsTitleLabel.Location = new System.Drawing.Point(12, 9);
            this.FieldsTitleLabel.Name = "FieldsTitleLabel";
            this.FieldsTitleLabel.Size = new System.Drawing.Size(136, 16);
            this.FieldsTitleLabel.TabIndex = 38;
            this.FieldsTitleLabel.Text = "Table Fields:";
            // 
            // FieldsListView
            // 
            this.FieldsListView.Location = new System.Drawing.Point(12, 25);
            this.FieldsListView.Name = "FieldsListView";
            this.FieldsListView.Size = new System.Drawing.Size(240, 152);
            this.FieldsListView.TabIndex = 37;
            this.FieldsListView.UseCompatibleStateImageBehavior = false;
            this.FieldsListView.View = System.Windows.Forms.View.List;
            this.FieldsListView.DoubleClick += new System.EventHandler(this.FieldsListView_DoubleClick);
            // 
            // btnDivide
            // 
            this.btnDivide.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnDivide.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnDivide.Location = new System.Drawing.Point(375, 178);
            this.btnDivide.Name = "btnDivide";
            this.btnDivide.Size = new System.Drawing.Size(24, 24);
            this.btnDivide.TabIndex = 49;
            this.btnDivide.Text = "/";
            // 
            // btnCancel
            // 
            this.btnCancel.BeforeTouchSize = new System.Drawing.Size(75, 23);
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.IsBackStageButton = false;
            this.btnCancel.Location = new System.Drawing.Point(320, 346);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 50;
            this.btnCancel.Text = "Close";
            // 
            // btnOk
            // 
            this.btnOk.BeforeTouchSize = new System.Drawing.Size(75, 23);
            this.btnOk.IsBackStageButton = false;
            this.btnOk.Location = new System.Drawing.Point(320, 317);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 51;
            this.btnOk.Text = "Calculate";
            // 
            // CalculateFieldView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(407, 383);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDivide);
            this.Controls.Add(this.lstFunctions);
            this.Controls.Add(this.LinkLabel2);
            this.Controls.Add(this.AssignmentLabel);
            this.Controls.Add(this.btnMultiply);
            this.Controls.Add(this.btnSubtract);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.ComputationTextBox);
            this.Controls.Add(this.DestFieldComboBox);
            this.Controls.Add(this.DestFieldTitleLabel);
            this.Controls.Add(this.FieldsTitleLabel);
            this.Controls.Add(this.FieldsListView);
            this.Name = "CalculateFieldView";
            this.Text = "CalculateFieldView";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TreeView lstFunctions;
        internal System.Windows.Forms.LinkLabel LinkLabel2;
        internal System.Windows.Forms.Label AssignmentLabel;
        internal System.Windows.Forms.Button btnMultiply;
        internal System.Windows.Forms.Button btnSubtract;
        internal System.Windows.Forms.Button btnAdd;
        internal System.Windows.Forms.TextBox ComputationTextBox;
        internal System.Windows.Forms.ComboBox DestFieldComboBox;
        internal System.Windows.Forms.Label DestFieldTitleLabel;
        internal System.Windows.Forms.Label FieldsTitleLabel;
        internal System.Windows.Forms.ListView FieldsListView;
        internal System.Windows.Forms.Button btnDivide;
        private Syncfusion.Windows.Forms.ButtonAdv btnCancel;
        private Syncfusion.Windows.Forms.ButtonAdv btnOk;
    }
}