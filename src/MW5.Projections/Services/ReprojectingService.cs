using System;
using System.Diagnostics;
using System.IO;
using MW5.Api;
using MW5.Api.Concrete;
using MW5.Api.Helpers;
using MW5.Api.Interfaces;
using MW5.Api.Static;
using MW5.Plugins.Services;
using MW5.Projections.Helpers;
using MW5.Projections.Services.Abstract;
using MW5.Projections.UI.Forms;

namespace MW5.Projections.Services
{
    /// <summary>
    /// Reprojects shapefiles, images and grids from one coordinate system to another.
    /// </summary>
    public class ReprojectingService: IReprojectingService
    {
        /// <summary>
        /// Reprojects layer source, including shapefiles, images and grids.
        /// </summary>
        public TestingResult Reproject(ILayerSource layer, out ILayerSource newLayer, ISpatialReference projection, TesterReportForm report)
        {
            if (layer.SeekSubstituteFile(projection, out newLayer))
            {
                return TestingResult.Substituted;
            }

            string newFilename = ProjectionHelper.FilenameWithProjectionSuffix(layer.Filename, layer.Projection, projection);
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

        /// <summary>
        /// Reprojects the specified vector layer.
        /// </summary>
        private IFeatureSet Reproject(IFeatureSet fsSource, ISpatialReference newProjection, string saveAsFilename)
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
        public GridSource Reproject(GridSource grid, ISpatialReference newProjection, string saveAsFilename)
        {
            // TODO: implement
            //bool result = MapWinGeoProc.SpatialReference.ProjectGrid(ref sourcePrj, ref targetPrj, ref origFilename, ref newFilename, true, report);
            //var gridNew = new GridSource(saveAsFilename);
            //gridNew.AssignNewProjection(newProjection.ExportToProj4());
            
            MessageService.Current.Info("Reprojection of grids isn't implemented");

            return grid;
        }
        
        /// <summary>
        /// Reprojects image
        /// </summary>
        public IImageSource Reproject(IImageSource image, ISpatialReference projection, string saveAsFilename)
        {
            // TODO: implement
            //MapWinGeoProc.SpatialReference.ProjectImage(sourcePrj, targetPrj, origFilename, newFilename, report);
            //return BitmapSource.Open(saveAsFilename, false);

            MessageService.Current.Info("Reprojection of images isn't implemented");

            return image;
        }

        /// <summary>
        /// Returns new filename and ensures that such file doesn't exist. Adds postfix if necessary.
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
