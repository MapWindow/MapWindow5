using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using MW5.Api;
using MW5.Api.Concrete;
using MW5.Api.Enums;
using MW5.Api.Interfaces;
using MW5.Plugins.Services;
using MW5.Shared;

namespace MW5.Plugins.Symbology.Controls.ImageCombo
{
    internal class ColorSchemeCollection
    {
        private List<ColorBlend> _list = new List<ColorBlend>();
        private readonly string _filename;
        private readonly SchemeTarget _type;

        public ColorSchemeCollection(SchemeTarget type, string filename)
        {
            _type = type;
            _filename = filename;
            SelectedIndex = -1;
            ReadFromFile(filename);
        }

        /// <summary>
        /// Occurs when list of color scheme is edited by user.
        /// </summary>
        public event EventHandler<EventArgs> ListChanged;

        internal void FireListChanged()
        {
            var handler = ListChanged;
            if (handler != null)
            {
                handler(this, new EventArgs());
            }
        }

        /// <summary>
        /// Gets or sets selected index chosen by user.
        /// </summary>
        public int SelectedIndex { get; set; }

        public List<ColorBlend> List
        {
            get { return _list; }
            set { _list = value; }
        }

        public SchemeTarget Type
        {
            get { return _type; }
        }

        /// <summary>
        /// Sets dummy color scheme based on the shapefile default color. The color schemes is the first in the list.
        /// </summary>
        public void SetFirstColorScheme(IFeatureSet sf)
        {
            ColorBlend blend = null;
            if (List.Count <= 0)
            {
                blend = new ColorBlend(2);
                blend.Colors[0] = Color.Black; blend.Positions[0] = 0.0f;
                blend.Colors[1] = Color.Black; blend.Positions[1] = 1.0f;
                List.Add(blend);
            }

            blend = List[0];
            var shpType = sf.GeometryType;
            if (sf.PointOrMultiPoint || shpType == GeometryType.Polygon)
            {
                blend.Colors[0] = sf.Style.Fill.Color;
                blend.Colors[1] = sf.Style.Fill.Color;
            }
            else if (shpType == GeometryType.Polyline)
            {
                blend.Colors[0] = sf.Style.Line.Color;
                blend.Colors[1] = sf.Style.Line.Color;
            }

            FireListChanged();
        }

        public void SetFirstColorScheme(Color color)
        {
            ColorBlend blend = null;
            if (List.Count <= 0)
            {
                blend = new ColorBlend(2);
                blend.Colors[0] = Color.Black; blend.Positions[0] = 0.0f;
                blend.Colors[1] = Color.Black; blend.Positions[1] = 1.0f;
                List.Add(blend);
            }

            blend = List[0];

            blend.Colors[0] = color;
            blend.Colors[1] = color;

            FireListChanged();
        }

