using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Syncfusion.Windows.Forms.Tools;
using Action = System.Action;

namespace MW5.Plugins.Symbology.Controls.ImageCombo
{
    public abstract class ImageComboBase : ComboBox //ComboBoxAdv
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
            DropDownStyle = ComboBoxStyle.DropDownList;
            EnabledChanged += (s, e) => RefreshImageList();

            DrawMode = DrawMode.OwnerDrawFixed;
        }

        [Browsable(false)]
        public new DrawMode DrawMode
        {
            get { return base.DrawMode; }
            set { base.DrawMode = value; }
        }

        [Browsable(false)]
        public new ComboBoxStyle DropDownStyle
        {
            get { return base.DropDownStyle; }
            set { base.DropDownStyle = value; }
        }

        #if COMBOBOX_ADV

        private void InitDrawMode()
        {
            ListBox.DrawMode = DrawMode.OwnerDrawFixed;
            ListBox.DrawItem += ListBox_DrawItem;
        }

        public DrawMode DrawMode
        {
            get { return ListBox.DrawMode; }
            set { ListBox.DrawMode = value; }
        }

        public bool FormattingEnabled { get; set; }

        protected override void DrawEditPortion(PaintEventArgs e)
        {
            //base.DrawEditPortion(e);

            DrawItem(SelectedIndex, e.ClipRectangle, e.Graphics, Font, ForeColor, DrawItemState.Default, () => { });
        }

        void ListBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            DrawItem(e.Index, e.Bounds, e.Graphics, e.Font, e.ForeColor, e.State, e.DrawBackground);
        }

        #endif

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            DrawItemCore(e.Index, e.Bounds, e.Graphics, e.Font, e.ForeColor, e.State, e.DrawBackground);
        }

        private void DrawItemCore(int itemIndex, Rectangle bounds, Graphics g, Font initFont, Color foreColor, DrawItemState state, Action drawBackground)
        {
            // check if it is an item from the Items collection
            if (itemIndex < 0)
            {
                // not an item, draw the text (indented)
                g.DrawString(Text, initFont, new SolidBrush(foreColor), bounds.Left + _list.ImageSize.Width, bounds.Top);
                return;
            }

            if (Items[itemIndex].GetType() != typeof(ImageComboItem))
            {
                // it is not an ImageComboItem, draw it
                g.DrawString(Items[itemIndex].ToString(), initFont, new SolidBrush(foreColor), bounds.Left + _list.ImageSize.Width, bounds.Top);
                return;
            }

            // get item to draw
            var item = (ImageComboItem)Items[itemIndex];

            if (Enabled)
            {
                g.FillRectangle(new SolidBrush(BackColor), bounds);
            }
            else
            {
                drawBackground();
            }

            var textColor = Enabled ? Color.Black : Color.Gray;
            var forecolor = item.ForeColor;
            var font = item.Mark ? new Font(initFont, FontStyle.Bold) : initFont;

            if (item.ImageIndex != -1 && item.ImageIndex < ImageList.Images.Count)
            {
                int offset = (bounds.Height - ImageList.ImageSize.Height)/2;
                ImageList.Draw(g, bounds.Left, bounds.Top + offset, item.ImageIndex);
                
                // draw text (indented)
                g.DrawString(item.Text, font, new SolidBrush(textColor), bounds.Left + _list.ImageSize.Width + 3 /*offset*/, bounds.Top);
            }
            else
            {
                g.DrawString(item.Text, font, new SolidBrush(forecolor), bounds.Left + _list.ImageSize.Width, bounds.Top);
            }

            if (((state & DrawItemState.Selected) != 0) && ((state & DrawItemState.ComboBoxEdit) == 0))
            {
                Pen pen = new Pen(textColor) { DashStyle = DashStyle.Dot };
                g.DrawRectangle(pen, 0, bounds.Top, bounds.Width - 1, bounds.Height - 1);
            }
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
    }
}
