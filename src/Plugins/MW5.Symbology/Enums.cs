namespace MW5.Plugins.Symbology
{


    internal enum SymbologyType
    {
        Default = 0,
        Random = 1,
        Custom = 2,
    }

    /// <summary>
    /// Color scheme lists used in the plug-in
    /// </summary>
    internal enum SchemeTarget
    {
        Vector = 0,
        Charts = 1,
        Raster = 2,
    }

    public enum RasterRendering
    {
        SingleBand = 0,
        MultiBandRgb = 1,
        ColorScheme = 2,
        BuiltInColorTable = 3,
    }

    public enum RasterClassification
    {
        EqualIntervals = 1,
        UniqueValues = 2,
    }

    public enum MinMaxCalculationType
    {
        Precise = 0,
        PercentRange = 1,
        StdDev = 2,
    }
}

