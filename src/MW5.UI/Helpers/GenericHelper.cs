using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MW5.UI.Helpers
{
    public static class GenericHelper
    {
        public static string GetPropertyName<T>(Expression<Func<T, object>> propertySelector) 
            where T: class
        {
            var me = propertySelector.Body as MemberExpression;
            if (me != null)
            {
                return me.Member.Name;
            }

            var ubody = propertySelector.Body as UnaryExpression;
            if (ubody != null)
            {
                var expr = ubody.Operand as MemberExpression;
                if (expr != null)
                {
                    return expr.Member.Name;
                }
            }

            return string.Empty;
        }

        public static string GetTypedPropertyName<T, TT>(Expression<Func<T, TT>> propertySelector)
        {
            var expr = propertySelector.Body as MemberExpression;
            if (expr == null)
            {
                return string.Empty;
            }

            return expr.Member.Name;
        }
    }
}
