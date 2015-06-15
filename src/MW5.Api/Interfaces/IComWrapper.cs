namespace MW5.Api.Interfaces
{
    public interface ISimpleComWrapper
    {
        object InternalObject { get; }
    }

    public interface IComWrapper: ISimpleComWrapper
    {
        string LastError { get; }
        string Tag { get; set; }
    }

    public interface ISerializableComWrapper : IComWrapper
    {
        string Serialize();
        bool Deserialize(string state);
    }
}
