// -------------------------------------------------------------------------------------------
// <copyright file="OutputLayerInfo.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System.IO;

namespace MW5.Tools.Model
{
    public class OutputLayerInfo
    {
        public bool AddToMap { get; set; }

        public bool MemoryLayer { get; set; }

        public string Name { get; set; }

        public bool Overwrite { get; set; }

        public bool Validate(out string message)
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                message = "OutputLayer layer name is empty.";
                return false;
            }

            if (MemoryLayer && !AddToMap)
            {
                message = "Add to the map flag must be selected for memory layer.";
                return false;
            }

            if (!MemoryLayer && !Overwrite && File.Exists(Name))
            {
                message = "The selected file name already exists but no overwrite flag is checked.";
                return false;
            }

            message = string.Empty;
            return true;
        }
    }
}