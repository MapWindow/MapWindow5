using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Plugins.Interfaces;
using MW5.Services.Helpers;
using MW5.Services.Serialization;
using MW5.Services.Serialization.Utility;
using MW5.Services.Services.Abstract;

namespace MW5.Services.Services
{
    public class ProjectService: IProjectService, IProject
    {
        private const string PROJECT_FILTER = "*.mwproj|*.mwproj";

        private readonly IAppContext _context;
        private readonly IFileDialogService _fileService;
        private readonly IMessageService _messageService;
        private string _filename = string.Empty;
        private bool _modified;

        public ProjectService(IAppContext context, IFileDialogService fileService, IMessageService messageService)
        {
            if (context == null) throw new ArgumentNullException("context");
            if (fileService == null) throw new ArgumentNullException("fileService");
            if (messageService == null) throw new ArgumentNullException("messageService");

            _context = context;
            _fileService = fileService;
            _messageService = messageService;
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
                if (_context.Map.GeoProjection.IsEmpty && _context.Map.Layers.Count == 0)
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

            var broadcaster = ((ISerializableContext) _context).PluginManager.Broadcaster;
            broadcaster.BroadcastEvent(p => p.ProjectClosing_, this, args);
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
            
            bool newProject = State == ProjectState.NotSaved;
            if (newProject)
            {
                if (!_fileService.SaveFile(PROJECT_FILTER, ref filename))
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
            if (!_fileService.SaveFile(PROJECT_FILTER, ref filename))
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
            if (_fileService.Open(PROJECT_FILTER, out filename))
            {
                if (!TryClose())
                {
                    return false;
                }
                
                Open(filename);
            }
            return false;
        }

        public void Open(string filename)
        {
            if (string.IsNullOrWhiteSpace(filename))
            {
                return;
            }

            if (!File.Exists(filename))
            {
                _messageService.Info("Project file wasn't found: " + filename);
                return;
            }

            using (var reader = new StreamReader(filename))
            {
                string state = reader.ReadToEnd();
                var project = state.Deserialize<XmlProject>();
                project.RestoreState(_context as ISerializableContext);
                _filename = filename;

                _messageService.Info("Project was loaded: " + filename);
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
