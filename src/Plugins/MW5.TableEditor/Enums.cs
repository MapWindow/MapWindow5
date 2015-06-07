namespace MW5.Plugins.TableEditor
{
    public enum TableEditorCommand
    {
        Close = 0,
        SaveChanges = 1,
        ZoomToSelected = 2,
        ShowSelected = 3,
        StartEdit = 4,
        AddField = 5,
        RemoveField = 6,
        RenameField = 7,
        SelectAll = 8,
        ClearSelection = 9,
        InvertSelection = 10,
        CalculateField = 11,
        Join = 12,
    }

    /// <summary>The unit of area.</summary>
    /// <remarks>This should be in the MW core</remarks>
    public enum UnitOfArea
    {
        /// <summary>The decimal degrees.</summary>
        DecimalDegrees,

        /// <summary>The millimeters.</summary>
        Millimeters,

        /// <summary>The centimeters.</summary>
        Centimeters,

        /// <summary>The inches.</summary>
        Inches,

        /// <summary>The feet.</summary>
        Feet,

        /// <summary>The yards.</summary>
        Yards,

        /// <summary>The meters.</summary>
        Meters,

        /// <summary>The miles.</summary>
        Miles,

        /// <summary>The kilometers.</summary>
        Kilometers,

        /// <summary>The hectares.</summary>
        Hectares,

        /// <summary>The acres.</summary>
        Acres,

        /// <summary>The unknown unit</summary>
        Unknown
    }

    /// <summary>
    /// The measurement types.
    /// </summary>
    /// <remarks>This should be in the MW core</remarks>
    public enum MeasurementTypes
    {
        /// <summary>The area.</summary>
        Area,

        /// <summary>The perimeter.</summary>
        Perimeter,

        /// <summary>The length.</summary>
        Length
    }

    /// <summary>
    /// Groups of fuctions for field calculator
    /// </summary>
    public enum CalculatorFunction
    {
        Shapes = 0,
        Operators = 1,
        Booleans = 2,
        Maths = 3,
        Angles = 4,
        Statistics = 5,
        Time = 6,
        Other = 7,
        Constants = 8,
    }

    public enum JoinsCommand
    {
        Join = 0,
        EditJoin = 1,
        Stop = 2,
        StopAll = 3,
    }

    public enum JoinSourceType
    {
        Dbf = 0,
        Xls = 1,
        Csv = 2,
    }
}
