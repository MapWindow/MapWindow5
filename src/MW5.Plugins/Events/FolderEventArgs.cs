namespace MW5.Plugins.Events
{
    public class FolderEventArgs
    {
        public FolderEventArgs(string path)
        {
            Path = path;
        }
        public string Path { get; private set; }
    }
}
