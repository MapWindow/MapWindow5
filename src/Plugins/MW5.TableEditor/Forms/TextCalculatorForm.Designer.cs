namespace MW5.Plugins.TableEditor.Forms
{
    partial class TextCalculatorForm
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
          System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TextCalculatorForm));
          this.AssignmentLabel = new System.Windows.Forms.Label();
          this.DestFieldComboBox = new System.Windows.Forms.ComboBox();
          this.DestFieldTitleLabel = new System.Windows.Forms.Label();
          this.Label4 = new System.Windows.Forms.Label();
          this.functions_lb = new System.Windows.Forms.ListBox();
          this.Label1 = new System.Windows.Forms.Label();
          this.Close_bn = new System.Windows.Forms.Button();
          this.Apply = new System.Windows.Forms.Button();
          this.query_text_tb = new System.Windows.Forms.TextBox();
          this.Fields_lb = new System.Windows.Forms.ListBox();
          this.SuspendLayout();
          // 
          // AssignmentLabel
          // 
          resources.ApplyResources(this.AssignmentLabel, "AssignmentLabel");
          this.AssignmentLabel.Name = "AssignmentLabel";
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
          // Label4
          // 
          resources.ApplyResources(this.Label4, "Label4");
          this.Label4.Name = "Label4";
          // 
          // functions_lb
          // 
          this.functions_lb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
          this.functions_lb.Items.AddRange(new object[] {
            resources.GetString("functions_lb.Items"),
            resources.GetString("functions_lb.Items1"),
            resources.GetString("functions_lb.Items2"),
            resources.GetString("functions_lb.Items3"),
            resources.GetString("functions_lb.Items4"),
            resources.GetString("functions_lb.Items5")});
          resources.ApplyResources(this.functions_lb, "functions_lb");
          this.functions_lb.Name = "functions_lb";
          this.functions_lb.DoubleClick += new System.EventHandler(this.functions_lb_DoubleClick);
          // 
          // Label1
          // 
          resources.ApplyResources(this.Label1, "Label1");
          this.Label1.Name = "Label1";
          // 
          // Close_bn
          // 
          this.Close_bn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
          resources.ApplyResources(this.Close_bn, "Close_bn");
          this.Close_bn.Name = "Close_bn";
          this.Close_bn.Click += new System.EventHandler(this.Close_bn_Click);
          // 
          // Apply
          // 
          this.Apply.DialogResult = System.Windows.Forms.DialogResult.Cancel;
          resources.ApplyResources(this.Apply, "Apply");
          this.Apply.Name = "Apply";
          this.Apply.Click += new System.EventHandler(this.Apply_Click);
          // 
          // query_text_tb
          // 
          resources.ApplyResources(this.query_text_tb, "query_text_tb");
          this.query_text_tb.Name = "query_text_tb";
          // 
          // Fields_lb
          // 
          this.Fields_lb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
          resources.ApplyResources(this.Fields_lb, "Fields_lb");
          this.Fields_lb.Name = "Fields_lb";
          this.Fields_lb.Sorted = true;
          this.Fields_lb.DoubleClick += new System.EventHandler(this.Fields_lb_DoubleClick);
          // 
          // frmTextCalculator
          // 
          resources.ApplyResources(this, "$this");
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.CancelButton = this.Close_bn;
          this.ControlBox = false;
          this.Controls.Add(this.AssignmentLabel);
          this.Controls.Add(this.DestFieldComboBox);
          this.Controls.Add(this.DestFieldTitleLabel);
          this.Controls.Add(this.Label4);
          this.Controls.Add(this.functions_lb);
          this.Controls.Add(this.Label1);
          this.Controls.Add(this.Close_bn);
          this.Controls.Add(this.Apply);
          this.Controls.Add(this.query_text_tb);
          this.Controls.Add(this.Fields_lb);
          this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
          this.Name = "TextCalculatorForm";
          this.ShowInTaskbar = false;
          this.TopMost = true;
          this.ResumeLayout(false);
          this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label AssignmentLabel;
        internal System.Windows.Forms.ComboBox DestFieldComboBox;
        internal System.Windows.Forms.Label DestFieldTitleLabel;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.ListBox functions_lb;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Button Close_bn;
        internal System.Windows.Forms.Button Apply;
        internal System.Windows.Forms.TextBox query_text_tb;
        internal System.Windows.Forms.ListBox Fields_lb;
    }
}