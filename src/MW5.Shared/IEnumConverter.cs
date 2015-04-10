using System;

namespace MW5.Shared
{
    public interface IEnumConverter<T> where T : struct, IConvertible
    {
        string GetString(T value);
    }
}
