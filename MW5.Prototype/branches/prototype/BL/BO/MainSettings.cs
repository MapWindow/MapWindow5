using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml.Serialization;

namespace BL.BO
{
    //[Serializable]
    //[XmlRoot(ElementName = "MainSettings", IsNullable = true)]
    //public class MainSettings
    //{
    //}

    [XmlRoot("MapwinSettings")]
    public class MainSettings : BaseSettings
    {
        public MainSettings() : base(Assembly.GetExecutingAssembly().GetName().Name)
        {
        }

        [XmlElement(ElementName = "Some")]
        public Some SomeSection { get; set; }

        [XmlElement(ElementName = "Other")]
        public Other OtherSection { get; set; }

        //public override bool InitializeItems()
        //{
        //    SomeSection = new Some();
        //    SomeSection.Color = String.Empty;
        //    SomeSection.Name = String.Empty;
        //    SomeSection
        //}

        public class Some
        {
            public string Name { get; set; }
            public int Version { get; set; }
            public string Color { get; set; }
        }

        public class Other
        {
            
        }
    }
}
