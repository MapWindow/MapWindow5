using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using MapWinGIS;
using MW5.Api.Enums;
using MW5.Api.Helpers;
using MW5.Api.Interfaces;
using MW5.Shared;

namespace MW5.Api.Concrete
{
    public class RasterColorScheme: IEnumerable<RasterInterval>, ISerializableComWrapper
    {
        private readonly GridColorScheme _scheme;

        public RasterColorScheme()
        {
            _scheme = new GridColorScheme();
        }

        internal RasterColorScheme(GridColorScheme scheme)
        {
            _scheme = scheme;
            if (scheme == null)
            {
                throw new NullReferenceException("Internal reference is null.");
            }
        }

        public object InternalObject
        {
            get { return _scheme; }
        }

        public string LastError
        {
            get { return _scheme.ErrorMsg[_scheme.LastErrorCode]; }
        }

        public string Tag
        {
            get { return _scheme.Key; }
            set { _scheme.Key = value; }
        }

        public void SetLightSource(double azimuth, double elevation)
        {
            _scheme.SetLightSource(azimuth, elevation);
        }

        public void AddInterval(RasterInterval interval)
        {
            _scheme.InsertBreak(interval.GetInternal());
        }

        public void DeleteInterval(int index)
        {
            _scheme.DeleteBreak(index);
        }

        public void Clear()
        {
            _scheme.Clear();
        }

        public void SetPredefined(double lowValue, double highValue, PredefinedColors preset = PredefinedColors.SummerMountains)
        {
            _scheme.UsePredefined(lowValue, highValue, (PredefinedColorScheme) preset);

            foreach (var item in this)
            {
                item.Caption = string.Format("{0} - {1}", item.LowValue, item.HighValue);
            }
        }

        public Vector3D GetLightSource()
        {
            return new Vector3D(_scheme.GetLightSource());
        }

        public void InsertAt(int position, RasterInterval interval)
        {
            _scheme.InsertAt(position, interval.GetInternal());
        }

        public string Serialize()
        {
            return _scheme.Serialize();
        }

        public bool Deserialize(string state)
        {
            _scheme.Deserialize(state);
            return true;
        }

        public bool ReadFromFile(string mwlegFilename, string nodeName = "GridColoringScheme")
        {
            return _scheme.ReadFromFile(mwlegFilename, nodeName);
        }

        public bool WriteToFile(string mwlegFilename, string gridName = "", int bandIndex = 1)
        {
            return _scheme.WriteToFile(mwlegFilename, gridName, bandIndex);
        }

        public void ApplyColoringType(GridColoringType coloringType)
        {
            _scheme.ApplyColoringType((ColoringType) coloringType);
        }

        public void ApplyGradientModel(GridGradientModel model)
        {
            _scheme.ApplyGradientModel((GradientModel)model);
        }

        public int NumBreaks
        {
            get { return _scheme.NumBreaks; }
        }

        public double AmbientIntensity
        {
            get { return _scheme.AmbientIntensity; }
            set { _scheme.AmbientIntensity = value; }
        }

        public double LightSourceIntensity
        {
            get { return _scheme.LightSourceIntensity; }
            set { _scheme.LightSourceIntensity = value; }
        }

        public double LightSourceAzimuth
        {
            get { return _scheme.LightSourceAzimuth; }
        }

        public double LightSourceElevation
        {
            get { return _scheme.LightSourceElevation; }
        }

        public RasterInterval this[int index]
        {
            get
            {
                var cb = _scheme.Break[index];
                return cb != null ? new RasterInterval(cb) : null;
            }
        }

        public Color NoDataColor
        {
            get { return ColorHelper.UintToColor(_scheme.NoDataColor); }
            set { _scheme.NoDataColor = ColorHelper.ColorToUInt(value); }
        }

        public IEnumerator<RasterInterval> GetEnumerator()
        {
            for (int i = 0; i < _scheme.NumBreaks; i++)
            {
                yield return new RasterInterval(_scheme.Break[i]);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public bool ApplyColors(SchemeType schemeType, ColorRamp colorScheme, bool gradientWithinCategories)
        {
            return _scheme.ApplyColors((tkColorSchemeType)schemeType, colorScheme.GetInternal(), gradientWithinCategories);
        }

        public bool HasColoringType(GridColoringType type)
        {
            return this.Any(item => item.ColoringType == type);
        }

        /// <summary>
        /// Gets the coloring type used by color scheme or Mixed if more than one type is used by different intervals.
        /// </summary>
        public GridColoringType ColoringType
        {
            get
            {
                var item = this.FirstOrDefault();
                if (item != null)
                {
                    if (this.Any(br => br.ColoringType != item.ColoringType))
                    {
                        return GridColoringType.Mixed;
                    }
                    
                    return item.ColoringType;
                }

                return GridColoringType.Mixed;
            }
        }

        /// <summary>
        /// Gets the gradient model used by color scheme or Mixed if more than one model used by differnt intervals.
        /// </summary>
        public GridGradientModel GradientModel
        {
            get
            {
                var item = this.FirstOrDefault();
                if (item != null)
                {
                    if (this.Any(br => br.GradientModel != item.GradientModel))
                    {
                        return GridGradientModel.Mixed;
                    }

                    return item.GradientModel;
                }

                return GridGradientModel.Mixed;
            }
        }

        public bool ColorGradientWithinCategory
        {
            get
            {
                return this.Any(item => item.LowColor != item.HighColor);
            }
        }
    }
}
