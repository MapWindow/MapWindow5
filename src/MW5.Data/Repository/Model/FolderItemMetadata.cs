namespace MW5.Data.Repository.Model
{
    public class FolderItemMetadata
    {
        public FolderItemMetadata(string path, bool root)
        {
            Path = path;
            Root = root;
        }

        public string Path { get; private set; }

        public bool Root { get; private set; }
    }
}
