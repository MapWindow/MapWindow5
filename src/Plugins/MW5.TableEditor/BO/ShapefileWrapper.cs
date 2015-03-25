using System.IO;
using MapWinGIS;

namespace MW5.Plugins.TableEditor.BO
{
    /// <summary>
    ///  Class for handling and communicating with the shapefile
    /// </summary>
    public class ShapefileWrapper
    {
        /// <summary>Status if file is readonly</summary>
        private bool? isDiskFileReadOnly;

        /// <summary>The shapefile-sourcetype</summary>
        private tkShapefileSourceType sourceType;

        /// <summary>Gets or sets the shapefile</summary>
        public Shapefile ShapeFile { get; set; }

        /// <summary>Gets or sets the name of the shapefile</summary>
        public string ShapefileName { get; set; }

        /// <summary>Gets a reference to the shapedata-object</summary>
        public ShapeData ShapeData
        {
            get { return new ShapeData(ShapeFile); }
        }

        /// <summary>Gets the shapefile-sourcetype</summary>
        public tkShapefileSourceType SourceType
        {
            get
            {
                if (sourceType == tkShapefileSourceType.sstUninitialized)
                {
                    sourceType = ShapeFile.SourceType;
                }

                return sourceType;
            }
        }

        /// <summary>Gets a value indicating whether the file is readonly</summary>
        public bool IsDiskFileReadOnly
        {
            get
            {
                if (isDiskFileReadOnly == null)
                {
                    if ((File.GetAttributes(ShapeFile.Filename.Replace(".shp", ".dbf")) & FileAttributes.ReadOnly) ==
                        FileAttributes.ReadOnly)
                    {
                        isDiskFileReadOnly = true;
                    }
                    else
                    {
                        isDiskFileReadOnly = false;
                    }
                }

                return (bool) isDiskFileReadOnly;
            }
        }

        /// <summary>Gets a value indicating whether the data can be changed </summary>
        public bool IsReadOnly
        {
            get
            {
                bool isReadOnly;

                if ((SourceType == tkShapefileSourceType.sstDiskBased && IsDiskFileReadOnly) ||
                    SourceType == tkShapefileSourceType.sstInMemory)
                {
                    isReadOnly = true;
                }
                else
                {
                    isReadOnly = false;
                }

                return isReadOnly;
            }
        }
    }
}