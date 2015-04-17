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

        //bool HasColorTable { get; }
        //string PaletteInterpretation { get; }

        //bool AllowHillshade { get; set; }

        //bool UseHistogram { get; set; }

        //GridColorScheme CustomColorScheme { get; set; }
        //GridColorScheme GridProxyColorScheme { get; }
        //PredefinedColorScheme ImageColorScheme { get; set; }

        //tkGridRendering AllowGridRendering { get; set; }
        
        //int BufferSize { get; set; }
        //bool ClearGdalCache { get; set; }
        
        //bool GridRendering { get; }
        
        //bool SetToGrey { get; set; }

        //string SourceFilename { get; }
        //int SourceGridBandIndex { get; set; }
        //string SourceGridName { get; }
        //bool IsRgb { get; }
        //bool IsGridProxy { get; }
        
        //bool Warped { get; }

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
