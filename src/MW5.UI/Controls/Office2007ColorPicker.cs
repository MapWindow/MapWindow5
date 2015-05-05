using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace MW5.UI.Controls
{
	public partial class Office2007ColorPicker : ComboBox
	{
		Office2007MenuHelper _colorPlate;

		[Browsable(true)]
		public event EventHandler SelectedColorChanged;

		[Browsable(true)]
		public Color Color
		{
			get { return this._colorPlate.ColorPlate.SelectedColor; }
			set
			{
				this._colorPlate.ColorPlate.SelectedColor = value;
				this.Invalidate();
			}
		}

		public Office2007ColorPicker()
		{
			InitializeComponent();
			OnInit();
		}

		public Office2007ColorPicker(IContainer container)
		{
			container.Add(this);
			InitializeComponent();
			OnInit();
		}

		private void OnInit()
		{
			SetStyle(ControlStyles.ResizeRedraw, true);
			SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

			this.Items.Add("Color");
			this.SelectedIndex = 0;

			this.DrawMode = DrawMode.OwnerDrawFixed;
			this.DropDownStyle = ComboBoxStyle.DropDownList;
            
            // lsu: modified !!
            this.DropDownHeight = 1;
            //Font fnt = new Font(this.Font.Name, 7);
            //this.Font = fnt;
            // end modification

			_colorPlate = new Office2007MenuHelper();
			_colorPlate.ColorPlate.SelectedColorChanged += new EventHandler(colorPlate_SelectedColorChanged);
		}

		private void colorPlate_SelectedColorChanged(object sender, EventArgs e)
		{
			if (SelectedColorChanged != null)
				SelectedColorChanged(this, new EventArgs());
		}

		private void ShowDropDown()
		{
			if (_colorPlate != null)
			{
                _colorPlate.Show(this, new Point(0, this.Height));
			    _colorPlate.Owner = this.FindForm();
			}
		}

		protected override void OnBindingContextChanged(EventArgs e)
		{
			base.OnBindingContextChanged(e);
			if (this.Items.Count != 1)
			{
				this.Items.Clear();
				this.Items.Add("Color");
				this.SelectedIndex = 0;
			}
		}

		protected override void OnDrawItem(DrawItemEventArgs e)
		{
			if (e.Index > -1)
			{
				// Paints the rectangle by the current color.
				e.Graphics.FillRectangle(new SolidBrush(this.Color), e.Bounds);
				Rectangle rec = new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width - 1, e.Bounds.Height - 1);

				if ((e.State & DrawItemState.Focus) == 0)
				{
					// Draw the border rectangle
					using (Pen pen = new Pen(Color.LightGray))
					{
						e.Graphics.DrawRectangle(pen, rec);
					}
				}
				else
				{
					// Draw the border rectangle
					using (Pen borderPen = new Pen(Color.LightGray, 1))
					{
						e.Graphics.DrawRectangle(borderPen, rec);
					}
					// Draw the focus rectangle
					Pen focusPen = new Pen(Color.Gray, 1);
					focusPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
					e.Graphics.DrawRectangle(focusPen, rec);
					focusPen.Dispose();
				}

                //// lsu: modified
                //Color clr = this.Color;
                //string s;
                //if (clr.IsNamedColor)
                //    s = clr.Name;
                //else
                //    s = clr.R.ToString() + "; " + clr.G.ToString() + "; " + clr.B.ToString();

                //// text color
                //if (((int)clr.R + (int)clr.G + (int)clr.B) > (255 * 3 / 2))
                //    base.ForeColor = Color.Black;
                //else
                //    base.ForeColor = Color.White;

                //e.Graphics.DrawString(s, base.Font, new SolidBrush(base.ForeColor), e.Bounds.Left, e.Bounds.Top);
                // lsu: add modification
			}
		}

		#region WndProc Code

		protected override void WndProc(ref Message m)
		{
			if (m.Msg == (WM_REFLECT + WM_COMMAND))
			{
				if (HIWord((int)m.WParam) == CBN_DROPDOWN)
				{
					ShowDropDown();
					return;
				}
			}
			base.WndProc(ref m);
		}

		private const int WM_USER = 0x0400;
		private const int WM_REFLECT = WM_USER + 0x1C00;
		private const int WM_COMMAND = 0x0111;
		private const int CBN_DROPDOWN = 7;

		public static int HIWord(int n)
		{
			return (n >> 16) & 0xffff;
		}

		#endregion
	}
}