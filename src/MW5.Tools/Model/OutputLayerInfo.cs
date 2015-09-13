// -------------------------------------------------------------------------------------------
// <copyright file="OutputLayerInfo.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System.IO;
using MW5.Api.Interfaces;
using MW5.Tools.Helpers;
using MW5.Tools.Model.Layers;

namespace MW5.Tools.Model
{
    public class OutputLayerInfo
    {
        private string _path = string.Empty;
        private string _nameTemplate = string.Empty;

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

        public string GetTemplateName(string extension)
        {
            return Path.ChangeExtension(_nameTemplate, extension);
        }

        private string GetTemplatedFilename(string inputFilename)
        {
            string path = _path;

            if (string.IsNullOrWhiteSpace(path) && !string.IsNullOrWhiteSpace(inputFilename))
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

        /// <summary>
        /// Gets or sets the datasource pointer to be used to delete the previous output on reruning the tool.
        /// </summary>
        /// <remarks>This property should be set manually when GisTool.AfterRun is overriden without the use
        /// of OutputManager.</remarks>
        public DatasourcePointer DatasourcePointer { get; set; }
    }
}