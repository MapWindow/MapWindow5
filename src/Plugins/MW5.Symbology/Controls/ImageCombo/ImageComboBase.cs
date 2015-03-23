using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MW5.Plugins.Symbology.Controls.ImageCombo
{
    public abstract class ImageComboBase : ComboBox
    {
        protected const int PADDING_X = 1;
        protected const int PADDING_Y = 1;
        
        protected int _itemCount;
        protected Color _outlineColor;

        protected ImageList _list = new ImageList();

        protected ImageComboBase()
        {
            _list.ColorDepth = ColorDepth.Depth24Bit;
            OutlineColor = Color.Black;
            DrawMode = DrawMode.OwnerDrawFixed;
            DropDownStyle = ComboBoxStyle.DropDownList;
            EnabledChanged += (s, e) => RefreshImageList();
        }

        /// <summary>
        ///  Gets or sets bound ImageList
        /// </summary>
        public ImageList ImageList
        {
            get { return _list; }
            set { _list = value; }
        }

        /// <summary>
        /// The color to draw outline of the content
        /// </summary>
        public Color OutlineColor
        {
            get { return _outlineColor; }
            set { _outlineColor = value; }
        }

        protected abstract void RefreshImageList();

        /// <summary>
        /// Drawing procedure of a single item of list
        /// </summary>
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            // check if it is an item from the Items collection
            if (e.Index < 0)
            {
                // not an item, draw the text (indented)
                e.Graphics.DrawString(Text, e.Font, new SolidBrush(e.ForeColor), e.Bounds.Left + _list.ImageSize.Width, e.Bounds.Top);
                return;
            }

            if (Items[e.Index].GetType() != typeof(ImageComboItem))
            {
                // it is not an ImageComboItem, draw it
                e.Graphics.DrawString(Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), e.Bounds.Left + _list.ImageSize.Width, e.Bounds.Top);
                return;
            }
            
            // get item to draw
            var item = (ImageComboItem)Items[e.Index];

            if (Enabled)
            {
                e.Graphics.FillRectangle(new SolidBrush(BackColor), e.Bounds);
            }
            else
            {
                e.DrawBackground();
            }

            var textColor = Enabled ? Color.Black : Color.Gray;
            var forecolor = item.ForeColor;
            var font = item.Mark ? new Font(e.Font, FontStyle.Bold) : e.Font;

            if (item.ImageIndex != -1 && item.ImageIndex < ImageList.Images.Count)
            {
                // draw image
                ImageList.Draw(e.Graphics, e.Bounds.Left, e.Bounds.Top, item.ImageIndex);
                // draw text (indented)
                e.Graphics.DrawString(item.Text, font, new SolidBrush(textColor), e.Bounds.Left + _list.ImageSize.Width + 3 /*offset*/, e.Bounds.Top);
            }
            else
            {
                e.Graphics.DrawString(item.Text, font, new SolidBrush(forecolor), e.Bounds.Left + _list.ImageSize.Width, e.Bounds.Top);
            }

            if (((e.State & DrawItemState.Selected) != 0) && ((e.State & DrawItemState.ComboBoxEdit) == 0))
            {
                Pen pen = new Pen(textColor) { DashStyle = DashStyle.Dot };
                e.Graphics.DrawRectangle(pen, 0, e.Bounds.Top, e.Bounds.Width - 1, e.Bounds.Height - 1);
            }
        }
    }
}
