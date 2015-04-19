using System;
using System.Collections.Generic;
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

namespace MW5.Plugins.Symbology.Controls.ImageCombo
{
    internal class ColorSchemeCombo: ImageComboBase
    {
        private ColorSchemes _colorSchemeType;
        private ColorSchemeCollection _provider;

        public ColorSchemeCombo()
        {
            ComboStyle = ColorRampType.Graduated;
        }

        public ColorRampType ComboStyle { get; set; }

        /// <summary>
        /// Gets or sets the type of the color schemes to populate the combobox with.
        /// </summary>
        public ColorSchemes ColorSchemeType
        {
            get { return _colorSchemeType; }
            set
            {
                _colorSchemeType = value;
                if (_provider == null || _provider.Type != ColorSchemeType)
                {
                    UpdateItems();
                }
            }
        }

        public void UpdateItems()
        {
            if (_provider != null)
            {
                _provider.ListChanged -= OnListChanged;     // unsubscribe from the previous list
            }

            _provider = ColorSchemeProvider.GetList(ColorSchemeType);
            _provider.ListChanged += OnListChanged;
            GenerateItems();
        }

        private void OnListChanged(object sender, EventArgs args)
        {
            if (this.IsDisposed) return;    // TODO: unsubscribe controls from notifications

            int index = SelectedIndex;
            GenerateItems();
            SelectedIndex = _provider.SelectedIndex >= 0 ? _provider.SelectedIndex : index;
        }

        public void SetSelectedItem(ColorBlend blend)
        {
            for (int i = 0; i < _provider.List.Count; i++)
            {
                // TODO: after serialization we need to compare by value as references will be different
                if (_provider.List[i] == blend)
                {
                    SelectedIndex = i;
                    break;
                }
            }
        }

        public ColorBlend GetSelectedItem()
        {
            return SelectedItem != null ? ColorSchemes.List[SelectedIndex] : null;
        }

        /// <summary>
        /// Gets the list of color schemes
        /// </summary>
        public ColorSchemeCollection ColorSchemes
        {
            get { return _provider; }
        }

        /// <summary>
        /// Generates items for the given combo style
        /// </summary>
        private void GenerateItems()
        {
            Items.Clear();

            _itemCount = _provider != null ? _provider.List.Count : 0;

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

                switch (ComboStyle)
                {
                    case ColorRampType.Graduated:
                        {
                            if (_provider != null)
                            {
                                var blend = _provider.List[i];
                                if (blend != null)
                                {
                                    LinearGradientBrush lgb = new LinearGradientBrush(rect, Color.White, Color.White, 0.0f) {InterpolationColors = blend};
                                    g.FillRectangle(lgb, rect);
                                    g.DrawRectangle(new Pen(_outlineColor), rect);
                                    lgb.Dispose();
                                }
                            }
                            break;
                        }
                    case ColorRampType.Random:
                        {
                            if (_provider != null)
                            {
                                var blend = _provider.List[i];
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
                            }
                            break;
                        }
                    default: 
                        return;
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
