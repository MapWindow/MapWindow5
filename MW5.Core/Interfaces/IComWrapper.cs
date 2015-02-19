namespace MW5.Core.Interfaces
{
    public interface IComWrapper
    {
        object InternalObject { get; }
        string LastError { get; }
        string Tag { get; set; }
    }

    public interface ISerializableComWrapper : IComWrapper
    {
        string Serialize();
        bool Deserialize(string state);
    }
}
