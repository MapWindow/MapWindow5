using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using MW5.UI.Properties;

namespace MW5.UI.Controls
{
    [DesignTimeVisible(false)]
	internal partial class Office2007ColorPlate : UserControl
	{
		private Size ColorBoxSize = new Size(12, 12);
		private const int ColorBoxUnit = 12;
		private const int ColorBoxMarginX = 3;
		private const int ColorMatrixX = 10;
		private const int ColorMatrixY = 7;
		private const int TopBoxMargin1 = ColorBoxUnit + 4;
		private const int TopBoxMargin2 = TopBoxMargin1 + ColorBoxUnit + 4;
		private const int TopBoxMargin3 = TopBoxMargin2 + 6 * ColorBoxUnit + 8;

        Font _font = new Font("Tahoma", 8, FontStyle.Bold);
		private Point _selectedBox = new Point(-1, -1);
		private bool _isPaletteSelected = false;

		Color[,] _colorMatrix;

		private Color _selectedColor = Color.Black;
		public Color SelectedColor
		{
			get { return _selectedColor; }
			set
			{
				_selectedColor = value;
				Refresh();
				OnSelectedColorChanged();
			}
		}

		public event EventHandler SelectedColorChanged;
		public delegate DialogResult ColorPaletteSelectedHandler(ref Color color);
		public event ColorPaletteSelectedHandler ColorPaletteSelected;

		public Office2007ColorPlate()
		{
			SetStyle(ControlStyles.DoubleBuffer, true);
			SetStyle(ControlStyles.AllPaintingInWmPaint, true);
			SetStyle(ControlStyles.ResizeRedraw, true);
			SetStyle(ControlStyles.SupportsTransparentBackColor, true);
			InitializeComponent();
			CreateColorMatrix();
		}

		private void CreateColorMatrix()
		{
			_colorMatrix = new Color[,] { 
					{ C(255, 255, 255), C(210, 210, 210), C(186, 186, 186), C(154, 154, 154), 
						C(130, 130, 130), C(114, 114, 114), C(178, 014, 018) }, 
					{ C(000, 000, 000), C(114, 114, 114), C(106, 106, 106), C(078, 078, 078), 
						C(054, 054, 054), C(030, 030, 030), C(234, 022, 030) }, 
					{ C(246, 234, 210), C(182, 174, 166), C(154, 150, 142), C(114, 110, 106), 
						C(078, 074, 070), C(054, 050, 050), C(254, 186, 010) }, 
					{ C(026, 062, 114), C(194, 206, 218), C(134, 154, 182), C(078, 106, 150), 
						C(018, 046, 082), C(010, 030, 054), C(255, 255, 000) }, 
					{ C(082, 122, 174), C(210, 222, 243), C(166, 186, 214), C(122, 154, 194), 
						C(058, 086, 126), C(038, 054, 078), C(150, 214, 066) }, 
					{ C(186, 070, 066), C(238, 206, 206), C(218, 158, 158), C(202, 114, 110), 
						C(134, 050, 046), C(086, 034, 030), C(026, 170, 066) }, 
					{ C(150, 182, 086), C(226, 238, 210), C(202, 218, 170), C(174, 198, 126), 
						C(106, 130, 062), C(066, 082, 038), C(002, 178, 238) }, 
					{ C(128, 102, 160), C(223, 216, 231), C(191, 178, 207), C(159, 140, 183), 
						C(096, 076, 120), C(064, 051, 080), C(000, 114, 188) }, 
					{ C(075, 172, 198), C(210, 234, 240), C(165, 213, 226), C(120, 192, 212), 
						C(056, 129, 148), C(037, 086, 099), C(047, 054, 153) }, 
					{ C(245, 157, 086), C(252, 230, 212), C(250, 206, 170), C(247, 181, 128), 
						C(183, 117, 064), C(122, 078, 043), C(111, 049, 152) }
				};


		}

