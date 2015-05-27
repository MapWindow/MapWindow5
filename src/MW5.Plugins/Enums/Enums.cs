namespace MW5.Plugins.Enums
{
    public enum GeoDatabaseType
    {
        PostGis = 0,
        SpatiaLite = 1,
        Oracle = 2,
        MsSql = 3,
        MySql = 4,
    }

    public enum DataSourceType
    {
        Vector = 0,
        Raster = 1,
        All = 2,
        SpatiaLite = 3,
    }

    public enum ProjectState
    {
        NotSaved = 0,
        HasChanges = 1,
        NoChanges = 2,
        Empty = 3,
    }

    public enum DockPanelState
    {
        None = 0,
        Left = 1,
        Right = 2,
        Top = 3,
        Bottom = 4,
        Tabbed = 5,
    }

    public enum DockPanels
    {
        Legend = 0,
        Preview = 1,
    }

    /// <summary>
    /// Defines types of behaviors when a projection for an layer being added is different from project one
    /// </summary>
    public enum ProjectionMismatch
    {
        IgnoreMismatch = 0,
        Reproject = 1,
        SkipFile = 2,
    }

    /// <summary>
    /// The type of geographic coordinate system
    /// </summary>
    public enum GeographicalCsType
    {
        /// <summary>
        /// Coordinate system used for a single country
        /// </summary>
        Local = 0,

        /// <summary>
        /// Coordinate system used inside certain region
        /// </summary>
        Regional = 1,

        /// <summary>
        /// Coordinate system used around the World
        /// </summary>
        Global = 2,
    }

    /// <summary>
    /// Defines types of behaviors when there is no projection for a layer being added, but the project has one
    /// </summary>
    public enum ProjectionAbsence
    {
        AssignFromProject = 0,
        IgnoreAbsence = 1,
        SkipFile = 2,
    }

    /// <summary>
    /// Serach types used by GetCoordinateSystemFunction
    /// </summary>
    public enum ProjectionSearchType
    {
        /// <summary>
        /// Only comparison by name among geographic and projected coordinate systems is made
        /// </summary>
        Standard = 0,

        /// <summary>
        /// Same as standard, but additional after using proj4 export-import operation
        /// </summary>
        Enhanced = 1,

        /// <summary>
        /// The same as enhanced, but dialects are used
        /// </summary>
        UseDialects = 2,
    }

    /// <summary>
    /// Enumeration of possible preview map update types.
    /// </summary>
    public enum PreviewExtents
    {
        /// <summary>
        /// Update using full exents.
        /// </summary>
        FullExtents = 0,
        /// <summary>
        /// Update using current map view.
        /// </summary>
        CurrentMapView = 1
    }

    public enum DefaultDockPanel
    {
        Legend = 0,
        Toolbox = 1,
        Locator = 2,
    }

    public enum ToolbarDockState
    {
        //
        // Summary:
        //     The CommandBar is docked to the top border of the form.
        Top = 1,
        //
        // Summary:
        //     The CommandBar is docked to the bottom border of the form.
        Bottom = 2,
        //
        // Summary:
        //     The CommandBar is docked to the left border of the form.
        Left = 4,
        //
        // Summary:
        //     The CommandBar is docked to the right border of the form.
        Right = 8,
        //
        // Summary:
        //     The CommandBar is in a floating state.
        Float = 32,
    }

    public enum ConfigPageType
    {
        General = 0,
        Map = 1,
        Plugins = 2,
        LayerOpening = 3,
        Custom = 4,
    }

    public enum SymbologyStorage
    {
        Project = 0,
        StyleFile = 1,
    }
}
