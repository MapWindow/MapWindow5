using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Concrete;
using MW5.Api.Interfaces;

namespace MW5.Plugins.ShapeEditor.Helpers
{
    public static class AttributeTableHelper
    {
        public static void CopyAttributes(this IAttributeTable table, int sourceIndex, int targetIndex)
        {
            table.CopyAttributes(sourceIndex, table, targetIndex);
        }

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
