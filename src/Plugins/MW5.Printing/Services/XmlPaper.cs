using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Printing.Helpers;
using MW5.Plugins.Printing.Model;

namespace MW5.Plugins.Printing.Services
{
    [DataContract()]
    internal class XmlPaper
    {
        public XmlPaper(PageSettings settings, LayoutPages pages)
        {
            PaperName = settings.PaperSize.PaperName;
            Landscape = settings.Landscape;
            Width = settings.PaperSize.Width;
            Height = settings.PaperSize.Height;
            PageCountX = pages.PageCountX;
            PageCountY = pages.PageCountY;
        }

        [DataMember]
        public string PaperName { get; set; }

        [DataMember]
        public bool Landscape { get; set; }

        [DataMember]
        public int Width { get; set; }

        [DataMember]
        public int Height { get; set; }

        [DataMember]
        public int PageCountX { get; set; }

        [DataMember]
        public int PageCountY { get; set; }

        /// <summary>
        /// Updates the instance of printer settings according to properties of the XmlPaper.
        /// </summary>
        public void UpdatePageSettings(PrinterSettings settings)
        {
            settings.DefaultPageSettings.Landscape = Landscape;

            var size = PaperSizes.PaperSizeByFormatName(PaperName, settings);

            if (size == null)
            {
                // let's create a custom paper size
                size = new PaperSize { Width = Width, Height = Height, PaperName = PaperName };
            }

            settings.DefaultPageSettings.PaperSize = size;
        }
    }
}
