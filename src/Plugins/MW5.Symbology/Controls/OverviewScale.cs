using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Plugins.Symbology.Controls
{
    public class OverviewScale : IEquatable<OverviewScale>
    {
        private readonly int _totalWidth;
        private int _totalHeight;

        public OverviewScale(int totalWidth, int totalHeight, int ratio)
        {
            Width = (totalWidth + ratio - 1) / ratio;       // see gt_overview.cpp GTIFFBuildOverviews
            Height = (totalHeight + ratio - 1) / ratio;       // see gt_overview.cpp GTIFFBuildOverviews
            
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

        [Browsable(false)]
        public int RatioCore
        {
            get
            {
                return (int)(_totalWidth / (double)Width + 0.5);
            }
        }

        public string Ratio
        {
            get
            {
                return string.Format("1:{0}", (_totalWidth/(double) Width).ToString("0.#"));
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

        public bool Equals(OverviewScale other)
        {
            return Width == other.Width && Height == other.Height;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as OverviewScale);
        }

        public override int GetHashCode()
        {
            return (Width + Height).GetHashCode();
        }
    }
}
