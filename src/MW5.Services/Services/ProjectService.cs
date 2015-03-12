using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Interfaces;
using MW5.Services.Serialization;
using MW5.Services.Serialization.Utility;
using MW5.Services.Services.Abstract;

namespace MW5.Services.Services
{
    public class ProjectService: IProjectService
    {
        private const string PROJECT_FILTER = "*.mwproj|*.mwproj";

        private readonly IFileDialogService _fileService;
        private readonly IMessageService _messageService;

        public ProjectService(IFileDialogService fileService, IMessageService messageService)
        {
            if (fileService == null) throw new ArgumentNullException("fileService");
            if (messageService == null) throw new ArgumentNullException("messageService");

            _fileService = fileService;
            _messageService = messageService;
        }

        public bool Save(ISerializableContext context)
        {
            string filename;
            if (_fileService.SaveFile(PROJECT_FILTER, out filename))
            {
                var project = new XmlProject(context);
                string state = project.Serialize(false);
                using (var writer = new StreamWriter(filename))
                {
                    writer.Write(state);
                    writer.Flush();

                    _messageService.Info("Project was saved: " + filename);
                    return true;
                }
            }
            return false;
        }

        public bool Open(ISerializableContext context)
        {
            string filename;
            if (_fileService.Open(PROJECT_FILTER, out filename))
            {
                using (var reader = new StreamReader(filename))
                {
                    string state = reader.ReadToEnd();
                    var project = state.Deserialize<XmlProject>();
                    project.RestoreState(context);

                    _messageService.Info("Project was loaded: " + filename);
                }
            }
            return false;
        }
    }
}
