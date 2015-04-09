using System;

namespace MW5.Api.Helpers
{
    public interface IEnumConverter<T> where T : struct, IConvertible
    {
        string GetString(T value);
    }
}
