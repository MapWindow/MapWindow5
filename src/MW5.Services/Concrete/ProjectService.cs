using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using MW5.Plugins;
using MW5.Plugins.Enums;
using MW5.Plugins.Helpers;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Services;
using MW5.Services.Helpers;
using MW5.Services.Serialization;
using MW5.Shared;

namespace MW5.Services.Concrete
{
    public class ProjectService: IProjectService, IProject
    {
        private const string ProjectFilter = "*.mwproj|*.mwproj";

        private readonly IAppContext _context;
        private readonly IFileDialogService _fileService;
        private readonly IMessageService _messageService;
        private readonly IBroadcasterService _broadcaster;
        private readonly IProjectLoader _projectLoader;
        private string _filename = string.Empty;
        private bool _modified;

        public ProjectService(IAppContext context, IFileDialogService fileService, 
        IMessageService messageService, IBroadcasterService broadcaster, IProjectLoader projectLoader)
        {
            if (context == null) throw new ArgumentNullException("context");
            if (fileService == null) throw new ArgumentNullException("fileService");
            if (messageService == null) throw new ArgumentNullException("messageService");
            if (broadcaster == null) throw new ArgumentNullException("broadcaster");
            if (projectLoader == null) throw new ArgumentNullException("projectLoader");

            _context = context;
            _fileService = fileService;
            _messageService = messageService;
            _broadcaster = broadcaster;
            _projectLoader = projectLoader;
        }

        public bool IsEmpty
        {
            get { return _filename.Length == 0; }
        }

        public string Filename
        {
            get { return _filename; }
        }

        public ProjectState GetState()
        {
            return State;       // don't expose as property or it will cause serialization of state on examining it during debugging
        }

        private ProjectState State
        {
            get
            {
                if (_context.Map.Projection.IsEmpty && _context.Map.Layers.Count == 0)
                {
                    return ProjectState.Empty;
                }

                if (string.IsNullOrWhiteSpace(_filename))
                {
                    return ProjectState.NotSaved;
                }

                try
                {
                    using (var r = new StreamReader(_filename))
                    {
                        var oldState = r.ReadToEnd();
                        var state = SerializeMapState();
                        return state.EqualsIgnoreCase(oldState) && !_modified ? ProjectState.NoChanges : ProjectState.HasChanges;
                    }
                }
                catch
                {
                    return ProjectState.NotSaved;
                }
            }
        }

        public bool TryClose()
        {
            var args = new CancelEventArgs();

            if (!(_context is ISerializableContext))
            {
                throw new ApplicationException("Invalid application context");
            }

            _broadcaster.BroadcastEvent(p => p.ProjectClosing_, this, args);
            if (args.Cancel)
            {
                return false;
            }
            
            if (TryCloseProject())
            {
                _context.Map.GeometryEditor.Clear();
                _context.Legend.Groups.Clear();
                _context.Legend.Layers.Clear();
                _context.Map.SetDefaultExtents();
                _context.Locator.Clear();
                return true;
            }
            return false;
        }

        private bool TryCloseProject()
        {
            var state = State;
            switch (state)
            {
                case ProjectState.NotSaved:
                case ProjectState.HasChanges:
                {
                    string prompt = "Save the project?";

                    if (!string.IsNullOrWhiteSpace(_filename))
                    {
                        prompt = string.Format("Save the project: {0}?", Path.GetFileName(_filename));
                    }

                    var result = _messageService.AskWithCancel(prompt);
                    if (result == DialogResult.Cancel)
                    {
                        return false;
                    }

                    if (result == DialogResult.Yes)
                    {
                        Save();
                    }
                    break;
                }
                case ProjectState.NoChanges:
                case ProjectState.Empty:
                    break;
            }

            SetEmptyProject();
            return true;
        }

        public bool Save()
        {
            string filename = _filename;
            var state = State; 
            
            bool newProject = state == ProjectState.NotSaved || state == ProjectState.Empty;
            if (newProject)
            {
                if (!_fileService.SaveFile(ProjectFilter, ref filename))
                {
                    return false;
                }
            }

            SaveProject(filename);

            if (newProject)
            {
                // OnProjectChanged();
            }
            return true;
        }

        public void SaveAs()
        {
            string filename = _filename;
            if (!_fileService.SaveFile(ProjectFilter, ref filename))
            {
                return;
            }
            SaveProject(filename);
            //OnProjectChanged();
        }

        private void SaveProject(string filename)
        {
            string state = SerializeMapState();

            try
            {
                using (var writer = new StreamWriter(filename))
                {
                    writer.Write(state);
                    writer.Flush();
                    _filename = filename;
                    _modified = false;

                    _messageService.Info("Project was saved: " + filename);
                }
            }
            catch (Exception ex)
            {
                _messageService.Warn("Failed to save project: " + ex.Message);
            }
        }

        public bool Open()
        {
            string filename;
            if (_fileService.Open(ProjectFilter, out filename))
            {
                if (!TryClose())
                {
                    return false;
                }
                
                Open(filename);
            }
            return false;
        }

        public void Open(string filename, bool silent = false)
        {
            if (string.IsNullOrWhiteSpace(filename))
            {
                return;
            }

            if (!File.Exists(filename))
            {
                if (!silent)
                {
                    _messageService.Info("Project file wasn't found: " + filename);
                }
                return;
            }

            using (var reader = new StreamReader(filename))
            {
                string state = reader.ReadToEnd();
                var project = state.Deserialize<XmlProject>();

                _projectLoader.Restore(project);
                _filename = filename;

                if (!silent)
                {
                    _messageService.Info("Project was loaded: " + filename);
                }
            }

            //OnProjectChanged();
        }

        public void SetModified()
        {
            _modified = true;
        }

        public bool Modified
        {
            get
            {
                var state = State;
                return (state == ProjectState.NotSaved || state == ProjectState.HasChanges);
            }
        }

        private string SerializeMapState()
        {
            var project = new XmlProject(_context as ISerializableContext);
            return project.Serialize(false);
        }

        private void SetEmptyProject()
        {
            _filename = "";
            //OnProjectChanged();
        }
    }
}
