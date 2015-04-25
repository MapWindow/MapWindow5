using System;
using System.Collections.Generic;
using MapWinGIS;
using MW5.Api.Concrete;
using MW5.Api.Enums;

namespace MW5.Api.Interfaces
{
    public interface IRasterSource : IImageSource
    {
        int NumOverviews { get; }
    
        bool BuildOverviews(RasterOverviewSampling  method, IEnumerable<int> scales);

        double BufferDx { get; }
        double BufferDy { get; }
        double BufferWidth { get; }
        double BufferHeight { get; }
        double BufferXllCenter { get; }
        double BufferYllCenter { get; }

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

        bool ForceGridRendering { get; set; }

        RenderingType RenderingType { get; }

        RasterBand ActiveBand { get; }

        // temporary
        RasterColorScheme RgbBandMapping { get; }

        RasterColorScheme GrayScaleColorScheme { get; }

        //bool AllowHillshade { get; set; }
        
        //GridColorScheme GridProxyColorScheme { get; }
        //PredefinedColorScheme ImageColorScheme { get; set; }
        
        //int BufferSize { get; set; }
        //bool ClearGdalCache { get; set; }
        
        //bool GridRendering { get; }

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
