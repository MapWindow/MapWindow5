// -------------------------------------------------------------------------------------------
// <copyright file="LayoutBitmap.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Imaging;
using System.IO;
using MW5.Plugins.Printing.Controls.PropertyGrid;
using MW5.Plugins.Printing.Enums;

namespace MW5.Plugins.Printing.Model.Elements
{
    /// <summary>
    /// The layout bitmap provides the ability to add any custom image to the layout
    /// </summary>
    public class LayoutBitmap : LayoutElement, IDisposable
    {
        private Bitmap _bitmap;
        private int _brightness;
        private int _contrast;
        private bool _draft;
        private string _filename;
        private bool _preserveAspectRatio;

        /// <summary>
        /// Constructor
        /// </summary>
        public LayoutBitmap()
        {
            Name = "Bitmap";
            ResizeStyle = ResizeStyle.HandledInternally;
            ResizeStyle = ResizeStyle.StretchToFit;
            _preserveAspectRatio = true;
            _draft = true;
            _filename = string.Empty;
            _brightness = 0;
            _contrast = 0;
        }

        /// <summary>
        /// Modifies the brightness of the bitmap relative to its original brightness +/- 255 Doesn't modify original bitmap
        /// </summary>
        [Browsable(true)]
        [DefaultValue(0)]
        [CategoryEx(@"cat_symbol")]
        [DisplayNameEx(@"prop_brightness")]
        public int Brightness
        {
            get { return _brightness; }
            set
            {
                if (value < -255) _brightness = -255;
                else if (value > 255) _brightness = 255;
                else _brightness = value;
                RefreshElement();
            }
        }

        /// <summary>
        /// Modifies the contrast of the bitmap relative to its original contrast +/- 255 Doesn't modify original bitmap
        /// </summary>
        [Browsable(true)]
        [DefaultValue(0)]
        [CategoryEx(@"cat_symbol")]
        [DisplayNameEx(@"prop_contrast")]
        public int Contrast
        {
            get { return _contrast; }
            set
            {
                if (value < -255) _contrast = -255;
                else if (value > 255) _contrast = 255;
                else _contrast = value;
                RefreshElement();
            }
        }

        /// <summary>
        /// Allows for a faster but lower quality bitmap to be rendered to the screen
        /// and a higher quality bitmap to be printed during actual printing.
        /// </summary>
        [Browsable(false)]
        [DefaultValue(true)]
        [CategoryEx(@"Behavior")]
        public bool Draft
        {
            get { return _draft; }
            set
            {
                _draft = value;

                if (_draft)
                {
                    RecycleBitmap();
                }
                else
                {
                    if (File.Exists(_filename))
                    {
                        _bitmap = new Bitmap(_filename);
                    }
                }

                RefreshElement();
            }
        }

        /// <summary>
        /// Gets or sets the string fileName of the bitmap to use
        /// </summary>
        [Browsable(true)]
        [DefaultValue("")]
        [CategoryEx(@"cat_symbol")]
        [DisplayNameEx(@"prop_filename")]
        [Editor("System.Windows.Forms.Design.FileNameEditor, System.Design", typeof(UITypeEditor))]
        public string Filename
        {
            get { return _filename; }
            set
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(value))
                    {
                        _filename = "";
                        RecycleBitmap();
                        return;
                    }

                    _filename = value;
                    RecycleBitmap();
                    _bitmap = new Bitmap(_filename);
                }
                catch
                {
                    // GDI+ supports the following file formats: BMP, GIF, EXIF, JPG, PNG and TIFF.
                    _filename = string.Empty;
                }

