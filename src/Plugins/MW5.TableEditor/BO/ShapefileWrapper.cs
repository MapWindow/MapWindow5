// ********************************************************************************************************
// <copyright file="BOShapeFile.cs" company="TopX Geo-ICT">
//     Copyright (c) 2012 TopX Geo-ICT. All rights reserved.
// </copyright>
// ********************************************************************************************************
// The contents of this file are subject to the Mozilla Public License Version 1.1 (the "License"); 
// you may not use this file except in compliance with the License. You may obtain a copy of the License at 
// http:// www.mozilla.org/MPL/ 
// Software distributed under the License is distributed on an "AS IS" basis, WITHOUT WARRANTY OF 
// ANY KIND, either express or implied. See the License for the specificlanguage governing rights and 
// limitations under the License. 
// 
// The Initial Developer of this version is Jeen de Vegt.
// 
// Contributor(s): (Open source contributors should list themselves and their modifications here). 
// Change Log: 
// Date           Changed By      Notes
// 29 March 2012  Jeen de Vegt    Inital coding
// ********************************************************************************************************

using System.IO;
using MapWinGIS;

namespace MW5.Plugins.TableEditor.BO
{
    /// <summary>
    ///  Class for handling and communicating with the shapefile
    /// </summary>
    public class ShapefileWrapper
    {
        /// <summary>The shapefile-sourcetype</summary>
        private tkShapefileSourceType sourceType;

        /// <summary>Status if file is readonly</summary>
        private bool? isDiskFileReadOnly;

        /// <summary>Gets or sets the shapefile</summary>
        public Shapefile ShapeFile { get; set; }

        /// <summary>Gets or sets the name of the shapefile</summary>
        public string ShapefileName { get; set; }

        /// <summary>Gets a reference to the shapedata-object</summary>
        public ShapeData ShapeData
        {
            get
            {
                return new ShapeData(this.ShapeFile);
            }
        }

        /// <summary>Gets the shapefile-sourcetype</summary>
        public tkShapefileSourceType SourceType
        {
            get
            {
                if (this.sourceType == tkShapefileSourceType.sstUninitialized)
                {
                    this.sourceType = this.ShapeFile.SourceType;
                }

                return this.sourceType;
            }
        }

        /// <summary>Gets a value indicating whether the file is readonly</summary>
        public bool IsDiskFileReadOnly
        {
            get
            {
                if (this.isDiskFileReadOnly == null)
                {
                    if ((File.GetAttributes(this.ShapeFile.Filename.Replace(".shp", ".dbf")) & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
                    {
                        this.isDiskFileReadOnly = true;
                    }
                    else
                    {
                        this.isDiskFileReadOnly = false;
                    }
                }

                return (bool)this.isDiskFileReadOnly;
            }
        }

        /// <summary>Gets a value indicating whether the data can be changed </summary>
        public bool IsReadOnly
        {
            get
            {
                bool isReadOnly;

                if ((this.SourceType == tkShapefileSourceType.sstDiskBased && this.IsDiskFileReadOnly) ||
                    this.SourceType == tkShapefileSourceType.sstInMemory)
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
