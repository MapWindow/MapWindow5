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
        SelectAll = 8,
        ClearSelection = 9,
        InvertSelection = 10,
        CalculateField = 11,
        Join = 12,
        LayoutTabbed = 13,
        LayoutHorizontal = 14,
        LayoutVertical = 15,
        UpdateMeasurements = 16,
        Find = 17,
        FindNext = 18,
        Replace = 19,
        FieldSortAsc = 20,
        FieldSortDesc = 21,
        FieldHide = 22,
        FieldStats = 23,
        FieldProperties = 24,
        RemoveFields = 25,
        ShowAliases = 26,
        ShowAllFields = 27,
        ReloadTable = 28,
        ImportFieldDefinitions = 29,
        StopJoins = 30,
        ZoomToCurrentCell = 31,
        ExportSelected = 32,
        Query = 33,
        AttributeExplorer = 34,
        ClearSorting = 35,
        RecalculateFields = 36,
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

    public enum UpdateMeasurementType
    {
        Ignore = 0,
        ExistingField = 1,
        NewField = 2,
    }

    public enum MatchType
    {
        Contains = 0,
        Match = 1,
        Start = 2,
    }

    public enum SearchDirection
    {
        Down = 0,
        Up = 1,
    }

    public enum FindReplaceFieldType
    {
        Regular = 0,
        All = 1,
    }

    public enum RecalculateFieldResult
    {
        None = 0,
        Failure = 1,
        SomeRows = 2,
        Success = 3,
    }
}
