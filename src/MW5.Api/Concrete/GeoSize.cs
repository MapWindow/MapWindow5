using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Api.Concrete
{
    public class GeoSize
    {
        public GeoSize()
        {
            
        }

        public GeoSize(double width, double height)
        {
            Width = width;
            Height = height;
        }

        public double Width { get; set; }
        
        public double Height { get; set; }

        public double Product
        {
            get { return Width * Height; }
        }
    }
}
