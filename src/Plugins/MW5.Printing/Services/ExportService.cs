using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows.Forms;
using MW5.Plugins.Printing.Enums;
using MW5.Plugins.Printing.Helpers;
using MW5.Plugins.Printing.Model.Elements;
using MW5.Plugins.Services;
using MW5.Shared;

namespace MW5.Plugins.Printing.Services
{
    /// <summary>
    /// Exports layout int a file.
    /// </summary>
    internal class ExportService
    {
        /// <summary>
        /// Exports to bitmap at specified dpi
        /// </summary>
        internal bool ExportToBitmap(Size paperSize, IEnumerable<LayoutElement> elements, float dpi)
        {
            int filterIndex;
            string filename;

            if (!ChooseFilename(out filename, out filterIndex))
            {
                return false;
            }

            var bmp = CreateBitmap(paperSize, dpi);

            var g = Graphics.FromImage(bmp);

            // caling may not work correctly for other values
            g.PageUnit = GraphicsUnit.Pixel;        

            if (filterIndex != (int)ImageExportFormat.Png)
            {
                g.Clear(Color.White);
            }

            DrawToBitmap(g, elements);

            bmp.Save(filename, ChooseFormat(filterIndex));

            MessageService.Current.Info("Export operation has completed successfully.");

            return true;
        }

        /// <summary>
        /// Draws the whole contents of the control to the specified graphics object
        /// </summary>
        private void DrawToBitmap(Graphics g, IEnumerable<LayoutElement> layoutElements)
        {
            float dpiRatio = g.DpiX / 100f;

            foreach (var el in layoutElements.Reverse())
            {
                var matrix = g.Transform;

                if (el is LayoutMap)
                {
                    // no autmatic scaling in this case
                    g.PageScale = 1f;

                    // MapWinGIS receives Graphics object by using GDI as intermediary layer,
                    // all Graphics settings such as PageScale, Clip, DPI are lost in the process.
                    // Therefore we need to do all the necessary DPI adjusments manually:
                    // - increase the size of output bitmap;
                    // - increase the size of clipping rectangle;
                    var rectNew = AdjustRectToDpi(el.Rectangle, dpiRatio);

                    g.SetClip(rectNew);
                    g.TranslateTransform(rectNew.X, rectNew.Y);

                    // We are stil passing rectangle in screen coordinates, since layout map
                    // needs to correctly estimate extents. It will afterwards enlarge 
                    // the printing area in pixels according to the DPI of Graphics object.
                    (el as LayoutMap).Print(g, el.Rectangle, true);
                }
                else
                {
                    g.PageScale = dpiRatio;

                    g.TranslateTransform(el.Rectangle.X, el.Rectangle.Y);

                    el.DrawElement(g, true, true);
                }

                g.ResetClip();
                g.Transform = matrix;
            }
        }

        /// <summary>
        /// Gets the size of the bitmap at given DPI.
        /// </summary>
        public Size GetBitmapSize(Size paperSize, float dpi)
        {
            var width = (int)(paperSize.Width / 100.0 * dpi);
            var height = (int)(paperSize.Height / 100.0 * dpi);
            return new Size(width, height);
        }

        /// <summary>
        /// Creates ouput bitmap to accomodate all the pages
        /// </summary>
        private Bitmap CreateBitmap(Size paperSize, float dpi)
        {
            var size = GetBitmapSize(paperSize, dpi);

            var bmp = new Bitmap(size.Width, size.Height, PixelFormat.Format32bppArgb);
            bmp.SetResolution(dpi, dpi);

            return bmp;
        }

        /// <summary>
        /// Chooses the filename to save bitmap.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <param name="filterIndex">Index of the filter.</param>
        private bool ChooseFilename(out string filename, out int filterIndex)
        {
            filterIndex = -1;
            filename = string.Empty;

            using (var dlg = new SaveFileDialog { Filter = PrintingConstants.EXPORT_FILTER })
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    filterIndex = dlg.FilterIndex;
                    filename = dlg.FileName;
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Chooses output image format.
        /// </summary>
        /// <param name="filterIndex">Index of the filter.</param>
        private ImageFormat ChooseFormat(int filterIndex)
        {
            var format = ImageFormat.Png;
            switch ((ImageExportFormat)filterIndex)
            {
                case ImageExportFormat.Tiff:
                    format = ImageFormat.Tiff;
                    break;
                case ImageExportFormat.Jpg:
                    format = ImageFormat.Jpeg;
                    break;
                case ImageExportFormat.Bmp:
                    format = ImageFormat.Bmp;
                    break;
            }

            return format;
        }

        private RectangleF AdjustRectToDpi(RectangleF r, float dpiRatio)
        {
            return new RectangleF(r.X * dpiRatio, r.Y * dpiRatio, r.Width * dpiRatio, r.Height * dpiRatio);
        }
    }
}
