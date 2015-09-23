using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Concrete;
using MW5.Api.Enums;

namespace MW5.Api.Interfaces
{
    public interface IGridSource : ILayerSource
    {
        DataType DataType { get; }

        RasterColorScheme RasterColorTableColoringScheme { get; }

        int NumBands { get; }

        int ActiveBandIndex { get; }

        GridSourceType SourceType { get; }

        IEnvelope Extents { get; }

        GridProxyMode PreferedDisplayMode { get; set; }

        bool HasValidImageProxy { get; }

        GridSourceHeader Header { get; }

        bool InRam { get; }

        object Maximum { get; }

        object Minimum { get; }

        IRasterBandCollection Bands { get; }

        RasterBand ActiveBand { get; }

        bool Save(string filename, GridFormat format = GridFormat.UseExtension);

        bool Clear(object clearValue);

        void ProjToCell(double x, double y, out int column, out int row);

        void CellToProj(int column, int row, out double x, out double y);

        bool SetInvalidValuesToNodata(double minThresholdValue, double maxThresholdValue);

        bool OpenBand(int bandIndex);

        IImageSource OpenAsImage(RasterColorScheme scheme, GridProxyMode proxyMode = GridProxyMode.Auto);

        RasterColorScheme RetrieveColorScheme(GridSchemeRetrieval method);

        RasterColorScheme GenerateColorScheme(GridSchemeGeneration method, PredefinedColors colors);

        bool RemoveImageProxy();

        IImageSource CreateImageProxy(RasterColorScheme colorScheme);

        RasterColorScheme RetrieveOrGenerateColorScheme(GridSchemeRetrieval retrievalMethod = GridSchemeRetrieval.Auto,
                                                                        GridSchemeGeneration generateMethod = GridSchemeGeneration.Gradient, PredefinedColors colors = PredefinedColors.FallLeaves);

        object get_Value(int column, int row);

        void set_Value(int column, int row, object value);

        bool GetRow(int row, ref float vals);

        bool PutRow(int row, ref float vals);

        bool GetValues(int startRow, int endRow, int startCol, int endCol, ref float vals);

        bool PutFloatWindow(int startRow, int endRow, int startCol, int endCol, ref float vals);

        bool GetValues(int startRow, int endRow, int startCol, int endCol, ref double vals);

        bool PutValues(int startRow, int endRow, int startCol, int endCol, ref double vals);

        bool PutRow(int row, ref double vals);

        bool GetRow2(int row, ref double vals);
    }
}
