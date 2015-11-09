using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Printing.Helpers;

namespace MW5.Plugins.Printing.Views
{
    internal class ChooseDpiModel
    {
        private Size _size;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChooseDpiModel"/> class.
        /// </summary>
        /// <param name="originalSize">Original size of bitmap at 96 DPI.</param>
        public ChooseDpiModel(Size originalSize)
        {
            _size = originalSize;
            Dpi = 96;
        }

        public int Dpi { get; set; }

        /// <summary>
        /// Gets or sets size of bitmap at current DPI.
        /// </summary>
        public Size Size 
        {
            get { return new Size((int)(_size.Width * Dpi / 96f), (int)(_size.Height * Dpi / 96f)); } 
        }   
    }
}
