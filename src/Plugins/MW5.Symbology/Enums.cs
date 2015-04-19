namespace MW5.Plugins.Symbology
{
    /// <summary>
    ///  Available styles for image combo. All apart from common have fixed set of icons.
    /// </summary>
    internal enum ImageComboStyle
    {
        Common = 0,
        LineStyle = 1,
        LineWidth = 2,
        LinearGradient = 3,
        FrameType = 4,
        PointShape = 5,
        HatchStyle = 6,
        HatchStyleWithNone = 9,
    }

    internal enum SymbologyType
    {
        Default = 0,
        Random = 1,
        Custom = 2,
    }

    /// <summary>
    /// Color scheme lists used in the plug-in
    /// </summary>
    internal enum ColorSchemes
    {
        Default = 0,
        Charts = 1,
    }

    internal enum RasterRendering
    {
        SingleBand = 0,
        MultiBand = 1,
        PsuedoColors = 2,
        BuiltInColorTable = 3,
    }
 }

