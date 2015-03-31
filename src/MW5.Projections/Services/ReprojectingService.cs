using System;
using System.Diagnostics;
using System.IO;
using MW5.Api;
using MW5.Api.Concrete;
using MW5.Api.Helpers;
using MW5.Api.Interfaces;
using MW5.Api.Static;
using MW5.Projections.UI.Forms;

namespace MW5.Projections.Services
{
    /// <summary>
    /// Performs transformation of shapefiles, images and grids from one coordinate system to another
    /// </summary>
    public class ReprojectingService
    {
        /// <summary>
        /// Reprojects layer of undefined type
        /// </summary>
        public static TestingResult ReprojectLayer(ILayerSource layer, out ILayerSource newLayer, ISpatialReference projection, TesterReportForm report)
        {
            if (SeekSubstituteFile(layer, projection, out newLayer))
            {
                return TestingResult.Substituted;
            }

            string newFilename = FilenameWithProjectionSuffix(layer.Filename, layer.Projection, projection);
            newFilename = GetSafeNewName(newFilename);
            
            switch(layer.LayerType)
            {
                case LayerType.Shapefile:
                    newLayer = Reproject(layer as IFeatureSet, projection, newFilename);
                    break;
                case LayerType.Grid:
                    newLayer = Reproject(layer as GridSource, projection, newFilename);
                    break;
                case LayerType.Image:
                    newLayer = Reproject(layer as BitmapSource, projection, newFilename);
                    break;
            }
            return newLayer != null ? TestingResult.Ok : TestingResult.Error;
        }

        private static IFeatureSet Reproject(IFeatureSet fsSource, ISpatialReference newProjection, string saveAsFilename)
        {
            int count = 0;

            var fs = fsSource.Reproject(newProjection, ref count);

            if (fs == null)
            {
                return null;
            }

            if (count == fsSource.Features.Count)
            {
                bool result = fs.SaveAs(saveAsFilename);
                if (!result)
                {
                    throw new ApplicationException("Error while saving reprojected shapefile: " + fs.LastError);
                }

                return fs;
            }

            fs.Close();
            return null;
        }

        /// <summary>
        /// Reprojects a grid
        /// </summary>
        public static GridSource Reproject(GridSource grid, ISpatialReference newProjection, string saveAsFilename)
        {
            // TODO: implement
            //bool result = MapWinGeoProc.SpatialReference.ProjectGrid(ref sourcePrj, ref targetPrj, ref origFilename, ref newFilename, true, report);

            var gridNew = new GridSource(saveAsFilename);
            //gridNew.AssignNewProjection(newProjection.ExportToProj4());

            return gridNew;
        }
        
        /// <summary>
        /// Reprojects image
        /// </summary>
        public static IImageSource Reproject(IImageSource image, ISpatialReference projection, string saveAsFilename)
        {
            // TODO: implement
            //MapWinGeoProc.SpatialReference.ProjectImage(sourcePrj, targetPrj, origFilename, newFilename, report);

            return BitmapSource.Open(saveAsFilename, false);
        }

        
        /// <summary>
        /// Gets filename with correct projection suffix included in it
        /// It's used to search for substitute file, or to create reprojected file
        /// </summary>
        /// <returns></returns>
        public static string FilenameWithProjectionSuffix(string filename, ISpatialReference oldProjection, ISpatialReference newProjection)
        {
            if (String.IsNullOrWhiteSpace(filename))
            {
                return filename;
            }

            // projection name will be included in file name
            string oldProjName = oldProjection.Name;
            oldProjName = oldProjName.Replace(@"/", "-");

            var testName = "";
            string extention = Path.GetExtension(filename);
            if (filename.EndsWith("." + oldProjName + extention, StringComparison.OrdinalIgnoreCase))
            {
                // in case current projection included in file name already, it should be be removed
                testName = filename.Substring(0, filename.Length - oldProjName.Length - extention.Length - 1);
            }
            else
            {
                // otherwise take the whole name
                testName = Path.GetDirectoryName(filename) + @"\" + Path.GetFileNameWithoutExtension(filename);
            }

            string newProjName = newProjection.Name.Replace(@"/", @"-");
            return testName = testName + "." + newProjName + extention;
        }

        /// <summary>
        /// Projection name is written as suffix to the filename in case of reprojection.
        /// Let's try to find file with the same name, but correct suffix for projection.
        /// It's assumed here that projection for the layer passed doesn't match the project one.
        /// </summary>
        public static bool SeekSubstituteFile(ILayerSource layer, ISpatialReference targetProjection, out ILayerSource newLayer)
        {
            newLayer = null;
            string testName = FilenameWithProjectionSuffix(layer.Filename, layer.Projection, targetProjection);

            if (!File.Exists(testName))
            {
                return false;
            }

            var layerTest = GeoSourceManager.Open(testName) as ILayerSource;
            if (layerTest == null)
            {
                return false;
            }

            //if (layerTest.Type != layer.Type)
            //{
            //    return false;
            //}

            var f1 = new FileInfo(layer.Filename);
            var f2 = new FileInfo(testName);

            // the size of .shp files must be exactly the same
            bool equalSize = !(layerTest.LayerType == LayerType.Shapefile && f1.Length != f2.Length);
                
            if (layerTest.Projection.IsSameExt(targetProjection, layerTest.Envelope, 10) && equalSize)
            {
                newLayer = layerTest;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Returns new filename and ensures that such file doesn't exist. 
        /// Adds index if necessary.
        /// </summary>
        public static string GetSafeNewName(string filename)
        {
            int index = 0;
            string testName = filename;
            while (File.Exists(testName))
            {
                testName = Path.GetFileNameWithoutExtension(filename) + "_" + index + Path.GetExtension(filename);
                index++;
            }
            return testName;
        }
    }
}
