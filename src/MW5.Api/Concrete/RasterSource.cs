using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using MapWinGIS;
using MW5.Api.Enums;
using MW5.Api.Helpers;
using MW5.Api.Interfaces;
using Image = MapWinGIS.Image;

namespace MW5.Api.Concrete
{
    public class RasterSource : BitmapSource, IRasterSource
    {
        public RasterSource(Image image)
            : base(image)
        {

        }

        #region Static methods

        public static IRasterSource Open(string filename)
        {
            var img = new Image();
            if (!img.Open(filename))
            {
                throw new ApplicationException("Failed to open datasource: " + img.ErrorMsg[img.LastErrorCode]);
            }
            if (img.SourceType != tkImageSourceType.istGDALBased)
            {
                // TODO: force opening BMP files with GDAL as well for uniformity
                throw new ApplicationException("Image format isn't supported by RasterSource");
            }
            return new RasterSource(img);
        }

        #endregion

        public override double Dx
        {
            get { return _image.OriginalDX; }
            set { throw new InvalidOperationException("Dx property isn't supported for RasterSource."); }
        }

        public override double Dy
        {
            get { return _image.OriginalDY; }
            set { throw new InvalidOperationException("Dy property isn't supported for RasterSource."); }
        }

        public override int Width
        {
            get { return _image.OriginalWidth; }
        }

        public override int Height
        {
            get { return _image.OriginalHeight; }
        }

        public override double XllCenter
        {
            get { return _image.OriginalXllCenter; }
            set { throw new InvalidOperationException("XllCenter property isn't supported for RasterSource."); }
        }

        public override double YllCenter
        {
            get { return _image.OriginalYllCenter; }
            set { throw new InvalidOperationException("YllCenter property isn't supported for RasterSource."); }
        }

        public override string ToolTipText
        {
            get
            {
                string s = base.ToolTipText;
                // TODO: add number of bands
                return s;
            }
        }

        public override int NumBands
        {
            get { return _image.NoBands; }
        }

        public int NumOverviews
        {
            get { return _image.NumOverviews; }
        }

        public bool BuildOverviews(RasterOverviewSampling method, IEnumerable<int> scales)
        {
            scales = scales.ToList();
            return _image.BuildOverviews((tkGDALResamplingMethod) method, scales.Count(), scales.ToArray());
        }

        public bool ClearOverviews()
        {
            return _image.ClearOverviews();
        }

        public double BufferDx
        {
            get { return _image.dX; }
        }

        public double BufferDy
        {
            get { return _image.dY; }
        }

        public double BufferWidth
        {
            get { return _image.Width; }
        }

        public double BufferHeight
        {
            get { return _image.Height; }
        }

        public double BufferXllCenter
        {
            get { return _image.XllCenter; }
        }

        public double BufferYllCenter
        {
            get { return _image.YllCenter; }
        }

        public void BufferToProjection(int bufferX, int bufferY, out double projX, out double projY)
        {
            _image.BufferToProjection(bufferX, bufferY, out projX, out projY);
        }

        public void ProjectionToBuffer(double projX, double projY, out int bufferX, out int bufferY)
        {
            _image.ProjectionToBuffer(projX, projY, out bufferX, out bufferY);
        }

        public IRasterBandCollection Bands
        {
            get { return new ImageBandCollection(_image); }
        }

        public bool UseHistogram
        {
            get { return _image.UseHistogram; }
            set { _image.UseHistogram = value; }
        }

        public PaletteInterpretation PaletteInterpretation
        {
            get { return (PaletteInterpretation)_image.PaletteInterpretation2; }
        }

        public bool IsRgb
        {
            get { return _image.IsRgb; }
        }

        public bool Warped
        {
            get { return _image.Warped; }
        }

        public bool HasBuiltInColorTable
        {
            get { return _image.HasColorTable; }
        }

        public int ActiveBandIndex
        {
            get { return _image.SourceGridBandIndex; }
            set { _image.SourceGridBandIndex = value; }
        }

        public RasterColorScheme CustomColorScheme
        {
            get
            {
                var scheme = _image.CustomColorScheme;
                return scheme != null ? new RasterColorScheme(scheme) : null;
            }
            set { _image.CustomColorScheme = value.GetInternal(); }
        }

        public GridRendering AllowGridRendering
        {
            get { return (GridRendering)_image.AllowGridRendering; }
            set { _image.AllowGridRendering = (tkGridRendering) value; }
        }

