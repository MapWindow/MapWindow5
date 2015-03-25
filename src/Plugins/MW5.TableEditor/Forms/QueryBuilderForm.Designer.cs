namespace MW5.Plugins.TableEditor.Forms
{
    partial class QueryBuilderForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QueryBuilderForm));
            this.SplitContainer1 = new System.Windows.Forms.SplitContainer();
            this.Query_help = new System.Windows.Forms.Button();
            this.equals_op = new System.Windows.Forms.Button();
            this.notequal_op = new System.Windows.Forms.Button();
            this.lvFields = new System.Windows.Forms.ListView();
            this.chName = new System.Windows.Forms.ColumnHeader();
            this.chType = new System.Windows.Forms.ColumnHeader();
            this.greaterthan_op = new System.Windows.Forms.Button();
            this.Label1 = new System.Windows.Forms.Label();
            this.greaterthanorequal_op = new System.Windows.Forms.Button();
            this.lessthan_op = new System.Windows.Forms.Button();
            this.lessthanorequal_op = new System.Windows.Forms.Button();
            this.and_op = new System.Windows.Forms.Button();
            this.or_op = new System.Windows.Forms.Button();
            this.like_op = new System.Windows.Forms.Button();
            this.not_op = new System.Windows.Forms.Button();
            this.query_text_tb = new System.Windows.Forms.TextBox();
            this.lblNumFoundRows = new System.Windows.Forms.Label();
            this.btnClearQuery = new System.Windows.Forms.Button();
            this.Close_bn = new System.Windows.Forms.Button();
            this.Apply = new System.Windows.Forms.Button();
            this.SplitContainer1.Panel1.SuspendLayout();
            this.SplitContainer1.Panel2.SuspendLayout();
            this.SplitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // SplitContainer1
            // 
            resources.ApplyResources(this.SplitContainer1, "SplitContainer1");
            this.SplitContainer1.Name = "SplitContainer1";
            // 
            // SplitContainer1.Panel1
            // 
            this.SplitContainer1.Panel1.Controls.Add(this.Query_help);
            this.SplitContainer1.Panel1.Controls.Add(this.equals_op);
            this.SplitContainer1.Panel1.Controls.Add(this.notequal_op);
            this.SplitContainer1.Panel1.Controls.Add(this.lvFields);
            this.SplitContainer1.Panel1.Controls.Add(this.greaterthan_op);
            this.SplitContainer1.Panel1.Controls.Add(this.Label1);
            this.SplitContainer1.Panel1.Controls.Add(this.greaterthanorequal_op);
            this.SplitContainer1.Panel1.Controls.Add(this.lessthan_op);
            this.SplitContainer1.Panel1.Controls.Add(this.lessthanorequal_op);
            this.SplitContainer1.Panel1.Controls.Add(this.and_op);
            this.SplitContainer1.Panel1.Controls.Add(this.or_op);
            this.SplitContainer1.Panel1.Controls.Add(this.like_op);
            this.SplitContainer1.Panel1.Controls.Add(this.not_op);
            // 
            // SplitContainer1.Panel2
            // 
            this.SplitContainer1.Panel2.Controls.Add(this.query_text_tb);
            // 
            // Query_help
            // 
            resources.ApplyResources(this.Query_help, "Query_help");
            this.Query_help.Name = "Query_help";
            this.Query_help.Click += new System.EventHandler(this.Query_help_Click);
            // 
            // equals_op
            // 
            resources.ApplyResources(this.equals_op, "equals_op");
            this.equals_op.Name = "equals_op";
            this.equals_op.Click += new System.EventHandler(this.equals_op_Click);
            // 
            // notequal_op
            // 
            resources.ApplyResources(this.notequal_op, "notequal_op");
            this.notequal_op.Name = "notequal_op";
            this.notequal_op.Click += new System.EventHandler(this.notequal_op_Click);
            // 
            // lvFields
            // 
            resources.ApplyResources(this.lvFields, "lvFields");
            this.lvFields.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chName,
            this.chType});
            this.lvFields.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvFields.MultiSelect = false;
            this.lvFields.Name = "lvFields";
            this.lvFields.ShowItemToolTips = true;
            this.lvFields.UseCompatibleStateImageBehavior = false;
            this.lvFields.View = System.Windows.Forms.View.Details;
            this.lvFields.DoubleClick += new System.EventHandler(this.lvFields_DoubleClick);
            // 
            // chName
            // 
            resources.ApplyResources(this.chName, "chName");
            // 
            // chType
            // 
            resources.ApplyResources(this.chType, "chType");
            // 
            // greaterthan_op
            // 
            resources.ApplyResources(this.greaterthan_op, "greaterthan_op");
            this.greaterthan_op.Name = "greaterthan_op";
            this.greaterthan_op.Click += new System.EventHandler(this.greaterthan_op_Click);
            // 
            // Label1
            // 
            resources.ApplyResources(this.Label1, "Label1");
            this.Label1.Name = "Label1";
            // 
            // greaterthanorequal_op
            // 
            resources.ApplyResources(this.greaterthanorequal_op, "greaterthanorequal_op");
            this.greaterthanorequal_op.Name = "greaterthanorequal_op";
            this.greaterthanorequal_op.Click += new System.EventHandler(this.greaterthanorequal_op_Click);
            // 
            // lessthan_op
            // 
            resources.ApplyResources(this.lessthan_op, "lessthan_op");
            this.lessthan_op.Name = "lessthan_op";
            this.lessthan_op.Click += new System.EventHandler(this.lessthan_op_Click);
            // 
            // lessthanorequal_op
            // 
            resources.ApplyResources(this.lessthanorequal_op, "lessthanorequal_op");
            this.lessthanorequal_op.Name = "lessthanorequal_op";
            this.lessthanorequal_op.Click += new System.EventHandler(this.lessthanorequal_op_Click);
            // 
            // and_op
            // 
            resources.ApplyResources(this.and_op, "and_op");
            this.and_op.Name = "and_op";
            this.and_op.Click += new System.EventHandler(this.and_op_Click);
            // 
            // or_op
            // 
            resources.ApplyResources(this.or_op, "or_op");
            this.or_op.Name = "or_op";
            this.or_op.Click += new System.EventHandler(this.or_op_Click);
            // 
            // like_op
            // 
            resources.ApplyResources(this.like_op, "like_op");
            this.like_op.Name = "like_op";
            this.like_op.Click += new System.EventHandler(this.like_op_Click);
            // 
            // not_op
            // 
            resources.ApplyResources(this.not_op, "not_op");
            this.not_op.Name = "not_op";
            this.not_op.Click += new System.EventHandler(this.not_op_Click);
            // 
            // query_text_tb
            // 
            resources.ApplyResources(this.query_text_tb, "query_text_tb");
            this.query_text_tb.Name = "query_text_tb";
            // 
            // lblNumFoundRows
            // 
            resources.ApplyResources(this.lblNumFoundRows, "lblNumFoundRows");
            this.lblNumFoundRows.Name = "lblNumFoundRows";
            // 
            // btnClearQuery
            // 
            resources.ApplyResources(this.btnClearQuery, "btnClearQuery");
            this.btnClearQuery.Name = "btnClearQuery";
            this.btnClearQuery.UseVisualStyleBackColor = true;
            this.btnClearQuery.Click += new System.EventHandler(this.btnClearQuery_Click);
            // 
            // Close_bn
            // 
            resources.ApplyResources(this.Close_bn, "Close_bn");
            this.Close_bn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close_bn.Name = "Close_bn";
            this.Close_bn.Click += new System.EventHandler(this.Close_bn_Click);
            // 
            // Apply
            // 
            resources.ApplyResources(this.Apply, "Apply");
            this.Apply.Name = "Apply";
            this.Apply.Click += new System.EventHandler(this.Apply_Click);
            // 
            // frmQueryBuilder
            // 
            this.AcceptButton = this.Apply;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Close_bn;
            this.Controls.Add(this.SplitContainer1);
            this.Controls.Add(this.lblNumFoundRows);
            this.Controls.Add(this.btnClearQuery);
            this.Controls.Add(this.Close_bn);
            this.Controls.Add(this.Apply);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "QueryBuilderForm";
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmQueryBuilder_KeyDown);
            this.SplitContainer1.Panel1.ResumeLayout(false);
            this.SplitContainer1.Panel2.ResumeLayout(false);
            this.SplitContainer1.Panel2.PerformLayout();
            this.SplitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.SplitContainer SplitContainer1;
        internal System.Windows.Forms.Button Query_help;
        internal System.Windows.Forms.Button equals_op;
        internal System.Windows.Forms.Button notequal_op;
        internal System.Windows.Forms.ListView lvFields;
        internal System.Windows.Forms.ColumnHeader chName;
        internal System.Windows.Forms.ColumnHeader chType;
        internal System.Windows.Forms.Button greaterthan_op;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Button greaterthanorequal_op;
        internal System.Windows.Forms.Button lessthan_op;
        internal System.Windows.Forms.Button lessthanorequal_op;
        internal System.Windows.Forms.Button and_op;
        internal System.Windows.Forms.Button or_op;
        internal System.Windows.Forms.Button like_op;
        internal System.Windows.Forms.Button not_op;
        internal System.Windows.Forms.TextBox query_text_tb;
        internal System.Windows.Forms.Label lblNumFoundRows;
        internal System.Windows.Forms.Button btnClearQuery;
        internal System.Windows.Forms.Button Close_bn;
        internal System.Windows.Forms.Button Apply;

    }
}