		private Color C(int red, int green, int blue)
		{
			return Color.FromArgb(red, green, blue);
		}

		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);
			_selectedBox = GetSelectedBox(e.Location);
			Invalidate();
		}

		private Point GetSelectedBox(Point mouseLocation)
		{
			int x = -1;
			int y = -1;
			bool isPaletteSelected = false;
			if (mouseLocation.Y >= TopBoxMargin1 
				&& mouseLocation.Y <= TopBoxMargin1 + ColorBoxUnit)
			{
				y = 0;
			}
			else if (mouseLocation.Y >= TopBoxMargin2 
				&& mouseLocation.Y <= TopBoxMargin2 + 5 * ColorBoxUnit)
			{
				y = (mouseLocation.Y - TopBoxMargin2) / ColorBoxUnit + 1;
			}
			else if (mouseLocation.Y >= TopBoxMargin3 
				&& mouseLocation.Y <= TopBoxMargin3 + ColorBoxUnit)
			{
				y = 6;
			}
			else if (mouseLocation.Y > TopBoxMargin3 + ColorBoxUnit)
			{
				isPaletteSelected = true;
			}

			int tmp = (mouseLocation.X - ColorBoxMarginX) 
				% (ColorBoxUnit + ColorBoxMarginX);
			if (tmp >= 0 && tmp <= ColorBoxUnit)
			{
				x = (mouseLocation.X - ColorBoxMarginX) 
					/ (ColorBoxUnit + ColorBoxMarginX);
				if (x >= 10) x = -1;
			}
			_isPaletteSelected = isPaletteSelected;
			return new Point(x, y);
		}

		protected override void OnMouseClick(MouseEventArgs e)
		{
			base.OnMouseClick(e);

			if (_isPaletteSelected)
			{
				if (this.ColorPaletteSelected != null)
				{
					Color color = Color.White;
					if (this.ColorPaletteSelected(ref color) == DialogResult.OK)
					{
						this.SelectedColor = color;
					}
				}
			}
			if (_selectedBox.X > -1 && _selectedBox.Y > -1)
			{
				_selectedColor = _colorMatrix[_selectedBox.X, _selectedBox.Y];
				OnSelectedColorChanged();
			}
		}

		private void OnSelectedColorChanged()
		{
			if (this.SelectedColorChanged != null)
				this.SelectedColorChanged(this, new EventArgs());
		}

		#region Drawing

		protected override void OnPaintBackground(PaintEventArgs e)
		{
			base.OnPaintBackground(e);
			DrawBackground(e.Graphics);
		}

		private void DrawBackground(Graphics graphics)
		{
			graphics.FillRectangle(new SolidBrush(Color.FromArgb(250, 250, 250)), 
				this.ClientRectangle);
			graphics.FillRectangle(new SolidBrush(Color.FromArgb(221, 231, 238)),
				new Rectangle(2, 2, this.Width - 4, ColorBoxUnit));
			
			graphics.FillRectangle(new SolidBrush(Color.FromArgb(221, 231, 238)),
				new Rectangle(2, TopBoxMargin2 + 5 * ColorBoxUnit + 5, this.Width - 4, 
				ColorBoxUnit));
		}


		private void Office2007ColorPlate_Paint(object sender, PaintEventArgs e)
		{
			DrawColorBoxes(e.Graphics);
			DrawTexts(e.Graphics, _font);
			DrawBorder(e.Graphics);
			DrawSelectedBox(e.Graphics);
			DrawPalette(e.Graphics);
		}

		private void DrawBorder(Graphics graphics)
		{
			graphics.DrawRectangle(new Pen(Color.LightGray), 0, 0, 
				(ColorBoxUnit + ColorBoxMarginX) * ColorMatrixX + ColorBoxMarginX + 1, 
				TopBoxMargin3 + 30);
		}

		private void DrawTexts(Graphics graphics, Font font)
		{
			graphics.DrawString("Theme colors", font, new SolidBrush(Color.Navy), 1, 1);
			graphics.DrawString("Standard", font, 
				new SolidBrush(Color.Navy), 1, TopBoxMargin2 + 5 * ColorBoxUnit + 4);
		}

		private void DrawColorBoxes(Graphics graphics)
		{
			DrawColorBelt(graphics, 0, TopBoxMargin1, true);
			for (int i = 1; i < ColorMatrixY - 1; i++)
			{
				DrawColorBelt(graphics, i, (i - 1) * ColorBoxUnit + TopBoxMargin2, false);
			}
			for (int i = 0; i < ColorMatrixX; i++)
			{
				graphics.DrawRectangle(new Pen(Color.Gray), 
					i * (ColorBoxUnit + ColorBoxMarginX) + ColorBoxMarginX, 
					TopBoxMargin2, ColorBoxUnit, ColorBoxUnit * 5);
			}
			DrawColorBelt(graphics, ColorMatrixY - 1, TopBoxMargin3, true);
		}

		private void DrawColorBelt(Graphics graphics, int no, int yOffSet, bool border)
		{
			for (int i = 0; i < ColorMatrixX; i++)
			{
				DrawColorBox(graphics, _colorMatrix[i, no], 
					new Point(i * (ColorBoxUnit + ColorBoxMarginX) + ColorBoxMarginX, yOffSet), 
					border);
			}
		}

		private void DrawColorBox(Graphics graphics, Color color, Point location, bool border)
		{
			graphics.FillRectangle(new SolidBrush(color), new Rectangle(location, ColorBoxSize));
			if (border)
			{
				graphics.DrawRectangle(new Pen(Color.LightGray), 
					new Rectangle(location, ColorBoxSize));
			}
		}

		private void DrawSelectedBox(Graphics graphics)
		{
			if (_selectedBox.X > -1 && _selectedBox.Y > -1)
			{
				Point point = new Point(0, 0);

				point.X = _selectedBox.X * (ColorBoxUnit + 3) + 3;

				if (_selectedBox.Y == 0)
					point.Y = TopBoxMargin1;
				else if (_selectedBox.Y == 6)
					point.Y = TopBoxMargin3;
				else
					point.Y = TopBoxMargin2 + (_selectedBox.Y - 1) * ColorBoxUnit;

				graphics.DrawRectangle(new Pen(Color.White), new Rectangle(point, ColorBoxSize));
				graphics.DrawRectangle(new Pen(Color.OrangeRed), point.X - 1, 
					point.Y - 1, ColorBoxUnit + 2, ColorBoxUnit + 2);
			}
		}

		private void DrawPalette(Graphics graphics)
		{
			graphics.DrawImage(Resources.palette, 2, TopBoxMargin3 + ColorBoxUnit + 2);
			graphics.DrawString("Pallete..", _font, new SolidBrush(Color.Navy), 
				20, TopBoxMargin3 + ColorBoxUnit + 2);
			if (_isPaletteSelected)
			{
				graphics.DrawRectangle(new Pen(Color.Gray), 2, 
					TopBoxMargin3 + ColorBoxUnit + 2, this.Width - 5, ColorBoxUnit + 2);
			}
		}

		#endregion
	}
}