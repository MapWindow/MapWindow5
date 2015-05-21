using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using MW5.Plugins;
using MW5.Plugins.Enums;
using MW5.Plugins.Helpers;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Services;
using MW5.Services.Helpers;
using MW5.Services.Serialization;
using MW5.Services.Serialization.Legacy;
using MW5.Shared;

namespace MW5.Services.Concrete
{
    public class ProjectService: IProjectService, IProject
    {
        private const string ProjectFilter = "MapWindow 5 project (*.mwproj)|*.mwproj|MapWindow 4 project (*.mwprj)|*.mwprj|All projects|*.mwprj;*.mwproj";
        private const int ProjectFilterIndex = 3;

        private readonly IAppContext _context;
        private readonly IFileDialogService _fileService;
        private readonly IBroadcasterService _broadcaster;
        private readonly IProjectLoader _projectLoader;
        private readonly ProjectLoaderLegacy _projectLoaderLegacy;
        private string _filename = string.Empty;
        private bool _modified;

        public ProjectService(IAppContext context, IFileDialogService fileService, 
         IBroadcasterService broadcaster, IProjectLoader projectLoader, ProjectLoaderLegacy projectLoaderLegacy)
        {
            if (context == null) throw new ArgumentNullException("context");
            if (fileService == null) throw new ArgumentNullException("fileService");
            if (broadcaster == null) throw new ArgumentNullException("broadcaster");
            if (projectLoader == null) throw new ArgumentNullException("projectLoader");
            if (projectLoaderLegacy == null) throw new ArgumentNullException("projectLoaderLegacy");

            _context = context;
            _fileService = fileService;
            _broadcaster = broadcaster;
            _projectLoader = projectLoader;
            _projectLoaderLegacy = projectLoaderLegacy;
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
            
            if (TryCloseCore())
            {
                _context.Map.GeometryEditor.Clear();
                _context.Legend.Groups.Clear();
                _context.Legend.Layers.Clear();
                _context.Map.SetDefaultExtents();
                _context.Locator.Clear();

                _broadcaster.BroadcastEvent(p => p.ProjectClosed_, this, args);
                return true;
            }
            return false;
        }

        private bool TryCloseCore()
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

                    var result = MessageService.Current.AskWithCancel(prompt);
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

                    MessageService.Current.Info("Project was saved: " + filename);
                }
            }
            catch (Exception ex)
            {
                MessageService.Current.Warn("Failed to save project: " + ex.Message);
            }
        }

        public bool Open()
        {
            string filename;
            if (_fileService.Open(ProjectFilter, out filename, ProjectFilterIndex))
            {
                if (!TryClose())
                {
                    return false;
                }

                if (filename.ToLower().EndsWith(".mwproj"))
                {
                    Open(filename);
                }
                else
                {
                    OpenLegacyProject(filename);
                }
            }
            return false;
        }

        private bool CheckProjectFilename(string filename, bool silent)
        {
            if (string.IsNullOrWhiteSpace(filename))
            {
                return false;
            }

            if (!File.Exists(filename))
            {
                if (!silent)
                {
                    MessageService.Current.Info("Project file wasn't found: " + filename);
                }
                
                return false;
            }

            return true;
        }

        public void OpenLegacyProject(string filename, bool silent = false)
        {
            if (!CheckProjectFilename(filename, silent))
            {
                return;
            }
            Logger.Current.Info("Start opening legacy MapWindow 4 project: " + filename);

            using (var reader = new StreamReader(filename))
            {
                string state = reader.ReadToEnd();

                var project = state.DeserializeFromXml<MapWin4Project>();

                bool result = _projectLoaderLegacy.Restore(project, filename);

                _filename = string.Empty;       // it must be saved in a new format

                if (!silent)
                {
                    MessageService.Current.Info("Project was loaded: " + result);
                }

                Logger.Current.Info("Project was loaded: " + result);
            }
        }

        public void Open(string filename, bool silent = false)
        {
            if (!CheckProjectFilename(filename, silent))
            {
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
                    MessageService.Current.Info("Project was loaded: " + filename);
                }

                Logger.Current.Info("Project was loaded: " + filename);
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
