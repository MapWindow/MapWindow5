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

    public enum RasterClassification
    {
        EqualIntervals = 1,
        EqualCount = 2,
        UniqueValues = 3,
    }

    public enum MinMaxCalculationType
    {
        Precise = 0,
        PercentRange = 1,
        StdDev = 2,
    }

    public enum RasterStyleTab
    {
        None = -1,
        General = 0,
        Colors = 1,
        Rendering = 2,
        Histogram = 3,
        Pyramids = 4,
        Info = 5,
    }

    public enum CategoriesCommand
    {
        ChangeColorScheme = 0,
        CategoryRemove = 1,
        CategoryClear = 2,
        CategoryAppearance = 3,
        CategoryGenerate = 4,
    }

    public enum VectorStyleCommand
    {
        OpenLocation = 0,
        SaveStyle = 1,
        RemoveStyle = 2,
        ProjectionDetails = 3,
        ChartAppearance = 4,
        ClearCharts = 5,
        ChartsEditColorScheme = 6,
        LabelAppearance = 7,
        ClearLabels = 8,
        ChangeVisibilityExpression = 9,
        ClearVisibilityExpression = 10,
    }
}

