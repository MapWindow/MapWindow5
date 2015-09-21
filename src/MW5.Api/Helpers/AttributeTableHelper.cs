using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Interfaces;

namespace MW5.Api.Helpers
{
    /// <summary>
    /// Extension methods for IAttributeTable interface.
    /// </summary>
    public static class AttributeTableHelper
    {
        /// <summary>
        /// Copies attributes between records of the same table
        /// </summary>
        public static void CopyAttributes(this IAttributeTable table, int sourceIndex, int targetIndex)
        {
            table.CopyAttributes(sourceIndex, table, targetIndex);
        }

        /// <summary>
        /// Copies attributes from source table to target table.
        /// </summary>
        public static void CopyAttributes(this IAttributeTable source, int sourceIndex, IAttributeTable target, int targetIndex)
        {
            var fields = source.Fields;
            for (int i = 0; i < fields.Count; i++)
            {
                if (fields[i].Name.ToLower() == "mwshapeid")
                {
                    continue;
                }
                target.EditCellValue(i, targetIndex, source.CellValue(i, sourceIndex));
            }
        }

        /// <summary>
        /// Copies selected attributes from source table to target table.
        /// </summary>
        public static void CopyAttributes(this IAttributeTable source, int sourceIndex, IAttributeTable target, int targetIndex, Dictionary<int, int> fieldMap)
        {
            if (fieldMap == null || target == null)
            {
                return;
            }

            var list = fieldMap.ToList();
            foreach (var fld in list)
            {
                object val = source.CellValue(fld.Key, sourceIndex);
                target.EditCellValue(fld.Value, targetIndex, val);
            }
        }

        /// <summary>
        /// Builds dictionary which maps fields of source table to target table.
        /// Fields are compared by name and type.
        /// </summary>
        public static Dictionary<int, int> BuildFieldMap(this IAttributeTable source, IAttributeTable target)
        {
            var dict = new Dictionary<int, int>();

            var fields = source.Fields;
            for (int i = 0; i < fields.Count; i++)
            {
                var fld = fields[i];
                var fldTarget = target.Fields[fld.Name];
                if (fldTarget == null || fld.Type != fldTarget.Type)
                {
                    continue;
                }
                int targetIndex = target.Fields.IndexByName(fldTarget.Name);
                if (targetIndex != -1)
                {
                    dict.Add(i, targetIndex);
                }
            }
            return dict;
        }
    }
}
