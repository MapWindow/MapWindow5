using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Concrete;
using MW5.Api.Interfaces;
using MW5.Shared;

namespace MW5.Api.Helpers
{
    public static class EnvelopeHelper
    {
        public static IEnvelope SetBoundsWithXYRatio(IEnvelope bounds, SizeF ratio)
        {
            if (NumericHelper.Equal(ratio.Width, 0.0) || NumericHelper.Equal(ratio.Height, 0.0))
            {
                return bounds.Clone();
            }

            double height = bounds.Height;
            double width = bounds.Width;

            if (ratio.Height / ratio.Width > height / width)
            {
                height = ratio.Height * width / ratio.Width;
            }
            else
            {
                width = ratio.Width * height / ratio.Height;
            }

            var result = new Envelope();
            result.SetBounds(bounds.Center, width, height);

            return result;
        }
    }
}
