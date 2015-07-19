using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Shared
{
    /// <summary>
    /// Extension methods for Attribute class.
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    public static class AttributeHelper
    {        
        /// <summary>
        /// Gets value of the specified attribute for type.
        /// </summary>
        /// <remarks>From http ://stackoverflow.com/questions/2656189/how-do-i-read-an-attribute-on-a-class-at-runtime</remarks>
        public static TValue GetAttributeValue<TAttribute, TValue>(this Type type, Func<TAttribute, TValue> valueSelector) 
            where TAttribute : Attribute
        {
            var att = type.GetCustomAttributes(typeof(TAttribute), true).FirstOrDefault() as TAttribute;

            if (att != null)
            {
                return valueSelector(att);
            }

            return default(TValue);
        }
    }
}
