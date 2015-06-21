using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace MW5.Shared
{
    public static class EnumHelper
    {
        private static Dictionary<Type, object> _dict = new Dictionary<Type, object>();

        public static void RegisterConverter<T>(IEnumConverter<T> converter) where T : struct, IConvertible
        {
            var t = new T();
            _dict.Add(t.GetType(), converter);
        }

        public static Func<T, string> GetToStringFunction<T>() where T : struct, IConvertible
        {
            var t = new T();
            var type = t.GetType();
            object val;
            if (_dict.TryGetValue(type, out val))
            {
                var converter = val as IEnumConverter<T>;
                if (converter != null)
                {
                    return converter.GetString;
                }
            }
            return null;
        }

        public static IEnumerable<string> GetStrings<T>() where T : struct, IConvertible
        {
            var t = new T();
            var type = t.GetType();
            var values = Enum.GetValues(type);
            return from T value in values select EnumToString(value);
        }

        public static string EnumToString<T>(this T value) where T : struct, IConvertible
        {
            var fn = GetToStringFunction<T>();

            if (fn != null)
            {
                return fn(value);
            }

            return value.ToString(CultureInfo.InvariantCulture);
        }
    }
}
