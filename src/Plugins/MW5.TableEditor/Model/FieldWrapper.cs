using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Concrete;
using MW5.Api.Interfaces;

namespace MW5.Plugins.TableEditor.Model
{
    public class FieldWrapper
    {
        private readonly IAttributeField _field;

        public FieldWrapper(IAttributeField field)
        {
            if (field == null) throw new ArgumentNullException("field");
            _field = field;
        }

        public string Name
        {
            get { return _field.Name; }
        }

        [DisplayName(" ")]
        public bool Selected { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
