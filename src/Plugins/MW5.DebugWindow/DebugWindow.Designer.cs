namespace MW5.Plugins.DebugWindow
{
    partial class DebugWindow
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
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.DebugTextbox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // DebugTextbox
            // 
            this.DebugTextbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DebugTextbox.Location = new System.Drawing.Point(0, 0);
            this.DebugTextbox.Multiline = true;
            this.DebugTextbox.Name = "DebugTextbox";
            this.DebugTextbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DebugTextbox.Size = new System.Drawing.Size(575, 95);
            this.DebugTextbox.TabIndex = 3;
            // 
            // DebugWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.DebugTextbox);
            this.Name = "DebugWindow";
            this.Size = new System.Drawing.Size(575, 95);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox DebugTextbox;
    }
}
