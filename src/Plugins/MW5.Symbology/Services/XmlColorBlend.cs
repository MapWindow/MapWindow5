using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Plugins.Symbology.Services
{
    public class XmlColorBlend
    {
        public XmlColorBlend()
        {
            
        }

        public XmlColorBlend(ColorBlend blend)
        {
            if (blend == null) throw new ArgumentNullException("blend");

            Items = new List<ColorBlendItem>();

            for (int i = 0; i < blend.Colors.Count(); i++)
            {
                Items.Add(new ColorBlendItem(blend.Colors[i], blend.Positions[i]));
            }
        }

        public List<ColorBlendItem> Items { get; set; }

        public ColorBlend ColorBlend
        {
            get
            {
                var blend = new ColorBlend(Items.Count);

                for (int i = 0; i < Items.Count; i++)
                {
                    blend.Colors[i] = ColorTranslator.FromHtml(Items[i].Color);
                    blend.Positions[i] = Items[i].Position;
                }

                return blend;
            }
        }
    }

    public class ColorBlendItem
    {
        public ColorBlendItem()
        {
            
        }

        public ColorBlendItem(Color color, float position)
        {
            Color = ColorTranslator.ToHtml(color);
            Position = position;
        }

        public string Color { get; set; }
        public float Position { get; set; }
    }
}
