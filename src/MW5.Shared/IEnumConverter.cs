using System;

namespace MW5.Shared
{
    public interface IEnumConverter<T> where T : IConvertible
    {
        string GetString(T value);
    }
}
