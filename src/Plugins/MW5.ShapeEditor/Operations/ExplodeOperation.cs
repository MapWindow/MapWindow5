using System.Collections.Generic;
using System.Linq;

namespace MW5.Plugins.ShapeEditor.Operations
{
    //internal static class ExplodeOperation
    //{
    //    /// <summary>
    //    /// Merges selected shapes of the active shapefile
    //    /// </summary>
    //    internal static ExplodeResult Explode()
    //    {
    //        var sf = App.SelectedShapefile;
    //        if (sf == null) return ExplodeResult.NoInput;
    //        if (sf.NumSelected < 1) return ExplodeResult.NoInput;
    //        if (!sf.InteractiveEditing) return ExplodeResult.NoInput;
    //        if (!sf.HasMultiPart()) return ExplodeResult.NoMultiPart;
    //        return Explode(App.Legend.SelectedLayer, sf);
    //    }

    //    /// <summary>
    //    /// Runs explode operation
    //    /// </summary>
    //    private static ExplodeResult Explode(int layerHandle, Shapefile sf)
    //    {
    //        var dict = new Dictionary<int, Shape[]>();
            
    //        // exploding
    //        for (int i = 0; i < sf.NumShapes; i++)
    //        {
    //            object result = null;
    //            if (sf.ShapeSelected[i])
    //            {
    //                sf.Shape[i].Explode(ref result);
    //                var shapes = result as object[];
    //                if (shapes != null && shapes.Any())
    //                    dict[i] = shapes.Cast<Shape>().ToArray();
    //                else
    //                    return ExplodeResult.Failed;
    //            }
    //        }

    //        int newSelectionStart = sf.NumShapes - sf.NumSelected;
    //        var undoList = App.Map.UndoList;
    //        undoList.BeginBatch();

    //        // add new shapes
    //        var list = dict.ToList();
    //        foreach (var item in list)
    //        {
    //            foreach (var shp in item.Value.ToList())
    //            {
    //                int shapeIndex = sf.EditAddShape(shp);

    //                sf.CopyAttributes(item.Key, shapeIndex);

    //                if (shapeIndex != -1)
    //                    undoList.Add(tkUndoOperation.uoAddShape, layerHandle, shapeIndex);
    //            }
    //        }

    //        // remove the old ones
    //        for (int i = sf.NumShapes - 1; i >= 0; i--)
    //        {
    //            if (sf.ShapeSelected[i])
    //            {
    //                undoList.Add(tkUndoOperation.uoRemoveShape, layerHandle, i);
    //                sf.EditDeleteShape(i);
    //            }
    //        }

    //        undoList.EndBatch();

    //        for (int i = newSelectionStart; i < sf.NumShapes; i++)
    //        {
    //            sf.ShapeSelected[i] = true;
    //        }

    //        return ExplodeResult.Ok;
    //    }
    //}
}
