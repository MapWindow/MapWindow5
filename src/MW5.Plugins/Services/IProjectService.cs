namespace MW5.Plugins.Services
{
    public interface IProjectService
    {
        bool IsEmpty { get; }
        string Filename { get; }
        ProjectState GetState();
        bool TryClose();
        bool Save();
        void SaveAs();
        bool Open();
        void Open(string filename, bool silent = false);
        void SetModified();
        bool Modified { get; }
    }
}
