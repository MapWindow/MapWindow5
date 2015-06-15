using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Enums;
using MW5.Api.Interfaces;

namespace MW5.Plugins.TableEditor.Views
{
    public class FieldCalculatorModel
    {
        public FieldCalculatorModel(IAttributeTable table, IAttributeField field)
        {
            if (table == null) throw new ArgumentNullException("table");
            if (field == null) throw new ArgumentNullException("field");

            Table = table;
            Field = field;
        }

        public IAttributeTable Table { get; private set; }
        public IAttributeField Field { get; private set; }

        public TableValueType ReturnType
        {
            get
            {
                switch (Field.Type)
                {
                    case AttributeType.String:
                        return TableValueType.String;
                    case AttributeType.Integer:
                    case AttributeType.Double:
                        return TableValueType.Double;
                }

                throw new ApplicationException("Unexpected field type.");
            }
        }
    }
}
