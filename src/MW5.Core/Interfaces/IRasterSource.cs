namespace MW5.Core.Interfaces
{
    public interface IRasterSource : IImageSource
    {
        //tkGridRendering AllowGridRendering { get; set; }
        //bool AllowHillshade { get; set; }
        //int BufferSize { get; set; }
        //bool ClearGdalCache { get; set; }
        //GridColorScheme CustomColorScheme { get; set; }
        //GridColorScheme GridProxyColorScheme { get; }
        //bool GridRendering { get; }
        //bool HasColorTable { get; }
        //PredefinedColorScheme ImageColorScheme { get; set; }
        //double OriginalDx { get; set; }
        //double OriginalDy { get; set; }
        //int OriginalHeight { get; }
        //int OriginalWidth { get; }
        //double OriginalXllCenter { get; set; }
        //double OriginalYllCenter { get; set; }
        //int NoBands { get; }
        //int NumOverviews { get; }
        //string PaletteInterpretation { get; }
        //bool SetToGrey { get; set; }

        //string SourceFilename { get; }
        //int SourceGridBandIndex { get; set; }
        //string SourceGridName { get; }
        //bool IsRgb { get; }
        //bool IsGridProxy { get; }

        //bool UseHistogram { get; set; }
        //bool Warped { get; }

        //bool _pushSchemetkRaster(GridColorScheme cScheme);
        //void BufferToProjection(int BufferX, int BufferY, out double ProjX, out double ProjY);
        //bool BuildOverviews(tkGDALResamplingMethod ResamplingMethod, int NumOverviews, Array OverviewList);

        //void Deserialize(string newVal);

        //bool GetImageBitsDC(int hDC);

        //bool GetRow(int Row, ref int Vals);

        //int GetUniqueColors(double MaxBufferSizeMB, out object Colors, out object Frequencies);

        //bool LoadBuffer(double maxBufferSize = 50);

        //bool Open(string ImageFileName, ImageType FileType = ImageType.USE_FILE_EXTENSION, bool InRam = false, ICallback cBack = null);

        //Grid OpenAsGrid();

        //void ProjectionToBuffer(double ProjX, double ProjY, out int BufferX, out int BufferY);

        //bool Resource(string newImgPath);

        //string Serialize(bool SerializePixels);

        //bool SetImageBitsDC(int hDC);

        //void SetNoDataValue(double Value, ref bool result);

        //void SetTransparentColor(uint Color);
    }
}
