using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Api;
using MW5.Api.Concrete;
using MW5.Api.Enums;
using MW5.Api.Interfaces;
using MW5.Plugins.Symbology.Helpers;
using MW5.UI.Controls;

namespace MW5.Plugins.Symbology.Controls.ImageCombo
{
    internal class ColorSchemeCombo: ImageComboBase
    {
        private SchemeTarget _schemeTarget;
        private ColorSchemeCollection _schemeList;

        public ColorSchemeCombo()
        {
            ComboStyle = SchemeType.Graduated;
        }

        public SchemeType ComboStyle { get; set; }

        /// <summary>
        /// Gets or sets the type of the color schemes to populate the combobox with.
        /// </summary>
        /// <remarks>This property must be set after control's size. </remarks>
        public SchemeTarget SchemeTarget
        {
            get { return _schemeTarget; }
            set
            {
                _schemeTarget = value;
                if (_schemeList == null || _schemeList.Type != SchemeTarget)
                {
                    UpdateItems();
                }
            }
        }

        public void UpdateItems()
        {
            if (_schemeList != null)
            {
                _schemeList.ListChanged -= OnListChanged;     // unsubscribe from the previous list
            }

            _schemeList = ColorSchemeProvider.GetList(SchemeTarget);
            if (_schemeList != null)
            {
                int index = SelectedIndex;

                _schemeList.ListChanged += OnListChanged;
                GenerateItems();

                if (index >= 0 && index < Items.Count)
                {
                    SelectedIndex = index;
                }
            }
        }

        private void OnListChanged(object sender, EventArgs args)
        {
            if (IsDisposed) return;    // TODO: unsubscribe controls from notifications

            int index = SelectedIndex;
            GenerateItems();
            SelectedIndex = _schemeList.SelectedIndex >= 0 ? _schemeList.SelectedIndex : index;
        }

        public void SetSelectedItem(ColorBlend blend)
        {
            for (int i = 0; i < _schemeList.List.Count; i++)
            {
                // TODO: after serialization we need to compare by value as references will be different
                if (_schemeList.List[i] == blend)
                {
                    SelectedIndex = i;
                    break;
                }
            }
        }

        [Browsable(false)]
        public ColorBlend GetSelectedItem()
        {
            return SelectedItem != null ? ColorSchemes.List[SelectedIndex] : null;
        }

        /// <summary>
        /// Gets the list of color schemes
        /// </summary>
        [Browsable(false)]
        public ColorSchemeCollection ColorSchemes
        {
            get { return _schemeList; }
        }

        /// <summary>
        /// Generates items for the given combo style
        /// </summary>
        private void GenerateItems()
        {
            Items.Clear();

            _itemCount = _schemeList != null ? _schemeList.List.Count : 0;

            for (var i = 0; i < _itemCount; i++)
            {
                Items.Add(new ImageComboItem(string.Empty, i));
            }

            RefreshImageList();
        }

        /// <summary>
        /// Fills the image list with icons according to the selected colors
        /// </summary>
        protected override void RefreshImageList()
        {
            _list.Images.Clear();

            var width = Width - 24;
            var sz = new Size(width, 16);
            _list.ImageSize = sz;

            int imgHeight = _list.ImageSize.Height;
            int imgWidth = _list.ImageSize.Width;

            var rect = new Rectangle(PADDING_X, PADDING_Y, imgWidth - 1 - PADDING_X * 2, imgHeight - 1 - PADDING_Y * 2);

            for (int i = 0; i < _itemCount; i++)
            {
                var img = new Bitmap(imgWidth, imgHeight, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                var g = Graphics.FromImage(img);

                if (_schemeList != null)
                {
                    switch (ComboStyle)
                    {
                        case SchemeType.Graduated:
                        {
                            var blend = _schemeList.List[i];
                            if (blend != null)
                            {
                                var lgb = new LinearGradientBrush(rect, Color.White, Color.White, 0.0f) {InterpolationColors = blend};
                                g.FillRectangle(lgb, rect);
                                g.DrawRectangle(new Pen(_outlineColor), rect);
                                lgb.Dispose();
                            }
                            break;
                        }
                        case SchemeType.Random:
                        {
                            var blend = _schemeList.List[i];
                            if (blend != null)
                            {
                                var scheme = blend.ToColorScheme();
                                if (scheme != null)
                                {
                                    int n = 0;
                                    var rnd = new Random();
                                    while (n < imgWidth)
                                    {
                                        var clr = scheme.GetRandomColor(rnd.NextDouble());
                                        var brush = new SolidBrush(clr);
                                        var rectTemp = new Rectangle(rect.X + n, rect.Y, 8, rect.Height);
                                        g.FillRectangle(brush, rectTemp);
                                        g.DrawRectangle(new Pen(_outlineColor), rectTemp);
                                        brush.Dispose();
                                        n += 8;
                                    }
                                }
                            }
                            break;
                        }
                        default:
                            return;
                    }
                }

                _list.Images.Add(img);
            }
        }

        /// <summary>
        /// Drawing procedure of a single item of list
        /// </summary>
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            if (!Enabled)
            {
                return;
            }

            base.OnDrawItem(e);
        }
    }
}
