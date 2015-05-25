using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace MW5.Api.Concrete
{
    public class DriverOption
    {
        private List<string> _values = new List<string>();

        public DriverOption(string name)
        {
            Name = name;
        }

        public DriverOption(XAttribute name, 
                            XAttribute type, 
                            XAttribute description, 
                            XAttribute defaultValue, 
                            IEnumerable<XElement> values)
        {
            if (name != null)
            {
                Name = name.Value;
            }

            if (type != null)
            {
                Type = type.Value;
            }

            if (description != null)
            {
                Description = description.Value;
            }

            if (defaultValue != null)
            {
                DefaultValue = defaultValue.Value;
            }

            if (values != null )
            {
                _values = values.Select(item => item.Value.ToLower()).ToList();
            }
        }

        public string Name { get; set; }
        public string Type { get; set; }

        [DisplayName("Description")]
        public string UserDescription 
        {
            get
            {
                string separator = string.Empty;

                var list = ValuesList;
                
                if (!string.IsNullOrWhiteSpace(list) && !string.IsNullOrWhiteSpace(Description))
                {
                    separator = Environment.NewLine;
                }

                return Description + separator + list;
            }
        }

        [DisplayName("Default")]
        public string DefaultValue { get; set; }

        [Browsable(false)]
        public string Description { get; set; }

        [Browsable(false)]
        public IEnumerable<string> Values
        {
            get { return _values; }
        }

        private string ValuesList
        {
            get
            {
                if (_values.Count == 0)
                {
                    return string.Empty;
                }

                string s = string.Join(", ", _values);

                return "Values: {" + s + "}";
            }
        }

    }
}
