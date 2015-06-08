using MW5.Plugins.Enums;

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
        bool Open(string filename, bool silent = false);
        void SetModified();
        bool Modified { get; }
    }
}
