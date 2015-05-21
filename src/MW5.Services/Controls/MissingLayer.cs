using System.ComponentModel;

namespace MW5.Services.Controls
{
    public class MissingLayer
    {
        public MissingLayer(string name, string filename, object tag)
        {
            Name = name;
            Filename = filename;
            Tag = tag;
        }

        
        [Browsable(false)]
        public object Tag { get; private set; }

        [DisplayName("Layer name")]
        public string Name { get; private set; }

        [DisplayName("Datasource filename")]
        public string Filename { get; set; }
    }
}
