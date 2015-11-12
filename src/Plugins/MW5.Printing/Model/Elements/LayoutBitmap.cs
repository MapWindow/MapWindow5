// -------------------------------------------------------------------------------------------
// <copyright file="LayoutBitmap.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.Serialization;
using MW5.Plugins.Printing.Controls.PropertyGrid;
using MW5.Plugins.Printing.Enums;

namespace MW5.Plugins.Printing.Model.Elements
{
    /// <summary>
    /// The layout bitmap provides the ability to add any custom image to the layout
    /// </summary>
    [DataContract]
    public class LayoutBitmap : LayoutElement, IDisposable
    {
        private Bitmap _bitmap;
        private int _brightness;
        private int _contrast;
        private bool _draft;
        private string _filename;
        private bool _preserveAspectRatio;

        public LayoutBitmap()
        {
            SetDefaults();
        }

        /// <summary>
        /// Modifies the brightness of the bitmap relative to its original brightness +/- 255 Doesn't modify original bitmap
        /// </summary>
        [Browsable(true)]
        [DataMember]
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
        [DataMember]
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
        [DataMember]
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
                    RecycleBitmap();

                    _filename = string.IsNullOrWhiteSpace(value) ? string.Empty : value;

                    if (_filename != string.Empty)
                    {
                        _bitmap = new Bitmap(_filename);
                    }
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
        [DataMember]
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

        private ImageAttributes CreateImageAttributes()
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

            return imgAttrib;
        }

        /// <summary>
        /// Modifies the parallelogram if we are preserving aspect ratio
        /// </summary>
        private void AjustDestinationBounds(Bitmap bitmap, float x, float y, ref PointF[] destPoints)
        {
            if (_preserveAspectRatio)
            {
                if (SizeF.Width / bitmap.Width < SizeF.Height / bitmap.Height)
                {
                    destPoints[2] = new PointF(x, y + (SizeF.Width * bitmap.Height / bitmap.Width));
                }
                else
                {
                    destPoints[1] = new PointF(x + (SizeF.Height * bitmap.Width / bitmap.Height), y);
                }
            }
        }

        /// <summary>
        /// Should initialize all private data members which aren't set by deserialization.
        /// </summary>
        protected override void SetDefaults()
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
        /// This gets called to instruct the element to draw itself in the appropriate spot of the graphics object
        /// </summary>
        protected override void Draw(Graphics g, bool printing, bool export, int x, int y)
        {
            var attr = CreateImageAttributes();

            PointF[] destPoints =
                {
                    new PointF(x, y), 
                    new PointF(x + SizeF.Width, y), 
                    new PointF(x, y + SizeF.Height)
                };

            Rectangle srcRect;

            if (printing)
            {
                using (var original = new Bitmap(_filename))
                {
                    srcRect = new Rectangle(0, 0, _bitmap.Width, _bitmap.Height);

                    AjustDestinationBounds(original, x, y, ref destPoints);

                    g.DrawImage(_bitmap, destPoints, srcRect, GraphicsUnit.Pixel, attr);
                }
            }
            else
            {
                if (!Resizing && Draft && File.Exists(_filename))
                {
                    PopulateBufferBitmap();
                }

                if (_bitmap == null) return;

                AjustDestinationBounds(_bitmap, LocationF.X, LocationF.Y, ref destPoints);

                srcRect = new Rectangle(0, 0, _bitmap.Width, _bitmap.Height);
                g.DrawImage(_bitmap, destPoints, srcRect, GraphicsUnit.Pixel, attr);
            }
        }

        private void PopulateBufferBitmap()
        {
            if ((_bitmap == null) || (_bitmap != null && _bitmap.Width != Convert.ToInt32(SizeF.Width)))
            {
                using (var original = new Bitmap(_filename))
                {
                    RecycleBitmap();

                    _bitmap = new Bitmap(Convert.ToInt32(SizeF.Width),
                        Convert.ToInt32(SizeF.Width * original.Height / original.Width),
                        PixelFormat.Format32bppArgb);

                    using (var graph = Graphics.FromImage(_bitmap))
                    {
                        graph.DrawImage(original, 0, 0, _bitmap.Width, _bitmap.Height);
                    }
                }
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