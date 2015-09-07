// -------------------------------------------------------------------------------------------
// <copyright file="OutputLayerInfo.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System.IO;
using MW5.Api.Interfaces;
using MW5.Tools.Helpers;

namespace MW5.Tools.Model
{
    public class OutputLayerInfo
    {
        private string _path;
        private string _nameTemplate;

        public bool AddToMap { get; set; }

        public bool MemoryLayer { get; set; }

        public void ResolveTemplateName(string inputFilename)
        {
            if (MemoryLayer)
            {
                string name = GetTemplatedLayerName(inputFilename);
                Filename = Path.GetFileNameWithoutExtension(name);
            }
            else
            {
                Filename = GetTemplatedFilename(inputFilename);
            }
        }

        private string GetTemplatedFilename(string inputFilename)
        {
            string path = _path;

            if (string.IsNullOrWhiteSpace(path))
            {
                path = Path.GetDirectoryName(inputFilename);
            }

            string inputName = Path.GetFileNameWithoutExtension(inputFilename);
            path += GetTemplatedLayerName(inputName);
            return path;
        }

        private string GetTemplatedLayerName(string inputLayerName)
        {
            string name = Path.GetFileNameWithoutExtension(inputLayerName);
            return _nameTemplate.Replace(TemplateVariables.Input, name);
        }

        public void SetTemplate(string path, string nameTemplate)
        {
            _path = path;
            _nameTemplate = nameTemplate;
        }

        public string Name
        {
            get { return Path.GetFileNameWithoutExtension(Filename); }
        }
 
        public string Filename { get; set; }

        public bool Overwrite { get; set; }

        public IDatasource Result { get; set; }

        public bool Validate(out string message)
        {
            if (string.IsNullOrWhiteSpace(Filename))
            {
                message = "OutputLayer layer name is empty.";
                return false;
            }

            if (MemoryLayer && !AddToMap)
            {
                message = "Add to the map flag must be selected for memory layer.";
                return false;
            }

            if (!MemoryLayer && !Overwrite && File.Exists(Filename))
            {
                message = "The selected file name already exists but no overwrite flag is checked.";
                return false;
            }

            message = string.Empty;
            return true;
        }
    }
}