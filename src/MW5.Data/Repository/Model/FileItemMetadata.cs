using System;

namespace MW5.Data.Repository.Model
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
