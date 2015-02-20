using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MapWinGIS;
using MW5.Core.Helpers;
using MW5.Core.Interfaces;

namespace MW5.Core.Concrete
{
    public class GridColorRamp: IEnumerable<GridColorInterval>, ISerializableComWrapper
    {
        private readonly GridColorScheme _scheme;

        internal GridColorRamp(GridColorScheme scheme)
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

        public void InsertInterval(GridColorInterval interval)
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
        }

        public Vector3D GetLightSource()
        {
            return new Vector3D(_scheme.GetLightSource());
        }

        public void InsertAt(int position, GridColorInterval interval)
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

        public GridColorInterval this[int index]
        {
            get
            {
                var cb = _scheme.Break[index];
                return cb != null ? new GridColorInterval(cb) : null;
            }
        }

        public Color NoDataColor
        {
            get { return ColorHelper.UintToColor(_scheme.NoDataColor); }
            set { _scheme.NoDataColor = ColorHelper.ColorToUInt(value); }
        }

        public IEnumerator<GridColorInterval> GetEnumerator()
        {
            for (int i = 0; i < _scheme.NumBreaks; i++)
            {
                yield return new GridColorInterval(_scheme.Break[i]);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
