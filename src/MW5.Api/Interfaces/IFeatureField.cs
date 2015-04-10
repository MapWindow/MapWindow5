using MW5.Api.Enums;

namespace MW5.Api.Interfaces
{
    public interface IFeatureField: IComWrapper
    {
        AttributeType Type { get; }
        string Name { get; set; }
        int Precision { get; }
        int Width { get; }
    }
}
