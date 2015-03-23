using System;
using System.Drawing;
using System.Windows.Forms;

namespace MW5.Plugins.Symbology.Controls.ColorPicker
{
	internal partial class Office2007MenuHelper : Form
	{
		Control _parentControl;

		private bool _freeze = false;
		public bool Freeze
		{
			get { return _freeze; }
			set { _freeze = value; }
		}

		public Office2007ColorPlate ColorPlate
		{
			get { return this.office2007ColorPlate1; }
		}

		public Office2007MenuHelper()
		{
			InitializeComponent();
		}

		public void Show(Control parent, Point location)
		{
			_parentControl = parent;
			this.Location = parent.PointToScreen(location);
			this.Show();
		}

		new public void Hide()
		{
			base.Hide();
			if (_parentControl != null)
			{
				Form parentForm = _parentControl.FindForm();
				if (parentForm != null)
				{
					parentForm.BringToFront();
				}
			}
		}

		private void Office2007MenuHelper_Deactivate(object sender, EventArgs e)
		{
			if (!_freeze)
			{
				Hide();
			}
		}

		private void Office2007MenuHelper_Leave(object sender, EventArgs e)
		{
			if (!_freeze)
			{
				Hide();
			}
		}

		private void office2007ColorPlate1_SelectedColorChanged(object sender, EventArgs e)
		{
			if (!_freeze)
			{
				Hide();
			}
		}

		DialogResult office2007ColorPlate1_ColorPaletteSelected(ref Color color)
		{
			_freeze = true;
			try
			{
				var dlg = new ColorDialog {FullOpen = true};
			    if (dlg.ShowDialog(this) == DialogResult.OK)
				{
					color = dlg.Color;
					_freeze = false;
					return DialogResult.OK;
				}
			}
			finally
			{
				_freeze = false;
			}
			return DialogResult.Cancel;
		}

		private void Office2007MenuHelper_Shown(object sender, EventArgs e)
		{

		}

	}
}