        public RenderingType RenderingType
        {
            get
            {
                if (_image.GridRendering)
                {
                    return RenderingType.Grid;
                }

                if (_image.ForceSingleBandRendering)
                {
                    return RenderingType.Grayscale;
                }

                if (_image.UseRgbBandMapping)
                {
                    return RenderingType.Rgb;
                }

                return _image.NoBands == 1 ? RenderingType.Grayscale : RenderingType.Rgb;
            }
        }


        public RasterColorScheme RgbBandMapping
        {
            get
            {
                var scheme = new RasterColorScheme();

                // default RGB, there is no active remapping                    
                scheme.AddInterval(new RasterInterval() { LowColor = Color.Red, Caption = "Band 1 (Red)" });
                scheme.AddInterval(new RasterInterval() { LowColor = Color.Green, Caption = "Band 2 (Green)" });
                scheme.AddInterval(new RasterInterval() { LowColor = Color.Blue, Caption = "Band 3 (Blue)" });

                if (_image.UseRgbBandMapping)
                {
                    string name = GetBandFullName(_image.RedBandIndex);
                    scheme[0].Caption = string.IsNullOrWhiteSpace(name) ? "<None>" : name;

                    name = GetBandFullName(_image.GreenBandIndex);
                    scheme[1].Caption = string.IsNullOrWhiteSpace(name) ? "<None>" : name;

                    name = GetBandFullName(_image.BlueBandIndex);
                    scheme[2].Caption = string.IsNullOrWhiteSpace(name) ? "<None>" : name;
                }
                
                return scheme;
            }
        }

        public RasterColorScheme GrayScaleColorScheme
        {
            get
            {
                var scheme = new RasterColorScheme();
                
                // TODO: udpate
                scheme.AddInterval(new RasterInterval()
                {
                    LowColor = Color.White,
                    HighColor = Color.Black,
                    Caption = "0 - 255"     // TODO: should depend on min / max really used
                });

                return scheme;
            }
        }

        public DatasourceDriver Driver
        {
            get { return new DatasourceDriver(_image.GdalDriver); }
        }

        public int RedBandIndex
        {
            get { return _image.RedBandIndex; }
            set { _image.RedBandIndex = value; }
        }

        public int GreenBandIndex
        {
            get { return _image.GreenBandIndex; }
            set { _image.GreenBandIndex = value; }
        }

        public int BlueBandIndex
        {
            get { return _image.BlueBandIndex; }
            set { _image.BlueBandIndex = value; }
        }

        public int AlphaBandIndex
        {
            get { return _image.AlphaBandIndex; }
            set { _image.AlphaBandIndex = value; }
        }

        public bool UseRgbBandMapping
        {
            get { return _image.UseRgbBandMapping; }
            set { _image.UseRgbBandMapping = value; }
        }

        public bool ForceSingleBandRendering
        {
            get { return _image.ForceSingleBandRendering; }
            set { _image.ForceSingleBandRendering = value; }
        }

        public string GetBandFullName(int bandIndex)
        {
            if (bandIndex < 1 || bandIndex > NumBands)
            {
                return string.Empty;
            }

            var band = _image.Band[bandIndex];
            if (band != null)
            {
                return "Band " + bandIndex + " (" + band.ColorInterpretation + ")";
            }

            return string.Empty;
        }

        public bool AlphaRendering
        {
            get { return _image.AlphaRendering; }
            set { _image.AlphaRendering = value; }
        }

        public bool GridRendering
        {
            get { return _image.GridRendering; }
        }

        public double GetBandMinimum(int bandIndex)
        {
            return _image.BandMinimum[bandIndex];
        }

        public double GetBandMaximum(int bandIndex)
        {
            return _image.BandMaximum[bandIndex];
        }

        public bool SetBandMinMax(int bandIndex, double min, double max)
        {
            return _image.SetBandMinMax(bandIndex, min, max);
        }

        public bool SetDefaultMinMax(int bandIndex)
        {
            return _image.SetDefaultMinMax(bandIndex);
        }

        public bool ReverseGreyScale
        {
            get { return _image.ReverseGreyscale; }
            set { _image.ReverseGreyscale = value; }
        }

        public RasterBand ActiveBand
        {
            get { return Bands[_image.SourceGridBandIndex]; }
        }

        public override GdalDataType DataType
        {
            get
            {
                if (NumBands > 0)
                {
                    return Bands[1].DataType;
                }

                return GdalDataType.Unknown;
            }
        }
    }
}
