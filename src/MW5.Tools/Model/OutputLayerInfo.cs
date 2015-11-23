// -------------------------------------------------------------------------------------------
// <copyright file="OutputLayerInfo.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.IO;
using MW5.Api.Interfaces;
using MW5.Tools.Helpers;
using MW5.Tools.Model.Layers;

namespace MW5.Tools.Model
{
    /// <summary>
    /// Defines the output settings for the GIS tool.
    /// </summary>
    public class OutputLayerInfo
    {
        public const string EmptyPathPrompt = "<ENTER_YOUR_PATH>";
        private string _nameTemplate = string.Empty;
        private string _path = string.Empty;

        /// <summary>
        /// Gets or sets a value indicating whether the output should be added to the map.
        /// </summary>
        public bool AddToMap { get; set; }

        public string TemplatedPath
        {
            get { return _path; }
        }

        /// <summary>
        /// Gets or sets the datasource pointer to be used to delete the previous output on reruning the tool.
        /// </summary>
        /// <remarks>This property should be set manually when GisTool.AfterRun is overriden without the use
        /// of OutputManager.</remarks>
        public DatasourcePointer DatasourcePointer { get; set; }

        /// <summary>
        /// Gets or sets the filename of the output.
        /// </summary>
        public string Filename { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether output saved as memory layer and not to be saved to the disk.
        /// </summary>
        public bool MemoryLayer { get; set; }

        /// <summary>
        /// Gets the name of the output without full pass or extension.
        /// </summary>
        public string Name
        {
            get { return Path.GetFileNameWithoutExtension(Filename); }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the output must overwrite any existing files with the same name.
        /// </summary>
        public bool Overwrite { get; set; }

        /// <summary>
        /// Gets or sets the result value. 
        /// </summary>
        /// Datasource assigned to this property will automatially be saved by default implementation of the GisTool.
        /// <remarks>
        /// </remarks>
        public IDatasource Result { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the validation of output parameter should be skipped.
        /// </summary>
        public bool SkipValidation { get; set; }

        /// <summary>
        /// Resolves the template name based on specified input name.
        /// </summary>
        /// <param name="inputFilename">The input filename.</param>
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

        /// <summary>
        /// Sets the template for output name.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="nameTemplate">The name template.</param>
        public void SetTemplate(string path, string nameTemplate)
        {
            _path = path;
            _nameTemplate = nameTemplate;
        }

        /// <summary>
        /// Validates the output.
        /// </summary>
        /// <param name="message">Error message set in case of failed validation.</param>
        /// <returns>True of output settings are valid.</returns>
        public bool Validate(out string message)
        {
            if (SkipValidation)
            {
                message = string.Empty;
                return true;
            }

            if (string.IsNullOrWhiteSpace(Filename))
            {
                message = "Output layer name is empty.";
                return false;
            }

            if (MemoryLayer && !AddToMap)
            {
                message = "Add to the map flag must be selected for memory layer.";
                return false;
            }

            if (!Path.IsPathRooted(Filename) && !MemoryLayer)
            {
                message = "Please select a target folder to save output.";
                return false;
            }

            bool fileExists = false;
            
            try
            {
                fileExists = File.Exists(Filename);
            }
            catch (ArgumentException ex)
            {
                message = "Invalid output name.";
                return false;
            }

            if (!MemoryLayer && !Overwrite && fileExists)
            {
                message = "The selected file name already exists but no overwrite flag is checked.";
                return false;
            }

            message = string.Empty;
            return true;
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
			// TODO: remove when tested
            //string name = Path.GetFileNameWithoutExtension(inputLayerName);
            //return _nameTemplate.Replace(TemplateNameResolver.Input, name);

            return TemplateNameResolver.Resolve(inputLayerName, _nameTemplate, true);
        }
    }
}