        private void SetDefaultColorSchemes()
        {
            switch (_type)
            {
                case SchemeTarget.Vector:
                    AddDefaultVectorSchemes();
                    break;
                case SchemeTarget.Charts:
                    AddDefaultChartSchemes();
                    break;
                case SchemeTarget.Raster:
                    AddDefaultRasterSchemes();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void AddDefaultRasterSchemes()
        {
            var values = Enum.GetValues(typeof (PredefinedColors));
            foreach (PredefinedColors value in values)
            {
                var sch = new ColorRamp();
                sch.SetColors(value);
                var blend = sch.ColorScheme2ColorBlend();
                List.Add(blend);
            }
        }

        private void AddDefaultChartSchemes()
        {
            ColorBlend blend = null;

            blend = new ColorBlend(2);
            blend.Colors[0] = Color.Yellow;
            blend.Positions[0] = 0.0f;
            blend.Colors[1] = Color.Orange;
            blend.Positions[1] = 1.0f;
            List.Add(blend);

            blend = new ColorBlend(2);
            blend.Colors[0] = Color.LightBlue;
            blend.Positions[0] = 0.0f;
            blend.Colors[1] = Color.Pink;
            blend.Positions[1] = 1.0f;
            List.Add(blend);

            blend = new ColorBlend(2);
            blend.Colors[0] = Color.LightGreen;
            blend.Positions[0] = 0.0f;
            blend.Colors[1] = Color.Yellow;
            blend.Positions[1] = 1.0f;
            List.Add(blend);
        }

        private void AddDefaultVectorSchemes()
        {
            ColorBlend blend = null;

            // dummy single color blend must be always the first for shapefile
            blend = new ColorBlend(2);
            blend.Colors[0] = Color.White;
            blend.Positions[0] = 0.0f;
            blend.Colors[1] = Color.White;
            blend.Positions[1] = 1.0f;
            List.Add(blend);

            blend = new ColorBlend(2);
            blend.Colors[0] = Color.LightBlue;
            blend.Positions[0] = 0.0f;
            blend.Colors[1] = Color.Orange;
            blend.Positions[1] = 1.0f;
            List.Add(blend);

            blend = new ColorBlend(2);
            blend.Colors[0] = Color.Yellow;
            blend.Positions[0] = 0.0f;
            blend.Colors[1] = Color.Orange;
            blend.Positions[1] = 1.0f;
            List.Add(blend);

            for (int i = 0; i < 2; i++)
            {
                var sch = new ColorRamp();
                if (i == 0) sch.SetColors(PredefinedColors.FallLeaves);
                if (i == 1) sch.SetColors(PredefinedColors.DeadSea);
                blend = sch.ColorScheme2ColorBlend();
                List.Add(blend);
            }

            // adding to 2 color schemes, as there can be none in the list
            blend = new ColorBlend(7);
            blend.Colors[0] = Color.Red;
            blend.Positions[0] = 0.0f;
            blend.Colors[1] = Color.Orange;
            blend.Positions[1] = 1.0f / 6.0f;
            blend.Colors[2] = Color.Yellow;
            blend.Positions[2] = 2.0f / 6.0f;
            blend.Colors[3] = Color.LightGreen;
            blend.Positions[3] = 3.0f / 6.0f;
            blend.Colors[4] = Color.LightBlue;
            blend.Positions[4] = 4.0f / 6.0f;
            blend.Colors[5] = Color.Blue;
            blend.Positions[5] = 5.0f / 6.0f;
            blend.Colors[6] = Color.BlueViolet;
            blend.Positions[6] = 1.0f;
            List.Add(blend);

            blend = new ColorBlend(2);
            blend.Colors[0] = Color.LightGray;
            blend.Positions[0] = 0.0f;
            blend.Colors[1] = Color.Gray;
            blend.Positions[1] = 1.0f;
            List.Add(blend);

            blend = new ColorBlend(2);
            blend.Colors[0] = Color.Pink;
            blend.Positions[0] = 0.0f;
            blend.Colors[1] = Color.LightYellow;
            blend.Positions[1] = 1.0f;
            List.Add(blend);
        }
        
        /// <summary>
        /// Saves the list of color schemes to XML file
        /// </summary>
        private XmlDocument Serialize2Xml()
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml("<MapWindow version= '" + "'></MapWindow>");     // TODO: add version
            var xelRoot = xmlDoc.DocumentElement;

            var xelSchemes = xmlDoc.CreateElement("ColorSchemes");

            // the first scheme must not be saved
            int j = _type == SchemeTarget.Vector ? 1 : 0;

            for (; j < List.Count; j++)
            {
                ColorBlend scheme = List[j];
                XmlElement xelScheme = xmlDoc.CreateElement("ColorScheme");
                for (int i = 0; i < scheme.Colors.Length; i++)
                {
                    XmlElement xel = xmlDoc.CreateElement("Break");
                    XmlAttribute attrColor = xmlDoc.CreateAttribute("Color");
                    XmlAttribute attrValue = xmlDoc.CreateAttribute("Value");

                    attrColor.InnerText = scheme.Colors[i].ToArgb().ToString();
                    attrValue.InnerText = scheme.Positions[i].ToString(System.Globalization.CultureInfo.InvariantCulture);

                    xel.Attributes.Append(attrColor);
                    xel.Attributes.Append(attrValue);
                    xelScheme.AppendChild(xel);
                }
                xelSchemes.AppendChild(xelScheme);
            }
            
            if (xelRoot != null)
            {
                xelRoot.AppendChild(xelSchemes);
            }

            return xmlDoc;
        }

        /// <summary>
        /// Initiliazes color schemes from XML document
        /// </summary>
        private bool LoadXml(XmlDocument xmlDoc)
        {
            if (xmlDoc.DocumentElement == null)
            {
                return false;
            }
            
            XmlElement xelSchemes = xmlDoc.DocumentElement["ColorSchemes"];
            if (xelSchemes == null)
            {
                return false;
            }
            
            // dummy single color blend 
            if (_type == SchemeTarget.Vector)
            {
                var blend = new ColorBlend(2);
                blend.Colors[0] = Color.Black; blend.Positions[0] = 0.0f;
                blend.Colors[1] = Color.Black; blend.Positions[1] = 1.0f;
                List.Add(blend);
            }

            foreach (XmlNode nodeScheme in xelSchemes.ChildNodes)
            {
                int i = 0;
                var scheme = new ColorBlend(nodeScheme.ChildNodes.Count);
                foreach (XmlNode nodeBreak in nodeScheme.ChildNodes)
                {
                    XmlAttribute attrValue = nodeBreak.Attributes["Value"];
                    XmlAttribute attrColor = nodeBreak.Attributes["Color"];
                    if (attrColor != null && attrValue != null)
                    {
                        double valDouble; int valInt;
                        bool parsed = false;
                        string s = attrValue.InnerText;

                        parsed = double.TryParse(s, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out valDouble);
                        if (!parsed)
                        {
                            s = s.Replace(',', '.');
                            parsed = double.TryParse(s, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out valDouble);
                        }

                        if (parsed && int.TryParse(attrColor.InnerText, out valInt))
                        {
                            scheme.Positions[i] = (float)valDouble;
                            scheme.Colors[i] = Color.FromArgb(valInt);
                            i++;
                        }
                    }
                }
                if (scheme.Colors.Length == i)
                {
                    List.Add(scheme);
                }
            }
            return true;
        }

        private void SaveToFile(string filename)
        {
            PathHelper.CreateFolder(filename);

            var xmlDoc = Serialize2Xml();
            
            try
            {
                xmlDoc.Save(filename);
            }
            catch (Exception ex)
            {
                Logger.Current.Warn("Failed to save color schemes: " + filename, ex);
            }
        }

        /// <summary>
        /// Reads the list of color schemes
        /// </summary>
        public void ReadFromFile(string filename)
        {
            List.Clear();

            var xmlDoc = new XmlDocument();

            if (File.Exists(filename))
            {
                xmlDoc.Load(filename);
                LoadXml(xmlDoc);
            }

            if (List.Count == 0)
            {
                SetDefaultColorSchemes();
            }
        }
    }
}
