using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Concrete;
using MW5.Api.Interfaces;
using MW5.Plugins;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Services;
using MW5.Projections.UI.Forms;

namespace MW5.Helpers
{
    // TODO: perhaps make an instance class out of it
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

            context.Map.GeoProjection = projection;
        }

        /// <summary>
        /// Displays properties of the current map projection.
        /// </summary>
        public static void ShowProjectionProperties(this IAppContext context)
        {
            var cs = context.Projections.GetCoordinateSystem(context.Map.GeoProjection, ProjectionSearchType.UseDialects);
            if (cs != null)
            {
                using (var form = new ProjectionPropertiesForm(cs, context.Projections))
                {
                    context.View.ShowChildView(form);
                }
            }
            else
            {
                using (var form = new ProjectionPropertiesForm(context.Map.GeoProjection))
                {
                    context.View.ShowChildView(form);
                }
            }
        }
    }
}
