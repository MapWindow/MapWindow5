using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MW5.Plugins.Services;

namespace MW5.Services.Concrete
{
    public class TempFileService : ITempFileService
    {
        private readonly HashSet<string> _files = new HashSet<string>();

        public void DeleteAll()
        {
            foreach (var s in _files)
            {
                try
                {
                    if (File.Exists(s))
                    {
                        File.Delete(s);
                    }
                }
                catch (Exception)
                {
                    
                }
            }
        }

        public void Register(string name)
        {
            name = name.ToLower();
            if (!_files.Contains(name))
            {
                _files.Add(name);
            }
        }

        public string GetTempFilename(string extensionWithDot)
        {
            string path = Path.GetTempFileName();
            Register(path);
            return Path.ChangeExtension(path, extensionWithDot);
        }
    }
}
