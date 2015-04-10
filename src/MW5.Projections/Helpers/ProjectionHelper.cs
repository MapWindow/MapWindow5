using System;
using System.IO;
using MW5.Api;
using MW5.Api.Concrete;
using MW5.Api.Enums;
using MW5.Api.Interfaces;
using MW5.Api.Static;
using MW5.Plugins;
using MW5.Plugins.Enums;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Interfaces.Projections;
using MW5.Plugins.Services;
using MW5.Projections.UI.Forms;

namespace MW5.Projections.Helpers
{
    public static class ProjectionHelper
    {
        /// <summary>
        /// Displays UI allowing the user to change map projection.
        /// </summary>
        /// <param name="context">The context.</param>
        public static void ChangeProjection(this IAppContext context)
        {
            using (var form = new ChooseProjectionForm(context.Projections, context))
            {
                if (context.View.ShowChildView(form))
                {
                    var cs = form.SelectedCoordinateSystem;
                    var sr = new SpatialReference();
                    if (!sr.ImportFromEpsg(cs.Code))
                    {
                        MessageService.Current.Warn("Failed to initialize projection: " + cs.Code);
                        return;
                    }

                    context.SetMapProjection(sr);
                }
            }
        }

        /// <summary>
        /// Sets map projection, tries to find it it in the database.
        /// </summary>
        public static void SetProjection(this IAppContext context, ISpatialReference projection)
        {
            // Let's place it in AppContext for the time being;
            // later on perhaps would be better to move it to a separate class
            if (context.Map.Layers.Count > 0 && !projection.IsEmpty)
            {
                MessageService.Current.Info("It's not possible to change projection after data layers were added to the map.");
                return;
            }

            // try to seek it in the database
            var cs = context.Projections.GetCoordinateSystem(projection, ProjectionSearchType.Standard) ??
                     context.Projections.GetCoordinateSystem(projection, ProjectionSearchType.UseDialects);

            if (cs != null)
            {
                var proj = new SpatialReference();
                if (proj.ImportFromEpsg(cs.Code))
                {
                    projection = proj;
                }
            }

            context.Map.Projection = projection;
        }

        /// <summary>
        /// Displays properties of the current map projection.
        /// </summary>
        public static void ShowProjectionProperties(this IAppContext context)
        {
            var cs = context.Projections.GetCoordinateSystem(context.Map.Projection, ProjectionSearchType.UseDialects);
            if (cs != null)
            {
                using (var form = new ProjectionPropertiesForm(cs, context.Projections))
                {
                    context.View.ShowChildView(form);
                }
            }
            else
            {
                using (var form = new ProjectionPropertiesForm(context.Map.Projection))
                {
                    context.View.ShowChildView(form);
                }
            }
        }

        public static bool IsDialectOf(this IProjectionDatabase projectionDatabase, ISpatialReference multiDefinedProj, ISpatialReference testProj)
        {
            if (multiDefinedProj.IsEmpty)
            {
                return false;
            }

            var db = projectionDatabase;
            if (db == null)
            {
                return false;
            }

            var cs = db.GetCoordinateSystem(multiDefinedProj, ProjectionSearchType.Enhanced);
            if (cs == null)
            {
                return false;
            }

            db.ReadDialects(cs);

            foreach (var dialect in cs.Dialects)
            {
                var projTemp = new SpatialReference();
                if (!projTemp.ImportFromAutoDetect(dialect))
                {
                    continue;
                }

                if (testProj.IsSame(projTemp))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Projection name is written as suffix to the filename in case of reprojection.
        /// Let's try to find file with the same name, but correct suffix for projection.
        /// It's assumed here that projection for the layer passed doesn't match the project one.
        /// </summary>
        public static bool SeekSubstituteFile(this ILayerSource layer, ISpatialReference targetProjection, out ILayerSource newLayer)
        {
            newLayer = null;
            string testName = FilenameWithProjectionSuffix(layer.Filename, layer.Projection, targetProjection);

            if (!File.Exists(testName))
            {
                return false;
            }

            var layerTest = GeoSource.Open(testName) as ILayerSource;
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
        /// Gets filename with correct projection suffix included in it.
        /// </summary>
        /// <remarks>It's used to search for substitute file, or to create reprojected file</remarks>
        public static string FilenameWithProjectionSuffix(string filename, ISpatialReference oldProjection, ISpatialReference newProjection)
        {
            if (String.IsNullOrWhiteSpace(filename))
            {
                return filename;
            }

            // projection name will be included in file name
            string oldProjName = oldProjection.Name;
            oldProjName = oldProjName.Replace(@"/", "-");

            string testName;
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
            return testName + "." + newProjName + extention;
        }
    }
}
