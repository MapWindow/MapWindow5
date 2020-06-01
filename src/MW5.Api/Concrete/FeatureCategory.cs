using System;
using MapWinGIS;
using MW5.Api.Enums;
using MW5.Api.Helpers;
using MW5.Api.Interfaces;

namespace MW5.Api.Concrete
{
    public class FeatureCategory : IFeatureCategory
    {
        private readonly ShapefileCategory _category;
        private readonly int _index = -1;

        public FeatureCategory(string name)
        {
            _category = new ShapefileCategory {Name = name};
        }

        internal FeatureCategory(ShapefileCategory category, int index)
        {
            if (category == null)
            {
                throw new NullReferenceException();
            }
            _category = category;
            _index = index;
        }

        public int Index
        {
            get { return _index; }
        }

        public object InternalObject
        {
            get { return _category; }
        }

        public string LastError
        {
            get { return ErrorHelper.NO_ERROR; }
        }

        public string Tag
        {
            get { throw new NotSupportedException(); }
            set { throw new NotSupportedException(); }
        }

        public IGeometryStyle Style
        {
            get { return new GeometryStyle(_category.DrawingOptions); }
        }

        public CategoryValue ValueType
        {
            get { return (CategoryValue)_category.ValueType; }
        }

        public string Expression
        {
            get { return _category.Expression; }
            set { _category.Expression = value; }
        }

        public string Name
        {
            get { return _category.Name; }
            set { _category.Name = value; }
        }

        public string MaxValue
        {
            get { return _category.MaxValue.ToString(); }
        }

        public string MinValue
        {
            get { return _category.MinValue.ToString(); }
        }

        public bool Numeric
        {
            get
            {
                if (_category.ValueType == tkCategoryValue.cvRange ||
                    _category.ValueType == tkCategoryValue.cvSingleValue)
                {
                    double val, val2;
                    return Double.TryParse(_category.MaxValue.ToString(), out val) &&
                           Double.TryParse(_category.MinValue.ToString(), out val2);
                }
                return false;
            }
        }

        public bool DynamicVisibility {
            get => _category.DrawingOptions.DynamicVisibility;
            set => _category.DrawingOptions.DynamicVisibility = value;
        }
        public int MinVisibleZoom
        {
            get => _category.DrawingOptions.MinVisibleZoom;
            set => _category.DrawingOptions.MinVisibleZoom = value;
        }
        public int MaxVisibleZoom
        {
            get => _category.DrawingOptions.MaxVisibleZoom;
            set => _category.DrawingOptions.MaxVisibleZoom = value;
        }
        public double MinVisibleScale
        {
            get => _category.DrawingOptions.MinVisibleScale;
            set => _category.DrawingOptions.MinVisibleScale = value;
        }
        public double MaxVisibleScale
        {
            get => _category.DrawingOptions.MaxVisibleScale;
            set => _category.DrawingOptions.MaxVisibleScale = value;
        }

        public double GetMinValue()
        {
            double val;
            Double.TryParse(_category.MinValue.ToString(), out val);
            return val;
        }

        public double GetMaxValue()
        {
            double val;
            Double.TryParse(_category.MaxValue.ToString(), out val);
            return val;
        }

        public void SetValue(double value)
        {
            _category.ValueType = tkCategoryValue.cvSingleValue;
            _category.MinValue = value;
            _category.MaxValue = value;
        }

        public void SetRange(double min, double max)
        {
            _category.ValueType = tkCategoryValue.cvRange;
            _category.MinValue = Math.Min(min, max);
            _category.MaxValue = Math.Max(min, max);
        }

        
    }
}
