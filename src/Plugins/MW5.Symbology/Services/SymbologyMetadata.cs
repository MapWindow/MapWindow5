using System;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using MW5.Api;
using MW5.Api.Enums;
using MW5.Api.Interfaces;
using MW5.Plugins.Concrete;

namespace MW5.Plugins.Symbology.Services
{
    [Serializable, XmlRoot("SymbologyMetadata")]
    public class SymbologyMetadata: LayerMetadataBase
    {
        [DefaultValue(Classification.NaturalBreaks)]
        public Classification CategoriesClassification = Classification.NaturalBreaks;

        [DefaultValue(8)] 
        public int CategoriesCount = 8;

        [DefaultValue(false)]
        public bool CategoriesUseGradient = false;

        [DefaultValue(false)]
        public bool CategoriesRandomColors = false;

        // ColorBlend has Color[] array, which can't be serialized by default
        [XmlIgnore]
        public ColorBlend CategoriesColorScheme = null;

        [DefaultValue(null)]
        public XmlColorBlend CategoriesColorBlend
        {
            get { return CategoriesColorScheme != null ? new XmlColorBlend(CategoriesColorScheme) : null; }
            set { CategoriesColorScheme = value != null ? value.ColorBlend : null; }
        }

        [DefaultValue("")]
        public string CategoriesFieldName = "";

        [DefaultValue(false)]
        public bool CategoriesVariableSize = false;

        [DefaultValue(8)]
        public int CategoriesSizeRange = 8;

        [DefaultValue("")]
        public string CategoriesSortingField = "";

        [DefaultValue(true)]
        public bool ShowLayerPreview = true;

        [DefaultValue("")]
        public string Comments = "";

        [DefaultValue(true)]
        public bool UpdateMapAtOnce = true;

        [DefaultValue(true)]
        public bool ShowQueryValues = true;

        [DefaultValue(false)]
        public bool ShowQueryOnMap = false;

        [DefaultValue(-1)]
        public int IconIndex = -1;
    }
}
