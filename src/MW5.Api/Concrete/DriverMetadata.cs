using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Xml.Linq;
using MW5.Api.Enums;
using MW5.Shared;

namespace MW5.Api.Concrete
{
    public class DriverMetadata
    {
        private const string GdalUrl = "http://www.gdal.org/";
        private string _value;

        public DriverMetadata(string name, string value, GdalDriverMetadata type)
        {
            _value = value;
            Name = name;
            Type = type;
        }

        [DisplayName("Name")]
        public string FriendlyName
        {
            get
            {
                string s = Type.EnumToString();
                return string.IsNullOrWhiteSpace(s) ? Name : s;
            }
        }

        public string Value
        {
            get
            {
                if (Type == GdalDriverMetadata.HelpTopic)
                {
                    return GdalUrl + _value;
                }

                return _value;
            }
        }

        [Browsable(false)]
        public string Name { get; private set; }

        [Browsable(false)]
        public GdalDriverMetadata Type { get; private set;}

        public static IEnumerable<DriverOption> ParseOptionList(string optionList)
        {
            try
            {
                XDocument doc = XDocument.Parse(optionList);
                var list = doc.Descendants("Option").Select(item => new DriverOption(
                    item.Attribute("name"),
                    item.Attribute("type"),
                    item.Attribute("description"),
                    item.Attribute("default"),
                    item.Descendants()
                    ));

                return list;
            }
            catch(Exception ex)
            {
                Logger.Current.Warn("Failed to parse driver options: " + optionList);
            }

            return new List<DriverOption>()
            {
                new DriverOption("<failed to parse XML>")
            };
        }
    }
}
