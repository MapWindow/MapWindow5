using System.Collections.Generic;
using System.Linq;
using MW5.Api;
using MW5.Api.Interfaces;
using MW5.Plugins.Interfaces;
using MW5.Plugins.ShapeEditor.Helpers;

namespace MW5.Plugins.ShapeEditor.Operations
{
    internal static class ExplodeOperation
    {
        /// <summary>
        /// Merges selected shapes of the active shapefile
        /// </summary>
        internal static ExplodeResult Run(IAppContext context)
        {
            var fs = context.Layers.SelectedLayer.FeatureSet;

            if (fs == null || fs.NumSelected == 0 || !fs.InteractiveEditing)
            {
                return ExplodeResult.NoInput;
            }

            if (!fs.HasMultiPart())
            {
                return ExplodeResult.NoMultiPart;
            }

            return Explode(context, fs);
        }

        /// <summary>
        /// Runs explode operation
        /// </summary>
        private static ExplodeResult Explode(IAppContext context, IFeatureSet fs)
        {
            var dict = new Dictionary<int, IGeometry[]>();

            // exploding
            foreach(var ft in fs.Features)
            {
                if (ft.Selected)
                {
                    var arr = ft.Geometry.Explode().ToArray();
                    if (arr.Length > 0)
                    {
                        dict[ft.Index] = arr;
                        continue;
                    }
                    return ExplodeResult.Failed;
                }
            }

            int newSelectionStart = fs.Features.Count - fs.Features.Count(ft => ft.Selected);

            int layerHandle = context.Legend.SelectedLayer;

            var history = context.Map.History;
            history.BeginBatch();

            // add new shapes
            var list = dict.ToList();
            foreach (var item in list)
            {
                foreach (var shp in item.Value.ToList())
                {
                    int shapeIndex = fs.Features.EditAdd(shp);

                    fs.Table.CopyAttributes(item.Key, shapeIndex);

                    if (shapeIndex != -1)
                    {
                        history.Add(UndoOperation.AddShape, layerHandle, shapeIndex);
                    }
                }
            }

            // remove the old ones
            foreach (var ft in fs.Features.Reverse())
            {
                if (ft.Selected)
                {
                    history.Add(UndoOperation.RemoveShape, layerHandle, ft.Index);
                    fs.Features.EditDelete(ft.Index);
                }
            }

            history.EndBatch();

            // selecting new shapes
            for (int i = newSelectionStart; i < fs.Features.Count; i++)
            {
                 fs.Features[i].Selected = true;
            }

            return ExplodeResult.Ok;
        }
    }
}
