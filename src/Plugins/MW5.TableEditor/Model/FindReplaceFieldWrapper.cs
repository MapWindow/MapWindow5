using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Interfaces;

namespace MW5.Plugins.TableEditor.Model
{
    public class FindReplaceFieldWrapper
    {
        public FindReplaceFieldWrapper()
        {
            FieldType = FindReplaceFieldType.All;
        }

        public FindReplaceFieldWrapper(IAttributeField field)
        {
            if (field == null) throw new ArgumentNullException("field");
            Field = field;
            FieldType = FindReplaceFieldType.Regular;
        }

        public IAttributeField Field { get; private set; }
        public FindReplaceFieldType FieldType { get; private set; }

        public override string ToString()
        {
            switch (FieldType)
            {
                case FindReplaceFieldType.Regular:
                    return Field.DisplayName;
                case FindReplaceFieldType.All:
                    return "<all>";
            }

            return "<n/d>";
        }
    }
}
