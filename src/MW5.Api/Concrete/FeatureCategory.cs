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

        public FeatureCategory(string name)
        {
            _category = new ShapefileCategory {Name = name};
        }

        internal FeatureCategory(ShapefileCategory category)
        {
            if (category == null)
            {
                throw new NullReferenceException();
            }
            _category = category;
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
