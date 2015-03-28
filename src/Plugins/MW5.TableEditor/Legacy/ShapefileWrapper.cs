using System.IO;
using MapWinGIS;
using MW5.Plugins.TableEditor.Legacy;

namespace MW5.Plugins.TableEditor.BO
{
    /// <summary>
    ///  Class for handling and communicating with the shapefile
    /// </summary>
    public class ShapefileWrapper
    {
        /// <summary>Status if file is readonly</summary>
        private bool? _isDiskFileReadOnly;

        /// <summary>The shapefile-sourcetype</summary>
        private tkShapefileSourceType _sourceType;

        /// <summary>Gets or sets the shapefile</summary>
        public Shapefile Shapefile { get; set; }

        /// <summary>Gets or sets the name of the shapefile</summary>
        public string ShapefileName { get; set; }

        /// <summary>Gets a reference to the shapedata-object</summary>
        public ShapeData ShapeData
        {
            get { return new ShapeData(Shapefile); }
        }

        /// <summary>Gets the shapefile-sourcetype</summary>
        public tkShapefileSourceType SourceType
        {
            get
            {
                if (_sourceType == tkShapefileSourceType.sstUninitialized)
                {
                    _sourceType = Shapefile.SourceType;
                }

                return _sourceType;
            }
        }

        /// <summary>Gets a value indicating whether the file is readonly</summary>
        public bool IsDiskFileReadOnly
        {
            get
            {
                if (_isDiskFileReadOnly == null)
                {
                    _isDiskFileReadOnly = (File.GetAttributes(Shapefile.Filename.Replace(".shp", ".dbf")) & FileAttributes.ReadOnly) ==
                                          FileAttributes.ReadOnly;
                }

                return (bool) _isDiskFileReadOnly;
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