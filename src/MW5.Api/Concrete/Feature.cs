using System;
using MapWinGIS;
using MW5.Api.Helpers;
using MW5.Api.Interfaces;

namespace MW5.Api.Concrete
{
    public class Feature : IFeature, IEquatable<Feature>
    {
        private readonly Shapefile _shapefile;
        private readonly int _shapeIndex;

        internal Feature(Shapefile sf, int shapeIndex)
        {
            if (sf == null)
            {
                throw new NullReferenceException("Shapefile reference is null.");
            }

            if (shapeIndex < 0 || shapeIndex > sf.NumShapes)
            {
                throw new IndexOutOfRangeException("Feature index out of range.");
            }

            _shapefile = sf;
            _shapeIndex = shapeIndex;
        }

        internal Shapefile InternalShapefile
        {
            get { return _shapefile; }
        }

        internal int InternalShapeIndex
        {
            get { return _shapeIndex; }
        }

        #region IEquatable<Feature> Members

        public bool Equals(Feature other)
        {
            if (other == null)
            {
                return false;
            }

            return InternalShapefile == other.InternalShapefile && InternalShapeIndex == other.InternalShapeIndex;
        }

        #endregion

        public override bool Equals(object obj)
        {
            return Equals(obj as Feature);
        }

        public override int GetHashCode()
        {
            return InternalShapeIndex;
        }

        #region IFeature Members

        public IGeometry Geometry
        {
            get { return new Geometry(_shapefile.Shape[_shapeIndex]); }
        }

        public int CategoryIndex
        {
            get { return _shapefile.ShapeCategory[_shapeIndex]; }
            set { _shapefile.ShapeCategory[_shapeIndex] = value; }
        }

        public string CategoryName
        {
            get { return _shapefile.ShapeCategory2[_shapeIndex]; }
            set { _shapefile.ShapeCategory2[_shapeIndex] = value; }
        }

        public IFeatureCategory Category
        {
            get { return new FeatureCategory(_shapefile.ShapeCategory3[_shapeIndex]); }
            set { _shapefile.ShapeCategory3[_shapeIndex] = value.GetInternal(); }
        }

        public bool Hidden
        {
            get { return _shapefile.ShapeIsHidden[_shapeIndex]; }
            set { _shapefile.ShapeIsHidden[_shapeIndex] = value; }
        }

        public bool Modified
        {
            get { return _shapefile.ShapeModified[_shapeIndex]; }
            set { _shapefile.ShapeModified[_shapeIndex] = value; }
        }

        public double Rotation
        {
            get { return _shapefile.ShapeRotation[_shapeIndex]; }
            set { _shapefile.ShapeRotation[_shapeIndex] = value; }
        }

        public bool Selected
        {
            get { return _shapefile.ShapeSelected[_shapeIndex]; }
            set { _shapefile.ShapeSelected[_shapeIndex] = value; }
        }

        public bool IsRendered
        {
            get { return _shapefile.ShapeRendered[_shapeIndex]; }
        }

        public bool IsVisible
        {
            get { return _shapefile.ShapeVisible[_shapeIndex]; }
        }

        public int NumFields
        {
            get { return _shapefile.NumFields; }
        }

        public object GetValue(int fieldIndex)
        {
            return _shapefile.CellValue[fieldIndex, _shapeIndex];
        }

        public double GetAsDouble(int fieldIndex)
        {
            // TODO: check fieldIndex out of range
            return Convert.ToDouble(_shapefile.CellValue[fieldIndex, _shapeIndex]);
        }

        public int GetAsInteger(int fieldIndex)
        {
            return Convert.ToInt32(_shapefile.CellValue[fieldIndex, _shapeIndex]);
        }

        public string GetAsString(int fieldIndex)
        {
            return Convert.ToString(_shapefile.CellValue[fieldIndex, _shapeIndex]);
        }

        public bool SetValue(int fieldIndex, object value)
        {
            return _shapefile.EditCellValue(fieldIndex, _shapeIndex, value);
        }

        public bool SetDouble(int fieldIndex, double value)
        {
            return _shapefile.EditCellValue(fieldIndex, _shapeIndex, value);
        }

        public bool SetInteger(int fieldIndex, int value)
        {
            return _shapefile.EditCellValue(fieldIndex, _shapeIndex, value);
        }

        public bool SetString(int fieldIndex, string value)
        {
            return _shapefile.EditCellValue(fieldIndex, _shapeIndex, value);
        }

        public IFeatureField GetField(int fieldIndex)
        {
            return new FeatureField(_shapefile.Field[fieldIndex]);
        }

        #endregion
    }
}