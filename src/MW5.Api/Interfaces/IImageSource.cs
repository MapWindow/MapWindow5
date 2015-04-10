using System.Drawing;
using MW5.Api.Enums;

namespace MW5.Api.Interfaces
{
    public interface IImageSource : ILayerSource
    {
        double Dx { get; set; }
        double Dy { get; set; }
        int Height { get; }
        int Width { get; }
        double XllCenter { get; set; }
        double YllCenter { get; set; }
        
        Color TransparentColorFrom { get; set; }
        Color TransparentColorTo { get; set; }
        bool UseTransparentColor { get; set; }
        
        double Transparency { get; set; }
        InterpolationType DownsamplingMode { get; set; }
        InterpolationType UpsamplingMode { get; set; }

        ImageFormat ImageFormat { get; }
        InRamState InRamState { get; }
        ImageSourceType SourceType { get; }

        void Clear(Color color);
        bool Save(string filename, bool writeWorldFile = false, ImageFormat fileType = ImageFormat.UseFileExtension);

        void ImageToProjection(int imageX, int imageY, out double projX, out double projY);
        void ProjectionToImage(double projX, double projY, out int imageX, out int imageY);

        Color GetPixel(int row, int column);
        void SetPixel(int row, int column, Color pVal);

        System.Drawing.Image ToGdiPlusBitmap();
        bool FromGdiPlusBitmap(System.Drawing.Image image);
    }
}
