namespace MW5.Mvp.Sample
{
    partial class SampleView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SampleView));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.mnuTestMenu = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnOk = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnTestButton = new Syncfusion.Windows.Forms.ButtonAdv();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(24, 44);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(238, 20);
            this.textBox1.TabIndex = 1;
            // 
            // mnuTestMenu
            // 
            this.mnuTestMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.mnuTestMenu.Image = ((System.Drawing.Image)(resources.GetObject("mnuTestMenu.Image")));
            this.mnuTestMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuTestMenu.Name = "mnuTestMenu";
            this.mnuTestMenu.Size = new System.Drawing.Size(67, 22);
            this.mnuTestMenu.Text = "Test menu";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuTestMenu});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(344, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnOk
            // 
            this.btnOk.BeforeTouchSize = new System.Drawing.Size(75, 23);
            this.btnOk.IsBackStageButton = false;
            this.btnOk.Location = new System.Drawing.Point(257, 85);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "Ok";
            // 
            // btnTestButton
            // 
            this.btnTestButton.BeforeTouchSize = new System.Drawing.Size(96, 23);
            this.btnTestButton.IsBackStageButton = false;
            this.btnTestButton.Location = new System.Drawing.Point(24, 85);
            this.btnTestButton.Name = "btnTestButton";
            this.btnTestButton.Size = new System.Drawing.Size(96, 23);
            this.btnTestButton.TabIndex = 3;
            this.btnTestButton.Text = "Test button";
            // 
            // SampleView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 120);
            this.Controls.Add(this.btnTestButton);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "SampleView";
            this.Text = "SampleView";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ToolStripButton mnuTestMenu;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private Syncfusion.Windows.Forms.ButtonAdv btnOk;
        private Syncfusion.Windows.Forms.ButtonAdv btnTestButton;

    }
}