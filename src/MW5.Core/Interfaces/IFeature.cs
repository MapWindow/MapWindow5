namespace MW5.Core.Interfaces
{
    public interface IFeature
    {
        IGeometry Geometry { get; }

        int CategoryIndex { get; set; }
        string CategoryName { get; set; }
        IFeatureCategory Category { get; set; }

        bool Hidden { get; set; }
        bool Modified { get; set; }
        double Rotation { get; set; }
        bool Selected { get; set; }
        bool IsRendered { get; }
        bool IsVisible { get; }

        int NumFields { get; }
        object GetValue(int fieldIndex);
        double GetAsDouble(int fieldIndex);
        int GetAsInteger(int fieldIndex);
        string GetAsString(int fieldIndex);
        bool SetValue(int fieldIndex, object value);
        bool SetDouble(int fieldIndex, double value);
        bool SetInteger(int fieldIndex, int value);
        bool SetString(int fieldIndex, string value);
        IFeatureField GetField(int fieldIndex);
    }
}