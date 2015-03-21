using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.UI.Helpers
{
    public static class EnumHelper
    {
        private static Dictionary<Type, object> _dict = new Dictionary<Type,object>();
        
        public static IEnumerable<ComboBoxEnumItem<T>> GetComboItems<T>(IEnumerable<T> items) where T : struct, IConvertible
        {
            return items.Select(item => new ComboBoxEnumItem<T>(item, GetToStringFunction<T>()));
        }

        public static void RegisterConverter<T>(IEnumConverter<T> converter) where T: struct, IConvertible
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

        public static string EnumToString<T>(this T value) where T: struct, IConvertible
        {
            var fn = GetToStringFunction<T>();
            return fn(value);
        }
    }
}
