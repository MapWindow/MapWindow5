using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Concrete;
using MW5.Plugins.Interfaces;
using MW5.Services.Serialization.Utility;

namespace MW5.Services.Serialization
{
    [DataContract]
    public class XmlMapLocator
    {
        public XmlMapLocator(ILocator locator, ImageSerializationService service)
        {
            if (locator == null) throw new ArgumentNullException("locator");
            if (service == null) throw new ArgumentNullException("service");
            
            var img = locator.Picture;
            if (img == null)
            {
                return;
            }

            var bitmap = img.ToGdiPlusBitmap();
            string type;

            Image = service.ConvertImageToString(bitmap, out type);
            Type = type;
            Dx = img.Dx;
            Dy = img.Dy;
            XllCenter = img.XllCenter;
            YllCenter = img.YllCenter;
        }

        [DataMember]
        public string Image { get; set; }

        [DataMember]
        public string Type { get; set; }

        [DataMember]
        public double Dx { get; set; }

        [DataMember]
        public double Dy { get; set; }

        [DataMember]
        public double XllCenter { get; set; }

        [DataMember]
        public double YllCenter { get; set; }
    }
}
