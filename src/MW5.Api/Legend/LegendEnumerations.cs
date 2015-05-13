namespace MW5.Api.Legend
{
    /// <summary>
    /// Enumeration of supported layer types.
    /// </summary>
    public enum LegendLayerType
    {
        /// <summary>
        /// Invalid layer type
        /// </summary>
        Invalid = -1,

        /// <summary>
        /// Image layer
        /// </summary>
        Image = 0,

        /// <summary>
        /// Point shapefile layer
        /// </summary>
        PointShapefile = 1,

        /// <summary>
        /// Line shapefile layer
        /// </summary>
        LineShapefile = 2,

        /// <summary>
        /// Polygon shapefile layer
        /// </summary>
        PolygonShapefile = 3,

        /// <summary>
        /// Grid layer
        /// </summary>
        Grid = 4
    }


    /// <summary>
    /// Visibility State of a Group
    /// </summary>
    public enum Visibility
    {
        /// <summary>
        /// All Layers are Visible
        /// </summary>
        AllVisible = 0,

        /// <summary>
        /// All Layers are Hidden
        /// </summary>
        AllHidden = 1,

        /// <summary>
        /// Mixed Layer Visibility
        /// </summary>
        PartiallyVisible = 2
    }

    internal enum LegendIcon
    {
        Grid = 0,
        Image = 1,
        CheckedBox = 2,
        UnCheckedBox = 3,
        CheckedBoxGray = 4,
        UnCheckedBoxGray = 5,
        ActiveLabel = 6,
        DimmedLabel = 7,
        Editing = 8,
        Database = 9,
        Folder = 10,
        FolderOpened = 11,
    }

    /// <summary>
    /// Elements of the layer representation in the legend
    /// </summary>
    internal enum LayerElementType
    {
        None = 0,
        Name = 1,
        Symbol = 2,
        Label = 3,
        CategoriesCaption = 4,
        CategoryName = 5,
        ChartsCaption = 7,
        Charts = 8,
        ChartField = 9,
        ChartFieldName = 10,
        CheckBox = 11,
        ExpansionBox = 12,
        RasterColorInterval = 13,
    }

    public enum LegendRedraw
    {
        LegendOnly = 0,
        LegendAndMap = 1,
        LegendAndMapForce = 2,
    }
}