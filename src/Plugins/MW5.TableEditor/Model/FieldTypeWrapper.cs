using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Enums;
using MW5.Api.Interfaces;

namespace MW5.Plugins.TableEditor.Model
{
    public class FieldTypeWrapper
    {
        private readonly IAttributeField _field;

        public FieldTypeWrapper(IAttributeField field)
        {
            if (field == null) throw new ArgumentNullException("field");
            _field = field;
        }

        public string Name
        {
            get { return _field.Name; }
        }

        [DisplayName(" ")]
        public string Type
        {
            get
            {
                switch (_field.Type)
                {
                    case AttributeType.String:
                        return "az";
                    case AttributeType.Integer:
                        return "09";
                    case AttributeType.Double:
                        return ".0";
                    default:
                        throw new ArgumentOutOfRangeException("Unexpected field type");
                }
            }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
