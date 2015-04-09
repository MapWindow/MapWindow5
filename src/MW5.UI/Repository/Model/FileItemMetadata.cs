using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.UI.Repository.Model
{
    internal class FileItemMetadata
    {
        public FileItemMetadata(string filename)
        {
            if (string.IsNullOrWhiteSpace(filename)) throw new ArgumentNullException("filename");
            Filename = filename;
        }

        public string Filename { get; set; }

        public bool AddedToMap { get; set; }
    }
}
