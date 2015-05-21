using System.Drawing;
using MW5.Api.Concrete;
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
        IEnvelope GetPixelBounds(int col, int row);

        Color TransparentColorFrom { get; set; }
        Color TransparentColorTo { get; set; }
        bool UseTransparentColor { get; set; }
        void SetTransparentColor(Color color);

        double Transparency { get; set; }
        InterpolationType DownsamplingMode { get; set; }
        InterpolationType UpsamplingMode { get; set; }

        ImageFormat ImageFormat { get; }
        InRamState InRamState { get; }
        ImageSourceType SourceType { get; }

        void Clear(Color color);
        bool Save(string filename, bool writeWorldFile = false, ImageFormat fileType = ImageFormat.UseFileExtension);

        void ImageToProjection(int imageX, int imageY, out double projX, out double projY);
        bool ProjectionToImage(double projX, double projY, out int imageX, out int imageY);

        Color GetPixel(int row, int column);
        void SetPixel(int row, int column, Color pVal);

        Image ToGdiPlusBitmap();
        bool FromGdiPlusBitmap(Image image);

        int NumBands { get; }

        GdalDataType DataType { get; }

        RasterColorScheme RgbBandMapping { get; }

        // GDI+ color matrix adjustments
        float Brightness { get; set; }
        float Contrast { get; set; }
        float Hue { get; set; }
        float Saturation { get; set; }
        float Gamma { get; set; }
        Color ColorizeColor { get; set; }
        float ColorizeIntensity { get; set; }
        bool Greyscale { get; set; }
    }
}
