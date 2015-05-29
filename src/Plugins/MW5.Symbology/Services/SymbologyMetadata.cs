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
    [Serializable]
    [XmlType("SymbologyMetadata")]
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

        // TODO: Make a wrapper. Color isn't serialized by default
        //http ://stackoverflow.com/questions/376234/best-solution-for-xmlserializer-and-system-drawing-color
        [DefaultValue(null)]
        public ColorBlend CategoriesColorScheme = null;     

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
