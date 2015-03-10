namespace MW5.Api.Interfaces
{
    public interface IFeatureField: IComWrapper
    {
        AttributeType Type { get; }
        string Name { get; }
        int Precision { get; }
        int Width { get; }
    }
}
