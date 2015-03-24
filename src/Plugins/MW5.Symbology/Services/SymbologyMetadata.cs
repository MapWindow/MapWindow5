using System;
using System.Drawing.Drawing2D;
using System.Xml.Serialization;
using MW5.Api;
using MW5.Api.Plugins;

namespace MW5.Plugins.Symbology.Services
{
    [Serializable]
    [XmlType("SymbologyPlugin")]
    public class SymbologyMetadata: LayerMetadataBase
    {
        public Classification CategoriesClassification = Classification.NaturalBreaks;
        
        public Classification LabelsClassification = Classification.NaturalBreaks;

        public int CategoriesCount = 8;
        
        public bool CategoriesUseGradient = false;
        
        public bool CategoriesRandomColors = false;
        
        public ColorBlend CategoriesColorScheme = null;

        public ColorBlend LabelsScheme = null;

        public string CategoriesFieldName = "";
        
        public bool CategoriesVariableSize = false;
        
        public int CategoriesSizeRange = 8;
        
        public string CategoriesSortingField = "";

        public bool LabelsGraduatedColors = false;
        
        public bool LabelsRandomColors = false;
        
        public bool LabelsVariableSize = false;
        
        public int LabelsSchemeIndex = 0;
        
        public int LabelsSizeRange = 10;
        
        public int LabelsCategoriesCount = 6;
        
        public string LabelsFieldName = "";
        
        public int LabelsSize = 10;

        public bool ShowLayerPreview = true;
        
        public string Comments = "";

        public bool ScaleIcons = false;

        public int IconIndex = -1;

        public string IconCollection = "";

        public bool UpdateMapAtOnce = true;

        public bool ShowQueryValues = true;

        public bool ShowQueryOnMap = false;
    }
}
