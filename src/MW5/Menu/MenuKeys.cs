namespace MW5.Menu
{
    // TODO: how to distingusih menu items and toolbar items (they can use the same keys
    // since menu and toolbars uses different instance of MenuIndex)
    internal class MenuKeys
    {
        public const string OpenProject = "OpenProject";
        public const string SaveProject = "SaveProject";
        public const string SaveProjectAs = "SaveProjectAs";
        public const string AddLayer = "AddLayer";
        public const string AddVectorLayer = "AddVectorLayer";
        public const string AddRasterLayer = "AddRasterLayer";
        public const string AddDatabaseLayer = "AddDatabaseLayer";
        public const string FileBarCreateLayer = "CreateLayer";
        public const string RemoveLayer = "RemoveLayer";

        public const string ZoomIn = "ZoomIn";
        public const string ZoomOut = "ZoomOut";
        public const string ZoomMax = "ZoomMax";
        public const string ZoomToLayer = "ZoomToLayer";
        public const string Pan = "Pan";
        public const string SetProjection = "SetProjection";
    }
}
