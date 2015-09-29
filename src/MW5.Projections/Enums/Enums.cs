namespace MW5.Projections.Enums
{
    /// <summary>
    /// Possible results of testing
    /// </summary>
    public enum TestingResult
    {
        /// <summary>
        /// Object is ok or user has ignored the mismatch
        /// </summary>
        Ok = 0,
        /// <summary>
        /// File should be skipped
        /// </summary>
        SkipFile = 1,
        /// <summary>
        /// Operatio should be canceled
        /// </summary>
        CancelOperation = 2,
        /// <summary>
        /// Error occured while processing
        /// </summary>
        Error = 3,
        /// <summary>
        /// The layer object was substituted by another file
        /// </summary>
        Substituted = 4
    }

    public enum ProjectionOperaion
    {
        Reprojected = 0,
        Assigned = 1,
        Skipped = 2,
        AbsenceIgnored = 3,
        MismatchIgnored = 4,
        Substituted = 5,
        FailedToReproject = 6,
        SameProjection = 7,
    }

    /// <summary>
    /// Types of projection report
    /// </summary>
    public enum ReportType
    {
        Loading = 0,
        Assignment = 1,
    }

    /// <summary>
    /// Selection mode for set extents operation
    /// </summary>
    public enum ProjectionSelectionMode
    {
        /// <summary>
        /// Selects those objects that are completely within extents
        /// </summary>
        Include = 0,

        /// <summary>
        /// Selects those objects that are completely within bounding box or intersects it
        /// </summary>
        Intersection = 1,

        /// <summary>
        /// Selects those objects that completely covers specified extents
        /// </summary>
        IsIncluded = 2,
    }

    public enum DialectsCommand
    {
        AddDialect = 0,
        RemoveDialect = 1,
        ClearDialects = 2,
        EditDialect = 3,
    }

    public enum DialectFormat
    {
        Proj4 = 0,
        Wkt = 1
    }
}
