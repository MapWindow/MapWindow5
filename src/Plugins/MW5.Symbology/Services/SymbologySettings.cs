using System;
using System.Drawing.Drawing2D;
using System.Xml.Serialization;
using MW5.Api;

namespace MW5.Plugins.Symbology.Services
{
    [Serializable]
    [XmlType("SymbologyPlugin")]
    internal class SymbologySettings
    {
        [XmlAttribute()]
        public Classification CategoriesClassification = Classification.NaturalBreaks;
        [XmlAttribute()]
        public int CategoriesCount = 8;
        [XmlAttribute()]
        public bool CategoriesUseGradient = false;
        [XmlAttribute()]
        public bool CategoriesRandomColors = false;
        [XmlElement]
        public ColorBlend CategoriesColorScheme = null;
        [XmlAttribute()]
        public string CategoriesFieldName = "";
        [XmlAttribute()]
        public bool CategoriesVariableSize = false;
        [XmlAttribute()]
        public int CategoriesSizeRange = 8;
        [XmlAttribute()]
        public string CategoriesSortingField = "";

        [XmlAttribute()]
        public bool LabelsGraduatedColors = false;
        [XmlAttribute()]
        public bool LabelsRandomColors = false;
        [XmlAttribute()]
        public bool LabelsVariableSize = false;
        [XmlElement]
        public ColorBlend LabelsScheme = null;
        [XmlAttribute()]
        public int LabelsSchemeIndex = 0;
        [XmlAttribute()]
        public int LabelsSizeRange = 10;
        [XmlAttribute()]
        public int LabelsCategoriesCount = 6;
        [XmlAttribute()]
        public string LabelsFieldName = "";
        [XmlAttribute()]
        public Classification LabelsClassification = Classification.NaturalBreaks;
        [XmlAttribute()]
        public int LabelsSize = 10;

        [XmlAttribute()]
        public bool ShowLayerPreview = true;
        [XmlAttribute()]
        public string Comments = "";

        [XmlAttribute()]
        public bool ScaleIcons = false;
        [XmlAttribute()]
        public int IconIndex = -1;
        [XmlAttribute()]
        public string IconCollection = "";
        [XmlAttribute()]
        public bool UpdateMapAtOnce = true;
        [XmlAttribute()]
        public bool ShowQueryValues = true;
        [XmlAttribute()]
        public bool ShowQueryOnMap = false;
    }
}
