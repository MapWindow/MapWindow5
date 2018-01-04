using System.Collections.Generic;
using MW5.Api.Concrete;
using MW5.Api.Enums;

namespace MW5.Api.Interfaces
{
    public interface IRasterSource : IImageSource
    {
        int NumOverviews { get; }

        bool BuildDefaultOverviews(RasterOverviewSampling method, TiffCompression compression = TiffCompression.Auto);
        bool BuildOverviews(RasterOverviewSampling method, IEnumerable<int> scales, TiffCompression compression = TiffCompression.Auto);
        bool ClearOverviews();
        bool NeedsOverviews { get; }
        IEnumerable<int> GetDefaultOverviewRatios();

        double BufferDx { get; }
        double BufferDy { get; }
        double BufferWidth { get; }
        double BufferHeight { get; }
        double BufferXllCenter { get; }
        double BufferYllCenter { get; }
        int BufferOffsetX { get; }
        int BufferOffsetY { get; }

        void ImageToBuffer(int column, int row, out int bufferX, out int bufferY);

        void BufferToProjection(int bufferX, int bufferY, out double projX, out double projY);
        void ProjectionToBuffer(double projX, double projY, out int bufferX, out int bufferY);

        IRasterBandCollection Bands { get; }

        /// <summary>
        /// Gets or sets a value indicating whether histogram equalization will be used. 
        /// Currently supported for single band, single byte per-pixel datasources with some
        /// format specific behavior.
        /// </summary>
        bool UseHistogram { get; set; }

        PaletteInterpretation PaletteInterpretation { get; }

        bool IsRgb { get; }

        bool Warped { get; }

        bool HasBuiltInColorTable { get; }

        int ActiveBandIndex { get; set; }

        /// <summary>
        /// Gets or sets user color scheme for single band pseudo color rendering.
        /// </summary>
        RasterColorScheme CustomColorScheme { get; set; }

        RasterColorScheme ActiveColorScheme { get; }

        GridRendering AllowGridRendering { get; set; }

        RasterRendering RenderingType { get; }

        RasterBand ActiveBand { get; }

        RasterColorScheme GrayScaleColorScheme { get; }

        DatasourceDriver Driver { get; }

        int RedBandIndex { get; set; }

        int GreenBandIndex { get; set; }

        int BlueBandIndex { get; set; }

        int AlphaBandIndex { get; set; }

        bool UseRgbBandMapping { get; set; }

        bool ForceSingleBandRendering { get; set; }

        string GetBandFullName(int bandIndex);

        bool UseActiveBandAsAlpha { get; set; }

        bool GridRendering { get; }

        double GetBandMinimum(int bandIndex);

        double GetBandMaximum(int bandIndex);

        bool SetBandMinMax(int bandIndex, double min, double max);

        bool SetDefaultMinMax(int bandIndex);

        bool ReverseGreyScale { get; set; }

        bool IgnoreColorTable { get; set; }

        bool IsUsingHillshade { get; }

        GridGradientModel GradientModel { get; }

        //GridColorScheme GridProxyColorScheme { get; }
        //PredefinedColorScheme ImageColorScheme { get; set; }

        //int BufferSize { get; set; }
        //bool ClearGdalCache { get; set; }

        //string SourceFilename { get; }

        //string SourceGridName { get; }

        //bool IsGridProxy { get; }

        //bool _pushSchemetkRaster(GridColorScheme cScheme);

        //void Deserialize(string newVal);

        //bool GetImageBitsDC(int hDC);

        //bool GetRow(int Row, ref int Vals);

        //int GetUniqueColors(double MaxBufferSizeMB, out object Colors, out object Frequencies);

        //bool LoadBuffer(double maxBufferSize = 50);

        //bool Open(string ImageFileName, ImageType FileType = ImageType.USE_FILE_EXTENSION, bool InRam = false, ICallback cBack = null);

        //Grid OpenAsGrid();

        //bool Resource(string newImgPath);

        //string Serialize(bool SerializePixels);

        //bool SetImageBitsDC(int hDC);

        //void SetNoDataValue(double Value, ref bool result);

        //void SetTransparentColor(uint Color);
    }
}
