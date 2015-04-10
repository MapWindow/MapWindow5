namespace MW5.Data.Repository
{
    internal class FolderItemMetadata: IItemMetadata
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
