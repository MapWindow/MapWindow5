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
        void Open(string filename);
        void SetModified();
        bool Modified { get; }
    }
}
