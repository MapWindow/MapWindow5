namespace MW5.Plugins.TableEditor.Forms
{
    partial class DeleteFieldForm
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
          System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeleteFieldForm));
          this.clb = new System.Windows.Forms.CheckedListBox();
          this.btnCancel = new System.Windows.Forms.Button();
          this.btnOK = new System.Windows.Forms.Button();
          this.Label1 = new System.Windows.Forms.Label();
          this.SuspendLayout();
          // 
          // clb
          // 
          resources.ApplyResources(this.clb, "clb");
          this.clb.CheckOnClick = true;
          this.clb.FormattingEnabled = true;
          this.clb.Name = "clb";
          this.clb.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clb_ItemCheck);
          // 
          // btnCancel
          // 
          resources.ApplyResources(this.btnCancel, "btnCancel");
          this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
          this.btnCancel.Name = "btnCancel";
          // 
          // btnOK
          // 
          resources.ApplyResources(this.btnOK, "btnOK");
          this.btnOK.Name = "btnOK";
          this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
          // 
          // Label1
          // 
          resources.ApplyResources(this.Label1, "Label1");
          this.Label1.Name = "Label1";
          // 
          // frmDeleteField
          // 
          this.AcceptButton = this.btnOK;
          resources.ApplyResources(this, "$this");
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.CancelButton = this.btnCancel;
          this.ControlBox = false;
          this.Controls.Add(this.clb);
          this.Controls.Add(this.btnCancel);
          this.Controls.Add(this.btnOK);
          this.Controls.Add(this.Label1);
          this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
          this.MaximizeBox = false;
          this.MinimizeBox = false;
          this.Name = "DeleteFieldForm";
          this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.CheckedListBox clb;
        internal System.Windows.Forms.Button btnCancel;
        internal System.Windows.Forms.Button btnOK;
        internal System.Windows.Forms.Label Label1;
    }
}