namespace MW5.Services
{
    public enum DataSourceType
    {
        Vector = 0,
        Raster = 1,
        All = 2,
    }

    public enum ProjectState
    {
        NotSaved = 0,
        HasChanges = 1,
        NoChanges = 2,
        Empty = 3,
    }
}