                RefreshElement();
            }
        }

        /// <summary>
        /// Preserves the aspect ratio if this boolean is true, otherwise it allows stretching of
        /// the bitmap to occur
        /// </summary>
        [Browsable(true)]
        [DefaultValue(true)]
        [CategoryEx(@"cat_behavior")]
        [DisplayNameEx(@"prop_ratio")]
        public bool PreserveAspectRatio
        {
            get { return _preserveAspectRatio; }
            set
            {
                _preserveAspectRatio = value;
                RefreshElement();
            }
        }

        public override ElementType Type
        {
            get { return ElementType.Bitmap; }
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            RecycleBitmap();
        }

        /// <summary>
        /// This gets called to instruct the element to draw itself in the appropriate spot of the graphics object
        /// </summary>
        protected override void Draw(Graphics g, bool printing, bool export, int x, int y)
        {
            //This color matrix is used to adjust how the image is drawn to the graphics object
            float bright = _brightness / 255.0F;
            float cont = (_contrast + 255.0F) / 255.0F;
            float[][] colorArray =
                {
                    new[] { cont, 0, 0, 0, 0 }, new[] { 0, cont, 0, 0, 0 }, new[] { 0, 0, cont, 0, 0 },
                    new[] { 0, 0, 0, 1f, 0 }, new[] { bright, bright, bright, 0, 1 }
                };

            var cm = new ColorMatrix(colorArray);
            var imgAttrib = new ImageAttributes();
            imgAttrib.SetColorMatrix(cm);

            //Defines a parallelgram where the image is to be drawn
            PointF[] destPoints = { new PointF(x, y), new PointF(x + Size.Width, y), new PointF(x, y + Size.Height) };
            Rectangle srcRect;

            //When printing we use this code
            if (printing)
            {
                //Open the original and gets its rectangle
                var original = new Bitmap(_filename);
                srcRect = new Rectangle(0, 0, _bitmap.Width, _bitmap.Height);

                //Modifies the parallelogram if we are preserving aspect ratio
                if (_preserveAspectRatio)
                {
                    if (Size.Width / original.Width < Size.Height / original.Height) destPoints[2] = new PointF(x, y + (Size.Width * original.Height / original.Width));
                    else destPoints[1] = new PointF(x + (Size.Height * original.Width / original.Height), y);
                }

                //Draws the bitmap
                g.DrawImage(_bitmap, destPoints, srcRect, GraphicsUnit.Pixel, imgAttrib);

                //Clean up and return
                imgAttrib.Dispose();
                original.Dispose();
            }
            else
            {
                if (!Resizing && Draft)
                {
                    if (File.Exists(_filename))
                    {
                        if ((_bitmap == null) || (_bitmap != null && _bitmap.Width != Convert.ToInt32(Size.Width)))
                        {
                            var original = new Bitmap(_filename);
                            if (_bitmap != null) _bitmap.Dispose();
                            _bitmap = new Bitmap(Convert.ToInt32(Size.Width),
                                Convert.ToInt32(Size.Width * original.Height / original.Width),
                                PixelFormat.Format32bppArgb);
                            var graph = Graphics.FromImage(_bitmap);
                            graph.DrawImage(original, 0, 0, _bitmap.Width, _bitmap.Height);
                            original.Dispose();
                            graph.Dispose();
                        }
                    }
                }
                if (_bitmap == null) return;

                //Modifies the parallelogram if we are preserving aspect ratio
                if (_preserveAspectRatio)
                {
                    if ((Size.Width / _bitmap.Width) < (Size.Height / _bitmap.Height))
                        destPoints[2] = new PointF(LocationF.X,
                            LocationF.Y + (Size.Width * _bitmap.Height / _bitmap.Width));
                    else
                        destPoints[1] = new PointF(LocationF.X + (Size.Height * _bitmap.Width / _bitmap.Height),
                            LocationF.Y);
                }

                //Draws the bitmap to the screen
                srcRect = new Rectangle(0, 0, _bitmap.Width, _bitmap.Height);
                g.DrawImage(_bitmap, destPoints, srcRect, GraphicsUnit.Pixel, imgAttrib);
            }
        }

        private void RecycleBitmap()
        {
            if (_bitmap != null)
            {
                _bitmap.Dispose();
                _bitmap = null;
            }
        }
    }
}