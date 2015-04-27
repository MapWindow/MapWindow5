using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Plugins.Symbology.Controls
{
    public class OverviewScale
    {
        private readonly int _totalWidth;
        private int _totalHeight;

        public OverviewScale(int totalWidth, int totalHeight, int ratio)
        {
            Width = totalWidth / ratio;
            Height = totalHeight / ratio;
            _totalHeight = totalHeight;
            _totalWidth = totalWidth;
        }

        public OverviewScale(int width, int height, int totalWidth, int totalHeight)
        {
            Width = width;
            Height = height;

            _totalWidth = totalWidth;
            _totalHeight = totalHeight;
        }
        
        [DisplayName(@" ")]
        public bool Selected { get; set; }

        public string Ratio
        {
            get
            {
                return string.Format("1:{0}", (_totalWidth/(double) Width).ToString("0.##"));
            }
        }

        [Browsable(false)]
        public int Width { get; set; }

        [Browsable(false)]
        public int Height { get; set; }

        public string Resolution
        {
            get { return string.Format("{0} × {1}", Width, Height); }
        }
    }
}
