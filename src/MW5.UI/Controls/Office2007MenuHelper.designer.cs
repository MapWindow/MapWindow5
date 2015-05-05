namespace MW5.UI.Controls
{
	internal partial class Office2007MenuHelper
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
            this.office2007ColorPlate1 = new Office2007ColorPlate();
            this.SuspendLayout();
            // 
            // office2007ColorPlate1
            // 
            this.office2007ColorPlate1.Location = new System.Drawing.Point(0, 0);
            this.office2007ColorPlate1.Name = "office2007ColorPlate1";
            this.office2007ColorPlate1.SelectedColor = System.Drawing.Color.Black;
            this.office2007ColorPlate1.Size = new System.Drawing.Size(155, 143);
            this.office2007ColorPlate1.TabIndex = 0;
            this.office2007ColorPlate1.ColorPaletteSelected += new Office2007ColorPlate.ColorPaletteSelectedHandler(this.office2007ColorPlate1_ColorPaletteSelected);
            this.office2007ColorPlate1.SelectedColorChanged += new System.EventHandler(this.office2007ColorPlate1_SelectedColorChanged);
            // 
            // Office2007MenuHelper
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(155, 143);
            this.ControlBox = false;
            this.Controls.Add(this.office2007ColorPlate1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Office2007MenuHelper";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Office2007MenuHelper";
            this.Deactivate += new System.EventHandler(this.Office2007MenuHelper_Deactivate);
            this.Shown += new System.EventHandler(this.Office2007MenuHelper_Shown);
            this.Leave += new System.EventHandler(this.Office2007MenuHelper_Leave);
            this.ResumeLayout(false);

		}

		#endregion

		private Office2007ColorPlate office2007ColorPlate1;
	}
}