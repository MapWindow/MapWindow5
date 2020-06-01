using MW5.Api.Enums;

namespace MW5.Api.Interfaces
{
    public interface IFeatureCategory: IComWrapper , IDynamicVisibilityTarget
    {
        IGeometryStyle Style { get; }
        CategoryValue ValueType { get; }
        string Expression { get; set; }
        string Name { get; set; }
        string MaxValue { get; }
        string MinValue { get; }
        bool Numeric { get; }
        double GetMinValue();
        double GetMaxValue();
        void SetValue(double value);
        void SetRange(double min, double max);
        int Index { get; }
    }
}